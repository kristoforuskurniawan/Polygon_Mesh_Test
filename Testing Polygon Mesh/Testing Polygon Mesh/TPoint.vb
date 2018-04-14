Public Class TPoint
    Public x, y, z, w As Double

    Public Sub New()
        x = 0
        y = 0
        z = 0
        w = 1
    End Sub

    Public Sub New(a As Double, b As Double, c As Double)
        x = a
        y = b
        z = c
        w = 1
    End Sub

    Public Sub SetPoints(a As Double, b As Double, c As Double)
        x = a
        y = b
        z = c
        w = 1
    End Sub
End Class
