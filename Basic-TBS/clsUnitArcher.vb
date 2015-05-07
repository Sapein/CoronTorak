Public Class clsUnitArcher
    Inherits clsUnit
    Public unitID_Old As Integer
    Public Function unitGetBuffs()
        Dim defUnitType As String
        Dim attackingUnit As Integer
        attackingUnit = Form1.getSelectedUnit()
        defUnitType = checkDefendingUnitType()

        If defUnitType = "mage" Then
            Return 2
        ElseIf defUnitType = "warrior" Then
            Return -1
        Else
            Return 0
        End If
    End Function

    Public Function unitAttack()
        Dim DistanceX
        Dim DistanceY
        DistanceX = Form1.checkUnitDistanceX()
        DistanceY = Form1.checkUnitDistanceY()
        MessageBox.Show(DistanceX)
        MessageBox.Show(DistanceY)
        If DistanceX = 0 Then
            DistanceX = 300
        ElseIf DistanceY = 0 Then
            DistanceY = 300
        End If
        If (DistanceX > unitRange And DistanceY > unitRange) Then
            MessageBox.Show("UNIT OUT OF RANGE!")
        Else
            If DistanceX <= unitRange Then
                If DistanceY <= unitRange Then
                    MessageBox.Show("Unit In Range!")
                End If

            End If
        End If
        Return 0
    End Function

    Public Sub unitInitialize(ByVal unitNumber As Integer, ByVal cUnitTeam As String, ByVal assignedArea As String, ByVal LocationX As Integer, ByVal LocationY As Integer)
        unitSetTeam(cUnitTeam)
        unitAssignedPicBox = assignedArea
        unitHealth = 7
        unitStrength = 5
        unitRange = 140
        unitLocX = LocationX
        unitLocY = LocationY
        unitID = unitNumber
        unitID_Old = unitID
    End Sub

    Public Sub unitTileLocation()

    End Sub

    Public Sub unitSetTeam(ByVal sUnitTeam As String)
        unitTeam = sUnitTeam
    End Sub
End Class
