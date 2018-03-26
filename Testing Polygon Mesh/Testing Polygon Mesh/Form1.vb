Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private PointsArr As List(Of TPoint)
    Private EdgesArr As List(Of TLine)
    Private MeshesArr As List(Of TMesh)
    Private MeshList As TMeshList

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        PointsArr = New List(Of TPoint)
        EdgesArr = New List(Of TLine)
        MeshesArr = New List(Of TMesh)
        MeshList = New TMeshList()
    End Sub

    Private Sub DrawMeshButton_Click(sender As Object, e As EventArgs) Handles DrawMeshButton.Click

    End Sub
End Class
