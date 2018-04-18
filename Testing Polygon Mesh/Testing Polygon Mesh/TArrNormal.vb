Public Class TArrNormal
    Public Nx, Ny, Nz As Double
End Class

Public Class ListNormal
    Public N As Integer
    Public Elmt() As TArrNormal
    Public Sub Init()
        N = 0
        ReDim Elmt(-1)
    End Sub
    Public Overloads Sub InsertNormal(x As Double, y As Double, z As Double)
        Dim P As TArrNormal
        P = New TArrNormal
        P.Nx = x
        P.Ny = y
        P.Nz = z
        ReDim Preserve Elmt(N)
        Elmt(N) = P
        N = N + 1
    End Sub
End Class
