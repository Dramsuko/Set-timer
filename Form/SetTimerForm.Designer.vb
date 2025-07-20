<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SetTimerForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LbWorkTitle = New System.Windows.Forms.Label()
        Me.LbRestTitle = New System.Windows.Forms.Label()
        Me.CbHourWork = New System.Windows.Forms.ComboBox()
        Me.CbHourRest = New System.Windows.Forms.ComboBox()
        Me.LbHourTitle = New System.Windows.Forms.Label()
        Me.CbMinWork = New System.Windows.Forms.ComboBox()
        Me.CbMinRest = New System.Windows.Forms.ComboBox()
        Me.CbSecWork = New System.Windows.Forms.ComboBox()
        Me.CbSecRest = New System.Windows.Forms.ComboBox()
        Me.LbMinTitle = New System.Windows.Forms.Label()
        Me.LbSecTitle = New System.Windows.Forms.Label()
        Me.CbStart = New System.Windows.Forms.Button()
        Me.CbStop = New System.Windows.Forms.Button()
        Me.CbClose = New System.Windows.Forms.Button()
        Me.CbWorkWav = New System.Windows.Forms.Button()
        Me.CbRestWav = New System.Windows.Forms.Button()
        Me.LbWavPathWork = New System.Windows.Forms.Label()
        Me.LbWavPathRest = New System.Windows.Forms.Label()
        Me.TimerAll = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRest = New System.Windows.Forms.Timer(Me.components)
        Me.TimerWork = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialogLast = New System.Windows.Forms.OpenFileDialog()
        Me.CbSecLast = New System.Windows.Forms.ComboBox()
        Me.CbMinLast = New System.Windows.Forms.ComboBox()
        Me.CbHourLast = New System.Windows.Forms.ComboBox()
        Me.LbLast = New System.Windows.Forms.Label()
        Me.CbLastWork = New System.Windows.Forms.CheckBox()
        Me.CbLastRest = New System.Windows.Forms.CheckBox()
        Me.CbSelectWavLast = New System.Windows.Forms.Button()
        Me.LbWavPathLast = New System.Windows.Forms.Label()
        Me.CbPause = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialogWork = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialogRest = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'LbWorkTitle
        '
        Me.LbWorkTitle.AutoSize = True
        Me.LbWorkTitle.Location = New System.Drawing.Point(12, 30)
        Me.LbWorkTitle.Name = "LbWorkTitle"
        Me.LbWorkTitle.Size = New System.Drawing.Size(35, 15)
        Me.LbWorkTitle.TabIndex = 0
        Me.LbWorkTitle.Text = "Work"
        '
        'LbRestTitle
        '
        Me.LbRestTitle.AutoSize = True
        Me.LbRestTitle.Location = New System.Drawing.Point(12, 59)
        Me.LbRestTitle.Name = "LbRestTitle"
        Me.LbRestTitle.Size = New System.Drawing.Size(29, 15)
        Me.LbRestTitle.TabIndex = 1
        Me.LbRestTitle.Text = "Rest"
        '
        'CbHourWork
        '
        Me.CbHourWork.FormattingEnabled = True
        Me.CbHourWork.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.CbHourWork.Location = New System.Drawing.Point(53, 27)
        Me.CbHourWork.Name = "CbHourWork"
        Me.CbHourWork.Size = New System.Drawing.Size(62, 23)
        Me.CbHourWork.TabIndex = 110
        Me.CbHourWork.Text = "0"
        '
        'CbHourRest
        '
        Me.CbHourRest.FormattingEnabled = True
        Me.CbHourRest.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.CbHourRest.Location = New System.Drawing.Point(53, 56)
        Me.CbHourRest.Name = "CbHourRest"
        Me.CbHourRest.Size = New System.Drawing.Size(62, 23)
        Me.CbHourRest.TabIndex = 150
        Me.CbHourRest.Text = "0"
        '
        'LbHourTitle
        '
        Me.LbHourTitle.AutoSize = True
        Me.LbHourTitle.Location = New System.Drawing.Point(63, 9)
        Me.LbHourTitle.Name = "LbHourTitle"
        Me.LbHourTitle.Size = New System.Drawing.Size(34, 15)
        Me.LbHourTitle.TabIndex = 4
        Me.LbHourTitle.Text = "Hour"
        '
        'CbMinWork
        '
        Me.CbMinWork.FormattingEnabled = True
        Me.CbMinWork.Items.AddRange(New Object() {"00", "01", "02", "...", "59"})
        Me.CbMinWork.Location = New System.Drawing.Point(121, 27)
        Me.CbMinWork.Name = "CbMinWork"
        Me.CbMinWork.Size = New System.Drawing.Size(62, 23)
        Me.CbMinWork.TabIndex = 120
        Me.CbMinWork.Text = "20"
        '
        'CbMinRest
        '
        Me.CbMinRest.FormattingEnabled = True
        Me.CbMinRest.Items.AddRange(New Object() {"01", "02", "...", "59"})
        Me.CbMinRest.Location = New System.Drawing.Point(121, 56)
        Me.CbMinRest.Name = "CbMinRest"
        Me.CbMinRest.Size = New System.Drawing.Size(62, 23)
        Me.CbMinRest.TabIndex = 160
        Me.CbMinRest.Text = "0"
        '
        'CbSecWork
        '
        Me.CbSecWork.FormattingEnabled = True
        Me.CbSecWork.Items.AddRange(New Object() {"0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.CbSecWork.Location = New System.Drawing.Point(189, 27)
        Me.CbSecWork.Name = "CbSecWork"
        Me.CbSecWork.Size = New System.Drawing.Size(62, 23)
        Me.CbSecWork.TabIndex = 130
        Me.CbSecWork.Text = "0"
        '
        'CbSecRest
        '
        Me.CbSecRest.FormattingEnabled = True
        Me.CbSecRest.Items.AddRange(New Object() {"0", "5", "10", "...", "55"})
        Me.CbSecRest.Location = New System.Drawing.Point(189, 56)
        Me.CbSecRest.Name = "CbSecRest"
        Me.CbSecRest.Size = New System.Drawing.Size(62, 23)
        Me.CbSecRest.TabIndex = 170
        Me.CbSecRest.Text = "30"
        '
        'LbMinTitle
        '
        Me.LbMinTitle.AutoSize = True
        Me.LbMinTitle.Location = New System.Drawing.Point(137, 9)
        Me.LbMinTitle.Name = "LbMinTitle"
        Me.LbMinTitle.Size = New System.Drawing.Size(28, 15)
        Me.LbMinTitle.TabIndex = 9
        Me.LbMinTitle.Text = "Min"
        '
        'LbSecTitle
        '
        Me.LbSecTitle.AutoSize = True
        Me.LbSecTitle.Location = New System.Drawing.Point(204, 9)
        Me.LbSecTitle.Name = "LbSecTitle"
        Me.LbSecTitle.Size = New System.Drawing.Size(25, 15)
        Me.LbSecTitle.TabIndex = 10
        Me.LbSecTitle.Text = "Sec"
        '
        'CbStart
        '
        Me.CbStart.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CbStart.Location = New System.Drawing.Point(12, 114)
        Me.CbStart.Name = "CbStart"
        Me.CbStart.Size = New System.Drawing.Size(75, 23)
        Me.CbStart.TabIndex = 240
        Me.CbStart.Text = "Start"
        Me.CbStart.UseVisualStyleBackColor = False
        '
        'CbStop
        '
        Me.CbStop.Location = New System.Drawing.Point(90, 114)
        Me.CbStop.Name = "CbStop"
        Me.CbStop.Size = New System.Drawing.Size(75, 23)
        Me.CbStop.TabIndex = 250
        Me.CbStop.Text = "Stop"
        Me.CbStop.UseVisualStyleBackColor = True
        '
        'CbClose
        '
        Me.CbClose.Location = New System.Drawing.Point(252, 113)
        Me.CbClose.Name = "CbClose"
        Me.CbClose.Size = New System.Drawing.Size(75, 23)
        Me.CbClose.TabIndex = 270
        Me.CbClose.Text = "Close"
        Me.CbClose.UseVisualStyleBackColor = True
        '
        'CbWorkWav
        '
        Me.CbWorkWav.Location = New System.Drawing.Point(257, 27)
        Me.CbWorkWav.Name = "CbWorkWav"
        Me.CbWorkWav.Size = New System.Drawing.Size(120, 23)
        Me.CbWorkWav.TabIndex = 140
        Me.CbWorkWav.Text = "Select wav(work)"
        Me.CbWorkWav.UseVisualStyleBackColor = True
        '
        'CbRestWav
        '
        Me.CbRestWav.Location = New System.Drawing.Point(257, 56)
        Me.CbRestWav.Name = "CbRestWav"
        Me.CbRestWav.Size = New System.Drawing.Size(120, 23)
        Me.CbRestWav.TabIndex = 180
        Me.CbRestWav.Text = "Select wav(rest)"
        Me.CbRestWav.UseVisualStyleBackColor = True
        '
        'LbWavPathWork
        '
        Me.LbWavPathWork.AutoSize = True
        Me.LbWavPathWork.Location = New System.Drawing.Point(383, 31)
        Me.LbWavPathWork.Name = "LbWavPathWork"
        Me.LbWavPathWork.Size = New System.Drawing.Size(184, 15)
        Me.LbWavPathWork.TabIndex = 16
        Me.LbWavPathWork.Text = "C:\Windows\Media\Alarm05.wav"
        '
        'LbWavPathRest
        '
        Me.LbWavPathRest.AutoSize = True
        Me.LbWavPathRest.Location = New System.Drawing.Point(383, 60)
        Me.LbWavPathRest.Name = "LbWavPathRest"
        Me.LbWavPathRest.Size = New System.Drawing.Size(184, 15)
        Me.LbWavPathRest.TabIndex = 17
        Me.LbWavPathRest.Text = "C:\Windows\Media\Alarm02.wav"
        '
        'TimerAll
        '
        '
        'OpenFileDialogLast
        '
        Me.OpenFileDialogLast.FileName = "OpenFileDialog1"
        Me.OpenFileDialogLast.Filter = "wavファイル (*.wav)|*.wav"
        Me.OpenFileDialogLast.InitialDirectory = "c:\windows\media\"
        Me.OpenFileDialogLast.Title = "ラスト？秒で鳣らすWAVファイルを選択して下さい"
        '
        'CbSecLast
        '
        Me.CbSecLast.FormattingEnabled = True
        Me.CbSecLast.Items.AddRange(New Object() {"0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.CbSecLast.Location = New System.Drawing.Point(189, 85)
        Me.CbSecLast.Name = "CbSecLast"
        Me.CbSecLast.Size = New System.Drawing.Size(62, 23)
        Me.CbSecLast.TabIndex = 210
        Me.CbSecLast.Text = "10"
        '
        'CbMinLast
        '
        Me.CbMinLast.FormattingEnabled = True
        Me.CbMinLast.Items.AddRange(New Object() {"01", "...", "59"})
        Me.CbMinLast.Location = New System.Drawing.Point(121, 85)
        Me.CbMinLast.Name = "CbMinLast"
        Me.CbMinLast.Size = New System.Drawing.Size(62, 23)
        Me.CbMinLast.TabIndex = 200
        Me.CbMinLast.Text = "0"
        '
        'CbHourLast
        '
        Me.CbHourLast.FormattingEnabled = True
        Me.CbHourLast.Items.AddRange(New Object() {"01", "...", "24"})
        Me.CbHourLast.Location = New System.Drawing.Point(53, 85)
        Me.CbHourLast.Name = "CbHourLast"
        Me.CbHourLast.Size = New System.Drawing.Size(62, 23)
        Me.CbHourLast.TabIndex = 190
        Me.CbHourLast.Text = "0"
        '
        'LbLast
        '
        Me.LbLast.AutoSize = True
        Me.LbLast.Location = New System.Drawing.Point(12, 88)
        Me.LbLast.Name = "LbLast"
        Me.LbLast.Size = New System.Drawing.Size(28, 15)
        Me.LbLast.TabIndex = 18
        Me.LbLast.Text = "Last"
        '
        'CbLastWork
        '
        Me.CbLastWork.AutoSize = True
        Me.CbLastWork.Checked = True
        Me.CbLastWork.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbLastWork.Location = New System.Drawing.Point(257, 89)
        Me.CbLastWork.Name = "CbLastWork"
        Me.CbLastWork.Size = New System.Drawing.Size(54, 19)
        Me.CbLastWork.TabIndex = 220
        Me.CbLastWork.Text = "Work"
        Me.CbLastWork.UseVisualStyleBackColor = True
        '
        'CbLastRest
        '
        Me.CbLastRest.AutoSize = True
        Me.CbLastRest.Location = New System.Drawing.Point(317, 88)
        Me.CbLastRest.Name = "CbLastRest"
        Me.CbLastRest.Size = New System.Drawing.Size(48, 19)
        Me.CbLastRest.TabIndex = 230
        Me.CbLastRest.Text = "Rest"
        Me.CbLastRest.UseVisualStyleBackColor = True
        '
        'CbSelectWavLast
        '
        Me.CbSelectWavLast.Location = New System.Drawing.Point(371, 86)
        Me.CbSelectWavLast.Name = "CbSelectWavLast"
        Me.CbSelectWavLast.Size = New System.Drawing.Size(120, 23)
        Me.CbSelectWavLast.TabIndex = 231
        Me.CbSelectWavLast.Text = "Select wav(last)"
        Me.CbSelectWavLast.UseVisualStyleBackColor = True
        '
        'LbWavPathLast
        '
        Me.LbWavPathLast.AutoSize = True
        Me.LbWavPathLast.Location = New System.Drawing.Point(497, 92)
        Me.LbWavPathLast.Name = "LbWavPathLast"
        Me.LbWavPathLast.Size = New System.Drawing.Size(255, 15)
        Me.LbWavPathLast.TabIndex = 262
        Me.LbWavPathLast.Text = "C:\Windows\Media\Windows Foreground.wav"
        '
        'CbPause
        '
        Me.CbPause.Location = New System.Drawing.Point(171, 113)
        Me.CbPause.Name = "CbPause"
        Me.CbPause.Size = New System.Drawing.Size(75, 23)
        Me.CbPause.TabIndex = 260
        Me.CbPause.Text = "Pause"
        Me.CbPause.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "wavファイル (*.wav)|*.wav"
        Me.OpenFileDialog1.InitialDirectory = "c:\windows\media\"
        Me.OpenFileDialog1.Title = "ラスト？秒で鳴らすWAVファイルを選択して下さい"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog1"
        Me.OpenFileDialog2.Filter = "wavファイル (*.wav)|*.wav"
        Me.OpenFileDialog2.InitialDirectory = "c:\windows\media\"
        Me.OpenFileDialog2.Title = "ラスト？秒で鳴らすWAVファイルを選択して下さい"
        '
        'OpenFileDialogWork
        '
        Me.OpenFileDialogWork.FileName = "OpenFileDialog3"
        '
        'OpenFileDialogRest
        '
        Me.OpenFileDialogRest.FileName = "OpenFileDialog3"
        '
        'SetTimerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 148)
        Me.Controls.Add(Me.CbPause)
        Me.Controls.Add(Me.LbWavPathLast)
        Me.Controls.Add(Me.CbSelectWavLast)
        Me.Controls.Add(Me.CbLastRest)
        Me.Controls.Add(Me.CbLastWork)
        Me.Controls.Add(Me.CbSecLast)
        Me.Controls.Add(Me.CbMinLast)
        Me.Controls.Add(Me.CbHourLast)
        Me.Controls.Add(Me.LbLast)
        Me.Controls.Add(Me.LbWavPathRest)
        Me.Controls.Add(Me.LbWavPathWork)
        Me.Controls.Add(Me.CbRestWav)
        Me.Controls.Add(Me.CbWorkWav)
        Me.Controls.Add(Me.CbClose)
        Me.Controls.Add(Me.CbStop)
        Me.Controls.Add(Me.CbStart)
        Me.Controls.Add(Me.LbSecTitle)
        Me.Controls.Add(Me.LbMinTitle)
        Me.Controls.Add(Me.CbSecRest)
        Me.Controls.Add(Me.CbSecWork)
        Me.Controls.Add(Me.CbMinRest)
        Me.Controls.Add(Me.CbMinWork)
        Me.Controls.Add(Me.LbHourTitle)
        Me.Controls.Add(Me.CbHourRest)
        Me.Controls.Add(Me.CbHourWork)
        Me.Controls.Add(Me.LbRestTitle)
        Me.Controls.Add(Me.LbWorkTitle)
        Me.Name = "SetTimerForm"
        Me.Text = "Set Timer"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents LbWorkTitle As Label
    Friend WithEvents LbRestTitle As Label
    Friend WithEvents CbHourWork As ComboBox
    Friend WithEvents CbHourRest As ComboBox
    Friend WithEvents LbHourTitle As Label
    Friend WithEvents CbMinWork As ComboBox
    Friend WithEvents CbMinRest As ComboBox
    Friend WithEvents CbSecWork As ComboBox
    Friend WithEvents CbSecRest As ComboBox
    Friend WithEvents LbMinTitle As Label
    Friend WithEvents LbSecTitle As Label
    Friend WithEvents CbStart As Button
    Friend WithEvents CbStop As Button
    Friend WithEvents CbClose As Button
    Friend WithEvents CbWorkWav As Button
    Friend WithEvents CbRestWav As Button
    Friend WithEvents LbWavPathWork As Label
    Friend WithEvents LbWavPathRest As Label
    Friend WithEvents TimerAll As System.Windows.Forms.Timer
    Friend WithEvents TimerRest As System.Windows.Forms.Timer
    Friend WithEvents TimerWork As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialogLast As OpenFileDialog
    Friend WithEvents CbSecLast As ComboBox
    Friend WithEvents CbMinLast As ComboBox
    Friend WithEvents CbHourLast As ComboBox
    Friend WithEvents LbLast As Label
    Friend WithEvents CbLastWork As CheckBox
    Friend WithEvents CbLastRest As CheckBox
    Friend WithEvents CbSelectWavLast As Button
    Friend WithEvents LbWavPathLast As Label
    Friend WithEvents CbPause As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents OpenFileDialogWork As OpenFileDialog
    Friend WithEvents OpenFileDialogRest As OpenFileDialog
End Class