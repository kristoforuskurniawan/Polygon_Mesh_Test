Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private ListofVertice As List(Of TPoint)
    Private ListofEdges As List(Of TLine)
    Private ListofMeshes As List(Of TMesh)
    Private MeshList As TMeshList
    Private sphereRadius As Double

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        MainCanvas.Image = bitmapCanvas
        ListofVertice = New List(Of TPoint)
        ListofEdges = New List(Of TLine)
        ListofMeshes = New List(Of TMesh)
        MeshList = New TMeshList()
        sphereRadius = 0
    End Sub

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

    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As EventArgs) Handles MainCanvas.Click

    End Sub

    Private Sub MainCanvas_Move(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        ScreenCoordLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub
End Class
