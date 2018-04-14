Module Main
    Public Const PI As Double = 3.1415926535897931
    Public Const Sin45 As Double = 0.70710678118654757
    Public Const Cos45 As Double = 0.70710678118654757
    Public Const Cos30 As Double = 0.8660254037844386
    Public Const DegToRad As Double = PI / 180
    Public Const Nil = Nothing
    Public Const Round As Double = 360

    Public Enum RotationAxis
        none = 0
        x = 1
        y = 2
        z = 3
    End Enum

    Public Function Limiter(x As Double) As Int64
        Return Math.Round(x, 2)
    End Function

    Public Function CosTetha(tetha As Double) As Double
        Return Math.Cos(tetha * DegToRad)
    End Function

    Public Function SinTetha(tetha As Double) As Double
        Return Math.Sin(tetha * DegToRad)
    End Function

    Public Function CotTetha(tetha As Double) As Double
        Return (1 / Math.Tan(tetha * DegToRad))
    End Function


    Structure TVector
        Dim x, y, z As Double
    End Structure

    Structure UVN
        Dim u, v, n As TVector
    End Structure

    Sub SetVector(ByRef V As TVector, x As Double, y As Double, z As Double)
        V.x = x
        V.y = y
        V.z = z
    End Sub

    Sub SetUVN(ByRef UVN As UVN, U As TVector, V As TVector, N As TVector)
        UVN.u = U
        UVN.v = V
        UVN.n = N
    End Sub

    Function dot(A As TVector, B As TVector)
        Dim temp As Double
        temp = (A.x * B.x) + (A.y * B.y) + (A.z * B.z)
        Return temp
    End Function

    Function MultiplyMat(point As TPoint, M As Matrix4x4) As TPoint 'Point . Matrix
        Dim result As New TPoint
        Dim w As Single
        w = (point.x * M.Mat(0, 3) + point.y * M.Mat(1, 3) + point.z * M.Mat(2, 3) + point.w * M.Mat(3, 3))
        result.x = (point.x * M.Mat(0, 0) + point.y * M.Mat(1, 0) + point.z * M.Mat(2, 0) + point.w * M.Mat(3, 0)) / w
        result.y = (point.x * M.Mat(0, 1) + point.y * M.Mat(1, 1) + point.z * M.Mat(2, 1) + point.w * M.Mat(3, 1)) / w
        result.z = (point.x * M.Mat(0, 2) + point.y * M.Mat(1, 2) + point.z * M.Mat(2, 2) + point.w * M.Mat(3, 2)) / w
        result.w = 1
        Return result
    End Function

    Function MultiplyMat4x4(A As Matrix4x4, B As Matrix4x4) ' Matrix4x4 version
        'Multiplication of 2 Matrix and return as Matrix4x4
        Dim temp(4, 4) As Double

        For j = 0 To 3
            For i = 0 To 3
                temp(j, i) = A.Mat(j, 0) * B.Mat(0, i) + A.Mat(j, 1) * B.Mat(1, i) + A.Mat(j, 2) * B.Mat(2, i) + A.Mat(j, 3) * B.Mat(3, i)
            Next
        Next

        Return temp
    End Function

    Function MultiplyMat(A(,) As Double, B(,) As Double) ' Original version
        'Multiplication of 2 Matrix and return as Double(4,4)
        Dim temp(4, 4) As Double

        For j = 0 To 3
            For i = 0 To 3
                temp(j, i) = A(j, 0) * B(0, i) + A(j, 1) * B(1, i) + A(j, 2) * B(2, i) + A(j, 3) * B(3, i)
            Next
        Next
        Return temp
    End Function

    Public Structure Normalvalue
        Dim x As Integer
        Dim y As Integer
        Dim z As Integer
    End Structure
End Module
