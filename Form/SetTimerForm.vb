Public Class SetTimerForm




    Private Sub CbClose_Click(sender As Object, e As EventArgs) Handles CbClose.Click
        Application.Exit()
    End Sub



    Private Sub CbStart_Click(sender As Object, e As EventArgs) Handles CbStart.Click
        Try

        Catch ex As Exception
            Print(ex.Message)
        End Try


    End Sub




End Class
