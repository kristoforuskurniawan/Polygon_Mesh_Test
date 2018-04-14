Imports System.Runtime.InteropServices
Public Class MainForm

    Private bitmapCanvas As Bitmap
    Private graphics As Graphics
    Private blackpen As Pen
    Private ListofVertices As TArrPoint
    Private sphereCenter, surfaceNormal As TPoint
    Private ListofEdges As List(Of TLine)
    Private ListofMeshes As TArrMesh
    Private sphereRadius, deltaU, deltaTheta, theta As Double
    Private longitude, latitude As Integer
    Dim PV As New Matrix4x4
    Private Status, backFaceCullingStatus As Boolean

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bitmapCanvas = New Bitmap(MainCanvas.Width, MainCanvas.Height)
        graphics = Graphics.FromImage(bitmapCanvas)
        blackpen = New Pen(Color.Black)
        MainCanvas.Image = bitmapCanvas
        ListofVertices = New TArrPoint
        ListofVertices.Init()
        ListofEdges = New List(Of TLine)
        ListofMeshes = New TArrMesh()
        ListofMeshes.Init()
        sphereRadius = 150
        longitude = 20
        latitude = 20
        SphereRadInput.Text = sphereRadius.ToString()
        LongiInput.Text = longitude.ToString()
        LatiInput.Text = latitude.ToString()
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

    'Public Sub DrawCube(M As Matrix4x4)
    '    Dim size As Integer = ListofVertices.Count()
    '    Dim obj(size) As TPoint
    '    For i As Integer = 0 To size - 1
    '        obj(i) = MultiplyMat(ListofVertices(i), M)
    '    Next
    '    Dim a, b, c, d As Single
    '    For i As Integer = 0 To size - 1
    '        a = obj(i).x
    '        b = obj(i).y
    '        For j As Integer = 0 To size - 1
    '            c = obj(j).x
    '            d = obj(j).y
    '            g.DrawLine(blackpen, a, b, c, d)
    '        Next
    '    Next
    '    MainCanvas.Image = bitmapCanvas
    'End Sub

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
            'DeclareSphere()
            Projection()
            DrawSphere()
        End If
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
        Dim size As Integer = ListofVertices.Count
        Dim obj(size) As TPoint
        For i As Integer = 0 To size - 1
            obj(i) = New TPoint
            obj(i) = MultiplyMat(ListofVertices.Elmt(i), PV)
        Next
        Dim a, b, c, d As Single
        For i As Integer = 0 To size - 2
            a = obj(i).x
            b = obj(i).y
            c = obj(i + 1).x
            d = obj(i + 1).y
            graphics.DrawLine(blackpen, a, b, c, d)
        Next
    End Sub

    Private Sub MainCanvas_Click(sender As Object, e As EventArgs) Handles MainCanvas.Click
        Status = True
        Win32.AllocConsole()
        Console.WriteLine(ListofVertices.Count)
        For i As Integer = 0 To ListofVertices.Count - 1
            Console.WriteLine(ListofVertices.Elmt(i).x.ToString() + " " + ListofVertices.Elmt(i).y.ToString() + " " + ListofVertices.Elmt(i).z.ToString() + Environment.NewLine)
        Next
        If Status = False Then
            Win32.FreeConsole()
        End If

    End Sub

    Private Sub MainCanvas_Move(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        ScreenCoordLabel.Text = "Coordinates: X = " + e.X.ToString() + ", Y = " + e.Y.ToString()
    End Sub
End Class



'' Ini punya kelompok x:

'Public Class Form1
'    Dim image As Bitmap
'    Dim gr As Graphics
'    Dim ListPoints As ArrPoints
'    Dim ListPoints1 As ArrPoints
'    Dim ListPolygon As ArrPolygon
'    Dim pin As TPolygon
'    Dim Screen(3, 3), vt(3, 3), rz(3, 3) As Double
'    Dim rotx, roty, rotz As Boolean
'    Dim angle1, angle2, angle3 As Double
'    Dim m As Integer 'latitude
'    Dim n As Integer 'longitude
'    Dim r As Double
'    Dim theta As Double
'    Dim u As Double
'    Dim dtheta As Double
'    Dim du As Double
'    Dim x, y, z, w As Double
'    Dim tx, ty, tz As Integer
'    Dim p1, p2, p3 As Integer
'    Dim pulpen As Pen

'    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        Timer1.Interval = 1
'        image = New Bitmap(PictureBox1.Width, PictureBox1.Height)
'        gr = Graphics.FromImage(image)
'        RadioButton2.Select()
'        rotx = False
'        roty = False
'        rotz = False
'        tx = 0
'        ty = 0
'        tz = 0
'        txtX.Text = tx
'        txtY.Text = ty
'        txtZ.Text = tz
'        angle1 = 0
'        angle2 = 0
'        angle3 = 0
'        pulpen = New Pen(Color.Black)
'        insertColumnMatrix(Screen, 0, 1, 0, 0, 200)
'        insertColumnMatrix(Screen, 1, 0, -1, 0, 200)
'        insertColumnMatrix(Screen, 2, 0, 0, 0, 0)
'        insertColumnMatrix(Screen, 3, 0, 0, 0, 1)
'        txtLatitude.Text = 20
'        txtLongitude.Text = 20
'        txtRadius.Text = 150
'        draw()
'        gr.Clear(Color.White)
'        m = Integer.Parse(txtLatitude.Text)
'        n = Integer.Parse(txtLongitude.Text)
'        r = Double.Parse(txtRadius.Text)
'        draw()
'    End Sub

'    Public Sub btnTranslate_Click(sender As Object, e As EventArgs) Handles Translatebtn.Click
'        gr.Clear(Color.White)
'        tx = tx + Integer.Parse(txtX.Text)
'        ty = ty + Integer.Parse(txtY.Text)
'        tz = tz + Integer.Parse(txtZ.Text)
'        insertColumnMatrix(Screen, 0, 1, 0, 0, 200 + tx)
'        insertColumnMatrix(Screen, 1, 0, -1, 0, 200 + ty)
'        insertColumnMatrix(Screen, 2, 0, 0, 0, +tz)
'        insertColumnMatrix(Screen, 3, 0, 0, 0, 1)
'        draw()
'    End Sub

'    Public Sub draw()
'        ListPoints = New ArrPoints
'        ListPoints1 = New ArrPoints
'        ListPolygon = New ArrPolygon
'        dtheta = 180 / m
'        du = 360 / n
'        For i = 0 To m / 2 - 1
'            theta = dtheta * i
'            For j = 0 To n - 1
'                u = du * j
'                x = r * Math.Cos(theta * Math.PI / 180) * Math.Sin(u * Math.PI / 180)
'                y = r * Math.Sin(theta * Math.PI / 180)
'                z = r * Math.Cos(theta * Math.PI / 180) * Math.Cos(u * Math.PI / 180)
'                w = 1
'                ListPoints.InsertLast(x, y, z)
'                ListPoints1.InsertLast(x, -y, z)
'            Next
'        Next
'        ListPoints.InsertLast(0, r, 0)
'        ListPoints1.InsertLast(0, -r, 0)
'        For i = 0 To m / 2 - 1
'            If i <= m / 2 - 2 Then
'                For j = 0 To n - 2
'                    p1 = n * i + j
'                    p2 = n * (i + 1) + j + 1
'                    p3 = n * (i + 1) + j
'                    ListPolygon.InsertLast(p1, p2, p3)

'                    p1 = n * i + j
'                    p2 = n * i + j + 1
'                    p3 = n * (i + 1) + j + 1
'                    ListPolygon.InsertLast(p1, p2, p3)
'                Next
'                p1 = n * (i + 1) - 1
'                p2 = n * (i + 1)
'                p3 = n * (i + 2) - 1
'                ListPolygon.InsertLast(p1, p2, p3)
'                p1 = n * (i + 1) - 1
'                p2 = n * i
'                p3 = n * (i + 1)
'                ListPolygon.InsertLast(p1, p2, p3)
'            Else
'                For j = 0 To n - 2
'                    p1 = n * i + j
'                    p2 = n * i + j + 1
'                    p3 = m / 2 * n
'                    ListPolygon.InsertLast(p1, p2, p3)
'                Next
'                p1 = n * (i + 1) - 1
'                p2 = n * i
'                p3 = n * (i + 1)
'                ListPolygon.InsertLast(p1, p2, p3)
'            End If
'        Next
'        gambarpoly()
'        PictureBox1.Image = image
'    End Sub

'    Private Sub insertColumnMatrix(matrix(,) As Double, ind As Integer, a As Double, b As Double, c As Double, d As Double)
'        matrix(ind, 0) = a
'        matrix(ind, 1) = b
'        matrix(ind, 2) = c
'        matrix(ind, 3) = d
'    End Sub

'    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
'        Dim checkm, checkn As Integer
'        checkm = Integer.Parse(txtLatitude.Text)
'        checkn = Integer.Parse(txtLongitude.Text)
'        If (checkm Mod 2 = 0) And (checkn Mod 2 = 0) Then
'            gr.Clear(Color.White)
'            m = checkm
'            n = checkn
'            r = Double.Parse(txtRadius.Text)
'            draw()
'        Else
'            MessageBox.Show("The number of longitude and latitude must be an even number ",
'                            "Value Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
'        End If
'    End Sub

'    Public Sub gambarpoly()
'        Dim m1, m2, m3, m4, m5, m6, m11, m22, m33, m44, m55, m66 As Double
'        If Timer1.Enabled = True Then
'            If rotx Then
'                insertColumnMatrix(rz, 0, 1, 0, 0, 0)
'                insertColumnMatrix(rz, 1, 0, Math.Cos(angle1 * Math.PI / 180), -Math.Sin(angle1 * Math.PI / 180), 0)
'                insertColumnMatrix(rz, 2, 0, Math.Sin(angle1 * Math.PI / 180), Math.Cos(angle1 * Math.PI / 180), 0)
'                insertColumnMatrix(rz, 3, 0, 0, 0, 1)
'            End If
'            If roty Then
'                insertColumnMatrix(rz, 0, Math.Cos(angle2 * Math.PI / 180), 0, -Math.Sin(angle2 * Math.PI / 180), 0)
'                insertColumnMatrix(rz, 1, 0, 1, 0, 0)
'                insertColumnMatrix(rz, 2, Math.Sin(angle2 * Math.PI / 180), 0, Math.Cos(angle2 * Math.PI / 180), 0)
'                insertColumnMatrix(rz, 3, 0, 0, 0, 1)
'            End If
'            If rotz Then
'                insertColumnMatrix(rz, 0, Math.Cos(angle3 * Math.PI / 180), Math.Sin(angle3 * Math.PI / 180), 0, 0)
'                insertColumnMatrix(rz, 1, -Math.Sin(angle3 * Math.PI / 180), Math.Cos(angle3 * Math.PI / 180), 0, 0)
'                insertColumnMatrix(rz, 2, 0, 0, 1, 0)
'                insertColumnMatrix(rz, 3, 0, 0, 0, 1)
'            End If
'            For j = 0 To ListPolygon.N - 1
'                pin = ListPolygon.Elmt(j)
'                p1 = pin.p1
'                p2 = pin.p2
'                p3 = pin.p3
'                m1 = (ListPoints.Elmt(p1).x * rz(0, 0) + ListPoints.Elmt(p1).y * rz(0, 1) + ListPoints.Elmt(p1).z * rz(0, 2) + w * rz(0, 3))
'                m2 = (ListPoints.Elmt(p1).x * rz(1, 0) + ListPoints.Elmt(p1).y * rz(1, 1) + ListPoints.Elmt(p1).z * rz(1, 2) + w * rz(1, 3))
'                m3 = (ListPoints.Elmt(p2).x * rz(0, 0) + ListPoints.Elmt(p2).y * rz(0, 1) + ListPoints.Elmt(p2).z * rz(0, 2) + w * rz(0, 3))
'                m4 = (ListPoints.Elmt(p2).x * rz(1, 0) + ListPoints.Elmt(p2).y * rz(1, 1) + ListPoints.Elmt(p2).z * rz(1, 2) + w * rz(1, 3))
'                m5 = (ListPoints.Elmt(p3).x * rz(0, 0) + ListPoints.Elmt(p3).y * rz(0, 1) + ListPoints.Elmt(p3).z * rz(0, 2) + w * rz(0, 3))
'                m6 = (ListPoints.Elmt(p3).x * rz(1, 0) + ListPoints.Elmt(p3).y * rz(1, 1) + ListPoints.Elmt(p3).z * rz(1, 2) + w * rz(1, 3))
'                m11 = (m1 * Screen(0, 0) + m1 * Screen(0, 1) + m1 * Screen(0, 2) + w * Screen(0, 3))
'                m22 = (m2 * Screen(1, 0) + m2 * Screen(1, 1) + m2 * Screen(1, 2) + w * Screen(1, 3))
'                m33 = (m3 * Screen(0, 0) + m3 * Screen(0, 1) + m3 * Screen(0, 2) + w * Screen(0, 3))
'                m44 = (m4 * Screen(1, 0) + m4 * Screen(1, 1) + m4 * Screen(1, 2) + w * Screen(1, 3))
'                m55 = (m5 * Screen(0, 0) + m5 * Screen(0, 1) + m5 * Screen(0, 2) + w * Screen(0, 3))
'                m66 = (m6 * Screen(1, 0) + m6 * Screen(1, 1) + m6 * Screen(1, 2) + w * Screen(1, 3))
'                gr.DrawLine(pulpen, New Point(m11, m22), New Point(m33, m44))
'                gr.DrawLine(pulpen, New Point(m33, m44), New Point(m55, m66))
'                gr.DrawLine(pulpen, New Point(m55, m66), New Point(m11, m22))
'                m1 = ListPoints1.Elmt(p1).x * rz(0, 0) + ListPoints1.Elmt(p1).y * rz(0, 1) + ListPoints1.Elmt(p1).z * rz(0, 2) + w * rz(0, 3)
'                m2 = ListPoints1.Elmt(p1).x * rz(1, 0) + ListPoints1.Elmt(p1).y * rz(1, 1) + ListPoints1.Elmt(p1).z * rz(1, 2) + w * rz(1, 3)
'                m3 = ListPoints1.Elmt(p2).x * rz(0, 0) + ListPoints1.Elmt(p2).y * rz(0, 1) + ListPoints1.Elmt(p2).z * rz(0, 2) + w * rz(0, 3)
'                m4 = ListPoints1.Elmt(p2).x * rz(1, 0) + ListPoints1.Elmt(p2).y * rz(1, 1) + ListPoints1.Elmt(p2).z * rz(1, 2) + w * rz(1, 3)
'                m5 = ListPoints1.Elmt(p3).x * rz(0, 0) + ListPoints1.Elmt(p3).y * rz(0, 1) + ListPoints1.Elmt(p3).z * rz(0, 2) + w * rz(0, 3)
'                m6 = ListPoints1.Elmt(p3).x * rz(1, 0) + ListPoints1.Elmt(p3).y * rz(1, 1) + ListPoints1.Elmt(p3).z * rz(1, 2) + w * rz(1, 3)
'                m11 = m1 * Screen(0, 0) + m1 * Screen(0, 1) + m1 * Screen(0, 2) + w * Screen(0, 3)
'                m22 = m2 * Screen(1, 0) + m2 * Screen(1, 1) + m2 * Screen(1, 2) + w * Screen(1, 3)
'                m33 = m3 * Screen(0, 0) + m3 * Screen(0, 1) + m3 * Screen(0, 2) + w * Screen(0, 3)
'                m44 = m4 * Screen(1, 0) + m4 * Screen(1, 1) + m4 * Screen(1, 2) + w * Screen(1, 3)
'                m55 = m5 * Screen(0, 0) + m5 * Screen(0, 1) + m5 * Screen(0, 2) + w * Screen(0, 3)
'                m66 = m6 * Screen(1, 0) + m6 * Screen(1, 1) + m6 * Screen(1, 2) + w * Screen(1, 3)
'                gr.DrawLine(pulpen, New Point(m11, m22), New Point(m33, m44))
'                gr.DrawLine(pulpen, New Point(m33, m44), New Point(m55, m66))
'                gr.DrawLine(pulpen, New Point(m55, m66), New Point(m11, m22))
'            Next
'        Else
'            For i = 0 To ListPolygon.N - 1
'                pin = ListPolygon.Elmt(i)
'                p1 = pin.p1
'                p2 = pin.p2
'                p3 = pin.p3
'                m1 = ListPoints.Elmt(p1).x * Screen(0, 0) + ListPoints.Elmt(p1).y * Screen(0, 1) + ListPoints.Elmt(p1).z * Screen(0, 2) + w * Screen(0, 3)
'                m2 = ListPoints.Elmt(p1).x * Screen(1, 0) + ListPoints.Elmt(p1).y * Screen(1, 1) + ListPoints.Elmt(p1).z * Screen(1, 2) + w * Screen(1, 3)
'                m3 = ListPoints.Elmt(p2).x * Screen(0, 0) + ListPoints.Elmt(p2).y * Screen(0, 1) + ListPoints.Elmt(p2).z * Screen(0, 2) + w * Screen(0, 3)
'                m4 = ListPoints.Elmt(p2).x * Screen(1, 0) + ListPoints.Elmt(p2).y * Screen(1, 1) + ListPoints.Elmt(p2).z * Screen(1, 2) + w * Screen(1, 3)
'                m5 = ListPoints.Elmt(p3).x * Screen(0, 0) + ListPoints.Elmt(p3).y * Screen(0, 1) + ListPoints.Elmt(p3).z * Screen(0, 2) + w * Screen(0, 3)
'                m6 = ListPoints.Elmt(p3).x * Screen(1, 0) + ListPoints.Elmt(p3).y * Screen(1, 1) + ListPoints.Elmt(p3).z * Screen(1, 2) + w * Screen(1, 3)
'                gr.DrawLine(pulpen, New Point(m1, m2), New Point(m3, m4))
'                gr.DrawLine(pulpen, New Point(m3, m4), New Point(m5, m6))
'                gr.DrawLine(pulpen, New Point(m5, m6), New Point(m1, m2))
'                m1 = ListPoints1.Elmt(p1).x * Screen(0, 0) + ListPoints1.Elmt(p1).y * Screen(0, 1) + ListPoints1.Elmt(p1).z * Screen(0, 2) + w * Screen(0, 3)
'                m2 = ListPoints1.Elmt(p1).x * Screen(1, 0) + ListPoints1.Elmt(p1).y * Screen(1, 1) + ListPoints1.Elmt(p1).z * Screen(1, 2) + w * Screen(1, 3)
'                m3 = ListPoints1.Elmt(p2).x * Screen(0, 0) + ListPoints1.Elmt(p2).y * Screen(0, 1) + ListPoints1.Elmt(p2).z * Screen(0, 2) + w * Screen(0, 3)
'                m4 = ListPoints1.Elmt(p2).x * Screen(1, 0) + ListPoints1.Elmt(p2).y * Screen(1, 1) + ListPoints1.Elmt(p2).z * Screen(1, 2) + w * Screen(1, 3)
'                m5 = ListPoints1.Elmt(p3).x * Screen(0, 0) + ListPoints1.Elmt(p3).y * Screen(0, 1) + ListPoints1.Elmt(p3).z * Screen(0, 2) + w * Screen(0, 3)
'                m6 = ListPoints1.Elmt(p3).x * Screen(1, 0) + ListPoints1.Elmt(p3).y * Screen(1, 1) + ListPoints1.Elmt(p3).z * Screen(1, 2) + w * Screen(1, 3)
'                gr.DrawLine(pulpen, New Point(m1, m2), New Point(m3, m4))
'                gr.DrawLine(pulpen, New Point(m3, m4), New Point(m5, m6))
'                gr.DrawLine(pulpen, New Point(m5, m6), New Point(m1, m2))
'            Next

'        End If

'    End Sub


'    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
'        gr.Clear(Color.White)
'        If rotx = True Then
'            angle1 += 0.3567
'        End If
'        If roty = True Then
'            angle2 += 0.3567
'        End If
'        If roty = True Then
'            angle2 += 0.3567
'        End If
'        If rotz = True Then
'            angle3 += 0.3567
'        End If
'        draw()
'        gambarpoly()
'    End Sub

'    Private Sub rotXbtn_Click(sender As Object, e As EventArgs) Handles rotXbtn.Click
'        rotx = True
'        roty = False
'        rotz = False
'        angle1 += 0.3567
'        Timer1.Enabled = True
'    End Sub

'    Private Sub rotYbtn_Click(sender As Object, e As EventArgs) Handles rotYbtn.Click
'        rotx = False
'        rotz = False
'        roty = True
'        angle2 += 0.3567
'        Timer1.Enabled = True
'    End Sub

'    Private Sub rotZbtn_Click(sender As Object, e As EventArgs) Handles rotZbtn.Click
'        rotx = False
'        roty = False
'        rotz = True
'        angle3 += 0.3567
'        Timer1.Enabled = True
'    End Sub

'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnStop.Click
'        Timer1.Enabled = False
'    End Sub


'    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
'        Timer1.Enabled = False
'        gr.Clear(Color.White)
'        m = 20
'        n = 20
'        r = 150
'        draw()
'        gambarpoly()
'    End Sub

'End Class
