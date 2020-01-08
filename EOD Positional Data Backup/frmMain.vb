Imports Utilities.DAL
Imports System.Threading
Imports Utilities.Network
Imports System.Net.Http
Imports System.Net

Public Class frmMain

#Region "Common Delegates"
    Delegate Sub SetObjectEnableDisable_Delegate(ByVal [obj] As Object, ByVal [value] As Boolean)
    Public Sub SetObjectEnableDisable_ThreadSafe(ByVal [obj] As Object, ByVal [value] As Boolean)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [obj].InvokeRequired Then
            Dim MyDelegate As New SetObjectEnableDisable_Delegate(AddressOf SetObjectEnableDisable_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[obj], [value]})
        Else
            [obj].Enabled = [value]
        End If
    End Sub

    Delegate Sub SetObjectVisible_Delegate(ByVal [obj] As Object, ByVal [value] As Boolean)
    Public Sub SetObjectVisible_ThreadSafe(ByVal [obj] As Object, ByVal [value] As Boolean)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [obj].InvokeRequired Then
            Dim MyDelegate As New SetObjectVisible_Delegate(AddressOf SetObjectVisible_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[obj], [value]})
        Else
            [obj].Visible = [value]
        End If
    End Sub

    Delegate Sub SetLabelText_Delegate(ByVal [label] As Label, ByVal [text] As String)
    Public Sub SetLabelText_ThreadSafe(ByVal [label] As Label, ByVal [text] As String)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [label].InvokeRequired Then
            Dim MyDelegate As New SetLabelText_Delegate(AddressOf SetLabelText_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[label], [text]})
        Else
            [label].Text = [text]
        End If
    End Sub

    Delegate Function GetLabelText_Delegate(ByVal [label] As Label) As String
    Public Function GetLabelText_ThreadSafe(ByVal [label] As Label) As String
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [label].InvokeRequired Then
            Dim MyDelegate As New GetLabelText_Delegate(AddressOf GetLabelText_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[label]})
        Else
            Return [label].Text
        End If
    End Function

    Delegate Sub SetLabelTag_Delegate(ByVal [label] As Label, ByVal [tag] As String)
    Public Sub SetLabelTag_ThreadSafe(ByVal [label] As Label, ByVal [tag] As String)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [label].InvokeRequired Then
            Dim MyDelegate As New SetLabelTag_Delegate(AddressOf SetLabelTag_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[label], [tag]})
        Else
            [label].Tag = [tag]
        End If
    End Sub

    Delegate Function GetLabelTag_Delegate(ByVal [label] As Label) As String
    Public Function GetLabelTag_ThreadSafe(ByVal [label] As Label) As String
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [label].InvokeRequired Then
            Dim MyDelegate As New GetLabelTag_Delegate(AddressOf GetLabelTag_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[label]})
        Else
            Return [label].Tag
        End If
    End Function
    Delegate Sub SetToolStripLabel_Delegate(ByVal [toolStrip] As StatusStrip, ByVal [label] As ToolStripStatusLabel, ByVal [text] As String)
    Public Sub SetToolStripLabel_ThreadSafe(ByVal [toolStrip] As StatusStrip, ByVal [label] As ToolStripStatusLabel, ByVal [text] As String)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [toolStrip].InvokeRequired Then
            Dim MyDelegate As New SetToolStripLabel_Delegate(AddressOf SetToolStripLabel_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[toolStrip], [label], [text]})
        Else
            [label].Text = [text]
        End If
    End Sub

    Delegate Function GetToolStripLabel_Delegate(ByVal [toolStrip] As StatusStrip, ByVal [label] As ToolStripLabel) As String
    Public Function GetToolStripLabel_ThreadSafe(ByVal [toolStrip] As StatusStrip, ByVal [label] As ToolStripLabel) As String
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [toolStrip].InvokeRequired Then
            Dim MyDelegate As New GetToolStripLabel_Delegate(AddressOf GetToolStripLabel_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[toolStrip], [label]})
        Else
            Return [label].Text
        End If
    End Function

    Delegate Function GetDateTimePickerValue_Delegate(ByVal [dateTimePicker] As DateTimePicker) As Date
    Public Function GetDateTimePickerValue_ThreadSafe(ByVal [dateTimePicker] As DateTimePicker) As Date
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [dateTimePicker].InvokeRequired Then
            Dim MyDelegate As New GetDateTimePickerValue_Delegate(AddressOf GetDateTimePickerValue_ThreadSafe)
            Return Me.Invoke(MyDelegate, New DateTimePicker() {[dateTimePicker]})
        Else
            Return [dateTimePicker].Value
        End If
    End Function

    Delegate Function GetNumericUpDownValue_Delegate(ByVal [numericUpDown] As NumericUpDown) As Integer
    Public Function GetNumericUpDownValue_ThreadSafe(ByVal [numericUpDown] As NumericUpDown) As Integer
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [numericUpDown].InvokeRequired Then
            Dim MyDelegate As New GetNumericUpDownValue_Delegate(AddressOf GetNumericUpDownValue_ThreadSafe)
            Return Me.Invoke(MyDelegate, New NumericUpDown() {[numericUpDown]})
        Else
            Return [numericUpDown].Value
        End If
    End Function

    Delegate Function GetComboBoxIndex_Delegate(ByVal [combobox] As ComboBox) As Integer
    Public Function GetComboBoxIndex_ThreadSafe(ByVal [combobox] As ComboBox) As Integer
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [combobox].InvokeRequired Then
            Dim MyDelegate As New GetComboBoxIndex_Delegate(AddressOf GetComboBoxIndex_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[combobox]})
        Else
            Return [combobox].SelectedIndex
        End If
    End Function

    Delegate Function GetComboBoxItem_Delegate(ByVal [ComboBox] As ComboBox) As String
    Public Function GetComboBoxItem_ThreadSafe(ByVal [ComboBox] As ComboBox) As String
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [ComboBox].InvokeRequired Then
            Dim MyDelegate As New GetComboBoxItem_Delegate(AddressOf GetComboBoxItem_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[ComboBox]})
        Else
            Return [ComboBox].SelectedItem.ToString
        End If
    End Function

    Delegate Function GetTextBoxText_Delegate(ByVal [textBox] As TextBox) As String
    Public Function GetTextBoxText_ThreadSafe(ByVal [textBox] As TextBox) As String
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [textBox].InvokeRequired Then
            Dim MyDelegate As New GetTextBoxText_Delegate(AddressOf GetTextBoxText_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[textBox]})
        Else
            Return [textBox].Text
        End If
    End Function

    Delegate Function GetCheckBoxChecked_Delegate(ByVal [checkBox] As CheckBox) As Boolean
    Public Function GetCheckBoxChecked_ThreadSafe(ByVal [checkBox] As CheckBox) As Boolean
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [checkBox].InvokeRequired Then
            Dim MyDelegate As New GetCheckBoxChecked_Delegate(AddressOf GetCheckBoxChecked_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[checkBox]})
        Else
            Return [checkBox].Checked
        End If
    End Function

    Delegate Function GetRadioButtonChecked_Delegate(ByVal [radioButton] As RadioButton) As Boolean
    Public Function GetRadioButtonChecked_ThreadSafe(ByVal [radioButton] As RadioButton) As Boolean
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [radioButton].InvokeRequired Then
            Dim MyDelegate As New GetRadioButtonChecked_Delegate(AddressOf GetRadioButtonChecked_ThreadSafe)
            Return Me.Invoke(MyDelegate, New Object() {[radioButton]})
        Else
            Return [radioButton].Checked
        End If
    End Function

    Delegate Sub SetDatagridBindDatatable_Delegate(ByVal [datagrid] As DataGridView, ByVal [table] As DataTable)
    Public Sub SetDatagridBindDatatable_ThreadSafe(ByVal [datagrid] As DataGridView, ByVal [table] As DataTable)
        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.  
        ' If these threads are different, it returns true.  
        If [datagrid].InvokeRequired Then
            Dim MyDelegate As New SetDatagridBindDatatable_Delegate(AddressOf SetDatagridBindDatatable_ThreadSafe)
            Me.Invoke(MyDelegate, New Object() {[datagrid], [table]})
        Else
            [datagrid].DataSource = [table]
            [datagrid].Refresh()
        End If
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub OnHeartbeat(message As String)
        SetLabelText_ThreadSafe(lblProgress, message)
    End Sub
    Private Sub OnDocumentDownloadComplete()
        'OnHeartbeat("Document download compelete")
    End Sub
    Private Sub OnDocumentRetryStatus(currentTry As Integer, totalTries As Integer)
        OnHeartbeat(String.Format("Try #{0}/{1}: Connecting...", currentTry, totalTries))
    End Sub
    Public Sub OnWaitingFor(ByVal elapsedSecs As Integer, ByVal totalSecs As Integer, ByVal msg As String)
        OnHeartbeat(String.Format("{0}, waiting {1}/{2} secs", msg, elapsedSecs, totalSecs))
    End Sub
    Private Sub OnFirstErrorGettingData(ByVal increaseDecrease As Integer)
        If increaseDecrease > 0 Then Interlocked.Increment(errorGettingData)
        If increaseDecrease < 0 Then Interlocked.Decrement(errorGettingData)
        UpdateLabels()
    End Sub
    Private Sub OnFirstErrorWritingData(ByVal increaseDecrease As Integer)
        If increaseDecrease > 0 Then Interlocked.Increment(errorWritingData)
        If increaseDecrease < 0 Then Interlocked.Decrement(errorWritingData)
        UpdateLabels()
    End Sub
