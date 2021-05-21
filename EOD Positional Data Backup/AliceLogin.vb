Imports System.Net
Imports System.Threading
Imports Utilities.Network
Imports Utilities
Imports System.Net.Http

Public Class AliceLogin
    Inherits Login

    Public ReadOnly Property UserId As String
    Public ReadOnly Property Password As String
    Public ReadOnly Property API2FA As String

    Private ReadOnly _MaxReTries As Integer = 20
    Private ReadOnly _WaitDurationOnConnectionFailure As TimeSpan = TimeSpan.FromSeconds(5)
    Private ReadOnly _WaitDurationOnServiceUnavailbleFailure As TimeSpan = TimeSpan.FromSeconds(30)
    Private ReadOnly _WaitDurationOnAnyFailure As TimeSpan = TimeSpan.FromSeconds(10)

    Private ReadOnly _cts As CancellationTokenSource
    Public Sub New(ByVal userId As String,
                   ByVal password As String,
                   ByVal _2FA As String,
                   ByVal canceller As CancellationTokenSource)
        Me.UserId = userId
        Me.Password = password
        Me.API2FA = _2FA
        _cts = canceller
    End Sub

    Public Overrides Async Function LoginAsync() As Task(Of Boolean)
        Dim ret As Boolean = False
        While True
            _cts.Token.ThrowIfCancellationRequested()
            Try
                ServicePointManager.Expect100Continue = False
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                ServicePointManager.ServerCertificateValidationCallback = Function(s, Ca, CaC, sslPE)
                                                                              Return True
                                                                          End Function

                Dim proxyToBeUsed As HttpProxy = Nothing
                Using browser As New HttpBrowser(proxyToBeUsed, DecompressionMethods.GZip Or DecompressionMethods.Deflate Or DecompressionMethods.None, New TimeSpan(0, 1, 0), _cts)
                    AddHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    AddHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                    AddHandler browser.Heartbeat, AddressOf OnHeartbeat
                    AddHandler browser.WaitingFor, AddressOf OnWaitingFor

                    OnHeartbeat("Opening Web login page")
                    Dim url1 As String = "https://ant.aliceblueonline.com/api/v2/login"

                    Dim headers As Dictionary(Of String, String) = New Dictionary(Of String, String)
                    headers.Add("a2tContent", "application/json")

                    Dim postJson As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                    postJson.Add("login_id", Me.UserId)
                    postJson.Add("password", Me.Password)
                    postJson.Add("device", "web")

                    Dim postContent As StringContent = New StringContent(Strings.JsonSerialize(postJson), System.Text.Encoding.UTF8, "application/json")

                    _cts.Token.ThrowIfCancellationRequested()
                    Dim tempRet As Tuple(Of Uri, Object) = Await browser.POSTRequestAsync(url1, Nothing, postContent, False, headers, False).ConfigureAwait(False)
                    If tempRet IsNot Nothing AndAlso tempRet.Item1 IsNot Nothing AndAlso tempRet.Item2 IsNot Nothing Then
                        Dim jsonDict As Dictionary(Of String, Object) = TryCast(tempRet.Item2, Dictionary(Of String, Object))
                        If jsonDict IsNot Nothing AndAlso jsonDict.ContainsKey("status") AndAlso jsonDict("status") = "success" AndAlso jsonDict.ContainsKey("data") Then
                            Dim dataDict As Dictionary(Of String, Object) = TryCast(jsonDict("data"), Dictionary(Of String, Object))
                            If dataDict IsNot Nothing AndAlso dataDict.ContainsKey("question_ids") Then
                                Dim questionIds As ArrayList = dataDict("question_ids")
                                If questionIds IsNot Nothing AndAlso questionIds.Count = 2 Then
                                    Dim answers() As String = {Me.API2FA, Me.API2FA}
                                    Dim url2 As String = "https://ant.aliceblueonline.com/api/v2/checktwofa"

                                    headers = New Dictionary(Of String, String)
                                    headers.Add("a2tContent", "application/json")

                                    postJson = New Dictionary(Of String, Object)
                                    postJson.Add("login_id", Me.UserId)
                                    postJson.Add("device", "web")
                                    postJson.Add("count", "2")
                                    postJson.Add("question_ids", questionIds)
                                    postJson.Add("answers", answers)
                                    postContent = New StringContent(Utilities.Strings.JsonSerialize(postJson), System.Text.Encoding.UTF8, "application/json")

                                    tempRet = Await browser.POSTRequestAsync(url2, Nothing, postContent, False, headers, False).ConfigureAwait(False)
                                    If tempRet IsNot Nothing AndAlso tempRet.Item1 IsNot Nothing AndAlso tempRet.Item2 IsNot Nothing Then
                                        jsonDict = TryCast(tempRet.Item2, Dictionary(Of String, Object))
                                        If jsonDict IsNot Nothing AndAlso jsonDict.ContainsKey("status") AndAlso jsonDict("status") = "success" AndAlso jsonDict.ContainsKey("data") Then
                                            dataDict = TryCast(jsonDict("data"), Dictionary(Of String, Object))
                                            If dataDict IsNot Nothing AndAlso dataDict.ContainsKey("auth_token") Then
                                                Me.ENCToken = dataDict("auth_token")
                                                ret = True
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End Using
            Catch ex As Exception
                OnHeartbeat("Possible error while generating session, token may be invalid, retrying the whole login process")
                Continue While
            End Try
            _cts.Token.ThrowIfCancellationRequested()
            Exit While
        End While
        Return ret
    End Function
End Class