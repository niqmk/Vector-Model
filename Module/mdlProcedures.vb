Option Explicit On
Option Strict On

Module mdlProcedures
#Region "Declarations"
    Public dblSimilarity_Document() As Double

    Public blnStop_List As Boolean
#End Region
#Region "IO Stream"
    Public Function Read_Text_File(ByVal strNama_File As String) As String
        Dim srdFile As System.IO.StreamReader

        Read_Text_File = ""

        Try
            If System.IO.File.Exists(strNama_File) Then
                srdFile = System.IO.File.OpenText(strNama_File)

                Read_Text_File = srdFile.ReadToEnd()

                srdFile.Close()
                srdFile.Dispose()
            End If
        Catch ex As UnauthorizedAccessException
            frmMain.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            frmMain.Set_Rich_Text(ex.ToString)
        End Try
    End Function

    Public Function Is_Found_Text_From_File(ByVal strFile_Name As String, ByVal strPattern() As String) As Boolean
        Dim Brute_Force_Class As New clsBrute_Force

        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object

        Dim blnFound As Boolean = False

        Dim strPattern_Array As String

        Try
            If System.IO.File.Exists(strFile_Name) Then
                srdFile = System.IO.File.OpenText(strFile_Name)

                objRead = srdFile.ReadLine

                While Not objRead Is Nothing
                    For Each strPattern_Array In strPattern
                        Brute_Force_Class.Start_Search(objRead.ToString, strPattern_Array, True)

                        If Brute_Force_Class.Is_Found Then
                            blnFound = Brute_Force_Class.Is_Found

                            Exit For
                        End If

                        Application.DoEvents()
                    Next strPattern_Array

                    If blnFound Then Exit While

                    objRead = srdFile.ReadLine

                    Application.DoEvents()
                End While

                srdFile.Close()
                srdFile.Dispose()
            End If

            Is_Found_Text_From_File = blnFound
        Catch ex As UnauthorizedAccessException
            frmMain.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            frmMain.Set_Rich_Text(ex.ToString)
        End Try
    End Function

    Public Function Is_Found_Text_From_File(ByVal strFile_Name As String, ByVal strPattern As String) As Boolean
        Dim Brute_Force_Class As New clsBrute_Force

        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object

        Dim blnFound As Boolean = False

        Try
            If System.IO.File.Exists(strFile_Name) Then
                srdFile = System.IO.File.OpenText(strFile_Name)

                objRead = srdFile.ReadLine

                While Not objRead Is Nothing
                    Brute_Force_Class.Start_Search(objRead.ToString, strPattern, True)

                    If Brute_Force_Class.Is_Found Then
                        blnFound = Brute_Force_Class.Is_Found

                        Exit While
                    End If

                    objRead = srdFile.ReadLine

                    Application.DoEvents()
                End While

                srdFile.Close()
                srdFile.Dispose()
            End If

            Is_Found_Text_From_File = blnFound
        Catch ex As UnauthorizedAccessException
            frmMain.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            frmMain.Set_Rich_Text(ex.ToString)
        End Try
    End Function

    Public Sub Write_Text_File(ByVal strFile_Name As String, ByVal strText As String)
        Dim swrFile As System.IO.StreamWriter

        Try
            If System.IO.File.Exists(strFile_Name) Then
                swrFile = System.IO.File.AppendText(strFile_Name)
            Else
                swrFile = System.IO.File.CreateText(strFile_Name)
            End If

            swrFile.WriteLine(strText)

            swrFile.Close()
            swrFile.Dispose()
        Catch ex As UnauthorizedAccessException
            frmMain.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            frmMain.Set_Rich_Text(ex.ToString)
        End Try
    End Sub

    Public Sub Clear_Text_From_File(ByVal strFile_Name As String)
        Dim swrFile As System.IO.StreamWriter

        Try
            If System.IO.File.Exists(strFile_Name) Then
                System.IO.File.Delete(strFile_Name)

                swrFile = System.IO.File.CreateText(strFile_Name)

                swrFile.Close()
                swrFile.Dispose()
            End If
        Catch ex As UnauthorizedAccessException
            frmMain.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            frmMain.Set_Rich_Text(ex.ToString)
        End Try
    End Sub

    Public Sub Remove_Text_Line_From_File(ByVal strFile_Name As String, ByVal strRemove As String)
        Dim strRead As String

        strRead = mdlProcedures.Read_Text_File(strFile_Name)

        If Not Trim(strRead) = "" Then
            strRead = Replace(strRead, strRemove, "", , , CompareMethod.Text)

            System.IO.File.WriteAllText(strFile_Name, strRead)
        End If
    End Sub

    Public Function Count_Line_From_File(ByVal strFile_Name As String) As Long
        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object

        Count_Line_From_File = 0

        If System.IO.File.Exists(strFile_Name) Then
            Try
                srdFile = System.IO.File.OpenText(strFile_Name)

                objRead = srdFile.ReadLine

                While Not objRead Is Nothing
                    If Not String.IsNullOrEmpty(objRead.ToString.Trim) Then
                        Count_Line_From_File += 1
                    End If

                    objRead = srdFile.ReadLine

                    Application.DoEvents()
                End While

                srdFile.Close()
                srdFile.Dispose()
            Catch ex As UnauthorizedAccessException
                frmMain.Set_Rich_Text(ex.ToString)
            Catch ex As System.IO.IOException
                frmMain.Set_Rich_Text(ex.ToString)
            End Try
        End If
    End Function

    Public Function Found_Text_From_File(ByVal strFile_Name As String, ByVal strPattern() As String) As String
        Dim Brute_Force_Class As New clsBrute_Force

        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object

        Dim blnFound As Boolean = False

        Found_Text_From_File = ""

        Try
            If System.IO.File.Exists(strFile_Name) Then
                srdFile = System.IO.File.OpenText(strFile_Name)

                objRead = srdFile.ReadLine

                While Not objRead Is Nothing
                    For Each strPattern_Array As String In strPattern
                        Brute_Force_Class.Start_Search(objRead.ToString, strPattern_Array, True)

                        If Brute_Force_Class.Is_Found Then
                            blnFound = Brute_Force_Class.Is_Found

                            Exit For
                        End If

                        Application.DoEvents()
                    Next strPattern_Array

                    If blnFound Then Exit While

                    objRead = srdFile.ReadLine

                    Application.DoEvents()
                End While

                srdFile.Close()
                srdFile.Dispose()

                If blnFound Then
                    Found_Text_From_File = objRead.ToString
                End If
            End If
        Catch ex As UnauthorizedAccessException
            frmMain.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            frmMain.Set_Rich_Text(ex.ToString)
        End Try
    End Function

    Public Function Found_Text_From_File(ByVal strFile_Name As String, ByVal objPattern As Object) As String
        Dim Brute_Force_Class As New clsBrute_Force

        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object

        Dim blnFound As Boolean = False

        Found_Text_From_File = ""

        Try
            If System.IO.File.Exists(strFile_Name) Then
                srdFile = System.IO.File.OpenText(strFile_Name)

                objRead = srdFile.ReadLine

                While Not objRead Is Nothing
                    For Each strPattern_Array As String In CType(objPattern, Array)
                        Brute_Force_Class.Start_Search(objRead.ToString, strPattern_Array, True)

                        If Brute_Force_Class.Is_Found Then
                            blnFound = Brute_Force_Class.Is_Found

                            Exit For
                        End If

                        Application.DoEvents()
                    Next strPattern_Array

                    If blnFound Then Exit While

                    objRead = srdFile.ReadLine

                    Application.DoEvents()
                End While

                srdFile.Close()
                srdFile.Dispose()

                If blnFound Then
                    Found_Text_From_File = objRead.ToString
                End If
            End If
        Catch ex As UnauthorizedAccessException
            frmMain.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            frmMain.Set_Rich_Text(ex.ToString)
        End Try
    End Function
#End Region

#Region "Common Procedures"
    Public Sub Show_Tooltip(ByVal cntForm As System.Windows.Forms.Control, ByVal strHeader As String, ByVal strText As String, ByVal intVisible As Integer, Optional ByVal icoTooltip As ToolTipIcon = ToolTipIcon.Error)
        Dim tltMain As New ToolTip

        With tltMain
            .RemoveAll()
            .Active = True
            .IsBalloon = True
            .ToolTipIcon = icoTooltip
            .ToolTipTitle = strHeader
            .ShowAlways = False
            .AutoPopDelay = 1
            .SetToolTip(cntForm, strText)
            .Show(strText, cntForm, intVisible)
        End With
    End Sub
#End Region
End Module