Public Class TPoint
    Public x, y, z, w As Double

    Public Sub New()
        x = 0
        y = 0
        z = 0
        w = 1
    End Sub

    Public Sub New(ByVal x As Double, ByVal y As Double, ByVal z As Double)
        Me.x = x
        Me.y = y
        Me.z = z
        w = 1
    End Sub
End Class