#End Region

    Enum DataType
        EOD = 1
        Intraday
    End Enum

    Private UpdateIntrumentType As InstrumentDetails.TypeOfInstrument
    Private UpdateDataType As DataType
    Private total As Integer = 0
    Private queued As Integer = 0
    Private gettingData As Integer = 0
    Private errorGettingData As Integer = 0
    Private writingData As Integer = 0
    Private errorWritingData As Integer = 0
    Private completed As Integer = 0

    Private canceller As CancellationTokenSource

    Private Sub UpdateLabels()
        Dim totalLabel As Label = Nothing
        Dim queuedLabel As Label = Nothing
        Dim gettingDataLabel As Label = Nothing
        Dim errorGettingDataLabel As Label = Nothing
        Dim writingDataLabel As Label = Nothing
        Dim errorWritingDataLabel As Label = Nothing
        Dim completedLabel As Label = Nothing

#Region "Label Selection"
        Select Case UpdateIntrumentType
            Case InstrumentDetails.TypeOfInstrument.Positional
                totalLabel = lblPstnlTotal
                queuedLabel = lblPstnlQueue
                gettingDataLabel = lblPstnlGettingData
                errorGettingDataLabel = lblPstnlErrorGettingData
                writingDataLabel = lblPstnlWritingData
                errorWritingDataLabel = lblPstnlErrorWritingData
                completedLabel = lblPstnlCompleted
            Case InstrumentDetails.TypeOfInstrument.Cash
                If UpdateDataType = DataType.Intraday Then
                    totalLabel = lblIntradayCashTotal
                    queuedLabel = lblIntradayCashQueue
                    gettingDataLabel = lblIntradayCashGettingData
                    errorGettingDataLabel = lblIntradayCashErrorGettingData
                    writingDataLabel = lblIntradayCashWritingData
                    errorWritingDataLabel = lblIntradayCashErrorWritingData
                    completedLabel = lblIntradayCashCompleted
                ElseIf UpdateDataType = DataType.EOD Then
                    totalLabel = lblEODCashTotal
                    queuedLabel = lblEODCashQueue
                    gettingDataLabel = lblEODCashGettingData
                    errorGettingDataLabel = lblEODCashErrorGettingData
                    writingDataLabel = lblEODCashWritingData
                    errorWritingDataLabel = lblEODCashErrorWritingData
                    completedLabel = lblEODCashCompleted
                End If
            Case InstrumentDetails.TypeOfInstrument.Futures
                If UpdateDataType = DataType.Intraday Then
                    totalLabel = lblIntradayFutureTotal
                    queuedLabel = lblIntradayFutureQueue
                    gettingDataLabel = lblIntradayFutureGettingData
                    errorGettingDataLabel = lblIntradayFutureErrorGettingData
                    writingDataLabel = lblIntradayFutureWritingData
                    errorWritingDataLabel = lblIntradayFutureErrorWritingData
                    completedLabel = lblIntradayFutureCompleted
                ElseIf UpdateDataType = DataType.EOD Then
                    totalLabel = lblEODFutureTotal
                    queuedLabel = lblEODFutureQueue
                    gettingDataLabel = lblEODFutureGettingData
                    errorGettingDataLabel = lblEODFutureErrorGettingData
                    writingDataLabel = lblEODFutureWritingData
                    errorWritingDataLabel = lblEODFutureErrorWritingData
                    completedLabel = lblEODFutureCompleted
                End If
            Case InstrumentDetails.TypeOfInstrument.Commodity
                If UpdateDataType = DataType.Intraday Then
                    totalLabel = lblIntradayCommodityTotal
                    queuedLabel = lblIntradayCommodityQueue
                    gettingDataLabel = lblIntradayCommodityGettingData
                    errorGettingDataLabel = lblIntradayCommodityErrorGettingData
                    writingDataLabel = lblIntradayCommodityWritingData
                    errorWritingDataLabel = lblIntradayCommodityErrorWritingData
                    completedLabel = lblIntradayCommodityCompleted
                ElseIf UpdateDataType = DataType.EOD Then
                    totalLabel = lblEODCommodityTotal
                    queuedLabel = lblEODCommodityQueue
                    gettingDataLabel = lblEODCommodityGettingData
                    errorGettingDataLabel = lblEODCommodityErrorGettingData
                    writingDataLabel = lblEODCommodityWritingData
                    errorWritingDataLabel = lblEODCommodityErrorWritingData
                    completedLabel = lblEODCommodityCompleted
                End If
            Case InstrumentDetails.TypeOfInstrument.Currency
                If UpdateDataType = DataType.Intraday Then
                    totalLabel = lblIntradayCurrencyTotal
                    queuedLabel = lblIntradayCurrencyQueue
                    gettingDataLabel = lblIntradayCurrencyGettingData
                    errorGettingDataLabel = lblIntradayCurrencyErrorGettingData
                    writingDataLabel = lblIntradayCurrencyWritingData
                    errorWritingDataLabel = lblIntradayCurrencyErrorWritingData
                    completedLabel = lblIntradayCurrencyCompleted
                ElseIf UpdateDataType = DataType.EOD Then
                    totalLabel = lblEODCurrencyTotal
                    queuedLabel = lblEODCurrencyQueue
                    gettingDataLabel = lblEODCurrencyGettingData
                    errorGettingDataLabel = lblEODCurrencyErrorGettingData
                    writingDataLabel = lblEODCurrencyWritingData
                    errorWritingDataLabel = lblEODCurrencyErrorWritingData
                    completedLabel = lblEODCurrencyCompleted
                End If
        End Select
