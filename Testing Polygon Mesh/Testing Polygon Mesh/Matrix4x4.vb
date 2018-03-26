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
        temp.Mat(3, 0) = x
        temp.Mat(3, 1) = y
        temp.Mat(3, 2) = z
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

    Public Sub AxoProjection(omega As Double, tetha As Double)
        'Axometric Projection
        Dim temp As New Matrix4x4
        temp.Mat(0, 0) = CosTetha(omega)
        temp.Mat(0, 1) = SinTetha(omega) * SinTetha(tetha)
        temp.Mat(1, 1) = CosTetha(tetha)
        temp.Mat(2, 0) = SinTetha(omega)
        temp.Mat(2, 1) = -CosTetha(omega) * SinTetha(tetha)
        temp.Mat(2, 2) = 0
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub ObliqueProjection(omega As Double, alpha As Double)
        ' Oblique Projection
        Dim temp As New Matrix4x4
        temp.Mat(2, 0) = CotTetha(omega) * CosTetha(alpha)
        temp.Mat(2, 1) = CotTetha(omega) * SinTetha(alpha)
        temp.Mat(2, 2) = 0
        MultiplyMatrix4x4(temp)
    End Sub

    Public Sub ShearMat(x As Double, y As Double) ' Shear(shx,shy)
        Dim temp As New Matrix4x4
        temp.Mat(2, 0) = x
        temp.Mat(2, 1) = y
        MultiplyMatrix4x4(temp)
    End Sub

    Public Function getDet_2x2(ByRef Two_Dim(,) As Double) As Double
        Return Two_Dim(0, 0) * Two_Dim(1, 1) - Two_Dim(0, 1) * Two_Dim(1, 0)
    End Function

    Public Function getDet_3x3(ByRef Three_Dim(,) As Double) As Double
        'For i = 0 To 1
        '    For j = 0 To 1
        '        forTwo_Dim1(i, j) = Three_Dim(i + 1, j + 1)

        '    Next
        'Next
        Dim forTwo_Dim1(2, 2), forTwo_Dim2(2, 2), forTwo_Dim3(2, 2) As Double

        forTwo_Dim1(0, 0) = Three_Dim(1, 1)
        forTwo_Dim1(0, 1) = Three_Dim(1, 2)
        forTwo_Dim1(1, 0) = Three_Dim(2, 1)
        forTwo_Dim1(1, 1) = Three_Dim(2, 2)

        forTwo_Dim2(0, 0) = Three_Dim(0, 1)
        forTwo_Dim2(0, 1) = Three_Dim(1, 2)
        forTwo_Dim2(1, 0) = Three_Dim(0, 2)
        forTwo_Dim2(1, 1) = Three_Dim(2, 2)

        forTwo_Dim3(0, 0) = Three_Dim(0, 1)
        forTwo_Dim3(0, 1) = Three_Dim(1, 1)
        forTwo_Dim3(1, 0) = Three_Dim(0, 2)
        forTwo_Dim3(1, 1) = Three_Dim(2, 1)

        Return Three_Dim(0, 0) * getDet_2x2(forTwo_Dim1) - Three_Dim(0, 1) * getDet_2x2(forTwo_Dim2) + Three_Dim(0, 2) * getDet_2x2(forTwo_Dim3)
    End Function

    Public Function getDet_4x4(ByRef Four_Dim(,) As Double)
        Dim forThree_Dim1(3, 3), forThree_Dim2(3, 3), forThree_Dim3(3, 3), forThree_Dim4(3, 3) As Double

        forThree_Dim1(0, 0) = Four_Dim(1, 1) 'Bisa pake loop tapi yah sudahlah
        forThree_Dim1(0, 1) = Four_Dim(1, 2)
        forThree_Dim1(0, 2) = Four_Dim(1, 3)
        forThree_Dim1(1, 0) = Four_Dim(2, 1)
        forThree_Dim1(1, 1) = Four_Dim(2, 2)
        forThree_Dim1(1, 2) = Four_Dim(2, 3)
        forThree_Dim1(2, 0) = Four_Dim(3, 1)
        forThree_Dim1(2, 1) = Four_Dim(3, 2)
        forThree_Dim1(2, 2) = Four_Dim(3, 3)

        forThree_Dim2(0, 0) = Four_Dim(1, 0) 'Bisa pake loop tapi yah sudahlah
        forThree_Dim2(0, 1) = Four_Dim(1, 2)
        forThree_Dim2(0, 2) = Four_Dim(1, 3)
        forThree_Dim2(1, 0) = Four_Dim(2, 0)
        forThree_Dim2(1, 1) = Four_Dim(2, 2)
        forThree_Dim2(1, 2) = Four_Dim(2, 3)
        forThree_Dim2(2, 0) = Four_Dim(3, 0)
        forThree_Dim2(2, 1) = Four_Dim(3, 2)
        forThree_Dim2(2, 2) = Four_Dim(3, 3)

        forThree_Dim3(0, 0) = Four_Dim(1, 0) 'Bisa pake loop tapi yah sudahlah
        forThree_Dim3(0, 1) = Four_Dim(1, 1)
        forThree_Dim3(0, 2) = Four_Dim(1, 3)
        forThree_Dim3(1, 0) = Four_Dim(2, 0)
        forThree_Dim3(1, 1) = Four_Dim(2, 1)
        forThree_Dim3(1, 2) = Four_Dim(2, 3)
        forThree_Dim3(2, 0) = Four_Dim(3, 0)
        forThree_Dim3(2, 1) = Four_Dim(3, 1)
        forThree_Dim3(2, 2) = Four_Dim(3, 3)

        forThree_Dim4(0, 0) = Four_Dim(1, 0) 'Bisa pake loop tapi yah sudahlah
        forThree_Dim4(0, 1) = Four_Dim(1, 1)
        forThree_Dim4(0, 2) = Four_Dim(1, 2)
        forThree_Dim4(1, 0) = Four_Dim(2, 0)
        forThree_Dim4(1, 1) = Four_Dim(2, 1)
        forThree_Dim4(1, 2) = Four_Dim(2, 2)
        forThree_Dim4(2, 0) = Four_Dim(3, 0)
        forThree_Dim4(2, 1) = Four_Dim(3, 1)
        forThree_Dim4(2, 2) = Four_Dim(3, 2)

        Return Four_Dim(0, 0) * getDet_3x3(forThree_Dim1) - Four_Dim(0, 1) * getDet_3x3(forThree_Dim2) + Four_Dim(0, 2) * getDet_3x3(forThree_Dim3) - Four_Dim(0, 3) * getDet_3x3(forThree_Dim4)
    End Function

    'Public Function getCofactorMatrix_4x4(ByRef Four_Dim(,) As Double) As Double 'This is crazy. I can't find the loop pattern...
    '    Dim CofactorMatrix_4x4(4, 4) As Double
    '    Dim Three_Dim(16, 3, 3) As Double

    '    For i = 0 To 2
    '        For j = 0 To 2
    '            Three_Dim(0, i, j) = Four_Dim(i + 1, j + 1) 'Top Left part of cofactor matrix
    '        Next
    '    Next

    '    'Three_Dim(0, 0, 0) = Four_Dim(1, 1)
    '    'Three_Dim(0, 0, 1) = Four_Dim(1, 2)
    '    'Three_Dim(0, 0, 2) = Four_Dim(1, 3)
    '    'Three_Dim(0, 1, 0) = Four_Dim(2, 1)
    '    'Three_Dim(0, 1, 1) = Four_Dim(2, 2)
    '    'Three_Dim(0, 1, 2) = Four_Dim(2, 3)
    '    'Three_Dim(0, 2, 0) = Four_Dim(3, 1)
    '    'Three_Dim(0, 2, 1) = Four_Dim(3, 2)
    '    'Three_Dim(0, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(1, 0, 0) = Four_Dim(1, 0)
    '    Three_Dim(1, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(1, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(1, 1, 0) = Four_Dim(2, 0)
    '    Three_Dim(1, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(1, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(1, 2, 0) = Four_Dim(3, 0)
    '    Three_Dim(1, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(1, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(2, 0, 0) = Four_Dim(1, 0)
    '    Three_Dim(2, 0, 1) = Four_Dim(1, 1)
    '    Three_Dim(2, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(2, 1, 0) = Four_Dim(2, 0)
    '    Three_Dim(2, 1, 1) = Four_Dim(2, 1)
    '    Three_Dim(2, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(2, 2, 0) = Four_Dim(3, 0)
    '    Three_Dim(2, 2, 1) = Four_Dim(3, 1) 'Last Edited Here....
    '    Three_Dim(2, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(3, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(3, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(3, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(3, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(3, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(3, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(3, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(3, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(3, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(4, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(4, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(4, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(4, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(4, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(4, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(4, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(4, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(4, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(5, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(5, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(5, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(5, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(5, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(5, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(5, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(5, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(5, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(6, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(6, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(6, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(6, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(6, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(6, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(6, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(6, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(6, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(7, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(7, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(7, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(7, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(7, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(7, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(7, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(7, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(7, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(8, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(8, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(8, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(8, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(8, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(8, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(8, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(8, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(8, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(9, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(9, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(9, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(9, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(9, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(9, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(9, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(9, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(9, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(10, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(10, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(10, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(10, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(10, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(10, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(10, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(10, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(10, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(11, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(11, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(11, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(11, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(11, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(11, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(11, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(11, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(11, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(12, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(12, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(12, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(12, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(12, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(12, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(12, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(12, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(12, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(13, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(13, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(13, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(13, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(13, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(13, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(13, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(13, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(13, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(14, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(14, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(14, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(14, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(14, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(14, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(14, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(14, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(14, 2, 2) = Four_Dim(3, 3)

    '    Three_Dim(15, 0, 0) = Four_Dim(1, 1)
    '    Three_Dim(15, 0, 1) = Four_Dim(1, 2)
    '    Three_Dim(15, 0, 2) = Four_Dim(1, 3)
    '    Three_Dim(15, 1, 0) = Four_Dim(2, 1)
    '    Three_Dim(15, 1, 1) = Four_Dim(2, 2)
    '    Three_Dim(15, 1, 2) = Four_Dim(2, 3)
    '    Three_Dim(15, 2, 0) = Four_Dim(3, 1)
    '    Three_Dim(15, 2, 1) = Four_Dim(3, 2)
    '    Three_Dim(15, 2, 2) = Four_Dim(3, 3)

    '    'For matrixNum As Integer = 0 To 15
    '    '    For i = 0 To 2
    '    '        For j = 0 To 2
    '    '            Three_Dim
    '    '        Next
    '    '    Next
    '    'Next

    '    'Dim Three_Dim2(3, 3) As Double
    '    'Dim Three_Dim3(3, 3) As Double
    '    'Dim Three_Dim4(3, 3) As Double
    '    'Dim Three_Dim5(3, 3) As Double
    '    'Dim Three_Dim6(3, 3) As Double
    '    'Dim Three_Dim7(3, 3) As Double
    '    'Dim Three_Dim8(3, 3) As Double
    '    'Dim Three_Dim9(3, 3) As Double
    '    'Dim Three_Dim10(3, 3) As Double
    '    'Dim Three_Dim11(3, 3) As Double
    '    'Dim Three_Dim12(3, 3) As Double
    '    'Dim Three_Dim13(3, 3) As Double
    '    'Dim Three_Dim14(3, 3) As Double
    '    'Dim Three_Dim15(3, 3) As Double
    '    'Dim Three_Dim16(3, 3) As Double
    '    '        CofactorMatrix_4x4(0, 0)(16) = getDet_3x3()
    '    Return CofactorMatrix_4x4(0, 0) 'Masih salah.
    'End Function

    'Public Function getMinorMatrix_4x4(ByRef Three_Dim(,) As Double) As Double
    '    Dim MinorMatrix_4x4(3, 3) As Double
    '    For i = 0 To 2
    '        For j = 0 To 2

    '        Next
    '    Next
    '    Return MinorMatrix_4x4(,)
    'End Function

    'Public Function getAdjointMatrix_4x4() As Matrix4x4 'Belum

    'End Function

    Public Sub OnePointProjection(c As Double) 'Ini vt kan ya?
        Dim temp As New Matrix4x4
        temp.Mat(2, 0) = 0.5
        temp.Mat(2, 1) = 0.5
        temp.Mat(2, 2) = 0
        'temp.Mat(0, 3) = (-1 / c)
        'temp.Mat(1, 3) = (-1 / c)
        temp.Mat(2, 3) = -(-1 / c)
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
            'identity
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
End Class
