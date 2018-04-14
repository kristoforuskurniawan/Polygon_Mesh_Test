Public Class AEL
    Public head As EdgeTable
    Public length As Integer
    Private s As New Stack(Of EdgeTable)

    Public Sub New()
        head = Nothing
        length = 0
        s.Clear()
    End Sub

    Public Sub Add(tempdata As EdgeTable)
        Dim node As EdgeTable = New EdgeTable(tempdata)
        Dim currentNode As EdgeTable = Me.head
        Dim prevNode As New EdgeTable
        ' an empty list
        If currentNode Is Nothing Then
            Me.head = node
            Me.length = 1
        Else
            While Not (currentNode Is Nothing)
                If node.xofymin < currentNode.xofymin OrElse (node.xofymin = currentNode.xofymin AndAlso node.dx / node.dy < currentNode.dx / currentNode.dy) Then
                    s.Push(node) 'old
                    s.Push(currentNode) 'old
                    'node.nxt = currentNode
                    'prevNode.nxt = node
                    Exit While
                Else
                    s.Push(currentNode) old
                    If currentNode.nxt Is Nothing Then
                        s.Push(node) 'old
                        'currentNode.nxt = node
                        Exit While
                    End If
                End If
                'prevNode = currentNode
                currentNode = currentNode.nxt
            End While
            RefillAET() 'old
        End If
    End Sub

    Public Sub Remove(position As Integer)
        Dim currentNode As EdgeTable = Me.head
        Dim length As Integer = Me.length - 1
        Dim counter As Integer = 0
        Dim temp As EdgeTable

        ' an invalid position
        If position < 0 OrElse position > length Then
            MsgBox("Out of index in removing node")
        End If
        ' the first node is removed
        If position = 0 Then
            Me.head = Me.head.nxt

        Else
            ' any other node is removed
            For i As Integer = 1 To position - 1
                currentNode = currentNode.nxt
            Next

            If Not (currentNode.nxt.nxt Is Nothing) Then
                temp = currentNode
                temp.nxt = temp.nxt.nxt
            Else
                temp = currentNode
                temp.nxt = Nothing
            End If

        End If
        Me.length = Me.length - 1
    End Sub

    Public Sub Update()
        If length > 0 Then
            Dim currentNode As EdgeTable = Me.head
            While Not (currentNode Is Nothing)
                'Update the data
                currentNode.carry = currentNode.carry + currentNode.dx
                If (currentNode.dx < 0) Then
                    While (-(currentNode.carry + currentNode.carry) >= currentNode.dy)
                        currentNode.carry = currentNode.carry + currentNode.dy
                        currentNode.xofymin = currentNode.xofymin - 1
                    End While
                Else
                    While ((currentNode.carry + currentNode.carry) >= currentNode.dy)
                        currentNode.carry = currentNode.carry - currentNode.dy
                        currentNode.xofymin = currentNode.xofymin + 1
                    End While
                End If
                s.Push(currentNode)
                currentNode = currentNode.nxt
            End While
            RefillAET()
        End If
    End Sub

    Public Sub Sorted()
        Dim currentNode As EdgeTable = Me.head
        Me.head = Nothing
        While Not (currentNode Is Nothing)
            Me.Add(currentNode)
            currentNode = currentNode.nxt
        End While

    End Sub

    Public Sub Single_expired(i As Integer)
        If length > 0 Then
            Dim temp As New EdgeTable
            Dim currentNode As EdgeTable = Me.head
            While Not (currentNode Is Nothing)
                If currentNode.ymax = (i + currentNode.normalize) Then
                    'ignore
                    MsgBox("ignore")
                Else

                    s.Push(currentNode)
                End If
                currentNode = currentNode.nxt
            End While
            RefillAET()
        End If
    End Sub

    Public Sub Double_expired(i As Integer)
        If length > 1 Then
            Dim currentNode As EdgeTable = Me.head
            Dim nextnode As EdgeTable = currentNode.nxt
            While Not (currentNode Is Nothing)
                If (currentNode.xofymin = nextnode.xofymin) AndAlso currentNode.carry = nextnode.carry = 0 Then
                    If ((currentNode.ymax - currentNode.normalize) = i - 1) And ((nextnode.ymax - nextnode.normalize) = i - 1) Then
                        MsgBox("tereerere te te tet teret")
                        'ignore
                    End If
                Else
                    s.Push(currentNode)
                End If
                currentNode = currentNode.nxt
            End While
            RefillAET()
        End If
    End Sub

    Private Sub RefillAET()
        If Not (s.Count = 0) Then
            Me.head = Nothing
            Dim prevtemp As EdgeTable
            Dim temp As EdgeTable = s.Pop()
            While Not (s.Count() = 0)
                prevtemp = s.Pop()
                'prevtemp.nxt = Nothing
                prevtemp.nxt = temp
                temp = prevtemp
            End While
            Me.head = temp
            length = CountAET()
            s.Clear()
        End If
    End Sub

    Public Function CountAET()
        Dim i As Integer = 0
        Dim node As EdgeTable = Me.head
        While Not (node Is Nothing)
            i = i + 1
            node = node.nxt
        End While
        Return i
    End Function
End Class