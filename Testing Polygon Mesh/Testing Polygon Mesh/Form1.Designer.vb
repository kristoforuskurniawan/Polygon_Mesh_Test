<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
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
        Me.LightSourceLabel = New System.Windows.Forms.Label()
        Me.Light_XPosTextBox = New System.Windows.Forms.TextBox()
        Me.Light_YPosTextBox = New System.Windows.Forms.TextBox()
        Me.Light_ZPosTextBox = New System.Windows.Forms.TextBox()
        Me.X_LightSourceLabel = New System.Windows.Forms.Label()
        Me.Y_LightSourceLabel = New System.Windows.Forms.Label()
        Me.Z_LightSourceLabel = New System.Windows.Forms.Label()
        Me.AddLightButton = New System.Windows.Forms.Button()
        Me.LightSourceListBox = New System.Windows.Forms.ListBox()
        Me.LightSourceListLabel = New System.Windows.Forms.Label()
        Me.DeleteLightSourceButton = New System.Windows.Forms.Button()
        Me.AnimationTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TranslateButton = New System.Windows.Forms.Button()
        Me.ambientTxtBox = New System.Windows.Forms.TextBox()
        Me.diffuseTxtBox = New System.Windows.Forms.TextBox()
        Me.specularTxtBox = New System.Windows.Forms.TextBox()
        Me.exponentTxtBox = New System.Windows.Forms.TextBox()
        Me.ambientLbl = New System.Windows.Forms.Label()
        Me.diffuseLbl = New System.Windows.Forms.Label()
        Me.specularLbl = New System.Windows.Forms.Label()
        Me.specularExponentLbl = New System.Windows.Forms.Label()
        Me.DoShadingButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainCanvas
        '
        Me.MainCanvas.BackColor = System.Drawing.Color.Black
        Me.MainCanvas.Location = New System.Drawing.Point(13, 13)
        Me.MainCanvas.Name = "MainCanvas"
        Me.MainCanvas.Size = New System.Drawing.Size(415, 489)
        Me.MainCanvas.TabIndex = 0
        Me.MainCanvas.TabStop = False
        '
        'DrawMeshButton
        '
        Me.DrawMeshButton.Location = New System.Drawing.Point(442, 140)
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
        Me.X_TransTextBox.Location = New System.Drawing.Point(519, 169)
        Me.X_TransTextBox.Name = "X_TransTextBox"
        Me.X_TransTextBox.Size = New System.Drawing.Size(63, 20)
        Me.X_TransTextBox.TabIndex = 9
        Me.X_TransTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Y_TransTextBox
        '
        Me.Y_TransTextBox.Location = New System.Drawing.Point(519, 195)
        Me.Y_TransTextBox.Name = "Y_TransTextBox"
        Me.Y_TransTextBox.Size = New System.Drawing.Size(62, 20)
        Me.Y_TransTextBox.TabIndex = 10
        Me.Y_TransTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Z_TransTextBox
        '
        Me.Z_TransTextBox.Location = New System.Drawing.Point(519, 221)
        Me.Z_TransTextBox.Name = "Z_TransTextBox"
        Me.Z_TransTextBox.Size = New System.Drawing.Size(63, 20)
        Me.Z_TransTextBox.TabIndex = 11
        Me.Z_TransTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LightSourceLabel
        '
        Me.LightSourceLabel.AutoSize = True
        Me.LightSourceLabel.Location = New System.Drawing.Point(481, 273)
        Me.LightSourceLabel.Name = "LightSourceLabel"
        Me.LightSourceLabel.Size = New System.Drawing.Size(67, 13)
        Me.LightSourceLabel.TabIndex = 15
        Me.LightSourceLabel.Text = "Light Source"
        '
        'Light_XPosTextBox
        '
        Me.Light_XPosTextBox.Location = New System.Drawing.Point(519, 294)
        Me.Light_XPosTextBox.Name = "Light_XPosTextBox"
        Me.Light_XPosTextBox.Size = New System.Drawing.Size(62, 20)
        Me.Light_XPosTextBox.TabIndex = 16
        Me.Light_XPosTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Light_YPosTextBox
        '
        Me.Light_YPosTextBox.Location = New System.Drawing.Point(519, 323)
        Me.Light_YPosTextBox.Name = "Light_YPosTextBox"
        Me.Light_YPosTextBox.Size = New System.Drawing.Size(62, 20)
        Me.Light_YPosTextBox.TabIndex = 17
        Me.Light_YPosTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Light_ZPosTextBox
        '
        Me.Light_ZPosTextBox.Location = New System.Drawing.Point(519, 349)
        Me.Light_ZPosTextBox.Name = "Light_ZPosTextBox"
        Me.Light_ZPosTextBox.Size = New System.Drawing.Size(62, 20)
        Me.Light_ZPosTextBox.TabIndex = 18
        Me.Light_ZPosTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'X_LightSourceLabel
        '
        Me.X_LightSourceLabel.AutoSize = True
        Me.X_LightSourceLabel.Location = New System.Drawing.Point(439, 297)
        Me.X_LightSourceLabel.Name = "X_LightSourceLabel"
        Me.X_LightSourceLabel.Size = New System.Drawing.Size(54, 13)
        Me.X_LightSourceLabel.TabIndex = 19
        Me.X_LightSourceLabel.Text = "X Position"
        '
        'Y_LightSourceLabel
        '
        Me.Y_LightSourceLabel.AutoSize = True
        Me.Y_LightSourceLabel.Location = New System.Drawing.Point(439, 326)
        Me.Y_LightSourceLabel.Name = "Y_LightSourceLabel"
        Me.Y_LightSourceLabel.Size = New System.Drawing.Size(54, 13)
        Me.Y_LightSourceLabel.TabIndex = 20
        Me.Y_LightSourceLabel.Text = "Y Position"
        '
        'Z_LightSourceLabel
        '
        Me.Z_LightSourceLabel.AutoSize = True
        Me.Z_LightSourceLabel.Location = New System.Drawing.Point(439, 352)
        Me.Z_LightSourceLabel.Name = "Z_LightSourceLabel"
        Me.Z_LightSourceLabel.Size = New System.Drawing.Size(54, 13)
        Me.Z_LightSourceLabel.TabIndex = 21
        Me.Z_LightSourceLabel.Text = "Z Position"
        '
        'AddLightButton
        '
        Me.AddLightButton.Location = New System.Drawing.Point(442, 375)
        Me.AddLightButton.Name = "AddLightButton"
        Me.AddLightButton.Size = New System.Drawing.Size(140, 23)
        Me.AddLightButton.TabIndex = 22
        Me.AddLightButton.Text = "Add Light Source"
        Me.AddLightButton.UseVisualStyleBackColor = True
        '
        'LightSourceListBox
        '
        Me.LightSourceListBox.FormattingEnabled = True
        Me.LightSourceListBox.Location = New System.Drawing.Point(598, 189)
        Me.LightSourceListBox.Name = "LightSourceListBox"
        Me.LightSourceListBox.Size = New System.Drawing.Size(219, 277)
        Me.LightSourceListBox.TabIndex = 27
        '
        'LightSourceListLabel
        '
        Me.LightSourceListLabel.AutoSize = True
        Me.LightSourceListLabel.Location = New System.Drawing.Point(657, 169)
        Me.LightSourceListLabel.Name = "LightSourceListLabel"
        Me.LightSourceListLabel.Size = New System.Drawing.Size(97, 13)
        Me.LightSourceListLabel.TabIndex = 28
        Me.LightSourceListLabel.Text = "Light Source(s) List"
        '
        'DeleteLightSourceButton
        '
        Me.DeleteLightSourceButton.Location = New System.Drawing.Point(598, 476)
        Me.DeleteLightSourceButton.Name = "DeleteLightSourceButton"
        Me.DeleteLightSourceButton.Size = New System.Drawing.Size(219, 23)
        Me.DeleteLightSourceButton.TabIndex = 29
        Me.DeleteLightSourceButton.Text = "Delete Selected"
        Me.DeleteLightSourceButton.UseVisualStyleBackColor = True
        '
        'AnimationTimer
        '
        Me.AnimationTimer.Interval = 1
        '
        'TranslateButton
        '
        Me.TranslateButton.Location = New System.Drawing.Point(442, 246)
        Me.TranslateButton.Name = "TranslateButton"
        Me.TranslateButton.Size = New System.Drawing.Size(140, 24)
        Me.TranslateButton.TabIndex = 32
        Me.TranslateButton.Text = "Translate"
        Me.TranslateButton.UseVisualStyleBackColor = True
        '
        'ambientTxtBox
        '
        Me.ambientTxtBox.Location = New System.Drawing.Point(596, 51)
        Me.ambientTxtBox.Name = "ambientTxtBox"
        Me.ambientTxtBox.Size = New System.Drawing.Size(69, 20)
        Me.ambientTxtBox.TabIndex = 36
        Me.ambientTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'diffuseTxtBox
        '
        Me.diffuseTxtBox.Location = New System.Drawing.Point(671, 51)
        Me.diffuseTxtBox.Name = "diffuseTxtBox"
        Me.diffuseTxtBox.Size = New System.Drawing.Size(69, 20)
        Me.diffuseTxtBox.TabIndex = 37
        Me.diffuseTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'specularTxtBox
        '
        Me.specularTxtBox.Location = New System.Drawing.Point(746, 51)
        Me.specularTxtBox.Name = "specularTxtBox"
        Me.specularTxtBox.Size = New System.Drawing.Size(69, 20)
        Me.specularTxtBox.TabIndex = 38
        Me.specularTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'exponentTxtBox
        '
        Me.exponentTxtBox.Location = New System.Drawing.Point(674, 113)
        Me.exponentTxtBox.Name = "exponentTxtBox"
        Me.exponentTxtBox.Size = New System.Drawing.Size(69, 20)
        Me.exponentTxtBox.TabIndex = 39
        Me.exponentTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ambientLbl
        '
        Me.ambientLbl.AutoSize = True
        Me.ambientLbl.Location = New System.Drawing.Point(606, 23)
        Me.ambientLbl.Name = "ambientLbl"
        Me.ambientLbl.Size = New System.Drawing.Size(45, 13)
        Me.ambientLbl.TabIndex = 40
        Me.ambientLbl.Text = "Ambient"
        '
        'diffuseLbl
        '
        Me.diffuseLbl.AutoSize = True
        Me.diffuseLbl.Location = New System.Drawing.Point(685, 23)
        Me.diffuseLbl.Name = "diffuseLbl"
        Me.diffuseLbl.Size = New System.Drawing.Size(40, 13)
        Me.diffuseLbl.TabIndex = 41
        Me.diffuseLbl.Text = "Diffuse"
        '
        'specularLbl
        '
        Me.specularLbl.AutoSize = True
        Me.specularLbl.Location = New System.Drawing.Point(754, 23)
        Me.specularLbl.Name = "specularLbl"
        Me.specularLbl.Size = New System.Drawing.Size(49, 13)
        Me.specularLbl.TabIndex = 42
        Me.specularLbl.Text = "Specular"
        '
        'specularExponentLbl
        '
        Me.specularExponentLbl.AutoSize = True
        Me.specularExponentLbl.Location = New System.Drawing.Point(638, 90)
        Me.specularExponentLbl.Name = "specularExponentLbl"
        Me.specularExponentLbl.Size = New System.Drawing.Size(148, 13)
        Me.specularExponentLbl.TabIndex = 43
        Me.specularExponentLbl.Text = "Specular Reflection Exponent"
        '
        'DoShadingButton
        '
        Me.DoShadingButton.Location = New System.Drawing.Point(651, 139)
        Me.DoShadingButton.Name = "DoShadingButton"
        Me.DoShadingButton.Size = New System.Drawing.Size(112, 23)
        Me.DoShadingButton.TabIndex = 44
        Me.DoShadingButton.Text = "Shade Sphere"
        Me.DoShadingButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(439, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "X Movement"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(439, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Y Movement"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(439, 228)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Z Movement"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 514)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DoShadingButton)
        Me.Controls.Add(Me.specularExponentLbl)
        Me.Controls.Add(Me.specularLbl)
        Me.Controls.Add(Me.diffuseLbl)
        Me.Controls.Add(Me.ambientLbl)
        Me.Controls.Add(Me.exponentTxtBox)
        Me.Controls.Add(Me.specularTxtBox)
        Me.Controls.Add(Me.diffuseTxtBox)
        Me.Controls.Add(Me.ambientTxtBox)
        Me.Controls.Add(Me.TranslateButton)
        Me.Controls.Add(Me.DeleteLightSourceButton)
        Me.Controls.Add(Me.LightSourceListLabel)
        Me.Controls.Add(Me.LightSourceListBox)
        Me.Controls.Add(Me.AddLightButton)
        Me.Controls.Add(Me.Z_LightSourceLabel)
        Me.Controls.Add(Me.Y_LightSourceLabel)
        Me.Controls.Add(Me.X_LightSourceLabel)
        Me.Controls.Add(Me.Light_ZPosTextBox)
        Me.Controls.Add(Me.Light_YPosTextBox)
        Me.Controls.Add(Me.Light_XPosTextBox)
        Me.Controls.Add(Me.LightSourceLabel)
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
    Friend WithEvents LightSourceLabel As Label
    Friend WithEvents Light_XPosTextBox As TextBox
    Friend WithEvents Light_YPosTextBox As TextBox
    Friend WithEvents Light_ZPosTextBox As TextBox
    Friend WithEvents X_LightSourceLabel As Label
    Friend WithEvents Y_LightSourceLabel As Label
    Friend WithEvents Z_LightSourceLabel As Label
    Friend WithEvents AddLightButton As Button
    Friend WithEvents LightSourceListBox As ListBox
    Friend WithEvents LightSourceListLabel As Label
    Friend WithEvents DeleteLightSourceButton As Button
    Friend WithEvents AnimationTimer As Timer
    Friend WithEvents TranslateButton As Button
    Friend WithEvents ambientTxtBox As TextBox
    Friend WithEvents diffuseTxtBox As TextBox
    Friend WithEvents specularTxtBox As TextBox
    Friend WithEvents exponentTxtBox As TextBox
    Friend WithEvents ambientLbl As Label
    Friend WithEvents diffuseLbl As Label
    Friend WithEvents specularLbl As Label
    Friend WithEvents specularExponentLbl As Label
    Friend WithEvents DoShadingButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
