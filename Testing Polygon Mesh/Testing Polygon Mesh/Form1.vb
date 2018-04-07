Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private g As Graphics
    Private blackpen As Pen
    Private ListofVertice As List(Of TPoint)
    Private ListofEdges As List(Of TLine)
    Private ListofMeshes As List(Of TMesh)
    Private MeshList As TMeshList
    Private sphereRadius As Double
    Dim PV As New Matrix4x4

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        g = Graphics.FromImage(bitmapCanvas)
        blackpen = New Pen(Color.Black)
        MainCanvas.Image = bitmapCanvas
        ListofVertice = New List(Of TPoint)
        ListofEdges = New List(Of TLine)
        ListofMeshes = New List(Of TMesh)
        MeshList = New TMeshList()
        sphereRadius = 0
        Declare_Sphere()
        Projection()
    End Sub


    Private Function dotproduct(x As Double(), y As Double()) As Double
        Dim d As Double = x(0) * y(0) + x(1) * y(1) + x(2) * y(2)
        Return If(d < 0, -d, 0)
    End Function

    Public Sub SetVertices(x As Double, y As Double, z As Double)
        Dim temp As New TPoint(x, y, z)
        ListofVertice.Add(temp)
    End Sub

    Public Sub SetEdges(x As Integer, y As Integer, a As Integer, b As Integer)
        Dim temp As New TLine(x, y, a, b)
        ListofEdges.Add(temp)
    End Sub

    Private Sub Declare_Sphere()
        SetVertices(7, 0, 1)
        SetVertices(-7, 0, 1)
        SetVertices(0, 7, 1)
        SetVertices(0, -7, 1)
        SetVertices(6, 6, 1)
        SetVertices(-6, -6, 1)
        SetVertices(6, -6, 1)
        SetVertices(-6, 6, 1)

        SetVertices(5, 0, 3)
        SetVertices(-5, 0, 3)
        SetVertices(0, 5, 3)
        SetVertices(0, -5, 3)
        SetVertices(4, 4, 3)
        SetVertices(4, -4, 3)
        SetVertices(4, -4, 3)
        SetVertices(-4, 4, 3)

        SetVertices(3, 0, 5)
        SetVertices(-3, 0, 5)
        SetVertices(0, 3, 5)
        SetVertices(0, -3, 5)
        SetVertices(3, 3, 5)
        SetVertices(-3, -3, 5)
        SetVertices(3, 3, 5)
        SetVertices(-3, 3, 5)

        SetVertices(1, 0, 7)
        SetVertices(-1, 0, 7)
        SetVertices(0, 1, 7)
        SetVertices(0, -1, 7)
        SetVertices(0.5, 0.5, 7)
        SetVertices(-0.5, -0.5, 7)
        SetVertices(0.5, -0.5, 7)
        SetVertices(-0.5, 0.5, 7)

    End Sub

    Public Sub DrawCube(M As Matrix4x4)
        Dim obj(32) As TPoint
        For i As Integer = 0 To 31
            obj(i) = MultiplyMat(ListofVertice(i), M)
        Next
        Dim a, b, c, d As Single
        For i As Integer = 0 To 
            a = obj(i).x
            b = obj(i).y
            'For j As Integer = 0 To 31
            c = obj(i + 1).x
            d = obj(i + 1).y
            g.DrawLine(blackpen, a, b, c, d)
            'Next
        Next
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub Projection()
        Dim Vt, St As New Matrix4x4
        PV = New Matrix4x4
        Vt.OnePointProjection(20) ' Zc = 3
        St.ScaleMat(7, -7, 0) ' scale
        St.TranslateMat(200, 200, 0) 'translate
        PV.Mat = MultiplyMat4x4(Vt, St)
    End Sub

    Private Sub DrawMeshButton_Click(sender As Object, e As EventArgs) Handles DrawMeshButton.Click
        'Dim temp As New TPoint
        'Dim x, y, z As Double
        'Dim hl, vl, radius As Integer 'horizontal lines and vertical lines
        'hl = 10
        'vl = 10
        'radius = 100
        'For m As Integer = 0 To hl 'horizontalLines
        '    For n As Integer = 0 To vl - 1 'verticalLines - 1
        '        x = Math.Sin(Math.PI * m / hl) * Math.Cos(2 * Math.PI * n / vl) * radius
        '        y = Math.Sin(Math.PI * m / hl) * Math.Sin(2 * Math.PI * n / vl) * radius
        '        z = Math.Cos(Math.PI * m / hl) * radius
        '        temp = New TPoint(x, y, z)
        '    Next
        'Next
        'drawsphere()
        DrawCube(PV)
    End Sub

    Private Sub drawsphere()
        Dim a, b, c, d As Single
        For i As Integer = 0 To ListofVertice.Count - 2
            a = ListofVertice(i).x
            b = ListofVertice(i).y
            c = ListofVertice(i + 1).x
            d = ListofVertice(i + 1).y
            g.DrawLine(blackpen, a, b, c, d)
        Next
    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As EventArgs) Handles MainCanvas.Click

    End Sub

    Private Sub MainCanvas_Move(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        ScreenCoordLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub
End Class
