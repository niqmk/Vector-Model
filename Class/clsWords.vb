Option Explicit On
Option Strict On

Public Class clsWords
#Region "Private Declarations"
    Private strStop_Words() As String = {" 0 ", " 1 ", " 2 ", " 3 ", " 4 ", " 5 ", " 6 ", " 7 ", " 8 ", " 9 ", _
                                        " a ", " aku ", _
                                        " b ", " bila ", " bilamana ", _
                                        " c ", _
                                        " d ", " daku ", " dia ", " dikau ", _
                                        " e ", _
                                        " f ", _
                                        " g ", _
                                        " h ", _
                                        " i ", _
                                        " j ", " jika ", _
                                        " k ", " kalian ", " kami ", " kamu ", _
                                        " l ", _
                                        " m ", _
                                        " n ", _
                                        " o ", _
                                        " p ", _
                                        " q ", _
                                        " r ", _
                                        " s ", " saya ", _
                                        " t ", " the ", _
                                        " u ", _
                                        " v ", _
                                        " w ", _
                                        " x ", _
                                        " y ", _
                                        " z "}

    Private strStop_Symbols() As String = {"~", "`", "!", "@", "#", _
                                            "$", "%", "^", "&", "*", _
                                            "(", ")", "-", "_", "+", _
                                            "=", "|", "\", "[", "]", _
                                            ":", ";", "'", "<", ",", _
                                            ">", ".", "?", "/", """", _
                                            vbCrLf, vbCr, vbLf}
#End Region
    Sub New()
        MyBase.New()
    End Sub

    Public Overloads Function Parse_Words(ByVal strList_Words As String) As String
        If mdlProcedures.blnStop_List Then
            Me.Remove_Stop_Symbols(strList_Words)
            Me.Remove_Stop_Words(strList_Words)
        End If

        Me.Remove_Blank(strList_Words)

        Parse_Words = strList_Words
    End Function

    Public Overloads Function Parse_Words(ByVal strList_Words As String, ByVal strFile_Name_Stop_List As String) As String
        If mdlProcedures.blnStop_List Then
            Me.Remove_Stop_Symbols(strList_Words)
            Me.Remove_Stop_Words(strList_Words)
            Me.Remove_Stop_List_From_File(strList_Words, strFile_Name_Stop_List)
        End If

        Me.Remove_Blank(strList_Words)

        Parse_Words = strList_Words
    End Function

    Public ReadOnly Property Get_Stop_Words() As Object
        Get
            Return Me.strStop_Words
        End Get
    End Property

    Public ReadOnly Property Get_Stop_Symbols() As Object
        Get
            Return Me.strStop_Symbols
        End Get
    End Property

    Private Sub Remove_Blank(ByRef strList_Words As String)
        Dim strWords_Temporary As String = ""
        Dim strWords() As String

        strWords = Split(strList_Words)

        For Each strCounter_Array As String In strWords
            If Not String.IsNullOrEmpty(strCounter_Array) Then
                If Not String.IsNullOrEmpty(strWords_Temporary.Trim) Then
                    strWords_Temporary &= " "
                End If

                strWords_Temporary &= strCounter_Array
            End If
        Next strCounter_Array

        strList_Words = strWords_Temporary
    End Sub

    Private Sub Remove_Stop_Words(ByRef strList_Words As String)
        Dim strWords() As String

        If Not String.IsNullOrEmpty(strList_Words.Trim) Then
            strWords = Split(strList_Words)

            strList_Words = Join(strWords, "  ")
            strList_Words = " " & strList_Words & " "

            For Each strCounter_Array As String In Me.strStop_Words
                strList_Words = Replace(strList_Words.ToLower, strCounter_Array.ToLower, " ", , , CompareMethod.Text)
            Next strCounter_Array
        End If
    End Sub

    Private Sub Remove_Stop_Symbols(ByRef strList_Words As String)
        If Not String.IsNullOrEmpty(strList_Words.Trim) Then
            For Each strCounter_Array As String In Me.strStop_Symbols
                strList_Words = Replace(strList_Words, strCounter_Array, " ", , , CompareMethod.Text)
            Next strCounter_Array
        End If
    End Sub

    Private Sub Remove_Stop_List_From_File(ByRef strList_Words As String, ByVal strFile_Name_Stop_List As String)
        Dim srdFile As System.IO.StreamReader

        Dim objFile As Object

        Dim strWords() As String

        If Not String.IsNullOrEmpty(strList_Words.Trim) Then
            strWords = Split(strList_Words)

            strList_Words = Join(strWords, "  ")
            strList_Words = " " & strList_Words & " "

            Try
                If System.IO.File.Exists(strFile_Name_Stop_List) Then
                    srdFile = System.IO.File.OpenText(strFile_Name_Stop_List)

                    objFile = srdFile.ReadLine

                    While objFile IsNot Nothing
                        If Not String.IsNullOrEmpty(objFile.ToString.Trim) Then
                            strList_Words = Replace(strList_Words.ToLower, objFile.ToString.ToLower, " ", , , CompareMethod.Text)
                        End If

                        objFile = srdFile.ReadLine
                    End While

                    srdFile.Close()
                    srdFile.Dispose()
                End If
            Catch ex As UnauthorizedAccessException
                frmMain.Set_Rich_Text(ex.ToString)
            Catch ex As System.IO.IOException
                frmMain.Set_Rich_Text(ex.ToString)
            End Try
        End If
    End Sub
End Class