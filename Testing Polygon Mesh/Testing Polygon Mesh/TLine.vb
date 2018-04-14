Public Class TLine 'Class ini ga dipakai sepertinya...
    Public PointIndex1 As Integer
    Public PointIndex2 As Integer
    Public poly1 As Integer 'For shared edge
    Public poly2 As Integer

    Public Sub New()
        PointIndex1 = 0
        PointIndex2 = 0
        poly1 = Nothing
        poly2 = Nothing
    End Sub

    Public Sub New(ByVal PointIndex1 As Integer, ByVal PointIndex2 As Integer, p1 As Integer, p2 As Integer)
        Me.PointIndex1 = PointIndex1
        Me.PointIndex2 = PointIndex2
        poly1 = p1
        poly2 = p2
    End Sub
End Class
