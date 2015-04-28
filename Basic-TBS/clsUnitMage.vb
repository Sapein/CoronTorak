Public Class clsUnitMage
    Inherits clsUnit
    Public unitType As Char

    Public Sub unitAttack()

    End Sub

    Public Sub unitDefend()

    End Sub

    Public Sub unitInitialize(ByVal unitNumber As Integer, ByVal cUnitTeam As String, ByVal assignedArea As String)
        unitSetTeam(cUnitTeam)
        unitAssignedPicBox = assignedArea
        unitHealth = 5
        unitStrength = 3
        unitRange = 3
    End Sub

    Public Sub unitTileLocation()

    End Sub

    Public Sub unitSetTeam(ByVal sUnitTeam As String)
        unitTeam = sUnitTeam
    End Sub

End Class
