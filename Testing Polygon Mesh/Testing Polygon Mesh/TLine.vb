Public Class TLine
    Public Point1 As TPoint
    Public Point2 As TPoint
    Public Poly1 As Integer
    Public Poly2 As Integer

    Public Sub New()
        Point1 = New TPoint()
        Point2 = New TPoint()
        Poly1 = Nothing
        Poly2 = Nothing
    End Sub

    Public Sub New(ByRef Point1 As TPoint, ByRef Point2 As TPoint, p1 As Integer, p2 As Integer)
        Me.Point1 = Point1
        Me.Point2 = Point2
        Poly1 = p1
        Poly2 = p2
    End Sub
End Class