#End Region

        SetLabelText_ThreadSafe(totalLabel, String.Format("Total: {0}", total))
        SetLabelText_ThreadSafe(queuedLabel, String.Format("Queued: {0}", queued))
        SetLabelText_ThreadSafe(gettingDataLabel, String.Format("Getting Data: {0}", gettingData))
        SetLabelText_ThreadSafe(errorGettingDataLabel, String.Format("Error Getting Data: {0}", errorGettingData))
        SetLabelText_ThreadSafe(writingDataLabel, String.Format("Writing Data: {0}", writingData))
        SetLabelText_ThreadSafe(errorWritingDataLabel, String.Format("Error Writing Data: {0}", errorWritingData))
        SetLabelText_ThreadSafe(completedLabel, String.Format("Completed: {0}", completed))
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetObjectEnableDisable_ThreadSafe(btnStop, False)
        Dim arguments As String() = Environment.GetCommandLineArgs()
        If arguments.Length > 1 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        canceller.Cancel()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        btnStart_Click(sender, e)
    End Sub

    Private Async Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        SetObjectEnableDisable_ThreadSafe(btnStop, True)
        SetObjectEnableDisable_ThreadSafe(btnStart, False)
        canceller = New CancellationTokenSource
        Await Task.Run(AddressOf StartProcessingAsync).ConfigureAwait(False)
    End Sub

    Private Async Function StartProcessingAsync() As Task
        Try
            Dim lastDateToCheck As Date = Now
            Dim zerodhaUser As ZerodhaLogin = New ZerodhaLogin(userId:="DK4056",
                                                               password:="Zerodha@123a",
                                                               apiSecret:="t9rd8wut44ija2vp15y87hln28h5oppb",
                                                               apiKey:="hcwmefsivttbchla",
                                                               apiVersion:="3",
                                                               _2FA:="111111",
                                                               canceller:=canceller)
            AddHandler zerodhaUser.Heartbeat, AddressOf OnHeartbeat
            'AddHandler zerodhaUser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
            'AddHandler zerodhaUser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
            'AddHandler zerodhaUser.WaitingFor, AddressOf OnWaitingFor
            Dim loginSuccesful As Boolean = Await zerodhaUser.LoginAsync().ConfigureAwait(False)

            If loginSuccesful Then
                Dim positionalStockList As List(Of InstrumentDetails) = Await GetStockListAsync(InstrumentDetails.TypeOfInstrument.Positional, lastDateToCheck).ConfigureAwait(False)
                Dim cashStockList As List(Of InstrumentDetails) = Await GetStockListAsync(InstrumentDetails.TypeOfInstrument.Cash, lastDateToCheck).ConfigureAwait(False)
                Dim futureStockList As List(Of InstrumentDetails) = Await GetStockListAsync(InstrumentDetails.TypeOfInstrument.Futures, lastDateToCheck).ConfigureAwait(False)
                Dim commodityStockList As List(Of InstrumentDetails) = Await GetStockListAsync(InstrumentDetails.TypeOfInstrument.Commodity, lastDateToCheck).ConfigureAwait(False)
                Dim currencyStockList As List(Of InstrumentDetails) = Await GetStockListAsync(InstrumentDetails.TypeOfInstrument.Currency, lastDateToCheck).ConfigureAwait(False)

