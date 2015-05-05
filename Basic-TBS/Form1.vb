Public Class Form1
    Dim selectedUnit As Integer = -1 'Uses the UnitID for the unit As Defined upon initialization.
    Dim chrPlayerTurn As Char
    Dim boolAttacking As Boolean
    Dim defUnit As Integer 'Uses the Initialization-Definied Unit ID


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


    Dim unitList As List(Of clsUnit) = New List(Of clsUnit)
    Dim usedUnitList As List(Of clsUnit) = New List(Of clsUnit)

    Dim usedUnitListBackup As List(Of Object) = New List(Of Object)
    Dim unitListBackup As List(Of Object) = New List(Of Object)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        mage1Player.unitInitialize(1, "Player", "unitP4", unitP4.Location.X, unitP4.Location.Y)
        mage2Player.unitInitialize(2, "Player", "unitP6", unitP6.Location.X, unitP6.Location.Y)
        warrior1Player.unitInitialize(3, "Player", "unitP5", unitP5.Location.X, unitP5.Location.Y)
        warrior2Player.unitInitialize(4, "Player", "unitP2", unitP2.Location.X, unitP2.Location.Y)
        archer1Player.unitInitialize(5, "Player", "unitP1", unitP1.Location.X, unitP1.Location.Y)
        archer2Player.unitInitialize(6, "Player", "unitP3", unitP3.Location.X, unitP3.Location.Y)


        mage1Computer.unitInitialize(7, "Computer", "unitE4", unitE4.Location.X, unitE4.Location.Y)
        mage2Computer.unitInitialize(8, "Computer", "unitE6", unitE6.Location.X, unitE6.Location.Y)
        warrior1Computer.unitInitialize(9, "Computer", "unitE5", unitE5.Location.X, unitE5.Location.Y)
        warrior2Computer.unitInitialize(10, "Computer", "unitE2", unitE2.Location.X, unitE2.Location.Y)
        archer1Computer.unitInitialize(11, "Computer", "unitE1", unitE1.Location.X, unitE1.Location.Y)
        archer2Computer.unitInitialize(12, "Computer", "unitE3", unitE3.Location.X, unitE3.Location.Y)

        DisplayUnitStats()

        unitList.Add(mage1Player)
        unitList.Add(mage2Player)
        unitList.Add(warrior1Player)
        unitList.Add(warrior2Player)
        unitList.Add(archer1Player)
        unitList.Add(archer2Player)
        unitList.Add(mage1Computer)
        unitList.Add(mage2Computer)
        unitList.Add(warrior1Computer)
        unitList.Add(warrior2Computer)
        unitList.Add(archer1Computer)
        unitList.Add(archer2Computer)

        For Each listItem As Object In unitList
            unitListBackup.Add(listItem)
        Next listItem
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
            mage1Player.unitLocX = unitP4.Location.X
            mage1Player.unitLocY = unitP4.Location.Y
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
            mage2Player.unitLocX = unitP6.Location.X
            mage2Player.unitLocY = unitP6.Location.Y
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
            warrior1Player.unitLocX = unitP5.Location.X
            warrior1Player.unitLocY = unitP5.Location.Y
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
            warrior2Player.unitLocX = unitP2.Location.X
            warrior2Player.unitLocY = unitP2.Location.Y
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
            archer1Player.unitLocX = unitP1.Location.X
            archer1Player.unitLocY = unitP1.Location.Y
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
            archer2Player.unitLocX = unitP3.Location.X
            archer2Player.unitLocY = unitP3.Location.Y
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
            mage1Computer.unitLocX = unitE4.Location.X
            mage1Computer.unitLocY = unitE4.Location.Y
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
            mage2Computer.unitLocX = unitE6.Location.X
            mage2Computer.unitLocY = unitE6.Location.Y
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
            warrior1Computer.unitLocX = unitE5.Location.X
            warrior1Computer.unitLocY = unitE5.Location.Y
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
            warrior2Computer.unitLocX = unitE2.Location.X
            warrior2Computer.unitLocY = unitE2.Location.Y
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
            archer1Computer.unitLocX = unitE1.Location.X
            archer1Computer.unitLocY = unitE1.Location.Y
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
            archer2Computer.unitLocX = unitE3.Location.X
            archer2Computer.unitLocY = unitE3.Location.Y
        End If
    End Sub

    Private Sub unitP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP4.Click
        If boolAttacking = False Then
            selectedUnit = 1
        ElseIf boolAttacking = True Then
            defUnit = 1
            Attacking()
        End If

    End Sub

    Private Sub unitP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP5.Click
        If boolAttacking = False Then
            selectedUnit = 3
        ElseIf boolAttacking = True Then
            defUnit = 3
            Attacking()
        End If
    End Sub

    Private Sub unitP6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP6.Click
        If boolAttacking = False Then
            selectedUnit = 2
        ElseIf boolAttacking = True Then
            defUnit = 2
            Attacking()
        End If
    End Sub

    Private Sub unitP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP1.Click
        If boolAttacking = False Then
            selectedUnit = 5
        ElseIf boolAttacking = True Then
            defUnit = 5
            Attacking()
        End If
    End Sub

    Private Sub unitP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP2.Click
        If boolAttacking = False Then
            selectedUnit = 4
        ElseIf boolAttacking = True Then
            defUnit = 4
            Attacking()
        End If
    End Sub

    Private Sub unitP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP3.Click
        If boolAttacking = False Then
            selectedUnit = 6
        ElseIf boolAttacking = True Then
            defUnit = 6
            Attacking()
        End If
    End Sub

    Private Sub unitE4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE4.Click
        If boolAttacking = False Then
            selectedUnit = 7
        ElseIf boolAttacking = True Then
            defUnit = 7
            Attacking()
        End If
    End Sub

    Private Sub unitE6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE6.Click
        If boolAttacking = False Then
            selectedUnit = 8
        ElseIf boolAttacking = True Then
            defUnit = 8
            Attacking()
        End If
    End Sub

    Private Sub unitE5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE5.Click
        If boolAttacking = False Then
            selectedUnit = 9
        ElseIf boolAttacking = True Then
            defUnit = 9
            Attacking()
        End If
    End Sub

    Private Sub unitE2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE2.Click
        If boolAttacking = False Then
            selectedUnit = 10
        ElseIf boolAttacking = True Then
            defUnit = 10
            Attacking()
        End If
    End Sub

    Private Sub unitE1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE1.Click
        If boolAttacking = False Then
            selectedUnit = 11
        ElseIf boolAttacking = True Then
            defUnit = 11
            Attacking()
        End If
    End Sub

    Private Sub unitE3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE3.Click
        If boolAttacking = False Then
            selectedUnit = 12
        ElseIf boolAttacking = True Then
            defUnit = 12
            Attacking()
        End If
    End Sub

    Private Sub btnAttack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttack.Click
        boolAttacking = True 'Note use the Movement Values for The check to see if it's valid. 
        MessageBox.Show("Please click the unit you wish to Attack")
    End Sub

    Private Sub Attacking()
        Dim attacking
        Dim healthOfDefending
        Dim rangeOfAttacking
        selectedUnit = selectedUnit - 1 : defUnit = defUnit - 1

        attacking = unitList(selectedUnit).unitStrength
        healthOfDefending = unitList(defUnit).unitHealth
        rangeOfAttacking = unitList(selectedUnit).unitRange
        healthOfDefending = healthOfDefending - attacking

        unitList(defUnit).unitHealth = healthOfDefending
        MessageBox.Show("Unit " & unitList(selectedUnit).unitID & " - " & unitList(selectedUnit).unitTeam _
        & " attacked " & unitList(defUnit).unitID & " - " & unitList(defUnit).unitTeam & "! The defending unit's health" _
        & " is " & healthOfDefending & " / " & unitList(defUnit).unitHealth)
        selectedUnit = selectedUnit + 1 : defUnit = defUnit + 1

        DisplayUnitStats()
        boolAttacking = False
    End Sub

    Private Sub DisplayUnitStats()
        Const AttackDisplay As String = " - Atk: "

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
    End Sub

    Private Sub CheckTurn()

    End Sub
End Class
