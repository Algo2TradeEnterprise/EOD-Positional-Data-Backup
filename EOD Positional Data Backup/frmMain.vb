Imports Utilities.DAL
Imports System.Threading
Imports Utilities.Network
Imports System.Net.Http
Imports System.Net
Imports System.Text
Imports HtmlAgilityPack
Imports System.Text.RegularExpressions

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

    Private NumberOfParallelTask As Integer = 10
    Private UpdateIntrumentType As InstrumentDetails.TypeOfInstrument
    Private UpdateDataType As DataType

    Private CountPerSecond As Decimal = 0
    Private TotalInstrumentCount As Decimal = 0
    Private InstrumentCounter As Integer = 0

    Private total As Integer = 0
    Private queued As Integer = 0
    Private gettingData As Integer = 0
    Private errorGettingData As Integer = 0
    Private writingData As Integer = 0
    Private errorWritingData As Integer = 0
    Private completed As Integer = 0
    Private errorCompleted As Integer = 0

    Private intradayCashErrorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing
    Private eodCashErrorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing
    Private intradayFutureErrorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing
    Private eodFutureErrorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing
    Private intradayCommodityErrorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing
    Private eodCommodityErrorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing
    Private intradayCurrencyErrorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing
    Private eodCurrencyErrorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing
    Private positionalErrorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing
    Private optionChainErrorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing

    Private canceller As CancellationTokenSource

    Private Sub UpdateErrorList(ByVal instrument As InstrumentDetails, ByVal typeOfData As DataType, ByVal errorMessage As String)
        Select Case instrument.InstrumentType
            Case InstrumentDetails.TypeOfInstrument.Cash
                If typeOfData = DataType.Intraday Then
                    If intradayCashErrorList Is Nothing Then intradayCashErrorList = New Concurrent.ConcurrentDictionary(Of String, InstrumentDetails)
                    Dim instrumentToAdd As InstrumentDetails = Utilities.Strings.DeepClone(Of InstrumentDetails)(instrument)
                    instrumentToAdd.ErrorMessage = errorMessage
                    If Not intradayCashErrorList.ContainsKey(instrumentToAdd.TradingSymbol) Then intradayCashErrorList.TryAdd(instrumentToAdd.TradingSymbol, instrumentToAdd)
                ElseIf typeOfData = DataType.EOD Then
                    If eodCashErrorList Is Nothing Then eodCashErrorList = New Concurrent.ConcurrentDictionary(Of String, InstrumentDetails)
                    Dim instrumentToAdd As InstrumentDetails = Utilities.Strings.DeepClone(Of InstrumentDetails)(instrument)
                    instrumentToAdd.ErrorMessage = errorMessage
                    If Not eodCashErrorList.ContainsKey(instrumentToAdd.TradingSymbol) Then eodCashErrorList.TryAdd(instrumentToAdd.TradingSymbol, instrumentToAdd)
                End If
            Case InstrumentDetails.TypeOfInstrument.Futures
                If typeOfData = DataType.Intraday Then
                    If intradayFutureErrorList Is Nothing Then intradayFutureErrorList = New Concurrent.ConcurrentDictionary(Of String, InstrumentDetails)
                    Dim instrumentToAdd As InstrumentDetails = Utilities.Strings.DeepClone(Of InstrumentDetails)(instrument)
                    instrumentToAdd.ErrorMessage = errorMessage
                    If Not intradayFutureErrorList.ContainsKey(instrumentToAdd.TradingSymbol) Then intradayFutureErrorList.TryAdd(instrumentToAdd.TradingSymbol, instrumentToAdd)
                ElseIf typeOfData = DataType.EOD Then
                    If eodFutureErrorList Is Nothing Then eodFutureErrorList = New Concurrent.ConcurrentDictionary(Of String, InstrumentDetails)
                    Dim instrumentToAdd As InstrumentDetails = Utilities.Strings.DeepClone(Of InstrumentDetails)(instrument)
                    instrumentToAdd.ErrorMessage = errorMessage
                    If Not eodFutureErrorList.ContainsKey(instrumentToAdd.TradingSymbol) Then eodFutureErrorList.TryAdd(instrumentToAdd.TradingSymbol, instrumentToAdd)
                End If
            Case InstrumentDetails.TypeOfInstrument.Commodity
                If typeOfData = DataType.Intraday Then
                    If intradayCommodityErrorList Is Nothing Then intradayCommodityErrorList = New Concurrent.ConcurrentDictionary(Of String, InstrumentDetails)
                    Dim instrumentToAdd As InstrumentDetails = Utilities.Strings.DeepClone(Of InstrumentDetails)(instrument)
                    instrumentToAdd.ErrorMessage = errorMessage
                    If Not intradayCommodityErrorList.ContainsKey(instrumentToAdd.TradingSymbol) Then intradayCommodityErrorList.TryAdd(instrumentToAdd.TradingSymbol, instrumentToAdd)
                ElseIf typeOfData = DataType.EOD Then
                    If eodCommodityErrorList Is Nothing Then eodCommodityErrorList = New Concurrent.ConcurrentDictionary(Of String, InstrumentDetails)
                    Dim instrumentToAdd As InstrumentDetails = Utilities.Strings.DeepClone(Of InstrumentDetails)(instrument)
                    instrumentToAdd.ErrorMessage = errorMessage
                    If Not eodCommodityErrorList.ContainsKey(instrumentToAdd.TradingSymbol) Then eodCommodityErrorList.TryAdd(instrumentToAdd.TradingSymbol, instrumentToAdd)
                End If
            Case InstrumentDetails.TypeOfInstrument.Currency
                If typeOfData = DataType.Intraday Then
                    If intradayCurrencyErrorList Is Nothing Then intradayCurrencyErrorList = New Concurrent.ConcurrentDictionary(Of String, InstrumentDetails)
                    Dim instrumentToAdd As InstrumentDetails = Utilities.Strings.DeepClone(Of InstrumentDetails)(instrument)
                    instrumentToAdd.ErrorMessage = errorMessage
                    If Not intradayCurrencyErrorList.ContainsKey(instrumentToAdd.TradingSymbol) Then intradayCurrencyErrorList.TryAdd(instrumentToAdd.TradingSymbol, instrumentToAdd)
                ElseIf typeOfData = DataType.EOD Then
                    If eodCurrencyErrorList Is Nothing Then eodCurrencyErrorList = New Concurrent.ConcurrentDictionary(Of String, InstrumentDetails)
                    Dim instrumentToAdd As InstrumentDetails = Utilities.Strings.DeepClone(Of InstrumentDetails)(instrument)
                    instrumentToAdd.ErrorMessage = errorMessage
                    If Not eodCurrencyErrorList.ContainsKey(instrumentToAdd.TradingSymbol) Then eodCurrencyErrorList.TryAdd(instrumentToAdd.TradingSymbol, instrumentToAdd)
                End If
            Case InstrumentDetails.TypeOfInstrument.Positional
                If positionalErrorList Is Nothing Then positionalErrorList = New Concurrent.ConcurrentDictionary(Of String, InstrumentDetails)
                Dim instrumentToAdd As InstrumentDetails = Utilities.Strings.DeepClone(Of InstrumentDetails)(instrument)
                instrumentToAdd.ErrorMessage = errorMessage
                If Not positionalErrorList.ContainsKey(instrumentToAdd.TradingSymbol) Then positionalErrorList.TryAdd(instrumentToAdd.TradingSymbol, instrumentToAdd)
            Case InstrumentDetails.TypeOfInstrument.OptionChain
                If optionChainErrorList Is Nothing Then optionChainErrorList = New Concurrent.ConcurrentDictionary(Of String, InstrumentDetails)
                Dim instrumentToAdd As InstrumentDetails = Utilities.Strings.DeepClone(Of InstrumentDetails)(instrument)
                instrumentToAdd.ErrorMessage = errorMessage
                If Not optionChainErrorList.ContainsKey(instrumentToAdd.TradingSymbol) Then optionChainErrorList.TryAdd(instrumentToAdd.TradingSymbol, instrumentToAdd)
        End Select
    End Sub

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
            Case InstrumentDetails.TypeOfInstrument.OptionChain
                totalLabel = lblOptnChnTotal
                queuedLabel = lblOptnChnQueue
                gettingDataLabel = lblOptnChnGettingData
                errorGettingDataLabel = lblOptnChnErrorGettingData
                writingDataLabel = lblOptnChnWritingData
                errorWritingDataLabel = lblOptnChnErrorWritingData
                completedLabel = lblOptnChnCompleted
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
        SetLabelText_ThreadSafe(queuedLabel, String.Format("Pending: {0}", total - (completed + errorCompleted)))
        SetLabelText_ThreadSafe(gettingDataLabel, String.Format("Getting Data: {0}", gettingData))
        SetLabelText_ThreadSafe(errorGettingDataLabel, String.Format("Error Getting Data: {0}", errorGettingData))
        SetLabelText_ThreadSafe(writingDataLabel, String.Format("Writing Data: {0}", writingData))
        SetLabelText_ThreadSafe(errorWritingDataLabel, String.Format("Error Writing Data: {0}", errorWritingData))
        SetLabelText_ThreadSafe(completedLabel, String.Format("Completed: {0}", completed))
        SetLabelText_ThreadSafe(lblCountDisplay, Math.Round(CountPerSecond, 2))
        If CountPerSecond > 0 Then
            SetLabelText_ThreadSafe(lblExpctdFnsTm, Now.AddSeconds((TotalInstrumentCount - InstrumentCounter) / CountPerSecond))
        End If
    End Sub

    Private Sub ManageBulb(ByVal bulbColor As Color)
        Select Case UpdateIntrumentType
            Case InstrumentDetails.TypeOfInstrument.Positional
                blbPositional.Color = bulbColor
            Case InstrumentDetails.TypeOfInstrument.OptionChain
                blbOptionChain.Color = bulbColor
            Case InstrumentDetails.TypeOfInstrument.Cash
                If UpdateDataType = DataType.Intraday Then
                    blbIntradayCash.Color = bulbColor
                ElseIf UpdateDataType = DataType.EOD Then
                    blbEODCash.Color = bulbColor
                End If
            Case InstrumentDetails.TypeOfInstrument.Futures
                If UpdateDataType = DataType.Intraday Then
                    blbIntradayFuture.Color = bulbColor
                ElseIf UpdateDataType = DataType.EOD Then
                    blbEODFuture.Color = bulbColor
                End If
            Case InstrumentDetails.TypeOfInstrument.Commodity
                If UpdateDataType = DataType.Intraday Then
                    blbIntradayCommodity.Color = bulbColor
                ElseIf UpdateDataType = DataType.EOD Then
                    blbEODCommodity.Color = bulbColor
                End If
            Case InstrumentDetails.TypeOfInstrument.Currency
                If UpdateDataType = DataType.Intraday Then
                    blbIntradayCurrency.Color = bulbColor
                ElseIf UpdateDataType = DataType.EOD Then
                    blbEODCurrency.Color = bulbColor
                End If
        End Select
    End Sub

    Private Sub ClearAll()
        TotalInstrumentCount = 0

        blbIntradayCash.Color = Color.Red
        blbEODCash.Color = Color.Red
        blbIntradayFuture.Color = Color.Red
        blbEODFuture.Color = Color.Red
        blbIntradayCommodity.Color = Color.Red
        blbEODCommodity.Color = Color.Red
        blbIntradayCurrency.Color = Color.Red
        blbEODCurrency.Color = Color.Red
        blbPositional.Color = Color.Red
        blbOptionChain.Color = Color.Red

        lblCountDisplay.Text = "0"
        lblExpctdFnsTm.Text = "00:00:00"

        CountPerSecond = 0
        total = 0
        queued = 0
        gettingData = 0
        errorGettingData = 0
        writingData = 0
        errorWritingData = 0
        completed = 0
        errorCompleted = 0

        UpdateDataType = DataType.EOD
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.OptionChain
        UpdateLabels()
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Positional
        UpdateLabels()
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Cash
        UpdateLabels()
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Futures
        UpdateLabels()
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Commodity
        UpdateLabels()
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Currency
        UpdateLabels()

        UpdateDataType = DataType.Intraday
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.OptionChain
        UpdateLabels()
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Positional
        UpdateLabels()
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Cash
        UpdateLabels()
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Futures
        UpdateLabels()
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Commodity
        UpdateLabels()
        UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.Currency
        UpdateLabels()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetObjectEnableDisable_ThreadSafe(btnStop, False)

        nmrcParallelHit.Value = My.Settings.NumberOfParallelHit
        rdbWithAPI.Checked = My.Settings.HistoricalHitWithAPI
        rdbWithoutAPI.Checked = My.Settings.HistoricalHitWithoutAPI

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
        My.Settings.NumberOfParallelHit = nmrcParallelHit.Value
        My.Settings.HistoricalHitWithAPI = rdbWithAPI.Checked
        My.Settings.HistoricalHitWithoutAPI = rdbWithoutAPI.Checked
        My.Settings.Save()

        SetObjectEnableDisable_ThreadSafe(btnStop, True)
        SetObjectEnableDisable_ThreadSafe(btnStart, False)
        SetObjectEnableDisable_ThreadSafe(grpHistoricalHitMode, False)
        SetObjectEnableDisable_ThreadSafe(nmrcParallelHit, False)

        SetObjectEnableDisable_ThreadSafe(chkbIntradayCash, False)
        SetObjectEnableDisable_ThreadSafe(chkbEODCash, False)
        SetObjectEnableDisable_ThreadSafe(chkbIntradayFuture, False)
        SetObjectEnableDisable_ThreadSafe(chkbEODFuture, False)
        SetObjectEnableDisable_ThreadSafe(chkbIntradayCommodity, False)
        SetObjectEnableDisable_ThreadSafe(chkbEODCommodity, False)
        SetObjectEnableDisable_ThreadSafe(chkbIntradayCurrency, False)
        SetObjectEnableDisable_ThreadSafe(chkbEODCurrency, False)
        SetObjectEnableDisable_ThreadSafe(chkbPositional, False)
        SetObjectEnableDisable_ThreadSafe(chkbOptionChain, False)

        ClearAll()

        Me.NumberOfParallelTask = nmrcParallelHit.Value
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
            Dim loginSuccesful As Boolean = False
            If GetRadioButtonChecked_ThreadSafe(rdbWithAPI) Then
                loginSuccesful = Await zerodhaUser.LoginAsync().ConfigureAwait(False)
            End If

            If loginSuccesful OrElse GetRadioButtonChecked_ThreadSafe(rdbWithoutAPI) Then
                Dim positionalStockList As List(Of InstrumentDetails) = Await GetStockListAsync(InstrumentDetails.TypeOfInstrument.Positional, lastDateToCheck).ConfigureAwait(False)
                Dim cashStockList As List(Of InstrumentDetails) = Await GetStockListAsync(InstrumentDetails.TypeOfInstrument.Cash, lastDateToCheck).ConfigureAwait(False)
                Dim futureStockList As List(Of InstrumentDetails) = Await GetStockListAsync(InstrumentDetails.TypeOfInstrument.Futures, lastDateToCheck).ConfigureAwait(False)
                Dim commodityStockList As List(Of InstrumentDetails) = Await GetStockListAsync(InstrumentDetails.TypeOfInstrument.Commodity, lastDateToCheck).ConfigureAwait(False)
                Dim currencyStockList As List(Of InstrumentDetails) = Await GetStockListAsync(InstrumentDetails.TypeOfInstrument.Currency, lastDateToCheck).ConfigureAwait(False)
                Dim optionChainStockList As List(Of InstrumentDetails) = Await GetAllOptionChainStockListAsync().ConfigureAwait(False)

                Me.TotalInstrumentCount = 0
                If cashStockList IsNot Nothing Then
                    If GetCheckBoxChecked_ThreadSafe(chkbIntradayCash) Then TotalInstrumentCount += cashStockList.Count
                    If GetCheckBoxChecked_ThreadSafe(chkbEODCash) Then TotalInstrumentCount += cashStockList.Count
                End If
                If futureStockList IsNot Nothing Then
                    If GetCheckBoxChecked_ThreadSafe(chkbIntradayFuture) Then TotalInstrumentCount += futureStockList.Count
                    If GetCheckBoxChecked_ThreadSafe(chkbEODFuture) Then TotalInstrumentCount += futureStockList.Count
                End If
                If commodityStockList IsNot Nothing Then
                    If GetCheckBoxChecked_ThreadSafe(chkbIntradayCommodity) Then TotalInstrumentCount += commodityStockList.Count
                    If GetCheckBoxChecked_ThreadSafe(chkbEODCommodity) Then TotalInstrumentCount += commodityStockList.Count
                End If
                If currencyStockList IsNot Nothing Then
                    If GetCheckBoxChecked_ThreadSafe(chkbIntradayCurrency) Then TotalInstrumentCount += currencyStockList.Count
                    If GetCheckBoxChecked_ThreadSafe(chkbEODCurrency) Then TotalInstrumentCount += currencyStockList.Count
                End If
                If positionalStockList IsNot Nothing Then
                    If GetCheckBoxChecked_ThreadSafe(chkbPositional) Then TotalInstrumentCount += positionalStockList.Count
                End If
                If optionChainStockList IsNot Nothing Then
                    If GetCheckBoxChecked_ThreadSafe(chkbOptionChain) Then TotalInstrumentCount += optionChainStockList.Count
                End If

                InstrumentCounter = 0
                CountPerSecond = 0
                Dim sw As Stopwatch = New Stopwatch
                sw.Start()

