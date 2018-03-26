Public Class TLine
    Public PointIndex1 As Integer
    Public PointIndex2 As Integer

    Public Sub New()
        PointIndex1 = 0
        PointIndex2 = 0
    End Sub

    Public Sub New(ByVal PointIndex1 As Integer, ByVal PointIndex2 As Integer)
        Me.PointIndex1 = PointIndex1
        Me.PointIndex2 = PointIndex2
    End Sub
End Class
