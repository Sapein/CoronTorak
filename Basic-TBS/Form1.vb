Public Class Form1
    'This project was programmed by Sapein. 
    Private chrPlayerTurn As Char = "P"c 'This allows us to know what turn it is. P is for Player, C is for Player2
    Private selectedUnit As Integer 'This is what allows us to tell what unit is selected. It uses the Unit ID number
    Private defUnit As Integer 'This allows us to know if a unit is defending and what unit it is. Uses the UID Number
    Private boolAttacking As Boolean 'This allows us to know if attacking mode is activated.

    'These next variables are the units themselves. There are a total of four for each unit, and two of each unit
    'Per team. Also Computer is Player 2.

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
        unitP4.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_MAGE).ToString)
        unitP6.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_MAGE).ToString)
        unitP5.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
        unitP2.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
        unitP1.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_ARCHER).ToString)
        unitP3.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_ARCHER).ToString)


        unitE4.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.ORANGE_MAGE).ToString)
        unitE6.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.ORANGE_MAGE).ToString)
        unitE5.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.ORANGE_WARRIOR).ToString)
        unitE2.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.ORANGE_WARRIOR).ToString)
        unitE1.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.ORANGE_ARCHER).ToString)
        unitE3.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.ORANGE_ARCHER).ToString)

        For i As Integer = 0 To CInt(MenuS.Base_Engine.getMageAmountP1())
            If CInt(MenuS.Base_Engine.getMageAmountP1()) = 0 Then
                Exit For
            End If
            unitListBackup.Add(New clsUnitMage)
            unitP4.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_MAGE).ToString)
            unitP6.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_MAGE).ToString)
            unitP5.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_MAGE).ToString)
            unitP2.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_MAGE).ToString)
            unitP1.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_MAGE).ToString)
            unitP3.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_MAGE).ToString)
        Next
        For i As Integer = 0 To CInt(MenuS.Base_Engine.getWarriorAmountP1())
            If CInt(MenuS.Base_Engine.getWarriorAmountP1()) = 0 Then
                Exit For
            End If
            unitListBackup.Add(New clsUnitWarrior)
            unitP5.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
            unitP2.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
            If MenuS.Base_Engine.getWarriorAmountP1() = 3 Then
                unitP6.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
            ElseIf MenuS.Base_Engine.getWarriorAmountP1() > 3 Then
                unitP4.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
                unitP6.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
                unitP5.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
                unitP2.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
                unitP1.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
                unitP3.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
            End If
        Next
        For i As Integer = 0 To CInt(MenuS.Base_Engine.getArcherAmountP1())
            If CInt(MenuS.Base_Engine.getArcherAmountP1()) = 0 Then
                Exit For
            End If
            unitListBackup.Add(New clsUnitArcher)
            If MenuS.Base_Engine.getArcherAmountP1() = 0 Then
            ElseIf MenuS.Base_Engine.getArcherAmountP1() = 1 Then
                unitP1.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_ARCHER).ToString)
            ElseIf MenuS.Base_Engine.getArcherAmountP1() = 2 Then
                unitP1.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_ARCHER).ToString)
                unitP3.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_ARCHER).ToString)
            ElseIf MenuS.Base_Engine.getArcherAmountP1() = 3 Then
                unitP4.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_WARRIOR).ToString)
                unitP1.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_ARCHER).ToString)
                unitP3.Image = System.Drawing.Bitmap.FromFile(My.Application.Info.DirectoryPath & (MenuS.Base_Engine.BLUE_ARCHER).ToString)
            ElseIf MenuS.Base_Engine.getArcherAmountP1() = 4 Then

            End If

        Next

        For i As Integer = 0 To CInt(MenuS.Base_Engine.getMageAmountP2())
            If CInt(MenuS.Base_Engine.getMageAmountP2()) = 0 Then
                Exit For
            End If
            unitListBackup.Add(New clsUnitMage)
        Next
        For i As Integer = 0 To CInt(MenuS.Base_Engine.getWarriorAmountP2())
            If CInt(MenuS.Base_Engine.getWarriorAmountP2()) = 0 Then
                Exit For
            End If
            unitListBackup.Add(New clsUnitWarrior)
        Next
        For i As Integer = 0 To CInt(MenuS.Base_Engine.getArcherAmountP2())
            If CInt(MenuS.Base_Engine.getArcherAmountP2()) = 0 Then
                Exit For
            End If
            unitListBackup.Add(New clsUnitArcher)
        Next

        'The next two sections initizalize and create the units, setting everything that is needed about them.
        'Initializes Player Units
        unitListBackup(0).unitInitialize(0, "Player", "unitP4", unitP4.Location.X, unitP4.Location.Y)
        unitListBackup(1).unitInitialize(1, "Player", "unitP6", unitP6.Location.X, unitP6.Location.Y)
        unitListBackup(2).unitInitialize(2, "Player", "unitP5", unitP5.Location.X, unitP5.Location.Y)
        unitListBackup(3).unitInitialize(3, "Player", "unitP2", unitP2.Location.X, unitP2.Location.Y)
        unitListBackup(4).unitInitialize(4, "Player", "unitP1", unitP1.Location.X, unitP1.Location.Y)
        unitListBackup(5).unitInitialize(5, "Player", "unitP3", unitP3.Location.X, unitP3.Location.Y)

        'Initalizes Computer Units
        unitListBackup(6).unitInitialize(6, "Computer", "unitE4", unitE4.Location.X, unitE4.Location.Y)
        unitListBackup(7).unitInitialize(7, "Computer", "unitE6", unitE6.Location.X, unitE6.Location.Y)
        unitListBackup(8).unitInitialize(8, "Computer", "unitE5", unitE5.Location.X, unitE5.Location.Y)
        unitListBackup(9).unitInitialize(9, "Computer", "unitE2", unitE2.Location.X, unitE2.Location.Y)
        unitListBackup(10).unitInitialize(10, "Computer", "unitE1", unitE1.Location.X, unitE1.Location.Y)
        unitListBackup(11).unitInitialize(11, "Computer", "unitE3", unitE3.Location.X, unitE3.Location.Y)

        'This simply adds them to the unitList list so this way we can find them quickly without having to code 
        'each unit's reaction. 

        'This adds them to the unitListBackup list 
        For Each listItem As Object In unitListBackup
            unitList.Add(CType(listItem, clsUnit))
        Next listItem

        'This also checks to see if we need to load a save-game or not.
        If MenuS.Base_Engine.getLoadGame() = "L"c Then
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

        errorCodeCheck = CInt(checkUnitUsed(selectedUnit)) 'This checks to see if the unit has been used
        If errorCodeCheck = 5 Then
            Exit Sub 'This part only executes when the error code is 5
        End If

        errorCodeCheck = CInt(moveUnit(selectedUnit)) 'Checks to see if the unit can Move, and if it can, moves it.
        If errorCodeCheck = 0 Then

        ElseIf errorCodeCheck = 11 Or errorCodeCheck = 12 Or errorCodeCheck = 13 Then
            Exit Sub 'If it can't move, then it exits here
        End If

        errorCodeCheck = CInt(opponentUnitMove(selectedUnit)) 'Does the same thing, but for the opponent's units
        If errorCodeCheck = 0 Then

        ElseIf errorCodeCheck = 11 Or errorCodeCheck = 12 Or errorCodeCheck = 13 Then
            Exit Sub
        End If

        'This is done to allow us to use a list....
        errorCodeCheck = CInt(useUnit(selectedUnit)) 'The unit is checked and then used
        If errorCodeCheck = 0 Then

        ElseIf errorCodeCheck = 4 Or errorCodeCheck = 5 Then
            Exit Sub
        End If

        checkTurnEnd() 'It then checks to see if the turn is over.
    End Sub

    'Function: moveUnit()
    'Parameters: unitID - The ID of the Unit to move from either defUnit or selectUnit
    'Summary: Moves the unit for the player (Player 1)
    'Returns: Integer-0,11,12,13 (Error Codes)
    Private Function moveUnit(ByVal unitNum As Integer) As Integer
        Dim moveDirection As String
        Dim errorCodeCheck As Integer
        Dim unitFirstX As Integer
        Dim unitFirstY As Integer

        isOver() 'Checks to see if the turn is over

        If chrPlayerTurn = "C" Then
            Return 0 'Just makes sure it is the player's turn.
        End If

        If unitNum = CInt(unitList(0).unitID) Then
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
            unitList(0).unitLocX = unitP4.Location.X
            unitList(0).unitLocY = unitP4.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP4.Left = unitFirstX
                Me.unitP4.Top = unitFirstY
                unitList(0).unitLocX = unitP4.Location.X
                unitList(0).unitLocY = unitP4.Location.Y
                Return 11 'Error Code 11: Unable to Move (General Error Code)
            End If
            Return 0
        ElseIf unitNum = CInt(unitList(1).unitID) Then
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
            unitList(1).unitLocX = unitP6.Location.X
            unitList(1).unitLocY = unitP6.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP6.Left = unitFirstX
                Me.unitP6.Top = unitFirstY
                unitList(1).unitLocX = unitP6.Location.X
                unitList(1).unitLocY = unitP6.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = CInt(unitList(2).unitID) Then
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
            unitList(2).unitLocX = unitP5.Location.X
            unitList(2).unitLocY = unitP5.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP5.Left = unitFirstX
                Me.unitP5.Top = unitFirstY
                unitList(2).unitLocX = unitP5.Location.X
                unitList(2).unitLocY = unitP5.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = CInt(unitList(3).unitID) Then
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
            unitList(3).unitLocX = unitP2.Location.X
            unitList(3).unitLocY = unitP2.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP2.Left = unitFirstX
                Me.unitP2.Top = unitFirstY
                unitList(3).unitLocX = unitP2.Location.X
                unitList(3).unitLocY = unitP2.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = CInt(unitList(4).unitID) Then
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
            unitList(4).unitLocX = unitP1.Location.X
            unitList(4).unitLocY = unitP1.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP1.Left = unitFirstX
                Me.unitP1.Top = unitFirstY
                unitList(4).unitLocX = unitP1.Location.X
                unitList(4).unitLocY = unitP1.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = CInt(unitList(5).unitID) Then
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
            unitList(4).unitLocX = unitP3.Location.X
            unitList(4).unitLocY = unitP3.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitP3.Left = unitFirstX
                Me.unitP3.Top = unitFirstY
                unitList(5).unitLocX = unitP3.Location.X
                unitList(5).unitLocY = unitP3.Location.Y
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
    Private Function opponentUnitMove(ByVal unitNum As Integer) As Integer
        Dim moveDirection As String
        Dim errorCodeCheck As Integer
        Dim unitFirstX As Integer
        Dim unitFirstY As Integer
        isOver()
        If chrPlayerTurn = "P" Then
            Return 0
        End If
        If unitNum = CInt(unitList(6).unitID) Then
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
            unitList(6).unitLocX = unitE4.Location.X
            unitList(6).unitLocY = unitE4.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE4.Left = unitFirstX
                Me.unitE4.Top = unitFirstY
                unitList(6).unitLocX = unitE4.Location.X
                unitList(6).unitLocY = unitE4.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = CInt(unitList(7).unitID) Then
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
            unitList(7).unitLocX = unitE6.Location.X
            unitList(7).unitLocY = unitE6.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE6.Left = unitFirstX
                Me.unitE6.Top = unitFirstY
                unitList(7).unitLocX = unitE6.Location.X
                unitList(7).unitLocY = unitE6.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = CInt(unitList(8).unitID) Then
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
            unitList(8).unitLocX = unitE5.Location.X
            unitList(8).unitLocY = unitE5.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE5.Left = unitFirstX
                Me.unitE5.Top = unitFirstY
                unitList(8).unitLocX = unitE5.Location.X
                unitList(8).unitLocY = unitE5.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = CInt(unitList(9).unitID) Then
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
            unitList(9).unitLocX = unitE2.Location.X
            unitList(9).unitLocY = unitE2.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE2.Left = unitFirstX
                Me.unitE2.Top = unitFirstY
                unitList(9).unitLocX = unitE2.Location.X
                unitList(9).unitLocY = unitE2.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = CInt(unitList(10).unitID) Then
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
            unitList(10).unitLocX = unitE1.Location.X
            unitList(10).unitLocY = unitE1.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE1.Left = unitFirstX
                Me.unitE1.Top = unitFirstY
                unitList(10).unitLocX = unitE1.Location.X
                unitList(10).unitLocY = unitE1.Location.Y
                Return 11
            End If
            Return 0
        ElseIf unitNum = CInt(unitList(11).unitID) Then
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
            unitList(11).unitLocX = unitE3.Location.X
            unitList(11).unitLocY = unitE3.Location.Y
            errorCodeCheck = CInt(checkUnitLocation(selectedUnit))
            If errorCodeCheck = 7 Or errorCodeCheck = 8 Then
                Me.unitE3.Left = unitFirstX
                Me.unitE3.Top = unitFirstY
                unitList(11).unitLocX = unitE3.Location.X
                unitList(11).unitLocY = unitE3.Location.Y
                Return 11
            End If
            Return 0
        End If
        Return 12
    End Function

    'Simply used for movement/clicking
    Private Sub unitP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP4.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitListBackup(0).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(0).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP5.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(2).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(2).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitP6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP6.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(1).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(1).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP1.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(4).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(4).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP2.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(3).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(3).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitP3.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(5).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(5).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE4.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(6).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(6).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE6.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(7).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(7).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE5.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(8).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(8).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE2.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(9).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(9).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE1.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(10).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(10).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub

    Private Sub unitE3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitE3.Click
        If boolAttacking = False Then
            selectedUnit = CInt(unitList(11).unitID)
        ElseIf boolAttacking = True Then
            defUnit = CInt(unitList(11).unitID)
            CheckTurn(selectedUnit)
        End If
    End Sub
    Private Sub btnAttack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttack.Click
        Dim errorCodeCheck As Integer

        errorCodeCheck = CInt(CheckTurn(selectedUnit))
        If errorCodeCheck = 0 Then
            errorCodeCheck = 0
        ElseIf errorCodeCheck = 1 Or errorCodeCheck = 2 Or errorCodeCheck = 3 Then
            Exit Sub
        End If

        errorCodeCheck = CInt(checkUnitUsed(selectedUnit))
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
    Private Function Attacking(ByVal defeUnit As Integer, ByVal atkUnit As Integer) As Integer
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

        errorCodeCheck = CInt(unitList(atkUnit).unitAttack(unitList(atkUnit), unitList(defeUnit)))
        If errorCodeCheck = 0 Then

        ElseIf errorCodeCheck = 9 Or errorCodeCheck = 10 Then
            boolAttacking = False
            Return 0
        End If

        unitBuff = CInt(unitListBackup(atkUnit).unitGetBuffs(atkUnit, defeUnit, unitList))
        errorCodeCheck = CInt(useUnit(atkUnit))
        If errorCodeCheck = 0 Then
        ElseIf errorCodeCheck = 4 Or errorCodeCheck = 5 Then
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

        unit1.Text = ("Mage 1 - HP: " & unitList(0).unitHealth & " - Atk: " & unitList(0).unitStrength).ToString
        unit2.Text = ("Mage 2 - HP: " & unitList(1).unitHealth & " - Atk: " & unitList(1).unitStrength).ToString
        unit3.Text = ("Warrior 1 - HP: " & unitList(2).unitHealth & AttackDisplay & unitList(2).unitStrength).ToString
        unit4.Text = ("Warrior 2 - HP: " & unitList(3).unitHealth & AttackDisplay & unitList(3).unitStrength).ToString
        unit5.Text = ("Archer 1 - HP: " & unitList(4).unitHealth & AttackDisplay & unitList(4).unitStrength).ToString
        unit6.Text = ("Archer 2 - HP: " & unitList(5).unitHealth & AttackDisplay & unitList(5).unitStrength).ToString

        eUnit1.Text = ("Mage 1 - HP: " & unitList(6).unitHealth & " - Atk: " & unitList(6).unitStrength).ToString
        eUnit2.Text = ("Mage 2 - HP: " & unitList(7).unitHealth & " - Atk: " & unitList(7).unitStrength).ToString
        eUnit3.Text = ("Warrior 1 - HP: " & unitList(8).unitHealth & AttackDisplay & unitList(8).unitStrength).ToString
        eUnit4.Text = ("Warrior 2 - HP: " & unitList(9).unitHealth & AttackDisplay & unitList(9).unitStrength).ToString
        eUnit5.Text = ("Archer 1 - HP: " & unitList(10).unitHealth & AttackDisplay & unitList(10).unitStrength).ToString
        eUnit6.Text = ("Archer 2 - HP: " & unitList(11).unitHealth & AttackDisplay & unitList(11).unitStrength).ToString

        'Used for the display of dead units
        If unitList(0).unitHealth <= 0 Then
            unit1.Text = "Mage 1 - DEAD"
            Me.Controls.Remove(unitP4)
            addUnitToDead(0)
        End If
        If unitList(1).unitHealth <= 0 Then
            unit2.Text = "Mage 2 - DEAD"
            Me.Controls.Remove(unitP6)
            addUnitToDead(1)
        End If
        If unitList(2).unitHealth <= 0 Then
            unit3.Text = "Warrior 1 - DEAD"
            Me.Controls.Remove(unitP5)
            addUnitToDead(2)
        End If
        If unitList(3).unitHealth <= 0 Then
            unit4.Text = "Warrior 2 - DEAD"
            Me.Controls.Remove(unitP2)
            addUnitToDead(3)
        End If
        If unitList(4).unitHealth <= 0 Then
            unit5.Text = "Archer 1 - DEAD"
            Me.Controls.Remove(unitP1)
            addUnitToDead(4)
        End If
        If unitList(5).unitHealth <= 0 Then
            unit6.Text = "Archer 2 - DEAD"
            Me.Controls.Remove(unitP3)
            addUnitToDead(5)
        End If

        If unitList(6).unitHealth <= 0 Then
            eUnit1.Text = "Mage 1 - DEAD"
            Me.Controls.Remove(unitE4)
            addUnitToDead(6)
        End If
        If unitList(7).unitHealth <= 0 Then
            eUnit2.Text = "Mage 2 - DEAD"
            Me.Controls.Remove(unitE6)
            addUnitToDead(7)
        End If
        If unitList(8).unitHealth <= 0 Then
            eUnit3.Text = "Warrior 1 - DEAD"
            Me.Controls.Remove(unitE5)
            addUnitToDead(8)
        End If
        If unitList(9).unitHealth <= 0 Then
            eUnit4.Text = "Warrior 2 - DEAD"
            Me.Controls.Remove(unitE2)
            addUnitToDead(9)
        End If
        If unitList(10).unitHealth <= 0 Then
            eUnit5.Text = "Archer 1 - DEAD"
            Me.Controls.Remove(unitE1)
            addUnitToDead(10)
        End If
        If unitList(11).unitHealth <= 0 Then
            eUnit6.Text = "Archer 2 - DEAD"
            Me.Controls.Remove(unitE3)
            addUnitToDead(11)
        End If
        isOver()
    End Sub

    'Function: CheckTurn()
    'Summary: Checks the current turn and also checks to see if attacking is possible
    'Returns: Integer - 0, 1, 2, or 3
    Private Function CheckTurn(ByVal unitNum As Integer) As Integer
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
    Private Function useUnit(ByVal unit As Integer) As Integer
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
                    chrPlayerTurn = "C"c
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
                    chrPlayerTurn = "P"c
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
                    chrPlayerTurn = "C"c
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
                    chrPlayerTurn = "P"c
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
    Private Function checkUnitLocation(ByVal unitA As Integer) As Integer
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
    Private Function checkUnitUsed(ByVal unit As Integer) As Integer
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
                        If currentField = "3.0" Then
                            loadNewFormat()
                            Exit Sub
                        End If
                        MessageBox.Show("You are using an outdated save file!")
                        Exit Sub
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                End Try
            End While
        End Using
    End Sub

    Public Sub isOver() 'Checks to see if the game is over
        If CBool(unitList(0).unitHealth = 0 And unitList(1).unitHealth = 0 And unitList(2).unitHealth = 0 And unitList(3).unitHealth = 0 And unitList(4).unitHealth = 0 And unitList(5).unitHealth = 0) Then
            MessageBox.Show("Game over")
            End
        ElseIf CBool(unitList(6).unitHealth = 0 And unitList(7).unitHealth = 0 And unitList(8).unitHealth = 0 And unitList(9).unitHealth = 0 And unitList(10).unitHealth = 0 And unitList(11).unitHealth = 0) Then
            MessageBox.Show("You Win!")
            End
        End If
    End Sub

    Private Sub addUnitToDead(ByVal unitNum As Integer)
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
                            chrPlayerTurn = "P"c
                        ElseIf currentField = "Turn2" Then
                            chrPlayerTurn = "C"c
                        Else
                            unitStuff.Add(currentField)
                            x += 1
                        End If

                        If x = 7 Then 'This actually loads up the location of the units, and sets their variables.
                            unitList(i).unitID = CInt(unitStuff(0))
                            unitList(i).unitAssignedPicBox = unitStuff(2).ToString
                            unitList(i).unitLocX = CInt(unitStuff(3))
                            unitList(i).unitLocY = CInt(unitStuff(4))
                            unitList(i).unitHealth = CInt(unitStuff(5))
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