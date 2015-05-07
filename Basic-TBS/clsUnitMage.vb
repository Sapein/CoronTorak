Public Class clsUnitMage
    Inherits clsUnit
    Public unitID_Old As Integer
    Public unitType As Char

    Public Function unitGetBuffs()
        Dim defUnitType As String
        Dim attackingUnit As Integer
        attackingUnit = Form1.getSelectedUnit()
        defUnitType = checkDefendingUnitType()

        If defUnitType = "warrior" Then
            Return 2
        ElseIf defUnitType = "archer" Then
            Return -1
        Else
            Return 0
        End If
    End Function

    Public Function unitAttack()
        Dim Distance As Integer
        Distance = Form1.getDistance()
        If Distance > unitRange Then
            MessageBox.Show("UNIT OUT OF RANGE!")
            Return 9 'Error Code - 9: Unit out of Range
        ElseIf Distance <= unitRange Then
            Return 0 'Error Code - 0: Successful 
        Else
            Return 10 'Error Code - 10: Distance Calculation Error!
        End If
        Return 0
    End Function

    Public Sub unitInitialize(ByVal unitNumber As Integer, ByVal cUnitTeam As String, ByVal assignedArea As String, ByVal LocationX As Integer, ByVal LocationY As Integer)
        unitSetTeam(cUnitTeam)
        unitAssignedPicBox = assignedArea
        unitID = unitNumber
        unitHealth = 5
        unitStrength = 3
        unitRange = 210
        unitLocX = LocationX
        unitLocY = LocationY
        unitID_Old = unitID
    End Sub

    Public Sub unitTileLocation()

    End Sub

    Public Sub unitSetTeam(ByVal sUnitTeam As String)
        unitTeam = sUnitTeam
    End Sub
End Class
