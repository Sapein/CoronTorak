Public Class Form1
    Dim selectedUnit As Integer 'Uses the UnitID for the unit As Defined upon initialization.
    'Player Units
    Dim mage1Player = New clsUnitMage
    Dim mage2Player = New clsUnitMage
    Dim warrior1Player
    Dim warrior2Player
    Dim archer1Player
    Dim archer2Player

    'Computer Units
    Dim mage1Computer = New clsUnitMage
    Dim mage2Computer = New clsUnitMage
    Dim warrior1Computer
    Dim warrior2Computer
    Dim archer1Computer
    Dim archer2Comptuer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim NewMenu = New Menu
        'Me.Hide()
        'NewMenu.Show()
        mage1Player.unitInitialize(1, "Player", "unitP4")
        mage1Player.unitInitialize(2, "Player", "unitP6")


        mage1Computer.unitInitialize(7, "Computer", "unitE4")
        mage2Computer.unitInitialize(8, "Computer", "unitE6")

        End
    End Sub

    Private Sub unitP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP4.Click
        selectedUnit = 1
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        '     clsUnit.movePlayerUnit(selectedUnit)
    End Sub

    Public Sub moveUnit(ByVal unitID)
        Dim moveDirection As String
        If unitID = 1 Then
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, or Right", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                '            Form1.unitP4.Top = Form1.unitP4.Top + 65
            End If
        End If
    End Sub
End Class
