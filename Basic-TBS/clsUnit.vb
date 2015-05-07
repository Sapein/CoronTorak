Public Class clsUnit
    Public unitHealth As Integer
    Public unitStrength As Integer
    Public unitRange As Integer
    Public unitTeam As String
    Public unitLocX As Integer
    Public unitLocY As Integer
    Public unitAssignedPicBox As String
    Public unitID As Integer

    Public Function checkDefendingUnitType()
        Dim defendingUnit = Form1.getDefendingUnit()
        If Form1.unitList(defendingUnit).ToString = "Basic_TBS.clsUnitWarrior" Then
            Return "warrior"
        ElseIf Form1.unitList(defendingUnit).ToString = "Basic_TBS.clsUnitArcher" Then
            Return "archer"
        Else
            Return "mage"
        End If
    End Function

    Public Sub destoryUnit(ByVal unitLocX As Integer, ByVal unitLocY As Integer)

    End Sub

    Public Sub updateUnit()

    End Sub

    Public Sub unitGetLocation()

    End Sub
End Class
