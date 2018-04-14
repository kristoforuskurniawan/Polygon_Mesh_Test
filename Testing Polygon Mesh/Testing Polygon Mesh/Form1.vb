Imports System.Runtime.InteropServices
Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private graphics As Graphics
    Private whitepen As Pen
    Private ListPoints As ListPoints
    Private ListPolygon As ListPolygons
    Private sphereCenter, surfaceNormal As TPoint
    Private mesh As TMesh
    'Private ListofEdges As List(Of TLine)
    'Private ListofMeshes As TArrMesh
    Private L, N, V, R As Normalvalue 'Vectors to calculate intensity
    Private LightSource As TPoint
    Private radius, dtheta, du, theta, u, x, y, z, w As Double
    Private longitude, latitude, transSphere_X, transSphere_Y, transSphere_Z As Integer
    Private PV As New Matrix4x4
    Private p1, p2, p3 As Integer
    Private ka, kd, ks, ki, intentAmb, intentDiff, intentSpec, intentLight, iTot As Double
    Private Status, backFaceCullingStatus As Boolean
    Private RotX, RotY, RotZ As Boolean

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        graphics = Graphics.FromImage(bitmapCanvas)
        whitepen = New Pen(Color.White)
        MainCanvas.Image = bitmapCanvas
        ListPoints = New ListPoints()
        ListPolygon = New ListPolygons()
        LightSource = New TPoint()
        sphereCenter = New TPoint(0, 0, 0)
        intentLight = 1
        'sphereCenter = New TPoint(MainCanvas.Width / 2 - 1, MainCanvas.Height / 2 - 1, 0)
        'mesh = New TMesh()
        'ListPoints.Init()
        'ListPolygon.Init()
        'ListofEdges = New List(Of TLine)
        'ListofMeshes = New TArrMesh()
        ''ListofMeshes.Init()
        'PV = New Matrix4x4()

        ''Vt = PV.insertColumnMatrix(Vt, 0, 1, 0, 0, 0)
        ''Vt = PV.insertColumnMatrix(Vt, 1, 0, 1, 0, 0)
        ''Vt = PV.insertColumnMatrix(Vt, 2, 0, 0, 0, -1 / 10)
        ''Vt = PV.insertColumnMatrix(Vt, 3, 0, 0, 0, 1)

        'St = PV.insertColumnMatrix(St, 0, 1, 0, 0, 200)
        'St = PV.insertColumnMatrix(St, 1, 0, -1, 0, 200)
        'St = PV.insertColumnMatrix(St, 2, 0, 0, 0, 0)
        'St = PV.insertColumnMatrix(St, 3, 0, 0, 0, 1)

        'PV.Mat = MultiplyMat4x4(Vt, St)
        SphereRadInput.Enabled = False
        SphereRadInput.Text = 1
        LongiInput.Text = 30
        LatiInput.Text = 30
        transSphere_X = 0
        transSphere_Y = 0
        transSphere_Z = 0
        X_TransTextBox.Text = transSphere_X
        Y_TransTextBox.Text = transSphere_Y
        Z_TransTextBox.Text = transSphere_Z
        Projection()
        'DrawSphere()
        radius = Integer.Parse(SphereRadInput.Text) * 150
        latitude = Integer.Parse(LatiInput.Text)
        longitude = Integer.Parse(LongiInput.Text)
        DrawSphere()
        'Status = True
    End Sub

    Private Function getUnitVector(ByRef Vector As TPoint) As TPoint
        Dim divisor As Double = Math.Sqrt((Vector.x * Vector.x) + (Vector.y * Vector.y) + (Vector.z * Vector.z))
        Dim result As New TPoint(Vector.x / divisor, Vector.y / divisor, Vector.z / divisor)
        Return result
    End Function

    Private Function dotproduct(x As Double(), y As Double()) As Double
        Dim d As Double = x(0) * y(0) + x(1) * y(1) + x(2) * y(2)
        Return If(d < 0, -d, 0)
    End Function

    Private Sub translateButton_Click_1(sender As Object, e As EventArgs) Handles TranslateButton.Click
        graphics.Clear(Color.Black)
        transSphere_X = transSphere_X + Integer.Parse(X_TransTextBox.Text)
        transSphere_Y = transSphere_Y + Integer.Parse(Y_TransTextBox.Text)
        transSphere_Z = transSphere_Z + Integer.Parse(Z_TransTextBox.Text)
        Dim Vt, St As New Matrix4x4
        PV = New Matrix4x4
        Vt.OnePointProjection(5)
        St.TranslateMat(200 + transSphere_X, 200 + transSphere_Y, 0 + transSphere_Z)
        PV.Mat = MultiplyMat4x4(Vt, St)
        DrawSphere()
    End Sub

    'Public Sub SetVertices(x As Double, y As Double, z As Double)
    '    Dim temp As New TPoint(x, y, z)
    '    ListPoints.InsertLast(temp.x, temp.y, temp.z)
    'End Sub

    'Public Sub SetEdges(x As Integer, y As Integer, a As Integer, b As Integer)
    '    Dim temp As New TLine(x, y, a, b)
    '    ListofEdges.Add(temp)
    'End Sub

    'Private Sub DeclareSphere()
    '    sphereRadius = Double.Parse(SphereRadInput.Text)
    '    longitude = Integer.Parse(LongiInput.Text)
    '    latitude = Integer.Parse(LatiInput.Text)
    '    'Dim radius As Integer = 10
    '    'Dim angley As Integer = 0
    '    'Dim anglez As Integer = 0
    '    'Dim tempx, tempy, tempz As Double
    '    'While anglez <= 90
    '    '    tempy = radius * Use_Sin(anglez)
    '    '    While angley <= 360
    '    '        tempx = radius * Use_Cos(angley)
    '    '        tempz = radius * Use_Sin(angley)
    '    '        SetVertices(tempx, tempy, tempz)
    '    '        SetVertices(tempx, -tempy, tempz)
    '    '        angley += 15
    '    '    End While
    '    '    anglez += 15
    '    '    angley = 0
    '    'End While
    'End Sub

    'Private Function getCrossProduct(ByRef Vector1 As TPoint, ByRef Vector2 As TPoint)
    '    Return New TPoint(Vector1.y * Vector2.z - Vector1.z * Vector2.y, Vector1.z * Vector2.x - Vector1.x * Vector2.z, Vector1.x * Vector2.y - Vector1.y * Vector2.x)
    'End Function

    'Private Sub calculateSurfaceNormal(ByRef Point1 As TPoint, ByRef Point2 As TPoint, ByRef Point3 As TPoint) 'Urutan tiga point udah counter clockwise
    '    Dim P1_P2, P1_P3 As TPoint
    '    P1_P2 = New TPoint(Point2.x - Point1.x, Point2.y - Point1.y, Point2.z - Point1.z)
    '    P1_P3 = New TPoint(Point3.x - Point1.x, Point3.y - Point1.y, Point3.z - Point1.z)
    '    surfaceNormal = getCrossProduct(P1_P2, P1_P3)
    'End Sub

    Private Sub AddLightButton_Click(sender As Object, e As EventArgs) Handles AddLightButton.Click
        If Light_XPosTextBox.Text <> "" And Light_YPosTextBox.Text <> "" And Light_ZPosTextBox.Text <> "" Then
            LightSource.SetPoints(Double.Parse(Light_XPosTextBox.Text), Double.Parse(Light_YPosTextBox.Text), Double.Parse(Light_ZPosTextBox.Text))
            MessageBox.Show(LightSource.x & ", " & LightSource.y & ", " & LightSource.z)
            Dim rect As New Rectangle()
            graphics.DrawEllipse(whitepen, rect)
        End If
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub Rotate_XButton_Click(sender As Object, e As EventArgs) Handles Rotate_XButton.Click
        RotX = True
        RotY = False
        RotZ = False
        AnimationTimer.Enabled = True
    End Sub

    Private Sub Rotate_YButton_Click(sender As Object, e As EventArgs) Handles Rotate_YButton.Click
        RotX = False
        RotY = True
        RotZ = False
        AnimationTimer.Enabled = True
    End Sub

    Private Sub DoShadingButton_Click(sender As Object, e As EventArgs) Handles DoShadingButton.Click
        If ambientTxtBox.Text <> "" And specularTxtBox.Text <> "" And diffuseTxtBox.Text <> "" Then
            ka = ambientTxtBox.Text
            ks = specularTxtBox.Text
            kd = diffuseTxtBox.Text
        Else
            MessageBox.Show("Please fill the coefficient for each!")
        End If
    End Sub

    Private Sub Rotate_ZButton_Click(sender As Object, e As EventArgs) Handles Rotate_ZButton.Click
        RotX = False
        RotY = False
        RotZ = True
        AnimationTimer.Enabled = True
    End Sub

    Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs) Handles AnimationTimer.Tick
        If RotX Then
            graphics.Clear(Color.Black)
            PV.RotateX(0.344)
            DrawSphere()
        ElseIf RotY Then
            graphics.Clear(Color.Black)
            PV.RotateY(0.344)
            DrawSphere()
        Else
            graphics.Clear(Color.Black)
            PV.RotateZ(0.344)
            DrawSphere()
        End If
    End Sub

    Private Sub BackCullOFF_BTN_CheckedChanged(sender As Object, e As EventArgs)
        backFaceCullingStatus = False
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

    Private Function CountPhong(ka As Double, ia As Double, kd As Double, il As Double, deg As Double, ks As Double, kl As Double, n As Integer, alpha As Double)
        Return ((ka * ia) + (kd * il * Use_Cos(deg)) + (ks * il * Math.Pow(Use_Cos(alpha), n)))
    End Function

    Private Function GetPhong()

    End Function

    Private Sub Projection()
        Dim Vt, St As New Matrix4x4
        PV = New Matrix4x4
        Vt.OnePointProjection(5) ' Zc = 3
        St.TranslateMat(200, 200, 0) 'translate
        PV.Mat = MultiplyMat4x4(Vt, St)
        Console.WriteLine(PV.Mat(0, 0)) 'baris,kolom
        Console.WriteLine(PV.Mat(0, 1))
        Console.WriteLine(PV.Mat(0, 2))
        Console.WriteLine(PV.Mat(0, 3))
        Console.WriteLine(PV.Mat(1, 0))
        Console.WriteLine(PV.Mat(1, 1))
        Console.WriteLine(PV.Mat(1, 2))
        Console.WriteLine(PV.Mat(1, 3))
        Console.WriteLine(PV.Mat(2, 0))
        Console.WriteLine(PV.Mat(2, 1))
        Console.WriteLine(PV.Mat(2, 2))
        Console.WriteLine(PV.Mat(2, 3))
        Console.WriteLine(PV.Mat(3, 0))
        Console.WriteLine(PV.Mat(3, 1))
        Console.WriteLine(PV.Mat(3, 2))
        Console.WriteLine(PV.Mat(3, 3))
    End Sub

    Private Sub DrawMeshButton_Click(sender As Object, e As EventArgs) Handles DrawMeshButton.Click
        If SphereRadInput.Text = "" Or LongiInput.Text = "" Or LatiInput.Text = "" Then
            MessageBox.Show("Please give a proper input")
        Else
            Dim lat, longi As Integer
            lat = Integer.Parse(LatiInput.Text)
            longi = Integer.Parse(LongiInput.Text)
            If (lat Mod 2 = 0) And (longi Mod 2 = 0) Then
                graphics.Clear(Color.Black)
                latitude = lat
                longitude = longi
                ' radius = Double.Parse(SphereRadInput.Text) * 150
                Projection()
                DrawSphere()
            Else
                MessageBox.Show("The number of longitude and latitude must be an even number ",
                                "Value Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub DrawSphere()
        ListPoints = New ListPoints
        ListPolygon = New ListPolygons
        dtheta = 180 / latitude
        du = 360 / longitude
        For i = 0 To latitude / 2 - 1
            theta = dtheta * i
            For j = 0 To longitude - 1
                u = du * j
                x = radius * Math.Cos(theta * Math.PI / 180) * Math.Sin(u * Math.PI / 180)
                y = radius * Math.Sin(theta * Math.PI / 180)
                z = radius * Math.Cos(theta * Math.PI / 180) * Math.Cos(u * Math.PI / 180)
                w = 1
                ListPoints.InsertPoint(x, y, z)
            Next
        Next
        ListPoints.InsertPoint(0, radius, 0)
        For i = 0 To (-latitude / 2) + 1 Step -1
            theta = dtheta * i
            For j = 0 To longitude - 1
                u = du * j
                x = radius * Math.Cos(theta * Math.PI / 180) * Math.Sin(u * Math.PI / 180)
                y = radius * Math.Sin(theta * Math.PI / 180)
                z = radius * Math.Cos(theta * Math.PI / 180) * Math.Cos(u * Math.PI / 180)
                w = 1
                ListPoints.InsertPoint(x, y, z)
            Next
        Next
        ListPoints.InsertPoint(0, -radius, 0)
        For i = 0 To latitude / 2 - 1 'm=latitude
            If i <= latitude / 2 - 2 Then 'n=longitude
                For j = 0 To longitude - 2
                    p1 = longitude * i + j
                    p2 = longitude * (i + 1) + j + 1
                    p3 = longitude * (i + 1) + j
                    ListPolygon.InsertIndex(p1, p2, p3)
                    p1 = longitude * i + j
                    p2 = longitude * i + j + 1
                    p3 = longitude * (i + 1) + j + 1
                    ListPolygon.InsertIndex(p1, p2, p3)
                Next
                p1 = longitude * (i + 1) - 1
                p2 = longitude * (i + 1)
                p3 = longitude * (i + 2) - 1
                ListPolygon.InsertIndex(p1, p2, p3)
                p1 = longitude * (i + 1) - 1
                p2 = longitude * i
                p3 = longitude * (i + 1)
                ListPolygon.InsertIndex(p1, p2, p3)
            Else
                For j = 0 To longitude - 2
                    p1 = longitude * i + j
                    p2 = longitude * i + j + 1
                    p3 = latitude / 2 * longitude
                    ListPolygon.InsertIndex(p1, p2, p3)
                Next
                p1 = longitude * (i + 1) - 1
                p2 = longitude * i
                p3 = longitude * (i + 1)
                ListPolygon.InsertIndex(p1, p2, p3)
            End If
        Next
        For i = 0 To (-latitude / 2) + 1 Step -1
            If i >= (-latitude / 2) + 2 Then
                For j = 0 To longitude - 2
                    p1 = (longitude * (-i + 1)) + j + (latitude / 2 * longitude) + 1 '(m / 2 * n) + n + j + 1 '13 + j 'n * i + j 
                    p2 = (longitude * -i + j + 1) + (latitude / 2 * longitude) + 1 '(m / 2 * n) + j + 2 '10 + j 'n * (i + 1) + j + 1
                    p3 = (longitude * -i + j) + (latitude / 2 * longitude) + 1 '(m / 2 * n) + j + 1 '9 + j 'n * (i + 1) + j
                    ListPolygon.InsertIndex(p1, p2, p3)
                    p1 = (longitude * (-i + 1)) + j + (latitude / 2 * longitude) + 1 '(m / 2 * n) + n + j + 1 ' n * i + j 13
                    p2 = (longitude * (-i + 1) + j + 1) + (latitude / 2 * longitude) + 1 '14 + j ' n * i + j + 1 
                    p3 = (longitude * -i + j + 1) + (latitude / 2 * longitude) + 1 '10 + j 'n * (i + 1) + j + 1
                    ListPolygon.InsertIndex(p1, p2, p3)
                Next
                p1 = (longitude * (-i + 2) - 1) + (latitude / 2 * longitude) + 1 '16 'n * (i + 1) - 1
                p2 = (longitude * -i) + (latitude / 2 * longitude) + 1 '9 'n * (i + 1)
                p3 = (longitude * (-i + 1) - 1) + (latitude / 2 * longitude) + 1 '12 'n * (i + 2) - 1
                ListPolygon.InsertIndex(p1, p2, p3)
                p1 = (longitude * (-i + 2) - 1) + (latitude / 2 * longitude) + 1 '16 'n * (i + 1) - 1
                p2 = (longitude * (-i + 1)) + (latitude / 2 * longitude) + 1 '13 ' n * i
                p3 = (longitude * -i) + (latitude / 2 * longitude) + 1 ' 9 'n * (i + 1)
                ListPolygon.InsertIndex(p1, p2, p3)
            Else
                For j = 0 To longitude - 2
                    p1 = (longitude * -i + j) + ((latitude / 2 * longitude) + 1) ' 13 + j 'n * i + j
                    p2 = (longitude * -i + j + 1) + (latitude / 2 * longitude) + 1 '14
                    p3 = (latitude / 2 * longitude) + (latitude / 2 * longitude) + 1 '17
                    ListPolygon.InsertIndex(p1, p2, p3)
                Next
                p1 = (longitude * (-i + 1) - 1) + (latitude / 2 * longitude) + 1 '16
                p2 = (longitude * -i) + (latitude / 2 * longitude) + 1 '13
                p3 = (longitude * (-i + 1)) + (latitude / 2 * longitude) + 1 '17
                ListPolygon.InsertIndex(p1, p2, p3)
            End If
        Next
        gambarpoly()
        MainCanvas.Image = bitmapCanvas
    End Sub

    Public Sub gambarpoly()
        Dim m1, m2, m3, m4, m5, m6, m11, m22, m33, m44, m55, m66 As Double
        Dim p1, p2, p3 As Integer
        Dim temp As New ListPolygons()
        BackFaceCulling()
        Dim DOP(3) As Integer
        DOP(0) = 0
        DOP(1) = 0
        DOP(2) = -10
        For i = 0 To ListPolygon.N - 1
            If dotproduct2(DOP, ListPolygon.Normal(i)) < 0 Then
                p1 = ListPolygon.Elmt(i).p1
                p2 = ListPolygon.Elmt(i).p2
                p3 = ListPolygon.Elmt(i).p3
                temp.Init()
                temp.InsertIndex(p1, p2, p3)
                MultiplyPV(p1, p2, p3, m1, m2, m3, m4, m5, m6)
                SurfaceDetection(temp)
                graphics.DrawLine(whitepen, New Point(m1, m2), New Point(m3, m4))
                graphics.DrawLine(whitepen, New Point(m3, m4), New Point(m5, m6))
                graphics.DrawLine(whitepen, New Point(m5, m6), New Point(m1, m2)) 'x
            End If
        Next
    End Sub

    Private Sub SurfaceDetection(temp As ListPolygons)
        Dim edgetable As New List(Of EdgeTable) 'SET
        Dim AET As New AEL
        Dim stacker As New Stack(Of EdgeTable)

    End Sub


    Private Sub MultiplyPV(p1 As Integer, p2 As Integer, p3 As Integer, ByRef m1 As Double, ByRef m2 As Double, ByRef m3 As Double, ByRef m4 As Double, ByRef m5 As Double, ByRef m6 As Double)

        m1 = ListPoints.Elmt(p1).x * PV.Mat(0, 0) + ListPoints.Elmt(p1).y * PV.Mat(0, 1) + ListPoints.Elmt(p1).z * PV.Mat(0, 2) + 1 * PV.Mat(0, 3)
        m2 = ListPoints.Elmt(p1).x * PV.Mat(1, 0) + ListPoints.Elmt(p1).y * PV.Mat(1, 1) + ListPoints.Elmt(p1).z * PV.Mat(1, 2) + 1 * PV.Mat(1, 3)
        m3 = ListPoints.Elmt(p2).x * PV.Mat(0, 0) + ListPoints.Elmt(p2).y * PV.Mat(0, 1) + ListPoints.Elmt(p2).z * PV.Mat(0, 2) + 1 * PV.Mat(0, 3)
        m4 = ListPoints.Elmt(p2).x * PV.Mat(1, 0) + ListPoints.Elmt(p2).y * PV.Mat(1, 1) + ListPoints.Elmt(p2).z * PV.Mat(1, 2) + 1 * PV.Mat(1, 3)
        m5 = ListPoints.Elmt(p3).x * PV.Mat(0, 0) + ListPoints.Elmt(p3).y * PV.Mat(0, 1) + ListPoints.Elmt(p3).z * PV.Mat(0, 2) + 1 * PV.Mat(0, 3)
        m6 = ListPoints.Elmt(p3).x * PV.Mat(1, 0) + ListPoints.Elmt(p3).y * PV.Mat(1, 1) + ListPoints.Elmt(p3).z * PV.Mat(1, 2) + 1 * PV.Mat(1, 3) 'test

    End Sub

    Private Sub MainCanvas_Move(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        ScreenCoordLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub


    Private Function dotproduct2(x As Integer(), normal As Normalvalue) As Integer
        Dim d As Integer = x(0) * normal.x + x(1) * normal.y + x(2) * normal.z
        Return d
    End Function

    Private Sub CalculateNormal(poly As ListPolygons)
        Dim ppp As New TMesh
        Dim p1, p2, p3, m1, m2, m3, m4, m5, m6 As Integer
        Dim AB, AC As TPoint
        For i As Integer = 0 To poly.N - 1
            p1 = ListPolygon.Elmt(i).p1
            p2 = ListPolygon.Elmt(i).p2
            p3 = ListPolygon.Elmt(i).p3
            AB = New TPoint(ListPoints.Elmt(p2).x - ListPoints.Elmt(p1).x, ListPoints.Elmt(p2).y - ListPoints.Elmt(p1).y, ListPoints.Elmt(p2).z - ListPoints.Elmt(p1).z)
            AC = New TPoint(ListPoints.Elmt(p3).x - ListPoints.Elmt(p1).x, ListPoints.Elmt(p3).y - ListPoints.Elmt(p1).y, ListPoints.Elmt(p3).z - ListPoints.Elmt(p1).z)
            poly.Normal(i).CrossProduct(AB, AC)
        Next
    End Sub

    Private Sub BackFaceCulling()
        CalculateNormal(ListPolygon)
        Dim DOP(3) As Double
    End Sub
End Class