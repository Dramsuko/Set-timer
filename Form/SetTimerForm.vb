Public Class SetTimerForm

    Private remainingSecondsWork As Integer = 0
    'Private remainingSecondsRestk As Integer = 0
    'Private remainingSecondsLast As Integer = 0
    Private remainingSecondsAll As Integer = 0


    Private Sub CbClose_Click(sender As Object, e As EventArgs) Handles CbClose.Click
        Application.Exit()
    End Sub



    Private Sub CbStart_Click(sender As Object, e As EventArgs) Handles CbStart.Click
        Try

            Dim timerValueSec As Integer = CInt(Me.CbHourWork.Text * 3600 + Me.CbMinWork.Text * 60 + Me.CbSecWork.Text)
            If timerValueSec <= 0 Then
                MessageBox.Show("0以上を入力して下さい", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Me.TimerAll.Interval = 1000 ' 1秒ごとに発火
            remainingSecondsWork = timerValueSec * 1000
            'remainingSecondsAll = timerValueSec * 1000 - ((CInt(Me.CbLastHour.Text) + CInt(Me.CbLastMin.Text) + CInt(Me.CbLastSec.Text)) * 1000)
            AddHandler Me.TimerAll.Tick, AddressOf TimerAll_Tick

            Me.TimerAll.Start()
            Debug.WriteLine("Start")

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try


    End Sub

    Private Sub TimerAll_Tick(sender As Object, e As EventArgs)
        Try
            ' ここに繰り返したい処理を書く
            remainingSecondsWork -= 1 * 1000
            Debug.WriteLine("残りWork " & remainingSecondsWork & "秒")

            If remainingSecondsWork <= (CInt(Me.CbLastHour.Text) * 3600 + CInt(Me.CbLastMin.Text) * 60 + CInt(Me.CbLastSec.Text)) * 1000 Then
                'MessageBox.Show("残り5秒です！")
                'My.Computer.Audio.Play("C:\Sounds\alert.wav", AudioPlayMode.WaitToComplete)
                Debug.WriteLine("残りWorkLast " & remainingSecondsWork & "秒")
            End If

            If remainingSecondsWork <= 0 Then
                Me.TimerAll.Stop()
                Debug.WriteLine("終了")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CbStop_Click(sender As Object, e As EventArgs) Handles CbStop.Click
        Try
            Me.TimerAll.Stop()
            Debug.WriteLine("終了:StopButton")
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try


    End Sub

    Private Sub CbSelectWavLast_Click(sender As Object, e As EventArgs) Handles CbSelectWavLast.Click

        Try

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try


    End Sub
End Class
