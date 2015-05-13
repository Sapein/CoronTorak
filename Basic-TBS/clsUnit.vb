Public Class clsUnit
    Public unitHealth As Integer
    Public unitStrength As Integer
    Public unitRange As Integer
    Public unitTeam As String
    Public unitLocX As Integer
    Public unitLocY As Integer
    Public unitAssignedPicBox As String
    Public unitID As Integer

    Public Function checkDefendingUnitType(ByVal defUnit, ByRef unitList)
        Dim defendingUnit = defUnit
        If unitList(defendingUnit).ToString = "Basic_TBS.clsUnitWarrior" Then
            Return "warrior"
        ElseIf unitList(defendingUnit).ToString = "Basic_TBS.clsUnitArcher" Then
            Return "archer"
        Else
            Return "mage"
        End If
    End Function

    Public Function unitAttack(ByVal unit1 As Object, ByVal unit2 As Object)
        Dim Distance As Integer
        Distance = Math.Sqrt((unit1.unitLocX - unit2.unitLocX) ^ 2 + _
        (unit1.unitLocY - unit2.unitLocY) ^ 2)
        MessageBox.Show(unit2.unitID)
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
End Class
