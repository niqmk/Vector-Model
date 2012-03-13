Option Explicit On
Option Strict On

Public Class frmView
#Region "Private Declaration"
    Private blnStart As Boolean = True
#End Region

#Region "Initialize Form"
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Initialization()
    End Sub

    Private Sub Form_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Form_Closing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.blnStart = False
    End Sub
#End Region

#Region "Form Private Function"
    Private Sub Initialization()
        Me.Text = frmMain.strList_View

        Me.rtbView.WordWrap = False

        Try
            If System.IO.File.Exists(frmMain.strList_View) Then
                Me.rtbView.LoadFile(frmMain.strList_View, RichTextBoxStreamType.PlainText)

                Me.Search_Text_Layout()
            Else
                frmMain.Set_Rich_Text("Tidak dapat membuka " & frmMain.strList_View)

                Me.Close()
            End If
        Catch ex As UnauthorizedAccessException
            frmMain.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            frmMain.Set_Rich_Text(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Private Procedure"
    Private Sub Search_Text_Layout()
        Dim objQuery As Object = frmMain.Get_Query

        Dim intFind As Integer

        Me.Cursor = Cursors.WaitCursor

        For Each strQuery As String In CType(objQuery, Array)
            If Not Me.blnStart Then
                Exit For
            End If

            Me.rtbView.SelectionStart = 0

            intFind = InStr(Me.rtbView.SelectionStart + 1, Me.rtbView.Text, strQuery & " ", CompareMethod.Text)

            While Not intFind = 0
                If Not Me.blnStart Then
                    Exit While
                End If

                Me.rtbView.SelectionStart = intFind - 1

                Me.rtbView.SelectionLength = strQuery.Length

                Me.rtbView.SelectionFont = New Font("Courier New", 24, FontStyle.Bold, GraphicsUnit.Point, 0)
                Me.rtbView.SelectionColor = Color.Blue

                intFind = InStr(intFind + 1, Me.rtbView.Text & " ", strQuery & " ", CompareMethod.Text)

                Application.DoEvents()
            End While
        Next strQuery

        Me.Cursor = Cursors.Default
    End Sub
#End Region
End Class