Public Class TLine
    Public Point1 As TPoint
    Public Point2 As TPoint

    Public Sub New()
        Point1 = New TPoint()
        Point2 = New TPoint()
    End Sub

    Public Sub New(ByRef Point1 As TPoint, ByRef Point2 As TPoint)
        Me.Point1 = Point1
        Me.Point2 = Point2
    End Sub
End Class
