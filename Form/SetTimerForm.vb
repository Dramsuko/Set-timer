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

    Private Const REGISTRY_HOUR_WORK As String = "HourWork"
    Private Const REGISTRY_MIN_WORK As String = "MinWork"
    Private Const REGISTRY_SEC_WORK As String = "SecWork"

    Private Const REGISTRY_HOUR_REST As String = "HourRest"
    Private Const REGISTRY_MIN_REST As String = "MinRest"
    Private Const REGISTRY_SEC_REST As String = "SecRest"

    Private Const REGISTRY_HOUR_LAST As String = "HourLast"
    Private Const REGISTRY_MIN_LAST As String = "MinLast"
    Private Const REGISTRY_SEC_LAST As String = "SecLast"


    Private Const REGISTRY_CHECK_WORK As String = "CheckWork"
    Private Const REGISTRY_CHECK_REST As String = "CheckRest"

    Private Const REGISTRY_WAV_PATH_WORK As String = "WavPathWork"
    Private Const REGISTRY_WAV_PATH_REST As String = "WavPathRest"
    Private Const REGISTRY_WAV_PATH_LAST As String = "WavPathLast"

    Private Const REGISTRY_SOUND_FLAG_WORK As String = "SoundFlagWork"
    Private Const REGISTRY_SOUND_FLAG_REST As String = "SoundFlagRest"
    Private Const REGISTRY_SOUND_FLAG_LAST As String = "SoundFlagLast"

    Private Const REGISTRY_MSGBOX_FLAG_WORK As String = "MsgBoxFlagWork"
    Private Const REGISTRY_MSGBOX_FLAG_REST As String = "MsgBoxFlagRest"
    Private Const REGISTRY_MSGBOX_FLAG_LAST As String = "MsgBoxFlagLast"

    '――― イベントハンドラ ―――

    ' フォームロード
    Private Sub SetTimerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        ' 前回保存値の復元例（型が合わないと例外になるので要検証）
        Call Me.SetRegistry()

        Call start()
    End Sub

    Private Sub SetRegistry()
        Try

            ' Work 時間（タイマー停止時のみ読み込み）
            If registryClass.ExistsValue(REGISTRY_HOUR_WORK) And Me.TimerAll.Enabled = False Then
                CbHourWork.Text = registryClass.GetValue(REGISTRY_HOUR_WORK, 0).ToString()
            Else
                CbHourWork.Text = "0"
            End If

            If registryClass.ExistsValue(REGISTRY_MIN_WORK) And Me.TimerAll.Enabled = False Then
                CbMinWork.Text = registryClass.GetValue(REGISTRY_MIN_WORK, 0).ToString()
            Else
                CbMinWork.Text = "0"
            End If

            If registryClass.ExistsValue(REGISTRY_SEC_WORK) And Me.TimerAll.Enabled = False Then
                CbSecWork.Text = registryClass.GetValue(REGISTRY_SEC_WORK, 0).ToString()
            Else
                CbSecWork.Text = "0"
            End If



            ' Rest 時間（タイマー停止時のみ読み込み）
            If registryClass.ExistsValue(REGISTRY_HOUR_REST) And Me.TimerAll.Enabled = False Then
                CbHourRest.Text = registryClass.GetValue(REGISTRY_HOUR_REST, 0).ToString()
            Else
                CbHourRest.Text = "0"
            End If

            If registryClass.ExistsValue(REGISTRY_MIN_REST) And Me.TimerAll.Enabled = False Then
                CbMinRest.Text = registryClass.GetValue(REGISTRY_MIN_REST, 0).ToString()
            Else
                CbMinRest.Text = "0"
            End If

            If registryClass.ExistsValue(REGISTRY_SEC_REST) And Me.TimerAll.Enabled = False Then
                CbSecRest.Text = registryClass.GetValue(REGISTRY_SEC_REST, 0).ToString()
            Else
                CbSecRest.Text = "0"
            End If



            ' Last 時間（タイマー停止時のみ読み込み）
            If registryClass.ExistsValue(REGISTRY_HOUR_LAST) And Me.TimerAll.Enabled = False Then
                CbHourLast.Text = registryClass.GetValue(REGISTRY_HOUR_LAST, 0).ToString()
            Else
                CbHourLast.Text = "0"
            End If

            If registryClass.ExistsValue(REGISTRY_MIN_LAST) And Me.TimerAll.Enabled = False Then
                CbMinLast.Text = registryClass.GetValue(REGISTRY_MIN_LAST, 0).ToString()
            Else
                CbMinLast.Text = "0"
            End If

            If registryClass.ExistsValue(REGISTRY_SEC_LAST) And Me.TimerAll.Enabled = False Then
                CbSecLast.Text = registryClass.GetValue(REGISTRY_SEC_LAST, 0).ToString()
            Else
                CbSecLast.Text = "0"
            End If



            ' チェックボックス（タイマー状態に関係なく読み込み）
            If registryClass.ExistsValue(REGISTRY_CHECK_WORK) Then
                CbLastWork.Checked = registryClass.GetValue(REGISTRY_CHECK_WORK, False)
            End If

            If registryClass.ExistsValue(REGISTRY_CHECK_REST) Then
                CbLastRest.Checked = registryClass.GetValue(REGISTRY_CHECK_REST, False)
            End If



            ' WAVパス（タイマー状態に関係なく読み込み）
            If registryClass.ExistsValue(REGISTRY_WAV_PATH_WORK) Then
                LbWavPathWork.Text = registryClass.GetValue(REGISTRY_WAV_PATH_WORK, "C:\Windows\Media\chimes.wav")
            End If

            If registryClass.ExistsValue(REGISTRY_WAV_PATH_REST) Then
                LbWavPathRest.Text = registryClass.GetValue(REGISTRY_WAV_PATH_REST, "C:\Windows\Media\chimes.wav")
            End If

            If registryClass.ExistsValue(REGISTRY_WAV_PATH_LAST) Then
                LbWavPathLast.Text = registryClass.GetValue(REGISTRY_WAV_PATH_LAST, "C:\Windows\Media\chimes.wav")
            End If

            ' Sound チェックボックス（Work/Rest/Last）
            If registryClass.ExistsValue(REGISTRY_SOUND_FLAG_WORK) Then
                CbSoundWork.Checked = registryClass.GetValue(REGISTRY_SOUND_FLAG_WORK, True)
            End If

            If registryClass.ExistsValue(REGISTRY_SOUND_FLAG_REST) Then
                CbSoundRest.Checked = registryClass.GetValue(REGISTRY_SOUND_FLAG_REST, True)
            End If

            If registryClass.ExistsValue(REGISTRY_SOUND_FLAG_LAST) Then
                CbSoundLast.Checked = registryClass.GetValue(REGISTRY_SOUND_FLAG_LAST, True)
            End If

            ' MsgBox チェックボックス（Work/Rest/Last）
            If registryClass.ExistsValue(REGISTRY_MSGBOX_FLAG_WORK) Then
                CbMsgBoxWork.Checked = registryClass.GetValue(REGISTRY_MSGBOX_FLAG_WORK, False)
            End If

            If registryClass.ExistsValue(REGISTRY_MSGBOX_FLAG_REST) Then
                CbMsgBoxRest.Checked = registryClass.GetValue(REGISTRY_MSGBOX_FLAG_REST, False)
            End If

            If registryClass.ExistsValue(REGISTRY_MSGBOX_FLAG_LAST) Then
                CbMsgBoxLast.Checked = registryClass.GetValue(REGISTRY_MSGBOX_FLAG_LAST, False)
            End If

        Catch ex As Exception
            Debug.WriteLine("SetRegistry例外: " & ex.Message)
        End Try
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
                    If CbSoundWork.Checked Then
                        My.Computer.Audio.Play(LbWavPathWork.Text, AudioPlayMode.WaitToComplete)
                    End If
                    If CbMsgBoxWork.Checked Then
                        MessageBox.Show("Work フェーズの残り時間が " & CbHourLast.Text & ":" & CbMinLast.Text & ":" & CbSecLast.Text & " です。", "Work Phase Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

                If remainingWorkSeconds = 0 Then
                    If CbSoundWork.Checked Then
                        My.Computer.Audio.Play(LbWavPathRest.Text, AudioPlayMode.WaitToComplete)
                    End If
                    If CbMsgBoxWork.Checked Then
                        MessageBox.Show("Work フェーズが終了しました。", "Work Phase Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    isWorkPhase = False
                    remainingWorkSeconds = initialWorkSeconds
                    remainingRestSeconds = initialRestSeconds

                    Dim tsWFinished = TimeSpan.FromSeconds(remainingWorkSeconds)
                    CbHourWork.Text = tsWFinished.Hours.ToString()
                    CbMinWork.Text = tsWFinished.Minutes.ToString()
                    CbSecWork.Text = tsWFinished.Seconds.ToString()
                End If

            Else
                If Not pauseFlag Then remainingRestSeconds -= 1

                Dim tsR = TimeSpan.FromSeconds(remainingRestSeconds)
                CbHourRest.Text = tsR.Hours.ToString()
                CbMinRest.Text = tsR.Minutes.ToString()
                CbSecRest.Text = tsR.Seconds.ToString()

                If remainingRestSeconds = triggerSeconds AndAlso CbLastRest.Checked Then
                    If CbSoundRest.Checked Then
                        My.Computer.Audio.Play(LbWavPathRest.Text, AudioPlayMode.WaitToComplete)
                    End If
                    If CbMsgBoxRest.Checked Then
                        MessageBox.Show("Rest フェーズの残り時間が " & CbHourLast.Text & ":" & CbMinLast.Text & ":" & CbSecLast.Text & " です。", "Rest Phase Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

                If remainingRestSeconds = 0 Then
                    If CbSoundRest.Checked Then
                        My.Computer.Audio.Play(LbWavPathLast.Text, AudioPlayMode.WaitToComplete)
                    End If
                    If CbMsgBoxRest.Checked Then
                        MessageBox.Show("Rest フェーズが終了しました。", "Rest Phase Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    isWorkPhase = True
                    remainingWorkSeconds = initialWorkSeconds
                    remainingRestSeconds = initialRestSeconds

                    Dim tsRFinished = TimeSpan.FromSeconds(remainingRestSeconds)
                    CbHourRest.Text = tsRFinished.Hours.ToString()
                    CbMinRest.Text = tsRFinished.Minutes.ToString()
                    CbSecRest.Text = tsRFinished.Seconds.ToString()
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

        remainingWorkSeconds = initialWorkSeconds
        Dim tsW = TimeSpan.FromSeconds(remainingWorkSeconds)
        CbHourWork.Text = tsW.Hours.ToString()
        CbMinWork.Text = tsW.Minutes.ToString()
        CbSecWork.Text = tsW.Seconds.ToString()


        remainingRestSeconds = initialRestSeconds
        Dim tsR = TimeSpan.FromSeconds(remainingRestSeconds)
        CbHourRest.Text = tsR.Hours.ToString()
        CbMinRest.Text = tsR.Minutes.ToString()
        CbSecRest.Text = tsR.Seconds.ToString()


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



    Private Sub CbWorkWav_Click(sender As Object, e As EventArgs) Handles CbWorkWav.Click
        Try
            With OpenFileDialogWork
                .Filter = "WAV ファイル (*.wav)|*.wav"
                .InitialDirectory = "C:\Windows\Media\"
                .Title = "Work フェーズで再生する WAV を選択"
                If .ShowDialog() = DialogResult.OK Then
                    LbWavPathWork.Text = .FileName
                    ' 必要ならレジストリに保存
                    registryClass.SaveValue(REGISTRY_WAV_PATH_WORK, .FileName)
                End If
            End With
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

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
                    registryClass.SaveValue(REGISTRY_WAV_PATH_REST, .FileName)
                End If
            End With
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
                    registryClass.SaveValue(REGISTRY_WAV_PATH_LAST, .FileName)
                End If
            End With
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub




    ' 値変更でレジストリ保存
    ' Work 時間（タイマー停止時のみ保存）
    Private Sub CbHourWork_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbHourWork.SelectedIndexChanged
        Try
            If Me.TimerAll.Enabled = False Then
                registryClass.SaveValue(REGISTRY_HOUR_WORK, CInt(CbHourWork.Text))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CbMinWork_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbMinWork.SelectedIndexChanged
        Try
            If Me.TimerAll.Enabled = False Then
                registryClass.SaveValue(REGISTRY_MIN_WORK, CInt(CbMinWork.Text))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CbSecWork_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbSecWork.SelectedIndexChanged
        Try
            If Me.TimerAll.Enabled = False Then
                registryClass.SaveValue(REGISTRY_SEC_WORK, CInt(CbSecWork.Text))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    ' Rest 時間（タイマー停止時のみ保存）
    Private Sub CbHourRest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbHourRest.SelectedIndexChanged
        Try
            If Me.TimerAll.Enabled = False Then
                registryClass.SaveValue(REGISTRY_HOUR_REST, CInt(CbHourRest.Text))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CbMinRest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbMinRest.SelectedIndexChanged
        Try
            If Me.TimerAll.Enabled = False Then
                registryClass.SaveValue(REGISTRY_MIN_REST, CInt(CbMinRest.Text))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CbSecRest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbSecRest.SelectedIndexChanged
        Try
            If Me.TimerAll.Enabled = False Then
                registryClass.SaveValue(REGISTRY_SEC_REST, CInt(CbSecRest.Text))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    ' Last 時間（タイマー停止時のみ保存）
    Private Sub CbHourLast_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbHourLast.SelectedIndexChanged
        Try
            If Me.TimerAll.Enabled = False Then
                registryClass.SaveValue(REGISTRY_HOUR_LAST, CInt(CbHourLast.Text))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CbMinLast_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbMinLast.SelectedIndexChanged
        Try
            If Me.TimerAll.Enabled = False Then
                registryClass.SaveValue(REGISTRY_MIN_LAST, CInt(CbMinLast.Text))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CbSecLast_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbSecLast.SelectedIndexChanged
        Try
            If Me.TimerAll.Enabled = False Then
                registryClass.SaveValue(REGISTRY_SEC_LAST, CInt(CbSecLast.Text))
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub


    Private Sub CbTestWork_Click(sender As Object, e As EventArgs) Handles CbTestWork.Click

        My.Computer.Audio.Play(LbWavPathWork.Text, AudioPlayMode.WaitToComplete)

    End Sub

    Private Sub CbTestRest_Click(sender As Object, e As EventArgs) Handles CbTestRest.Click

        My.Computer.Audio.Play(LbWavPathRest.Text, AudioPlayMode.WaitToComplete)

    End Sub

    Private Sub CbTestLast_Click(sender As Object, e As EventArgs) Handles CbTestLast.Click

        My.Computer.Audio.Play(LbWavPathLast.Text, AudioPlayMode.WaitToComplete)

    End Sub

    Private Sub CbSoundWork_Click(sender As Object, e As EventArgs) Handles CbSoundWork.Click
        registryClass.SaveValue(REGISTRY_SOUND_FLAG_WORK, CbSoundWork.Checked)
    End Sub

    Private Sub CbSoundLast_Click(sender As Object, e As EventArgs) Handles CbSoundLast.Click
        registryClass.SaveValue(REGISTRY_SOUND_FLAG_LAST, CbSoundLast.Checked)
    End Sub

    Private Sub CbSoundRest_Click(sender As Object, e As EventArgs) Handles CbSoundRest.Click
        registryClass.SaveValue(REGISTRY_SOUND_FLAG_REST, CbSoundRest.Checked)
    End Sub

    Private Sub CbMsgBoxWork_Click(sender As Object, e As EventArgs) Handles CbMsgBoxWork.Click
        registryClass.SaveValue(REGISTRY_MSGBOX_FLAG_WORK, CbMsgBoxWork.Checked)
    End Sub

    Private Sub CbMsgBoxRest_Click(sender As Object, e As EventArgs) Handles CbMsgBoxRest.Click
        registryClass.SaveValue(REGISTRY_MSGBOX_FLAG_REST, CbMsgBoxRest.Checked)
    End Sub

    Private Sub CbMsgBoxLast_Click(sender As Object, e As EventArgs) Handles CbMsgBoxLast.Click
        registryClass.SaveValue(REGISTRY_MSGBOX_FLAG_LAST, CbMsgBoxLast.Checked)
    End Sub

    ' チェックボックス（タイマー状態に関係なく保存）
    Private Sub CbLastWork_Click(sender As Object, e As EventArgs) Handles CbLastWork.Click
        registryClass.SaveValue(REGISTRY_CHECK_WORK, CbLastWork.Checked)
    End Sub

    Private Sub CbLastRest_Click(sender As Object, e As EventArgs) Handles CbLastRest.CheckedChanged
        registryClass.SaveValue(REGISTRY_CHECK_REST, CbLastRest.Checked)
    End Sub

End Class