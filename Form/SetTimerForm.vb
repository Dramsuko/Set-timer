Option Explicit On

Imports System.Security.Cryptography

Public Class SetTimerForm

    ' フェーズ制御
    Private isWorkPhase As Boolean = True

    ' 初期値保持用
    Private initialWorkSeconds As Integer
    Private initialRestSeconds As Integer

    ' 残り時間
    Private remainingWorkSeconds As Integer
    Private remainingRestSeconds As Integer

    ' アラート閾値（秒）
    Private triggerSeconds As Integer


    Private Sub CbClose_Click(sender As Object, e As EventArgs) Handles CbClose.Click
        Application.Exit()
    End Sub



    Private Sub CbStart_Click(sender As Object, e As EventArgs) Handles CbStart.Click
        Try
            ' 入力から秒数を算出して初期値＆残り時間へセット
            Me.initialWorkSeconds = CInt(CbHourWork.Text) * 3600 _
                           + CInt(CbMinWork.Text) * 60 _
                           + CInt(CbSecWork.Text)

            Me.initialRestSeconds = CInt(CbHourRest.Text) * 3600 _
                           + CInt(CbMinRest.Text) * 60 _
                           + CInt(CbSecRest.Text)

            Me.triggerSeconds = CInt(CbHourLast.Text) * 3600 _
                       + CInt(CbMinLast.Text) * 60 _
                       + CInt(CbSecLast.Text)

            If Me.initialWorkSeconds <= 0 Then
                MessageBox.Show("0より多くの値を入力して下さい", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Me.TimerAll.Interval = 1000 ' 1秒ごとに発火
            AddHandler Me.TimerAll.Tick, AddressOf TimerAll_Tick

            Me.TimerAll.Start()
            Debug.WriteLine("Start")

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try


    End Sub

    Private Sub TimerAll_Tick(sender As Object, e As EventArgs)
        Try

            remainingSecondsWork -= 1


            ' TimeSpan で時・分・秒を取得
            Dim ts As TimeSpan = TimeSpan.FromSeconds(remainingSecondsWork)

            ' 各コントロールにセット
            CbHourWork.Text = ts.Hours.ToString()
            CbMinWork.Text = ts.Minutes.ToString()
            CbSecWork.Text = ts.Seconds.ToString()



            Dim triggerSeconds As Integer = CInt(Me.CbHourLast.Text) * 3600 _
                               + CInt(Me.CbMinLast.Text) * 60 _
                               + CInt(Me.CbSecLast.Text)

            If remainingSecondsWork = triggerSeconds Then
                My.Computer.Audio.Play(Me.LbWavPathRest.Text, AudioPlayMode.WaitToComplete)
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
            If Me.OpenFileDialogLast.ShowDialog() = DialogResult.OK Then
                Me.LbPathLast.Text = OpenFileDialogLast.FileName
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try


    End Sub
End Class
