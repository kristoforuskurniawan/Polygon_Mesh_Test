﻿Public Class TArrPoint
    Public x, y, z, w As Double
End Class
Public Class ListPoints
    Public N As Integer
    Public Elmt() As TPoint
    Public Sub Init()
        N = 0
        ReDim Elmt(-1)
    End Sub
    Public Overloads Sub InsertPoint(x As Double, y As Double, z As Double)
        Dim P As TPoint
        P = New TPoint
        P.x = x
        P.y = y
        P.z = z
        ReDim Preserve Elmt(N)
        Elmt(N) = P
        N = N + 1
    End Sub
End Class