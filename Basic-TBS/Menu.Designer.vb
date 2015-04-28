<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.btnConnect = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.OdbcSelectCommand1 = New System.Data.Odbc.OdbcCommand
        Me.OdbcInsertCommand1 = New System.Data.Odbc.OdbcCommand
        Me.OdbcUpdateCommand1 = New System.Data.Odbc.OdbcCommand
        Me.OdbcDeleteCommand1 = New System.Data.Odbc.OdbcCommand
        Me.OdbcDataAdapter1 = New System.Data.Odbc.OdbcDataAdapter
        Me.SuspendLayout()
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(32, 103)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New Game"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Enabled = False
        Me.btnLoad.Location = New System.Drawing.Point(146, 103)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "Load Game"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Enabled = False
        Me.btnConnect.Location = New System.Drawing.Point(260, 103)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 2
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(374, 103)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'OdbcDataAdapter1
        '
        Me.OdbcDataAdapter1.DeleteCommand = Me.OdbcDeleteCommand1
        Me.OdbcDataAdapter1.InsertCommand = Me.OdbcInsertCommand1
        Me.OdbcDataAdapter1.SelectCommand = Me.OdbcSelectCommand1
        Me.OdbcDataAdapter1.UpdateCommand = Me.OdbcUpdateCommand1
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 160)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnNew)
        Me.Name = "Menu"
        Me.Text = "Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents OdbcSelectCommand1 As System.Data.Odbc.OdbcCommand
    Friend WithEvents OdbcInsertCommand1 As System.Data.Odbc.OdbcCommand
    Friend WithEvents OdbcUpdateCommand1 As System.Data.Odbc.OdbcCommand
    Friend WithEvents OdbcDeleteCommand1 As System.Data.Odbc.OdbcCommand
    Friend WithEvents OdbcDataAdapter1 As System.Data.Odbc.OdbcDataAdapter
End Class
