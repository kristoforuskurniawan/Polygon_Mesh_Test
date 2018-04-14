Public Class TArrMesh
    Public N As Integer
    Public Elmt() As TMesh

    Public Sub Init()
        N = 0
        ReDim Elmt(-1)
    End Sub

    Public Overloads Sub InsertLast(p1 As Integer, p2 As Integer, p3 As Integer)
        Dim P As TMesh
        P = New TMesh()
        P.EdgeIndex1 = p1
        P.EdgeIndex2 = p2
        P.EdgeIndex3 = p3
        ReDim Preserve Elmt(N)
        Elmt(N) = P
        N = N + 1
    End Sub

    Public Function Count()
        Return N
    End Function
End Class