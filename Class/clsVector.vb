Option Explicit On
Option Strict On

Public Class clsVector
#Region "Private Declarations"
    Private dblWeight_Document(,) As Double
    Private dblWeight_Query() As Double

    Private lngNumber_Document(,) As Long
    Private lngNumber_Query() As Long
#End Region

    Sub New()
        MyBase.New()
    End Sub

    Public Sub Start_Vector(Optional ByVal blnNormalize As Boolean = True, Optional ByVal blnScan_All As Boolean = True)
        Dim lngToken_Count As Long = mdlProcedures.Count_Line_From_File(Application.StartupPath & "\parse.txt")
        Dim lngDocument_Count As Long = mdlProcedures.Count_Line_From_File(Application.StartupPath & "\file.txt")

        frmMain.Cursor = Cursors.WaitCursor

        Application.DoEvents()

        ReDim Me.lngNumber_Document(CType(lngToken_Count, Integer) - 1, CType(lngDocument_Count, Integer) - 1)
        ReDim Me.lngNumber_Query(CType(lngToken_Count, Integer) - 1)
        ReDim Me.dblWeight_Document(CType(lngToken_Count, Integer) - 1, CType(lngDocument_Count, Integer) - 1)
        ReDim Me.dblWeight_Query(CType(lngToken_Count, Integer) - 1)
        ReDim mdlProcedures.dblSimilarity_Document(CType(lngDocument_Count, Integer) - 1)

        Me.Document_Frequency_From_File(blnScan_All)
        Me.Query_Frequency_From_File()
        Me.Weight_Document_Query_From_File(lngToken_Count, lngDocument_Count, blnNormalize)
        Me.Similarity_Document_From_File(lngToken_Count, lngDocument_Count)

        frmMain.Cursor = Cursors.Default

        Application.DoEvents()
    End Sub

    Private Sub Document_Frequency_From_File(ByVal blnScan_All As Boolean)
        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object

        Dim lngCounter_File_Array As Long

        Try
            If System.IO.File.Exists(Application.StartupPath & "\file.txt") Then
                srdFile = System.IO.File.OpenText(Application.StartupPath & "\file.txt")

                objRead = srdFile.ReadLine

                lngCounter_File_Array = 0

                While objRead IsNot Nothing
                    If Not String.IsNullOrEmpty(objRead.ToString.Trim) Then
                        If blnScan_All Then
                            Me.Result_Document_Frequency(objRead.ToString.Trim, lngCounter_File_Array)
                        Else
                            Me.Result_Document_Frequency_Not_Scan_All(objRead.ToString.Trim, lngCounter_File_Array)
                        End If
                    End If

                    objRead = srdFile.ReadLine

                    lngCounter_File_Array += 1
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

    Private Sub Result_Document_Frequency(ByVal strFile_Name As String, ByVal lngCounter_File_Array As Long)
        Dim Words_Class As New clsWords

        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object
        Dim objFile As Object

        Dim lngCounter_Token_Array As Long

        Try
            If System.IO.File.Exists(strFile_Name) Then
                objRead = mdlProcedures.Read_Text_File(strFile_Name)

                objRead = Words_Class.Parse_Words(objRead.ToString, Application.StartupPath & "\stop.txt")

                objRead = Split(objRead.ToString)

                For Each strCounter_Words_Array As String In CType(objRead, Array)
                    Try
                        If System.IO.File.Exists(Application.StartupPath & "\parse.txt") Then
                            srdFile = System.IO.File.OpenText(Application.StartupPath & "\parse.txt")

                            objFile = srdFile.ReadLine

                            lngCounter_Token_Array = 0

                            While objFile IsNot Nothing
                                If objFile.ToString.ToLower.Trim = strCounter_Words_Array.ToLower.Trim Then
                                    Me.lngNumber_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_File_Array, Integer)) += 1
                                End If

                                objFile = srdFile.ReadLine

                                lngCounter_Token_Array += 1
                            End While

                            srdFile.Close()
                            srdFile.Dispose()
                        End If
                    Catch ex As UnauthorizedAccessException
                        frmMain.Set_Rich_Text(ex.ToString)
                    Catch ex As System.IO.IOException
                        frmMain.Set_Rich_Text(ex.ToString)
                    End Try
                Next strCounter_Words_Array
            End If
        Catch ex As UnauthorizedAccessException
            frmMain.Set_Rich_Text(ex.ToString)
        Catch ex As System.IO.IOException
            frmMain.Set_Rich_Text(ex.ToString)
        End Try
    End Sub

    Private Sub Result_Document_Frequency_Not_Scan_All(ByVal strFile_Name As String, ByVal lngCounter_File_Array As Long)
        Dim Words_Class As New clsWords

        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object
        Dim objFile As Object

        Dim objResult_Query As Object = frmMain.Get_Query

        Dim lngCounter_Token_Array As Long

        Dim strRead As String = mdlProcedures.Found_Text_From_File(strFile_Name, objResult_Query)

        If Not String.IsNullOrEmpty(strRead.Trim) Then
            strRead = Words_Class.Parse_Words(strRead, Application.StartupPath & "\stop.txt")

            objRead = Split(strRead)

            For Each strCounter_Words_Array As String In CType(objRead, Array)
                Try
                    If System.IO.File.Exists(Application.StartupPath & "\parse.txt") Then
                        srdFile = System.IO.File.OpenText(Application.StartupPath & "\parse.txt")

                        objFile = srdFile.ReadLine

                        lngCounter_Token_Array = 0

                        While objFile IsNot Nothing
                            If objFile.ToString.ToLower.Trim = strCounter_Words_Array.ToLower.Trim Then
                                Me.lngNumber_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_File_Array, Integer)) += 1
                            End If

                            objFile = srdFile.ReadLine

                            lngCounter_Token_Array += 1
                        End While

                        srdFile.Close()
                        srdFile.Dispose()
                    End If
                Catch ex As UnauthorizedAccessException
                    frmMain.Set_Rich_Text(ex.ToString)
                Catch ex As System.IO.IOException
                    frmMain.Set_Rich_Text(ex.ToString)
                End Try
            Next strCounter_Words_Array
        End If
    End Sub

    Private Sub Query_Frequency_From_File()
        Dim srdFile As System.IO.StreamReader

        Dim objRead As Object
        Dim objResult_Query As Object = frmMain.Get_Query

        Dim lngCounter_Token_Array As Long

        For Each strCounter_Query_Array As String In CType(objResult_Query, Array)
            Try
                If System.IO.File.Exists(Application.StartupPath & "\parse.txt") Then
                    srdFile = System.IO.File.OpenText(Application.StartupPath & "\parse.txt")

                    objRead = srdFile.ReadLine

                    lngCounter_Token_Array = 0

                    While objRead IsNot Nothing
                        If objRead.ToString.ToLower.Trim = strCounter_Query_Array.ToLower.Trim Then
                            Me.lngNumber_Query(CType(lngCounter_Token_Array, Integer)) += 1
                        End If

                        objRead = srdFile.ReadLine

                        lngCounter_Token_Array += 1
                    End While
                End If
            Catch ex As UnauthorizedAccessException
                frmMain.Set_Rich_Text(ex.ToString)
            Catch ex As System.IO.IOException
                frmMain.Set_Rich_Text(ex.ToString)
            End Try
        Next strCounter_Query_Array
    End Sub

    Private Sub Weight_Document_Query_From_File(ByVal lngToken_Count As Long, ByVal lngDocument_Count As Long, ByVal blnNormalize As Boolean)
        Dim dblNormalize_Document_Frequency As Double
        Dim dblNormalize_Query_Frequency As Double
        Dim dblInverse_Document_Frequency As Double

        Dim lngMaximum_Document_Frequency As Long
        Dim lngMaximum_Query_Frequency As Long = Me.Maximum_Query_Frequency(lngToken_Count)

        For lngCounter_Document_Array As Long = 0 To lngDocument_Count - 1
            lngMaximum_Document_Frequency = Me.Maximum_Document_Frequency(lngToken_Count, lngCounter_Document_Array)

            For lngCounter_Token_Array As Long = 0 To lngToken_Count - 1
                dblNormalize_Document_Frequency = Me.lngNumber_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_Document_Array, Integer)) / lngMaximum_Document_Frequency

                dblNormalize_Query_Frequency = Me.lngNumber_Query(CType(lngCounter_Token_Array, Integer)) / lngMaximum_Query_Frequency

                dblInverse_Document_Frequency = Math.Log10(lngDocument_Count / Me.Count_Document_Frequency(lngCounter_Token_Array, lngDocument_Count))

                If blnNormalize Then
                    Me.dblWeight_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_Document_Array, Integer)) = dblNormalize_Document_Frequency * dblInverse_Document_Frequency

                    Me.dblWeight_Query(CType(lngCounter_Token_Array, Integer)) = (0.5 + (0.5 * dblNormalize_Query_Frequency)) * dblInverse_Document_Frequency
                Else
                    Me.dblWeight_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_Document_Array, Integer)) = Me.lngNumber_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_Document_Array, Integer)) * dblInverse_Document_Frequency

                    Me.dblWeight_Query(CType(lngCounter_Token_Array, Integer)) = Me.lngNumber_Query(CType(lngCounter_Token_Array, Integer)) * dblInverse_Document_Frequency
                End If
            Next lngCounter_Token_Array
        Next lngCounter_Document_Array
    End Sub

    Private Function Maximum_Document_Frequency(ByVal lngToken_Count As Long, ByVal lngCounter_Document_Array As Long) As Long
        Dim lngMaximum As Long = 0

        For lngCounter_Token_Array As Long = 0 To lngToken_Count - 1
            If lngMaximum < Me.lngNumber_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_Document_Array, Integer)) Then
                lngMaximum = Me.lngNumber_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_Document_Array, Integer))
            End If
        Next lngCounter_Token_Array

        Maximum_Document_Frequency = lngMaximum
    End Function

    Private Function Maximum_Query_Frequency(ByVal lngToken_Count As Long) As Long
        Dim lngMaximum As Long = 0

        For lngCounter_Token_Array As Long = 0 To lngToken_Count - 1
            If lngMaximum < Me.lngNumber_Query(CType(lngCounter_Token_Array, Integer)) Then
                lngMaximum = Me.lngNumber_Query(CType(lngCounter_Token_Array, Integer))
            End If
        Next lngCounter_Token_Array

        Maximum_Query_Frequency = lngMaximum
    End Function

    Private Function Count_Document_Frequency(ByVal lngCounter_Token_Array As Long, ByVal lngDocument_Count As Long) As Long
        Dim lngCounter_Frequency As Long = 0

        For lngCounter_Document_Array As Long = 0 To lngDocument_Count - 1
            If Not Me.lngNumber_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_Document_Array, Integer)) = 0 Then
                lngCounter_Frequency += 1
            End If
        Next lngCounter_Document_Array

        Count_Document_Frequency = lngCounter_Frequency
    End Function

    Private Sub Similarity_Document_From_File(ByVal lngToken_Count As Long, ByVal lngDocument_Count As Long)
        Dim dblVector_Document As Double
        Dim dblVector_Query As Double = Math.Sqrt(Me.Vector_Query())
        Dim dblCorrelation As Double

        For lngCounter_Document_Array As Long = 0 To lngDocument_Count - 1
            dblVector_Document = Math.Sqrt(Me.Vector_Document(lngToken_Count, lngCounter_Document_Array))

            dblCorrelation = 0

            For lngCounter_Token_Array As Long = 0 To lngToken_Count - 1
                dblCorrelation += Me.dblWeight_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_Document_Array, Integer)) * Me.dblWeight_Query(CType(lngCounter_Token_Array, Integer))
            Next lngCounter_Token_Array

            If dblVector_Document = 0 OrElse dblVector_Query = 0 Then
                dblVector_Document = 1
                dblVector_Query = 1
            End If

            Try
                mdlProcedures.dblSimilarity_Document(CType(lngCounter_Document_Array, Integer)) = dblCorrelation / (dblVector_Document * dblVector_Query)
            Catch ex As System.DivideByZeroException
                frmMain.Set_Rich_Text(ex.ToString)

                mdlProcedures.dblSimilarity_Document(CType(lngCounter_Document_Array, Integer)) = 0
            End Try
        Next lngCounter_Document_Array
    End Sub

    Private Function Vector_Query() As Double
        Dim dblResult As Double = 0

        For Each dblCounter_Weight_Query_Array As Double In dblWeight_Query
            dblResult += Math.Pow(dblCounter_Weight_Query_Array, 2)
        Next dblCounter_Weight_Query_Array

        Vector_Query = dblResult
    End Function

    Private Function Vector_Document(ByVal lngToken_Count As Long, ByVal lngCounter_Document_Array As Long) As Double
        Dim dblResult As Double = 0

        For lngCounter_Token_Array As Long = 0 To lngToken_Count - 1
            dblResult += Math.Pow(Me.dblWeight_Document(CType(lngCounter_Token_Array, Integer), CType(lngCounter_Document_Array, Integer)), 2)
        Next lngCounter_Token_Array

        Vector_Document = dblResult
    End Function
End Class