<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.grpBoxPositional = New System.Windows.Forms.GroupBox()
        Me.lblPstnlErrorWritingData = New System.Windows.Forms.Label()
        Me.lblPstnlWritingData = New System.Windows.Forms.Label()
        Me.lblPstnlQueue = New System.Windows.Forms.Label()
        Me.lblPstnlCompleted = New System.Windows.Forms.Label()
        Me.lblPstnlErrorGettingData = New System.Windows.Forms.Label()
        Me.lblPstnlGettingData = New System.Windows.Forms.Label()
        Me.lblPstnlTotal = New System.Windows.Forms.Label()
        Me.grpBoxIntradayCash = New System.Windows.Forms.GroupBox()
        Me.lblIntradayCashErrorWritingData = New System.Windows.Forms.Label()
        Me.lblIntradayCashWritingData = New System.Windows.Forms.Label()
        Me.lblIntradayCashQueue = New System.Windows.Forms.Label()
        Me.lblIntradayCashCompleted = New System.Windows.Forms.Label()
        Me.lblIntradayCashErrorGettingData = New System.Windows.Forms.Label()
        Me.lblIntradayCashGettingData = New System.Windows.Forms.Label()
        Me.lblIntradayCashTotal = New System.Windows.Forms.Label()
        Me.grpBoxIntradayFuture = New System.Windows.Forms.GroupBox()
        Me.lblIntradayFutureErrorWritingData = New System.Windows.Forms.Label()
        Me.lblIntradayFutureWritingData = New System.Windows.Forms.Label()
        Me.lblIntradayFutureQueue = New System.Windows.Forms.Label()
        Me.lblIntradayFutureCompleted = New System.Windows.Forms.Label()
        Me.lblIntradayFutureErrorGettingData = New System.Windows.Forms.Label()
        Me.lblIntradayFutureGettingData = New System.Windows.Forms.Label()
        Me.lblIntradayFutureTotal = New System.Windows.Forms.Label()
        Me.grpBoxIntradayCurrency = New System.Windows.Forms.GroupBox()
        Me.lblIntradayCurrencyErrorWritingData = New System.Windows.Forms.Label()
        Me.lblIntradayCurrencyWritingData = New System.Windows.Forms.Label()
        Me.lblIntradayCurrencyQueue = New System.Windows.Forms.Label()
        Me.lblIntradayCurrencyCompleted = New System.Windows.Forms.Label()
        Me.lblIntradayCurrencyErrorGettingData = New System.Windows.Forms.Label()
        Me.lblIntradayCurrencyGettingData = New System.Windows.Forms.Label()
        Me.lblIntradayCurrencyTotal = New System.Windows.Forms.Label()
        Me.grpBoxIntradayCommodity = New System.Windows.Forms.GroupBox()
        Me.lblIntradayCommodityErrorWritingData = New System.Windows.Forms.Label()
        Me.lblIntradayCommodityWritingData = New System.Windows.Forms.Label()
        Me.lblIntradayCommodityQueue = New System.Windows.Forms.Label()
        Me.lblIntradayCommodityCompleted = New System.Windows.Forms.Label()
        Me.lblIntradayCommodityErrorGettingData = New System.Windows.Forms.Label()
        Me.lblIntradayCommodityGettingData = New System.Windows.Forms.Label()
        Me.lblIntradayCommodityTotal = New System.Windows.Forms.Label()
        Me.grpBoxEODCurrency = New System.Windows.Forms.GroupBox()
        Me.lblEODCurrencyErrorWritingData = New System.Windows.Forms.Label()
        Me.lblEODCurrencyWritingData = New System.Windows.Forms.Label()
        Me.lblEODCurrencyQueue = New System.Windows.Forms.Label()
        Me.lblEODCurrencyCompleted = New System.Windows.Forms.Label()
        Me.lblEODCurrencyErrorGettingData = New System.Windows.Forms.Label()
        Me.lblEODCurrencyGettingData = New System.Windows.Forms.Label()
        Me.lblEODCurrencyTotal = New System.Windows.Forms.Label()
        Me.grpBoxEODCommodity = New System.Windows.Forms.GroupBox()
        Me.lblEODCommodityErrorWritingData = New System.Windows.Forms.Label()
        Me.lblEODCommodityWritingData = New System.Windows.Forms.Label()
        Me.lblEODCommodityQueue = New System.Windows.Forms.Label()
        Me.lblEODCommodityCompleted = New System.Windows.Forms.Label()
        Me.lblEODCommodityErrorGettingData = New System.Windows.Forms.Label()
        Me.lblEODCommodityGettingData = New System.Windows.Forms.Label()
        Me.lblEODCommodityTotal = New System.Windows.Forms.Label()
        Me.grpBoxEODFuture = New System.Windows.Forms.GroupBox()
        Me.lblEODFutureErrorWritingData = New System.Windows.Forms.Label()
        Me.lblEODFutureWritingData = New System.Windows.Forms.Label()
        Me.lblEODFutureQueue = New System.Windows.Forms.Label()
        Me.lblEODFutureCompleted = New System.Windows.Forms.Label()
        Me.lblEODFutureErrorGettingData = New System.Windows.Forms.Label()
        Me.lblEODFutureGettingData = New System.Windows.Forms.Label()
        Me.lblEODFutureTotal = New System.Windows.Forms.Label()
        Me.grpBoxEODCash = New System.Windows.Forms.GroupBox()
        Me.lblEODCashErrorWritingData = New System.Windows.Forms.Label()
        Me.lblEODCashWritingData = New System.Windows.Forms.Label()
        Me.lblEODCashQueue = New System.Windows.Forms.Label()
        Me.lblEODCashCompleted = New System.Windows.Forms.Label()
        Me.lblEODCashErrorGettingData = New System.Windows.Forms.Label()
        Me.lblEODCashGettingData = New System.Windows.Forms.Label()
        Me.lblEODCashTotal = New System.Windows.Forms.Label()
        Me.grpBoxPositional.SuspendLayout()
        Me.grpBoxIntradayCash.SuspendLayout()
        Me.grpBoxIntradayFuture.SuspendLayout()
        Me.grpBoxIntradayCurrency.SuspendLayout()
        Me.grpBoxIntradayCommodity.SuspendLayout()
        Me.grpBoxEODCurrency.SuspendLayout()
        Me.grpBoxEODCommodity.SuspendLayout()
        Me.grpBoxEODFuture.SuspendLayout()
        Me.grpBoxEODCash.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(383, 11)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(145, 39)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.Location = New System.Drawing.Point(14, 473)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(1043, 44)
        Me.lblProgress.TabIndex = 2
        Me.lblProgress.Text = "Progress Status"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(545, 11)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(139, 39)
        Me.btnStop.TabIndex = 5
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'grpBoxPositional
        '
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlErrorWritingData)
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlWritingData)
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlQueue)
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlCompleted)
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlErrorGettingData)
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlGettingData)
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlTotal)
        Me.grpBoxPositional.Location = New System.Drawing.Point(14, 85)
        Me.grpBoxPositional.Name = "grpBoxPositional"
        Me.grpBoxPositional.Size = New System.Drawing.Size(513, 74)
        Me.grpBoxPositional.TabIndex = 6
        Me.grpBoxPositional.TabStop = False
        Me.grpBoxPositional.Text = "Positional"
        '
        'lblPstnlErrorWritingData
        '
        Me.lblPstnlErrorWritingData.AutoSize = True
        Me.lblPstnlErrorWritingData.Location = New System.Drawing.Point(139, 48)
        Me.lblPstnlErrorWritingData.Name = "lblPstnlErrorWritingData"
        Me.lblPstnlErrorWritingData.Size = New System.Drawing.Size(142, 17)
        Me.lblPstnlErrorWritingData.TabIndex = 7
        Me.lblPstnlErrorWritingData.Text = "Error Writing Data : 0"
        '
        'lblPstnlWritingData
        '
        Me.lblPstnlWritingData.AutoSize = True
        Me.lblPstnlWritingData.Location = New System.Drawing.Point(7, 48)
        Me.lblPstnlWritingData.Name = "lblPstnlWritingData"
        Me.lblPstnlWritingData.Size = New System.Drawing.Size(110, 17)
        Me.lblPstnlWritingData.TabIndex = 6
        Me.lblPstnlWritingData.Text = "Writitng Data : 0"
        '
        'lblPstnlQueue
        '
        Me.lblPstnlQueue.AutoSize = True
        Me.lblPstnlQueue.Location = New System.Drawing.Point(98, 25)
        Me.lblPstnlQueue.Name = "lblPstnlQueue"
        Me.lblPstnlQueue.Size = New System.Drawing.Size(79, 17)
        Me.lblPstnlQueue.TabIndex = 5
        Me.lblPstnlQueue.Text = "Queued : 0"
        '
        'lblPstnlCompleted
        '
        Me.lblPstnlCompleted.AutoSize = True
        Me.lblPstnlCompleted.Location = New System.Drawing.Point(335, 48)
        Me.lblPstnlCompleted.Name = "lblPstnlCompleted"
        Me.lblPstnlCompleted.Size = New System.Drawing.Size(95, 17)
        Me.lblPstnlCompleted.TabIndex = 3
        Me.lblPstnlCompleted.Text = "Completed : 0"
        '
        'lblPstnlErrorGettingData
        '
        Me.lblPstnlErrorGettingData.AutoSize = True
        Me.lblPstnlErrorGettingData.Location = New System.Drawing.Point(335, 25)
        Me.lblPstnlErrorGettingData.Name = "lblPstnlErrorGettingData"
        Me.lblPstnlErrorGettingData.Size = New System.Drawing.Size(144, 17)
        Me.lblPstnlErrorGettingData.TabIndex = 2
        Me.lblPstnlErrorGettingData.Text = "Error Getting Data : 0"
        '
        'lblPstnlGettingData
        '
        Me.lblPstnlGettingData.AutoSize = True
        Me.lblPstnlGettingData.Location = New System.Drawing.Point(203, 25)
        Me.lblPstnlGettingData.Name = "lblPstnlGettingData"
        Me.lblPstnlGettingData.Size = New System.Drawing.Size(108, 17)
        Me.lblPstnlGettingData.TabIndex = 1
        Me.lblPstnlGettingData.Text = "Getting Data : 0"
        '
        'lblPstnlTotal
        '
        Me.lblPstnlTotal.AutoSize = True
        Me.lblPstnlTotal.Location = New System.Drawing.Point(7, 25)
        Me.lblPstnlTotal.Name = "lblPstnlTotal"
        Me.lblPstnlTotal.Size = New System.Drawing.Size(60, 17)
        Me.lblPstnlTotal.TabIndex = 0
        Me.lblPstnlTotal.Text = "Total : 0"
        '
        'grpBoxIntradayCash
        '
        Me.grpBoxIntradayCash.Controls.Add(Me.lblIntradayCashErrorWritingData)
        Me.grpBoxIntradayCash.Controls.Add(Me.lblIntradayCashWritingData)
        Me.grpBoxIntradayCash.Controls.Add(Me.lblIntradayCashQueue)
        Me.grpBoxIntradayCash.Controls.Add(Me.lblIntradayCashCompleted)
        Me.grpBoxIntradayCash.Controls.Add(Me.lblIntradayCashErrorGettingData)
        Me.grpBoxIntradayCash.Controls.Add(Me.lblIntradayCashGettingData)
        Me.grpBoxIntradayCash.Controls.Add(Me.lblIntradayCashTotal)
        Me.grpBoxIntradayCash.Location = New System.Drawing.Point(14, 160)
        Me.grpBoxIntradayCash.Name = "grpBoxIntradayCash"
        Me.grpBoxIntradayCash.Size = New System.Drawing.Size(513, 74)
        Me.grpBoxIntradayCash.TabIndex = 8
        Me.grpBoxIntradayCash.TabStop = False
        Me.grpBoxIntradayCash.Text = "Intraday Cash"
        '
        'lblIntradayCashErrorWritingData
        '
        Me.lblIntradayCashErrorWritingData.AutoSize = True
        Me.lblIntradayCashErrorWritingData.Location = New System.Drawing.Point(139, 48)
        Me.lblIntradayCashErrorWritingData.Name = "lblIntradayCashErrorWritingData"
        Me.lblIntradayCashErrorWritingData.Size = New System.Drawing.Size(142, 17)
        Me.lblIntradayCashErrorWritingData.TabIndex = 7
        Me.lblIntradayCashErrorWritingData.Text = "Error Writing Data : 0"
        '
        'lblIntradayCashWritingData
        '
        Me.lblIntradayCashWritingData.AutoSize = True
        Me.lblIntradayCashWritingData.Location = New System.Drawing.Point(7, 48)
        Me.lblIntradayCashWritingData.Name = "lblIntradayCashWritingData"
        Me.lblIntradayCashWritingData.Size = New System.Drawing.Size(110, 17)
        Me.lblIntradayCashWritingData.TabIndex = 6
        Me.lblIntradayCashWritingData.Text = "Writitng Data : 0"
        '
        'lblIntradayCashQueue
        '
        Me.lblIntradayCashQueue.AutoSize = True
        Me.lblIntradayCashQueue.Location = New System.Drawing.Point(98, 25)
        Me.lblIntradayCashQueue.Name = "lblIntradayCashQueue"
        Me.lblIntradayCashQueue.Size = New System.Drawing.Size(79, 17)
        Me.lblIntradayCashQueue.TabIndex = 5
        Me.lblIntradayCashQueue.Text = "Queued : 0"
        '
        'lblIntradayCashCompleted
        '
        Me.lblIntradayCashCompleted.AutoSize = True
        Me.lblIntradayCashCompleted.Location = New System.Drawing.Point(335, 48)
        Me.lblIntradayCashCompleted.Name = "lblIntradayCashCompleted"
        Me.lblIntradayCashCompleted.Size = New System.Drawing.Size(95, 17)
        Me.lblIntradayCashCompleted.TabIndex = 3
        Me.lblIntradayCashCompleted.Text = "Completed : 0"
        '
        'lblIntradayCashErrorGettingData
        '
        Me.lblIntradayCashErrorGettingData.AutoSize = True
        Me.lblIntradayCashErrorGettingData.Location = New System.Drawing.Point(335, 25)
        Me.lblIntradayCashErrorGettingData.Name = "lblIntradayCashErrorGettingData"
        Me.lblIntradayCashErrorGettingData.Size = New System.Drawing.Size(144, 17)
        Me.lblIntradayCashErrorGettingData.TabIndex = 2
        Me.lblIntradayCashErrorGettingData.Text = "Error Getting Data : 0"
        '
        'lblIntradayCashGettingData
        '
        Me.lblIntradayCashGettingData.AutoSize = True
        Me.lblIntradayCashGettingData.Location = New System.Drawing.Point(203, 25)
        Me.lblIntradayCashGettingData.Name = "lblIntradayCashGettingData"
        Me.lblIntradayCashGettingData.Size = New System.Drawing.Size(108, 17)
        Me.lblIntradayCashGettingData.TabIndex = 1
        Me.lblIntradayCashGettingData.Text = "Getting Data : 0"
        '
        'lblIntradayCashTotal
        '
        Me.lblIntradayCashTotal.AutoSize = True
        Me.lblIntradayCashTotal.Location = New System.Drawing.Point(7, 25)
        Me.lblIntradayCashTotal.Name = "lblIntradayCashTotal"
        Me.lblIntradayCashTotal.Size = New System.Drawing.Size(60, 17)
        Me.lblIntradayCashTotal.TabIndex = 0
        Me.lblIntradayCashTotal.Text = "Total : 0"
        '
        'grpBoxIntradayFuture
        '
        Me.grpBoxIntradayFuture.Controls.Add(Me.lblIntradayFutureErrorWritingData)
        Me.grpBoxIntradayFuture.Controls.Add(Me.lblIntradayFutureWritingData)
        Me.grpBoxIntradayFuture.Controls.Add(Me.lblIntradayFutureQueue)
        Me.grpBoxIntradayFuture.Controls.Add(Me.lblIntradayFutureCompleted)
        Me.grpBoxIntradayFuture.Controls.Add(Me.lblIntradayFutureErrorGettingData)
        Me.grpBoxIntradayFuture.Controls.Add(Me.lblIntradayFutureGettingData)
        Me.grpBoxIntradayFuture.Controls.Add(Me.lblIntradayFutureTotal)
        Me.grpBoxIntradayFuture.Location = New System.Drawing.Point(544, 160)
        Me.grpBoxIntradayFuture.Name = "grpBoxIntradayFuture"
        Me.grpBoxIntradayFuture.Size = New System.Drawing.Size(513, 74)
        Me.grpBoxIntradayFuture.TabIndex = 9
        Me.grpBoxIntradayFuture.TabStop = False
        Me.grpBoxIntradayFuture.Text = "Intraday Future"
        '
        'lblIntradayFutureErrorWritingData
        '
        Me.lblIntradayFutureErrorWritingData.AutoSize = True
        Me.lblIntradayFutureErrorWritingData.Location = New System.Drawing.Point(139, 48)
        Me.lblIntradayFutureErrorWritingData.Name = "lblIntradayFutureErrorWritingData"
        Me.lblIntradayFutureErrorWritingData.Size = New System.Drawing.Size(142, 17)
        Me.lblIntradayFutureErrorWritingData.TabIndex = 7
        Me.lblIntradayFutureErrorWritingData.Text = "Error Writing Data : 0"
        '
        'lblIntradayFutureWritingData
        '
        Me.lblIntradayFutureWritingData.AutoSize = True
        Me.lblIntradayFutureWritingData.Location = New System.Drawing.Point(7, 48)
        Me.lblIntradayFutureWritingData.Name = "lblIntradayFutureWritingData"
        Me.lblIntradayFutureWritingData.Size = New System.Drawing.Size(110, 17)
        Me.lblIntradayFutureWritingData.TabIndex = 6
        Me.lblIntradayFutureWritingData.Text = "Writitng Data : 0"
        '
        'lblIntradayFutureQueue
        '
        Me.lblIntradayFutureQueue.AutoSize = True
        Me.lblIntradayFutureQueue.Location = New System.Drawing.Point(98, 25)
        Me.lblIntradayFutureQueue.Name = "lblIntradayFutureQueue"
        Me.lblIntradayFutureQueue.Size = New System.Drawing.Size(79, 17)
        Me.lblIntradayFutureQueue.TabIndex = 5
        Me.lblIntradayFutureQueue.Text = "Queued : 0"
        '
        'lblIntradayFutureCompleted
        '
        Me.lblIntradayFutureCompleted.AutoSize = True
        Me.lblIntradayFutureCompleted.Location = New System.Drawing.Point(335, 48)
        Me.lblIntradayFutureCompleted.Name = "lblIntradayFutureCompleted"
        Me.lblIntradayFutureCompleted.Size = New System.Drawing.Size(95, 17)
        Me.lblIntradayFutureCompleted.TabIndex = 3
        Me.lblIntradayFutureCompleted.Text = "Completed : 0"
        '
        'lblIntradayFutureErrorGettingData
        '
        Me.lblIntradayFutureErrorGettingData.AutoSize = True
        Me.lblIntradayFutureErrorGettingData.Location = New System.Drawing.Point(335, 25)
        Me.lblIntradayFutureErrorGettingData.Name = "lblIntradayFutureErrorGettingData"
        Me.lblIntradayFutureErrorGettingData.Size = New System.Drawing.Size(144, 17)
        Me.lblIntradayFutureErrorGettingData.TabIndex = 2
        Me.lblIntradayFutureErrorGettingData.Text = "Error Getting Data : 0"
        '
        'lblIntradayFutureGettingData
        '
        Me.lblIntradayFutureGettingData.AutoSize = True
        Me.lblIntradayFutureGettingData.Location = New System.Drawing.Point(203, 25)
        Me.lblIntradayFutureGettingData.Name = "lblIntradayFutureGettingData"
        Me.lblIntradayFutureGettingData.Size = New System.Drawing.Size(108, 17)
        Me.lblIntradayFutureGettingData.TabIndex = 1
        Me.lblIntradayFutureGettingData.Text = "Getting Data : 0"
        '
        'lblIntradayFutureTotal
        '
        Me.lblIntradayFutureTotal.AutoSize = True
        Me.lblIntradayFutureTotal.Location = New System.Drawing.Point(7, 25)
        Me.lblIntradayFutureTotal.Name = "lblIntradayFutureTotal"
        Me.lblIntradayFutureTotal.Size = New System.Drawing.Size(60, 17)
        Me.lblIntradayFutureTotal.TabIndex = 0
        Me.lblIntradayFutureTotal.Text = "Total : 0"
        '
        'grpBoxIntradayCurrency
        '
        Me.grpBoxIntradayCurrency.Controls.Add(Me.lblIntradayCurrencyErrorWritingData)
        Me.grpBoxIntradayCurrency.Controls.Add(Me.lblIntradayCurrencyWritingData)
        Me.grpBoxIntradayCurrency.Controls.Add(Me.lblIntradayCurrencyQueue)
        Me.grpBoxIntradayCurrency.Controls.Add(Me.lblIntradayCurrencyCompleted)
        Me.grpBoxIntradayCurrency.Controls.Add(Me.lblIntradayCurrencyErrorGettingData)
        Me.grpBoxIntradayCurrency.Controls.Add(Me.lblIntradayCurrencyGettingData)
        Me.grpBoxIntradayCurrency.Controls.Add(Me.lblIntradayCurrencyTotal)
        Me.grpBoxIntradayCurrency.Location = New System.Drawing.Point(545, 235)
        Me.grpBoxIntradayCurrency.Name = "grpBoxIntradayCurrency"
        Me.grpBoxIntradayCurrency.Size = New System.Drawing.Size(513, 74)
        Me.grpBoxIntradayCurrency.TabIndex = 13
        Me.grpBoxIntradayCurrency.TabStop = False
        Me.grpBoxIntradayCurrency.Text = "Intraday Currency"
        '
        'lblIntradayCurrencyErrorWritingData
        '
        Me.lblIntradayCurrencyErrorWritingData.AutoSize = True
        Me.lblIntradayCurrencyErrorWritingData.Location = New System.Drawing.Point(139, 48)
        Me.lblIntradayCurrencyErrorWritingData.Name = "lblIntradayCurrencyErrorWritingData"
        Me.lblIntradayCurrencyErrorWritingData.Size = New System.Drawing.Size(142, 17)
        Me.lblIntradayCurrencyErrorWritingData.TabIndex = 7
        Me.lblIntradayCurrencyErrorWritingData.Text = "Error Writing Data : 0"
        '
        'lblIntradayCurrencyWritingData
        '
        Me.lblIntradayCurrencyWritingData.AutoSize = True
        Me.lblIntradayCurrencyWritingData.Location = New System.Drawing.Point(7, 48)
        Me.lblIntradayCurrencyWritingData.Name = "lblIntradayCurrencyWritingData"
        Me.lblIntradayCurrencyWritingData.Size = New System.Drawing.Size(110, 17)
        Me.lblIntradayCurrencyWritingData.TabIndex = 6
        Me.lblIntradayCurrencyWritingData.Text = "Writitng Data : 0"
        '
        'lblIntradayCurrencyQueue
        '
        Me.lblIntradayCurrencyQueue.AutoSize = True
        Me.lblIntradayCurrencyQueue.Location = New System.Drawing.Point(98, 25)
        Me.lblIntradayCurrencyQueue.Name = "lblIntradayCurrencyQueue"
        Me.lblIntradayCurrencyQueue.Size = New System.Drawing.Size(79, 17)
        Me.lblIntradayCurrencyQueue.TabIndex = 5
        Me.lblIntradayCurrencyQueue.Text = "Queued : 0"
        '
        'lblIntradayCurrencyCompleted
        '
        Me.lblIntradayCurrencyCompleted.AutoSize = True
        Me.lblIntradayCurrencyCompleted.Location = New System.Drawing.Point(335, 48)
        Me.lblIntradayCurrencyCompleted.Name = "lblIntradayCurrencyCompleted"
        Me.lblIntradayCurrencyCompleted.Size = New System.Drawing.Size(95, 17)
        Me.lblIntradayCurrencyCompleted.TabIndex = 3
        Me.lblIntradayCurrencyCompleted.Text = "Completed : 0"
        '
        'lblIntradayCurrencyErrorGettingData
        '
        Me.lblIntradayCurrencyErrorGettingData.AutoSize = True
        Me.lblIntradayCurrencyErrorGettingData.Location = New System.Drawing.Point(335, 25)
        Me.lblIntradayCurrencyErrorGettingData.Name = "lblIntradayCurrencyErrorGettingData"
        Me.lblIntradayCurrencyErrorGettingData.Size = New System.Drawing.Size(144, 17)
        Me.lblIntradayCurrencyErrorGettingData.TabIndex = 2
        Me.lblIntradayCurrencyErrorGettingData.Text = "Error Getting Data : 0"
        '
        'lblIntradayCurrencyGettingData
        '
        Me.lblIntradayCurrencyGettingData.AutoSize = True
        Me.lblIntradayCurrencyGettingData.Location = New System.Drawing.Point(203, 25)
        Me.lblIntradayCurrencyGettingData.Name = "lblIntradayCurrencyGettingData"
        Me.lblIntradayCurrencyGettingData.Size = New System.Drawing.Size(108, 17)
        Me.lblIntradayCurrencyGettingData.TabIndex = 1
        Me.lblIntradayCurrencyGettingData.Text = "Getting Data : 0"
        '
        'lblIntradayCurrencyTotal
        '
        Me.lblIntradayCurrencyTotal.AutoSize = True
        Me.lblIntradayCurrencyTotal.Location = New System.Drawing.Point(7, 25)
        Me.lblIntradayCurrencyTotal.Name = "lblIntradayCurrencyTotal"
        Me.lblIntradayCurrencyTotal.Size = New System.Drawing.Size(60, 17)
        Me.lblIntradayCurrencyTotal.TabIndex = 0
        Me.lblIntradayCurrencyTotal.Text = "Total : 0"
        '
        'grpBoxIntradayCommodity
        '
        Me.grpBoxIntradayCommodity.Controls.Add(Me.lblIntradayCommodityErrorWritingData)
        Me.grpBoxIntradayCommodity.Controls.Add(Me.lblIntradayCommodityWritingData)
        Me.grpBoxIntradayCommodity.Controls.Add(Me.lblIntradayCommodityQueue)
        Me.grpBoxIntradayCommodity.Controls.Add(Me.lblIntradayCommodityCompleted)
        Me.grpBoxIntradayCommodity.Controls.Add(Me.lblIntradayCommodityErrorGettingData)
        Me.grpBoxIntradayCommodity.Controls.Add(Me.lblIntradayCommodityGettingData)
        Me.grpBoxIntradayCommodity.Controls.Add(Me.lblIntradayCommodityTotal)
        Me.grpBoxIntradayCommodity.Location = New System.Drawing.Point(15, 235)
        Me.grpBoxIntradayCommodity.Name = "grpBoxIntradayCommodity"
        Me.grpBoxIntradayCommodity.Size = New System.Drawing.Size(513, 74)
        Me.grpBoxIntradayCommodity.TabIndex = 12
        Me.grpBoxIntradayCommodity.TabStop = False
        Me.grpBoxIntradayCommodity.Text = "Intraday Commodity"
        '
        'lblIntradayCommodityErrorWritingData
        '
        Me.lblIntradayCommodityErrorWritingData.AutoSize = True
        Me.lblIntradayCommodityErrorWritingData.Location = New System.Drawing.Point(139, 48)
        Me.lblIntradayCommodityErrorWritingData.Name = "lblIntradayCommodityErrorWritingData"
        Me.lblIntradayCommodityErrorWritingData.Size = New System.Drawing.Size(142, 17)
        Me.lblIntradayCommodityErrorWritingData.TabIndex = 7
        Me.lblIntradayCommodityErrorWritingData.Text = "Error Writing Data : 0"
        '
        'lblIntradayCommodityWritingData
        '
        Me.lblIntradayCommodityWritingData.AutoSize = True
        Me.lblIntradayCommodityWritingData.Location = New System.Drawing.Point(7, 48)
        Me.lblIntradayCommodityWritingData.Name = "lblIntradayCommodityWritingData"
        Me.lblIntradayCommodityWritingData.Size = New System.Drawing.Size(110, 17)
        Me.lblIntradayCommodityWritingData.TabIndex = 6
        Me.lblIntradayCommodityWritingData.Text = "Writitng Data : 0"
        '
        'lblIntradayCommodityQueue
        '
        Me.lblIntradayCommodityQueue.AutoSize = True
        Me.lblIntradayCommodityQueue.Location = New System.Drawing.Point(98, 25)
        Me.lblIntradayCommodityQueue.Name = "lblIntradayCommodityQueue"
        Me.lblIntradayCommodityQueue.Size = New System.Drawing.Size(79, 17)
        Me.lblIntradayCommodityQueue.TabIndex = 5
        Me.lblIntradayCommodityQueue.Text = "Queued : 0"
        '
        'lblIntradayCommodityCompleted
        '
        Me.lblIntradayCommodityCompleted.AutoSize = True
        Me.lblIntradayCommodityCompleted.Location = New System.Drawing.Point(335, 48)
        Me.lblIntradayCommodityCompleted.Name = "lblIntradayCommodityCompleted"
        Me.lblIntradayCommodityCompleted.Size = New System.Drawing.Size(95, 17)
        Me.lblIntradayCommodityCompleted.TabIndex = 3
        Me.lblIntradayCommodityCompleted.Text = "Completed : 0"
        '
        'lblIntradayCommodityErrorGettingData
        '
        Me.lblIntradayCommodityErrorGettingData.AutoSize = True
        Me.lblIntradayCommodityErrorGettingData.Location = New System.Drawing.Point(335, 25)
        Me.lblIntradayCommodityErrorGettingData.Name = "lblIntradayCommodityErrorGettingData"
        Me.lblIntradayCommodityErrorGettingData.Size = New System.Drawing.Size(144, 17)
        Me.lblIntradayCommodityErrorGettingData.TabIndex = 2
        Me.lblIntradayCommodityErrorGettingData.Text = "Error Getting Data : 0"
        '
        'lblIntradayCommodityGettingData
        '
        Me.lblIntradayCommodityGettingData.AutoSize = True
        Me.lblIntradayCommodityGettingData.Location = New System.Drawing.Point(203, 25)
        Me.lblIntradayCommodityGettingData.Name = "lblIntradayCommodityGettingData"
        Me.lblIntradayCommodityGettingData.Size = New System.Drawing.Size(108, 17)
        Me.lblIntradayCommodityGettingData.TabIndex = 1
        Me.lblIntradayCommodityGettingData.Text = "Getting Data : 0"
        '
        'lblIntradayCommodityTotal
        '
        Me.lblIntradayCommodityTotal.AutoSize = True
        Me.lblIntradayCommodityTotal.Location = New System.Drawing.Point(7, 25)
        Me.lblIntradayCommodityTotal.Name = "lblIntradayCommodityTotal"
        Me.lblIntradayCommodityTotal.Size = New System.Drawing.Size(60, 17)
        Me.lblIntradayCommodityTotal.TabIndex = 0
        Me.lblIntradayCommodityTotal.Text = "Total : 0"
        '
        'grpBoxEODCurrency
        '
        Me.grpBoxEODCurrency.Controls.Add(Me.lblEODCurrencyErrorWritingData)
        Me.grpBoxEODCurrency.Controls.Add(Me.lblEODCurrencyWritingData)
        Me.grpBoxEODCurrency.Controls.Add(Me.lblEODCurrencyQueue)
        Me.grpBoxEODCurrency.Controls.Add(Me.lblEODCurrencyCompleted)
        Me.grpBoxEODCurrency.Controls.Add(Me.lblEODCurrencyErrorGettingData)
        Me.grpBoxEODCurrency.Controls.Add(Me.lblEODCurrencyGettingData)
        Me.grpBoxEODCurrency.Controls.Add(Me.lblEODCurrencyTotal)
        Me.grpBoxEODCurrency.Location = New System.Drawing.Point(545, 385)
        Me.grpBoxEODCurrency.Name = "grpBoxEODCurrency"
        Me.grpBoxEODCurrency.Size = New System.Drawing.Size(513, 74)
        Me.grpBoxEODCurrency.TabIndex = 21
        Me.grpBoxEODCurrency.TabStop = False
        Me.grpBoxEODCurrency.Text = "EOD Currency"
        '
        'lblEODCurrencyErrorWritingData
        '
        Me.lblEODCurrencyErrorWritingData.AutoSize = True
        Me.lblEODCurrencyErrorWritingData.Location = New System.Drawing.Point(139, 48)
        Me.lblEODCurrencyErrorWritingData.Name = "lblEODCurrencyErrorWritingData"
        Me.lblEODCurrencyErrorWritingData.Size = New System.Drawing.Size(142, 17)
        Me.lblEODCurrencyErrorWritingData.TabIndex = 7
        Me.lblEODCurrencyErrorWritingData.Text = "Error Writing Data : 0"
        '
        'lblEODCurrencyWritingData
        '
        Me.lblEODCurrencyWritingData.AutoSize = True
        Me.lblEODCurrencyWritingData.Location = New System.Drawing.Point(7, 48)
        Me.lblEODCurrencyWritingData.Name = "lblEODCurrencyWritingData"
        Me.lblEODCurrencyWritingData.Size = New System.Drawing.Size(110, 17)
        Me.lblEODCurrencyWritingData.TabIndex = 6
        Me.lblEODCurrencyWritingData.Text = "Writitng Data : 0"
        '
        'lblEODCurrencyQueue
        '
        Me.lblEODCurrencyQueue.AutoSize = True
        Me.lblEODCurrencyQueue.Location = New System.Drawing.Point(98, 25)
        Me.lblEODCurrencyQueue.Name = "lblEODCurrencyQueue"
        Me.lblEODCurrencyQueue.Size = New System.Drawing.Size(79, 17)
        Me.lblEODCurrencyQueue.TabIndex = 5
        Me.lblEODCurrencyQueue.Text = "Queued : 0"
        '
        'lblEODCurrencyCompleted
        '
        Me.lblEODCurrencyCompleted.AutoSize = True
        Me.lblEODCurrencyCompleted.Location = New System.Drawing.Point(335, 48)
        Me.lblEODCurrencyCompleted.Name = "lblEODCurrencyCompleted"
        Me.lblEODCurrencyCompleted.Size = New System.Drawing.Size(95, 17)
        Me.lblEODCurrencyCompleted.TabIndex = 3
        Me.lblEODCurrencyCompleted.Text = "Completed : 0"
        '
        'lblEODCurrencyErrorGettingData
        '
        Me.lblEODCurrencyErrorGettingData.AutoSize = True
        Me.lblEODCurrencyErrorGettingData.Location = New System.Drawing.Point(335, 25)
        Me.lblEODCurrencyErrorGettingData.Name = "lblEODCurrencyErrorGettingData"
        Me.lblEODCurrencyErrorGettingData.Size = New System.Drawing.Size(144, 17)
        Me.lblEODCurrencyErrorGettingData.TabIndex = 2
        Me.lblEODCurrencyErrorGettingData.Text = "Error Getting Data : 0"
        '
        'lblEODCurrencyGettingData
        '
        Me.lblEODCurrencyGettingData.AutoSize = True
        Me.lblEODCurrencyGettingData.Location = New System.Drawing.Point(203, 25)
        Me.lblEODCurrencyGettingData.Name = "lblEODCurrencyGettingData"
        Me.lblEODCurrencyGettingData.Size = New System.Drawing.Size(108, 17)
        Me.lblEODCurrencyGettingData.TabIndex = 1
        Me.lblEODCurrencyGettingData.Text = "Getting Data : 0"
        '
        'lblEODCurrencyTotal
        '
        Me.lblEODCurrencyTotal.AutoSize = True
        Me.lblEODCurrencyTotal.Location = New System.Drawing.Point(7, 25)
        Me.lblEODCurrencyTotal.Name = "lblEODCurrencyTotal"
        Me.lblEODCurrencyTotal.Size = New System.Drawing.Size(60, 17)
        Me.lblEODCurrencyTotal.TabIndex = 0
        Me.lblEODCurrencyTotal.Text = "Total : 0"
        '
        'grpBoxEODCommodity
        '
        Me.grpBoxEODCommodity.Controls.Add(Me.lblEODCommodityErrorWritingData)
        Me.grpBoxEODCommodity.Controls.Add(Me.lblEODCommodityWritingData)
        Me.grpBoxEODCommodity.Controls.Add(Me.lblEODCommodityQueue)
        Me.grpBoxEODCommodity.Controls.Add(Me.lblEODCommodityCompleted)
        Me.grpBoxEODCommodity.Controls.Add(Me.lblEODCommodityErrorGettingData)
        Me.grpBoxEODCommodity.Controls.Add(Me.lblEODCommodityGettingData)
        Me.grpBoxEODCommodity.Controls.Add(Me.lblEODCommodityTotal)
        Me.grpBoxEODCommodity.Location = New System.Drawing.Point(15, 385)
        Me.grpBoxEODCommodity.Name = "grpBoxEODCommodity"
        Me.grpBoxEODCommodity.Size = New System.Drawing.Size(513, 74)
        Me.grpBoxEODCommodity.TabIndex = 20
        Me.grpBoxEODCommodity.TabStop = False
        Me.grpBoxEODCommodity.Text = "EOD Commodity"
        '
        'lblEODCommodityErrorWritingData
        '
        Me.lblEODCommodityErrorWritingData.AutoSize = True
        Me.lblEODCommodityErrorWritingData.Location = New System.Drawing.Point(139, 48)
        Me.lblEODCommodityErrorWritingData.Name = "lblEODCommodityErrorWritingData"
        Me.lblEODCommodityErrorWritingData.Size = New System.Drawing.Size(142, 17)
        Me.lblEODCommodityErrorWritingData.TabIndex = 7
        Me.lblEODCommodityErrorWritingData.Text = "Error Writing Data : 0"
        '
        'lblEODCommodityWritingData
        '
        Me.lblEODCommodityWritingData.AutoSize = True
        Me.lblEODCommodityWritingData.Location = New System.Drawing.Point(7, 48)
        Me.lblEODCommodityWritingData.Name = "lblEODCommodityWritingData"
        Me.lblEODCommodityWritingData.Size = New System.Drawing.Size(110, 17)
        Me.lblEODCommodityWritingData.TabIndex = 6
        Me.lblEODCommodityWritingData.Text = "Writitng Data : 0"
        '
        'lblEODCommodityQueue
        '
        Me.lblEODCommodityQueue.AutoSize = True
        Me.lblEODCommodityQueue.Location = New System.Drawing.Point(98, 25)
        Me.lblEODCommodityQueue.Name = "lblEODCommodityQueue"
        Me.lblEODCommodityQueue.Size = New System.Drawing.Size(79, 17)
        Me.lblEODCommodityQueue.TabIndex = 5
        Me.lblEODCommodityQueue.Text = "Queued : 0"
        '
        'lblEODCommodityCompleted
        '
        Me.lblEODCommodityCompleted.AutoSize = True
        Me.lblEODCommodityCompleted.Location = New System.Drawing.Point(335, 48)
        Me.lblEODCommodityCompleted.Name = "lblEODCommodityCompleted"
        Me.lblEODCommodityCompleted.Size = New System.Drawing.Size(95, 17)
        Me.lblEODCommodityCompleted.TabIndex = 3
        Me.lblEODCommodityCompleted.Text = "Completed : 0"
        '
        'lblEODCommodityErrorGettingData
        '
        Me.lblEODCommodityErrorGettingData.AutoSize = True
        Me.lblEODCommodityErrorGettingData.Location = New System.Drawing.Point(335, 25)
        Me.lblEODCommodityErrorGettingData.Name = "lblEODCommodityErrorGettingData"
        Me.lblEODCommodityErrorGettingData.Size = New System.Drawing.Size(144, 17)
        Me.lblEODCommodityErrorGettingData.TabIndex = 2
        Me.lblEODCommodityErrorGettingData.Text = "Error Getting Data : 0"
        '
        'lblEODCommodityGettingData
        '
        Me.lblEODCommodityGettingData.AutoSize = True
        Me.lblEODCommodityGettingData.Location = New System.Drawing.Point(203, 25)
        Me.lblEODCommodityGettingData.Name = "lblEODCommodityGettingData"
        Me.lblEODCommodityGettingData.Size = New System.Drawing.Size(108, 17)
        Me.lblEODCommodityGettingData.TabIndex = 1
        Me.lblEODCommodityGettingData.Text = "Getting Data : 0"
        '
        'lblEODCommodityTotal
        '
        Me.lblEODCommodityTotal.AutoSize = True
        Me.lblEODCommodityTotal.Location = New System.Drawing.Point(7, 25)
        Me.lblEODCommodityTotal.Name = "lblEODCommodityTotal"
        Me.lblEODCommodityTotal.Size = New System.Drawing.Size(60, 17)
        Me.lblEODCommodityTotal.TabIndex = 0
        Me.lblEODCommodityTotal.Text = "Total : 0"
        '
        'grpBoxEODFuture
        '
        Me.grpBoxEODFuture.Controls.Add(Me.lblEODFutureErrorWritingData)
        Me.grpBoxEODFuture.Controls.Add(Me.lblEODFutureWritingData)
        Me.grpBoxEODFuture.Controls.Add(Me.lblEODFutureQueue)
        Me.grpBoxEODFuture.Controls.Add(Me.lblEODFutureCompleted)
        Me.grpBoxEODFuture.Controls.Add(Me.lblEODFutureErrorGettingData)
        Me.grpBoxEODFuture.Controls.Add(Me.lblEODFutureGettingData)
        Me.grpBoxEODFuture.Controls.Add(Me.lblEODFutureTotal)
        Me.grpBoxEODFuture.Location = New System.Drawing.Point(544, 310)
        Me.grpBoxEODFuture.Name = "grpBoxEODFuture"
        Me.grpBoxEODFuture.Size = New System.Drawing.Size(513, 74)
        Me.grpBoxEODFuture.TabIndex = 19
        Me.grpBoxEODFuture.TabStop = False
        Me.grpBoxEODFuture.Text = "EOD Future"
        '
        'lblEODFutureErrorWritingData
        '
        Me.lblEODFutureErrorWritingData.AutoSize = True
        Me.lblEODFutureErrorWritingData.Location = New System.Drawing.Point(139, 48)
        Me.lblEODFutureErrorWritingData.Name = "lblEODFutureErrorWritingData"
        Me.lblEODFutureErrorWritingData.Size = New System.Drawing.Size(142, 17)
        Me.lblEODFutureErrorWritingData.TabIndex = 7
        Me.lblEODFutureErrorWritingData.Text = "Error Writing Data : 0"
        '
        'lblEODFutureWritingData
        '
        Me.lblEODFutureWritingData.AutoSize = True
        Me.lblEODFutureWritingData.Location = New System.Drawing.Point(7, 48)
        Me.lblEODFutureWritingData.Name = "lblEODFutureWritingData"
        Me.lblEODFutureWritingData.Size = New System.Drawing.Size(110, 17)
        Me.lblEODFutureWritingData.TabIndex = 6
        Me.lblEODFutureWritingData.Text = "Writitng Data : 0"
        '
        'lblEODFutureQueue
        '
        Me.lblEODFutureQueue.AutoSize = True
        Me.lblEODFutureQueue.Location = New System.Drawing.Point(98, 25)
        Me.lblEODFutureQueue.Name = "lblEODFutureQueue"
        Me.lblEODFutureQueue.Size = New System.Drawing.Size(79, 17)
        Me.lblEODFutureQueue.TabIndex = 5
        Me.lblEODFutureQueue.Text = "Queued : 0"
        '
        'lblEODFutureCompleted
        '
        Me.lblEODFutureCompleted.AutoSize = True
        Me.lblEODFutureCompleted.Location = New System.Drawing.Point(335, 48)
        Me.lblEODFutureCompleted.Name = "lblEODFutureCompleted"
        Me.lblEODFutureCompleted.Size = New System.Drawing.Size(95, 17)
        Me.lblEODFutureCompleted.TabIndex = 3
        Me.lblEODFutureCompleted.Text = "Completed : 0"
        '
        'lblEODFutureErrorGettingData
        '
        Me.lblEODFutureErrorGettingData.AutoSize = True
        Me.lblEODFutureErrorGettingData.Location = New System.Drawing.Point(335, 25)
        Me.lblEODFutureErrorGettingData.Name = "lblEODFutureErrorGettingData"
        Me.lblEODFutureErrorGettingData.Size = New System.Drawing.Size(144, 17)
        Me.lblEODFutureErrorGettingData.TabIndex = 2
        Me.lblEODFutureErrorGettingData.Text = "Error Getting Data : 0"
        '
        'lblEODFutureGettingData
        '
        Me.lblEODFutureGettingData.AutoSize = True
        Me.lblEODFutureGettingData.Location = New System.Drawing.Point(203, 25)
        Me.lblEODFutureGettingData.Name = "lblEODFutureGettingData"
        Me.lblEODFutureGettingData.Size = New System.Drawing.Size(108, 17)
        Me.lblEODFutureGettingData.TabIndex = 1
        Me.lblEODFutureGettingData.Text = "Getting Data : 0"
        '
        'lblEODFutureTotal
        '
        Me.lblEODFutureTotal.AutoSize = True
        Me.lblEODFutureTotal.Location = New System.Drawing.Point(7, 25)
        Me.lblEODFutureTotal.Name = "lblEODFutureTotal"
        Me.lblEODFutureTotal.Size = New System.Drawing.Size(60, 17)
        Me.lblEODFutureTotal.TabIndex = 0
        Me.lblEODFutureTotal.Text = "Total : 0"
        '
        'grpBoxEODCash
        '
        Me.grpBoxEODCash.Controls.Add(Me.lblEODCashErrorWritingData)
        Me.grpBoxEODCash.Controls.Add(Me.lblEODCashWritingData)
        Me.grpBoxEODCash.Controls.Add(Me.lblEODCashQueue)
        Me.grpBoxEODCash.Controls.Add(Me.lblEODCashCompleted)
        Me.grpBoxEODCash.Controls.Add(Me.lblEODCashErrorGettingData)
        Me.grpBoxEODCash.Controls.Add(Me.lblEODCashGettingData)
        Me.grpBoxEODCash.Controls.Add(Me.lblEODCashTotal)
        Me.grpBoxEODCash.Location = New System.Drawing.Point(14, 310)
        Me.grpBoxEODCash.Name = "grpBoxEODCash"
        Me.grpBoxEODCash.Size = New System.Drawing.Size(513, 74)
        Me.grpBoxEODCash.TabIndex = 18
        Me.grpBoxEODCash.TabStop = False
        Me.grpBoxEODCash.Text = "EOD Cash"
        '
        'lblEODCashErrorWritingData
        '
        Me.lblEODCashErrorWritingData.AutoSize = True
        Me.lblEODCashErrorWritingData.Location = New System.Drawing.Point(139, 48)
        Me.lblEODCashErrorWritingData.Name = "lblEODCashErrorWritingData"
        Me.lblEODCashErrorWritingData.Size = New System.Drawing.Size(142, 17)
        Me.lblEODCashErrorWritingData.TabIndex = 7
        Me.lblEODCashErrorWritingData.Text = "Error Writing Data : 0"
        '
        'lblEODCashWritingData
        '
        Me.lblEODCashWritingData.AutoSize = True
        Me.lblEODCashWritingData.Location = New System.Drawing.Point(7, 48)
        Me.lblEODCashWritingData.Name = "lblEODCashWritingData"
        Me.lblEODCashWritingData.Size = New System.Drawing.Size(110, 17)
        Me.lblEODCashWritingData.TabIndex = 6
        Me.lblEODCashWritingData.Text = "Writitng Data : 0"
        '
        'lblEODCashQueue
        '
        Me.lblEODCashQueue.AutoSize = True
        Me.lblEODCashQueue.Location = New System.Drawing.Point(98, 25)
        Me.lblEODCashQueue.Name = "lblEODCashQueue"
        Me.lblEODCashQueue.Size = New System.Drawing.Size(79, 17)
        Me.lblEODCashQueue.TabIndex = 5
        Me.lblEODCashQueue.Text = "Queued : 0"
        '
        'lblEODCashCompleted
        '
        Me.lblEODCashCompleted.AutoSize = True
        Me.lblEODCashCompleted.Location = New System.Drawing.Point(335, 48)
        Me.lblEODCashCompleted.Name = "lblEODCashCompleted"
        Me.lblEODCashCompleted.Size = New System.Drawing.Size(95, 17)
        Me.lblEODCashCompleted.TabIndex = 3
        Me.lblEODCashCompleted.Text = "Completed : 0"
        '
        'lblEODCashErrorGettingData
        '
        Me.lblEODCashErrorGettingData.AutoSize = True
        Me.lblEODCashErrorGettingData.Location = New System.Drawing.Point(335, 25)
        Me.lblEODCashErrorGettingData.Name = "lblEODCashErrorGettingData"
        Me.lblEODCashErrorGettingData.Size = New System.Drawing.Size(144, 17)
        Me.lblEODCashErrorGettingData.TabIndex = 2
        Me.lblEODCashErrorGettingData.Text = "Error Getting Data : 0"
        '
        'lblEODCashGettingData
        '
        Me.lblEODCashGettingData.AutoSize = True
        Me.lblEODCashGettingData.Location = New System.Drawing.Point(203, 25)
        Me.lblEODCashGettingData.Name = "lblEODCashGettingData"
        Me.lblEODCashGettingData.Size = New System.Drawing.Size(108, 17)
        Me.lblEODCashGettingData.TabIndex = 1
        Me.lblEODCashGettingData.Text = "Getting Data : 0"
        '
        'lblEODCashTotal
        '
        Me.lblEODCashTotal.AutoSize = True
        Me.lblEODCashTotal.Location = New System.Drawing.Point(7, 25)
        Me.lblEODCashTotal.Name = "lblEODCashTotal"
        Me.lblEODCashTotal.Size = New System.Drawing.Size(60, 17)
        Me.lblEODCashTotal.TabIndex = 0
        Me.lblEODCashTotal.Text = "Total : 0"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 532)
        Me.Controls.Add(Me.grpBoxEODCurrency)
        Me.Controls.Add(Me.grpBoxEODCommodity)
        Me.Controls.Add(Me.grpBoxEODFuture)
        Me.Controls.Add(Me.grpBoxEODCash)
        Me.Controls.Add(Me.grpBoxIntradayCurrency)
        Me.Controls.Add(Me.grpBoxIntradayCommodity)
        Me.Controls.Add(Me.grpBoxIntradayFuture)
        Me.Controls.Add(Me.grpBoxIntradayCash)
        Me.Controls.Add(Me.grpBoxPositional)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.btnStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EOD Positional Data Backup"
        Me.grpBoxPositional.ResumeLayout(False)
        Me.grpBoxPositional.PerformLayout()
        Me.grpBoxIntradayCash.ResumeLayout(False)
        Me.grpBoxIntradayCash.PerformLayout()
        Me.grpBoxIntradayFuture.ResumeLayout(False)
        Me.grpBoxIntradayFuture.PerformLayout()
        Me.grpBoxIntradayCurrency.ResumeLayout(False)
        Me.grpBoxIntradayCurrency.PerformLayout()
        Me.grpBoxIntradayCommodity.ResumeLayout(False)
        Me.grpBoxIntradayCommodity.PerformLayout()
        Me.grpBoxEODCurrency.ResumeLayout(False)
        Me.grpBoxEODCurrency.PerformLayout()
        Me.grpBoxEODCommodity.ResumeLayout(False)
        Me.grpBoxEODCommodity.PerformLayout()
        Me.grpBoxEODFuture.ResumeLayout(False)
        Me.grpBoxEODFuture.PerformLayout()
        Me.grpBoxEODCash.ResumeLayout(False)
        Me.grpBoxEODCash.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnStart As Button
    Friend WithEvents lblProgress As Label
    Friend WithEvents btnStop As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents grpBoxPositional As GroupBox
    Friend WithEvents lblPstnlTotal As Label
    Friend WithEvents lblPstnlGettingData As Label
    Friend WithEvents lblPstnlCompleted As Label
    Friend WithEvents lblPstnlErrorGettingData As Label
    Friend WithEvents lblPstnlQueue As Label
    Friend WithEvents lblPstnlErrorWritingData As Label
    Friend WithEvents lblPstnlWritingData As Label
    Friend WithEvents grpBoxIntradayCash As GroupBox
    Friend WithEvents lblIntradayCashErrorWritingData As Label
    Friend WithEvents lblIntradayCashWritingData As Label
    Friend WithEvents lblIntradayCashQueue As Label
    Friend WithEvents lblIntradayCashCompleted As Label
    Friend WithEvents lblIntradayCashErrorGettingData As Label
    Friend WithEvents lblIntradayCashGettingData As Label
    Friend WithEvents lblIntradayCashTotal As Label
    Friend WithEvents grpBoxIntradayFuture As GroupBox
    Friend WithEvents lblIntradayFutureErrorWritingData As Label
    Friend WithEvents lblIntradayFutureWritingData As Label
    Friend WithEvents lblIntradayFutureQueue As Label
    Friend WithEvents lblIntradayFutureCompleted As Label
    Friend WithEvents lblIntradayFutureErrorGettingData As Label
    Friend WithEvents lblIntradayFutureGettingData As Label
    Friend WithEvents lblIntradayFutureTotal As Label
    Friend WithEvents grpBoxIntradayCurrency As GroupBox
    Friend WithEvents lblIntradayCurrencyErrorWritingData As Label
    Friend WithEvents lblIntradayCurrencyWritingData As Label
    Friend WithEvents lblIntradayCurrencyQueue As Label
    Friend WithEvents lblIntradayCurrencyCompleted As Label
    Friend WithEvents lblIntradayCurrencyErrorGettingData As Label
    Friend WithEvents lblIntradayCurrencyGettingData As Label
    Friend WithEvents lblIntradayCurrencyTotal As Label
    Friend WithEvents grpBoxIntradayCommodity As GroupBox
    Friend WithEvents lblIntradayCommodityErrorWritingData As Label
    Friend WithEvents lblIntradayCommodityWritingData As Label
    Friend WithEvents lblIntradayCommodityQueue As Label
    Friend WithEvents lblIntradayCommodityCompleted As Label
    Friend WithEvents lblIntradayCommodityErrorGettingData As Label
    Friend WithEvents lblIntradayCommodityGettingData As Label
    Friend WithEvents lblIntradayCommodityTotal As Label
    Friend WithEvents grpBoxEODCurrency As GroupBox
    Friend WithEvents lblEODCurrencyErrorWritingData As Label
    Friend WithEvents lblEODCurrencyWritingData As Label
    Friend WithEvents lblEODCurrencyQueue As Label
    Friend WithEvents lblEODCurrencyCompleted As Label
    Friend WithEvents lblEODCurrencyErrorGettingData As Label
    Friend WithEvents lblEODCurrencyGettingData As Label
    Friend WithEvents lblEODCurrencyTotal As Label
    Friend WithEvents grpBoxEODCommodity As GroupBox
    Friend WithEvents lblEODCommodityErrorWritingData As Label
    Friend WithEvents lblEODCommodityWritingData As Label
    Friend WithEvents lblEODCommodityQueue As Label
    Friend WithEvents lblEODCommodityCompleted As Label
    Friend WithEvents lblEODCommodityErrorGettingData As Label
    Friend WithEvents lblEODCommodityGettingData As Label
    Friend WithEvents lblEODCommodityTotal As Label
    Friend WithEvents grpBoxEODFuture As GroupBox
    Friend WithEvents lblEODFutureErrorWritingData As Label
    Friend WithEvents lblEODFutureWritingData As Label
    Friend WithEvents lblEODFutureQueue As Label
    Friend WithEvents lblEODFutureCompleted As Label
    Friend WithEvents lblEODFutureErrorGettingData As Label
    Friend WithEvents lblEODFutureGettingData As Label
    Friend WithEvents lblEODFutureTotal As Label
    Friend WithEvents grpBoxEODCash As GroupBox
    Friend WithEvents lblEODCashErrorWritingData As Label
    Friend WithEvents lblEODCashWritingData As Label
    Friend WithEvents lblEODCashQueue As Label
    Friend WithEvents lblEODCashCompleted As Label
    Friend WithEvents lblEODCashErrorGettingData As Label
    Friend WithEvents lblEODCashGettingData As Label
    Friend WithEvents lblEODCashTotal As Label
End Class
