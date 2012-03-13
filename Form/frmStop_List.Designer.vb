<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStop_List
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstStop_List = New System.Windows.Forms.ListBox
        Me.txtStop_List = New System.Windows.Forms.TextBox
        Me.btnCreate = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.chkStop_List = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'lstStop_List
        '
        Me.lstStop_List.FormattingEnabled = True
        Me.lstStop_List.HorizontalScrollbar = True
        Me.lstStop_List.Location = New System.Drawing.Point(12, 12)
        Me.lstStop_List.Name = "lstStop_List"
        Me.lstStop_List.Size = New System.Drawing.Size(268, 199)
        Me.lstStop_List.TabIndex = 0
        Me.lstStop_List.TabStop = False
        Me.lstStop_List.UseTabStops = False
        '
        'txtStop_List
        '
        Me.txtStop_List.Location = New System.Drawing.Point(12, 217)
        Me.txtStop_List.Name = "txtStop_List"
        Me.txtStop_List.Size = New System.Drawing.Size(268, 20)
        Me.txtStop_List.TabIndex = 0
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(12, 245)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(65, 23)
        Me.btnCreate.TabIndex = 1
        Me.btnCreate.Text = "Buat List"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(83, 245)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 2
        Me.btnRemove.Text = "Hapus List"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'chkStop_List
        '
        Me.chkStop_List.AutoSize = True
        Me.chkStop_List.Location = New System.Drawing.Point(164, 249)
        Me.chkStop_List.Name = "chkStop_List"
        Me.chkStop_List.Size = New System.Drawing.Size(114, 17)
        Me.chkStop_List.TabIndex = 3
        Me.chkStop_List.Text = "Gunakan Stop List"
        Me.chkStop_List.UseVisualStyleBackColor = True
        '
        'frmStop_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 280)
        Me.Controls.Add(Me.chkStop_List)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.txtStop_List)
        Me.Controls.Add(Me.lstStop_List)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmStop_List"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daftar Stop List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstStop_List As System.Windows.Forms.ListBox
    Friend WithEvents txtStop_List As System.Windows.Forms.TextBox
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents chkStop_List As System.Windows.Forms.CheckBox
End Class