#Region "Future"
#Region "Intraday"
                UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Futures
                UpdateDataType = DataType.Intraday
                total = 0
                queued = 0
                gettingData = 0
                errorGettingData = 0
                writingData = 0
                errorWritingData = 0
                completed = 0
                If futureStockList IsNot Nothing AndAlso futureStockList.Count > 0 Then
                    total = futureStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                        tasks = futureStockList.Select(Async Function(x)
                                                           Try
                                                               Await ProcessData(lastDateToCheck, x, sqlHlpr, zerodhaUser, DataType.Intraday).ConfigureAwait(False)
                                                           Catch ex As Exception
                                                               Throw ex
                                                           End Try
                                                           Return True
                                                       End Function)

                        Dim mainTask As Task = Task.WhenAll(tasks)
                        Await mainTask.ConfigureAwait(False)
                        If mainTask.Exception IsNot Nothing Then
                            Throw mainTask.Exception
                        End If
                    End Using
                End If
#End Region

#Region "EOD"
                UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Futures
                UpdateDataType = DataType.EOD
                total = 0
                queued = 0
                gettingData = 0
                errorGettingData = 0
                writingData = 0
                errorWritingData = 0
                completed = 0
                If futureStockList IsNot Nothing AndAlso futureStockList.Count > 0 Then
                    total = futureStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                        tasks = futureStockList.Select(Async Function(x)
                                                           Try
                                                               Await ProcessData(lastDateToCheck, x, sqlHlpr, zerodhaUser, DataType.EOD).ConfigureAwait(False)
                                                           Catch ex As Exception
                                                               Throw ex
                                                           End Try
                                                           Return True
                                                       End Function)

                        Dim mainTask As Task = Task.WhenAll(tasks)
                        Await mainTask.ConfigureAwait(False)
                        If mainTask.Exception IsNot Nothing Then
                            Throw mainTask.Exception
                        End If
                    End Using
                End If
#End Region
#End Region

                Exit Function

#Region "Cash"
#Region "Intraday"
                UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Cash
                UpdateDataType = DataType.Intraday
                total = 0
                queued = 0
                gettingData = 0
                errorGettingData = 0
                writingData = 0
                errorWritingData = 0
                completed = 0
                If cashStockList IsNot Nothing AndAlso cashStockList.Count > 0 Then
                    total = cashStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                        tasks = cashStockList.Select(Async Function(x)
                                                         Try
                                                             Await ProcessData(lastDateToCheck, x, sqlHlpr, zerodhaUser, DataType.Intraday).ConfigureAwait(False)
                                                         Catch ex As Exception
                                                             Throw ex
                                                         End Try
                                                         Return True
                                                     End Function)

                        Dim mainTask As Task = Task.WhenAll(tasks)
                        Await mainTask.ConfigureAwait(False)
                        If mainTask.Exception IsNot Nothing Then
                            Throw mainTask.Exception
                        End If
                    End Using
                End If
#End Region

#Region "EOD"
                UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Cash
                UpdateDataType = DataType.EOD
                total = 0
                queued = 0
                gettingData = 0
                errorGettingData = 0
                writingData = 0
                errorWritingData = 0
                completed = 0
                If cashStockList IsNot Nothing AndAlso cashStockList.Count > 0 Then
                    total = cashStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                        tasks = cashStockList.Select(Async Function(x)
                                                         Try
                                                             Await ProcessData(lastDateToCheck, x, sqlHlpr, zerodhaUser, DataType.EOD).ConfigureAwait(False)
                                                         Catch ex As Exception
                                                             Throw ex
                                                         End Try
                                                         Return True
                                                     End Function)

                        Dim mainTask As Task = Task.WhenAll(tasks)
                        Await mainTask.ConfigureAwait(False)
                        If mainTask.Exception IsNot Nothing Then
                            Throw mainTask.Exception
                        End If
                    End Using
                End If
#End Region
#End Region

