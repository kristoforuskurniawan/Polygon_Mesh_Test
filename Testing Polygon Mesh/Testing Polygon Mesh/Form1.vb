Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private g As Graphics
    Private blackpen As Pen
    Private ListofVertice As List(Of TPoint)
    Private ListofEdges As List(Of TLine)
    Private ListofMeshes As List(Of TMesh)
    Private MeshList As TMeshList
    Private sphereRadius As Double

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        g = Graphics.FromImage(bitmapCanvas)
        blackpen = New Pen(Color.Black, 0.5)
        MainCanvas.Image = bitmapCanvas
        ListofVertice = New List(Of TPoint)
        ListofEdges = New List(Of TLine)
        ListofMeshes = New List(Of TMesh)
        MeshList = New TMeshList()
        sphereRadius = 0
    End Sub


    Private Function dotproduct(x As Double(), y As Double()) As Double
        Dim d As Double = x(0) * y(0) + x(1) * y(1) + x(2) * y(2)
        Return If(d < 0, -d, 0)
    End Function

    Dim point1, point2, point3, point4, point5 As System.Drawing.Point

    Private Sub DrawMeshButton_Click(sender As Object, e As EventArgs) Handles DrawMeshButton.Click
        Dim temp As New TPoint
        Dim x, y, z As Double
        Dim hl, vl, radius As Integer 'horizontal lines and vertical lines
        hl = 10
        vl = 10
        radius = 100
        For m As Integer = 0 To hl 'horizontalLines
            For n As Integer = 0 To vl - 1 'verticalLines - 1
                x = Math.Sin(Math.PI * m / hl) * Math.Cos(2 * Math.PI * n / vl) * radius
                y = Math.Sin(Math.PI * m / hl) * Math.Sin(2 * Math.PI * n / vl) * radius
                z = Math.Cos(Math.PI * m / hl) * radius
                temp = New TPoint(x, y, z)
            Next
        Next
        drawsphere()
    End Sub

    Private Sub drawsphere()
        For i As Integer = 0 To ListofVertice.Count - 1

            g.DrawSphere(ListofVertice, 0.1F)
        Next
    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As EventArgs) Handles MainCanvas.Click

    End Sub

    Private Sub MainCanvas_Move(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        ScreenCoordLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub
End Class
