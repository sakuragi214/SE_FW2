Public Class test
    Private Sub test_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            File_Number_List.Show()
            MsgBox("Help")
        End If
    End Sub

    Private Sub test_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class