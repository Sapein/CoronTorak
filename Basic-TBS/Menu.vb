Public Class MenuS
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'Loads up a New Game
        Dim NewForm1 = New Form1
        NewForm1.Show()
        Me.Close()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        'Allows a game to load up
        Form1.loadGame = "L"
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        Dim newAbout = New About
        newAbout.Show()
    End Sub
End Class