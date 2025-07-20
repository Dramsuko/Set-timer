Option Explicit On
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports WaveFlat.SetTimer    ' ルートNamespaceが WaveFlat.SetTimer なら

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

    ' ボタン色、初期値
    Private initialButtonColor As Color

    ' レジストリクラスのインスタンス化
    Private registryClass As New RegistrySetting()

    ' Pauseフラグ
    Private pauseFlag As Boolean

    Private Sub SetTimerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        ' 前回設定の読み込み例
        Me.CbHourWork.Text = Me.registryClass.GetValue("HourWork", 0).ToString()
        ' …他のコントロールも同様に初期値復元可能…
    End Sub

    Private Sub CbStart_Click(sender As Object, e As EventArgs) Handles CbStart.Click
        Try
            Me.initialButtonColor = Me.CbStart.BackColor
            Me.CbStart.BackColor = Color.LightGreen

            Me.initialWorkSeconds = CInt(Me.CbHourWork.Text) * 3600 + CInt(Me.CbMinWork.Text) * 60 + CInt(Me.CbSecWork.Text)
            Me.initialRestSeconds = CInt(Me.CbHourRest.Text) * 3600 + CInt(Me.CbMinRest.Text) * 60 + CInt(Me.CbSecRest.Text)
            Me.triggerSeconds = CInt(Me.CbHourLast.Text) * 3600 + CInt(Me.CbMinLast.Text) * 60 + CInt(Me.CbSecLast.Text)

            If Me.initialWorkSeconds <= 0 Then
                MessageBox.Show("0より多くの値を入力してください", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Me.isWorkPhase = True
            Me.remainingWorkSeconds = Me.initialWorkSeconds
            Me.remainingRestSeconds = Me.initialRestSeconds

            Me.TimerAll.Interval = 1000
            Me.TimerAll.Start()
            Debug.WriteLine("タイマー開始: Workフェーズ")

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub TimerAll_Tick(sender As Object, e As EventArgs) Handles TimerAll.Tick
        Try
            If Me.isWorkPhase Then
                If Not Me.pauseFlag Then Me.remainingWorkSeconds -= 1
                Dim tsW = TimeSpan.FromSeconds(Me.remainingWorkSeconds)

                Me.CbHourWork.Text = tsW.Hours.ToString()
                Me.CbMinWork.Text = tsW.Minutes.ToString()
                Me.CbSecWork.Text = tsW.Seconds.ToString()

                If Me.remainingWorkSeconds = Me.triggerSeconds AndAlso Me.CbLastWork.Checked Then
                    My.Computer.Audio.Play(Me.LbWavPathLast.Text, AudioPlayMode.WaitToComplete)
                End If

                If Me.remainingWorkSeconds <= 0 Then
                    My.Computer.Audio.Play(Me.LbWavPathWork.Text, AudioPlayMode.WaitToComplete)
                    Me.isWorkPhase = False
                    Me.remainingRestSeconds = Me.initialRestSeconds
                End If

            Else
                If Not Me.pauseFlag Then Me.remainingRestSeconds -= 1
                Dim tsR = TimeSpan.FromSeconds(Me.remainingRestSeconds)

                Me.CbHourRest.Text = tsR.Hours.ToString()
                Me.CbMinRest.Text = tsR.Minutes.ToString()
                Me.CbSecRest.Text = tsR.Seconds.ToString()

                If Me.remainingRestSeconds = Me.triggerSeconds AndAlso Me.CbLastRest.Checked Then
                    My.Computer.Audio.Play(Me.LbWavPathLast.Text, AudioPlayMode.WaitToComplete)
                End If

                If Me.remainingRestSeconds <= 0 Then
                    My.Computer.Audio.Play(Me.LbWavPathRest.Text, AudioPlayMode.WaitToComplete)
                    Me.isWorkPhase = True
                    Me.remainingWorkSeconds = Me.initialWorkSeconds
                End If
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CbStop_Click(sender As Object, e As EventArgs) Handles CbStop.Click
        Me.CbStart.BackColor = Me.initialButtonColor
        Me.TimerAll.Stop()
        Debug.WriteLine("終了: Stop")
    End Sub

    Private Sub CbPause_Click(sender As Object, e As EventArgs) Handles CbPause.Click
        Me.pauseFlag = Not Me.pauseFlag
        Me.CbPause.BackColor = If(Me.pauseFlag, Color.LightGreen, Me.initialButtonColor)
    End Sub

    Private Sub CbClose_Click(sender As Object, e As EventArgs) Handles CbClose.Click
        Application.Exit()
    End Sub

    Private Sub CbHourWork_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbHourWork.SelectedIndexChanged
        Me.registryClass.SaveValue("HourWork", CInt(Me.CbHourWork.Text))
    End Sub

    ' …必要に応じて他イベントハンドラも同様に実装…
End Class