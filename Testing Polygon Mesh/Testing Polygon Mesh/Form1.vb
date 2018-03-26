Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private PointsList As List(Of TPoint)

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        PointsList = New List(Of TPoint)
    End Sub

    Private Sub DrawMeshButton_Click(sender As Object, e As EventArgs) Handles DrawMeshButton.Click

    End Sub
End Class
