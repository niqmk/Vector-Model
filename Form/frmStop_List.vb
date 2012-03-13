Option Explicit On
Option Strict On

Public Class frmStop_List
#Region "Private Declarations"
    Private intSystem_Stop_List As Integer
#End Region

#Region "Initialize Form"
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Initialization()
    End Sub

    Private Sub Form_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "Clicker"
    Private Sub Button_Clicker(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click, btnRemove.Click
        If sender.Equals(Me.btnCreate) Then
            If Not String.IsNullOrEmpty(Me.txtStop_List.Text.Trim) Then
                If Not Me.lstStop_List.Items.Contains(Me.txtStop_List.Text.Trim.ToLower) Then
                    If Me.txtStop_List.Text.Trim.Contains(" ") Then
                        For Each strStop_List As String In Split(Me.txtStop_List.Text.Trim)
                            If Not String.IsNullOrEmpty(strStop_List.Trim) Then
                                If Not Me.lstStop_List.Items.Contains(strStop_List.ToLower) Then
                                    mdlProcedures.Write_Text_File(Application.StartupPath & "\stop.txt", " " & strStop_List.Trim.ToLower & " ")

                                    Me.lstStop_List.Items.Add(strStop_List.ToLower)
                                End If
                            End If
                        Next strStop_List
                    Else
                        mdlProcedures.Write_Text_File(Application.StartupPath & "\stop.txt", " " & Me.txtStop_List.Text.Trim.ToLower & " ")

                        Me.lstStop_List.Items.Add(Me.txtStop_List.Text.Trim.ToLower)
                    End If
                Else
                    mdlProcedures.Show_Tooltip(lstStop_List, "Gagal Membuat Stop List", "Stop List Sudah Ada", 2000)
                End If
            Else
                mdlProcedures.Show_Tooltip(txtStop_List, "Gagal Membuat Stop List", "Stop List Tidak Dapat Dibuat Karena Field Kosong", 2000)
            End If
        ElseIf sender.Equals(Me.btnRemove) Then
            If Me.lstStop_List.SelectedItem IsNot Nothing Then
                If Me.lstStop_List.SelectedIndex >= intSystem_Stop_List Then
                    mdlProcedures.Remove_Text_Line_From_File(Application.StartupPath & "\stop.txt", " " & Me.lstStop_List.SelectedItem.ToString.Trim.ToLower & " " & vbCrLf)

                    Me.lstStop_List.Items.RemoveAt(Me.lstStop_List.SelectedIndex)

                    Me.lstStop_List.Refresh()
                Else
                    mdlProcedures.Show_Tooltip(lstStop_List, "Gagal Menghapus Stop List", "Tidak Dapat Menghapus Stop List Dari System", 2000)
                End If
            End If
        End If
    End Sub

    Private Sub Checker_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStop_List.CheckedChanged
        If Me.chkStop_List.Checked Then
            mdlProcedures.blnStop_List = True
        ElseIf Not Me.chkStop_List.Checked Then
            mdlProcedures.blnStop_List = False
        End If
    End Sub
#End Region

#Region "Private Form Function & Procedure"
    Private Sub Initialization()
        If mdlProcedures.blnStop_List Then
            Me.chkStop_List.Checked = True
        ElseIf Not mdlProcedures.blnStop_List Then
            Me.chkStop_List.Checked = False
        End If

        Me.intSystem_Stop_List = Me.Read_Stop_List_From_System()

        Me.Read_Stop_List_From_File()
    End Sub

    Private Sub Read_Stop_List_From_File()
        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object

        Try
            If System.IO.File.Exists(Application.StartupPath & "\stop.txt") Then
                srdFile = System.IO.File.OpenText(Application.StartupPath & "\stop.txt")

                objRead = srdFile.ReadLine

                While objRead IsNot Nothing
                    If Not String.IsNullOrEmpty(objRead.ToString.Trim) Then
                        Me.lstStop_List.Items.Add(objRead.ToString.Trim.ToLower)
                    End If

                    objRead = srdFile.ReadLine
                End While

                srdFile.Close()
                srdFile.Dispose()
            End If
        Catch ex As UnauthorizedAccessException
            frmMain.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            frmMain.Set_Rich_Text(ex.ToString)
        End Try
    End Sub

    Private Function Read_Stop_List_From_System() As Integer
        Dim Words_Class As New clsWords

        Dim objList_Stop As Object

        objList_Stop = Words_Class.Get_Stop_Words

        Me.Cursor = Cursors.WaitCursor

        For Each strRead As String In CType(objList_Stop, Array)
            Me.lstStop_List.Items.Add(strRead.Trim)
        Next strRead

        Me.Cursor = Cursors.Default

        Read_Stop_List_From_System = CType(objList_Stop, Array).Length

        objList_Stop = Words_Class.Get_Stop_Symbols

        Me.Cursor = Cursors.WaitCursor

        For Each strRead As String In CType(objList_Stop, Array)
            Me.lstStop_List.Items.Add(strRead.Trim)
        Next strRead

        Me.Cursor = Cursors.Default

        Read_Stop_List_From_System += CType(objList_Stop, Array).Length
    End Function
#End Region
End Class