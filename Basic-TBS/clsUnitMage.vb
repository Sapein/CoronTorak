Public Class clsUnitMage
    Inherits clsUnit
    Public unitID_Old As Integer
    Public unitType As Char

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

    Public Sub unitInitialize(ByVal unitNumber As Integer, ByVal cUnitTeam As String, ByVal assignedArea As String, ByVal LocationX As Integer, ByVal LocationY As Integer, Optional ByVal unitHP As Integer = 5)
        unitSetTeam(cUnitTeam)
        unitAssignedPicBox = assignedArea
        unitID = unitNumber
        unitHealth = unitHP
        unitStrength = 3
        unitRange = 210
        unitLocX = LocationX
        unitLocY = LocationY
        unitID_Old = unitID
    End Sub

    Public Sub unitSetTeam(ByVal sUnitTeam As String)
        unitTeam = sUnitTeam
    End Sub
End Class
