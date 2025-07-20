Option Explicit On
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.Win32  ' RegistrySetting が同じプロジェクトにあれば不要

' Designer と同じグローバル名前空間に置く
Partial Class SetTimerForm
    Inherits Form

    '――― フィールド ―――
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

    ' レジストリ保存用クラス
    Private registryClass As New WaveFlat.SetTimer.RegistrySetting()

    ' Pause フラグ
    Private pauseFlag As Boolean

    '――― イベントハンドラ ―――

    ' フォームロード
    Private Sub SetTimerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        ' 前回保存値の復元例（型が合わないと例外になるので要検証）
        Me.CbHourWork.Text = registryClass.GetValue("HourWork", CInt(Me.CbHourWork.Text)).ToString()
        Me.CbMinWork.Text = registryClass.GetValue("MinWork", CInt(Me.CbMinWork.Text)).ToString()
        Me.CbSecWork.Text = registryClass.GetValue("SecWork", CInt(Me.CbSecWork.Text)).ToString()

        Call start()
    End Sub

    Private Sub start()
        Try
            Me.initialButtonColor = Me.CbStart.BackColor
            Me.CbStart.BackColor = Color.LightGreen

            initialWorkSeconds = CInt(CbHourWork.Text) * 3600 + CInt(CbMinWork.Text) * 60 + CInt(CbSecWork.Text)
            initialRestSeconds = CInt(CbHourRest.Text) * 3600 + CInt(CbMinRest.Text) * 60 + CInt(CbSecRest.Text)
            triggerSeconds = CInt(CbHourLast.Text) * 3600 + CInt(CbMinLast.Text) * 60 + CInt(CbSecLast.Text)

            If initialWorkSeconds <= 0 Then
                MessageBox.Show("0より大きい値を設定してください", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            isWorkPhase = True
            remainingWorkSeconds = initialWorkSeconds
            remainingRestSeconds = initialRestSeconds

            Me.TimerAll.Interval = 1000
            Me.TimerAll.Start()
            Debug.WriteLine("タイマー開始: Workフェーズ")

        Catch ex As Exception
            Debug.WriteLine("Start_Click例外: " & ex.Message)
        End Try
    End Sub

    ' Start ボタン
    Private Sub CbStart_Click(sender As Object, e As EventArgs) Handles CbStart.Click
        Try
            Call start()
        Catch ex As Exception
            Debug.WriteLine("Start_Click例外: " & ex.Message)
        End Try
    End Sub

    ' Tick 処理
    Private Sub TimerAll_Tick(sender As Object, e As EventArgs) Handles TimerAll.Tick
        Try
            If isWorkPhase Then
                If Not pauseFlag Then remainingWorkSeconds -= 1

                Dim tsW = TimeSpan.FromSeconds(remainingWorkSeconds)
                CbHourWork.Text = tsW.Hours.ToString()
                CbMinWork.Text = tsW.Minutes.ToString()
                CbSecWork.Text = tsW.Seconds.ToString()

                If remainingWorkSeconds = triggerSeconds AndAlso CbLastWork.Checked Then
                    My.Computer.Audio.Play(LbWavPathLast.Text, AudioPlayMode.WaitToComplete)
                End If

                If remainingWorkSeconds <= 0 Then
                    My.Computer.Audio.Play(LbWavPathWork.Text, AudioPlayMode.WaitToComplete)
                    isWorkPhase = False
                    remainingRestSeconds = initialRestSeconds
                End If

            Else
                If Not pauseFlag Then remainingRestSeconds -= 1

                Dim tsR = TimeSpan.FromSeconds(remainingRestSeconds)
                CbHourRest.Text = tsR.Hours.ToString()
                CbMinRest.Text = tsR.Minutes.ToString()
                CbSecRest.Text = tsR.Seconds.ToString()

                If remainingRestSeconds = triggerSeconds AndAlso CbLastRest.Checked Then
                    My.Computer.Audio.Play(LbWavPathLast.Text, AudioPlayMode.WaitToComplete)
                End If

                If remainingRestSeconds <= 0 Then
                    My.Computer.Audio.Play(LbWavPathRest.Text, AudioPlayMode.WaitToComplete)
                    isWorkPhase = True
                    remainingWorkSeconds = initialWorkSeconds
                End If
            End If

        Catch ex As Exception
            Debug.WriteLine("Tick例外: " & ex.Message)
        End Try
    End Sub

    ' Stop ボタン
    Private Sub CbStop_Click(sender As Object, e As EventArgs) Handles CbStop.Click
        Me.CbStart.BackColor = initialButtonColor
        Me.TimerAll.Stop()
        Debug.WriteLine("停止")
    End Sub

    ' Pause ボタン
    Private Sub CbPause_Click(sender As Object, e As EventArgs) Handles CbPause.Click
        pauseFlag = Not pauseFlag
        CbPause.BackColor = If(pauseFlag, Color.LightGreen, initialButtonColor)
    End Sub

    ' Close ボタン
    Private Sub CbClose_Click(sender As Object, e As EventArgs) Handles CbClose.Click
        Application.Exit()
    End Sub

    ' 値変更でレジストリ保存
    Private Sub CbHourWork_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbHourWork.SelectedIndexChanged
        registryClass.SaveValue("HourWork", CInt(CbHourWork.Text))
    End Sub

    Private Sub CbRestWav_Click(sender As Object, e As EventArgs) Handles CbRestWav.Click

        Try
            With OpenFileDialogRest
                .Filter = "WAV ファイル (*.wav)|*.wav"
                .InitialDirectory = "C:\Windows\Media\"
                .Title = "Rest フェーズで再生する WAV を選択"
                If .ShowDialog() = DialogResult.OK Then
                    LbWavPathRest.Text = .FileName
                    ' 必要ならレジストリに保存
                    registryClass.SaveValue("WavPathRest", .FileName)
                End If
            End With
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub

    ' キー押下イベント（KeyPreview=True のおかげでここに届く）
    Private Sub SetTimerForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                ' 全フォームを閉じてメッセージループを抜ける
                Application.Exit()
                ' あるいは Me.Close() でも OK（メインフォームならアプリ終了になります）
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CbSelectWavLast_Click(sender As Object, e As EventArgs) Handles CbSelectWavLast.Click
        Try
            With OpenFileDialogLast
                .Filter = "WAV ファイル (*.wav)|*.wav"
                .InitialDirectory = "C:\Windows\Media\"
                .Title = "Last フェーズで再生する WAV を選択"
                If .ShowDialog() = DialogResult.OK Then
                    LbWavPathLast.Text = .FileName
                    ' 必要ならレジストリに保存
                    registryClass.SaveValue("WavPathLast", .FileName)
                End If
            End With
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub CbWorkWav_Click(sender As Object, e As EventArgs) Handles CbWorkWav.Click
        Try
            With OpenFileDialogWork
                .Filter = "WAV ファイル (*.wav)|*.wav"
                .InitialDirectory = "C:\Windows\Media\"
                .Title = "Work フェーズで再生する WAV を選択"
                If .ShowDialog() = DialogResult.OK Then
                    LbWavPathWork.Text = .FileName
                    ' 必要ならレジストリに保存
                    registryClass.SaveValue("WavPathWork", .FileName)
                End If
            End With
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub
End Class