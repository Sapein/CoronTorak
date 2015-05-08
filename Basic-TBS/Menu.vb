Public Class Menu

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim NewForm = New Form1
        NewForm.Show()
        Me.Close()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim NewForm = New Form1
        NewForm.Show()
        loadInformation()
    End Sub

    Public Sub loadInformation()
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(My.Application.Info.DirectoryPath & "../../../saves/Corontorak-save.txt")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    Dim i As Integer = 0
                    For Each currentField In currentRow
                        MessageBox.Show(currentField)
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                End Try
            End While
        End Using
    End Sub
End Class