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
        Me.SphereRadLabel = New System.Windows.Forms.Label()
        Me.SphereRadInput = New System.Windows.Forms.TextBox()
        Me.LongitudeLabel = New System.Windows.Forms.Label()
        Me.LatitudeLabel = New System.Windows.Forms.Label()
        Me.LongiInput = New System.Windows.Forms.TextBox()
        Me.LatiInput = New System.Windows.Forms.TextBox()
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
        'SphereRadLabel
        '
        Me.SphereRadLabel.AutoSize = True
        Me.SphereRadLabel.Location = New System.Drawing.Point(435, 118)
        Me.SphereRadLabel.Name = "SphereRadLabel"
        Me.SphereRadLabel.Size = New System.Drawing.Size(77, 13)
        Me.SphereRadLabel.TabIndex = 3
        Me.SphereRadLabel.Text = "Sphere Radius"
        '
        'SphereRadInput
        '
        Me.SphereRadInput.Location = New System.Drawing.Point(518, 115)
        Me.SphereRadInput.Name = "SphereRadInput"
        Me.SphereRadInput.Size = New System.Drawing.Size(62, 20)
        Me.SphereRadInput.TabIndex = 4
        '
        'LongitudeLabel
        '
        Me.LongitudeLabel.AutoSize = True
        Me.LongitudeLabel.Location = New System.Drawing.Point(438, 144)
        Me.LongitudeLabel.Name = "LongitudeLabel"
        Me.LongitudeLabel.Size = New System.Drawing.Size(54, 13)
        Me.LongitudeLabel.TabIndex = 5
        Me.LongitudeLabel.Text = "Longitude"
        '
        'LatitudeLabel
        '
        Me.LatitudeLabel.AutoSize = True
        Me.LatitudeLabel.Location = New System.Drawing.Point(438, 174)
        Me.LatitudeLabel.Name = "LatitudeLabel"
        Me.LatitudeLabel.Size = New System.Drawing.Size(45, 13)
        Me.LatitudeLabel.TabIndex = 6
        Me.LatitudeLabel.Text = "Latitude"
        '
        'LongiInput
        '
        Me.LongiInput.Location = New System.Drawing.Point(518, 144)
        Me.LongiInput.Name = "LongiInput"
        Me.LongiInput.Size = New System.Drawing.Size(63, 20)
        Me.LongiInput.TabIndex = 7
        '
        'LatiInput
        '
        Me.LatiInput.Location = New System.Drawing.Point(518, 171)
        Me.LatiInput.Name = "LatiInput"
        Me.LatiInput.Size = New System.Drawing.Size(63, 20)
        Me.LatiInput.TabIndex = 8
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 459)
        Me.Controls.Add(Me.LatiInput)
        Me.Controls.Add(Me.LongiInput)
        Me.Controls.Add(Me.LatitudeLabel)
        Me.Controls.Add(Me.LongitudeLabel)
        Me.Controls.Add(Me.SphereRadInput)
        Me.Controls.Add(Me.SphereRadLabel)
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
    Friend WithEvents SphereRadLabel As Label
    Friend WithEvents SphereRadInput As TextBox
    Friend WithEvents LongitudeLabel As Label
    Friend WithEvents LatitudeLabel As Label
    Friend WithEvents LongiInput As TextBox
    Friend WithEvents LatiInput As TextBox
End Class
