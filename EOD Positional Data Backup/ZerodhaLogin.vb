Imports System.Web
Imports System.Net
Imports System.Threading
Imports Utilities.Network
Imports System.Collections.Specialized
Imports Utilities.ErrorHandlers
Imports KiteConnect
Imports Utilities
Imports System.Net.Http

Public Class ZerodhaLogin
    Implements IDisposable

#Region "Events/Event handlers"
    Public Event DocumentDownloadComplete()
    Public Event DocumentRetryStatus(ByVal currentTry As Integer, ByVal totalTries As Integer)
    Public Event Heartbeat(ByVal msg As String)
    Public Event WaitingFor(ByVal elapsedSecs As Integer, ByVal totalSecs As Integer, ByVal msg As String)
    'The below functions are needed to allow the derived classes to raise the above two events
    Protected Overridable Sub OnDocumentDownloadComplete()
        RaiseEvent DocumentDownloadComplete()
    End Sub
    Protected Overridable Sub OnDocumentRetryStatus(ByVal currentTry As Integer, ByVal totalTries As Integer)
        RaiseEvent DocumentRetryStatus(currentTry, totalTries)
    End Sub
    Protected Overridable Sub OnHeartbeat(ByVal msg As String)
        RaiseEvent Heartbeat(msg)
    End Sub
    Protected Overridable Sub OnWaitingFor(ByVal elapsedSecs As Integer, ByVal totalSecs As Integer, ByVal msg As String)
        RaiseEvent WaitingFor(elapsedSecs, totalSecs, msg)
    End Sub
