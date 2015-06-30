Public Class Engine
    Private loadGame As Char = "N"c 'This determines if a game should be loaded or not
    Private mageAmountP1 As Integer = 2
    Private mageAmountP2 As Integer = 2
    Private warriorAmountP1 As Integer = 2
    Private warriorAmountP2 As Integer = 2
    Private archerAmountP1 As Integer = 2
    Private archerAmountP2 As Integer = 2
    Public Const BLUE_MAGE As String = "Sprites\Mage Up Facing Blue.png"
    Public Const BLUE_WARRIOR As String = "Sprites\Warrior Up Facing Blue.png"
    Public Const BLUE_ARCHER As String = "Sprites\Archer Up Facing Blue.png"
    Public Const ORANGE_MAGE As String = "Sprites\Mage Down Facing Orange.png"
    Public Const ORANGE_WARRIOR As String = "Sprites\Warrior Down Facing Orange.png"
    Public Const ORANGE_ARCHER As String = "Sprites\Archer Down Facing Orange.png"





    'Getter and Setters Below
    Public Function getLoadGame() As Char
        Return loadGame
    End Function

    Public Function getMageAmountP1() As Integer
        Return mageAmountP1
    End Function
    Public Function getWarriorAmountP1() As Integer
        Return warriorAmountP1
    End Function
    Public Function getArcherAmountP1() As Integer
        Return archerAmountP1
    End Function

    Public Function getMageAmountP2() As Integer
        Return mageAmountP2
    End Function
    Public Function getWarriorAmountP2() As Integer
        Return warriorAmountP2
    End Function
    Public Function getArcherAmountP2() As Integer
        Return archerAmountP2
    End Function

    Public Sub setLoadGame(ByVal cLoadGame As Char)
        loadGame = cLoadGame
    End Sub

    Public Sub setMageAmountP1(ByVal mageAmount As Integer)
        mageAmountP1 = mageAmount
    End Sub
    Public Sub setWarriorAmountP1(ByVal warriorAmount As Integer)
        warriorAmountP1 = warriorAmount
    End Sub
    Public Sub setArcherAmountP1(ByVal archerAmount As Integer)
        archerAmountP1 = archerAmount
    End Sub

    Public Sub setMageAmountP2(ByVal mageAmount As Integer)
        mageAmountP2 = mageAmount
    End Sub
    Public Sub setWarriorAmountP2(ByVal warriorAmount As Integer)
        warriorAmountP2 = warriorAmount
    End Sub
    Public Sub setArcherAmountP2(ByVal archerAmount As Integer)
        archerAmountP2 = archerAmount
    End Sub
End Class
