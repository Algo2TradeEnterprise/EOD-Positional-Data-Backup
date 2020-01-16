<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmErrorList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmErrorList))
        Me.dgvMain = New System.Windows.Forms.DataGridView()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMain
        '
        Me.dgvMain.AllowUserToAddRows = False
        Me.dgvMain.AllowUserToDeleteRows = False
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMain.Location = New System.Drawing.Point(0, 0)
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.ReadOnly = True
        Me.dgvMain.RowHeadersVisible = False
        Me.dgvMain.RowTemplate.Height = 24
        Me.dgvMain.Size = New System.Drawing.Size(801, 306)
        Me.dgvMain.TabIndex = 0
        '
        'frmErrorList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 306)
        Me.Controls.Add(Me.dgvMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmErrorList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Error List"
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvMain As DataGridView
End Class
