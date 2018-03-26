<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MainCanvas = New System.Windows.Forms.PictureBox()
        Me.DrawMeshButton = New System.Windows.Forms.Button()
        Me.ScreenCoordLabel = New System.Windows.Forms.Label()
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainCanvas
        '
        Me.MainCanvas.BackColor = System.Drawing.Color.White
        Me.MainCanvas.Location = New System.Drawing.Point(13, 13)
        Me.MainCanvas.Name = "MainCanvas"
        Me.MainCanvas.Size = New System.Drawing.Size(415, 433)
        Me.MainCanvas.TabIndex = 0
        Me.MainCanvas.TabStop = False
        '
        'DrawMeshButton
        '
        Me.DrawMeshButton.Location = New System.Drawing.Point(431, 13)
        Me.DrawMeshButton.Name = "DrawMeshButton"
        Me.DrawMeshButton.Size = New System.Drawing.Size(150, 23)
        Me.DrawMeshButton.TabIndex = 1
        Me.DrawMeshButton.Text = "Draw Mesh"
        Me.DrawMeshButton.UseVisualStyleBackColor = True
        '
        'ScreenCoordLabel
        '
        Me.ScreenCoordLabel.AutoSize = True
        Me.ScreenCoordLabel.Location = New System.Drawing.Point(432, 39)
        Me.ScreenCoordLabel.Name = "ScreenCoordLabel"
        Me.ScreenCoordLabel.Size = New System.Drawing.Size(125, 13)
        Me.ScreenCoordLabel.TabIndex = 2
        Me.ScreenCoordLabel.Text = "Coordinates: X = 0, Y = 0"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 459)
        Me.Controls.Add(Me.ScreenCoordLabel)
        Me.Controls.Add(Me.DrawMeshButton)
        Me.Controls.Add(Me.MainCanvas)
        Me.Name = "MainForm"
        Me.Text = "Testing Polygon Mesh"
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainCanvas As PictureBox
    Friend WithEvents DrawMeshButton As Button
    Friend WithEvents ScreenCoordLabel As Label
End Class
