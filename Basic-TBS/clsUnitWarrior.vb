Public Class clsUnitWarrior
    Inherits clsUnit
    Public unitID_old
    Public Function unitGetBuffs()
        Dim defUnitType As String
        Dim attackingUnit As Integer
        attackingUnit = Form1.getSelectedUnit()
        defUnitType = checkDefendingUnitType()

        If defUnitType = "archer" Then
            Return 2
        ElseIf defUnitType = "mage" Then
            Return -1
        Else
            Return 0
        End If
    End Function

    Public Sub unitInitialize(ByVal unitNumber As Integer, ByVal cUnitTeam As String, ByVal assignedArea As String, ByVal LocationX As Integer, ByVal LocationY As Integer)
        unitSetTeam(cUnitTeam)
        unitAssignedPicBox = assignedArea
        unitHealth = 10
        unitStrength = 6
        unitRange = 70
        unitLocX = LocationX
        unitLocY = LocationY
        unitID = unitNumber
        unitID_old = unitID
    End Sub

    Public Sub unitTileLocation()

    End Sub

    Public Sub unitSetTeam(ByVal sUnitTeam As String)
        unitTeam = sUnitTeam
    End Sub
End Class
