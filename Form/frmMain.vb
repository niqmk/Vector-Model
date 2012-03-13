Option Explicit On
Option Strict On

Public Class frmMain
#Region "Public Declarations"
    Public strList_View As String
#End Region

#Region "Private Declarations"
    Private strResult_Query() As String

    Private blnOption As Boolean = False
    Private blnStart As Boolean = False
    Private blnScan_All As Boolean = False
#End Region

#Region "Form Initialization"
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Initialization()
    End Sub

    Private Sub Form_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.strResult_Query = Nothing
    End Sub

    Private Sub Form_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.blnStart Then Me.blnStart = False
    End Sub
#End Region

#Region "Clicker"
    Private Sub Button_Clicker(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click, btnDirectory.Click
        If sender.Equals(Me.btnDirectory) Then
            If Me.fbdMain.ShowDialog = Windows.Forms.DialogResult.OK Then
                mdlProcedures.Write_Text_File(Application.StartupPath & "\setting.txt", fbdMain.SelectedPath)

                Me.Fill_Search_List(Me.fbdMain.SelectedPath)

                Me.Show_Hide_Label_Remove()
            End If
        ElseIf sender.Equals(Me.btnSearch) Then
            If Me.btnSearch.Text = "Cari" Then
                If Me.Check_Validation() Then
                    Me.Set_All_Variable()

                    If Me.Build_Query() Then
                        Me.Initialization_Environment(True)

                        Me.Start_Search()

                        Me.Show_Result()

                        If Not Me.btnSearch.Text = "Cari" Then
                            Me.Initialization_Environment(False)
                        End If
                    End If
                End If
            Else
                Me.Initialization_Environment(False)
            End If
        End If
    End Sub

    Private Sub LinkLabel_Clicker(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbRemove.LinkClicked, llbMain.LinkClicked
        If sender.Equals(Me.llbRemove) Then
            If Me.clbMain.SelectedItem IsNot Nothing Then
                mdlProcedures.Remove_Text_Line_From_File(Application.StartupPath & "\setting.txt", Me.clbMain.SelectedItem.ToString & vbCrLf)

                Me.Remove_Search_List(Me.clbMain.SelectedIndex)
            End If
        ElseIf sender.Equals(Me.llbMain) Then
            If Me.blnOption Then
                Me.pnlOption.Visible = False
            Else
                Me.pnlOption.Visible = True
            End If

            Me.blnOption = Not blnOption
        End If
    End Sub

    Private Sub RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMain_First.CheckedChanged, rbtMain_Second.CheckedChanged, rbtMain_Third.CheckedChanged, rbtMain_Fourth.CheckedChanged
        CType(sender, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold, GraphicsUnit.Point, 0)

        If sender.Equals(Me.rbtMain_First) Then
            CType(Me.rbtMain_Second, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
            CType(Me.rbtMain_Third, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
            CType(Me.rbtMain_Fourth, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
        ElseIf sender.Equals(Me.rbtMain_Second) Then
            CType(Me.rbtMain_First, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
            CType(Me.rbtMain_Third, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
            CType(Me.rbtMain_Fourth, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
        ElseIf sender.Equals(rbtMain_Third) Then
            CType(Me.rbtMain_First, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
            CType(Me.rbtMain_Second, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
            CType(Me.rbtMain_Fourth, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
        ElseIf sender.Equals(rbtMain_Fourth) Then
            CType(Me.rbtMain_First, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
            CType(Me.rbtMain_Second, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
            CType(Me.rbtMain_Third, RadioButton).Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
        End If
    End Sub

    Private Sub RichTextbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtbNote.KeyDown
        Me.tlsslbMain.Text = "Maaf, Anda Tidak Dapat Mengedit Ini"
    End Sub

    Private Sub RichTextbox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtbNote.LostFocus
        Me.tlsslbMain.Text = ""
    End Sub

    Private Sub Toolstrip_Clicker(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlsbtnMain.Click, tlscmbMain.SelectedIndexChanged
        If sender.Equals(Me.tlsbtnMain) Then
            'If Not frmStop_List.Visible Then
            frmStop_List.Show(Me)
            'End If
        ElseIf sender.Equals(Me.tlscmbMain) Then
            Me.Select_Sort()
        End If
    End Sub

    Private Sub Listview_Clicker(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvMain.DoubleClick
        Dim frm_View As Form

        If Me.lsvMain.Items.Count > 0 Then
            frm_View = New frmView

            frm_View.Show(Me)
        End If
    End Sub

    Private Sub Listview_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lsvMain.ItemSelectionChanged
        If e.IsSelected Then
            Me.strList_View = e.Item.SubItems(1).Text & "\" & e.Item.SubItems(0).Text
        End If
    End Sub

    Private Sub Checker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScan.CheckedChanged
        If Me.chkScan.Checked Then
            mdlProcedures.Show_Tooltip(chkScan, "Scan Semua Isi File", "Scan Akan Memakan Waktu Lebih Lama", 2000, ToolTipIcon.Info)

            Me.blnScan_All = True
        ElseIf Not Me.chkScan.Checked Then
            Me.blnScan_All = False
        End If
    End Sub

    Private Sub txtMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMain.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.btnSearch.Text = "Cari" Then
                If Me.Check_Validation() Then
                    Me.Set_All_Variable()

                    If Me.Build_Query() Then
                        Me.Initialization_Environment(True)

                        Me.Start_Search()

                        Me.Show_Result()

                        If Not Me.btnSearch.Text = "Cari" Then
                            Me.Initialization_Environment(False)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Mouse"
    Private Sub Panel_Main_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlMain.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Store_Mouse_X_Move(e.X)
            Me.Store_Mouse_Y_Move(e.Y)

            Me.pnlMain.Cursor = Cursors.NoMove2D
        End If
    End Sub

    Private Sub Panel_Main_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlMain.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.pnlMain.Left = Me.pnlMain.Left + e.X - Me.Store_Mouse_X_Move
            Me.pnlMain.Top = Me.pnlMain.Top + e.Y - Me.Store_Mouse_Y_Move

            Me.pnlOption.Left = Me.pnlMain.Left
            Me.pnlOption.Top = Me.pnlMain.Top + 280
        Else
            Me.pnlMain.Cursor = Cursors.Default
        End If
    End Sub

    Private Function Store_Mouse_X_Move(Optional ByVal intX_Position As Integer = 0) As Integer
        Static intX As Integer

        If Not intX_Position = 0 Then intX = intX_Position

        Return intX
    End Function

    Private Function Store_Mouse_Y_Move(Optional ByVal intY_Position As Integer = 0) As Integer
        Static intY As Integer

        If Not intY_Position = 0 Then intY = intY_Position

        Return intY
    End Function
#End Region

#Region "File Search"
    Private Sub Start_Search()
        If Me.clbMain.CheckedItems.Count > 0 Then
            For Each strChecked_List As String In Me.clbMain.CheckedItems
                If Not Me.blnStart Then
                    Exit For
                End If

                Try
                    If System.IO.Directory.Exists(strChecked_List) Then
                        Me.lblMain.Text = "Mencari di Direktori:" & vbCrLf & strChecked_List

                        Me.Scan_Folder(strChecked_List)
                        Me.Scan_File_In_Folder(strChecked_List)
                    Else
                        Me.Set_Rich_Text("Pilihan Folder Tidak Ada")
                    End If
                Catch ex As UnauthorizedAccessException
                    Me.Set_Rich_Text(ex.ToString)
                Catch ex As System.IO.IOException
                    Me.Set_Rich_Text(ex.ToString)
                End Try

                Application.DoEvents()
            Next strChecked_List
        Else
            Try
                For Each drvMain As System.IO.DriveInfo In System.IO.DriveInfo.GetDrives
                    If Not Me.blnStart Then
                        Exit For
                    End If

                    If drvMain.IsReady Then
                        Me.lblMain.Text = "Mencari di Direktori:" & vbCrLf & drvMain.ToString

                        Me.Scan_Folder(drvMain.ToString)
                        Me.Scan_File_In_Folder(drvMain.ToString)
                    End If

                    Application.DoEvents()
                Next drvMain
            Catch ex As UnauthorizedAccessException
                Me.Set_Rich_Text(ex.ToString)
            Catch ex As System.IO.IOException
                Me.Set_Rich_Text(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Scan_File_In_Folder(ByVal strFolder As String)
        Dim strLabel As String = lblMain.Text

        Try
            For Each strFile_Name As String In System.IO.Directory.GetFiles(strFolder, "*.txt", IO.SearchOption.TopDirectoryOnly)
                If Not Me.blnStart Then
                    Exit For
                End If

                lblMain.Text = strLabel & vbCrLf & "Menemukan File:" & vbCrLf & New System.IO.FileInfo(strFile_Name).Name

                If Not strFile_Name.Trim = Application.StartupPath & "\parse.txt" _
                    AndAlso Not strFile_Name.Trim = Application.StartupPath & "\file.txt" Then
                    If Me.Compare_With_Option(strFile_Name) Then
                        If Me.blnScan_All Then
                            If mdlProcedures.Is_Found_Text_From_File(strFile_Name, strResult_Query) Then
                                Me.Parse_Token_From_File(strFile_Name)

                                mdlProcedures.Write_Text_File(Application.StartupPath & "\file.txt", strFile_Name)
                            End If
                        Else
                            If Me.Parse_Token_From_Line_File(strFile_Name) Then
                                mdlProcedures.Write_Text_File(Application.StartupPath & "\file.txt", strFile_Name)
                            End If
                        End If
                    End If
                End If

                Application.DoEvents()
            Next strFile_Name
        Catch ex As UnauthorizedAccessException
            Me.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            Me.Set_Rich_Text(ex.ToString)
        End Try
    End Sub

    Private Sub Scan_Folder(ByVal strFolder As String)
        Try
            For Each strSub_Folder As String In System.IO.Directory.GetDirectories(strFolder)
                If Not Me.blnStart Then
                    Exit For
                End If

                Me.lblMain.Text = "Mencari di Direktori:" & vbCrLf & strSub_Folder

                Try
                    If System.IO.Directory.GetFiles(strSub_Folder).Length > 0 Then
                        Me.Scan_File_In_Folder(strSub_Folder)
                    End If

                    If System.IO.Directory.GetDirectories(strSub_Folder).Length > 0 Then
                        Me.Scan_Folder(strSub_Folder)
                    End If
                Catch ex As UnauthorizedAccessException
                    Me.Set_Rich_Text(ex.ToString)
                Catch ex As System.IO.IOException
                    Me.Set_Rich_Text(ex.ToString)
                End Try

                Application.DoEvents()
            Next strSub_Folder
        Catch ex As UnauthorizedAccessException
            Me.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            Me.Set_Rich_Text(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Public Procedures"
    Public Sub Set_Rich_Text(ByVal strText As String, Optional ByVal blnWarning As Boolean = True)
        Me.rtbNote.AppendText(strText & vbCrLf)

        Me.rtbNote.Select(Me.rtbNote.TextLength, 0)
        Me.rtbNote.ScrollToCaret()
    End Sub

    Public ReadOnly Property Get_Query() As Object
        Get
            Return strResult_Query
        End Get
    End Property
#End Region

#Region "Procedures and Functions"
    Private Sub Initialization()
        mdlProcedures.blnStop_List = True

        Me.llbRemove.Visible = False
        Me.pnlOption.Visible = False

        Me.rbtMain_First.Checked = True

        With Me.tlscmbMain
            .Items.Add("Nama")
            .Items.Add("Persentase")
            .Items.Add("Ukuran File")

            .SelectedIndex = 0
        End With

        With Me.lsvMain
            .SmallImageList = imlMain

            .Columns.Add("Nama File", 150, HorizontalAlignment.Left)
            .Columns.Add("Direktori", 200, HorizontalAlignment.Left)
            .Columns.Add("Ukuran File (byte)", 100, HorizontalAlignment.Left)
            .Columns.Add("Persentase (%)", 100, HorizontalAlignment.Left)
        End With

        Me.Read_File_Setting()
        Me.Show_Hide_Label_Remove()
    End Sub

    Private Sub Read_File_Setting()
        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object

        Try
            If System.IO.File.Exists(Application.StartupPath & "\setting.txt") Then
                srdFile = System.IO.File.OpenText(Application.StartupPath & "\setting.txt")

                objRead = srdFile.ReadLine

                While Not objRead Is Nothing
                    Me.Fill_Search_List(objRead.ToString)

                    objRead = srdFile.ReadLine
                End While

                srdFile.Close()
                srdFile.Dispose()
            End If
        Catch ex As UnauthorizedAccessException
            Me.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            Me.Set_Rich_Text(ex.ToString)
        End Try
    End Sub

    Private Sub Show_Hide_Label_Remove(Optional ByVal blnLook_At_List As Boolean = True, Optional ByVal blnVisible As Boolean = True)
        If blnLook_At_List Then
            If Me.clbMain.Items.Count = 0 Then
                Me.llbRemove.Visible = False
            Else
                Me.llbRemove.Visible = True
            End If
        Else
            Me.llbRemove.Visible = blnVisible
        End If
    End Sub

    Private Function Check_Validation() As Boolean
        If String.IsNullOrEmpty(Me.txtMain.Text.Trim) Then
            mdlProcedures.Show_Tooltip(txtMain, "Query Kosong", "Masukkan Kata Atau Kalimat", 2000)

            Me.txtMain.Focus()

            Check_Validation = False
        Else
            Check_Validation = True
        End If
    End Function

    Private Sub Set_All_Variable()
        mdlProcedures.dblSimilarity_Document = Nothing
        Me.strResult_Query = Nothing
    End Sub

    Private Function Build_Query() As Boolean
        Dim Words_Class As New clsWords

        Dim strList_Words As String

        strList_Words = Words_Class.Parse_Words(Trim(Me.txtMain.Text), Application.StartupPath & "\stop.txt")

        If Not String.IsNullOrEmpty(strList_Words.Trim) Then
            Me.strResult_Query = Split(strList_Words)

            Build_Query = True
        Else
            mdlProcedures.Show_Tooltip(txtMain, "Semua Query Terkandung Stop List", "Stop List Menyebabkan Query Anda Kosong", 2000)

            txtMain.Focus()

            Build_Query = False
        End If
    End Function

    Private Sub Initialization_Environment(ByVal blnSearch As Boolean)
        Me.txtMain.Visible = Not blnSearch
        Me.clbMain.Visible = Not blnSearch
        Me.btnDirectory.Visible = Not blnSearch
        Me.llbMain.Visible = Not blnSearch
        Me.chkNormalize.Visible = Not blnSearch

        If Me.pnlOption.Visible Then Me.pnlOption.Visible = False

        If blnSearch Then
            mdlProcedures.Clear_Text_From_File(Application.StartupPath & "\parse.txt")
            mdlProcedures.Clear_Text_From_File(Application.StartupPath & "\file.txt")

            Me.rtbNote.Clear()
            Me.lsvMain.Items.Clear()

            Me.btnSearch.Text = "Berhenti"

            Me.lsvMain.ListViewItemSorter = Nothing

            Me.Show_Hide_Label_Remove(False, False)

            Me.lblMain.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold, GraphicsUnit.Point, 0)
            Me.lblMain.Text = ""

            Me.blnStart = True

            Me.blnOption = False
        Else
            Me.tlsslbMain.Text = ""
            Me.btnSearch.Text = "Cari"

            Me.Show_Hide_Label_Remove()

            Me.lblMain.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.lblMain.Text = "Masukkan Kata atau Kalimat:"

            Me.blnStart = False
        End If
    End Sub

    Private Sub Parse_Token_From_File(ByVal strFile_Name As String)
        Dim Words_Class As New clsWords

        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object

        Try
            If System.IO.File.Exists(strFile_Name) Then
                srdFile = System.IO.File.OpenText(strFile_Name)

                objRead = srdFile.ReadLine()

                While objRead IsNot Nothing
                    If Not Me.blnStart Then
                        Exit While
                    End If

                    If Not String.IsNullOrEmpty(objRead.ToString.Trim) Then
                        objRead = Words_Class.Parse_Words(objRead.ToString, Application.StartupPath & "\stop.txt")

                        If Not String.IsNullOrEmpty(objRead.ToString.Trim) Then
                            Me.Check_Validation_Token_From_File(Application.StartupPath & "\parse.txt", objRead.ToString)
                        End If
                    End If

                    objRead = srdFile.ReadLine()

                    Application.DoEvents()
                End While
            End If
        Catch ex As UnauthorizedAccessException
            Me.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            Me.Set_Rich_Text(ex.ToString)
        End Try
    End Sub

    Private Function Parse_Token_From_Line_File(ByVal strFile_Name As String) As Boolean
        Dim Words_Class As New clsWords

        Dim strRead As String = mdlProcedures.Found_Text_From_File(strFile_Name, strResult_Query)

        If Not String.IsNullOrEmpty(strRead.Trim) Then
            strRead = Words_Class.Parse_Words(strRead)

            Me.Check_Validation_Token_From_File(Application.StartupPath & "\parse.txt", strRead)

            Parse_Token_From_Line_File = True
        End If
    End Function

    Private Sub Check_Validation_Token_From_File(ByVal strToken_File_Name As String, ByVal strList_Words As String)
        Dim strWords() As String

        strWords = Split(strList_Words)

        For Each strWords_Array As String In strWords
            If Not Me.blnStart Then
                Exit For
            End If

            If Not String.IsNullOrEmpty(strWords_Array.Trim) Then
                If Not mdlProcedures.Is_Found_Text_From_File(strToken_File_Name, strWords_Array) Then
                    Me.tlsslbMain.Text = "Memparsing: " & strWords_Array

                    mdlProcedures.Write_Text_File(strToken_File_Name, strWords_Array)
                End If
            End If

            Application.DoEvents()
        Next strWords_Array
    End Sub

    Private Sub Show_Result()
        Dim lngDocument_Count As Long = mdlProcedures.Count_Line_From_File(Application.StartupPath & "\file.txt")

        If lngDocument_Count > 0 Then
            Me.Build_Vector()

            mdlProcedures.Show_Tooltip(lsvMain, "Hasil Temuan", "Terdapat " & lngDocument_Count.ToString & " File Yang Ditemukan", 2000, ToolTipIcon.Info)
        Else
            mdlProcedures.Show_Tooltip(lsvMain, "Hasil Temuan", "Hasil Temuan Tidak Ada", 2000, ToolTipIcon.Warning)
        End If
    End Sub

    Private Function Compare_With_Option(ByVal strFile_Compare As String) As Boolean
        Dim fioCompare As System.IO.FileInfo

        Try
            fioCompare = New System.IO.FileInfo(strFile_Compare)

            If Me.rbtMain_First.Checked Then
                Compare_With_Option = True
            ElseIf Me.rbtMain_Second.Checked Then
                If fioCompare.Length <= 1024 Then
                    Compare_With_Option = True
                Else
                    Compare_With_Option = False
                End If
            ElseIf Me.rbtMain_Third.Checked Then
                If fioCompare.Length <= (5 * 1024) Then
                    Compare_With_Option = True
                Else
                    Compare_With_Option = False
                End If
            ElseIf Me.rbtMain_Fourth.Checked Then
                If fioCompare.Length > (5 * 1024) Then
                    Compare_With_Option = True
                Else
                    Compare_With_Option = False
                End If
            End If
        Catch ex As UnauthorizedAccessException
            Me.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            Me.Set_Rich_Text(ex.ToString)
        End Try
    End Function

    Private Sub Build_Vector()
        Dim Vector_Class As New clsVector

        Me.btnSearch.Enabled = False

        Vector_Class.Start_Vector(Me.chkNormalize.Checked, Me.blnScan_All)

        Me.Fill_Result()

        Me.btnSearch.Enabled = True
    End Sub

    Private Sub Fill_Result()
        Dim srdFile As System.IO.StreamReader
        Dim fioResult As System.IO.FileInfo

        Dim objRead As Object

        Try
            If System.IO.File.Exists(Application.StartupPath & "\file.txt") Then
                srdFile = System.IO.File.OpenText(Application.StartupPath & "\file.txt")

                Me.Cursor = Cursors.WaitCursor

                objRead = srdFile.ReadLine

                While objRead IsNot Nothing
                    If Not String.IsNullOrEmpty(objRead.ToString.Trim) Then
                        If System.IO.File.Exists(objRead.ToString.Trim) Then
                            fioResult = New System.IO.FileInfo(objRead.ToString.Trim)

                            With Me.lsvMain
                                .Items.Add(fioResult.Name.Trim, 0)
                                .Items(.Items.Count - 1).SubItems.Add(fioResult.DirectoryName)
                                .Items(.Items.Count - 1).SubItems.Add(fioResult.Length.ToString)
                                .Items(.Items.Count - 1).SubItems.Add((dblSimilarity_Document(.Items.Count - 1) * 100).ToString & IIf(dblSimilarity_Document(.Items.Count - 1) = 0, " (Error)", "").ToString)
                            End With
                        End If
                    End If

                    objRead = srdFile.ReadLine

                    Application.DoEvents()
                End While

                Me.Cursor = Cursors.Default

                srdFile.Close()
                srdFile.Dispose()

                Me.Select_Sort()
            End If
        Catch ex As UnauthorizedAccessException
            Me.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            Me.Set_Rich_Text(ex.ToString)
        End Try
    End Sub

    Private Sub Fill_Search_List(ByVal strSearch_List As String)
        If Not Me.clbMain.Items.Contains(strSearch_List) Then
            Me.clbMain.Items.Add(strSearch_List)
        End If
    End Sub

    Private Sub Remove_Search_List(ByVal intSearch_Index As Integer)
        Me.clbMain.Items.RemoveAt(intSearch_Index)

        Me.Show_Hide_Label_Remove()
    End Sub

    Private Sub Select_Sort()
        If Me.lsvMain.Items.Count > 0 Then
            Select Case Me.tlscmbMain.SelectedIndex
                Case 0
                    Me.lsvMain.ListViewItemSorter = New clsList_View(0, True)
                Case 1
                    Me.lsvMain.ListViewItemSorter = New clsList_View(3, False)
                Case 2
                    Me.lsvMain.ListViewItemSorter = New clsList_View(2, True)
            End Select
        End If
    End Sub
#End Region
End Class