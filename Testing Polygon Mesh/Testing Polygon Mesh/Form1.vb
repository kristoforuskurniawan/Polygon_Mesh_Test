Imports System.Runtime.InteropServices
Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private g As Graphics
    Private blackpen As Pen
    Private ListofVertice As List(Of TPoint)
    Private ListofEdges As List(Of TLine)
    Private ListofMeshes As List(Of TMesh)
    Private MeshList As TMeshList
    Private sphereRadius As Double
    Private longitude, latitude As Integer
    Dim PV As New Matrix4x4
    Private Status As Boolean

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
        longitude = 0
        latitude = 0
        Status = True
    End Sub

    Public Class Win32 'Ini class untuk apa?
        <DllImport("kernel32.dll")> Public Shared Function AllocConsole() As Boolean

        End Function
        <DllImport("kernel32.dll")> Public Shared Function FreeConsole() As Boolean

        End Function

    End Class


    Private Function dotproduct(x As Double(), y As Double()) As Double
        Dim d As Double = x(0) * y(0) + x(1) * y(1) + x(2) * y(2)
        Return If(d < 0, -d, 0)
        'asdf
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
        Dim radius As Integer = 10
        Dim angley As Integer = 0.1
        Dim anglez As Integer = 0.1
        Dim tempx, tempy, tempz As Double
        While anglez <= 90
            tempy = radius * Use_Sin(anglez)
            While angley <= 90
                tempx = radius * Use_Cos(angley)
                tempz = radius * Use_Sin(angley)
                SetVertices(tempx, tempy, tempz)
                SetVertices(tempx, tempy, -tempz)
                SetVertices(-tempx, tempy, tempz)
                SetVertices(-tempx, tempy, -tempz)
                SetVertices(tempx, -tempy, tempz)
                SetVertices(tempx, -tempy, -tempz)
                SetVertices(-tempx, -tempy, tempz)
                SetVertices(-tempx, -tempy, -tempz)

                angley += 15
            End While
            anglez += 15
            angley = 0.1
        End While

    End Sub

    Private Function Use_Cos(deg As Double)
        Return Math.Cos(convert_to_degree(deg))
    End Function

    Private Function Use_Sin(deg As Double)
        Return Math.Sin(convert_to_degree(deg))
    End Function

    Private Function convert_to_degree(x As Double)
        Return Math.PI * x / 180.0
    End Function

    Public Sub DrawCube(M As Matrix4x4)
        Dim size As Integer = ListofVertice.Count
        Dim obj(size) As TPoint
        For i As Integer = 0 To size - 1
            obj(i) = MultiplyMat(ListofVertice(i), M)
        Next
        Dim a, b, c, d As Single
        For i As Integer = 0 To size - 1
            a = obj(i).x
            b = obj(i).y
            For j As Integer = 0 To size - 1
                c = obj(j).x
                d = obj(j).y
                g.DrawLine(blackpen, a, b, c, d)
            Next
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
        sphereRadius = SphereRadInput.Text
        longitude = LongiInput.Text
        latitude = LatiInput.Text

        If sphereRadius = Nothing Or longitude = Nothing Or latitude = Nothing Or sphereRadius = 0 Or (latitude = 0 And longitude = 0) Then
            MessageBox.Show("Please give a proper input")
        Else

        End If

        Declare_Sphere()
        Projection()
        DrawCube(PV)
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
        'DrawCube(PV)
    End Sub

    Private Sub drawsphere()
        Dim size As Integer = ListofVertice.Count
        Dim obj(size) As TPoint
        For i As Integer = 0 To size - 1
            obj(i) = New TPoint
            obj(i) = MultiplyMat(ListofVertice(i), PV)
        Next
        Dim a, b, c, d As Single
        For i As Integer = 0 To size - 2
            a = obj(i).x
            b = obj(i).y
            c = obj(i + 1).x
            d = obj(i + 1).y
            g.DrawLine(blackpen, a, b, c, d)
        Next
    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As EventArgs) Handles MainCanvas.Click
        Status = True
        Win32.AllocConsole()
        Console.WriteLine(ListofVertice.Count)
        For i As Integer = 0 To ListofVertice.Count - 1
            Console.WriteLine(ListofVertice(i).x.ToString() + " " + ListofVertice(i).y.ToString() + " " + ListofVertice(i).z.ToString() + Environment.NewLine)
        Next
        If Status = False Then
            Win32.FreeConsole()
        End If

    End Sub

    Private Sub MainCanvas_Move(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        ScreenCoordLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub
End Class


