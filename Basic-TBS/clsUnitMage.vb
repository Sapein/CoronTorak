Public Class clsUnitMage
    Inherits clsUnit

    'Function: unitGetBuffs
    'Summary: Checks the unit type to get the buffs
    'Parameters: attackingUnit (integer), defUnit(integer), unitList(list)
    'Returns: Integer: -1, 0, or 2
    Public Function unitGetBuffs(ByVal attackingUnit, ByVal defUnit, ByRef unitList)
        Dim defUnitType As String
        defUnitType = checkDefendingUnitType(defUnit, unitList)

        If defUnitType = "warrior" Then
            Return 2
        ElseIf defUnitType = "archer" Then
            Return -1
        Else
            Return 0
        End If
    End Function

    'Initializes the unit
    Public Sub unitInitialize(ByVal unitNumber As Integer, ByVal cUnitTeam As String, ByVal assignedArea As String, ByVal LocationX As Integer, ByVal LocationY As Integer, Optional ByVal unitHP As Integer = 5)
        unitSetTeam(cUnitTeam)
        unitAssignedPicBox = assignedArea
        unitID = unitNumber
        unitHealth = unitHP
        unitStrength = 3
        unitRange = 210
        unitLocX = LocationX
        unitLocY = LocationY
    End Sub

    'Sets the unit Team
    Public Sub unitSetTeam(ByVal sUnitTeam As String)
        unitTeam = sUnitTeam
    End Sub
End Class
