Public Class History
    Private Sub txtFileNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFileNo.KeyDown
        If e.KeyCode = Keys.F3 Then
            File_Number_List.Show()

        End If
    End Sub

    Private Sub txtFileNo_MouseClick(sender As Object, e As MouseEventArgs) Handles txtFileNo.MouseClick
        txtFileNo.Text = ""
    End Sub
End Class