#Region "Positional"
                UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Positional
                UpdateDataType = DataType.EOD
                total = 0
                queued = 0
                gettingData = 0
                errorGettingData = 0
                writingData = 0
                errorWritingData = 0
                completed = 0
                If positionalStockList IsNot Nothing AndAlso positionalStockList.Count > 0 Then
                    total = positionalStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                        tasks = positionalStockList.Select(Async Function(x)
                                                               Try
                                                                   Await ProcessData(lastDateToCheck, x, sqlHlpr, zerodhaUser, DataType.EOD).ConfigureAwait(False)
                                                               Catch ex As Exception
                                                                   Throw ex
                                                               End Try
                                                               Return True
                                                           End Function)

                        Dim mainTask As Task = Task.WhenAll(tasks)
                        Await mainTask.ConfigureAwait(False)
                        If mainTask.Exception IsNot Nothing Then
                            Throw mainTask.Exception
                        End If
                    End Using
                End If
#End Region

#Region "Commodity"
#Region "Intraday"
                UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Commodity
                UpdateDataType = DataType.Intraday
                total = 0
                queued = 0
                gettingData = 0
                errorGettingData = 0
                writingData = 0
                errorWritingData = 0
                completed = 0
                If commodityStockList IsNot Nothing AndAlso commodityStockList.Count > 0 Then
                    total = commodityStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                        tasks = commodityStockList.Select(Async Function(x)
                                                              Try
                                                                  Await ProcessData(lastDateToCheck, x, sqlHlpr, zerodhaUser, DataType.Intraday).ConfigureAwait(False)
                                                              Catch ex As Exception
                                                                  Throw ex
                                                              End Try
                                                              Return True
                                                          End Function)

                        Dim mainTask As Task = Task.WhenAll(tasks)
                        Await mainTask.ConfigureAwait(False)
                        If mainTask.Exception IsNot Nothing Then
                            Throw mainTask.Exception
                        End If
                    End Using
                End If
#End Region

#Region "EOD"
                UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Commodity
                UpdateDataType = DataType.EOD
                total = 0
                queued = 0
                gettingData = 0
                errorGettingData = 0
                writingData = 0
                errorWritingData = 0
                completed = 0
                If commodityStockList IsNot Nothing AndAlso commodityStockList.Count > 0 Then
                    total = commodityStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                        tasks = commodityStockList.Select(Async Function(x)
                                                              Try
                                                                  Await ProcessData(lastDateToCheck, x, sqlHlpr, zerodhaUser, DataType.EOD).ConfigureAwait(False)
                                                              Catch ex As Exception
                                                                  Throw ex
                                                              End Try
                                                              Return True
                                                          End Function)

                        Dim mainTask As Task = Task.WhenAll(tasks)
                        Await mainTask.ConfigureAwait(False)
                        If mainTask.Exception IsNot Nothing Then
                            Throw mainTask.Exception
                        End If
                    End Using
                End If
#End Region
#End Region

#Region "Currency"
#Region "Intraday"
                UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Currency
                UpdateDataType = DataType.Intraday
                total = 0
                queued = 0
                gettingData = 0
                errorGettingData = 0
                writingData = 0
                errorWritingData = 0
                completed = 0
                If currencyStockList IsNot Nothing AndAlso currencyStockList.Count > 0 Then
                    total = currencyStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                        tasks = currencyStockList.Select(Async Function(x)
                                                             Try
                                                                 Await ProcessData(lastDateToCheck, x, sqlHlpr, zerodhaUser, DataType.Intraday).ConfigureAwait(False)
                                                             Catch ex As Exception
                                                                 Throw ex
                                                             End Try
                                                             Return True
                                                         End Function)

                        Dim mainTask As Task = Task.WhenAll(tasks)
                        Await mainTask.ConfigureAwait(False)
                        If mainTask.Exception IsNot Nothing Then
                            Throw mainTask.Exception
                        End If
                    End Using
                End If
#End Region

#Region "EOD"
                UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Currency
                UpdateDataType = DataType.EOD
                total = 0
                queued = 0
                gettingData = 0
                errorGettingData = 0
                writingData = 0
                errorWritingData = 0
                completed = 0
                If currencyStockList IsNot Nothing AndAlso currencyStockList.Count > 0 Then
                    total = currencyStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                        tasks = currencyStockList.Select(Async Function(x)
                                                             Try
                                                                 Await ProcessData(lastDateToCheck, x, sqlHlpr, zerodhaUser, DataType.EOD).ConfigureAwait(False)
                                                             Catch ex As Exception
                                                                 Throw ex
                                                             End Try
                                                             Return True
                                                         End Function)

                        Dim mainTask As Task = Task.WhenAll(tasks)
                        Await mainTask.ConfigureAwait(False)
                        If mainTask.Exception IsNot Nothing Then
                            Throw mainTask.Exception
                        End If
                    End Using
                End If
#End Region
#End Region


            Else
                Throw New ApplicationException("Zerodha login fail")
            End If
        Catch cex As OperationCanceledException
            MsgBox(cex.Message)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            SetObjectEnableDisable_ThreadSafe(btnStop, False)
            SetObjectEnableDisable_ThreadSafe(btnStart, True)
            SetLabelText_ThreadSafe(lblProgress, "Process Complete")
        End Try
    End Function

#Region "Main Task"
    Private _internetHitCount As Integer = 0
    Private Async Function ProcessData(ByVal currentDate As Date, ByVal instrument As InstrumentDetails, ByVal dbHlpr As MySQLDBHelper, ByVal zerodha As ZerodhaLogin, ByVal typeOfData As DataType) As Task
        Try
            Interlocked.Increment(queued)
            UpdateLabels()
            While _internetHitCount >= 10
                Await Task.Delay(10, canceller.Token).ConfigureAwait(False)
            End While
            Interlocked.Decrement(queued)
            Interlocked.Increment(gettingData)
            UpdateLabels()

            Await Task.Delay(1, canceller.Token).ConfigureAwait(False)
            Interlocked.Increment(_internetHitCount)

