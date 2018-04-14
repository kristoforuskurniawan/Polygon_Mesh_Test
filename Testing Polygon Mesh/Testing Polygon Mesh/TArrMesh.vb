Public Class TArrMesh
    Public N As Integer
    Public Elmt() As TMesh

    Public Sub Init()
        N = 0
        ReDim Elmt(-1)
    End Sub

    Public Overloads Sub InsertLast(p1 As Integer, p2 As Integer, p3 As Integer)
        Dim P As TMesh
        P = New TMesh(p1, p2, p3)
        ReDim Preserve Elmt(N)
        Elmt(N) = P
        N = N + 1
    End Sub

    Public Function Count()
        Return N
    End Function
End Class