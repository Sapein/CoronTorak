<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Me.lblTeam = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.lblLicenses = New System.Windows.Forms.Label
        Me.lblGithub = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Location = New System.Drawing.Point(167, 22)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(105, 39)
        Me.lblTeam.TabIndex = 1
        Me.lblTeam.Text = "Eylos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sapein - Programmer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dazzey - Artist"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(190, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(59, 13)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Corontorak"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLicenses
        '
        Me.lblLicenses.AutoSize = True
        Me.lblLicenses.Location = New System.Drawing.Point(194, 71)
        Me.lblLicenses.Name = "lblLicenses"
        Me.lblLicenses.Size = New System.Drawing.Size(51, 13)
        Me.lblLicenses.TabIndex = 3
        Me.lblLicenses.Text = "[licenses]"
        '
        'lblGithub
        '
        Me.lblGithub.AutoSize = True
        Me.lblGithub.Location = New System.Drawing.Point(186, 91)
        Me.lblGithub.Name = "lblGithub"
        Me.lblGithub.Size = New System.Drawing.Size(66, 13)
        Me.lblGithub.TabIndex = 4
        Me.lblGithub.Text = "Github: [link]"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DodgerBlue
        Me.ClientSize = New System.Drawing.Size(465, 340)
        Me.Controls.Add(Me.lblGithub)
        Me.Controls.Add(Me.lblLicenses)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblTeam)
        Me.Name = "About"
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblLicenses As System.Windows.Forms.Label
    Friend WithEvents lblGithub As System.Windows.Forms.Label
End Class
