Option Explicit On
Option Strict On

Public Class clsList_View
    Implements IComparer

    Private intIndex_Column As Integer
    Private blnAscending As Boolean

    Sub New(ByVal intIndex_Column As Integer, ByVal blnAcsending As Boolean)
        MyBase.New()

        Me.intIndex_Column = intIndex_Column
        Me.blnAscending = blnAcsending
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim itm_First As ListViewItem
        Dim itm_Second As ListViewItem

        itm_First = CType(x, ListViewItem)
        itm_Second = CType(y, ListViewItem)

        If Me.blnAscending Then
            If IsNumeric(itm_First.SubItems(intIndex_Column).Text) AndAlso IsNumeric(itm_Second.SubItems(intIndex_Column).Text) Then
                If CType(itm_First.SubItems(intIndex_Column).Text, Double) > CType(itm_Second.SubItems(intIndex_Column).Text, Double) Then
                    Return 1
                Else
                    If CType(itm_First.SubItems(intIndex_Column).Text, Double) < CType(itm_Second.SubItems(intIndex_Column).Text, Double) Then
                        Return -1
                    Else
                        Return 0
                    End If
                End If
            Else
                If itm_First.SubItems(intIndex_Column).Text.ToLower > itm_Second.SubItems(intIndex_Column).Text.ToLower Then
                    Return 1
                Else
                    If itm_First.SubItems(intIndex_Column).Text.ToLower < itm_Second.SubItems(intIndex_Column).Text.ToLower Then
                        Return -1
                    Else
                        Return 0
                    End If
                End If
            End If
        Else
            If IsNumeric(itm_First.SubItems(intIndex_Column).Text) AndAlso IsNumeric(itm_Second.SubItems(intIndex_Column).Text) Then
                If CType(itm_First.SubItems(intIndex_Column).Text, Double) < CType(itm_Second.SubItems(intIndex_Column).Text, Double) Then
                    Return 1
                Else
                    If CType(itm_First.SubItems(intIndex_Column).Text, Double) > CType(itm_Second.SubItems(intIndex_Column).Text, Double) Then
                        Return -1
                    Else
                        Return 0
                    End If
                End If
            Else
                If itm_First.SubItems(intIndex_Column).Text.ToLower < itm_Second.SubItems(intIndex_Column).Text.ToLower Then
                    Return 1
                Else
                    If itm_First.SubItems(intIndex_Column).Text.ToLower > itm_Second.SubItems(intIndex_Column).Text.ToLower Then
                        Return -1
                    Else
                        Return 0
                    End If
                End If
            End If
        End If
    End Function
End Class
