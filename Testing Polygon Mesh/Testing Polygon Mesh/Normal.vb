Public Class Normalvalue
    Public x As Integer
    Public y As Integer
    Public z As Integer

    Public Sub New()
        x = 0
        y = 0
        z = 0
    End Sub

    Public Sub Calculate(Point1 As TPoint, Point2 As TPoint)
        x = Point1.y * Point2.z - Point1.z * Point2.y
        y = Point1.z * Point2.x - Point1.x * Point2.z
        z = Point1.x * Point2.y - Point1.y * Point2.x
    End Sub
End Class
