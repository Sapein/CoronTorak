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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.lblTeam = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.lblLicenses = New System.Windows.Forms.Label
        Me.lblGithub = New System.Windows.Forms.Label
        Me.txtCodeLicense = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTeam.Location = New System.Drawing.Point(164, 27)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(136, 48)
        Me.lblTeam.TabIndex = 1
        Me.lblTeam.Text = "Eylos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sapein - Programmer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dazzey - Artist"
        Me.lblTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(195, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(74, 16)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Corontorak"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLicenses
        '
        Me.lblLicenses.AutoSize = True
        Me.lblLicenses.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenses.Location = New System.Drawing.Point(70, 95)
        Me.lblLicenses.Name = "lblLicenses"
        Me.lblLicenses.Size = New System.Drawing.Size(324, 32)
        Me.lblLicenses.TabIndex = 3
        Me.lblLicenses.Text = "Art License: CC Attribution-ShareAlike 3.0 International" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Code License: MIT Licen" & _
            "se"
        Me.lblLicenses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGithub
        '
        Me.lblGithub.AutoSize = True
        Me.lblGithub.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGithub.Location = New System.Drawing.Point(105, 77)
        Me.lblGithub.Name = "lblGithub"
        Me.lblGithub.Size = New System.Drawing.Size(255, 16)
        Me.lblGithub.TabIndex = 4
        Me.lblGithub.Text = "Github: http://github.com/eylos/finalproject"
        Me.lblGithub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCodeLicense
        '
        Me.txtCodeLicense.BackColor = System.Drawing.Color.DodgerBlue
        Me.txtCodeLicense.Location = New System.Drawing.Point(12, 129)
        Me.txtCodeLicense.Multiline = True
        Me.txtCodeLicense.Name = "txtCodeLicense"
        Me.txtCodeLicense.ReadOnly = True
        Me.txtCodeLicense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCodeLicense.Size = New System.Drawing.Size(441, 276)
        Me.txtCodeLicense.TabIndex = 5
        Me.txtCodeLicense.Text = resources.GetString("txtCodeLicense.Text")
        Me.txtCodeLicense.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DodgerBlue
        Me.ClientSize = New System.Drawing.Size(465, 420)
        Me.Controls.Add(Me.txtCodeLicense)
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
    Friend WithEvents txtCodeLicense As System.Windows.Forms.TextBox
End Class
