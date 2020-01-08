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
        Me.lblPstnlTotal = New System.Windows.Forms.Label()
        Me.lblPstnlHstrclDone = New System.Windows.Forms.Label()
        Me.lblPstnlDBDone = New System.Windows.Forms.Label()
        Me.lblPstnlTotalDone = New System.Windows.Forms.Label()
        Me.lblPstnlWaiting = New System.Windows.Forms.Label()
        Me.grpBoxPositional.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(314, 19)
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
        Me.lblProgress.Size = New System.Drawing.Size(781, 44)
        Me.lblProgress.TabIndex = 2
        Me.lblProgress.Text = "Progress Status"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(408, 19)
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
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlWaiting)
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlTotalDone)
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlDBDone)
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlHstrclDone)
        Me.grpBoxPositional.Controls.Add(Me.lblPstnlTotal)
        Me.grpBoxPositional.Location = New System.Drawing.Point(14, 85)
        Me.grpBoxPositional.Name = "grpBoxPositional"
        Me.grpBoxPositional.Size = New System.Drawing.Size(184, 168)
        Me.grpBoxPositional.TabIndex = 6
        Me.grpBoxPositional.TabStop = False
        Me.grpBoxPositional.Text = "Positional"
        '
        'lblPstnlTotal
        '
        Me.lblPstnlTotal.AutoSize = True
        Me.lblPstnlTotal.Location = New System.Drawing.Point(7, 31)
        Me.lblPstnlTotal.Name = "lblPstnlTotal"
        Me.lblPstnlTotal.Size = New System.Drawing.Size(60, 17)
        Me.lblPstnlTotal.TabIndex = 0
        Me.lblPstnlTotal.Text = "Total : 0"
        '
        'lblPstnlHstrclDone
        '
        Me.lblPstnlHstrclDone.AutoSize = True
        Me.lblPstnlHstrclDone.Location = New System.Drawing.Point(7, 57)
        Me.lblPstnlHstrclDone.Name = "lblPstnlHstrclDone"
        Me.lblPstnlHstrclDone.Size = New System.Drawing.Size(124, 17)
        Me.lblPstnlHstrclDone.TabIndex = 1
        Me.lblPstnlHstrclDone.Text = "Historical Done : 0"
        '
        'lblPstnlDBDone
        '
        Me.lblPstnlDBDone.AutoSize = True
        Me.lblPstnlDBDone.Location = New System.Drawing.Point(7, 83)
        Me.lblPstnlDBDone.Name = "lblPstnlDBDone"
        Me.lblPstnlDBDone.Size = New System.Drawing.Size(127, 17)
        Me.lblPstnlDBDone.TabIndex = 2
        Me.lblPstnlDBDone.Text = "Database Done : 0"
        '
        'lblPstnlTotalDone
        '
        Me.lblPstnlTotalDone.AutoSize = True
        Me.lblPstnlTotalDone.Location = New System.Drawing.Point(7, 109)
        Me.lblPstnlTotalDone.Name = "lblPstnlTotalDone"
        Me.lblPstnlTotalDone.Size = New System.Drawing.Size(98, 17)
        Me.lblPstnlTotalDone.TabIndex = 3
        Me.lblPstnlTotalDone.Text = "Total Done : 0"
        '
        'lblPstnlWaiting
        '
        Me.lblPstnlWaiting.AutoSize = True
        Me.lblPstnlWaiting.Location = New System.Drawing.Point(7, 135)
        Me.lblPstnlWaiting.Name = "lblPstnlWaiting"
        Me.lblPstnlWaiting.Size = New System.Drawing.Size(75, 17)
        Me.lblPstnlWaiting.TabIndex = 4
        Me.lblPstnlWaiting.Text = "Waiting : 0"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 308)
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
    Friend WithEvents lblPstnlHstrclDone As Label
    Friend WithEvents lblPstnlWaiting As Label
    Friend WithEvents lblPstnlTotalDone As Label
    Friend WithEvents lblPstnlDBDone As Label
End Class
