Imports System.Runtime.InteropServices
Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private graphics As Graphics
    Private whitepen As Pen
    Private bluepen As Pen
    Private ListPoints As ListPoints
    Private ListPolygon As ListPolygons
    Private sphereCenter, surfaceNormal, surfacePoint As TPoint
    Private mesh As TMesh
    'Private ListofEdges As List(Of TLine)
    'Private ListofMeshes As TArrMesh
    Private L, N, V, R As Normalvalue 'Vectors to calculate intensity
    Private LightSource As TPoint
    Private radius, dtheta, du, theta, u, x, y, z, w As Double
    Private longitude, latitude, transSphere_X, transSphere_Y, transSphere_Z As Integer
    Private PV As New Matrix4x4
    Private p1, p2, p3 As Integer
    Private ka, kd, ks, ki, intentAmb, intentDiff, intentSpec, intentLight, iTot, expon As Double
    Private Status, backFaceCullingStatus As Boolean


    Private RotX, RotY, RotZ As Boolean

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        graphics = graphics.FromImage(bitmapCanvas)
        whitepen = New Pen(Color.White)
        bluepen = New Pen(Color.Blue)
        MainCanvas.Image = bitmapCanvas
        ListPoints = New ListPoints()
        ListPolygon = New ListPolygons()
        LightSource = New TPoint()
        sphereCenter = New TPoint(0, 0, 0)
        surfacePoint = New TPoint()
        PV = New Matrix4x4()
        intentLight = 1
        intentAmb = 0.2
        intentDiff = 0.4
        intentSpec = 0.7
        ka = 1
        kd = 1
        ks = 1
        expon = 1
        ambientTxtBox.Text = ka.ToString()
        diffuseTxtBox.Text = kd.ToString()
        specularTxtBox.Text = ks.ToString()
        exponentTxtBox.Text = expon.ToString()
        Light_XPosTextBox.Text = -10
        Light_YPosTextBox.Text = 10
        Light_ZPosTextBox.Text = 10
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

    Private Sub MidPointDrawLine(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        Dim dx As Integer = x2 - x1
        Dim dy As Integer = y2 - y1
        Dim dr As Integer = 2 * dy
        Dim dur As Integer = 2 * (dy - dx)
        Dim d As Integer = 2 * dy - dx
        Dim x As Integer = x1
        Dim y As Integer = y1

        While x <= x2
            x = x + 1
            If d < 0 Then
                d = d + dy
            Else
                d = d + dur
                y = y + 1
            End If
            bitmapCanvas.SetPixel(x, y, Color.Blue)
        End While
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub translateButton_Click_1(sender As Object, e As EventArgs) Handles TranslateButton.Click
        graphics.Clear(Color.Black)
        transSphere_X = Integer.Parse(X_TransTextBox.Text)
        transSphere_Y = Integer.Parse(Y_TransTextBox.Text)
        transSphere_Z = Integer.Parse(Z_TransTextBox.Text)
        sphereCenter.SetPoints(sphereCenter.x + transSphere_X, sphereCenter.y + transSphere_Y, sphereCenter.z + transSphere_Z)
        Dim Vt, St As New Matrix4x4
        'PV = New Matrix4x4
        Vt.OnePointProjection(5)
        St.TranslateMat(sphereCenter.x + transSphere_X, sphereCenter.y + transSphere_Y, 0 + sphereCenter.z + transSphere_Z)
        PV.Mat = MultiplyMat4x4(Vt, St)
        PV.TranslateMat(MainCanvas.Width / 2 - 1, MainCanvas.Height / 2 - 1, 0)
        'MessageBox.Show(sphereCenter.x & ", " & sphereCenter.y & ", " & sphereCenter.z)
        DrawSphere()
    End Sub


    Private Sub AddLightButton_Click(sender As Object, e As EventArgs) Handles AddLightButton.Click
        If Light_XPosTextBox.Text <> "" And Light_YPosTextBox.Text <> "" And Light_ZPosTextBox.Text <> "" Then
            LightSource.SetPoints(Double.Parse(Light_XPosTextBox.Text), Double.Parse(Light_YPosTextBox.Text), Double.Parse(Light_ZPosTextBox.Text))
            'MessageBox.Show(LightSource.x & ", " & LightSource.y & ", " & LightSource.z)
            LightSourceListBox.Items.Add("Light " & lightCount)
            lightCount += 1
            Dim rect As New Rectangle(LightSource.x, LightSource.y, 10, 10)
            Dim thickPen = New Pen(Color.White, 10)
            graphics.DrawEllipse(thickPen, rect)
        End If
        MainCanvas.Image = bitmapCanvas
    End Sub

    'Private Sub Rotate_XButton_Click(sender As Object, e As EventArgs)
    '    RotX = True
    '    RotY = False
    '    RotZ = False
    '    AnimationTimer.Enabled = True
    'End Sub

    'Private Sub Rotate_YButton_Click(sender As Object, e As EventArgs)
    '    RotX = False
    '    RotY = True
    '    RotZ = False
    '    AnimationTimer.Enabled = True
    'End Sub

    'Private Sub Rotate_ZButton_Click(sender As Object, e As EventArgs)
    '    RotX = False
    '    RotY = False
    '    RotZ = True
    '    AnimationTimer.Enabled = True
    'End Sub

    Private Sub DoShadingButton_Click(sender As Object, e As EventArgs) Handles DoShadingButton.Click
        If ambientTxtBox.Text <> "" And specularTxtBox.Text <> "" And diffuseTxtBox.Text <> "" Then
            ka = ambientTxtBox.Text
            ks = specularTxtBox.Text
            kd = diffuseTxtBox.Text
        Else
            MessageBox.Show("Please fill the coefficient for each!")
        End If
    End Sub

    'Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs) Handles AnimationTimer.Tick
    '    If RotX Then
    '        graphics.Clear(Color.Black)
    '        PV.RotateX(0.344)
    '        DrawSphere()
    '    ElseIf RotY Then
    '        graphics.Clear(Color.Black)
    '        PV.RotateY(0.344)
    '        DrawSphere()
    '    Else
    '        graphics.Clear(Color.Black)
    '        PV.RotateZ(0.344)
    '        DrawSphere()
    '    End If
    'End Sub

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

    Private Function GetPhong() As Double
        'Dim ka, kd, ks, ia, il As Double
        'Dim expo As Integer
        ka = Double.Parse(ambientTxtBox.Text.ToString)
        kd = Double.Parse(diffuseTxtBox.Text.ToString)
        ks = Double.Parse(specularTxtBox.Text.ToString)
        expon = Integer.Parse(exponentTxtBox.Text.ToString)
        'iTot = ((ka * intentAmb) + (kd * intentLight * dotproduct(I, L) + (ks * intentLight * Math.Pow(dotproduct(V, R), expon)))
        Return iTot
    End Function

    Private Sub Projection()
        Dim Vt, St As New Matrix4x4
        PV = New Matrix4x4
        Vt.OnePointProjection(5) ' Zc = 3
        St.TranslateMat(MainCanvas.Width / 2 - 1, MainCanvas.Height / 2 - 1, 0) 'translate
        PV.Mat = MultiplyMat4x4(Vt, St)
        'Console.WriteLine(PV.Mat(0, 0)) 'baris,kolom
        'Console.WriteLine(PV.Mat(0, 1))
        'Console.WriteLine(PV.Mat(0, 2))
        'Console.WriteLine(PV.Mat(0, 3))
        'Console.WriteLine(PV.Mat(1, 0))
        'Console.WriteLine(PV.Mat(1, 1))
        'Console.WriteLine(PV.Mat(1, 2))
        'Console.WriteLine(PV.Mat(1, 3))
        'Console.WriteLine(PV.Mat(2, 0))
        'Console.WriteLine(PV.Mat(2, 1))
        'Console.WriteLine(PV.Mat(2, 2))
        'Console.WriteLine(PV.Mat(2, 3))
        'Console.WriteLine(PV.Mat(3, 0))
        'Console.WriteLine(PV.Mat(3, 1))
        'Console.WriteLine(PV.Mat(3, 2))
        'Console.WriteLine(PV.Mat(3, 3))
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
                    p1 = (longitude * -i + j + 1) + (latitude / 2 * longitude) + 1 '14
                    p2 = (longitude * -i + j) + ((latitude / 2 * longitude) + 1) ' 13 + j 'n * i + j
                    p3 = (latitude / 2 * longitude) + (latitude / 2 * longitude) + 1 '17
                    ListPolygon.InsertIndex(p2, p1, p3)
                Next
                p1 = (longitude * -i) + (latitude / 2 * longitude) + 1 '13
                p2 = (longitude * (-i + 1) - 1) + (latitude / 2 * longitude) + 1 '16
                p3 = (longitude * (-i + 1)) + (latitude / 2 * longitude) + 1 '17
                ListPolygon.InsertIndex(p2, p1, p3)
            End If
        Next
        DrawWithMesh()
        MainCanvas.Image = bitmapCanvas
    End Sub

    Public Sub DrawWithMesh()
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
                'MsgBox(p2.ToString + " aaa " + temp.Elmt(0).p2.ToString)
                FillPolygon(temp, ListPoints, PV, graphics, bitmapCanvas, Pens.Blue, MainCanvas)
                'MidPointDrawLine(m1, m2, m3, m4)
                'MidPointDrawLine(m3, m4, m5, m6)
                'MidPointDrawLine(m5, m6, m1, m2)
                graphics.DrawLine(bluepen, New Point(m1, m2), New Point(m3, m4))
                graphics.DrawLine(bluepen, New Point(m3, m4), New Point(m5, m6))
                graphics.DrawLine(bluepen, New Point(m5, m6), New Point(m1, m2)) 'x
            End If
        Next
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
    'Surface normal
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