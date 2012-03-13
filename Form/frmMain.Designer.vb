<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.fbdMain = New System.Windows.Forms.FolderBrowserDialog
        Me.lsvMain = New System.Windows.Forms.ListView
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.chkNormalize = New System.Windows.Forms.CheckBox
        Me.llbRemove = New System.Windows.Forms.LinkLabel
        Me.llbMain = New System.Windows.Forms.LinkLabel
        Me.clbMain = New System.Windows.Forms.CheckedListBox
        Me.txtMain = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnDirectory = New System.Windows.Forms.Button
        Me.lblMain = New System.Windows.Forms.Label
        Me.pnlOption = New System.Windows.Forms.Panel
        Me.chkScan = New System.Windows.Forms.CheckBox
        Me.lblScan = New System.Windows.Forms.Label
        Me.rbtMain_Fourth = New System.Windows.Forms.RadioButton
        Me.rbtMain_Third = New System.Windows.Forms.RadioButton
        Me.rbtMain_Second = New System.Windows.Forms.RadioButton
        Me.rbtMain_First = New System.Windows.Forms.RadioButton
        Me.lblSize = New System.Windows.Forms.Label
        Me.spcMain = New System.Windows.Forms.SplitContainer
        Me.tlsMain = New System.Windows.Forms.ToolStrip
        Me.tlslblMain = New System.Windows.Forms.ToolStripLabel
        Me.tlscmbMain = New System.Windows.Forms.ToolStripComboBox
        Me.tlsbtnMain = New System.Windows.Forms.ToolStripButton
        Me.rtbNote = New System.Windows.Forms.RichTextBox
        Me.imlMain = New System.Windows.Forms.ImageList(Me.components)
        Me.stsMain = New System.Windows.Forms.StatusStrip
        Me.tlsslbMain = New System.Windows.Forms.ToolStripStatusLabel
        Me.pnlMain.SuspendLayout()
        Me.pnlOption.SuspendLayout()
        Me.spcMain.Panel1.SuspendLayout()
        Me.spcMain.Panel2.SuspendLayout()
        Me.spcMain.SuspendLayout()
        Me.tlsMain.SuspendLayout()
        Me.stsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbdMain
        '
        Me.fbdMain.Description = "Silahkan Pilih Direktori"
        Me.fbdMain.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.fbdMain.ShowNewFolderButton = False
        '
        'lsvMain
        '
        Me.lsvMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvMain.FullRowSelect = True
        Me.lsvMain.GridLines = True
        Me.lsvMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvMain.LabelWrap = False
        Me.lsvMain.Location = New System.Drawing.Point(3, 28)
        Me.lsvMain.MultiSelect = False
        Me.lsvMain.Name = "lsvMain"
        Me.lsvMain.ShowGroups = False
        Me.lsvMain.Size = New System.Drawing.Size(278, 429)
        Me.lsvMain.TabIndex = 0
        Me.lsvMain.TabStop = False
        Me.lsvMain.UseCompatibleStateImageBehavior = False
        Me.lsvMain.View = System.Windows.Forms.View.Details
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.chkNormalize)
        Me.pnlMain.Controls.Add(Me.llbRemove)
        Me.pnlMain.Controls.Add(Me.llbMain)
        Me.pnlMain.Controls.Add(Me.clbMain)
        Me.pnlMain.Controls.Add(Me.txtMain)
        Me.pnlMain.Controls.Add(Me.btnSearch)
        Me.pnlMain.Controls.Add(Me.btnDirectory)
        Me.pnlMain.Controls.Add(Me.lblMain)
        Me.pnlMain.Location = New System.Drawing.Point(17, 3)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(242, 273)
        Me.pnlMain.TabIndex = 0
        '
        'chkNormalize
        '
        Me.chkNormalize.AutoSize = True
        Me.chkNormalize.Location = New System.Drawing.Point(20, 239)
        Me.chkNormalize.Name = "chkNormalize"
        Me.chkNormalize.Size = New System.Drawing.Size(79, 17)
        Me.chkNormalize.TabIndex = 0
        Me.chkNormalize.TabStop = False
        Me.chkNormalize.Text = "Normalisasi"
        Me.chkNormalize.UseVisualStyleBackColor = True
        '
        'llbRemove
        '
        Me.llbRemove.AutoSize = True
        Me.llbRemove.Location = New System.Drawing.Point(17, 178)
        Me.llbRemove.Name = "llbRemove"
        Me.llbRemove.Size = New System.Drawing.Size(57, 13)
        Me.llbRemove.TabIndex = 4
        Me.llbRemove.TabStop = True
        Me.llbRemove.Text = "Hapus List"
        '
        'llbMain
        '
        Me.llbMain.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.llbMain.AutoSize = True
        Me.llbMain.Location = New System.Drawing.Point(71, 207)
        Me.llbMain.Name = "llbMain"
        Me.llbMain.Size = New System.Drawing.Size(95, 13)
        Me.llbMain.TabIndex = 5
        Me.llbMain.TabStop = True
        Me.llbMain.Text = "Spesifik Pencarian"
        '
        'clbMain
        '
        Me.clbMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbMain.FormattingEnabled = True
        Me.clbMain.HorizontalScrollbar = True
        Me.clbMain.Location = New System.Drawing.Point(20, 66)
        Me.clbMain.Name = "clbMain"
        Me.clbMain.Size = New System.Drawing.Size(202, 109)
        Me.clbMain.TabIndex = 0
        Me.clbMain.TabStop = False
        Me.clbMain.UseTabStops = False
        '
        'txtMain
        '
        Me.txtMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMain.Location = New System.Drawing.Point(20, 40)
        Me.txtMain.Name = "txtMain"
        Me.txtMain.Size = New System.Drawing.Size(202, 20)
        Me.txtMain.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSearch.Location = New System.Drawing.Point(129, 235)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(93, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Cari"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnDirectory
        '
        Me.btnDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDirectory.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDirectory.Location = New System.Drawing.Point(129, 181)
        Me.btnDirectory.Name = "btnDirectory"
        Me.btnDirectory.Size = New System.Drawing.Size(93, 23)
        Me.btnDirectory.TabIndex = 1
        Me.btnDirectory.Text = "Direktori"
        Me.btnDirectory.UseVisualStyleBackColor = False
        '
        'lblMain
        '
        Me.lblMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMain.Location = New System.Drawing.Point(18, 24)
        Me.lblMain.Name = "lblMain"
        Me.lblMain.Size = New System.Drawing.Size(205, 234)
        Me.lblMain.TabIndex = 0
        Me.lblMain.Text = "Masukkan Kata atau Kalimat:"
        '
        'pnlOption
        '
        Me.pnlOption.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlOption.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOption.Controls.Add(Me.chkScan)
        Me.pnlOption.Controls.Add(Me.lblScan)
        Me.pnlOption.Controls.Add(Me.rbtMain_Fourth)
        Me.pnlOption.Controls.Add(Me.rbtMain_Third)
        Me.pnlOption.Controls.Add(Me.rbtMain_Second)
        Me.pnlOption.Controls.Add(Me.rbtMain_First)
        Me.pnlOption.Controls.Add(Me.lblSize)
        Me.pnlOption.Location = New System.Drawing.Point(17, 282)
        Me.pnlOption.Name = "pnlOption"
        Me.pnlOption.Size = New System.Drawing.Size(242, 176)
        Me.pnlOption.TabIndex = 0
        '
        'chkScan
        '
        Me.chkScan.AutoSize = True
        Me.chkScan.Location = New System.Drawing.Point(51, 147)
        Me.chkScan.Name = "chkScan"
        Me.chkScan.Size = New System.Drawing.Size(119, 17)
        Me.chkScan.TabIndex = 0
        Me.chkScan.TabStop = False
        Me.chkScan.Text = "Scan Semua Isi File"
        Me.chkScan.UseVisualStyleBackColor = True
        '
        'lblScan
        '
        Me.lblScan.AutoSize = True
        Me.lblScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScan.Location = New System.Drawing.Point(48, 130)
        Me.lblScan.Name = "lblScan"
        Me.lblScan.Size = New System.Drawing.Size(79, 13)
        Me.lblScan.TabIndex = 0
        Me.lblScan.Text = "Teknik Scan"
        '
        'rbtMain_Fourth
        '
        Me.rbtMain_Fourth.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rbtMain_Fourth.AutoSize = True
        Me.rbtMain_Fourth.Location = New System.Drawing.Point(51, 101)
        Me.rbtMain_Fourth.Name = "rbtMain_Fourth"
        Me.rbtMain_Fourth.Size = New System.Drawing.Size(135, 17)
        Me.rbtMain_Fourth.TabIndex = 0
        Me.rbtMain_Fourth.Text = "(Besar) Lebih Dari 5 KB"
        Me.rbtMain_Fourth.UseVisualStyleBackColor = True
        '
        'rbtMain_Third
        '
        Me.rbtMain_Third.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rbtMain_Third.AutoSize = True
        Me.rbtMain_Third.Location = New System.Drawing.Point(51, 78)
        Me.rbtMain_Third.Name = "rbtMain_Third"
        Me.rbtMain_Third.Size = New System.Drawing.Size(153, 17)
        Me.rbtMain_Third.TabIndex = 0
        Me.rbtMain_Third.Text = "(Sedang) Kurang Dari 5 KB"
        Me.rbtMain_Third.UseVisualStyleBackColor = True
        '
        'rbtMain_Second
        '
        Me.rbtMain_Second.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rbtMain_Second.AutoSize = True
        Me.rbtMain_Second.Location = New System.Drawing.Point(51, 55)
        Me.rbtMain_Second.Name = "rbtMain_Second"
        Me.rbtMain_Second.Size = New System.Drawing.Size(139, 17)
        Me.rbtMain_Second.TabIndex = 0
        Me.rbtMain_Second.Text = "(Kecil) Kurang Dari 1 KB"
        Me.rbtMain_Second.UseVisualStyleBackColor = True
        '
        'rbtMain_First
        '
        Me.rbtMain_First.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rbtMain_First.AutoSize = True
        Me.rbtMain_First.Location = New System.Drawing.Point(51, 32)
        Me.rbtMain_First.Name = "rbtMain_First"
        Me.rbtMain_First.Size = New System.Drawing.Size(79, 17)
        Me.rbtMain_First.TabIndex = 0
        Me.rbtMain_First.Text = "Tidak Ingat"
        Me.rbtMain_First.UseVisualStyleBackColor = True
        '
        'lblSize
        '
        Me.lblSize.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSize.AutoSize = True
        Me.lblSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.Location = New System.Drawing.Point(48, 16)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(72, 13)
        Me.lblSize.TabIndex = 0
        Me.lblSize.Text = "Ukuran File"
        '
        'spcMain
        '
        Me.spcMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spcMain.BackColor = System.Drawing.Color.White
        Me.spcMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.spcMain.Location = New System.Drawing.Point(12, 12)
        Me.spcMain.Name = "spcMain"
        '
        'spcMain.Panel1
        '
        Me.spcMain.Panel1.AutoScroll = True
        Me.spcMain.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.spcMain.Panel1.Controls.Add(Me.pnlOption)
        Me.spcMain.Panel1.Controls.Add(Me.pnlMain)
        '
        'spcMain.Panel2
        '
        Me.spcMain.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.spcMain.Panel2.Controls.Add(Me.tlsMain)
        Me.spcMain.Panel2.Controls.Add(Me.lsvMain)
        Me.spcMain.Size = New System.Drawing.Size(568, 465)
        Me.spcMain.SplitterDistance = 275
        Me.spcMain.SplitterWidth = 5
        Me.spcMain.TabIndex = 4
        '
        'tlsMain
        '
        Me.tlsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlslblMain, Me.tlscmbMain, Me.tlsbtnMain})
        Me.tlsMain.Location = New System.Drawing.Point(0, 0)
        Me.tlsMain.Name = "tlsMain"
        Me.tlsMain.Size = New System.Drawing.Size(284, 25)
        Me.tlsMain.TabIndex = 1
        '
        'tlslblMain
        '
        Me.tlslblMain.Name = "tlslblMain"
        Me.tlslblMain.Size = New System.Drawing.Size(91, 22)
        Me.tlslblMain.Text = "Urut Berdasarkan"
        '
        'tlscmbMain
        '
        Me.tlscmbMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tlscmbMain.Name = "tlscmbMain"
        Me.tlscmbMain.Size = New System.Drawing.Size(121, 25)
        '
        'tlsbtnMain
        '
        Me.tlsbtnMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlsbtnMain.Image = CType(resources.GetObject("tlsbtnMain.Image"), System.Drawing.Image)
        Me.tlsbtnMain.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlsbtnMain.Name = "tlsbtnMain"
        Me.tlsbtnMain.Size = New System.Drawing.Size(23, 22)
        Me.tlsbtnMain.ToolTipText = "Daftar Stop List"
        '
        'rtbNote
        '
        Me.rtbNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbNote.BackColor = System.Drawing.SystemColors.Window
        Me.rtbNote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbNote.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.rtbNote.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbNote.Location = New System.Drawing.Point(13, 483)
        Me.rtbNote.Name = "rtbNote"
        Me.rtbNote.ReadOnly = True
        Me.rtbNote.ShortcutsEnabled = False
        Me.rtbNote.Size = New System.Drawing.Size(567, 116)
        Me.rtbNote.TabIndex = 0
        Me.rtbNote.TabStop = False
        Me.rtbNote.Text = ""
        Me.rtbNote.WordWrap = False
        '
        'imlMain
        '
        Me.imlMain.ImageStream = CType(resources.GetObject("imlMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMain.Images.SetKeyName(0, "text.ico")
        '
        'stsMain
        '
        Me.stsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlsslbMain})
        Me.stsMain.Location = New System.Drawing.Point(0, 602)
        Me.stsMain.Name = "stsMain"
        Me.stsMain.Size = New System.Drawing.Size(589, 22)
        Me.stsMain.TabIndex = 5
        Me.stsMain.Text = "StatusStrip1"
        '
        'tlsslbMain
        '
        Me.tlsslbMain.Name = "tlsslbMain"
        Me.tlsslbMain.Size = New System.Drawing.Size(0, 17)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 624)
        Me.Controls.Add(Me.stsMain)
        Me.Controls.Add(Me.rtbNote)
        Me.Controls.Add(Me.spcMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistem Temu Kembali Informasi Model Vektor"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlOption.ResumeLayout(False)
        Me.pnlOption.PerformLayout()
        Me.spcMain.Panel1.ResumeLayout(False)
        Me.spcMain.Panel2.ResumeLayout(False)
        Me.spcMain.Panel2.PerformLayout()
        Me.spcMain.ResumeLayout(False)
        Me.tlsMain.ResumeLayout(False)
        Me.tlsMain.PerformLayout()
        Me.stsMain.ResumeLayout(False)
        Me.stsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbdMain As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lsvMain As System.Windows.Forms.ListView
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents llbMain As System.Windows.Forms.LinkLabel
    Friend WithEvents clbMain As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtMain As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblMain As System.Windows.Forms.Label
    Friend WithEvents btnDirectory As System.Windows.Forms.Button
    Friend WithEvents pnlOption As System.Windows.Forms.Panel
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents spcMain As System.Windows.Forms.SplitContainer
    Friend WithEvents llbRemove As System.Windows.Forms.LinkLabel
    Friend WithEvents rbtMain_Second As System.Windows.Forms.RadioButton
    Friend WithEvents rbtMain_First As System.Windows.Forms.RadioButton
    Friend WithEvents rbtMain_Third As System.Windows.Forms.RadioButton
    Friend WithEvents rbtMain_Fourth As System.Windows.Forms.RadioButton
    Friend WithEvents rtbNote As System.Windows.Forms.RichTextBox
    Friend WithEvents imlMain As System.Windows.Forms.ImageList
    Friend WithEvents stsMain As System.Windows.Forms.StatusStrip
    Friend WithEvents chkNormalize As System.Windows.Forms.CheckBox
    Friend WithEvents tlsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents tlslblMain As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tlscmbMain As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tlsbtnMain As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlsslbMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chkScan As System.Windows.Forms.CheckBox
    Friend WithEvents lblScan As System.Windows.Forms.Label
End Class