#End Region

    Public Property RequestToken As String
    Public Property AccessToken As String
    Public Property PublicToken As String
    Public Property ENCToken As String

    Public ReadOnly Property UserId As String
    Public ReadOnly Property Password As String
    Public ReadOnly Property APISecret As String
    Public ReadOnly Property APIKey As String
    Public ReadOnly Property APIVersion As String
    Public ReadOnly Property API2FAPin As String

    Private ReadOnly _MaxReTries As Integer = 20
    Private ReadOnly _WaitDurationOnConnectionFailure As TimeSpan = TimeSpan.FromSeconds(5)
    Private ReadOnly _WaitDurationOnServiceUnavailbleFailure As TimeSpan = TimeSpan.FromSeconds(30)
    Private ReadOnly _WaitDurationOnAnyFailure As TimeSpan = TimeSpan.FromSeconds(10)

    Private ReadOnly _LoginURL As String = "https://kite.trade/connect/login"
    Private ReadOnly _cts As CancellationTokenSource
    Public Sub New(ByVal userId As String,
                   ByVal password As String,
                   ByVal apiSecret As String,
                   ByVal apiKey As String,
                   ByVal apiVersion As String,
                   ByVal _2FA As String,
                   ByVal canceller As CancellationTokenSource)
        Me.UserId = userId
        Me.Password = password
        Me.APISecret = apiSecret
        Me.APIKey = apiKey
        Me.APIVersion = apiVersion
        Me.API2FAPin = _2FA
        _cts = canceller
    End Sub

    Private Function GetLoginURL() As String
        Return String.Format("{0}?api_key={1}&v={2}", _LoginURL, Me.APIKey, Me.APIVersion)
    End Function

    Private Function GetErrorResponse(ByVal response As Object) As String
        _cts.Token.ThrowIfCancellationRequested()
        Dim ret As String = Nothing

        If response IsNot Nothing AndAlso
               response.GetType = GetType(Dictionary(Of String, Object)) AndAlso
               CType(response, Dictionary(Of String, Object)).ContainsKey("status") AndAlso
               CType(response, Dictionary(Of String, Object))("status") = "error" AndAlso
               CType(response, Dictionary(Of String, Object)).ContainsKey("message") Then
            ret = String.Format("Zerodha reported error, message:{0}", CType(response, Dictionary(Of String, Object))("message"))
        End If
        Return ret
    End Function

    Public Async Function LoginAsync() As Task(Of Boolean)
        Dim ret As Boolean = False
        While True
            _cts.Token.ThrowIfCancellationRequested()
            Try
                Dim requestToken As String = Nothing

                Dim postContent As New Dictionary(Of String, String)
                postContent.Add("user_id", Me.UserId)
                postContent.Add("password", Me.Password)
                postContent.Add("login", "")

                HttpBrowser.KillCookies()
                _cts.Token.ThrowIfCancellationRequested()

                Using browser As New HttpBrowser(Nothing, DecompressionMethods.GZip, TimeSpan.FromMinutes(1), _cts)
                    AddHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    AddHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                    AddHandler browser.Heartbeat, AddressOf OnHeartbeat
                    AddHandler browser.WaitingFor, AddressOf OnWaitingFor

                    'Keep the below headers constant for all login browser operations
                    browser.UserAgent = GetRandomUserAgent()
                    browser.KeepAlive = True

                    Dim redirectedURI As Uri = Nothing

                    'Now launch the authentication page
                    Dim headers As New Dictionary(Of String, String)
                    headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8")
                    'headers.Add("Accept-Encoding", "gzip, deflate, br")
                    headers.Add("Accept-Encoding", "*")
                    headers.Add("Accept-Language", "en-US,en;q=0.8")
                    headers.Add("Host", "kite.trade")
                    headers.Add("X-Kite-version", Me.APIVersion)

                    OnHeartbeat("Opening login page")
                    'logger.Debug("Opening login page, GetLoginURL:{0}, headers:{1}", GetLoginURL, Utils.JsonSerialize(headers))

                    _cts.Token.ThrowIfCancellationRequested()
                    Dim tempRet As Tuple(Of Uri, Object) = Await browser.NonPOSTRequestAsync(GetLoginURL,
                                                                                              Http.HttpMethod.Get,
                                                                                              Nothing,
                                                                                              False,
                                                                                              headers,
                                                                                              False,
                                                                                              Nothing).ConfigureAwait(False)

                    _cts.Token.ThrowIfCancellationRequested()
                    'Should be getting back the redirected URL in Item1 and the htmldocument response in Item2
                    Dim finalURLToCall As Uri = Nothing
                    If tempRet IsNot Nothing AndAlso tempRet.Item1 IsNot Nothing AndAlso tempRet.Item1.ToString.Contains("sess_id") Then
                        'logger.Debug("Login page returned, sess_id string:{0}", tempRet.Item1.ToString)
                        finalURLToCall = tempRet.Item1
                        redirectedURI = tempRet.Item1

                        postContent = New Dictionary(Of String, String)
                        postContent.Add("user_id", Me.UserId)
                        postContent.Add("password", Me.Password)
                        'postContent.Add("login", "")

                        'Now prepare the step 1 authentication
                        headers = New Dictionary(Of String, String)
                        headers.Add("Accept", "application/json, text/plain, */*")
                        headers.Add("Accept-Language", "en-US")
                        'headers.Add("Accept-Encoding", "gzip, deflate, br")
                        headers.Add("Content-Type", "application/x-www-form-urlencoded")
                        headers.Add("Host", "kite.zerodha.com")
                        headers.Add("Origin", "https://kite.zerodha.com")
                        headers.Add("X-Kite-version", Me.APIVersion)

                        tempRet = Nothing
                        OnHeartbeat("Submitting Id/pass")
                        'logger.Debug("Submitting Id/pass, redirectedURI:{0}, postContent:{1}, headers:{2}", redirectedURI.ToString, Utils.JsonSerialize(postContent), Utils.JsonSerialize(headers))
                        _cts.Token.ThrowIfCancellationRequested()
                        tempRet = Await browser.POSTRequestAsync("https://kite.zerodha.com/api/login",
                                                                 redirectedURI.ToString,
                                                                 postContent,
                                                                 False,
                                                                 headers,
                                                                 False).ConfigureAwait(False)
                        _cts.Token.ThrowIfCancellationRequested()
                        'Should come back as redirected url in Item1 and htmldocument in Item2
                        Dim twoFAUserId As String = Nothing
                        Dim twoFARequestId As String = Nothing
                        Dim twoFAPIN As String = Nothing

                        If tempRet IsNot Nothing AndAlso tempRet.Item2 IsNot Nothing AndAlso tempRet.Item2.GetType Is GetType(Dictionary(Of String, Object)) AndAlso
                                tempRet.Item2.containskey("status") AndAlso tempRet.Item2("status") = "success" AndAlso
                                tempRet.Item2.containskey("data") AndAlso tempRet.Item2("data").containskey("user_id") AndAlso
                                tempRet.Item2("data").containskey("request_id") Then


                            'user_id=DK4056&request_id=Ypnc3WNKh1ulM8jP5QsmZmCUdSBI8EqT0aS9uhiHYrBNgodDla1y7VhTZE8z4Ia9&twofa_value=111111
                            twoFAUserId = tempRet.Item2("data")("user_id")
                            twoFARequestId = tempRet.Item2("data")("request_id")
                            twoFAPIN = Me.API2FAPin
                            If twoFAUserId IsNot Nothing AndAlso twoFARequestId IsNot Nothing Then
                                'logger.Debug("Id/pass submission returned, twoFAUserId:{0}, twoFARequestId:{1}", twoFAUserId, twoFARequestId)
                                'Now preprate the 2 step authentication
                                Dim stringPostContent As New Http.StringContent(String.Format("user_id={0}&request_id={1}&twofa_value={2}",
                                                                                      Uri.EscapeDataString(twoFAUserId),
                                                                                      Uri.EscapeDataString(twoFARequestId),
                                                                                      Uri.EscapeDataString(twoFAPIN)),
                                                                        Text.Encoding.UTF8, "application/x-www-form-urlencoded")

                                headers = New Dictionary(Of String, String)
                                headers.Add("Accept", "application/json, text/plain, */*")
                                headers.Add("Accept-Language", "en-US,en;q=0.5")
                                'headers.Add("Accept-Encoding", "gzip, deflate, br")
                                headers.Add("Content-Type", "application/x-www-form-urlencoded")
                                headers.Add("Host", "kite.zerodha.com")
                                headers.Add("Origin", "https://kite.zerodha.com")
                                headers.Add("X-Kite-version", Me.APIVersion)

                                tempRet = Nothing
                                OnHeartbeat("Submitting 2FA")
                                'logger.Debug("Submitting 2FA, redirectedURI:{0}, stringPostContent:{1}, headers:{2}", redirectedURI.ToString, Await stringPostContent.ReadAsStringAsync().ConfigureAwait(False), Utils.JsonSerialize(headers))
                                _cts.Token.ThrowIfCancellationRequested()
                                tempRet = Await browser.POSTRequestAsync("https://kite.zerodha.com/api/twofa",
                                                                 redirectedURI.ToString,
                                                                 stringPostContent,
                                                                 False,
                                                                 headers,
                                                                 False).ConfigureAwait(False)
                                _cts.Token.ThrowIfCancellationRequested()

                                'Should come back as redirect url in Item1 and htmldocument response in Item2
                                If tempRet IsNot Nothing AndAlso tempRet.Item1 IsNot Nothing AndAlso tempRet.Item1.ToString.Contains("request_token") Then
                                    redirectedURI = tempRet.Item1
                                    Dim queryStrings As NameValueCollection = HttpUtility.ParseQueryString(redirectedURI.Query)
                                    requestToken = queryStrings("request_token")
                                    'logger.Debug("2FA submission returned, requestToken:{0}", requestToken)
                                    'logger.Debug("Authentication complete, requestToken:{0}", requestToken)
                                ElseIf tempRet IsNot Nothing AndAlso tempRet.Item2 IsNot Nothing AndAlso tempRet.Item2.GetType Is GetType(Dictionary(Of String, Object)) AndAlso
                                        tempRet.Item2.containskey("status") AndAlso tempRet.Item2("status") = "success" Then
                                    'logger.Debug("2FA submission returned, redirection:true")

                                    headers = New Dictionary(Of String, String)
                                    headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8")
                                    headers.Add("Accept-Encoding", "gzip, deflate, br")
                                    headers.Add("Accept-Language", "en-US,en;q=0.5")
                                    headers.Add("Host", "kite.zerodha.com")
                                    headers.Add("X-Kite-version", Me.APIVersion)
                                    tempRet = Nothing

                                    OnHeartbeat("Addressing redirection")
                                    'logger.Debug("Redirecting, finalURLToCall:{0}, headers:{1}", finalURLToCall.ToString, Utils.JsonSerialize(headers))
                                    _cts.Token.ThrowIfCancellationRequested()
                                    tempRet = Await browser.NonPOSTRequestAsync(String.Format("{0}&skip_session=true", finalURLToCall.ToString),
                                                                        Http.HttpMethod.Get,
                                                                        finalURLToCall.ToString,
                                                                        False,
                                                                        headers,
                                                                        True,
                                                                        Nothing).ConfigureAwait(False)
                                    _cts.Token.ThrowIfCancellationRequested()
                                    If tempRet IsNot Nothing AndAlso tempRet.Item1 IsNot Nothing AndAlso tempRet.Item1.ToString.Contains("request_token") Then
                                        redirectedURI = tempRet.Item1
                                        Dim queryStrings As NameValueCollection = HttpUtility.ParseQueryString(redirectedURI.Query)
                                        requestToken = queryStrings("request_token")

                                        For Each cookie As Cookie In HttpBrowser.AllCookies.GetCookies(New Uri("http://kite.zerodha.com"))
                                            Console.WriteLine("Name = {0} ; Value = {1} ; Domain = {2}", cookie.Name, cookie.Value,
                                                      cookie.Domain)
                                            If cookie.Name = "enctoken" Then
                                                Me.ENCToken = cookie.Value
                                            End If
                                        Next
                                        'logger.Debug("Redirection returned, requestToken:{0}", requestToken)
                                        'logger.Debug("Authentication complete, requestToken:{0}", requestToken)
                                    Else
                                        If tempRet IsNot Nothing AndAlso tempRet.Item2 IsNot Nothing AndAlso tempRet.Item2.GetType Is GetType(Dictionary(Of String, Object)) Then
                                            Throw New AuthenticationException(GetErrorResponse(tempRet.Item2),
                                                                   AuthenticationException.TypeOfException.SecondLevelFailure)
                                        Else
                                            Throw New AuthenticationException("Step 2 authentication did not produce any request_token after redirection",
                                                                   AuthenticationException.TypeOfException.SecondLevelFailure)
                                        End If
                                    End If
                                Else
                                    If tempRet IsNot Nothing AndAlso tempRet.Item2 IsNot Nothing AndAlso tempRet.Item2.GetType Is GetType(Dictionary(Of String, Object)) Then
                                        Throw New AuthenticationException(GetErrorResponse(tempRet.Item2),
                                                                   AuthenticationException.TypeOfException.SecondLevelFailure)
                                    Else
                                        Throw New AuthenticationException("Step 2 authentication did not produce any request_token",
                                                                   AuthenticationException.TypeOfException.SecondLevelFailure)
                                    End If
                                End If
                            Else
                                If tempRet IsNot Nothing AndAlso tempRet.Item2 IsNot Nothing AndAlso tempRet.Item2.GetType Is GetType(Dictionary(Of String, Object)) Then
                                    Throw New AuthenticationException(GetErrorResponse(tempRet.Item2),
                                                                   AuthenticationException.TypeOfException.SecondLevelFailure)
                                Else
                                    Throw New AuthenticationException("Step 2 authentication did not produce first or second questions",
                                                                   AuthenticationException.TypeOfException.SecondLevelFailure)
                                End If
                            End If
                        Else
                            If tempRet IsNot Nothing AndAlso tempRet.Item2 IsNot Nothing AndAlso tempRet.Item2.GetType Is GetType(Dictionary(Of String, Object)) Then
                                Throw New AuthenticationException(GetErrorResponse(tempRet.Item2),
                                                                   AuthenticationException.TypeOfException.FirstLevelFailure)
                            Else
                                Throw New AuthenticationException("Step 1 authentication did not produce any questions in the response", AuthenticationException.TypeOfException.FirstLevelFailure)
                            End If
                        End If
                    Else
                        If tempRet IsNot Nothing AndAlso tempRet.Item2 IsNot Nothing AndAlso tempRet.Item2.GetType Is GetType(Dictionary(Of String, Object)) Then
                            Throw New AuthenticationException(GetErrorResponse(tempRet.Item2),
                                                                   AuthenticationException.TypeOfException.FirstLevelFailure)
                        Else
                            Throw New AuthenticationException("Step 1 authentication prepration to get to the login page failed",
                                                                   AuthenticationException.TypeOfException.FirstLevelFailure)
                        End If
                    End If
                    RemoveHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    RemoveHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                    RemoveHandler browser.Heartbeat, AddressOf OnHeartbeat
                    RemoveHandler browser.WaitingFor, AddressOf OnWaitingFor
                End Using
                If requestToken IsNot Nothing AndAlso Me.ENCToken IsNot Nothing Then
                    _cts.Token.ThrowIfCancellationRequested()
                    ret = True
                    'ret = Await RequestAccessTokenAsync(requestToken).ConfigureAwait(False)
                    _cts.Token.ThrowIfCancellationRequested()

                    _cts.Token.ThrowIfCancellationRequested()
                End If
            Catch ex As TokenException
                OnHeartbeat("Possible error while generating session, token may be invalid, retrying the whole login process")
                Continue While
            End Try
            _cts.Token.ThrowIfCancellationRequested()
            Exit While
        End While
        Return ret
    End Function

    Private Async Function RequestAccessTokenAsync(ByVal requestToken As String) As Task(Of Boolean)
        Dim ret As Boolean = False
        'logger.Debug("RequestAccessTokenAsync, requestToken:{0}", requestToken)
        Await Task.Delay(0, _cts.Token).ConfigureAwait(False)
        Dim kiteConnector As New Kite(Me.APIKey, Debug:=True)

        Dim lastException As Exception = Nothing
        Dim allOKWithoutException As Boolean = False

        Using Waiter As New Waiter(_cts)
            AddHandler Waiter.Heartbeat, AddressOf OnHeartbeat
            AddHandler Waiter.WaitingFor, AddressOf OnWaitingFor

            For retryCtr = 1 To _MaxReTries
                _cts.Token.ThrowIfCancellationRequested()
                lastException = Nothing
                OnHeartbeat("Generating session...")
                'logger.Debug("Generating session, command:{0}, requestToken:{1}, _currentUser.APISecret:{2}",
                '                                    "GenerateSession", requestToken, _currentUser.APISecret)
                OnDocumentRetryStatus(retryCtr, _MaxReTries)
                Try
                    _cts.Token.ThrowIfCancellationRequested()
                    Dim user As User = kiteConnector.GenerateSession(requestToken, Me.APISecret)
                    _cts.Token.ThrowIfCancellationRequested()
                    Console.WriteLine(Utils.JsonSerialize(user))
                    'logger.Debug("Processing response")

                    If user.AccessToken IsNot Nothing Then
                        kiteConnector.SetAccessToken(user.AccessToken)
                        'logger.Debug("Session generated, user.AccessToken:{0}", user.AccessToken)

                        Me.RequestToken = requestToken
                        Me.AccessToken = user.AccessToken
                        Me.PublicToken = user.PublicToken
                        ret = True

                        lastException = Nothing
                        allOKWithoutException = True
                        Exit For
                    Else
                        Throw New ApplicationException(String.Format("Generating session did not succeed, command:{0}", "GenerateSession"))
                    End If
                    _cts.Token.ThrowIfCancellationRequested()
                Catch tex As TokenException
                    'logger.Error(tex)
                    lastException = tex
                    Exit For
                Catch opx As OperationCanceledException
                    'logger.Error(opx)
                    lastException = opx
                    If Not _cts.Token.IsCancellationRequested Then
                        _cts.Token.ThrowIfCancellationRequested()
                        If Not Waiter.WaitOnInternetFailure(_WaitDurationOnConnectionFailure) Then
                            'Provide required wait in case internet was already up
                            'logger.Debug("HTTP->Task was cancelled without internet problem:{0}",
                            '                 opx.Message)
                            _cts.Token.ThrowIfCancellationRequested()
                            Waiter.SleepRequiredDuration(_WaitDurationOnAnyFailure.TotalSeconds, "Non-explicit cancellation")
                            _cts.Token.ThrowIfCancellationRequested()
                        Else
                            'logger.Debug("HTTP->Task was cancelled due to internet problem:{0}, waited prescribed seconds, will now retry",
                            '                 opx.Message)
                            'Since internet was down, no need to consume retries
                            retryCtr -= 1
                        End If
                    End If
                Catch hex As HttpRequestException
                    'logger.Error(hex)
                    lastException = hex
                    If ExceptionExtensions.GetExceptionMessages(hex).Contains("trust relationship") Then
                        Throw New ForbiddenException(hex.Message, hex, ForbiddenException.TypeOfException.PossibleReloginRequired)
                    End If
                    _cts.Token.ThrowIfCancellationRequested()
                    If Not Waiter.WaitOnInternetFailure(_WaitDurationOnConnectionFailure) Then
                        If hex.Message.Contains("429") Or hex.Message.Contains("503") Then
                            'logger.Debug("HTTP->429/503 error without internet problem:{0}",
                            '                 hex.Message)
                            _cts.Token.ThrowIfCancellationRequested()
                            Waiter.SleepRequiredDuration(_WaitDurationOnServiceUnavailbleFailure.TotalSeconds, "Service unavailable(429/503)")
                            _cts.Token.ThrowIfCancellationRequested()
                            'Since site service is blocked, no need to consume retries
                            retryCtr -= 1
                        ElseIf hex.Message.Contains("404") Then
                            'logger.Debug("HTTP->404 error without internet problem:{0}",
                            '                 hex.Message)
                            _cts.Token.ThrowIfCancellationRequested()
                            'No point retrying, exit for
                            Exit For
                        Else
                            If ExceptionExtensions.IsExceptionConnectionRelated(hex) Then
                                'logger.Debug("HTTP->HttpRequestException without internet problem but of type internet related detected:{0}",
                                '                 hex.Message)
                                _cts.Token.ThrowIfCancellationRequested()
                                Waiter.SleepRequiredDuration(_WaitDurationOnConnectionFailure.TotalSeconds, "Connection HttpRequestException")
                                _cts.Token.ThrowIfCancellationRequested()
                                'Since exception was internet related, no need to consume retries
                                retryCtr -= 1
                            Else
                                'Provide required wait in case internet was already up
                                'logger.Debug("HTTP->HttpRequestException without internet problem:{0}",
                                '                 hex.Message)
                                _cts.Token.ThrowIfCancellationRequested()
                                Waiter.SleepRequiredDuration(_WaitDurationOnAnyFailure.TotalSeconds, "Unknown HttpRequestException:" & hex.Message)
                                _cts.Token.ThrowIfCancellationRequested()
                            End If
                        End If
                    Else
                        'logger.Debug("HTTP->HttpRequestException with internet problem:{0}, waited prescribed seconds, will now retry",
                        '                 hex.Message)
                        'Since internet was down, no need to consume retries
                        retryCtr -= 1
                    End If
                Catch ex As Exception
                    'logger.Error(ex)
                    lastException = ex
                    'Exit if it is a network failure check and stop retry to avoid stack overflow
                    'Need to relogin, no point retrying
                    If ExceptionExtensions.GetExceptionMessages(ex).Contains("disposed") Then
                        Throw New ForbiddenException(ex.Message, ex, ForbiddenException.TypeOfException.ExceptionInBetweenLoginProcess)
                    End If
                    _cts.Token.ThrowIfCancellationRequested()
                    If Not Waiter.WaitOnInternetFailure(_WaitDurationOnConnectionFailure) Then
                        'Provide required wait in case internet was already up
                        _cts.Token.ThrowIfCancellationRequested()
                        If ExceptionExtensions.IsExceptionConnectionRelated(ex) Then
                            'logger.Debug("HTTP->Exception without internet problem but of type internet related detected:{0}",
                            '                 ex.Message)
                            _cts.Token.ThrowIfCancellationRequested()
                            Waiter.SleepRequiredDuration(_WaitDurationOnConnectionFailure.TotalSeconds, "Connection Exception")
                            _cts.Token.ThrowIfCancellationRequested()
                            'Since exception was internet related, no need to consume retries
                            retryCtr -= 1
                        Else
                            'logger.Debug("HTTP->Exception without internet problem of unknown type detected:{0}",
                            '                 ex.Message)
                            _cts.Token.ThrowIfCancellationRequested()
                            Waiter.SleepRequiredDuration(_WaitDurationOnAnyFailure.TotalSeconds, "Unknown Exception")
                            _cts.Token.ThrowIfCancellationRequested()
                        End If
                    Else
                        'logger.Debug("HTTP->Exception with internet problem:{0}, waited prescribed seconds, will now retry",
                        '                 ex.Message)
                        'Since internet was down, no need to consume retries
                        retryCtr -= 1
                    End If
                Finally
                    OnDocumentDownloadComplete()
                End Try

                If ret Then Exit For
                _cts.Token.ThrowIfCancellationRequested()
                GC.Collect()
            Next
            RemoveHandler Waiter.Heartbeat, AddressOf OnHeartbeat
            RemoveHandler Waiter.WaitingFor, AddressOf OnWaitingFor
        End Using
        _cts.Token.ThrowIfCancellationRequested()
        If Not allOKWithoutException Then Throw lastException
        Return ret
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
