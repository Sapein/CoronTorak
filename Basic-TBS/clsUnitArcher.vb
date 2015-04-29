Public Class clsUnitArcher
    Inherits clsUnit

    Public Sub unitAttack()

    End Sub

    Public Sub unitDefend()

    End Sub

    Public Sub unitInitialize(ByVal unitNumber As Integer, ByVal cUnitTeam As String, ByVal assignedArea As String)
        unitSetTeam(cUnitTeam)
        unitAssignedPicBox = assignedArea
        unitHealth = 7
        unitStrength = 5
        unitRange = 2
    End Sub

    Public Sub unitTileLocation()

    End Sub

    Public Sub unitSetTeam(ByVal sUnitTeam As String)
        unitTeam = sUnitTeam
    End Sub
End Class
