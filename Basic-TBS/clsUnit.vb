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

    Public Sub destoryUnit()
        Dim destroyedUnit As Integer
        destroyedUnit = Form1.getDefendingUnit()
        Dim con As Control

        For controlIndex As Integer = Form1.Controls.Count - 1 To 0 Step -1
            con = Form1.Controls(controlIndex)
            If con.Name = Form1.unitList(destroyedUnit).unitAssignedPicBox Then
                Form1.Controls.Remove(con)
            End If
        Next
    End Sub

    Public Sub updateUnit()

    End Sub

    Public Sub unitGetLocation()

    End Sub
End Class
