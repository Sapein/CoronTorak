Public Class Form1
    Private selectedUnit As Integer = -1 'Uses the UnitID for the unit As Defined upon initialization.
    Dim chrPlayerTurn As Char = "P" 'Character is either P for player 1, and C for player 2
    Dim boolAttacking As Boolean
    Public defUnit As Integer = -1 'Uses the Initialization-Definied Unit ID


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


    Public unitList As List(Of clsUnit) = New List(Of clsUnit)
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
        Dim errorCodeCheck As Integer
        CheckTurn()
        selectedUnit = selectedUnit - 1
        errorCodeCheck = useUnit(selectedUnit)
        If errorCodeCheck = 0 Then
            selectedUnit = selectedUnit + 1
        ElseIf errorCodeCheck = 4 Or 5 Then
            selectedUnit = selectedUnit + 1
            Exit Sub
        End If
        moveUnit(selectedUnit)
        opponentUnitMove(selectedUnit)
        checkTurnEnd()
    End Sub

    Public Sub moveUnit(ByVal unitID)
        Dim moveDirection As String
        Dim errorCodeCheck As Integer
        Dim unitFirstX As Integer
        Dim unitFirstY As Integer
        If unitID = mage1Player.unitID Then
            unitFirstY = Me.unitP4.Top
            unitFirstX = Me.unitP4.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP4.Left = unitFirstX
                Me.unitP4.Top = unitFirstY
                mage1Player.unitLocX = unitP4.Location.X
                mage1Player.unitLocY = unitP4.Location.Y
            End If
        ElseIf unitID = mage2Player.unitID Then
            unitFirstY = Me.unitP6.Top
            unitFirstX = Me.unitP6.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP6.Left = unitFirstX
                Me.unitP6.Top = unitFirstY
                mage2Player.unitLocX = unitP6.Location.X
                mage2Player.unitLocY = unitP6.Location.Y
            End If
        ElseIf unitID = warrior1Player.unitID Then
            unitFirstY = Me.unitP5.Top
            unitFirstX = Me.unitP5.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP5.Left = unitFirstX
                Me.unitP5.Top = unitFirstY
                warrior1Player.unitLocX = unitP5.Location.X
                warrior1Player.unitLocY = unitP5.Location.Y
            End If
        ElseIf unitID = warrior2Player.unitID Then
            unitFirstY = Me.unitP2.Top
            unitFirstX = Me.unitP2.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP2.Left = unitFirstX
                Me.unitP2.Top = unitFirstY
                warrior2Player.unitLocX = unitP2.Location.X
                warrior2Player.unitLocY = unitP2.Location.Y
            End If
        ElseIf unitID = archer1Player.unitID Then
            unitFirstY = Me.unitP1.Top
            unitFirstX = Me.unitP1.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP1.Left = unitFirstX
                Me.unitP1.Top = unitFirstY
                archer1Player.unitLocX = unitP1.Location.X
                archer1Player.unitLocY = unitP1.Location.Y
            End If
        ElseIf unitID = archer2Player.unitID Then
            unitFirstY = Me.unitP3.Top
            unitFirstX = Me.unitP3.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP3.Left = unitFirstX
                Me.unitP3.Top = unitFirstY
                archer2Player.unitLocX = unitP3.Location.X
                archer2Player.unitLocY = unitP3.Location.Y
            End If
        End If
    End Sub

    Public Sub opponentUnitMove(ByVal unitID)
        Dim moveDirection As String
        Dim errorCodeCheck As Integer
        Dim unitFirstX As Integer
        Dim unitFirstY As Integer
        If unitID = mage1Computer.unitID Then
            unitFirstY = Me.unitE4.Top
            unitFirstX = Me.unitE4.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE4.Left = unitFirstX
                Me.unitE4.Top = unitFirstY
                mage1Computer.unitLocX = unitE4.Location.X
                mage1Computer.unitLocY = unitE4.Location.Y
            End If
        ElseIf unitID = mage2Computer.unitID Then
            unitFirstY = Me.unitE6.Top
            unitFirstX = Me.unitE6.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE6.Left = unitFirstX
                Me.unitE6.Top = unitFirstY
                mage2Computer.unitLocX = unitE6.Location.X
                mage2Computer.unitLocY = unitE6.Location.Y
            End If
        ElseIf unitID = warrior1Computer.unitID Then
            unitFirstY = Me.unitE5.Top
            unitFirstX = Me.unitE5.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE5.Left = unitFirstX
                Me.unitE5.Top = unitFirstY
                warrior1Computer.unitLocX = unitE5.Location.X
                warrior1Computer.unitLocY = unitE5.Location.Y
            End If
        ElseIf unitID = warrior2Computer.unitID Then
            unitFirstY = Me.unitE2.Top
            unitFirstX = Me.unitE2.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE2.Left = unitFirstX
                Me.unitE2.Top = unitFirstY
                warrior2Computer.unitLocX = unitE2.Location.X
                warrior2Computer.unitLocY = unitE2.Location.Y
            End If
        ElseIf unitID = archer1Computer.unitID Then
            unitFirstY = Me.unitE1.Top
            unitFirstX = Me.unitE1.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE1.Left = unitFirstX
                Me.unitE1.Top = unitFirstY
                archer1Computer.unitLocX = unitE1.Location.X
                archer1Computer.unitLocY = unitE1.Location.Y
            End If
        ElseIf unitID = archer2Computer.unitID Then
            unitFirstY = Me.unitE3.Top
            unitFirstX = Me.unitE3.Left
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
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE3.Left = unitFirstX
                Me.unitE3.Top = unitFirstY
                archer2Computer.unitLocX = unitE3.Location.X
                archer2Computer.unitLocY = unitE3.Location.Y
            End If
        End If
    End Sub

    Public Sub opponentUnitMove_OLD(ByVal unitID)
        Dim moveDirection As String
        If unitID = mage1Computer.unitID Then
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
        ElseIf unitID = mage2Computer.unitID Then
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
        ElseIf unitID = warrior1Computer.unitID Then
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
        ElseIf unitID = warrior2Computer.unitID Then
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
        ElseIf unitID = archer1Computer.unitID Then
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
        ElseIf unitID = archer2Computer.unitID Then
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
            selectedUnit = mage1Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = mage1Player.unitID
            CheckTurn()
        End If

    End Sub

    Private Sub unitP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP5.Click
        If boolAttacking = False Then
            selectedUnit = warrior1Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = warrior1Player.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub unitP6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP6.Click
        If boolAttacking = False Then
            selectedUnit = mage2Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = mage2Player.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub unitP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP1.Click
        If boolAttacking = False Then
            selectedUnit = archer1Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = archer1Player.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub unitP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP2.Click
        If boolAttacking = False Then
            selectedUnit = warrior2Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = warrior2Player.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub unitP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP3.Click
        If boolAttacking = False Then
            selectedUnit = archer2Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = archer2Player.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub unitE4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE4.Click
        If boolAttacking = False Then
            selectedUnit = mage1Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = mage1Computer.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub unitE6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE6.Click
        If boolAttacking = False Then
            selectedUnit = mage2Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = mage2Computer.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub unitE5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE5.Click
        If boolAttacking = False Then
            selectedUnit = warrior1Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = warrior1Computer.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub unitE2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE2.Click
        If boolAttacking = False Then
            selectedUnit = warrior2Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = warrior2Computer.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub unitE1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE1.Click
        If boolAttacking = False Then
            selectedUnit = archer1Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = archer1Computer.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub unitE3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE3.Click
        If boolAttacking = False Then
            selectedUnit = archer2Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = archer2Computer.unitID
            CheckTurn()
        End If
    End Sub

    Private Sub btnAttack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttack.Click
        Dim errorCodeCheck As Integer
        errorCodeCheck = CheckTurn()
        If errorCodeCheck = 0 Then
            errorCodeCheck = 0
        ElseIf errorCodeCheck = 1 Or 2 Or 3 Then
            Exit Sub
        End If
        errorCodeCheck = Attacking(True)
        If errorCodeCheck = 0 Then
            errorCodeCheck = 0
        ElseIf errorCodeCheck = 5 Then
            Exit Sub
        End If
        boolAttacking = True 'Note use the Movement Values for The check to see if it's valid. 
        MessageBox.Show("Please click the unit you wish to Attack")
    End Sub

    Private Function Attacking(Optional ByVal boolDryRun As Boolean = False)
        Dim attackStat As Integer
        Dim healthOfDefending As Integer
        Dim rangeOfAttacking As Integer
        Dim errorCodeCheck As Integer
        Dim unitBuff As Integer
        If boolDryRun = True Then
            Dim i As Integer
            selectedUnit = selectedUnit - 1
            While i < usedUnitList.Count
                If unitList(selectedUnit).unitID = usedUnitList(i).unitID Then
                    MessageBox.Show("ERROR: UNIT ALREADY USED!", "ERROR: USED UNIT")
                    Return 5
                End If
                i += 1
            End While
            selectedUnit = selectedUnit + 1
            Return 0
        End If

        errorCodeCheck = useUnit(selectedUnit)
        If errorCodeCheck = 0 Then
        ElseIf errorCodeCheck = 4 Or 5 Then
            Return 0
        End If

        errorCodeCheck = unitListBackup(selectedUnit).unitAttack()
        If errorCodeCheck = 0 Then

        ElseIf errorCodeCheck = 9 Or errorCodeCheck = 10 Then
            Return 0
        End If

        unitBuff = unitListBackup(selectedUnit).unitGetBuffs()
        If (defUnit = -1 And selectedUnit = -1) Or (defUnit = -1 Or selectedUnit = -1) Then
            MessageBox.Show("ERROR: NO ATTACKING OR DEFNDING UNIT!", "ERROR: INVALID TARGET(S)")
            Return 6 'Error Code: Invalid Target(s)
        Else
            defUnit = defUnit - 1
            If selectedUnit = -1 Then
                Return 0
            End If
            attackStat = unitList(selectedUnit).unitStrength
            healthOfDefending = unitList(defUnit).unitHealth
            rangeOfAttacking = unitList(selectedUnit).unitRange
            healthOfDefending = (healthOfDefending - attackStat) - unitBuff

            unitList(defUnit).unitHealth = healthOfDefending

            MessageBox.Show("Unit " & unitList(selectedUnit).unitID & " - " & unitList(selectedUnit).unitTeam _
            & " attacked " & unitList(defUnit).unitID & " - " & unitList(defUnit).unitTeam & "! The defending unit's health" _
            & " is " & unitList(defUnit).unitHealth)
            selectedUnit = selectedUnit + 1 : defUnit = defUnit + 1

            DisplayUnitStats()
        End If
        boolAttacking = False
        checkTurnEnd()
        Return 0
    End Function

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

    Private Function CheckTurn()
        'NOTE: This returns an "ERROR LEVEL". I took the concept from C. Because there are 3 "errors" possible
        'There are 4 error Codes: 0 - Success: No Error encountered; 1 - INVALID UNIT: Attacking unit on wrong team; 
        '2 - INVALID UNIT: No Unit selected; 3 - Attacking Teamed Unit: Defending Unit on wrong team.
        selectedUnit = selectedUnit - 1
        If chrPlayerTurn = "P" Then
            If selectedUnit > -1 Then
                If unitList(selectedUnit).unitTeam = "Computer" Then
                    selectedUnit = -1
                    MessageBox.Show("ERROR: PLEASE SELECT A UNIT ON YOUR TEAM!", "ERROR: INVALID UNIT")
                    Return 1
                End If
            End If
            If selectedUnit = -1 Then
                MessageBox.Show("ERROR: PLEASE SELECT A UNIT!", "ERROR: INVALID UNIT")
                Return 2
            End If
            If boolAttacking = True Then
                defUnit = defUnit - 1
                If unitList(defUnit).unitTeam = "Computer" Then
                    Attacking()
                    defUnit = defUnit + 1
                Else
                    defUnit = -1
                    MessageBox.Show("ERROR! PLEASE CHOOSE A NON-TEAMED UNIT!", "ERROR: ATTACKING TEAM-MATE")
                    selectedUnit = selectedUnit + 1
                    Return 3
                End If
            End If
        ElseIf chrPlayerTurn = "C" Then
            If selectedUnit > -1 Then
                If unitList(selectedUnit).unitTeam = "Player" Then
                    selectedUnit = -1
                    MessageBox.Show("ERROR: PLEASE SELECT A UNIT ON YOUR TEAM!", "ERROR: INVALID UNIT")
                    Return 1
                End If
            End If
            If selectedUnit = -1 Then
                MessageBox.Show("ERROR: PLEASE SELECT A UNIT!", "ERROR: INVALID UNIT")
                Return 2
            End If
            If boolAttacking = True Then
                If unitList(defUnit).unitTeam = "Player" Then
                    Attacking()
                Else
                    defUnit = -1
                    MessageBox.Show("ERROR! PLEASE CHOOSE A NON-TEAMED UNIT!", "ERROR: ATTACKING TEAM-MATE")
                    selectedUnit = selectedUnit + 1
                    Return 3
                End If
            End If
        End If
        selectedUnit = selectedUnit + 1
        Return 0
    End Function

    Private Function useUnit(ByVal unit As Integer)
        Dim i As Integer = 0
        'unit = unit - 1
        If unit <= -1 Then
            Return 4 'Error Code 4: unit value is negative
        End If
        While i < usedUnitList.Count
            If unitList(unit).unitID = usedUnitList(i).unitID Then
                MessageBox.Show("ERROR: UNIT ALREADY USED!", "ERROR: USED UNIT")
                boolAttacking = False
                Return 5 'Error Code 5: Unit has been used
            End If
            i += 1
        End While
        usedUnitList.Add(unitList(unit))
        unit = unit + 1
        Return 0 'Error Code 0: Successful Run
    End Function

    Private Sub checkTurnEnd()
        Dim i = 0
        Dim x = 0
        selectedUnit = selectedUnit - 1
        While i < usedUnitList.Count
            If chrPlayerTurn = "P" Then
                If usedUnitList(i).unitID = 1 Or usedUnitList(i).unitID = 2 Or usedUnitList(i).unitID = 3 Or usedUnitList(i).unitID = 4 Or usedUnitList(i).unitID = 5 Or usedUnitList(i).unitID = 6 Then
                    i += 1
                End If
                If i = 6 Then
                    MessageBox.Show("The turn of Player 1 is over, begin Player 2.", "Turn Over")
                    usedUnitList.Clear()
                    chrPlayerTurn = "P"
                    Exit Sub
                End If
            End If
            If chrPlayerTurn = "C" Then
                If usedUnitList(i).unitID = usedUnitList(i).unitID = 7 Or usedUnitList(i).unitID = 8 Or usedUnitList(i).unitID = 9 Or usedUnitList(i).unitID = 10 Or usedUnitList(i).unitID = 11 Or usedUnitList(i).unitID = 12 Then
                    i += 1
                End If
                If i = 6 Then
                    MessageBox.Show("The turn of Player 2 is over, begin Player 1.", "Turn Over")
                    usedUnitList.Clear()
                    chrPlayerTurn = "P"
                    Exit Sub
                End If
            End If
        End While
        selectedUnit = -1
    End Sub

    Public Function checkUnitDistanceX()
        Dim OutputX As Integer
        Dim attackingUnitLocation_X As Integer = unitList(selectedUnit).unitLocX
        Dim defendingUnitLocation_X As Integer = unitList(defUnit).unitLocX

        OutputX = attackingUnitLocation_X - defendingUnitLocation_X

        If OutputX < 0 Then
            OutputX = -1 * (OutputX)
        End If
        Return OutputX
    End Function

    Public Function checkUnitDistanceY()
        Dim OutputY As Integer
        Dim attackingUnitLocation_Y As Integer = unitList(selectedUnit).unitLocY
        Dim defendingUnitLocation_Y As Integer = unitList(defUnit).unitLocY

        OutputY = attackingUnitLocation_Y - defendingUnitLocation_Y
        If OutputY < 0 Then
            OutputY = -1 * (OutputY)
        End If
        Return OutputY
    End Function


    Private Function checkUnitLocation(ByVal unitA As Integer)
        Dim i As Integer
        unitA = unitA - 1
        While i < unitList.Count
            If unitList(unitA).unitLocX = unitList(i).unitLocX And unitList(unitA).unitLocY = unitList(i).unitLocY Then
                If unitList(unitA).unitID = unitList(i).unitID Then

                Else
                    MessageBox.Show("TEST")
                    Return 7 'Error Code 7: Unit Occupying Space
                End If
            End If
            i += 1
        End While
        If unitList(unitA).unitLocX <= 208 Then ' Or unitList(unitA).unitLocX <= 723 Then
            Return 8 'Error Code 8: Unit Passed Map Bounds
        End If

        If unitList(unitA).unitLocY <= 25 Or unitList(unitA).unitLocY >= 477 Then
            Return 8 'Error Code 8: Unit Passed Map Bounds
        End If
        Return 0
    End Function

    Public Function getSelectedUnit()
        Return selectedUnit
    End Function

    Public Function getDefendingUnit()
        Return defUnit
    End Function

    Public Function getDistance()
        Dim distance As Integer
        distance = Math.Sqrt((unitList(selectedUnit).unitLocX - unitList(defUnit).unitLocX) ^ 2 + _
        (unitList(selectedUnit).unitLocY - unitList(defUnit).unitLocY) ^ 2)
        MessageBox.Show(distance)
        Return distance
    End Function
End Class
