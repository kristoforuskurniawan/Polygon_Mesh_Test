Public Class TMesh 'Triangle Mesh
    Public EdgeIndex1 As Integer
    Public EdgeIndex2 As Integer
    Public EdgeIndex3 As Integer

    Public Sub New()
        EdgeIndex1 = 0
        EdgeIndex2 = 0
        EdgeIndex3 = 0
    End Sub

    Public Sub New(ByVal EdgeIndex1 As Integer, ByVal EdgeIndex2 As Integer, ByVal EdgeIndex3 As Integer)
        Me.EdgeIndex1 = EdgeIndex1
        Me.EdgeIndex2 = EdgeIndex2
        Me.EdgeIndex3 = EdgeIndex3
    End Sub
End Class
