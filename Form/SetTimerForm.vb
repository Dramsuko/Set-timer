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

    Private initialButtonColor As Color


    Private Sub CbClose_Click(sender As Object, e As EventArgs) Handles CbClose.Click
        Application.Exit()
    End Sub



    Private Sub CbStart_Click(sender As Object, e As EventArgs) Handles CbStart.Click
        Try
            initialButtonColor = Me.CbStart.BackColor
            Me.CbStart.BackColor = Color.LightGreen

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


            ' フェーズをWorkからスタート、残り時間を初期値でセット
            Me.isWorkPhase = True
            Me.remainingWorkSeconds = initialWorkSeconds
            Me.remainingRestSeconds = initialRestSeconds


            ' タイマー起動
            TimerAll.Interval = 1000
            AddHandler Me.TimerAll.Tick, AddressOf Me.TimerAll_Tick
            TimerAll.Start()
            Debug.WriteLine("タイマー開始: Workフェーズ")


        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try


    End Sub

    Private Sub TimerAll_Tick(sender As Object, e As EventArgs)
        Try

            If Me.isWorkPhase Then
                ' Work フェーズ
                Me.remainingWorkSeconds -= 1
                Dim tsW As TimeSpan = TimeSpan.FromSeconds(Me.remainingWorkSeconds)

                Me.CbHourWork.Text = tsW.Hours.ToString()
                Me.CbMinWork.Text = tsW.Minutes.ToString()
                Me.CbSecWork.Text = tsW.Seconds.ToString()

                If Me.remainingWorkSeconds = Me.triggerSeconds _
                        And CbLastWork.Checked Then
                    My.Computer.Audio.Play(Me.LbWavPathLast.Text, AudioPlayMode.WaitToComplete)
                    Debug.WriteLine("Workアラート: 残り " & Me.remainingWorkSeconds & "秒")
                End If

                If Me.remainingWorkSeconds <= 0 Then
                    My.Computer.Audio.Play(Me.LbWavPathWork.Text, AudioPlayMode.WaitToComplete)
                    Me.isWorkPhase = False
                    Me.remainingRestSeconds = Me.initialRestSeconds
                    Debug.WriteLine("Work終了 → Restフェーズへ")
                End If

            Else
                ' Rest フェーズ
                Me.remainingRestSeconds -= 1
                Dim tsR As TimeSpan = TimeSpan.FromSeconds(Me.remainingRestSeconds)

                Me.CbHourRest.Text = tsR.Hours.ToString()
                Me.CbMinRest.Text = tsR.Minutes.ToString()
                Me.CbSecRest.Text = tsR.Seconds.ToString()

                If Me.remainingRestSeconds = Me.triggerSeconds _
                        And CbLastRest.Checked Then
                    My.Computer.Audio.Play(Me.LbWavPathLast.Text, AudioPlayMode.WaitToComplete)
                    Debug.WriteLine("Restアラート: 残り " & Me.remainingRestSeconds & "秒")
                End If

                If Me.remainingRestSeconds <= 0 Then
                    My.Computer.Audio.Play(Me.LbWavPathRest.Text, AudioPlayMode.WaitToComplete)
                    Me.isWorkPhase = True
                    Me.remainingWorkSeconds = Me.initialWorkSeconds
                    Debug.WriteLine("Rest終了 → Workフェーズへ")
                End If
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CbStop_Click(sender As Object, e As EventArgs) Handles CbStop.Click
        Try
            Me.CbStart.BackColor = initialButtonColor
            Me.TimerAll.Stop()
            Debug.WriteLine("終了:StopButton")
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try


    End Sub

    Private Sub CbSelectWavLast_Click(sender As Object, e As EventArgs) Handles CbSelectWavLast.Click

        Try
            If Me.OpenFileDialogLast.ShowDialog() = DialogResult.OK Then
                Me.LbWavPathLast.Text = OpenFileDialogLast.FileName
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' フォームがキーイベントを先に受け取るようにする
            Me.KeyPreview = True
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                ' アプリケーションを終了
                Application.Exit()
                ' または Me.Close() でもOK
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub


End Class
