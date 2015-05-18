<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuS))
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnAbout = New System.Windows.Forms.Button
        Me.picLogo = New System.Windows.Forms.PictureBox
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(12, 111)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(97, 37)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New Game"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(142, 111)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(97, 37)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "Load Game"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(377, 111)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(97, 37)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Location = New System.Drawing.Point(257, 111)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(97, 37)
        Me.btnAbout.TabIndex = 4
        Me.btnAbout.Text = "About Us"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.BackgroundImage = CType(resources.GetObject("picLogo.BackgroundImage"), System.Drawing.Image)
        Me.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picLogo.Location = New System.Drawing.Point(101, 12)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(284, 93)
        Me.picLogo.TabIndex = 5
        Me.picLogo.TabStop = False
        '
        'MenuS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 160)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnNew)
        Me.Name = "MenuS"
        Me.Text = "Menu"
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
End Class
