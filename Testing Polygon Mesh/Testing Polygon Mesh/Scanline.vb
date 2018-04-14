﻿Module Scanline
    Dim edgetable As List(Of EdgeTable) 'SET
    Dim AET As AEL
    Dim stacker As Stack(Of EdgeTable)

    Enum poly
        p0 = 0
        p1 = 1
        p2 = 2
    End Enum

    Public Sub FillPolygon(a As ListPolygons, b As ListPoints, ByRef g As Graphics, ByRef bmp As Bitmap, pen As Pen)
        edgetable = New List(Of EdgeTable)
        stacker = New Stack(Of EdgeTable)
        edgetable.Clear()
        stacker.Clear()
        FillSET(a, b)
        AET = New AEL
        ProcessAET(g, bmp, pen)
    End Sub

    Public Sub FillSET(a As ListPolygons, b As ListPoints)
        Dim min As Integer = getMinimumY(a, b)
        Dim max As Integer = getMaximumY(a, b)
        Dim size As Integer = max - min + 1
        resizeArray(edgetable, size)
        DeclareTemp(min, a.Elmt(0).p1, a.Elmt(0).p2, a, b)


    End Sub

    Public Sub DeclareTemp(min As Integer, i As Integer, j As Integer, a As ListPolygons, b As ListPoints)
        If Not (b.Elmt(i).y = b.Elmt(j).y) Then
            Dim temp As New EdgeTable
            temp.normalize = min
            temp.ymin = If(b.Elmt(i).y <= b.Elmt(j).y, b.Elmt(i).y, b.Elmt(j).y)
            temp.ymax = If(b.Elmt(i).y <= b.Elmt(j).y, b.Elmt(i).y, b.Elmt(j).y)
            temp.xofymin = If(b.Elmt(i).y <= b.Elmt(j).y, b.Elmt(i).x, b.Elmt(j).x)
            temp.dx = b.Elmt(j).x - b.Elmt(i).x
            temp.dy = b.Elmt(j).y - b.Elmt(i).y
            temp.carry = 0
            temp.zofymin = If(b.Elmt(i).y <= b.Elmt(j).y, b.Elmt(i).z, b.Elmt(j).z)
            temp.nxt = Nothing
            If temp.dy < 0 Then
                temp.dy = -temp.dy
                temp.dx = -temp.dx
            End If
            Dim index As Integer = temp.ymin - min
            sortedInsertion(edgetable(index), temp)
        End If
    End Sub


    Public Sub ProcessAET(ByRef g As Graphics, ByRef bmp As Bitmap, pen As Pen)
        'Loop from index 0 to Max
        Dim current As EdgeTable
        For i As Integer = 0 To edgetable.Count - 1
            'assign the temporary variable to save the current data 
            current = edgetable(i)
            'delete the single expired
            If i > 0 Then CheckSingleExpired(i)
            'insert the new edges (sorted)

            While Not (current Is Nothing)
                AET.Add(current)
                'MsgBox("break")
                current = current.nxt
                'MsgBox(AET.length.ToString)
            End While
            'draw lines (don't forget about the normalization)
            drawlines(i, g, bmp, pen)
            'delete the double expired
            '
            'If i > 0 Then CheckDoubleExpired(i) 'cause bug
            'update 
            AET.Update()
            'sort
            AET.Sorted()
            'sortAETStackVersion() ' is failed
        Next
    End Sub

    Public Sub drawlines(y As Integer, ByRef g As Graphics, ByRef bmp As Bitmap, pen As Pen)
        If AET.length > 0 Then
            Dim data As EdgeTable = AET.head
            Dim data2 As EdgeTable = data.nxt
            While Not (data Is Nothing Or data2 Is Nothing)
                ' MsgBox(i.ToString + ": "+data.xofymin.ToString + " " + data2.xofymin.ToString)
                If (data.xofymin = data2.xofymin) Then
                    'setpixel
                    bmp.SetPixel(data.xofymin, y + data.normalize, pen.Color)
                Else
                    'MsgBox(AET.length.ToString + " -- " + (y + data.normalize).ToString)
                    g.DrawLine(pen, data.xofymin, y + data.normalize, data2.xofymin, y + data2.normalize)
                End If
                data = data.nxt.nxt
                If Not (data Is Nothing) Then
                    data2 = data.nxt
                Else
                    Exit While
                End If
            End While

        End If
    End Sub

    Public Sub InsertEdgesToAET(data As EdgeTable)
        'Check the scanline, if there is new edge, insert it
        AET.Add(data)
    End Sub

    Public Sub CheckSingleExpired(y As Integer)
        'create a counter
        Dim currentdata As EdgeTable = AET.head
        Dim counter As Integer = 0
        If (AET.CountAET() > 0) Then
            While Not (currentdata Is Nothing)
                If currentdata.ymax = y + currentdata.normalize Then
                    'delete node
                    AET.Remove(counter)
                    counter = counter - 1
                End If
                counter = counter + 1
                currentdata = currentdata.nxt
            End While
        End If
        'replace AET with new one
    End Sub
    '


    Public Sub sortedInsertion(ByRef target As EdgeTable, temp As EdgeTable)
        If target Is Nothing Then
            'if there is no data in that index
            'assign the temp to that index 
            target = temp
        Else
            stacker.Clear()
            Dim targettemp As EdgeTable = Nothing
            Dim node As EdgeTable = target
            Dim i As Integer = 0
            ' node as the current node that will be used to tranverse the SET
            While Not (node Is Nothing)
                If node.xofymin < temp.xofymin Then
                    'if xofymin value of current node is less than the temp data
                    If node.nxt Is Nothing Then
                        'assign it, it's the last place
                        'target.nxt = temp
                        If i = 0 Then stacker.Push(node)
                        stacker.Push(temp)
                        Exit While
                    Else
                        'it's not the last place, tranverse the SET
                        stacker.Push(node)
                        node = node.nxt
                    End If
                ElseIf node.xofymin > temp.xofymin Then
                    'if xofymin value of current node is more than the temp data
                    Dim store As EdgeTable = node
                    'store the current node's data
                    'target = temp
                    stacker.Push(temp)
                    'replace the current node with the temp data
                    If node.nxt Is Nothing Then
                        'if it's the last, just assign the stored data to the last
                        'target.nxt = store
                        stacker.Push(node)
                        Exit While
                    Else
                        'if it's not the last
                        'tranverse the SET, but use the stored data as the temp data
                        temp = store
                        node = node.nxt
                    End If
                Else
                    ' if xofymin of both current node and temp data is same
                    If (node.dx / node.dy) > (temp.dx / temp.dy) Then
                        'if value of current node is more than the temp data
                        Dim store As EdgeTable = node
                        'store the current node's data
                        'target = temp
                        stacker.Push(temp)
                        'replace the current node with the temp data
                        If node.nxt Is Nothing Then
                            'if it's the last, just assign the stored data to the last
                            'target.nxt = store
                            stacker.Push(node)
                            Exit While
                        Else
                            'if it's not the last
                            'transverse the SET, but use the stored data as the temp data
                            temp = store
                            node = node.nxt
                        End If

                    Else
                        'if the value of current node is same or less than the temp data
                        If node.nxt Is Nothing Then
                            'If it's the last, just assign the stored data to the last
                            'target.nxt = temp
                            If i = 0 Then stacker.Push(node)
                            stacker.Push(temp)
                            Exit While
                        Else
                            'if it's not the last
                            'tranverse the SET
                            stacker.Push(node)
                            node = node.nxt
                        End If
                    End If
                End If
                i = i + 1
            End While
            'MsgBox(stacker.Count())
            refillAET(stacker, targettemp)
            target = targettemp
            stacker.Clear()
        End If
    End Sub

    Public Sub refillAET(ByRef s As Stack(Of EdgeTable), ByRef target As EdgeTable)

        target = Nothing
        Dim prevtemp As New EdgeTable
        Dim temp As EdgeTable
        If s.Count > 0 Then
            temp = s.Pop()
            temp.nxt = Nothing
        Else
            temp = Nothing
        End If
        While s.Count() > 0
            prevtemp = s.Pop()
            'MsgBox(prevtemp.xofymin.ToString + " " + prevtemp.ymax.ToString)
            prevtemp.nxt = temp
            temp = prevtemp
        End While
        target = temp
        s.Clear()
    End Sub

    Public Sub resizeArray(a As List(Of EdgeTable), size As Integer)
        'resizing array and assign the NULL value to each index
        For i As Integer = 0 To size
            a.Add(Nothing)
        Next
    End Sub

    'Public Sub displaySET(temp As List(Of EdgeTable))
    '    'to check the content of SET
    '    For i = 0 To temp.Count - 1
    '        If Not (temp(i) Is Nothing) Then
    '            Dim node As EdgeTable = temp(i)
    '            Dim str As String
    '            While Not (node Is Nothing)
    '                str = ""
    '                str = node.ymin.ToString + " " + node.ymax.ToString + " " + node.xofymin.ToString + " " + node.dx.ToString
    '                MsgBox(str)
    '                node = node.nxt
    '            End While

    '        End If
    '    Next
    'End Sub

    'Public Sub displayAET(temp As EdgeTable)
    '    'to check the content of SET
    '    If Not (temp Is Nothing) Then
    '        Dim node As EdgeTable = temp
    '        Dim str As String
    '        While Not (node Is Nothing)
    '            str = ""
    '            str = str + node.ymin.ToString + " " + node.ymax.ToString + " " + node.xofymin.ToString + " " + node.dx.ToString
    '            node = node.nxt
    '            MsgBox(str)
    '        End While
    '    End If
    'End Sub

    Public Function getMinimumY(v As ListPolygons, a As ListPoints)
        Dim min As Integer
        min = If(a.Elmt(v.Elmt(0).p1).y < a.Elmt(v.Elmt(0).p2).y, a.Elmt(v.Elmt(0).p1).y, a.Elmt(v.Elmt(0).p2).y)
        min = If(min < a.Elmt(v.Elmt(0).p3).y, min, a.Elmt(v.Elmt(0).p3).y)
        Return min
    End Function

    Public Function getMaximumY(v As ListPolygons, a As ListPoints)
        Dim max As Integer
        max = If(a.Elmt(v.Elmt(0).p1).y > a.Elmt(v.Elmt(0).p2).y, a.Elmt(v.Elmt(0).p1).y, a.Elmt(v.Elmt(0).p2).y)
        max = If(max > a.Elmt(v.Elmt(0).p3).y, max, a.Elmt(v.Elmt(0).p3).y)
        Return max
    End Function

    Public Function CountEdge(head As EdgeTable)
        Dim i As Integer = 0
        Dim node As EdgeTable = head
        While Not (node Is Nothing)
            i = i + 1
            node = node.nxt
        End While
        Return i
    End Function

End Module

