Public Class TArrPoint
    Public N As Integer
    Public Elmt() As TPoint
    Public Sub Init()
        N = 0
        ReDim Elmt(-1)
    End Sub
    Public Overloads Sub InsertLast(x As Double, y As Double, z As Double)
        Dim P As TPoint
        P = New TPoint
        P.x = x
        P.y = y
        P.z = z
        ReDim Preserve Elmt(N)
        Elmt(N) = P
        N = N + 1
    End Sub

    Public Function Count()
        Return N
    End Function
End Class