#Region "table name & date selection"
            Dim startDate As Date = Date.MinValue
            Dim endDate As Date = Date.MinValue
            Select Case instrument.InstrumentType
                Case InstrumentDetails.TypeOfInstrument.Cash, InstrumentDetails.TypeOfInstrument.Commodity, InstrumentDetails.TypeOfInstrument.Currency, InstrumentDetails.TypeOfInstrument.Futures
                    startDate = currentDate.AddDays(-30)
                    endDate = currentDate
                Case InstrumentDetails.TypeOfInstrument.Positional
                    startDate = currentDate.AddYears(-3)
                    endDate = currentDate
            End Select
            Dim tableName As String = Nothing
            If instrument.InstrumentType = InstrumentDetails.TypeOfInstrument.Positional Then
                tableName = "eod_positional_data"
            Else
                Select Case instrument.Exchange
                    Case "NSE"
                        Select Case instrument.Segment
                            Case "NSE", "NSE-INDICES", "INDICES"
                                If typeOfData = DataType.Intraday Then
                                    tableName = "intraday_prices_cash"
                                ElseIf typeOfData = DataType.EOD Then
                                    tableName = "eod_prices_cash"
                                End If
                            Case Else
                                Throw New NotImplementedException
                        End Select
                    Case "NFO"
                        Select Case instrument.Segment
                            Case "NFO-FUT"
                                If typeOfData = DataType.Intraday Then
                                    tableName = "intraday_prices_futures"
                                ElseIf typeOfData = DataType.EOD Then
                                    tableName = "eod_prices_futures"
                                End If
                            Case "NFO-OPT"
                                If typeOfData = DataType.Intraday Then
                                    tableName = "intraday_prices_opt_futures"
                                ElseIf typeOfData = DataType.EOD Then
                                    tableName = "eod_prices_opt_futures"
                                End If
                            Case Else
                                Throw New NotImplementedException
                        End Select
                    Case "MCX"
                        Select Case instrument.Segment
                            Case "MCX"
                                If typeOfData = DataType.Intraday Then
                                    tableName = "intraday_prices_commodity"
                                ElseIf typeOfData = DataType.EOD Then
                                    tableName = "eod_prices_commodity"
                                End If
                            Case "MCX-OPT"
                                If typeOfData = DataType.Intraday Then
                                    tableName = "intraday_prices_opt_commodity"
                                ElseIf typeOfData = DataType.EOD Then
                                    tableName = "eod_prices_opt_commodity"
                                End If
                            Case Else
                                Throw New NotImplementedException
                        End Select
                    Case "CDS"
                        Select Case instrument.Segment
                            Case "CDS-FUT"
                                If typeOfData = DataType.Intraday Then
                                    tableName = "intraday_prices_currency"
                                ElseIf typeOfData = DataType.EOD Then
                                    tableName = "eod_prices_currency"
                                End If
                            Case "CDS-OPT"
                                If typeOfData = DataType.Intraday Then
                                    tableName = "intraday_prices_opt_currency"
                                ElseIf typeOfData = DataType.EOD Then
                                    tableName = "eod_prices_opt_currency"
                                End If
                            Case Else
                                Throw New NotImplementedException
                        End Select
                    Case Else
                        Throw New NotImplementedException
                End Select
            End If
