Public Class frmErrorList

    Private ReadOnly _errorList As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails) = Nothing
    Public Sub New(ByVal listOfInstrument As Concurrent.ConcurrentDictionary(Of String, InstrumentDetails))
        InitializeComponent()
        _errorList = listOfInstrument
    End Sub

    Private Sub frmErrorList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _errorList IsNot Nothing AndAlso _errorList.Count > 0 Then
            Me.Text = String.Format("Error List - Count:{0}", _errorList.Count)

            Dim dt As New DataTable
            dt.Columns.Add("Trading Symbol")
            dt.Columns.Add("Instrument Token")
            dt.Columns.Add("Segment")
            dt.Columns.Add("Exchange")
            dt.Columns.Add("Expiry")
            dt.Columns.Add("ErrorMessage")
            For Each instrument In _errorList
                Dim row As DataRow = dt.NewRow
                row("Trading Symbol") = instrument.Value.TradingSymbol
                row("Instrument Token") = instrument.Value.InstrumentToken
                row("Segment") = instrument.Value.Segment
                row("Exchange") = instrument.Value.Exchange
                row("Expiry") = instrument.Value.Expiry.ToString("dd-MM-yyyy")
                row("ErrorMessage") = instrument.Value.ErrorMessage
                dt.Rows.Add(row)
            Next
            dgvMain.DataSource = dt
            dgvMain.Refresh()
        End If
    End Sub
End Class