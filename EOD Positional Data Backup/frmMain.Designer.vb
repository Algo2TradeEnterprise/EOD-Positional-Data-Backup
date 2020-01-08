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
        Me.grpBoxPositional.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(179, 23)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(85, 39)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.Location = New System.Drawing.Point(11, 256)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(516, 44)
        Me.lblProgress.TabIndex = 2
        Me.lblProgress.Text = "Progress Status"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(273, 23)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(85, 39)
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
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 308)
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
End Class
