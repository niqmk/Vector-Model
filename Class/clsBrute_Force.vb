Option Explicit On
Option Strict On

Public Class clsBrute_Force
#Region "Private Declarations"
    Private intFound_Position() As Integer

    Private blnFound As Boolean = False
#End Region

    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal strText As String, ByVal strPattern As String, Optional ByVal blnWord As Boolean = False)
        MyBase.New()

        Start_Search(strText, strPattern, blnWord)
    End Sub

    Public Sub Start_Search(ByVal strText As String, ByVal strPattern As String, Optional ByVal blnWord As Boolean = False)
        Dim intCounter_Array As Integer = -1

        Dim strWords() As String

        Me.blnFound = False

        If blnWord Then
            strWords = Split(strText)

            For Each strCounter_Text As String In strWords
                If Not String.IsNullOrEmpty(strCounter_Text) Then
                    If strCounter_Text.ToLower = strPattern.ToLower Then
                        Me.blnFound = True
                    End If
                End If
            Next strCounter_Text
        Else
            For intCounter_Text As Integer = 0 To strText.Length - strPattern.Length
                If strText.Substring(intCounter_Text + 1, strPattern.Length).ToLower = strPattern.ToLower Then
                    intCounter_Array = intCounter_Array + 1

                    ReDim Preserve Me.intFound_Position(intCounter_Array)

                    Me.intFound_Position(intCounter_Array) = intCounter_Text + 1

                    Me.blnFound = True
                End If
            Next intCounter_Text
        End If
    End Sub

    Public ReadOnly Property Is_Found() As Boolean
        Get
            Return Me.blnFound
        End Get
    End Property

    Public ReadOnly Property Fill_Found_Position() As Object
        Get
            Return Me.intFound_Position
        End Get
    End Property
End Class
