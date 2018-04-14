Public Class TArrMesh
    Public N As Integer
    Public Elmt() As TMesh
    Public Normal() As Normalvalue

    Public Sub Init()
        N = 0
        ReDim Elmt(-1)
        ReDim Normal(-1)
    End Sub

    Public Overloads Sub InsertLast(p1 As Integer, p2 As Integer, p3 As Integer)
        Dim P As TMesh
        P = New TMesh()
        P.EdgeIndex1 = p1
        P.EdgeIndex2 = p2
        P.EdgeIndex3 = p3
        ReDim Preserve Elmt(N)
        ReDim Preserve Normal(N)
        Elmt(N) = P
        Normal(N) = New Normalvalue
        N = N + 1
    End Sub

    Public Function Count()
        Return N
    End Function

    Public Function DeleteAllData() As TArrMesh
        For i = 0 To N - 1
            Me.Elmt(i) = Nothing
        Next
        Init()
        Return Me
    End Function
End Class