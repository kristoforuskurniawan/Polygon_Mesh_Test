Public Class EdgeTable
    'updated
    Public ymin As Integer
    Public ymax As Integer
    Public xofymin As Integer
    Public dx As Integer
    Public dy As Integer
    Public carry As Integer
    Public normalize As Integer
    Public zofymin As Integer
    Public PolygonColor As Color 'show which polygon the SET belong
    Public nxt As EdgeTable

    Public Sub New()
        ymin = Nothing
        ymax = Nothing
        xofymin = Nothing
        dx = Nothing
        dy = Nothing
        carry = Nothing
        normalize = Nothing
        nxt = Nothing
    End Sub

    Public Sub New(temp As EdgeTable)
        Me.ymin = temp.ymin
        Me.ymax = temp.ymax
        Me.xofymin = temp.xofymin
        Me.dx = temp.dx
        Me.dy = temp.dy
        Me.carry = temp.carry
        Me.normalize = temp.normalize
        nxt = Nothing
    End Sub
End Class
