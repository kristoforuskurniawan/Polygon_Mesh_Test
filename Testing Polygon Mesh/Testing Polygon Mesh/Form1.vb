Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private g As Graphics
    Private blackpen As Pen
    Private PointsArr As List(Of TPoint)
    Private EdgesArr As List(Of TLine)
    Private MeshesArr As List(Of TMesh)
    Private MeshList As TMeshList
    Private sphereRadius As Double

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        g = Graphics.FromImage(bitmapCanvas)
        blackpen = New Pen(Color.Black, 0.5)
        MainCanvas.Image = bitmapCanvas
        PointsArr = New List(Of TPoint)
        EdgesArr = New List(Of TLine)
        MeshesArr = New List(Of TMesh)
        MeshList = New TMeshList()
        sphereRadius = 0
    End Sub


    Private Function dotproduct(x As Double(), y As Double()) As Double
        Dim d As Double = x(0) * y(0) + x(1) * y(1) + x(2) * y(2)
        Return If(d < 0, -d, 0)
    End Function

    Dim point1, point2, point3, point4, point5 As System.Drawing.Point

    Private Sub DrawMeshButton_Click(sender As Object, e As EventArgs) Handles DrawMeshButton.Click
        MainCanvas.Refresh()
        g = MainCanvas.CreateGraphics
        Dim i, r As Integer
        Dim x, y, z, s, q, p, px, py As Single
        Dim mx(600), my(600) As Integer
        s = PI / 4
        r = 100
        i = 1
        q = -PI / 2 + 0.1
        For p = 0 To 2 * PI Step 0.2
            x = r * Math.Cos(q) * Math.Sin(p)
            y = r * Math.Sin(q)
            z = r * Math.Cos(q) * Math.Cos(p)
            px = x * 1.2
            py = y - z * Math.Sin(s)
            mx(i) = px + 200
            my(i) = 150 - py
            i = i + 1
        Next p
        point1.X = mx(1) : point1.Y = my(1)
        For q = -PI / 2 + 0.2 To PI / 2 Step 0.2
            i = 1
            For p = 0 To 2 * PI Step 0.2
                x = r * Math.Cos(q) * Math.Sin(p)
                y = r * Math.Sin(q)
                z = r * Math.Cos(q) * Math.Cos(p)
                px = x * 1.2
                py = y - z * Math.Sin(s)

                point2.X = px + 200 : point2.Y = 150 - py
                g.DrawLine(blackpen, point1, point2)

                point1 = point2

                point3.X = mx(i) : point3.Y = my(i)
                point4.X = px + 200 : point4.Y = 150 - py
                g.DrawLine(blackpen, point3, point4)
                point3 = point4
                mx(i) = px + 200
                my(i) = 150 - py
                i = i + 1
            Next p
            p = 0
            x = r * Math.Cos(q) * Math.Sin(p)
            y = r * Math.Sin(q)
            z = r * Math.Cos(q) * Math.Cos(p)
            px = x * 1.2
            py = y - z * Math.Sin(s)

            point5.X = px + 200 : point5.Y = 150 - py
            g.DrawLine(blackpen, point4, point5)
            point4 = point5
        Next q
    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As EventArgs) Handles MainCanvas.Click

    End Sub

    Private Sub MainCanvas_Move(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        ScreenCoordLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub
End Class
