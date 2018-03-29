Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private PointsArr As List(Of TPoint)
    Private EdgesArr As List(Of TLine)
    Private MeshesArr As List(Of TMesh)
    Private MeshList As TMeshList
    Private sphereRadius As Double

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        MainCanvas.Image = bitmapCanvas
        PointsArr = New List(Of TPoint)
        EdgesArr = New List(Of TLine)
        MeshesArr = New List(Of TMesh)
        MeshList = New TMeshList()
        sphereRadius = 0
    End Sub

    Private Sub DrawMeshButton_Click(sender As Object, e As EventArgs) Handles DrawMeshButton.Click

    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As EventArgs) Handles MainCanvas.Click

    End Sub

    Private Sub MainCanvas_Move(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        ScreenCoordLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub
End Class