#Region "Option Chain"
                UpdateIntrumentType = InstrumentDetails.TypeOfInstrument.OptionChain
                UpdateDataType = DataType.EOD
                total = 0
                queued = 0
                gettingData = 0
                errorGettingData = 0
                writingData = 0
                errorWritingData = 0
                completed = 0
                errorCompleted = 0
                ManageBulb(Color.Yellow)
                If GetCheckBoxChecked_ThreadSafe(chkbOptionChain) AndAlso optionChainStockList IsNot Nothing AndAlso optionChainStockList.Count > 0 Then
                    total = optionChainStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Try
                            sw.Start()
                            For i As Integer = 0 To optionChainStockList.Count - 1 Step Me.NumberOfParallelTask
                                canceller.Token.ThrowIfCancellationRequested()
                                Dim numberOfData As Integer = If(optionChainStockList.Count - i > Me.NumberOfParallelTask, Me.NumberOfParallelTask, optionChainStockList.Count - i)
                                Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                                tasks = optionChainStockList.GetRange(i, numberOfData).Select(Async Function(x)
                                                                                                  Try
                                                                                                      Await ProcessOptionChainData(x, sqlHlpr).ConfigureAwait(False)
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
                                InstrumentCounter += numberOfData
                                If sw.Elapsed.TotalSeconds > 0 Then CountPerSecond = InstrumentCounter / sw.Elapsed.TotalSeconds
                                UpdateLabels()
                            Next
                            sw.Stop()
                        Catch cex As TaskCanceledException
                            'logger.Error(cex)
                            Throw cex
                        Catch aex As AggregateException
                            'logger.Error(aex)
                            Throw aex
                        Catch ex As Exception
                            'logger.Error(ex)
                            Throw ex
                        End Try
                    End Using
                End If
                ManageBulb(Color.LawnGreen)
                SendNotification(String.Format("{0} {1} : <<<<< SUCCESS >>>>> : Data Backup Process", Now.DayOfWeek, Now.ToString("dd-MMM-yyyy")), "Option Chain Complete")
                'SendNotification(String.Format("{0} {1} : <<<<< SUCCESS >>>>> : Data Backup Process", Now.DayOfWeek, Now.ToString("dd-MMM-yyyy")),
                '                 String.Format("{0}, {1}, {2}",
                '                               GetLabelText_ThreadSafe(lblOptnChnTotal),
                '                               GetLabelText_ThreadSafe(lblOptnChnCompleted),
                '                               GetLabelText_ThreadSafe(lblOptnChnErrorGettingData)))
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
                errorCompleted = 0
                ManageBulb(Color.Yellow)
                If GetCheckBoxChecked_ThreadSafe(chkbPositional) AndAlso positionalStockList IsNot Nothing AndAlso positionalStockList.Count > 0 Then
                    total = positionalStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Try
                            sw.Start()
                            For i As Integer = 0 To positionalStockList.Count - 1 Step Me.NumberOfParallelTask
                                canceller.Token.ThrowIfCancellationRequested()
                                Dim numberOfData As Integer = If(positionalStockList.Count - i > Me.NumberOfParallelTask, Me.NumberOfParallelTask, positionalStockList.Count - i)
                                Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                                tasks = positionalStockList.GetRange(i, numberOfData).Select(Async Function(x)
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
                                InstrumentCounter += numberOfData
                                If sw.Elapsed.TotalSeconds > 0 Then CountPerSecond = InstrumentCounter / sw.Elapsed.TotalSeconds
                                UpdateLabels()
                            Next
                            sw.Stop()
                        Catch cex As TaskCanceledException
                            'logger.Error(cex)
                            Throw cex
                        Catch aex As AggregateException
                            'logger.Error(aex)
                            Throw aex
                        Catch ex As Exception
                            'logger.Error(ex)
                            Throw ex
                        End Try
                    End Using
                End If
                ManageBulb(Color.LawnGreen)
                SendNotification(String.Format("{0} {1} : <<<<< SUCCESS >>>>> : Data Backup Process", Now.DayOfWeek, Now.ToString("dd-MMM-yyyy")), "Positional Complete")
#End Region

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
                errorCompleted = 0
                ManageBulb(Color.Yellow)
                If GetCheckBoxChecked_ThreadSafe(chkbIntradayCash) AndAlso cashStockList IsNot Nothing AndAlso cashStockList.Count > 0 Then
                    total = cashStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Try
                            For i As Integer = 0 To cashStockList.Count - 1 Step Me.NumberOfParallelTask
                                canceller.Token.ThrowIfCancellationRequested()
                                Dim numberOfData As Integer = If(cashStockList.Count - i > Me.NumberOfParallelTask, Me.NumberOfParallelTask, cashStockList.Count - i)
                                Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                                tasks = cashStockList.GetRange(i, numberOfData).Select(Async Function(x)
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
                                InstrumentCounter += numberOfData
                                If sw.Elapsed.TotalSeconds > 0 Then CountPerSecond = InstrumentCounter / sw.Elapsed.TotalSeconds
                                UpdateLabels()
                            Next
                            sw.Stop()
                        Catch cex As TaskCanceledException
                            'logger.Error(cex)
                            Throw cex
                        Catch aex As AggregateException
                            'logger.Error(aex)
                            Throw aex
                        Catch ex As Exception
                            'logger.Error(ex)
                            Throw ex
                        End Try
                    End Using
                End If
                ManageBulb(Color.LawnGreen)
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
                errorCompleted = 0
                ManageBulb(Color.Yellow)
                If GetCheckBoxChecked_ThreadSafe(chkbEODCash) AndAlso cashStockList IsNot Nothing AndAlso cashStockList.Count > 0 Then
                    total = cashStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Try
                            sw.Start()
                            For i As Integer = 0 To cashStockList.Count - 1 Step Me.NumberOfParallelTask
                                canceller.Token.ThrowIfCancellationRequested()
                                Dim numberOfData As Integer = If(cashStockList.Count - i > Me.NumberOfParallelTask, Me.NumberOfParallelTask, cashStockList.Count - i)
                                Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                                tasks = cashStockList.GetRange(i, numberOfData).Select(Async Function(x)
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
                                InstrumentCounter += numberOfData
                                If sw.Elapsed.TotalSeconds > 0 Then CountPerSecond = InstrumentCounter / sw.Elapsed.TotalSeconds
                                UpdateLabels()
                            Next
                            sw.Stop()
                        Catch cex As TaskCanceledException
                            'logger.Error(cex)
                            Throw cex
                        Catch aex As AggregateException
                            'logger.Error(aex)
                            Throw aex
                        Catch ex As Exception
                            'logger.Error(ex)
                            Throw ex
                        End Try
                    End Using
                End If
                ManageBulb(Color.LawnGreen)
#End Region
#End Region

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
                errorCompleted = 0
                ManageBulb(Color.Yellow)
                If GetCheckBoxChecked_ThreadSafe(chkbIntradayFuture) AndAlso futureStockList IsNot Nothing AndAlso futureStockList.Count > 0 Then
                    total = futureStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Try
                            sw.Start()
                            For i As Integer = 0 To futureStockList.Count - 1 Step Me.NumberOfParallelTask
                                canceller.Token.ThrowIfCancellationRequested()
                                Dim numberOfData As Integer = If(futureStockList.Count - i > Me.NumberOfParallelTask, Me.NumberOfParallelTask, futureStockList.Count - i)
                                Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                                tasks = futureStockList.GetRange(i, numberOfData).Select(Async Function(x)
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
                                InstrumentCounter += numberOfData
                                If sw.Elapsed.TotalSeconds > 0 Then CountPerSecond = InstrumentCounter / sw.Elapsed.TotalSeconds
                                UpdateLabels()
                            Next
                            sw.Stop()
                        Catch cex As TaskCanceledException
                            'logger.Error(cex)
                            Throw cex
                        Catch aex As AggregateException
                            'logger.Error(aex)
                            Throw aex
                        Catch ex As Exception
                            'logger.Error(ex)
                            Throw ex
                        End Try
                    End Using
                End If
                ManageBulb(Color.LawnGreen)
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
                errorCompleted = 0
                ManageBulb(Color.Yellow)
                If GetCheckBoxChecked_ThreadSafe(chkbEODFuture) AndAlso futureStockList IsNot Nothing AndAlso futureStockList.Count > 0 Then
                    total = futureStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Try
                            sw.Start()
                            For i As Integer = 0 To futureStockList.Count - 1 Step Me.NumberOfParallelTask
                                canceller.Token.ThrowIfCancellationRequested()
                                Dim numberOfData As Integer = If(futureStockList.Count - i > Me.NumberOfParallelTask, Me.NumberOfParallelTask, futureStockList.Count - i)
                                Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                                tasks = futureStockList.GetRange(i, numberOfData).Select(Async Function(x)
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
                                InstrumentCounter += numberOfData
                                If sw.Elapsed.TotalSeconds > 0 Then CountPerSecond = InstrumentCounter / sw.Elapsed.TotalSeconds
                                UpdateLabels()
                            Next
                            sw.Stop()
                        Catch cex As TaskCanceledException
                            'logger.Error(cex)
                            Throw cex
                        Catch aex As AggregateException
                            'logger.Error(aex)
                            Throw aex
                        Catch ex As Exception
                            'logger.Error(ex)
                            Throw ex
                        End Try
                    End Using
                End If
                ManageBulb(Color.LawnGreen)
#End Region
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
                errorCompleted = 0
                ManageBulb(Color.Yellow)
                If GetCheckBoxChecked_ThreadSafe(chkbIntradayCommodity) AndAlso commodityStockList IsNot Nothing AndAlso commodityStockList.Count > 0 Then
                    total = commodityStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Try
                            sw.Start()
                            For i As Integer = 0 To commodityStockList.Count - 1 Step Me.NumberOfParallelTask
                                canceller.Token.ThrowIfCancellationRequested()
                                Dim numberOfData As Integer = If(commodityStockList.Count - i > Me.NumberOfParallelTask, Me.NumberOfParallelTask, commodityStockList.Count - i)
                                Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                                tasks = commodityStockList.GetRange(i, numberOfData).Select(Async Function(x)
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
                                InstrumentCounter += numberOfData
                                If sw.Elapsed.TotalSeconds > 0 Then CountPerSecond = InstrumentCounter / sw.Elapsed.TotalSeconds
                                UpdateLabels()
                            Next
                            sw.Stop()
                        Catch cex As TaskCanceledException
                            'logger.Error(cex)
                            Throw cex
                        Catch aex As AggregateException
                            'logger.Error(aex)
                            Throw aex
                        Catch ex As Exception
                            'logger.Error(ex)
                            Throw ex
                        End Try
                    End Using
                End If
                ManageBulb(Color.LawnGreen)
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
                errorCompleted = 0
                ManageBulb(Color.Yellow)
                If GetCheckBoxChecked_ThreadSafe(chkbEODCommodity) AndAlso commodityStockList IsNot Nothing AndAlso commodityStockList.Count > 0 Then
                    total = commodityStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Try
                            sw.Start()
                            For i As Integer = 0 To commodityStockList.Count - 1 Step Me.NumberOfParallelTask
                                canceller.Token.ThrowIfCancellationRequested()
                                Dim numberOfData As Integer = If(commodityStockList.Count - i > Me.NumberOfParallelTask, Me.NumberOfParallelTask, commodityStockList.Count - i)
                                Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                                tasks = commodityStockList.GetRange(i, numberOfData).Select(Async Function(x)
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
                                InstrumentCounter += numberOfData
                                If sw.Elapsed.TotalSeconds > 0 Then CountPerSecond = InstrumentCounter / sw.Elapsed.TotalSeconds
                                UpdateLabels()
                            Next
                            sw.Stop()
                        Catch cex As TaskCanceledException
                            'logger.Error(cex)
                            Throw cex
                        Catch aex As AggregateException
                            'logger.Error(aex)
                            Throw aex
                        Catch ex As Exception
                            'logger.Error(ex)
                            Throw ex
                        End Try
                    End Using
                End If
                ManageBulb(Color.LawnGreen)
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
                errorCompleted = 0
                ManageBulb(Color.Yellow)
                If GetCheckBoxChecked_ThreadSafe(chkbIntradayCurrency) AndAlso currencyStockList IsNot Nothing AndAlso currencyStockList.Count > 0 Then
                    total = currencyStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Try
                            sw.Start()
                            For i As Integer = 0 To currencyStockList.Count - 1 Step Me.NumberOfParallelTask
                                canceller.Token.ThrowIfCancellationRequested()
                                Dim numberOfData As Integer = If(currencyStockList.Count - i > Me.NumberOfParallelTask, Me.NumberOfParallelTask, currencyStockList.Count - i)
                                Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                                tasks = currencyStockList.GetRange(i, numberOfData).Select(Async Function(x)
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
                                InstrumentCounter += numberOfData
                                If sw.Elapsed.TotalSeconds > 0 Then CountPerSecond = InstrumentCounter / sw.Elapsed.TotalSeconds
                                UpdateLabels()
                            Next
                            sw.Stop()
                        Catch cex As TaskCanceledException
                            'logger.Error(cex)
                            Throw cex
                        Catch aex As AggregateException
                            'logger.Error(aex)
                            Throw aex
                        Catch ex As Exception
                            'logger.Error(ex)
                            Throw ex
                        End Try
                    End Using
                End If
                ManageBulb(Color.LawnGreen)
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
                errorCompleted = 0
                ManageBulb(Color.Yellow)
                If GetCheckBoxChecked_ThreadSafe(chkbEODCurrency) AndAlso currencyStockList IsNot Nothing AndAlso currencyStockList.Count > 0 Then
                    total = currencyStockList.Count
                    UpdateLabels()
                    Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
                        AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
                        AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                        AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                        AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor
                        AddHandler sqlHlpr.FirstError, AddressOf OnFirstErrorWritingData

                        Try
                            sw.Start()
                            For i As Integer = 0 To currencyStockList.Count - 1 Step Me.NumberOfParallelTask
                                canceller.Token.ThrowIfCancellationRequested()
                                Dim numberOfData As Integer = If(currencyStockList.Count - i > Me.NumberOfParallelTask, Me.NumberOfParallelTask, currencyStockList.Count - i)
                                Dim tasks As IEnumerable(Of Task(Of Boolean)) = Nothing
                                tasks = currencyStockList.GetRange(i, numberOfData).Select(Async Function(x)
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
                                InstrumentCounter += numberOfData
                                If sw.Elapsed.TotalSeconds > 0 Then CountPerSecond = InstrumentCounter / sw.Elapsed.TotalSeconds
                                UpdateLabels()
                            Next
                            sw.Stop()
                        Catch cex As TaskCanceledException
                            'logger.Error(cex)
                            Throw cex
                        Catch aex As AggregateException
                            'logger.Error(aex)
                            Throw aex
                        Catch ex As Exception
                            'logger.Error(ex)
                            Throw ex
                        End Try
                    End Using
                End If
                ManageBulb(Color.LawnGreen)
#End Region
#End Region

                SendNotification(String.Format("{0} {1} : <<<<< SUCCESS >>>>> : Data Backup Process", Now.DayOfWeek, Now.ToString("dd-MMM-yyyy")), "All Stock Complete")
                SendNotification(String.Format("{0} {1} : <<<<< SUCCESS >>>>> : Data Backup Process", Now.DayOfWeek, Now.ToString("dd-MMM-yyyy")), "All Process Complete")
            Else
                Throw New ApplicationException("Zerodha login fail")
            End If
        Catch cex As OperationCanceledException
            MsgBox(cex.Message)
        Catch ex As Exception
            SendNotification(String.Format("{0} {1} : <<<<< ERROR >>>>> : Data Backup Process", Now.DayOfWeek, Now.ToString("dd-MMM-yyyy")), ex.ToString)
            MsgBox(ex.ToString)
        Finally
            SetObjectEnableDisable_ThreadSafe(btnStop, False)
            SetObjectEnableDisable_ThreadSafe(btnStart, True)
            SetObjectEnableDisable_ThreadSafe(grpHistoricalHitMode, True)
            SetObjectEnableDisable_ThreadSafe(nmrcParallelHit, True)

            SetObjectEnableDisable_ThreadSafe(chkbIntradayCash, True)
            SetObjectEnableDisable_ThreadSafe(chkbEODCash, True)
            SetObjectEnableDisable_ThreadSafe(chkbIntradayFuture, True)
            SetObjectEnableDisable_ThreadSafe(chkbEODFuture, True)
            SetObjectEnableDisable_ThreadSafe(chkbIntradayCommodity, True)
            SetObjectEnableDisable_ThreadSafe(chkbEODCommodity, True)
            SetObjectEnableDisable_ThreadSafe(chkbIntradayCurrency, True)
            SetObjectEnableDisable_ThreadSafe(chkbEODCurrency, True)
            SetObjectEnableDisable_ThreadSafe(chkbPositional, True)
            SetObjectEnableDisable_ThreadSafe(chkbOptionChain, True)

            SetLabelText_ThreadSafe(lblProgress, "Process Complete")
        End Try
    End Function

#Region "Main Task"
    Private _internetHitCount As Integer = 0
    Private Async Function ProcessData(ByVal currentDate As Date, ByVal instrument As InstrumentDetails, ByVal dbHlpr As MySQLDBHelper, ByVal zerodha As ZerodhaLogin, ByVal typeOfData As DataType) As Task
        Try
            canceller.Token.ThrowIfCancellationRequested()
            While _internetHitCount >= Me.NumberOfParallelTask
                Await Task.Delay(10, canceller.Token).ConfigureAwait(False)
                canceller.Token.ThrowIfCancellationRequested()
            End While
            Interlocked.Increment(gettingData)
            UpdateLabels()

            canceller.Token.ThrowIfCancellationRequested()
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
                            Case "MCX", "MCX-FUT"
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
                Dim historicalData As Dictionary(Of Date, Payload) = Await GetHistoricalDataAsync(instrument, startDate, endDate, typeOfData, zerodha)
                canceller.Token.ThrowIfCancellationRequested()
                Interlocked.Decrement(gettingData)
                UpdateLabels()

                If historicalData IsNot Nothing AndAlso historicalData.Count > 0 Then
                    Interlocked.Increment(writingData)
                    UpdateLabels()
                    Dim insertDataString As String = Nothing
                    Dim insertDataStringBuilder As New StringBuilder()

                    If typeOfData = DataType.EOD Then
                        insertDataStringBuilder.Append("INSERT INTO `").Append(tableName).Append("`") _
                                                            .Append("(`TradingSymbol`,") _
                                                            .Append("`Open`,") _
                                                            .Append("`Low`,") _
                                                            .Append("`High`,") _
                                                            .Append("`Close`,") _
                                                            .Append("`Volume`,") _
                                                            .Append("`OI`,") _
                                                            .Append("`SnapshotDate`,") _
                                                            .Append("`UpdateToDBTime`) ") _
                                                            .Append("VALUES ")
                    ElseIf typeOfData = DataType.Intraday Then
                        insertDataStringBuilder.Append("INSERT INTO `").Append(tableName).Append("`") _
                                                            .Append("(`TradingSymbol`,") _
                                                            .Append("`SnapshotDateTime`,") _
                                                            .Append("`Open`,") _
                                                            .Append("`Low`,") _
                                                            .Append("`High`,") _
                                                            .Append("`Close`,") _
                                                            .Append("`Volume`,") _
                                                            .Append("`SnapshotDate`,") _
                                                            .Append("`SnapshotTime`,") _
                                                            .Append("`UpdateToDBTime`) ") _
                                                            .Append("VALUES ")
                    End If


                    For Each runningPayload In historicalData.Values
                        canceller.Token.ThrowIfCancellationRequested()
                        If typeOfData = DataType.EOD Then
                            insertDataStringBuilder.Append("(") _
                                                    .Append("'").Append(runningPayload.TradingSymbol).Append("',") _
                                                    .Append(runningPayload.Open).Append(",") _
                                                    .Append(runningPayload.Low).Append(",") _
                                                    .Append(runningPayload.High).Append(",") _
                                                    .Append(runningPayload.Close).Append(",") _
                                                    .Append(runningPayload.Volume).Append(",") _
                                                    .Append(runningPayload.OI).Append(",") _
                                                    .Append("'").Append(runningPayload.PayloadDate.ToString("yyyy-MM-dd")).Append("',") _
                                                    .Append("TIMESTAMP(CURRENT_TIME)),")

                            'insertDataString = String.Format("{0},('{1}',{2},{3},{4},{5},{6},{7},'{8}',TIMESTAMP(CURRENT_TIME))",
                            '                                 insertDataString,
                            '                                 runningPayload.TradingSymbol,
                            '                                 runningPayload.Open,
                            '                                 runningPayload.Low,
                            '                                 runningPayload.High,
                            '                                 runningPayload.Close,
                            '                                 runningPayload.Volume,
                            '                                 runningPayload.OI,
                            '                                 runningPayload.PayloadDate.ToString("yyyy-MM-dd"))
                        ElseIf typeOfData = DataType.Intraday Then
                            insertDataStringBuilder.Append("(") _
                                                    .Append("'").Append(runningPayload.TradingSymbol).Append("',") _
                                                    .Append("'").Append(runningPayload.PayloadDate.ToString("yyyy-MM-dd HH:mm:ss")).Append("',") _
                                                    .Append(runningPayload.Open).Append(",") _
                                                    .Append(runningPayload.Low).Append(",") _
                                                    .Append(runningPayload.High).Append(",") _
                                                    .Append(runningPayload.Close).Append(",") _
                                                    .Append(runningPayload.Volume).Append(",") _
                                                    .Append("'").Append(runningPayload.PayloadDate.ToString("yyyy-MM-dd")).Append("',") _
                                                    .Append("'").Append(runningPayload.PayloadDate.ToString("HH:mm:ss")).Append("',") _
                                                    .Append("TIMESTAMP(CURRENT_TIME)),")

                            'insertDataString = String.Format("{0},('{1}','{2}',{3},{4},{5},{6},{7},'{8}','{9}',TIMESTAMP(CURRENT_TIME))",
                            '                                 insertDataString,
                            '                                 runningPayload.TradingSymbol,
                            '                                 runningPayload.PayloadDate.ToString("yyyy-MM-dd HH:mm:ss"),
                            '                                 runningPayload.Open,
                            '                                 runningPayload.Low,
                            '                                 runningPayload.High,
                            '                                 runningPayload.Close,
                            '                                 runningPayload.Volume,
                            '                                 runningPayload.PayloadDate.ToString("yyyy-MM-dd"),
                            '                                 runningPayload.PayloadDate.ToString("HH:mm:ss"))
                        End If
                    Next
                    If insertDataStringBuilder IsNot Nothing Then
                        insertDataStringBuilder.Remove(insertDataStringBuilder.Length - 1, 1)
                        Dim insertString As String = Nothing
                        If typeOfData = DataType.EOD Then
                            insertDataStringBuilder.Append(" ON DUPLICATE KEY UPDATE ") _
                                                            .Append("`TradingSymbol`=VALUES(`TradingSymbol`),") _
                                                            .Append("`Open`=VALUES(`Open`),") _
                                                            .Append("`Low`=VALUES(`Low`),") _
                                                            .Append("`High`=VALUES(`High`),") _
                                                            .Append("`Close`=VALUES(`Close`),") _
                                                            .Append("`Volume`=VALUES(`Volume`),") _
                                                            .Append("`OI`=VALUES(`OI`),") _
                                                            .Append("`SnapshotDate`=VALUES(`SnapshotDate`),") _
                                                            .Append("`UpdateToDBTime`=VALUES(`UpdateToDBTime`);")

                            'insertString = String.Format("INSERT INTO `{0}` 
                            '                                (`TradingSymbol`,
                            '                                `Open`,
                            '                                `Low`,
                            '                                `High`,
                            '                                `Close`,
                            '                                `Volume`,
                            '                                `OI`,
                            '                                `SnapshotDate`,
                            '                                `UpdateToDBTime`) 
                            '                                VALUES {1} 
                            '                                ON DUPLICATE KEY UPDATE 
                            '                                `TradingSymbol`=VALUES(`TradingSymbol`), 
                            '                                `Open`=VALUES(`Open`), `Low`=VALUES(`Low`), 
                            '                                `High`=VALUES(`High`), 
                            '                                `Close`=VALUES(`Close`), 
                            '                                `Volume`=VALUES(`Volume`), 
                            '                                `OI`=VALUES(`OI`), 
                            '                                `SnapshotDate`=VALUES(`SnapshotDate`), 
                            '                                `UpdateToDBTime`=VALUES(`UpdateToDBTime`);",
                            '                             tableName, insertDataString.Substring(1))
                        ElseIf typeOfData = DataType.Intraday Then
                            insertDataStringBuilder.Append(" ON DUPLICATE KEY UPDATE ") _
                                                            .Append("`TradingSymbol`=VALUES(`TradingSymbol`),") _
                                                            .Append("`SnapshotDateTime`=VALUES(`SnapshotDateTime`),") _
                                                            .Append("`Open`=VALUES(`Open`),") _
                                                            .Append("`Low`=VALUES(`Low`),") _
                                                            .Append("`High`=VALUES(`High`),") _
                                                            .Append("`Close`=VALUES(`Close`),") _
                                                            .Append("`Volume`=VALUES(`Volume`),") _
                                                            .Append("`SnapshotDate`=VALUES(`SnapshotDate`),") _
                                                            .Append("`SnapshotTime`=VALUES(`SnapshotTime`),") _
                                                            .Append("`UpdateToDBTime`=VALUES(`UpdateToDBTime`);")


                            'insertString = String.Format("INSERT INTO `{0}` 
                            '                                (`TradingSymbol`,
                            '                                `SnapshotDateTime`,
                            '                                `Open`,
                            '                                `Low`,
                            '                                `High`,
                            '                                `Close`,
                            '                                `Volume`,
                            '                                `SnapshotDate`,
                            '                                `SnapshotTime`,
                            '                                `UpdateToDBTime`)
                            '                                VALUES {1}
                            '                                ON DUPLICATE KEY UPDATE
                            '                                `TradingSymbol`=VALUES(`TradingSymbol`),
                            '                                `SnapshotDateTime`=VALUES(`SnapshotDateTime`),
                            '                                `Open`=VALUES(`Open`),
                            '                                `Low`=VALUES(`Low`),
                            '                                `High`=VALUES(`High`),
                            '                                `Close`=VALUES(`Close`),
                            '                                `Volume`=VALUES(`Volume`),
                            '                                `SnapshotDate`=VALUES(`SnapshotDate`),
                            '                                `SnapshotTime`=VALUES(`SnapshotTime`),
                            '                                `UpdateToDBTime`=VALUES(`UpdateToDBTime`);",
                            '                             tableName, insertDataString.Substring(1))
                        End If
                        insertString = insertDataStringBuilder.ToString
                        canceller.Token.ThrowIfCancellationRequested()
                        Dim numberOfData As Integer = Await dbHlpr.RunUpdateAsync(insertString).ConfigureAwait(False)
                        Interlocked.Decrement(writingData)
                        Interlocked.Increment(completed)
                        UpdateLabels()
                    End If
                Else
                    UpdateErrorList(instrument, typeOfData, "No Data Found")
                    Interlocked.Increment(errorGettingData)
                    Interlocked.Increment(errorCompleted)
                    UpdateLabels()
                End If
            Else
                Throw New ApplicationException(String.Format("Table name not found: {0}, {1}, {2}", instrument.TradingSymbol, instrument.Segment, instrument.Exchange))
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Interlocked.Decrement(_internetHitCount)
            UpdateLabels()
        End Try
    End Function
#End Region

#Region "Option Chain Task"
    Private _optionChainHitCount As Integer = 0
    Private Async Function ProcessOptionChainData(ByVal instrument As InstrumentDetails, ByVal dbHlpr As MySQLDBHelper) As Task
        Try
            canceller.Token.ThrowIfCancellationRequested()
            While _optionChainHitCount >= Me.NumberOfParallelTask
                Await Task.Delay(10, canceller.Token).ConfigureAwait(False)
                canceller.Token.ThrowIfCancellationRequested()
            End While
            Interlocked.Increment(gettingData)
            UpdateLabels()

            canceller.Token.ThrowIfCancellationRequested()
            Await Task.Delay(1, canceller.Token).ConfigureAwait(False)
            Interlocked.Increment(_optionChainHitCount)

            Dim NSEIDXOptionChainURL As String = "https://www.nseindia.com/live_market/dynaContent/live_watch/option_chain/optionKeys.jsp?symbolCode=-0&symbol={0}&symbol={0}&instrument=OPTIDX&date=-&segmentLink=17&segmentLink=17"
            Dim NSESTKOptionChainURL As String = "https://www.nseindia.com/live_market/dynaContent/live_watch/option_chain/optionKeys.jsp?symbolCode=-0&symbol={0}&symbol={0}&instrument=OPTSTK&date=-&segmentLink=17&segmentLink=17"
            Dim openPositionDataURL As String = Nothing
            If instrument.TradingSymbol = "NIFTY" OrElse instrument.TradingSymbol = "BANKNIFTY" OrElse instrument.TradingSymbol = "NIFTYIT" Then
                openPositionDataURL = String.Format(NSEIDXOptionChainURL, instrument.TradingSymbol)
            Else
                Dim instrumentName As String = instrument.TradingSymbol
                If instrumentName.Contains("&") Then instrumentName = instrumentName.Replace("&", "%26")
                openPositionDataURL = String.Format(NSESTKOptionChainURL, instrumentName)
            End If
            Dim outputResponse As HtmlDocument = Nothing
            Dim proxyToBeUsed As HttpProxy = Nothing
            Using browser As New HttpBrowser(proxyToBeUsed, Net.DecompressionMethods.GZip, New TimeSpan(0, 1, 0), canceller)
                AddHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                AddHandler browser.Heartbeat, AddressOf OnHeartbeat
                AddHandler browser.WaitingFor, AddressOf OnWaitingFor
                AddHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus

                browser.KeepAlive = True
                Dim headersToBeSent As New Dictionary(Of String, String)
                headersToBeSent.Add("Host", "www.nseindia.com")
                headersToBeSent.Add("Upgrade-Insecure-Requests", "1")
                headersToBeSent.Add("Sec-Fetch-Mode", "navigate")
                headersToBeSent.Add("Sec-Fetch-Site", "none")

                Dim l As Tuple(Of Uri, Object) = Await browser.NonPOSTRequestAsync(openPositionDataURL,
                                                                                    HttpMethod.Get,
                                                                                    Nothing,
                                                                                    False,
                                                                                    headersToBeSent,
                                                                                    True,
                                                                                    "text/html").ConfigureAwait(False)
                If l IsNot Nothing AndAlso l.Item2 IsNot Nothing Then
                    outputResponse = l.Item2
                End If
                RemoveHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                RemoveHandler browser.Heartbeat, AddressOf OnHeartbeat
                RemoveHandler browser.WaitingFor, AddressOf OnWaitingFor
                RemoveHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
            End Using

            Interlocked.Decrement(gettingData)
            UpdateLabels()

            If outputResponse IsNot Nothing AndAlso outputResponse.DocumentNode IsNot Nothing Then
                OnHeartbeat("Extracting Option Chain from HTML")
                Dim calls As List(Of OptionChain) = Nothing
                Dim puts As List(Of OptionChain) = Nothing

                Dim optionDate As Date = Now
                If outputResponse.DocumentNode.SelectNodes("//div[@id='wrapper_btm']") IsNot Nothing Then
                    For Each div As HtmlNode In outputResponse.DocumentNode.SelectNodes("//div[@id='wrapper_btm']")
                        If div IsNot Nothing AndAlso div.SelectNodes("table") IsNot Nothing AndAlso div.SelectNodes("table").Count > 0 Then
                            Dim table As HtmlNode = div.SelectNodes("table")(0)
                            If table IsNot Nothing And table.SelectNodes("tr") IsNot Nothing AndAlso table.SelectNodes("tr").Count > 0 Then
                                Dim tr As HtmlNode = table.SelectNodes("tr")(0)
                                If tr IsNot Nothing And tr.SelectNodes("td") IsNot Nothing AndAlso tr.SelectNodes("td").Count > 1 Then
                                    Dim td As HtmlNode = tr.SelectNodes("td")(1)
                                    If td IsNot Nothing And td.SelectNodes("div") IsNot Nothing AndAlso td.SelectNodes("div").Count > 0 Then
                                        Dim div2 As HtmlNode = td.SelectNodes("div")(0)
                                        If div2 IsNot Nothing And div2.SelectNodes("span") IsNot Nothing AndAlso div2.SelectNodes("span").Count > 1 Then
                                            Dim span As HtmlNode = div2.SelectNodes("span")(1)
                                            If span IsNot Nothing AndAlso span.InnerText IsNot Nothing AndAlso span.InnerText <> "" Then
                                                Dim dateText As String = Utilities.Strings.GetTextBetween("As on", "IST", span.InnerText).Trim
                                                optionDate = Convert.ToDateTime(dateText)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If

                If outputResponse.DocumentNode.SelectNodes("//table[@id='octable']") IsNot Nothing Then
                    For Each table As HtmlNode In outputResponse.DocumentNode.SelectNodes("//table[@id='octable']")
                        canceller.Token.ThrowIfCancellationRequested()
                        If table IsNot Nothing AndAlso table.SelectNodes("tr") IsNot Nothing Then
                            For Each row As HtmlNode In table.SelectNodes("tr")
                                canceller.Token.ThrowIfCancellationRequested()
                                If row IsNot Nothing AndAlso row.SelectNodes("td") IsNot Nothing Then
                                    Dim callData As OptionChain = Nothing
                                    Dim putData As OptionChain = Nothing
                                    Dim counter As Integer = 0
                                    For Each cell As HtmlNode In row.SelectNodes("td")
                                        canceller.Token.ThrowIfCancellationRequested()
                                        If cell IsNot Nothing AndAlso cell.InnerText IsNot Nothing AndAlso cell.InnerText <> "" Then
                                            If cell.InnerText.Trim = "Total" Then
                                                Exit For
                                            End If
                                            If callData Is Nothing Then callData = New OptionChain
                                            If putData Is Nothing Then putData = New OptionChain
                                            counter += 1
                                            If counter = 1 Then
                                                callData.OI = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 2 Then
                                                callData.ChangeInOI = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 3 Then
                                                callData.Volume = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 4 Then
                                                callData.IV = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 5 Then
                                                callData.LTP = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 6 Then
                                                callData.NetChange = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 7 Then
                                                callData.BidQuantity = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 8 Then
                                                callData.BidPrice = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 9 Then
                                                callData.AskPrice = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 10 Then
                                                callData.AskQuantity = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 11 Then
                                                callData.StrikePrice = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                                putData.StrikePrice = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 12 Then
                                                putData.BidQuantity = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 13 Then
                                                putData.BidPrice = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 14 Then
                                                putData.AskPrice = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 15 Then
                                                putData.AskQuantity = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 16 Then
                                                putData.NetChange = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 17 Then
                                                putData.LTP = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 18 Then
                                                putData.IV = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 19 Then
                                                putData.Volume = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 20 Then
                                                putData.ChangeInOI = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            ElseIf counter = 21 Then
                                                putData.OI = If(cell.InnerText.Trim = "-", Decimal.MinValue, cell.InnerText.Trim)
                                            End If
                                        End If
                                    Next
                                    If callData IsNot Nothing Then
                                        If calls Is Nothing Then calls = New List(Of OptionChain)
                                        calls.Add(callData)
                                    End If
                                    If putData IsNot Nothing Then
                                        If puts Is Nothing Then puts = New List(Of OptionChain)
                                        puts.Add(putData)
                                    End If
                                End If
                            Next
                        End If
                    Next
                End If
                canceller.Token.ThrowIfCancellationRequested()

                OnHeartbeat("Creating table of option chain data")
                canceller.Token.ThrowIfCancellationRequested()
                If calls IsNot Nothing AndAlso calls.Count > 0 AndAlso puts IsNot Nothing AndAlso puts.Count > 0 AndAlso calls.Count = puts.Count Then
                    canceller.Token.ThrowIfCancellationRequested()
                    Interlocked.Increment(writingData)
                    UpdateLabels()

                    Dim insertDataString As String = Nothing
                    For Each runningCall In calls
                        canceller.Token.ThrowIfCancellationRequested()
                        insertDataString = String.Format("{0},('{1}','{2}',{3},'{4}',{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},TIMESTAMP(CURRENT_TIME))",
                                                                        insertDataString,
                                                                        optionDate.ToString("yyyy-MM-dd"),
                                                                        instrument.TradingSymbol.ToUpper,
                                                                        runningCall.StrikePrice,
                                                                        "CE",
                                                                        If(runningCall.OI <> Decimal.MinValue, runningCall.OI, Nothing),
                                                                        If(runningCall.ChangeInOI <> Decimal.MinValue, runningCall.ChangeInOI, Nothing),
                                                                        If(runningCall.Volume <> Decimal.MinValue, runningCall.Volume, Nothing),
                                                                        If(runningCall.IV <> Decimal.MinValue, runningCall.IV, Nothing),
                                                                        If(runningCall.LTP <> Decimal.MinValue, runningCall.LTP, Nothing),
                                                                        If(runningCall.NetChange <> Decimal.MinValue, runningCall.NetChange, Nothing),
                                                                        If(runningCall.BidQuantity <> Decimal.MinValue, runningCall.BidQuantity, Nothing),
                                                                        If(runningCall.BidPrice <> Decimal.MinValue, runningCall.BidPrice, Nothing),
                                                                        If(runningCall.AskPrice <> Decimal.MinValue, runningCall.AskPrice, Nothing),
                                                                        If(runningCall.AskQuantity <> Decimal.MinValue, runningCall.AskQuantity, Nothing))
                    Next
                    For Each runningPut In puts
                        canceller.Token.ThrowIfCancellationRequested()
                        insertDataString = String.Format("{0},('{1}','{2}',{3},'{4}',{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},TIMESTAMP(CURRENT_TIME))",
                                                                        insertDataString,
                                                                        optionDate.ToString("yyyy-MM-dd"),
                                                                        instrument.TradingSymbol.ToUpper,
                                                                        runningPut.StrikePrice,
                                                                        "PE",
                                                                        If(runningPut.OI <> Decimal.MinValue, runningPut.OI, Nothing),
                                                                        If(runningPut.ChangeInOI <> Decimal.MinValue, runningPut.ChangeInOI, Nothing),
                                                                        If(runningPut.Volume <> Decimal.MinValue, runningPut.Volume, Nothing),
                                                                        If(runningPut.IV <> Decimal.MinValue, runningPut.IV, Nothing),
                                                                        If(runningPut.LTP <> Decimal.MinValue, runningPut.LTP, Nothing),
                                                                        If(runningPut.NetChange <> Decimal.MinValue, runningPut.NetChange, Nothing),
                                                                        If(runningPut.BidQuantity <> Decimal.MinValue, runningPut.BidQuantity, Nothing),
                                                                        If(runningPut.BidPrice <> Decimal.MinValue, runningPut.BidPrice, Nothing),
                                                                        If(runningPut.AskPrice <> Decimal.MinValue, runningPut.AskPrice, Nothing),
                                                                        If(runningPut.AskQuantity <> Decimal.MinValue, runningPut.AskQuantity, Nothing))
                    Next

                    If insertDataString IsNot Nothing Then
                        Dim insertString As String = String.Format("INSERT INTO `nse_option_chain` 
                                                                                (`SnapshotDate`,
                                                                                `InstrumentName`,
                                                                                `StrikePrice`,
                                                                                `CallPut`,
                                                                                `OI`,
                                                                                `ChangeInOI`,
                                                                                `Volume`,
                                                                                `IV`,
                                                                                `LTP`,
                                                                                `NetChange`,
                                                                                `BidQuantity`,
                                                                                `BidPrice`,
                                                                                `AskPrice`,
                                                                                `AskQuantity`,
                                                                                `UpdateToDBTime`) 
                                                                                VALUES {0} 
                                                                                ON DUPLICATE KEY UPDATE 
                                                                                `SnapshotDate`=VALUES(`SnapshotDate`),
                                                                                `InstrumentName`=VALUES(`InstrumentName`),
                                                                                `StrikePrice`=VALUES(`StrikePrice`),
                                                                                `CallPut`=VALUES(`CallPut`),
                                                                                `OI`=VALUES(`OI`),
                                                                                `ChangeInOI`=VALUES(`ChangeInOI`),
                                                                                `Volume`=VALUES(`Volume`),
                                                                                `IV`=VALUES(`IV`),
                                                                                `LTP`=VALUES(`LTP`),
                                                                                `NetChange`=VALUES(`NetChange`),
                                                                                `BidQuantity`=VALUES(`BidQuantity`),
                                                                                `BidPrice`=VALUES(`BidPrice`),
                                                                                `AskPrice`=VALUES(`AskPrice`),
                                                                                `AskQuantity`=VALUES(`AskQuantity`),
                                                                                `UpdateToDBTime`=VALUES(`UpdateToDBTime`);", insertDataString.Substring(1))

                        canceller.Token.ThrowIfCancellationRequested()
                        Dim numberOfdata As Integer = Await dbHlpr.RunUpdateAsync(insertString).ConfigureAwait(False)
                        Interlocked.Decrement(writingData)
                        Interlocked.Increment(completed)
                        UpdateLabels()
                    End If
                    canceller.Token.ThrowIfCancellationRequested()
                Else
                    UpdateErrorList(instrument, DataType.EOD, "No Data Found")
                    Interlocked.Increment(errorGettingData)
                    Interlocked.Increment(errorCompleted)
                    UpdateLabels()
                End If
                canceller.Token.ThrowIfCancellationRequested()
            Else
                UpdateErrorList(instrument, DataType.EOD, "No Data Found")
                Interlocked.Increment(errorGettingData)
                Interlocked.Increment(errorCompleted)
                UpdateLabels()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Interlocked.Decrement(_optionChainHitCount)
            UpdateLabels()
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

            Dim queryString As String = "SELECT DISTINCT(`INSTRUMENT_TOKEN`),`TRADING_SYMBOL`,`SEGMENT`,`EXCHANGE`,`EXPIRY` 
                                        FROM `{0}`
                                        WHERE `AS_ON_DATE`=(SELECT MAX(`AS_ON_DATE`) FROM `{0}`)"
            queryString = String.Format(queryString, tableName)

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
                        If Not IsDBNull(dt.Rows(i).Item(4)) Then
                            runningInstrument.Expiry = dt.Rows(i).Item(4)
                        Else
                            runningInstrument.Expiry = Date.MaxValue
                        End If
                        runningInstrument.InstrumentType = instrumentType

                        Dim pattern As String = "([0-9][0-9]JAN)|([0-9][0-9]FEB)|([0-9][0-9]MAR)|([0-9][0-9]APR)|([0-9][0-9]MAY)|([0-9][0-9]JUN)|([0-9][0-9]JUL)|([0-9][0-9]AUG)|([0-9][0-9]SEP)|([0-9][0-9]OCT)|([0-9][0-9]NOV)|([0-9][0-9]DEC)"
                        If Regex.Matches(runningInstrument.TradingSymbol, pattern).Count <= 1 Then
                            If ret Is Nothing Then ret = New List(Of InstrumentDetails)
                            ret.Add(runningInstrument)
                        Else
                            Console.WriteLine(String.Format("Instrument Neglected for {0}: {1}", instrumentType.ToString, runningInstrument.TradingSymbol))
                        End If
                        'If i >= 99 Then Exit For
                    End If
                Next
            End If
        End Using
        Return ret
    End Function
    Private Async Function GetAllOptionChainStockListAsync() As Task(Of List(Of InstrumentDetails))
        Dim ret As List(Of InstrumentDetails) = Nothing
        Dim selectString As String = "SELECT `TRADING_SYMBOL` FROM `active_instruments_futures` WHERE `SEGMENT`='NFO-FUT' AND `AS_ON_DATE`=(SELECT MAX(`AS_ON_DATE`) FROM `active_instruments_futures`)"
        Using sqlHlpr As New MySQLDBHelper(My.Settings.ServerName, "local_stock", "3306", "rio", "speech123", canceller)
            AddHandler sqlHlpr.Heartbeat, AddressOf OnHeartbeat
            AddHandler sqlHlpr.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
            AddHandler sqlHlpr.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
            AddHandler sqlHlpr.WaitingFor, AddressOf OnWaitingFor

            Dim dt As DataTable = Await sqlHlpr.RunSelectAsync(selectString).ConfigureAwait(False)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim stockList As List(Of String) = Nothing
                For i = 0 To dt.Rows.Count - 1
                    Dim tradingSymbol As String = dt.Rows(i).Item(0).ToString.ToUpper
                    Dim instrumentName As String = Nothing
                    If tradingSymbol.Contains("FUT") Then
                        instrumentName = tradingSymbol.Remove(tradingSymbol.Count - 8)
                    Else
                        instrumentName = tradingSymbol
                    End If

                    Dim pattern As String = "([0-9][0-9]JAN)|([0-9][0-9]FEB)|([0-9][0-9]MAR)|([0-9][0-9]APR)|([0-9][0-9]MAY)|([0-9][0-9]JUN)|([0-9][0-9]JUL)|([0-9][0-9]AUG)|([0-9][0-9]SEP)|([0-9][0-9]OCT)|([0-9][0-9]NOV)|([0-9][0-9]DEC)"
                    If Regex.Matches(tradingSymbol, pattern).Count <= 1 Then
                        If stockList Is Nothing Then stockList = New List(Of String)
                        If Not stockList.Contains(instrumentName) Then stockList.Add(instrumentName)
                    Else
                        Console.WriteLine(String.Format("Instrument Neglected for option chain: {0}", tradingSymbol))
                    End If
                Next

                If stockList IsNot Nothing AndAlso stockList.Count > 0 Then
                    For Each runningStock In stockList
                        If ret Is Nothing Then ret = New List(Of InstrumentDetails)
                        ret.Add(New InstrumentDetails With {.TradingSymbol = runningStock, .InstrumentType = InstrumentDetails.TypeOfInstrument.OptionChain})
                    Next
                End If
            End If
        End Using
        Return ret
    End Function
    Private Async Function GetHistoricalDataAsync(ByVal instrument As InstrumentDetails, ByVal startDate As Date, ByVal endDate As Date, ByVal typeOfData As DataType, ByVal zerodhaDetails As ZerodhaLogin) As Task(Of Dictionary(Of Date, Payload))
        Dim ret As Dictionary(Of Date, Payload) = Nothing
        Dim AWSZerodhaEODHistoricalURL As String = "https://kitecharts-aws.zerodha.com/api/chart/{0}/day?oi=1&api_key=kitefront&access_token=K&from={1}&to={2}"
        Dim AWSZerodhaIntradayHistoricalURL As String = "https://kitecharts-aws.zerodha.com/api/chart/{0}/minute?oi=1&api_key=kitefront&access_token=K&from={1}&to={2}"
        Dim ZerodhaEODHistoricalURL As String = "https://kite.zerodha.com/oms/instruments/historical/{0}/day?&oi=1&from={1}&to={2}"
        Dim ZerodhaIntradayHistoricalURL As String = "https://kite.zerodha.com/oms/instruments/historical/{0}/minute?oi=1&from={1}&to={2}"
        Dim ZerodhaHistoricalURL As String = Nothing
        Select Case typeOfData
            Case DataType.EOD
                If GetRadioButtonChecked_ThreadSafe(rdbWithAPI) Then
                    ZerodhaHistoricalURL = ZerodhaEODHistoricalURL
                ElseIf GetRadioButtonChecked_ThreadSafe(rdbWithoutAPI) Then
                    ZerodhaHistoricalURL = AWSZerodhaEODHistoricalURL
                End If
            Case DataType.Intraday
                If GetRadioButtonChecked_ThreadSafe(rdbWithAPI) Then
                    ZerodhaHistoricalURL = ZerodhaIntradayHistoricalURL
                ElseIf GetRadioButtonChecked_ThreadSafe(rdbWithoutAPI) Then
                    ZerodhaHistoricalURL = AWSZerodhaIntradayHistoricalURL
                End If
        End Select
        If ZerodhaHistoricalURL IsNot Nothing AndAlso instrument.InstrumentToken IsNot Nothing AndAlso instrument.InstrumentToken <> "" Then
            Dim historicalDataURL As String = String.Format(ZerodhaHistoricalURL, instrument.InstrumentToken, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"))
            OnHeartbeat(String.Format("Fetching historical Data: {0}", historicalDataURL))
            Dim historicalCandlesJSONDict As Dictionary(Of String, Object) = Nothing

            ServicePointManager.Expect100Continue = False
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            ServicePointManager.ServerCertificateValidationCallback = Function(s, Ca, CaC, sslPE)
                                                                          Return True
                                                                      End Function

            If GetRadioButtonChecked_ThreadSafe(rdbWithAPI) Then
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

                    Try
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
                    Catch ex As Exception
                        If ex.Message.Contains("400 (Bad Request)") Then
                            If instrument.Expiry.Date >= Now.Date Then
                                Throw ex
                            Else
                                UpdateErrorList(instrument, typeOfData, "Instrument expired")
                            End If
                        Else
                            Throw ex
                        End If
                    End Try

                    RemoveHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    RemoveHandler browser.Heartbeat, AddressOf OnHeartbeat
                    RemoveHandler browser.WaitingFor, AddressOf OnWaitingFor
                    RemoveHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                    RemoveHandler browser.FirstError, AddressOf OnFirstErrorGettingData
                End Using
            ElseIf GetRadioButtonChecked_ThreadSafe(rdbWithoutAPI) Then
                Dim proxyToBeUsed As HttpProxy = Nothing
                Using browser As New HttpBrowser(proxyToBeUsed, Net.DecompressionMethods.GZip, New TimeSpan(0, 1, 0), canceller)
                    AddHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    AddHandler browser.Heartbeat, AddressOf OnHeartbeat
                    AddHandler browser.WaitingFor, AddressOf OnWaitingFor
                    AddHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                    AddHandler browser.FirstError, AddressOf OnFirstErrorGettingData

                    Try
                        canceller.Token.ThrowIfCancellationRequested()
                        Dim l As Tuple(Of Uri, Object) = Await browser.NonPOSTRequestAsync(historicalDataURL,
                                                                                        HttpMethod.Get,
                                                                                        Nothing,
                                                                                        True,
                                                                                        Nothing,
                                                                                        True,
                                                                                        "application/json").ConfigureAwait(False)
                        canceller.Token.ThrowIfCancellationRequested()
                        If l IsNot Nothing AndAlso l.Item2 IsNot Nothing Then
                            historicalCandlesJSONDict = l.Item2
                        End If
                    Catch ex As Exception
                        If ex.Message.Contains("400 (Bad Request)") Then
                            If instrument.Expiry.Date >= Now.Date Then
                                Throw ex
                            Else
                                UpdateErrorList(instrument, typeOfData, "Instrument expired")
                            End If
                        Else
                            Throw ex
                        End If
                    End Try

                    RemoveHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    RemoveHandler browser.Heartbeat, AddressOf OnHeartbeat
                    RemoveHandler browser.WaitingFor, AddressOf OnWaitingFor
                    RemoveHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                    RemoveHandler browser.FirstError, AddressOf OnFirstErrorGettingData
                End Using
            End If

            If historicalCandlesJSONDict IsNot Nothing AndAlso historicalCandlesJSONDict.Count > 0 AndAlso
                historicalCandlesJSONDict.ContainsKey("data") Then
                Dim historicalCandlesDict As Dictionary(Of String, Object) = historicalCandlesJSONDict("data")
                If historicalCandlesDict.ContainsKey("candles") AndAlso historicalCandlesDict("candles").count > 0 Then
                    Dim historicalCandles As ArrayList = historicalCandlesDict("candles")
                    OnHeartbeat(String.Format("Generating Payload for {0}", instrument.TradingSymbol))
                    Dim previousPayload As Payload = Nothing
                    For Each historicalCandle As ArrayList In historicalCandles
                        canceller.Token.ThrowIfCancellationRequested()
                        Dim runningSnapshotTime As Date = Utilities.Time.GetDateTimeTillMinutes(historicalCandle(0))

                        Dim runningPayload As Payload = New Payload
                        With runningPayload
                            .PayloadDate = Utilities.Time.GetDateTimeTillMinutes(historicalCandle(0))
                            .TradingSymbol = instrument.TradingSymbol
                            .Open = historicalCandle(1)
                            .High = historicalCandle(2)
                            .Low = historicalCandle(3)
                            .Close = historicalCandle(4)
                            .Volume = historicalCandle(5)
                            If historicalCandle.Count > 6 Then
                                .OI = historicalCandle(6)
                            End If
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

    Private Sub SendNotification(ByVal title As String, ByVal message As String)
        Using sndr As New Utilities.Notification.Gmail(canceller, "ganeshathelifechanger@gmail.com", "speech123", "shortwire@gmail.com", "kallol@algo2trade.com", "indibar@algo2trade.com")
            AddHandler sndr.Heartbeat, AddressOf OnHeartbeat
            sndr.SendMailAsync(title, message)
        End Using
        Using sndr As New Utilities.Notification.Telegram("700121864:AAHjes45V0kEPBDLIfnZzsatH5NhRwIjciw", "-326362481", canceller)
            AddHandler sndr.Heartbeat, AddressOf OnHeartbeat
            sndr.SendMessageAsync(message)
        End Using
    End Sub

    Private Sub lblIntradayCashErrorGettingData_Click(sender As Object, e As EventArgs) Handles lblIntradayCashErrorGettingData.Click
        Dim newForm As New frmErrorList(intradayCashErrorList)
        newForm.Show()
    End Sub

    Private Sub lblEODCashErrorGettingData_Click(sender As Object, e As EventArgs) Handles lblEODCashErrorGettingData.Click
        Dim newForm As New frmErrorList(eodCashErrorList)
        newForm.Show()
    End Sub

    Private Sub lblIntradayFutureErrorGettingData_Click(sender As Object, e As EventArgs) Handles lblIntradayFutureErrorGettingData.Click
        Dim newForm As New frmErrorList(intradayFutureErrorList)
        newForm.Show()
    End Sub

    Private Sub lblEODFutureErrorGettingData_Click(sender As Object, e As EventArgs) Handles lblEODFutureErrorGettingData.Click
        Dim newForm As New frmErrorList(eodFutureErrorList)
        newForm.Show()
    End Sub

    Private Sub lblIntradayCommodityErrorGettingData_Click(sender As Object, e As EventArgs) Handles lblIntradayCommodityErrorGettingData.Click
        Dim newForm As New frmErrorList(intradayCommodityErrorList)
        newForm.Show()
    End Sub

    Private Sub lblEODCommodityErrorGettingData_Click(sender As Object, e As EventArgs) Handles lblEODCommodityErrorGettingData.Click
        Dim newForm As New frmErrorList(eodCommodityErrorList)
        newForm.Show()
    End Sub

    Private Sub lblIntradayCurrencyErrorGettingData_Click(sender As Object, e As EventArgs) Handles lblIntradayCurrencyErrorGettingData.Click
        Dim newForm As New frmErrorList(intradayCurrencyErrorList)
        newForm.Show()
    End Sub

    Private Sub lblEODCurrencyErrorGettingData_Click(sender As Object, e As EventArgs) Handles lblEODCurrencyErrorGettingData.Click
        Dim newForm As New frmErrorList(eodCurrencyErrorList)
        newForm.Show()
    End Sub

    Private Sub lblPstnlErrorGettingData_Click(sender As Object, e As EventArgs) Handles lblPstnlErrorGettingData.Click
        Dim newForm As New frmErrorList(positionalErrorList)
        newForm.Show()
    End Sub

    Private Sub lblOptnChnErrorGettingData_Click(sender As Object, e As EventArgs) Handles lblOptnChnErrorGettingData.Click
        Dim newForm As New frmErrorList(optionChainErrorList)
        newForm.Show()
    End Sub
End Class