#End Region

            If startDate <> Date.MinValue AndAlso endDate <> Date.MinValue AndAlso tableName IsNot Nothing Then
                UpdateLabels()
                Dim historicalData As Dictionary(Of Date, Payload) = Await GetHistoricalDataAsync(instrument.InstrumentToken, instrument.TradingSymbol, startDate, endDate, typeOfData, zerodha)
                canceller.Token.ThrowIfCancellationRequested()
                Interlocked.Decrement(gettingData)
                UpdateLabels()

                If historicalData IsNot Nothing AndAlso historicalData.Count > 0 Then
                    Interlocked.Increment(writingData)
                    UpdateLabels()
                    Dim insertDataString As String = Nothing
                    For Each runningPayload In historicalData.Values
                        canceller.Token.ThrowIfCancellationRequested()
                        If typeOfData = DataType.EOD Then
                            insertDataString = String.Format("{0},('{1}',{2},{3},{4},{5},{6},{7},'{8}',TIMESTAMP(CURRENT_TIME))",
                                                             insertDataString,
                                                             runningPayload.TradingSymbol,
                                                             runningPayload.Open,
                                                             runningPayload.Low,
                                                             runningPayload.High,
                                                             runningPayload.Close,
                                                             runningPayload.Volume,
                                                             runningPayload.OI,
                                                             runningPayload.PayloadDate.ToString("yyyy-MM-dd"))
                        ElseIf typeOfData = DataType.Intraday Then
                            insertDataString = String.Format("{0},('{1}','{2}',{3},{4},{5},{6},{7},'{8}','{9}',TIMESTAMP(CURRENT_TIME))",
                                                             insertDataString,
                                                             runningPayload.TradingSymbol,
                                                             runningPayload.PayloadDate.ToString("yyyy-MM-dd HH:mm:ss"),
                                                             runningPayload.Open,
                                                             runningPayload.Low,
                                                             runningPayload.High,
                                                             runningPayload.Close,
                                                             runningPayload.Volume,
                                                             runningPayload.PayloadDate.ToString("yyyy-MM-dd"),
                                                             runningPayload.PayloadDate.ToString("HH:mm:ss"))
                        End If
                    Next
                    If insertDataString IsNot Nothing Then
                        Dim insertString As String = Nothing
                        If typeOfData = DataType.EOD Then
                            insertString = String.Format("INSERT INTO `{0}` 
                                                            (`TradingSymbol`,
                                                            `Open`,
                                                            `Low`,
                                                            `High`,
                                                            `Close`,
                                                            `Volume`,
                                                            `OI`,
                                                            `SnapshotDate`,
                                                            `UpdateToDBTime`) 
                                                            VALUES {1} 
                                                            ON DUPLICATE KEY UPDATE 
                                                            `TradingSymbol`=VALUES(`TradingSymbol`), 
                                                            `Open`=VALUES(`Open`), `Low`=VALUES(`Low`), 
                                                            `High`=VALUES(`High`), 
                                                            `Close`=VALUES(`Close`), 
                                                            `Volume`=VALUES(`Volume`), 
                                                            `OI`=VALUES(`OI`), 
                                                            `SnapshotDate`=VALUES(`SnapshotDate`), 
                                                            `UpdateToDBTime`=VALUES(`UpdateToDBTime`);",
                                                         tableName, insertDataString.Substring(1))
                        ElseIf typeOfData = DataType.Intraday Then
                            insertString = String.Format("INSERT INTO `{0}` 
                                                            (`TradingSymbol`,
                                                            `SnapshotDateTime`,
                                                            `Open`,
                                                            `Low`,
                                                            `High`,
                                                            `Close`,
                                                            `Volume`,
                                                            `SnapshotDate`,
                                                            `SnapshotTime`,
                                                            `UpdateToDBTime`)
                                                            VALUES {1}
                                                            ON DUPLICATE KEY UPDATE
                                                            `TradingSymbol`=VALUES(`TradingSymbol`),
                                                            `SnapshotDateTime`=VALUES(`SnapshotDateTime`),
                                                            `Open`=VALUES(`Open`),
                                                            `Low`=VALUES(`Low`),
                                                            `High`=VALUES(`High`),
                                                            `Close`=VALUES(`Close`),
                                                            `Volume`=VALUES(`Volume`),
                                                            `SnapshotDate`=VALUES(`SnapshotDate`),
                                                            `SnapshotTime`=VALUES(`SnapshotTime`),
                                                            `UpdateToDBTime`=VALUES(`UpdateToDBTime`);",
                                                         tableName, insertDataString.Substring(1))
                        End If
                        canceller.Token.ThrowIfCancellationRequested()
                        Dim numberOfData As Integer = Await dbHlpr.RunUpdateAsync(insertString).ConfigureAwait(False)
                        Interlocked.Decrement(writingData)
                        Interlocked.Increment(completed)
                        UpdateLabels()
                    End If
                Else
                    Interlocked.Increment(errorGettingData)
                    UpdateLabels()
                End If
            Else
                Console.Write(instrument.TradingSymbol)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Interlocked.Decrement(_internetHitCount)
        End Try
    End Function
#End Region

