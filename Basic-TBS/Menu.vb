Public Class MenuS
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'Loads up a New Game
        Dim NewForm1 As Form = New Form1
        NewForm1.Show()
        Me.Close()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        'Allows a game to load up
        Form1.loadGame = "L"c
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        Dim newAbout As Form = New About
        newAbout.Show()
    End Sub

    Private Sub MenuS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        picLogo.BackgroundImage = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\CoronTorak Image.png")
    End Sub
End Class