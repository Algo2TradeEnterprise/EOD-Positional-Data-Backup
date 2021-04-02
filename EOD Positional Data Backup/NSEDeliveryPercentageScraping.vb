Imports System.Threading
Imports Utilities.Network
Imports HtmlAgilityPack
Imports System.Net.Http
Imports Utilities.Strings

Public Class NSEDeliveryPercentageScraping
    Implements IDisposable

#Region "Event Handlers"
    Public Event DocumentDownloadComplete()
    Public Event DocumentRetryStatus(ByVal currentTry As Integer, ByVal totalTries As Integer)
    Public Event Heartbeat(ByVal msg As String)
    Public Event WaitingFor(ByVal elapsedSecs As Integer, ByVal totalSecs As Integer, ByVal msg As String)

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

    Private ReadOnly _cts As CancellationTokenSource

    Public Sub New(ByVal canceller As CancellationTokenSource)
        _cts = canceller
    End Sub

    Public Async Function GetDeliveryPercentageDataAsync(ByVal instrumentName As String) As Task(Of Dictionary(Of Date, Decimal))
        Dim ret As Dictionary(Of Date, Decimal) = Nothing
        If instrumentName.Trim.ToUpper IsNot Nothing Then
            Dim symbolCount As Integer = Await GetSymbolCountAsync(instrumentName).ConfigureAwait(False)
            If symbolCount <> Integer.MinValue Then
                Dim baseURL As String = "https://www1.nseindia.com/products/dynaContent/common/productsSymbolMapping.jsp?symbol={0}&segmentLink=3&symbolCount={1}&series=EQ&dateRange=24month&fromDate=&toDate=&dataType=PRICEVOLUMEDELIVERABLE"
                Dim mainURL As String = String.Format(baseURL, instrumentName.Trim.ToUpper, symbolCount)

                Dim outputResponse As HtmlDocument = Nothing
                Dim proxyToBeUsed As HttpProxy = Nothing
                Using browser As New HttpBrowser(proxyToBeUsed, Net.DecompressionMethods.GZip Or Net.DecompressionMethods.Deflate Or Net.DecompressionMethods.None, New TimeSpan(0, 1, 0), _cts)
                    AddHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    AddHandler browser.Heartbeat, AddressOf OnHeartbeat
                    AddHandler browser.WaitingFor, AddressOf OnWaitingFor
                    AddHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus

                    browser.KeepAlive = True

                    Dim headersToBeSent As New Dictionary(Of String, String)
                    headersToBeSent.Add("Accept", "*/*")
                    headersToBeSent.Add("Accept-Encoding", "gzip, deflate, br")
                    headersToBeSent.Add("Accept-Language", "en-US,en;q=0.9")
                    headersToBeSent.Add("Host", "www1.nseindia.com")
                    headersToBeSent.Add("Referer", "https://www1.nseindia.com/products/content/equities/equities/eq_security.htm")

                    Dim l As Tuple(Of Uri, Object) = Await browser.NonPOSTRequestAsync(mainURL, HttpMethod.Get, Nothing, False, headersToBeSent, True, "text/html").ConfigureAwait(False)
                    If l IsNot Nothing AndAlso l.Item2 IsNot Nothing Then
                        outputResponse = l.Item2
                    End If
                    RemoveHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    RemoveHandler browser.Heartbeat, AddressOf OnHeartbeat
                    RemoveHandler browser.WaitingFor, AddressOf OnWaitingFor
                    RemoveHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                End Using
                If outputResponse IsNot Nothing Then
                    Dim csvTableNode As HtmlNode = outputResponse.DocumentNode.SelectSingleNode("//div[@id= 'csvContentDiv']")
                    If csvTableNode IsNot Nothing Then
                        Dim allRows() As String = csvTableNode.InnerText.Trim.Split(":")
                        If allRows IsNot Nothing AndAlso allRows.Count > 0 Then
                            For Each runningRow In allRows
                                If runningRow.Trim <> "" AndAlso runningRow.Trim.Contains(",") Then
                                    Dim allColumns() As String = runningRow.Split(",")
                                    If allColumns IsNot Nothing AndAlso allColumns.Count >= 15 Then
                                        Dim runningDate As Date = Date.MinValue
                                        If Date.TryParseExact(RemoveBeginningAndEndingQuotes(allColumns(2)).Trim, "dd-MMM-yyyy", Nothing, Globalization.DateTimeStyles.None, runningDate) Then
                                            Dim deliveryPercentage As String = allColumns(14)
                                            If deliveryPercentage IsNot Nothing AndAlso
                                                deliveryPercentage.Trim <> "" AndAlso
                                                IsNumeric(RemoveBeginningAndEndingQuotes(deliveryPercentage).Trim) Then
                                                If ret Is Nothing Then ret = New Dictionary(Of Date, Decimal)
                                                ret.Add(runningDate, Val(RemoveBeginningAndEndingQuotes(deliveryPercentage).Trim))
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            End If
        End If
        Return ret
    End Function

    Private Async Function GetSymbolCountAsync(ByVal instrumentName As String) As Task(Of Integer)
        Dim ret As Integer = Integer.MinValue
        If instrumentName.Trim.ToUpper IsNot Nothing Then
            Dim baseURL As String = "https://www1.nseindia.com/marketinfo/sym_map/symbolCount.jsp?symbol={0}"
            Dim mainURL As String = String.Format(baseURL, instrumentName.Trim.ToUpper)

            Dim outputResponse As HtmlDocument = Nothing
            Dim proxyToBeUsed As HttpProxy = Nothing
            Using browser As New HttpBrowser(proxyToBeUsed, Net.DecompressionMethods.GZip Or Net.DecompressionMethods.Deflate Or Net.DecompressionMethods.None, New TimeSpan(0, 1, 0), _cts)
                AddHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                AddHandler browser.Heartbeat, AddressOf OnHeartbeat
                AddHandler browser.WaitingFor, AddressOf OnWaitingFor
                AddHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus

                browser.KeepAlive = True

                Dim headersToBeSent As New Dictionary(Of String, String)
                headersToBeSent.Add("Accept", "*/*")
                headersToBeSent.Add("Accept-Encoding", "gzip, deflate, br")
                headersToBeSent.Add("Accept-Language", "en-US,en;q=0.9")
                headersToBeSent.Add("Host", "www1.nseindia.com")
                headersToBeSent.Add("Referer", "https://www1.nseindia.com/products/content/equities/equities/eq_security.htm")

                Dim l As Tuple(Of Uri, Object) = Await browser.NonPOSTRequestAsync(mainURL, HttpMethod.Get, Nothing, False, headersToBeSent, True, "text/html").ConfigureAwait(False)
                If l IsNot Nothing AndAlso l.Item2 IsNot Nothing Then
                    outputResponse = l.Item2
                End If
                RemoveHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                RemoveHandler browser.Heartbeat, AddressOf OnHeartbeat
                RemoveHandler browser.WaitingFor, AddressOf OnWaitingFor
                RemoveHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
            End Using
            If outputResponse IsNot Nothing Then
                If IsNumeric(outputResponse.ParsedText.Trim) Then
                    ret = Val(outputResponse.ParsedText.Trim)
                End If
            End If
        End If
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
