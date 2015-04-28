Public Class clsUnitWarrior
    Inherits clsUnit
    Public Sub unitAttack()

    End Sub

    Public Sub unitDefend()

    End Sub

    Public Sub unitInitialize(ByVal unitNumber As Integer, ByVal cUnitTeam As String)
        unitSetTeam(cUnitTeam)
    End Sub

    Public Sub unitTileLocation()

    End Sub

    Public Sub unitSetTeam(ByVal sUnitTeam As String)
        unitTeam = sUnitTeam
    End Sub
End Class
