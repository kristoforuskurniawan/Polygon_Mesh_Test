Public Class TArrPoint
    Public x, y, z, w As Double

    Public Sub New()
        x = 0
        y = 0
        z = 0
        w = 1
    End Sub

    Public Sub MultiplyMatMesh(ListPoint As ListPoints, A As Integer, M As Matrix4x4)
        Dim result As New TArrPoint
        Dim w As Single
        w = 1
        result.x = (ListPoint.Elmt(A).x * M.Mat(0, 0) + ListPoint.Elmt(A).y * M.Mat(1, 0) + ListPoint.Elmt(A).z * M.Mat(2, 0) + ListPoint.Elmt(A).w * M.Mat(3, 0)) / w
        result.y = (ListPoint.Elmt(A).x * M.Mat(0, 1) + ListPoint.Elmt(A).y * M.Mat(1, 1) + ListPoint.Elmt(A).z * M.Mat(2, 1) + ListPoint.Elmt(A).w * M.Mat(3, 1)) / w
        result.z = (ListPoint.Elmt(A).x * M.Mat(0, 2) + ListPoint.Elmt(A).y * M.Mat(1, 2) + ListPoint.Elmt(A).z * M.Mat(2, 2) + ListPoint.Elmt(A).w * M.Mat(3, 2)) / w
        x = result.x
        y = result.y
        z = result.z
    End Sub

    Public Sub InsertVal(ListPoint As ListPoints, A As Integer)
        x = ListPoint.Elmt(A).x
        y = ListPoint.Elmt(A).y
        z = ListPoint.Elmt(A).z
        w = 1
    End Sub
End Class
Public Class ListPoints
    Public N As Integer
    Public Elmt() As TArrPoint
    Public Sub Init()
        N = 0
        ReDim Elmt(-1)
    End Sub
    Public Overloads Sub InsertPoint(x As Double, y As Double, z As Double)
        Dim P As TArrPoint
        P = New TArrPoint
        P.x = x
        P.y = y
        P.z = z
        ReDim Preserve Elmt(N)
        Elmt(N) = P
        N = N + 1
    End Sub
End Class