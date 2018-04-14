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
        Me.X_TransTextBox = New System.Windows.Forms.TextBox()
        Me.Y_TransTextBox = New System.Windows.Forms.TextBox()
        Me.Z_TransTextBox = New System.Windows.Forms.TextBox()
        Me.X_TransButton = New System.Windows.Forms.Button()
        Me.Y_TransButton = New System.Windows.Forms.Button()
        Me.Z_TransButton = New System.Windows.Forms.Button()
        Me.LightSourceLabel = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.X_LightSourceLabel = New System.Windows.Forms.Label()
        Me.Y_LightSourceLabel = New System.Windows.Forms.Label()
        Me.Z_LightSourceLabel = New System.Windows.Forms.Label()
        Me.AddLightButton = New System.Windows.Forms.Button()
        Me.BackCulling_ONRadioButton = New System.Windows.Forms.RadioButton()
        Me.BackCulling_OFFRadioButton = New System.Windows.Forms.RadioButton()
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
        Me.DrawMeshButton.Location = New System.Drawing.Point(442, 154)
        Me.DrawMeshButton.Name = "DrawMeshButton"
        Me.DrawMeshButton.Size = New System.Drawing.Size(140, 23)
        Me.DrawMeshButton.TabIndex = 1
        Me.DrawMeshButton.Text = "Draw Sphere"
        Me.DrawMeshButton.UseVisualStyleBackColor = True
        '
        'ScreenCoordLabel
        '
        Me.ScreenCoordLabel.AutoSize = True
        Me.ScreenCoordLabel.Location = New System.Drawing.Point(439, 23)
        Me.ScreenCoordLabel.Name = "ScreenCoordLabel"
        Me.ScreenCoordLabel.Size = New System.Drawing.Size(125, 13)
        Me.ScreenCoordLabel.TabIndex = 2
        Me.ScreenCoordLabel.Text = "Coordinates: X = 0, Y = 0"
        '
        'SphereRadLabel
        '
        Me.SphereRadLabel.AutoSize = True
        Me.SphereRadLabel.Location = New System.Drawing.Point(439, 61)
        Me.SphereRadLabel.Name = "SphereRadLabel"
        Me.SphereRadLabel.Size = New System.Drawing.Size(40, 13)
        Me.SphereRadLabel.TabIndex = 3
        Me.SphereRadLabel.Text = "Radius"
        '
        'SphereRadInput
        '
        Me.SphereRadInput.Location = New System.Drawing.Point(519, 58)
        Me.SphereRadInput.Name = "SphereRadInput"
        Me.SphereRadInput.Size = New System.Drawing.Size(62, 20)
        Me.SphereRadInput.TabIndex = 4
        '
        'LongitudeLabel
        '
        Me.LongitudeLabel.AutoSize = True
        Me.LongitudeLabel.Location = New System.Drawing.Point(439, 87)
        Me.LongitudeLabel.Name = "LongitudeLabel"
        Me.LongitudeLabel.Size = New System.Drawing.Size(54, 13)
        Me.LongitudeLabel.TabIndex = 5
        Me.LongitudeLabel.Text = "Longitude"
        '
        'LatitudeLabel
        '
        Me.LatitudeLabel.AutoSize = True
        Me.LatitudeLabel.Location = New System.Drawing.Point(439, 117)
        Me.LatitudeLabel.Name = "LatitudeLabel"
        Me.LatitudeLabel.Size = New System.Drawing.Size(45, 13)
        Me.LatitudeLabel.TabIndex = 6
        Me.LatitudeLabel.Text = "Latitude"
        '
        'LongiInput
        '
        Me.LongiInput.Location = New System.Drawing.Point(519, 87)
        Me.LongiInput.Name = "LongiInput"
        Me.LongiInput.Size = New System.Drawing.Size(63, 20)
        Me.LongiInput.TabIndex = 7
        '
        'LatiInput
        '
        Me.LatiInput.Location = New System.Drawing.Point(519, 114)
        Me.LatiInput.Name = "LatiInput"
        Me.LatiInput.Size = New System.Drawing.Size(63, 20)
        Me.LatiInput.TabIndex = 8
        '
        'X_TransTextBox
        '
        Me.X_TransTextBox.Location = New System.Drawing.Point(442, 197)
        Me.X_TransTextBox.Name = "X_TransTextBox"
        Me.X_TransTextBox.Size = New System.Drawing.Size(51, 20)
        Me.X_TransTextBox.TabIndex = 9
        '
        'Y_TransTextBox
        '
        Me.Y_TransTextBox.Location = New System.Drawing.Point(442, 224)
        Me.Y_TransTextBox.Name = "Y_TransTextBox"
        Me.Y_TransTextBox.Size = New System.Drawing.Size(51, 20)
        Me.Y_TransTextBox.TabIndex = 10
        '
        'Z_TransTextBox
        '
        Me.Z_TransTextBox.Location = New System.Drawing.Point(442, 251)
        Me.Z_TransTextBox.Name = "Z_TransTextBox"
        Me.Z_TransTextBox.Size = New System.Drawing.Size(51, 20)
        Me.Z_TransTextBox.TabIndex = 11
        '
        'X_TransButton
        '
        Me.X_TransButton.Location = New System.Drawing.Point(500, 193)
        Me.X_TransButton.Name = "X_TransButton"
        Me.X_TransButton.Size = New System.Drawing.Size(75, 23)
        Me.X_TransButton.TabIndex = 12
        Me.X_TransButton.Text = "Translate X"
        Me.X_TransButton.UseVisualStyleBackColor = True
        '
        'Y_TransButton
        '
        Me.Y_TransButton.Location = New System.Drawing.Point(500, 220)
        Me.Y_TransButton.Name = "Y_TransButton"
        Me.Y_TransButton.Size = New System.Drawing.Size(75, 23)
        Me.Y_TransButton.TabIndex = 13
        Me.Y_TransButton.Text = "Translate Y"
        Me.Y_TransButton.UseVisualStyleBackColor = True
        '
        'Z_TransButton
        '
        Me.Z_TransButton.Location = New System.Drawing.Point(500, 247)
        Me.Z_TransButton.Name = "Z_TransButton"
        Me.Z_TransButton.Size = New System.Drawing.Size(75, 23)
        Me.Z_TransButton.TabIndex = 14
        Me.Z_TransButton.Text = "Translate Z"
        Me.Z_TransButton.UseVisualStyleBackColor = True
        '
        'LightSourceLabel
        '
        Me.LightSourceLabel.AutoSize = True
        Me.LightSourceLabel.Location = New System.Drawing.Point(479, 279)
        Me.LightSourceLabel.Name = "LightSourceLabel"
        Me.LightSourceLabel.Size = New System.Drawing.Size(67, 13)
        Me.LightSourceLabel.TabIndex = 15
        Me.LightSourceLabel.Text = "Light Source"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(519, 304)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(61, 20)
        Me.TextBox1.TabIndex = 16
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(519, 331)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(62, 20)
        Me.TextBox2.TabIndex = 17
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(519, 358)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(62, 20)
        Me.TextBox3.TabIndex = 18
        '
        'X_LightSourceLabel
        '
        Me.X_LightSourceLabel.AutoSize = True
        Me.X_LightSourceLabel.Location = New System.Drawing.Point(445, 307)
        Me.X_LightSourceLabel.Name = "X_LightSourceLabel"
        Me.X_LightSourceLabel.Size = New System.Drawing.Size(54, 13)
        Me.X_LightSourceLabel.TabIndex = 19
        Me.X_LightSourceLabel.Text = "X Position"
        '
        'Y_LightSourceLabel
        '
        Me.Y_LightSourceLabel.AutoSize = True
        Me.Y_LightSourceLabel.Location = New System.Drawing.Point(445, 331)
        Me.Y_LightSourceLabel.Name = "Y_LightSourceLabel"
        Me.Y_LightSourceLabel.Size = New System.Drawing.Size(54, 13)
        Me.Y_LightSourceLabel.TabIndex = 20
        Me.Y_LightSourceLabel.Text = "Y Position"
        '
        'Z_LightSourceLabel
        '
        Me.Z_LightSourceLabel.AutoSize = True
        Me.Z_LightSourceLabel.Location = New System.Drawing.Point(445, 361)
        Me.Z_LightSourceLabel.Name = "Z_LightSourceLabel"
        Me.Z_LightSourceLabel.Size = New System.Drawing.Size(54, 13)
        Me.Z_LightSourceLabel.TabIndex = 21
        Me.Z_LightSourceLabel.Text = "Z Position"
        '
        'AddLightButton
        '
        Me.AddLightButton.Location = New System.Drawing.Point(442, 384)
        Me.AddLightButton.Name = "AddLightButton"
        Me.AddLightButton.Size = New System.Drawing.Size(139, 23)
        Me.AddLightButton.TabIndex = 22
        Me.AddLightButton.Text = "Add Light Source"
        Me.AddLightButton.UseVisualStyleBackColor = True
        '
        'BackCulling_ONRadioButton
        '
        Me.BackCulling_ONRadioButton.AutoSize = True
        Me.BackCulling_ONRadioButton.Location = New System.Drawing.Point(442, 429)
        Me.BackCulling_ONRadioButton.Name = "BackCulling_ONRadioButton"
        Me.BackCulling_ONRadioButton.Size = New System.Drawing.Size(75, 17)
        Me.BackCulling_ONRadioButton.TabIndex = 23
        Me.BackCulling_ONRadioButton.TabStop = True
        Me.BackCulling_ONRadioButton.Text = "Hide Back"
        Me.BackCulling_ONRadioButton.UseVisualStyleBackColor = True
        '
        'BackCulling_OFFRadioButton
        '
        Me.BackCulling_OFFRadioButton.AutoSize = True
        Me.BackCulling_OFFRadioButton.Location = New System.Drawing.Point(442, 413)
        Me.BackCulling_OFFRadioButton.Name = "BackCulling_OFFRadioButton"
        Me.BackCulling_OFFRadioButton.Size = New System.Drawing.Size(80, 17)
        Me.BackCulling_OFFRadioButton.TabIndex = 24
        Me.BackCulling_OFFRadioButton.TabStop = True
        Me.BackCulling_OFFRadioButton.Text = "Show Back"
        Me.BackCulling_OFFRadioButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 459)
        Me.Controls.Add(Me.BackCulling_OFFRadioButton)
        Me.Controls.Add(Me.BackCulling_ONRadioButton)
        Me.Controls.Add(Me.AddLightButton)
        Me.Controls.Add(Me.Z_LightSourceLabel)
        Me.Controls.Add(Me.Y_LightSourceLabel)
        Me.Controls.Add(Me.X_LightSourceLabel)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LightSourceLabel)
        Me.Controls.Add(Me.Z_TransButton)
        Me.Controls.Add(Me.Y_TransButton)
        Me.Controls.Add(Me.X_TransButton)
        Me.Controls.Add(Me.Z_TransTextBox)
        Me.Controls.Add(Me.Y_TransTextBox)
        Me.Controls.Add(Me.X_TransTextBox)
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
    Friend WithEvents X_TransTextBox As TextBox
    Friend WithEvents Y_TransTextBox As TextBox
    Friend WithEvents Z_TransTextBox As TextBox
    Friend WithEvents X_TransButton As Button
    Friend WithEvents Y_TransButton As Button
    Friend WithEvents Z_TransButton As Button
    Friend WithEvents LightSourceLabel As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents X_LightSourceLabel As Label
    Friend WithEvents Y_LightSourceLabel As Label
    Friend WithEvents Z_LightSourceLabel As Label
    Friend WithEvents AddLightButton As Button
    Friend WithEvents BackCulling_ONRadioButton As RadioButton
    Friend WithEvents BackCulling_OFFRadioButton As RadioButton
End Class
