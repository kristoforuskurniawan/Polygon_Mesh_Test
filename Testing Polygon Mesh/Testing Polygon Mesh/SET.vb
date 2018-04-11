Public Class EdgeTable
    'updated
    Public ymin As Integer
    Public ymax As Integer
    Public xofymin As Integer
    Public dx As Integer
    Public dy As Integer
    Public carry As Integer
    Public normalize As Integer
    Public nxt As EdgeTable


    'by kevin
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

    'added by handy
    Public Sub New(ymin As Integer, ymax As Integer, xofymin As Integer, dx As Integer, dy As Integer, normalize As Integer, Optional carry As Integer = 0)
        Me.ymin = ymin
        Me.ymax = ymax
        Me.xofymin = xofymin
        Me.dx = dx
        Me.dy = dy
        Me.carry = carry
        Me.normalize = normalize
        nxt = Nothing
    End Sub
    'by kevin
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