#Region "Required Functions"
    Private Async Function GetStockListAsync(ByVal instrumentType As InstrumentDetails.TypeOfInstrument, ByVal currentDate As Date) As Task(Of List(Of InstrumentDetails))
        Dim ret As List(Of InstrumentDetails) = Nothing
        Dim tableName As String = Nothing
        Select Case instrumentType
            Case InstrumentDetails.TypeOfInstrument.Cash, InstrumentDetails.TypeOfInstrument.Positional
                tableName = "active_instruments_cash"
            Case InstrumentDetails.TypeOfInstrument.Commodity
                tableName = "active_instruments_commodity"
            Case InstrumentDetails.TypeOfInstrument.Currency
                tableName = "active_instruments_currency"
            Case InstrumentDetails.TypeOfInstrument.Futures
                tableName = "active_instruments_futures"
        End Select

        Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
            AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
            'AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
            'AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
            'AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor

            Dim queryString As String = "SELECT DISTINCT(`INSTRUMENT_TOKEN`),`TRADING_SYMBOL`,`SEGMENT`,`EXCHANGE` FROM `{0}` WHERE `AS_ON_DATE`='{1}'"
            queryString = String.Format(queryString, tableName, currentDate.ToString("yyyy-MM-dd"))

            Dim dt As DataTable = Await sqlHlpr.RunSelectAsync(queryString).ConfigureAwait(False)
            canceller.Token.ThrowIfCancellationRequested()
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    canceller.Token.ThrowIfCancellationRequested()
                    If Not IsDBNull(dt.Rows(i).Item(0)) AndAlso Not IsDBNull(dt.Rows(i).Item(1)) AndAlso Not IsDBNull(dt.Rows(i).Item(2)) Then
                        Dim runningInstrument As InstrumentDetails = New InstrumentDetails
                        runningInstrument.InstrumentToken = dt.Rows(i).Item(0)
                        runningInstrument.TradingSymbol = dt.Rows(i).Item(1)
                        runningInstrument.Segment = dt.Rows(i).Item(2)
                        runningInstrument.Exchange = dt.Rows(i).Item(3)
                        runningInstrument.InstrumentType = instrumentType

                        If ret Is Nothing Then ret = New List(Of InstrumentDetails)
                        ret.Add(runningInstrument)

                        If i >= 100 Then Exit For
                    End If
                Next
            End If
        End Using
        Return ret
    End Function

    Private Async Function GetHistoricalDataAsync(ByVal instrumentToken As String, ByVal tradingSymbol As String, ByVal startDate As Date, ByVal endDate As Date, ByVal typeOfData As DataType, ByVal zerodhaDetails As ZerodhaLogin) As Task(Of Dictionary(Of Date, Payload))
        Dim ret As Dictionary(Of Date, Payload) = Nothing
        'Dim ZerodhaEODHistoricalURL As String = "https://kitecharts-aws.zerodha.com/api/chart/{0}/day?api_key=kitefront&access_token=K&from={1}&to={2}"
        'Dim ZerodhaIntradayHistoricalURL As String = "https://kitecharts-aws.zerodha.com/api/chart/{0}/minute?api_key=kitefront&access_token=K&from={1}&to={2}"
        Dim ZerodhaEODHistoricalURL As String = "https://kite.zerodha.com/oms/instruments/historical/{0}/day?&oi=1&from={1}&to={2}"
        Dim ZerodhaIntradayHistoricalURL As String = "https://kite.zerodha.com/oms/instruments/historical/{0}/minute?oi=1&from={1}&to={2}"
        Dim ZerodhaHistoricalURL As String = Nothing
        Select Case typeOfData
            Case DataType.EOD
                ZerodhaHistoricalURL = ZerodhaEODHistoricalURL
            Case DataType.Intraday
                ZerodhaHistoricalURL = ZerodhaIntradayHistoricalURL
        End Select
        If instrumentToken IsNot Nothing AndAlso instrumentToken <> "" Then
            Dim historicalDataURL As String = String.Format(ZerodhaHistoricalURL, instrumentToken, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"))
            OnHeartbeat(String.Format("Fetching historical Data: {0}", historicalDataURL))
            Dim historicalCandlesJSONDict As Dictionary(Of String, Object) = Nothing

            ServicePointManager.Expect100Continue = False
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            ServicePointManager.ServerCertificateValidationCallback = Function(s, Ca, CaC, sslPE)
                                                                          Return True
                                                                      End Function

            HttpBrowser.KillCookies()
            Dim proxyToBeUsed As HttpProxy = Nothing
            Using browser As New HttpBrowser(proxyToBeUsed, Net.DecompressionMethods.GZip Or DecompressionMethods.Deflate Or DecompressionMethods.None, New TimeSpan(0, 1, 0), canceller)
                AddHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                AddHandler browser.Heartbeat, AddressOf OnHeartbeat
                AddHandler browser.WaitingFor, AddressOf OnWaitingFor
                AddHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                AddHandler browser.FirstError, AddressOf OnFirstErrorGettingData

                Dim headers As New Dictionary(Of String, String)
                headers.Add("Host", "kite.zerodha.com")
                headers.Add("Accept", "*/*")
                headers.Add("Accept-Encoding", "gzip, deflate")
                headers.Add("Accept-Language", "en-US,en;q=0.9,hi;q=0.8,ko;q=0.7")
                headers.Add("Authorization", String.Format("enctoken {0}", zerodhaDetails.ENCToken))
                headers.Add("Referer", "https://kite.zerodha.com/static/build/chart.html?v=2.4.0")
                headers.Add("sec-fetch-mode", "cors")
                headers.Add("sec-fetch-site", "same-origin")
                headers.Add("Connection", "keep-alive")

                canceller.Token.ThrowIfCancellationRequested()
                Dim l As Tuple(Of Uri, Object) = Await browser.NonPOSTRequestAsync(historicalDataURL,
                                                                                    HttpMethod.Get,
                                                                                    Nothing,
                                                                                    False,
                                                                                    headers,
                                                                                    True,
                                                                                    "application/json").ConfigureAwait(False)
                canceller.Token.ThrowIfCancellationRequested()
                If l IsNot Nothing AndAlso l.Item2 IsNot Nothing Then
                    historicalCandlesJSONDict = l.Item2
                End If
                RemoveHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                RemoveHandler browser.Heartbeat, AddressOf OnHeartbeat
                RemoveHandler browser.WaitingFor, AddressOf OnWaitingFor
                RemoveHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                RemoveHandler browser.FirstError, AddressOf OnFirstErrorGettingData
            End Using

            If historicalCandlesJSONDict IsNot Nothing AndAlso historicalCandlesJSONDict.Count > 0 AndAlso
                historicalCandlesJSONDict.ContainsKey("data") Then
                Dim historicalCandlesDict As Dictionary(Of String, Object) = historicalCandlesJSONDict("data")
                If historicalCandlesDict.ContainsKey("candles") AndAlso historicalCandlesDict("candles").count > 0 Then
                    Dim historicalCandles As ArrayList = historicalCandlesDict("candles")
                    OnHeartbeat(String.Format("Generating Payload for {0}", tradingSymbol))
                    Dim previousPayload As Payload = Nothing
                    For Each historicalCandle In historicalCandles
                        canceller.Token.ThrowIfCancellationRequested()
                        Dim runningSnapshotTime As Date = Utilities.Time.GetDateTimeTillMinutes(historicalCandle(0))

                        Dim runningPayload As Payload = New Payload
                        With runningPayload
                            .PayloadDate = Utilities.Time.GetDateTimeTillMinutes(historicalCandle(0))
                            .TradingSymbol = tradingSymbol
                            .Open = historicalCandle(1)
                            .High = historicalCandle(2)
                            .Low = historicalCandle(3)
                            .Close = historicalCandle(4)
                            .Volume = historicalCandle(5)
                            .OI = historicalCandle(6)
                        End With
                        If ret Is Nothing Then ret = New Dictionary(Of Date, Payload)
                        ret.Add(runningSnapshotTime, runningPayload)
                    Next
                End If
            End If
        End If
        Return ret
    End Function
#End Region

End Class
