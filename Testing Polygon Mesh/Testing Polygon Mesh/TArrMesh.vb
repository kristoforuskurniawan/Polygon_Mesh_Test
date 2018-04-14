Public Class TArrMesh
    Public p1, p2, p3 As Integer
End Class

Public Class ListPolygons
    Public N As Integer
    Public Elmt() As TArrMesh
    Public Normal() As Normalvalue
    Public Sub Init()
        N = 0
        ReDim Elmt(-1)
        ReDim Normal(-1)
    End Sub
    Public Overloads Sub InsertIndex(p1 As Integer, p2 As Integer, p3 As Integer)
        Dim P As TArrMesh
        P = New TArrMesh
        P.p1 = p1
        P.p2 = p2
        P.p3 = p3
        ReDim Preserve Elmt(N)
        ReDim Preserve Normal(N)
        Elmt(N) = P
        Normal(N) = New Normalvalue
        N = N + 1
    End Sub
End Class