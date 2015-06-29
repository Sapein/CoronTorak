Public Class Unit_Selection

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If Not (IsNumeric(txtMageAmount.Text) And IsNumeric(txtWarriorAmount.Text) And IsNumeric(txtArcherAmount.Text) And IsNumeric(txtMageAmount2.Text) And IsNumeric(txtWarriorAmount2.Text) And IsNumeric(txtArcherAmount2.Text)) Then
            MessageBox.Show("You need to enter Numbers!")
            Exit Sub
        End If

        If CInt(txtMageAmount.Text + txtArcherAmount.Text + txtWarriorAmount.Text) > 6 Then
            MessageBox.Show("Player 1, your units are above the limit of 6!")
            Exit Sub
        ElseIf CInt(txtMageAmount2.Text + txtArcherAmount2.Text + txtWarriorAmount2.Text) > 6 Then
            MessageBox.Show("Player 2, your units are above the limit of 6!")
            Exit Sub
        End If

        MenuS.Base_Engine.setMageAmountP1(CInt(txtMageAmount.Text))
        MenuS.Base_Engine.setWarriorAmountP1(CInt(txtWarriorAmount.Text))
        MenuS.Base_Engine.setArcherAmountP1(CInt(txtArcherAmount.Text))

        MenuS.Base_Engine.setMageAmountP2(CInt(txtMageAmount2.Text))
        MenuS.Base_Engine.setWarriorAmountP2(CInt(txtWarriorAmount2.Text))
        MenuS.Base_Engine.setArcherAmountP2(CInt(txtArcherAmount2.Text))
    End Sub
End Class