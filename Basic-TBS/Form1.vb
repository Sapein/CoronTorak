Public Class Form1
    'This project was made by Sapein (AKA Chandler), for his Programming I class. For information see the TDD

    Public loadGame As Char = "N" 'This determines if a game should be loaded or not
    Private chrPlayerTurn As Char = "P" 'This allows us to know what turn it is. P is for Player, C is for Player2
    Private selectedUnit As Integer 'This is what allows us to tell what unit is selected. It uses the Unit ID number
    Private defUnit As Integer 'This allows us to know if a unit is defending and what unit it is. Uses the UID Number
    Private boolAttacking As Boolean 'This allows us to know if attacking mode is activated.

    'These next variables are the units themselves. There are a total of four for each unit, and two of each unit
    'Per team. Also Computer is Player 2.

    'Player Units
    Private mage1Player = New clsUnitMage
    Private mage2Player = New clsUnitMage
    Private warrior1Player = New clsUnitWarrior
    Private warrior2Player = New clsUnitWarrior
    Private archer1Player = New clsUnitArcher
    Private archer2Player = New clsUnitArcher

    'Computer Units
    Private mage1Computer = New clsUnitMage
    Private mage2Computer = New clsUnitMage
    Private warrior1Computer = New clsUnitWarrior
    Private warrior2Computer = New clsUnitWarrior
    Private archer1Computer = New clsUnitArcher
    Private archer2Computer = New clsUnitArcher

    'These variables simply hold the Units. The Ones right below this commented section are the main ones used, 
    'Which make a list of clsUnit(which, since clsUnitMage/Warrior/Archer are apart of it, can hold the units
    'The Backups are simply in case they are needed. 
    Private unitList As List(Of clsUnit) = New List(Of clsUnit)
    Private usedUnitList As List(Of clsUnit) = New List(Of clsUnit)
    Private deadUnitList As List(Of clsUnit) = New List(Of clsUnit)

    Private usedUnitListBackup As List(Of Object) = New List(Of Object)
    Private unitListBackup As List(Of Object) = New List(Of Object)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'This is what occurs when this form is loaded. 

        'Variables which depend upon selection are listed here and made to be -1, since the value should not be
        'Negative 1 for any unit
        selectedUnit = -1
        defUnit = -1

        'Sets the icons for the player units
        unitP4.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Mage Up Facing Blue.png")
        unitP6.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Mage Up Facing Blue.png")
        unitP5.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Warrior Up Facing Blue.png")
        unitP2.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Warrior Up Facing Blue.png")
        unitP1.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Archer Up Facing Blue.png")
        unitP3.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Archer Up Facing Blue.png")


        unitE4.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Mage Down Facing Orange.png")
        unitE6.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Mage Down Facing Orange.png")
        unitE5.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Warrior Down Facing Orange.png")
        unitE2.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Warrior Down Facing Orange.png")
        unitE1.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Archer Down Facing Orange.png")
        unitE3.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & "\Sprites\Archer Down Facing Orange.png")

        'The next two sections initizalize and create the units, setting everything that is needed about them.
        'Initializes Player Units
        mage1Player.unitInitialize(0, "Player", "unitP4", unitP4.Location.X, unitP4.Location.Y)
        mage2Player.unitInitialize(1, "Player", "unitP6", unitP6.Location.X, unitP6.Location.Y)
        warrior1Player.unitInitialize(2, "Player", "unitP5", unitP5.Location.X, unitP5.Location.Y)
        warrior2Player.unitInitialize(3, "Player", "unitP2", unitP2.Location.X, unitP2.Location.Y)
        archer1Player.unitInitialize(4, "Player", "unitP1", unitP1.Location.X, unitP1.Location.Y)
        archer2Player.unitInitialize(5, "Player", "unitP3", unitP3.Location.X, unitP3.Location.Y)

        'Initalizes Computer Units
        mage1Computer.unitInitialize(6, "Computer", "unitE4", unitE4.Location.X, unitE4.Location.Y)
        mage2Computer.unitInitialize(7, "Computer", "unitE6", unitE6.Location.X, unitE6.Location.Y)
        warrior1Computer.unitInitialize(8, "Computer", "unitE5", unitE5.Location.X, unitE5.Location.Y)
        warrior2Computer.unitInitialize(9, "Computer", "unitE2", unitE2.Location.X, unitE2.Location.Y)
        archer1Computer.unitInitialize(10, "Computer", "unitE1", unitE1.Location.X, unitE1.Location.Y)
        archer2Computer.unitInitialize(11, "Computer", "unitE3", unitE3.Location.X, unitE3.Location.Y)

        'This simply adds them to the unitList list so this way we can find them quickly without having to code 
        'each unit's reaction. 
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

        'This adds them to the unitListBackup list 
        For Each listItem As Object In unitList
            unitListBackup.Add(listItem)
        Next listItem

        'This also checks to see if we need to load a save-game or not.
        If loadGame = "L" Then
            loadSave()
        End If

        'This displays the unit stats.
        DisplayUnitStats()
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        'Error Codes are something borrowed from C and derived languages. It is how I can tell what happened.
        'Error Codes may also be different from an actual error. 
        Dim errorCodeCheck As Integer
        CheckTurn(selectedUnit) 'This merely checks the turn.

        errorCodeCheck = checkUnitUsed(selectedUnit) 'This checks to see if the unit has been used
        If errorCodeCheck = 5 Then
            Exit Sub 'This part only executes when the error code is 5
        End If

        errorCodeCheck = moveUnit(selectedUnit) 'Checks to see if the unit can Move, and if it can, moves it.
        If errorCodeCheck = 0 Then

        ElseIf errorCodeCheck = 11 Or errorCodeCheck = 12 Or errorCodeCheck = 13 Then
            Exit Sub 'If it can't move, then it exits here
        End If

        errorCodeCheck = opponentUnitMove(selectedUnit) 'Does the same thing, but for the opponent's units
        If errorCodeCheck = 0 Then

        ElseIf errorCodeCheck = 11 Or errorCodeCheck = 12 Or errorCodeCheck = 13 Then
            Exit Sub
        End If

        'This is done to allow us to use a list....
        errorCodeCheck = useUnit(selectedUnit) 'The unit is checked and then used
        If errorCodeCheck = 0 Then

        ElseIf errorCodeCheck = 4 Or 5 Then
            Exit Sub
        End If

        checkTurnEnd() 'It then checks to see if the turn is over.
    End Sub

    'Function: moveUnit()
    'Parameters: unitID - The ID of the Unit to move from either defUnit or selectUnit
    'Summary: Moves the unit for the player (Player 1)
    'Returns: Integer-0,11,12,13 (Error Codes)
    Private Function moveUnit(ByVal unitNum)
        Dim moveDirection As String
        Dim errorCodeCheck As Integer
        Dim unitFirstX As Integer
        Dim unitFirstY As Integer

        isOver() 'Checks to see if the turn is over

        If chrPlayerTurn = "C" Then
            Return 0 'Just makes sure it is the player's turn.
        End If

        If unitNum = mage1Player.unitID Then
            unitFirstY = Me.unitP4.Top
            unitFirstX = Me.unitP4.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP4.Top = Me.unitP4.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP4.Top = Me.unitP4.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP4.Left = Me.unitP4.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP4.Left = Me.unitP4.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            mage1Player.unitLocX = unitP4.Location.X
            mage1Player.unitLocY = unitP4.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP4.Left = unitFirstX
                Me.unitP4.Top = unitFirstY
                mage1Player.unitLocX = unitP4.Location.X
                mage1Player.unitLocY = unitP4.Location.Y
                Return 11 'Error Code 11: Unable to Move (General Error Code)
            End If
            Return 0
        ElseIf unitNum = mage2Player.unitID Then
            unitFirstY = Me.unitP6.Top
            unitFirstX = Me.unitP6.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP6.Top = Me.unitP6.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP6.Top = Me.unitP6.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP6.Left = Me.unitP6.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP6.Left = Me.unitP6.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            mage2Player.unitLocX = unitP6.Location.X
            mage2Player.unitLocY = unitP6.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP6.Left = unitFirstX
                Me.unitP6.Top = unitFirstY
                mage2Player.unitLocX = unitP6.Location.X
                mage2Player.unitLocY = unitP6.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = warrior1Player.unitID Then
            unitFirstY = Me.unitP5.Top
            unitFirstX = Me.unitP5.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP5.Top = Me.unitP5.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP5.Top = Me.unitP5.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP5.Left = Me.unitP5.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP5.Left = Me.unitP5.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13 'Error Code 13: No movement selected
            End If
            warrior1Player.unitLocX = unitP5.Location.X
            warrior1Player.unitLocY = unitP5.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP5.Left = unitFirstX
                Me.unitP5.Top = unitFirstY
                warrior1Player.unitLocX = unitP5.Location.X
                warrior1Player.unitLocY = unitP5.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = warrior2Player.unitID Then
            unitFirstY = Me.unitP2.Top
            unitFirstX = Me.unitP2.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP2.Top = Me.unitP2.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP2.Top = Me.unitP2.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP2.Left = Me.unitP2.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP2.Left = Me.unitP2.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            warrior2Player.unitLocX = unitP2.Location.X
            warrior2Player.unitLocY = unitP2.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP2.Left = unitFirstX
                Me.unitP2.Top = unitFirstY
                warrior2Player.unitLocX = unitP2.Location.X
                warrior2Player.unitLocY = unitP2.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = archer1Player.unitID Then
            unitFirstY = Me.unitP1.Top
            unitFirstX = Me.unitP1.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP1.Top = Me.unitP1.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP1.Top = Me.unitP1.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP1.Left = Me.unitP1.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP1.Left = Me.unitP1.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            archer1Player.unitLocX = unitP1.Location.X
            archer1Player.unitLocY = unitP1.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP1.Left = unitFirstX
                Me.unitP1.Top = unitFirstY
                archer1Player.unitLocX = unitP1.Location.X
                archer1Player.unitLocY = unitP1.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = archer2Player.unitID Then
            unitFirstY = Me.unitP3.Top
            unitFirstX = Me.unitP3.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitP3.Top = Me.unitP3.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitP3.Top = Me.unitP3.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitP3.Left = Me.unitP3.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitP3.Left = Me.unitP3.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            archer2Player.unitLocX = unitP3.Location.X
            archer2Player.unitLocY = unitP3.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP3.Left = unitFirstX
                Me.unitP3.Top = unitFirstY
                archer2Player.unitLocX = unitP3.Location.X
                archer2Player.unitLocY = unitP3.Location.Y
                Return 11
            End If
            Return 0
        End If
        Return 12 'Error Code 12: Unknown Error/Generic Error
    End Function

    'Function: oppnentUnitMove()
    'Parameters: unitID - The ID of the Unit to move from either defUnit or selectUnit
    'Summary: Moves the unit for the opponent/computer (Player 2)
    'Returns: Integer-0,11,12,13 (Error Codes)
    Private Function opponentUnitMove(ByVal unitNum)
        Dim moveDirection As String
        Dim errorCodeCheck As Integer
        Dim unitFirstX As Integer
        Dim unitFirstY As Integer
        isOver()
        If chrPlayerTurn = "P" Then
            Return 0
        End If
        If unitNum = mage1Computer.unitID Then
            unitFirstY = Me.unitE4.Top
            unitFirstX = Me.unitE4.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE4.Top = Me.unitE4.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE4.Top = Me.unitE4.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE4.Left = Me.unitE4.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE4.Left = Me.unitE4.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            mage1Computer.unitLocX = unitE4.Location.X
            mage1Computer.unitLocY = unitE4.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE4.Left = unitFirstX
                Me.unitE4.Top = unitFirstY
                mage1Computer.unitLocX = unitE4.Location.X
                mage1Computer.unitLocY = unitE4.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = mage2Computer.unitID Then
            unitFirstY = Me.unitE6.Top
            unitFirstX = Me.unitE6.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE6.Top = Me.unitE6.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE6.Top = Me.unitE6.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE6.Left = Me.unitE6.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE6.Left = Me.unitE6.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            mage2Computer.unitLocX = unitE6.Location.X
            mage2Computer.unitLocY = unitE6.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE6.Left = unitFirstX
                Me.unitE6.Top = unitFirstY
                mage2Computer.unitLocX = unitE6.Location.X
                mage2Computer.unitLocY = unitE6.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = warrior1Computer.unitID Then
            unitFirstY = Me.unitE5.Top
            unitFirstX = Me.unitE5.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE5.Top = Me.unitE5.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE5.Top = Me.unitE5.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE5.Left = Me.unitE5.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE5.Left = Me.unitE5.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            warrior1Computer.unitLocX = unitE5.Location.X
            warrior1Computer.unitLocY = unitE5.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE5.Left = unitFirstX
                Me.unitE5.Top = unitFirstY
                warrior1Computer.unitLocX = unitE5.Location.X
                warrior1Computer.unitLocY = unitE5.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = warrior2Computer.unitID Then
            unitFirstY = Me.unitE2.Top
            unitFirstX = Me.unitE2.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE2.Top = Me.unitE2.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE2.Top = Me.unitE2.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE2.Left = Me.unitE2.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE2.Left = Me.unitE2.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            warrior2Computer.unitLocX = unitE2.Location.X
            warrior2Computer.unitLocY = unitE2.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE2.Left = unitFirstX
                Me.unitE2.Top = unitFirstY
                warrior2Computer.unitLocX = unitE2.Location.X
                warrior2Computer.unitLocY = unitE2.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = archer1Computer.unitID Then
            unitFirstY = Me.unitE1.Top
            unitFirstX = Me.unitE1.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE1.Top = Me.unitE1.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE1.Top = Me.unitE1.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE1.Left = Me.unitE1.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE1.Left = Me.unitE1.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            archer1Computer.unitLocX = unitE1.Location.X
            archer1Computer.unitLocY = unitE1.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE1.Left = unitFirstX
                Me.unitE1.Top = unitFirstY
                archer1Computer.unitLocX = unitE1.Location.X
                archer1Computer.unitLocY = unitE1.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = archer2Computer.unitID Then
            unitFirstY = Me.unitE3.Top
            unitFirstX = Me.unitE3.Left
            moveDirection = InputBox("Please enter a direction: Up, Down, Left, Right, or Pass", "Basic-TBS: Movement")
            If LCase(moveDirection) = "up" Then
                Me.unitE3.Top = Me.unitE3.Top - 65
            ElseIf LCase(moveDirection) = "down" Then
                Me.unitE3.Top = Me.unitE3.Top + 65
            ElseIf LCase(moveDirection) = "left" Then
                Me.unitE3.Left = Me.unitE3.Left - 66
            ElseIf LCase(moveDirection) = "right" Then
                Me.unitE3.Left = Me.unitE3.Left + 66
            ElseIf LCase(moveDirection) = "pass" Then
                Return 0
            Else
                Return 13
            End If
            archer2Computer.unitLocX = unitE3.Location.X
            archer2Computer.unitLocY = unitE3.Location.Y
            errorCodeCheck = checkUnitLocation(selectedUnit)
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE3.Left = unitFirstX
                Me.unitE3.Top = unitFirstY
                archer2Computer.unitLocX = unitE3.Location.X
                archer2Computer.unitLocY = unitE3.Location.Y
                Return 11
            End If
            Return 0
        End If
        Return 12
    End Function

    'Simply used for movement/clicking
    Private Sub unitP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP4.Click
        If boolAttacking = False Then
            selectedUnit = mage1Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = mage1Player.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP5.Click
        If boolAttacking = False Then
            selectedUnit = warrior1Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = warrior1Player.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitP6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP6.Click
        If boolAttacking = False Then
            selectedUnit = mage2Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = mage2Player.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP1.Click
        If boolAttacking = False Then
            selectedUnit = archer1Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = archer1Player.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP2.Click
        If boolAttacking = False Then
            selectedUnit = warrior2Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = warrior2Player.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP3.Click
        If boolAttacking = False Then
            selectedUnit = archer2Player.unitID
        ElseIf boolAttacking = True Then
            defUnit = archer2Player.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE4.Click
        If boolAttacking = False Then
            selectedUnit = mage1Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = mage1Computer.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE6.Click
        If boolAttacking = False Then
            selectedUnit = mage2Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = mage2Computer.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE5.Click
        If boolAttacking = False Then
            selectedUnit = warrior1Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = warrior1Computer.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE2.Click
        If boolAttacking = False Then
            selectedUnit = warrior2Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = warrior2Computer.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE1.Click
        If boolAttacking = False Then
            selectedUnit = archer1Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = archer1Computer.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE3.Click
        If boolAttacking = False Then
            selectedUnit = archer2Computer.unitID
        ElseIf boolAttacking = True Then
            defUnit = archer2Computer.unitID
            CheckTurn(selectedUnit)
        End If
    End Sub
    Private Sub btnAttack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttack.Click
        Dim errorCodeCheck As Integer

        errorCodeCheck = CheckTurn(selectedUnit)
        If errorCodeCheck = 0 Then
            errorCodeCheck = 0
        ElseIf errorCodeCheck = 1 Or 2 Or 3 Then
            Exit Sub
        End If

        errorCodeCheck = checkUnitUsed(selectedUnit)
        If errorCodeCheck = 0 Then
            errorCodeCheck = 0
        ElseIf errorCodeCheck = 5 Then
            Exit Sub
        End If

        boolAttacking = True 'Note use the Movement Values for The check to see if it's valid. 
        MessageBox.Show("Please click the unit you wish to Attack")
    End Sub

    'Function: Attacking
    'Summary: When a unit wants to attack it uses this method.
    'Parameters: Optional: Boolean - boolDryRun 
    'Returns 0,6, or the output of checkUnitUsed.
    'Note: boolDryRun is depricated. Do not use it. Call checkUnitUsed instead.
    Private Function Attacking(ByVal defeUnit As Integer, ByVal atkUnit As Integer)
        Dim attackStat As Integer
        Dim healthOfDefending As Integer
        Dim rangeOfAttacking As Integer
        Dim errorCodeCheck As Integer
        Dim unitBuff As Integer

        'This is to check to see if the unit can actually attack or not.
        If (defeUnit = -1 And atkUnit = -1) Or (defeUnit = -1 Or atkUnit = -1) Then
            MessageBox.Show("ERROR: NO ATTACKING OR DEFNDING UNIT!", "ERROR: INVALID TARGET(S)")
            Return 6 'Error Code 6: Invalid Target(s)
        End If

        errorCodeCheck = unitList(atkUnit).unitAttack(unitList(atkUnit), unitList(defeUnit))
        If errorCodeCheck = 0 Then

        ElseIf errorCodeCheck = 9 Or errorCodeCheck = 10 Then
            boolAttacking = False
            Return 0
        End If

        unitBuff = unitListBackup(atkUnit).unitGetBuffs(atkUnit, defeUnit, unitList)
        errorCodeCheck = useUnit(atkUnit)
        If errorCodeCheck = 0 Then
        ElseIf errorCodeCheck = 4 Or 5 Then
            Return 0
        End If

        If atkUnit = -1 Then
            Return 0
        End If

        'This is the actual attacking code.
        attackStat = unitList(atkUnit).unitStrength
        healthOfDefending = unitList(defeUnit).unitHealth
        rangeOfAttacking = unitList(atkUnit).unitRange
        healthOfDefending = (healthOfDefending - attackStat) - unitBuff

        unitList(defeUnit).unitHealth = healthOfDefending

        MessageBox.Show("Unit " & unitList(atkUnit).unitID & " - " & unitList(atkUnit).unitTeam _
        & " attacked " & unitList(defeUnit).unitID & " - " & unitList(defeUnit).unitTeam & "! The defending unit's health" _
        & " is " & unitList(defeUnit).unitHealth)

        DisplayUnitStats()
        boolAttacking = False
        checkTurnEnd()
        isOver()

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

        'Used for the display of dead units
        If mage1Player.unitHealth <= 0 Then
            unit1.Text = "Mage 1 - DEAD"
            Me.Controls.Remove(unitP4)
            addUnitToDead(0)
        End If
        If mage2Player.unitHealth <= 0 Then
            unit2.Text = "Mage 2 - DEAD"
            Me.Controls.Remove(unitP6)
            addUnitToDead(1)
        End If
        If warrior1Player.unitHealth <= 0 Then
            unit3.Text = "Warrior 1 - DEAD"
            Me.Controls.Remove(unitP5)
            addUnitToDead(2)
        End If
        If warrior2Player.unitHealth <= 0 Then
            unit4.Text = "Warrior 2 - DEAD"
            Me.Controls.Remove(unitP2)
            addUnitToDead(3)
        End If
        If archer1Player.unitHealth <= 0 Then
            unit5.Text = "Archer 1 - DEAD"
            Me.Controls.Remove(unitP1)
            addUnitToDead(4)
        End If
        If archer2Player.unitHealth <= 0 Then
            unit6.Text = "Archer 2 - DEAD"
            Me.Controls.Remove(unitP3)
            addUnitToDead(5)
        End If

        If mage1Computer.unitHealth <= 0 Then
            eUnit1.Text = "Mage 1 - DEAD"
            Me.Controls.Remove(unitE4)
            addUnitToDead(6)
        End If
        If mage2Computer.unitHealth <= 0 Then
            eUnit2.Text = "Mage 2 - DEAD"
            Me.Controls.Remove(unitE6)
            deadUnitList.Add(mage2Computer)
            addUnitToDead(7)
        End If
        If warrior1Computer.unitHealth <= 0 Then
            eUnit3.Text = "Warrior 1 - DEAD"
            Me.Controls.Remove(unitE5)
            addUnitToDead(8)
        End If
        If warrior2Computer.unitHealth <= 0 Then
            eUnit4.Text = "Warrior 2 - DEAD"
            Me.Controls.Remove(unitE2)
            deadUnitList.Add(warrior2Computer)
            addUnitToDead(9)
        End If
        If archer1Computer.unitHealth <= 0 Then
            eUnit5.Text = "Archer 1 - DEAD"
            Me.Controls.Remove(unitE1)
            deadUnitList.Add(archer1Computer)
            addUnitToDead(10)
        End If
        If archer2Computer.unitHealth <= 0 Then
            eUnit6.Text = "Archer 2 - DEAD"
            Me.Controls.Remove(unitE3)
            addUnitToDead(11)
        End If
        isOver()
    End Sub

    'Function: CheckTurn()
    'Summary: Checks the current turn and also checks to see if attacking is possible
    'Returns: Integer - 0, 1, 2, or 3
    Private Function CheckTurn(ByVal unitNum)
        isOver()
        'NOTE: This returns an "ERROR LEVEL". I took the concept from C. Because there are 3 "errors" possible
        'There are 4 error Codes: 0 - Success: No Error encountered; 1 - INVALID UNIT: Attacking unit on wrong team; 
        '2 - INVALID UNIT: No Unit selected; 3 - Attacking Teamed Unit: Defending Unit on wrong team.

        If chrPlayerTurn = "P" Then
            If unitNum > -1 Then
                If unitList(unitNum).unitTeam = "Computer" Then
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
                If unitList(defUnit).unitTeam = "Computer" Then
                    Attacking(defUnit, selectedUnit)
                Else
                    defUnit = -1
                    MessageBox.Show("ERROR! PLEASE CHOOSE A NON-TEAMED UNIT!", "ERROR: ATTACKING TEAM-MATE")
                    Return 3
                End If
            End If

        ElseIf chrPlayerTurn = "C" Then
            If unitNum > -1 Then
                If unitList(unitNum).unitTeam = "Player" Then
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
                    Attacking(defUnit, selectedUnit)
                Else
                    defUnit = -1
                    MessageBox.Show("ERROR! PLEASE CHOOSE A NON-TEAMED UNIT!", "ERROR: ATTACKING TEAM-MATE")
                    Return 3
                End If
            End If
        End If

        Return 0
    End Function

    'Function: useUnit()
    'Summary: adds the unit to the used unit list
    'Parameters: Integer - Unit (As in the Unit ID)
    'Returns: Integer - 0, 4, or 5
    Private Function useUnit(ByVal unit As Integer)
        Dim i As Integer = 0

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
        Return 0 'Error Code 0: Successful Run
    End Function


    Private Sub checkTurnEnd() 'Checks the turn's end
        'These are used to iterate through the while loops
        Dim i As Integer = 0
        Dim x As Integer = 0
        Dim d As Integer = 0

        While i < usedUnitList.Count
            'MsgBox(usedUnitList(i).unitID)
            If chrPlayerTurn = "P" Then
                If usedUnitList(i).unitID = 0 Or usedUnitList(i).unitID = 1 Or usedUnitList(i).unitID = 2 Or usedUnitList(i).unitID = 3 Or usedUnitList(i).unitID = 4 Or usedUnitList(i).unitID = 5 Then
                    i += 1
                End If
                If i = 6 Then
                    MessageBox.Show("The turn of Player 1 is over, begin Player 2.", "Turn Over")
                    usedUnitList.Clear()
                    chrPlayerTurn = "C"
                    Exit Sub
                End If
            End If

            If chrPlayerTurn = "C" Then
                If usedUnitList(i).unitID = 6 Or usedUnitList(i).unitID = 7 Or usedUnitList(i).unitID = 8 Or usedUnitList(i).unitID = 9 Or usedUnitList(i).unitID = 10 Or usedUnitList(i).unitID = 11 Then
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

        While d < deadUnitList.Count
            If chrPlayerTurn = "P" Then
                If deadUnitList(d).unitID = 0 Or deadUnitList(d).unitID = 1 Or deadUnitList(d).unitID = 2 Or deadUnitList(d).unitID = 3 Or deadUnitList(d).unitID = 4 Or deadUnitList(d).unitID = 5 Then
                    i += 1
                End If
                If i = 6 Then
                    MessageBox.Show("The turn of Player 1 is over, begin Player 2.", "Turn Over")
                    usedUnitList.Clear()
                    chrPlayerTurn = "C"
                    Exit Sub
                End If
            End If

            If chrPlayerTurn = "C" Then
                If deadUnitList(d).unitID = 6 Or deadUnitList(d).unitID = 7 Or deadUnitList(d).unitID = 8 Or deadUnitList(d).unitID = 9 Or deadUnitList(d).unitID = 10 Or deadUnitList(d).unitID = 11 Then
                    i += 1
                End If
                If i = 6 Then
                    MessageBox.Show("The turn of Player 2 is over, begin Player 1.", "Turn Over")
                    usedUnitList.Clear()
                    chrPlayerTurn = "P"
                    Exit Sub
                End If
            End If
            d += 1
        End While

        selectedUnit = -1
    End Sub

    'Function: checkUnitLocation()
    'Summary: Checks to see if the unitLocation (taken by unit X) is sot
    'Parameters: unitA
    'Returns: Integer - 0, 7, or 8
    Private Function checkUnitLocation(ByVal unitA As Integer)
        Dim i As Integer
        While i < unitList.Count
            If unitList(unitA).unitLocX = unitList(i).unitLocX And unitList(unitA).unitLocY = unitList(i).unitLocY Then
                If unitList(unitA).unitID = unitList(i).unitID Then

                Else
                    Return 7 'Error Code 7: Unit Occupying Space
                End If
            End If
            i += 1
        End While

        If unitList(unitA).unitLocX <= 208 Or unitList(unitA).unitLocX >= 723 Then
            Return 8 'Error Code 8: Unit Passed Map Bounds
        End If

        If unitList(unitA).unitLocY <= 25 Or unitList(unitA).unitLocY >= 477 Then
            Return 8 'Error Code 8: Unit Passed Map Bounds
        End If
        Return 0
    End Function

    'Function: checkUnitUsed()
    'Summary: Checks to see if the unit has already been used
    'Parameters: unit [Integer] - Unit ID
    Private Function checkUnitUsed(ByVal unit As Integer)
        Dim i As Integer

        If i > usedUnitList.Count Or i < 0 Then
            Return 0
        End If
        If unit < 0 Then
            Return 5 'Error Code 14: unknown error
        End If

        While i < usedUnitList.Count
            If unitList(unit).unitID = usedUnitList(i).unitID Then
                MessageBox.Show("ERROR: UNIT ALREADY USED!", "ERROR: USED UNIT")
                Return 5 'Error Code 5: Unit Used
            End If
            i += 1
        End While

        Return 0
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim file As System.IO.StreamWriter
        Dim i As Integer = 0
        Dim x As Integer = 0

        file = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "/saves/Corontorak-Save.txt", False)

        file.WriteLine("2.0")
        If chrPlayerTurn = "P" Then
            file.WriteLine("Turn1")
        ElseIf chrPlayerTurn = "C" Then
            file.WriteLine("Turn2")
        End If

        While i < unitList.Count
            Dim isUsed As Boolean = False
            While x < usedUnitList.Count
                If usedUnitList(x).unitID = unitList(i).unitID Then
                    isUsed = True
                    Exit While
                End If
                x += 1
            End While
            x = 0
            file.WriteLine(unitList(i).unitID & " " & unitList(i).unitTeam & " " & unitList(i).unitAssignedPicBox _
            & " " & unitList(i).unitLocX & " " & unitList(i).unitLocY & " " & unitList(i).unitHealth & " " & isUsed)
            i += 1
        End While
        file.Close()

    End Sub

    Public Sub loadSave() 'loads the saves
        'Iteration Variables
        Dim t As Integer = 0
        Dim i As Integer = 0
        Dim TX As Integer = 0

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(My.Application.Info.DirectoryPath & "/saves/Corontorak-Save.txt")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(" ")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    Dim x As Integer = 0
                    Dim unitStuff As List(Of Object) = New List(Of Object)

                    For Each currentField In currentRow
                        'Checks to see if the line is the 'Turn Line'
                        If currentField = "2.0" Then
                            loadNewFormat()
                            Exit Sub
                        End If
                        If currentField = "Turn1" Then
                            chrPlayerTurn = "P"
                        ElseIf currentField = "Turn2" Then
                            chrPlayerTurn = "C"
                        Else
                            unitStuff.Add(currentField)
                            x += 1
                        End If

                        If x = 7 Then 'This actually loads up the location of the units, and sets their variables.
                            unitList(i).unitID = unitStuff(0) - 1
                            unitList(i).unitAssignedPicBox = unitStuff(2)
                            unitList(i).unitLocX = unitStuff(3)
                            unitList(i).unitLocY = unitStuff(4)
                            unitList(i).unitHealth = unitStuff(5)
                            t = 0
                            While t < Me.Controls.Count
                                TX = 0
                                If Me.Controls(t).Name.Contains("unitE") Or Me.Controls(t).Name.Contains("unitP") Then
                                    While TX < unitList.Count
                                        If Me.Controls(t).Name.Equals(unitList(TX).unitAssignedPicBox) Then
                                            Me.Controls(t).Location = New Point(unitList(TX).unitLocX, unitList(TX).unitLocY)
                                        End If
                                        TX += 1
                                    End While
                                End If
                                t += 1
                            End While

                            If unitStuff(6) = True Then
                                useUnit(i)
                            End If
                            unitStuff.Clear()
                            i += 1
                        End If
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                End Try
            End While
        End Using
    End Sub

    Public Sub isOver() 'Checks to see if the game is over
        If mage1Player.unitHealth = 0 And mage2Player.unitHealth = 0 And warrior1Player.unitHealth = 0 And warrior2Player.unitHealth = 0 And archer1Player.unitHealth = 0 And archer2Player.unitHealth = 0 Then
            MessageBox.Show("Game over")
            End
        ElseIf mage1Computer.unitHealth = 0 And mage2Computer.unitHealth = 0 And warrior1Computer.unitHealth = 0 And warrior2Computer.unitHealth = 0 And archer1Computer.unitHealth = 0 And archer2Computer.unitHealth = 0 Then
            MessageBox.Show("You Win!")
            End
        End If
    End Sub

    Private Sub addUnitToDead(ByVal unitNum)
        Dim i As Integer = 0

        If unitNum <= -1 Then
            Exit Sub
        End If

        While i < deadUnitList.Count
            If unitList(unitNum).unitID = deadUnitList(i).unitID Then
                Exit Sub
            End If
            i += 1
        End While

        deadUnitList.Add(unitList(unitNum))
    End Sub

    Private Sub loadNewFormat()
        Dim t As Integer = 0
        Dim i As Integer = 0
        Dim TX As Integer = 0

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(My.Application.Info.DirectoryPath & "/saves/Corontorak-Save.txt")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(" ")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    Dim x As Integer = 0
                    Dim unitStuff As List(Of Object) = New List(Of Object)

                    For Each currentField In currentRow
                        'Checks to see if the line is the 'Turn Line'
                        If currentField = "Turn1" Then
                            chrPlayerTurn = "P"
                        ElseIf currentField = "Turn2" Then
                            chrPlayerTurn = "C"
                        Else
                            unitStuff.Add(currentField)
                            x += 1
                        End If

                        If x = 7 Then 'This actually loads up the location of the units, and sets their variables.
                            unitList(i).unitID = unitStuff(0)
                            unitList(i).unitAssignedPicBox = unitStuff(2)
                            unitList(i).unitLocX = unitStuff(3)
                            unitList(i).unitLocY = unitStuff(4)
                            unitList(i).unitHealth = unitStuff(5)
                            t = 0
                            While t < Me.Controls.Count
                                TX = 0
                                If Me.Controls(t).Name.Contains("unitE") Or Me.Controls(t).Name.Contains("unitP") Then
                                    While TX < unitList.Count
                                        If Me.Controls(t).Name.Equals(unitList(TX).unitAssignedPicBox) Then
                                            Me.Controls(t).Location = New Point(unitList(TX).unitLocX, unitList(TX).unitLocY)
                                        End If
                                        TX += 1
                                    End While
                                End If
                                t += 1
                            End While

                            If unitStuff(6) = True Then
                                useUnit(i)
                            End If
                            unitStuff.Clear()
                            i += 1
                        End If
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                End Try
            End While
        End Using
    End Sub
End Class