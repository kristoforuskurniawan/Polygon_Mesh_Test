Imports System.Runtime.InteropServices
Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private graphics As Graphics
    Private blackpen As Pen
    Private ListofVertices As TArrPoint
    Private ListPolygon As TArrMesh
    Private sphereCenter, surfaceNormal As TPoint
    Private mesh As TMesh
    Private ListofEdges As List(Of TLine)
    Private ListofMeshes As TArrMesh
    Private sphereRadius, deltaU, deltaTheta, theta, u, rotationAngle_X, rotationAngle_Y, rotationAngle_Z, Vt(3, 3), St(3, 3), rz(3, 3), x, y, z, w As Double
    Private longitude, latitude, transPhere_X, transSphere_Y, transSphere_Z, p1, p2, p3 As Integer
    Private PV As New Matrix4x4
    Private Status, backFaceCullingStatus As Boolean

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        graphics = Graphics.FromImage(bitmapCanvas)
        blackpen = New Pen(Color.Black)
        MainCanvas.Image = bitmapCanvas
        ListofVertices = New TArrPoint
        ListofMeshes = New TArrMesh()
        ListPolygon = New TArrMesh
        sphereCenter = New TPoint(MainCanvas.Width / 2 - 1, MainCanvas.Height / 2 - 1, 0)
        mesh = New TMesh()
        ListofVertices.Init()
        ListPolygon.Init()
        'ListofEdges = New List(Of TLine)
        'ListofMeshes = New TArrMesh()
        ListofMeshes.Init()
        PV = New Matrix4x4()

        Vt = PV.insertColumnMatrix(Vt, 0, 1, 0, 0, 0)
        Vt = PV.insertColumnMatrix(Vt, 1, 0, 1, 0, 0)
        Vt = PV.insertColumnMatrix(Vt, 2, 0, 0, 0, -1 / 10)
        Vt = PV.insertColumnMatrix(Vt, 3, 0, 0, 0, 1)

        St = PV.insertColumnMatrix(St, 0, 1, 0, 0, sphereCenter.x)
        St = PV.insertColumnMatrix(St, 1, 0, -1, 0, sphereCenter.y)
        St = PV.insertColumnMatrix(St, 2, 0, 0, 0, 0)
        St = PV.insertColumnMatrix(St, 3, 0, 0, 0, 1)

        sphereRadius = 150
        longitude = 30
        latitude = 30
        transPhere_X = 0
        transSphere_Y = 0
        transSphere_Z = 0
        rotationAngle_X = 0
        rotationAngle_Y = 0
        rotationAngle_Z = 0
        SphereRadInput.Text = sphereRadius.ToString()
        LongiInput.Text = longitude.ToString()
        LatiInput.Text = latitude.ToString()
        X_TransTextBox.Text = transPhere_X.ToString()
        Y_TransTextBox.Text = transSphere_Y.ToString()
        Z_TransTextBox.Text = transSphere_Z.ToString()
        SphereMoveRadioButton.Checked = True
        LightMoveRadioButton.Checked = False
        BackCulling_OFFRadioButton.Checked = True
        BackCulling_ONRadioButton.Checked = False
        backFaceCullingStatus = False
        Status = True
    End Sub

    'Public Class Win32 'Ini class untuk apa?
    '    <DllImport("kernel32.dll")> Public Shared Function AllocConsole() As Boolean

    '    End Function
    '    <DllImport("kernel32.dll")> Public Shared Function FreeConsole() As Boolean

    '    End Function
    'End Class


    Private Function dotproduct(x As Double(), y As Double()) As Double
        Dim d As Double = x(0) * y(0) + x(1) * y(1) + x(2) * y(2)
        Return If(d < 0, -d, 0)
        'asdf
    End Function

    Public Sub SetVertices(x As Double, y As Double, z As Double)
        Dim temp As New TPoint(x, y, z)
        ListofVertices.InsertLast(temp.x, temp.y, temp.z)
    End Sub

    Public Sub SetEdges(x As Integer, y As Integer, a As Integer, b As Integer)
        Dim temp As New TLine(x, y, a, b)
        ListofEdges.Add(temp)
    End Sub

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

    Private Function getCrossProduct(ByRef Vector1 As TPoint, ByRef Vector2 As TPoint)
        Return New TPoint(Vector1.y * Vector2.z - Vector1.z * Vector2.y, Vector1.z * Vector2.x - Vector1.x * Vector2.z, Vector1.x * Vector2.y - Vector1.y * Vector2.x)
    End Function

    Private Sub calculateSurfaceNormal(ByRef Point1 As TPoint, ByRef Point2 As TPoint, ByRef Point3 As TPoint) 'Urutan tiga point udah counter clockwise
        Dim P1_P2, P1_P3 As TPoint
        P1_P2 = New TPoint(Point2.x - Point1.x, Point2.y - Point1.y, Point2.z - Point1.z)
        P1_P3 = New TPoint(Point3.x - Point1.x, Point3.y - Point1.y, Point3.z - Point1.z)
        surfaceNormal = getCrossProduct(P1_P2, P1_P3)
    End Sub

    Private Sub BackCullON_BTN_CheckedChanged(sender As Object, e As EventArgs)
        backFaceCullingStatus = True
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

    Public Sub DrawCube(M As Matrix4x4)
        Dim size As Integer = ListofVertices.Count()
        Dim obj(size) As TPoint
        For i As Integer = 0 To size - 1
            obj(i) = MultiplyMat(ListofVertices.Elmt(i), M)
        Next
        Dim a, b, c, d As Single
        For i As Integer = 0 To size - 1
            a = obj(i).x
            b = obj(i).y
            For j As Integer = 0 To size - 1
                c = obj(j).x
                d = obj(j).y
                graphics.DrawLine(blackpen, a, b, c, d)
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
        If SphereRadInput.Text = "" Or LongiInput.Text = "" Or LatiInput.Text = "" Then
            MessageBox.Show("Please give a proper input")
        Else
            sphereRadius = Double.Parse(SphereRadInput.Text)
            longitude = Integer.Parse(LongiInput.Text)
            latitude = Integer.Parse(LatiInput.Text)
            'DeclareSphere()
            'Projection()
            graphics.Clear(Color.White)
            ListofVertices.DeleteAllData()
            ListofMeshes.DeleteAllData()
            DrawSphere()
        End If
        'MainCanvas.Image = bitmapCanvas
        'DrawCube(PV)
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

    Private Sub DrawSphere()
        deltaTheta = 180 / latitude
        deltaU = 360 / longitude
        For i = 0 To latitude / 2 - 1
            theta = deltaTheta * i
            For j = 0 To longitude - 1
                u = deltaU * j
                x = sphereRadius * Math.Cos(theta * Math.PI / 180) * Math.Sin(u * Math.PI / 180)
                y = sphereRadius * Math.Sin(theta * Math.PI / 180)
                z = sphereRadius * Math.Cos(theta * Math.PI / 180) * Math.Cos(u * Math.PI / 180)
                w = 1
                ListofVertices.InsertLast(x, y, z)
            Next
        Next
        ListofVertices.InsertLast(0, sphereRadius, 0)
        For i = 0 To (-latitude / 2) + 1 Step -1
            theta = deltaTheta * i
            For j = 0 To longitude - 1
                u = deltaU * j
                x = sphereRadius * Math.Cos(theta * Math.PI / 180) * Math.Sin(u * Math.PI / 180)
                y = sphereRadius * Math.Sin(theta * Math.PI / 180)
                z = sphereRadius * Math.Cos(theta * Math.PI / 180) * Math.Cos(u * Math.PI / 180)
                w = 1
                ListofVertices.InsertLast(x, y, z)
            Next
        Next
        ListofVertices.InsertLast(0, -sphereRadius, 0)
        For i = 0 To latitude / 2 - 1 'm=latitude 'Bagian bola atas
            If i <= latitude / 2 - 2 Then 'n=longitude
                For j = 0 To longitude - 2
                    p1 = longitude * i + j
                    p2 = longitude * (i + 1) + j + 1
                    p3 = longitude * (i + 1) + j
                    ListofMeshes.InsertLast(p1, p2, p3)

                    p1 = longitude * i + j
                    p2 = longitude * i + j + 1
                    p3 = longitude * (i + 1) + j + 1
                    ListofMeshes.InsertLast(p1, p2, p3)
                Next
                p1 = longitude * (i + 1) - 1
                p2 = longitude * (i + 1)
                p3 = longitude * (i + 2) - 1
                ListofMeshes.InsertLast(p1, p2, p3)

                p1 = longitude * (i + 1) - 1
                p2 = longitude * i
                p3 = longitude * (i + 1)
                ListofMeshes.InsertLast(p1, p2, p3)
            Else
                For j = 0 To longitude - 2
                    p1 = longitude * i + j
                    p2 = longitude * i + j + 1
                    p3 = latitude / 2 * longitude
                    ListofMeshes.InsertLast(p1, p2, p3)
                Next
                p1 = longitude * (i + 1) - 1
                p2 = longitude * i
                p3 = longitude * (i + 1)
                ListofMeshes.InsertLast(p1, p2, p3)
            End If
        Next
        For i = 0 To (-latitude / 2) + 1 Step -1 'Bagian bola bawah
            If i >= (-latitude / 2) + 2 Then
                For j = 0 To longitude - 2
                    p1 = (longitude * (-i + 1)) + j + (latitude / 2 * longitude) + 1 '(m / 2 * n) + n + j + 1 '13 + j 'n * i + j 
                    p2 = (longitude * -i + j + 1) + (latitude / 2 * longitude) + 1 '(m / 2 * n) + j + 2 '10 + j 'n * (i + 1) + j + 1
                    p3 = (longitude * -i + j) + (latitude / 2 * longitude) + 1 '(m / 2 * n) + j + 1 '9 + j 'n * (i + 1) + j
                    ListofMeshes.InsertLast(p1, p2, p3)

                    p1 = (longitude * (-i + 1)) + j + (latitude / 2 * longitude) + 1 '(m / 2 * n) + n + j + 1 ' n * i + j 13
                    p2 = (longitude * (-i + 1) + j + 1) + (latitude / 2 * longitude) + 1 '14 + j ' n * i + j + 1 
                    p3 = (longitude * -i + j + 1) + (latitude / 2 * longitude) + 1 '10 + j 'n * (i + 1) + j + 1
                    ListofMeshes.InsertLast(p1, p2, p3)
                Next
                p1 = (longitude * (-i + 2) - 1) + (latitude / 2 * longitude) + 1 '16 'n * (i + 1) - 1
                p2 = (longitude * -i) + (latitude / 2 * longitude) + 1 '9 'n * (i + 1)
                p3 = (longitude * (-i + 1) - 1) + (latitude / 2 * longitude) + 1 '12 'n * (i + 2) - 1
                ListofMeshes.InsertLast(p1, p2, p3)

                p1 = (longitude * (-i + 2) - 1) + (latitude / 2 * longitude) + 1 '16 'n * (i + 1) - 1
                p2 = (longitude * (-i + 1)) + (latitude / 2 * longitude) + 1 '13 ' n * i
                p3 = (longitude * -i) + (latitude / 2 * longitude) + 1 ' 9 'n * (i + 1)
                ListofMeshes.InsertLast(p1, p2, p3)
            Else
                For j = 0 To longitude - 2
                    p1 = (longitude * -i + j) + ((latitude / 2 * longitude) + 1) ' 13 + j 'n * i + j
                    p2 = (longitude * -i + j + 1) + (latitude / 2 * longitude) + 1 '14
                    p3 = (latitude / 2 * longitude) + (latitude / 2 * longitude) + 1 '17
                    ListofMeshes.InsertLast(p1, p2, p3)
                Next
                p1 = (longitude * (-i + 1) - 1) + (latitude / 2 * longitude) + 1 '16
                p2 = (longitude * -i) + (latitude / 2 * longitude) + 1 '13
                p3 = (longitude * (-i + 1)) + (latitude / 2 * longitude) + 1 '17
                ListofMeshes.InsertLast(p1, p2, p3)
            End If
        Next
        DrawPoly()
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub DrawPoly()
        Dim m1, m2, m3, m4, m5, m6, m11, m22, m33, m44, m55, m66 As Double
        If (backFaceCullingStatus = False) Then
            If Timer1.Enabled Then
                'If rotx = True Then
                '    insertColumnMatrix(rz, 0, 1, 0, 0, 0)
                '    insertColumnMatrix(rz, 1, 0, Math.Cos(angle1 * Math.PI / 180), -Math.Sin(angle1 * Math.PI / 180), 0)
                '    insertColumnMatrix(rz, 2, 0, Math.Sin(angle1 * Math.PI / 180), Math.Cos(angle1 * Math.PI / 180), 0)
                '    insertColumnMatrix(rz, 3, 0, 0, 0, 1)
                'End If
                'If roty = True Then
                '    insertColumnMatrix(rz, 0, Math.Cos(angle2 * Math.PI / 180), 0, -Math.Sin(angle2 * Math.PI / 180), 0)
                '    insertColumnMatrix(rz, 1, 0, 1, 0, 0)
                '    insertColumnMatrix(rz, 2, Math.Sin(angle2 * Math.PI / 180), 0, Math.Cos(angle2 * Math.PI / 180), 0)
                '    insertColumnMatrix(rz, 3, 0, 0, 0, 1)
                'End If
                'If rotz = True Then
                '    insertColumnMatrix(rz, 0, Math.Cos(angle3 * Math.PI / 180), Math.Sin(angle3 * Math.PI / 180), 0, 0)
                '    insertColumnMatrix(rz, 1, -Math.Sin(angle3 * Math.PI / 180), Math.Cos(angle3 * Math.PI / 180), 0, 0)
                '    insertColumnMatrix(rz, 2, 0, 0, 1, 0)
                '    insertColumnMatrix(rz, 3, 0, 0, 0, 1)
                'End If
                For j = 0 To ListofMeshes.N - 1
                    mesh = ListofMeshes.Elmt(j)
                    p1 = mesh.EdgeIndex1
                    p2 = mesh.EdgeIndex2
                    p3 = mesh.EdgeIndex3
                    m1 = (ListofVertices.Elmt(p1).x * rz(0, 0) + ListofVertices.Elmt(p1).y * rz(0, 1) + ListofVertices.Elmt(p1).z * rz(0, 2) + w * rz(0, 3))
                    m2 = (ListofVertices.Elmt(p1).x * rz(1, 0) + ListofVertices.Elmt(p1).y * rz(1, 1) + ListofVertices.Elmt(p1).z * rz(1, 2) + w * rz(1, 3))
                    m3 = (ListofVertices.Elmt(p2).x * rz(0, 0) + ListofVertices.Elmt(p2).y * rz(0, 1) + ListofVertices.Elmt(p2).z * rz(0, 2) + w * rz(0, 3))
                    m4 = (ListofVertices.Elmt(p2).x * rz(1, 0) + ListofVertices.Elmt(p2).y * rz(1, 1) + ListofVertices.Elmt(p2).z * rz(1, 2) + w * rz(1, 3))
                    m5 = (ListofVertices.Elmt(p3).x * rz(0, 0) + ListofVertices.Elmt(p3).y * rz(0, 1) + ListofVertices.Elmt(p3).z * rz(0, 2) + w * rz(0, 3))
                    m6 = (ListofVertices.Elmt(p3).x * rz(1, 0) + ListofVertices.Elmt(p3).y * rz(1, 1) + ListofVertices.Elmt(p3).z * rz(1, 2) + w * rz(1, 3))
                    m11 = (m1 * St(0, 0) + m1 * St(0, 1) + m1 * St(0, 2) + w * St(0, 3))
                    m22 = (m2 * St(1, 0) + m2 * St(1, 1) + m2 * St(1, 2) + w * St(1, 3))
                    m33 = (m3 * St(0, 0) + m3 * St(0, 1) + m3 * St(0, 2) + w * St(0, 3))
                    m44 = (m4 * St(1, 0) + m4 * St(1, 1) + m4 * St(1, 2) + w * St(1, 3))
                    m55 = (m5 * St(0, 0) + m5 * St(0, 1) + m5 * St(0, 2) + w * St(0, 3))
                    m66 = (m6 * St(1, 0) + m6 * St(1, 1) + m6 * St(1, 2) + w * St(1, 3))
                    graphics.DrawLine(blackpen, New Point(m11, m22), New Point(m33, m44))
                    graphics.DrawLine(blackpen, New Point(m33, m44), New Point(m55, m66))
                    graphics.DrawLine(blackpen, New Point(m55, m66), New Point(m11, m22))
                Next
            Else
                For i = 0 To ListofMeshes.N - 1
                    mesh = ListofMeshes.Elmt(i)
                    p1 = mesh.EdgeIndex1
                    p2 = mesh.EdgeIndex2
                    p3 = mesh.EdgeIndex3
                    m1 = ListofVertices.Elmt(p1).x * St(0, 0) + ListofVertices.Elmt(p1).y * St(0, 1) + ListofVertices.Elmt(p1).z * St(0, 2) + w * St(0, 3)
                    m2 = ListofVertices.Elmt(p1).x * St(1, 0) + ListofVertices.Elmt(p1).y * St(1, 1) + ListofVertices.Elmt(p1).z * St(1, 2) + w * St(1, 3)
                    m3 = ListofVertices.Elmt(p2).x * St(0, 0) + ListofVertices.Elmt(p2).y * St(0, 1) + ListofVertices.Elmt(p2).z * St(0, 2) + w * St(0, 3)
                    m4 = ListofVertices.Elmt(p2).x * St(1, 0) + ListofVertices.Elmt(p2).y * St(1, 1) + ListofVertices.Elmt(p2).z * St(1, 2) + w * St(1, 3)
                    m5 = ListofVertices.Elmt(p3).x * St(0, 0) + ListofVertices.Elmt(p3).y * St(0, 1) + ListofVertices.Elmt(p3).z * St(0, 2) + w * St(0, 3)
                    m6 = ListofVertices.Elmt(p3).x * St(1, 0) + ListofVertices.Elmt(p3).y * St(1, 1) + ListofVertices.Elmt(p3).z * St(1, 2) + w * St(1, 3)
                    graphics.DrawLine(blackpen, New Point(m1, m2), New Point(m3, m4))
                    graphics.DrawLine(blackpen, New Point(m3, m4), New Point(m5, m6))
                    graphics.DrawLine(blackpen, New Point(m5, m6), New Point(m1, m2))
                Next
            End If
        Else 'Backface Culling is activated

        End If
        MainCanvas.Image = bitmapCanvas
    End Sub


    Private Sub MainCanvas_Click(sender As Object, e As EventArgs) Handles MainCanvas.Click
        Status = True
        'Win32.AllocConsole()
        Console.WriteLine(ListofVertices.Count)
        For i As Integer = 0 To ListofVertices.Count - 1
            'Console.WriteLine(ListoPoints.Elmt(i).x.ToString() + " " + ListofVertices.Elmt(i).y.ToString() + " " + ListofVertices.Elmt(i).z.ToString() + Environment.NewLine)
        Next
        If Status = False Then
            'Win32.FreeConsole()
        End If

    End Sub

    Private Sub MainCanvas_Move(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        ScreenCoordLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub
End Class