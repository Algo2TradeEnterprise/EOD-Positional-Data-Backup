Imports System.Net.Mail
Imports System.Threading
Imports NLog
Imports Utilities.ErrorHandlers

Namespace Notification
    Public Class Gmail
        Implements IDisposable

#Region "Logging and Status Progress"
        Public Shared logger As Logger = LogManager.GetCurrentClassLogger
#End Region

#Region "Events"
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

        Private ReadOnly _mailFrom As String
        Private ReadOnly _password As String
        Private ReadOnly _mailTo As List(Of String)

        Protected _canceller As CancellationTokenSource

        Public Sub New(ByVal canceller As CancellationTokenSource, ByVal mailForm As String, ByVal password As String, ParamArray ByVal mailTo() As String)
            _canceller = canceller
            _mailFrom = mailForm
            _password = password
            If mailTo.Count > 0 Then
                For i As Integer = 0 To mailTo.Count - 1
                    If _mailTo Is Nothing Then _mailTo = New List(Of String)
                    _mailTo.Add(mailTo(i))
                Next
            End If
        End Sub

        Public Async Function SendMailAsync(ByVal title As String, ByVal content As String) As Task
            Dim errorOcurred As Boolean = False
            While True
                Try
                    OnHeartbeat("Sending mail...")
                    Dim SmtpServer As New SmtpClient("smtp.gmail.com", 587)
                    Dim mail As New MailMessage
                    mail.From = New MailAddress(_mailFrom)
                    If _mailTo IsNot Nothing AndAlso _mailTo.Count > 0 Then
                        For Each runningMailAddress In _mailTo
                            mail.To.Add(runningMailAddress)
                        Next
                    End If
                    mail.Subject = title
                    mail.Body = content

                    SmtpServer.Credentials = New System.Net.NetworkCredential(_mailFrom, _password)
                    SmtpServer.EnableSsl = True

                    SmtpServer.Send(mail)
                    Exit While
                Catch ex As Exception
                    errorOcurred = True
                    If ExceptionExtensions.IsExceptionConnectionRelated(ex) Or ExceptionExtensions.IsExceptionConnectionBusyRelated(ex) Then
                        If Not _canceller.IsCancellationRequested Then
                            OnHeartbeat("Waiting after connection/internet error")
                        Else
                            _canceller.Token.ThrowIfCancellationRequested()
                        End If
                    Else
                        If Not _canceller.IsCancellationRequested Then
                            OnHeartbeat("Waiting after other error")
                        Else
                            _canceller.Token.ThrowIfCancellationRequested()
                        End If
                    End If
                End Try
                If errorOcurred Then
                    Await Task.Delay(5 * 1000)
                End If
            End While
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
End Namespace