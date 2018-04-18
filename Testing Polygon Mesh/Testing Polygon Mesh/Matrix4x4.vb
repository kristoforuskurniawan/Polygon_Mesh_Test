Public Class Matrix4x4
    Public Mat(4, 4) As Double ' array 4x4

    Public Sub New() ' OnCreate
        IdentityMat() ' Declare Identity Matrix
    End Sub

    Public Sub ScaleMat(x As Double, y As Double, z As Double) ' Shear(x,y,z)
        Dim temp As New Matrix4x4
        temp.Mat(0, 0) = x
        temp.Mat(1, 1) = y
        temp.Mat(2, 2) = z
        MultiplyMatrix4x4(temp) ' Multiply to current Matrix ( Current . temp)
    End Sub

    Public Sub CopyMatrix(target As Matrix4x4) ' Copy matrix from a target
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                Mat(i, j) = target.Mat(i, j) ' fill the matrix with other matrix's data
            Next
        Next
    End Sub

    Public Function Transform() As Matrix4x4 ' Transform the matrix
        Dim temp As New Matrix4x4
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                temp.Mat(i, j) = Mat(j, i)
            Next
        Next
        Return temp ' return the transformed matrix
    End Function

    Public Sub TranslateMat(x As Double, y As Double, z As Double) ' Translate(x,y,z)
        Dim temp As New Matrix4x4
        temp.Mat(0, 3) = x
        temp.Mat(1, 3) = y
        temp.Mat(2, 3) = z
        MultiplyMatrix4x4(temp) ' Multiply to current Matrix (Current. temp)
    End Sub

    Public Sub T1(x As Double, y As Double, z As Double, x1 As Double, y2 As Double, z3 As Double)
        'Combination of Scale and Translate
        Dim temp As New Matrix4x4
        temp.Mat(0, 0) = x
        temp.Mat(1, 1) = y
        temp.Mat(2, 2) = z
        temp.Mat(3, 0) = x1
        temp.Mat(3, 1) = y2
        temp.Mat(3, 2) = z3
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub OnePointProjection(c As Double) 'Ini vt kan ya?
        Dim temp As New Matrix4x4
        'temp.Mat(2, 0) = 0.5
        'temp.Mat(2, 1) = 0
        'temp.Mat(2, 2) = 0
        temp.Mat(0, 3) = 0
        temp.Mat(1, 3) = 0
        temp.Mat(2, 3) = 0
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub Rotation(axis As Integer, angle As Double)
        If axis = 1 Then
            RotateX(angle)
        ElseIf axis = 2 Then
            RotateY(angle)
        ElseIf axis = 3 Then
            RotateZ(angle)
        Else
            'IdentityMat()
        End If
    End Sub

    Public Sub RotateX(x As Double)
        Dim temp As New Matrix4x4
        temp.Mat(1, 1) = CosTetha(x)
        temp.Mat(1, 2) = SinTetha(x)
        temp.Mat(2, 1) = -SinTetha(x)
        temp.Mat(2, 2) = CosTetha(x)
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub RotateY(x As Double)
        Dim temp As New Matrix4x4
        temp.Mat(0, 0) = CosTetha(x)
        temp.Mat(0, 2) = -SinTetha(x)
        temp.Mat(2, 0) = SinTetha(x)
        temp.Mat(2, 2) = CosTetha(x)
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub RotateZ(x As Double)
        Dim temp As New Matrix4x4
        temp.Mat(0, 0) = CosTetha(x)
        temp.Mat(0, 1) = SinTetha(x)
        temp.Mat(1, 0) = -SinTetha(x)
        temp.Mat(1, 1) = CosTetha(x)
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub IdentityMat()
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                If i = j Then
                    Mat(i, j) = 1
                Else
                    Mat(i, j) = 0
                End If
            Next
        Next
    End Sub

    Public Sub MultiplyMatrix4x4(M2 As Matrix4x4) 'Multiply to ownself
        Dim temp(4, 4) As Double
        For j = 0 To 3
            For i = 0 To 3
                temp(j, i) = Mat(j, 0) * M2.Mat(0, i) + Mat(j, 1) * M2.Mat(1, i) + Mat(j, 2) * M2.Mat(2, i) + Mat(j, 3) * M2.Mat(3, i)
            Next
        Next
        Mat = temp
    End Sub

    Public Sub insertColumnMatrix(ByRef Matrix(,) As Double, ByVal index As Integer, ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double) ' As Double(,)
        Matrix(index, 0) = a
        Matrix(index, 1) = b
        Matrix(index, 2) = c
        Matrix(index, 3) = d
        'Return Matrix
    End Sub
End Class