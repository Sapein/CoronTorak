Public Class Form1
    Dim selectedUnit As Integer 'Uses the UnitID for the unit As Defined upon initialization.
    Dim chrPlayerTurn As Char
    'Dim unitsUsed[6] As String

    'Player Units
    Dim mage1Player = New clsUnitMage
    Dim mage2Player = New clsUnitMage
    Dim warrior1Player = New clsUnitWarrior
    Dim warrior2Player = New clsUnitWarrior
    Dim archer1Player = New clsUnitArcher
    Dim archer2Player = New clsUnitArcher

    'Computer Units
    Dim mage1Computer = New clsUnitMage
    Dim mage2Computer = New clsUnitMage
    Dim warrior1Computer = New clsUnitWarrior
    Dim warrior2Computer = New clsUnitWarrior
    Dim archer1Computer = New clsUnitArcher
    Dim archer2Computer = New clsUnitArcher

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim NewMenu = New Menu
        'Me.Hide()
        'NewMenu.Show()
        Const AttackDisplay As String = " - Atk: "
        mage1Player.unitInitialize(1, "Player", "unitP4")
        mage2Player.unitInitialize(2, "Player", "unitP6")
        warrior1Player.unitInitialize(3, "Player", "unitP5")
        warrior2Player.unitInitialize(4, "Player", "unitP2")
        archer1Player.unitInitialize(5, "Player", "unitP1")
        archer2Player.unitInitialize(6, "Player", "unitP3")

        mage1Computer.unitInitialize(7, "Computer", "unitE4")
        mage2Computer.unitInitialize(8, "Computer", "unitE6")
        warrior1Computer.unitInitialize(9, "Computer", "unitE5")
        warrior2Computer.unitInitialize(10, "Computer", "unitE2")
        archer1Computer.unitInitialize(11, "Computer", "unitE1")
        archer2Computer.unitInitialize(12, "Computer", "unitE3")

        unit1.Text = "Mage 1 - HP: " & mage1Player.unitHealth & " - Atk: " & mage1Player.unitStrength
        unit2.Text = "Mage 2 - HP: " & mage2Player.unitHealth & " - Atk: " & mage2Player.unitStrength
        unit3.Text = "Warrior 1 - HP: " & warrior1Player.unitHealth & AttackDisplay & warrior1Player.unitStrength
        unit4.Text = "Warrior 2 - HP: " & warrior2Player.unitHealth & AttackDisplay & warrior2Player.unitStrength
        unit5.Text = "Archer 1 - HP: " & archer1Player.unitHealth & AttackDisplay & archer1Player.unitStrength
        unit6.Text = "Archer 2 - HP: " & archer2Player.unitHealth & AttackDisplay & archer2Player.unitStrength

        eUnit1.Text = "Mage 1 - HP: " & mage1Computer.unitHealth & " - Atk: " & mage1Computer.unitStrength
        eUnit2.Text = "Mage 2 - HP: " & mage2Computer.unitHealth & " - Atk: " & mage2Computer.unitStrength
        eUnit3.Text = "Warrior 1 - HP: " & warrior1Computer.unitHealth & AttackDisplay & warrior1Computer.unitStrength
        eUnit4.Text = "Warrior 2 - HP: " & warrior2Computer.unitHealth & AttackDisplay & warrior2Computer.unitStrength
        eUnit5.Text = "Archer 1 - HP: " & archer1Computer.unitHealth & AttackDisplay & archer1Computer.unitStrength
        eUnit6.Text = "Archer 2 - HP: " & archer2Computer.unitHealth & AttackDisplay & archer2Computer.unitStrength
        'End
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        moveUnit(selectedUnit)
        opponentUnitMove(selectedUnit)
    End Sub

    Public Sub moveUnit(ByVal unitID)
        Dim moveDirection As String
        If unitID = 1 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP4.Top = Me.unitP4.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP4.Top = Me.unitP4.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP4.Left = Me.unitP4.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP4.Left = Me.unitP4.Left + 66
            End If
        ElseIf unitID = 2 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP6.Top = Me.unitP6.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP6.Top = Me.unitP6.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP6.Left = Me.unitP6.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP6.Left = Me.unitP6.Left + 66
            End If
        ElseIf unitID = 3 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP5.Top = Me.unitP5.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP5.Top = Me.unitP5.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP5.Left = Me.unitP5.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP5.Left = Me.unitP5.Left + 66
            End If
        ElseIf unitID = 4 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP2.Top = Me.unitP2.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP2.Top = Me.unitP2.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP2.Left = Me.unitP2.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP2.Left = Me.unitP2.Left + 66
            End If
        ElseIf unitID = 5 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP1.Top = Me.unitP1.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP1.Top = Me.unitP1.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP1.Left = Me.unitP1.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP1.Left = Me.unitP1.Left + 66
            End If
        ElseIf unitID = 6 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP3.Top = Me.unitP3.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP3.Top = Me.unitP3.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP3.Left = Me.unitP3.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP3.Left = Me.unitP3.Left + 66
            End If
        End If
    End Sub

    Public Sub opponentUnitMove(ByVal unitID)
        Dim moveDirection As String
        If unitID = 7 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE4.Top = Me.unitE4.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE4.Top = Me.unitE4.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE4.Left = Me.unitE4.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE4.Left = Me.unitE4.Left + 66
            End If
        ElseIf unitID = 8 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE6.Top = Me.unitE6.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE6.Top = Me.unitE6.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE6.Left = Me.unitE6.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE6.Left = Me.unitE6.Left + 66
            End If
        ElseIf unitID = 9 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE5.Top = Me.unitE5.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE5.Top = Me.unitE5.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE5.Left = Me.unitE5.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE5.Left = Me.unitE5.Left + 66
            End If
        ElseIf unitID = 10 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE2.Top = Me.unitE2.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE2.Top = Me.unitE2.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE2.Left = Me.unitE2.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE2.Left = Me.unitE2.Left + 66
            End If
        ElseIf unitID = 11 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE1.Top = Me.unitE1.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE1.Top = Me.unitE1.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE1.Left = Me.unitE1.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE1.Left = Me.unitE1.Left + 66
            End If
        ElseIf unitID = 12 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE3.Top = Me.unitE3.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE3.Top = Me.unitE3.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE3.Left = Me.unitE3.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE3.Left = Me.unitE3.Left + 66
            End If
        End If
    End Sub

    Private Sub unitP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP4.Click
        'selectedUnit = mage1Player.unitID
        selectedUnit = 1
    End Sub

    Private Sub unitP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP5.Click
        'selectedUnit = warrior1Player.unitID
        selectedUnit = 3
    End Sub

    Private Sub unitP6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP6.Click
        'selectedUnit = mage2Player.unitID
        selectedUnit = 2
    End Sub

    Private Sub unitP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP1.Click
        'selectedUnit = archer1Player.unitID
        selectedUnit = 5
    End Sub

    Private Sub unitP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP2.Click
        'selectedUnit = warrior2Player.unitID
        selectedUnit = 4
    End Sub

    Private Sub unitP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP3.Click
        'selectedUnit = archer2Player.unitID
        selectedUnit = 6
    End Sub

    Private Sub unitE4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE4.Click
        selectedUnit = 7
    End Sub

    Private Sub unitE6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE6.Click
        selectedUnit = 8
    End Sub

    Private Sub unitE5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE5.Click
        selectedUnit = 9
    End Sub

    Private Sub unitE2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE2.Click
        selectedUnit = 10
    End Sub

    Private Sub unitE1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE1.Click
        selectedUnit = 11
    End Sub

    Private Sub unitE3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE3.Click
        selectedUnit = 12
    End Sub
End Class
