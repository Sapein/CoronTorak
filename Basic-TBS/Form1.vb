Public Class Form1
    Dim selectedUnit As Integer 'Uses the UnitID for the unit As Defined upon initialization.
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
        mage1Player.unitInitialize(1, "Player", "unitP4")
        mage1Player.unitInitialize(2, "Player", "unitP6")
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
        'End
    End Sub

    Private Sub unitP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP4.Click
        selectedUnit = mage1Player.unitID
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        '     clsUnit.movePlayerUnit(selectedUnit)
        moveUnit(selectedUnit)
    End Sub

    Public Sub moveUnit(ByVal unitID)
        Dim moveDirection As String
        If unitID = mage1Player.unitID Then
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
        ElseIf unitID = mage2Player.unitID Then

        End If
    End Sub
End Class
