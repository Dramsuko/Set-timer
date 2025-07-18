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
        components = New ComponentModel.Container()
        LbWorkTitle = New Label()
        LbRestTitle = New Label()
        CbHourWork = New ComboBox()
        CbHourRest = New ComboBox()
        LbHourTitle = New Label()
        CbMinWork = New ComboBox()
        CbMinRest = New ComboBox()
        CbSecWork = New ComboBox()
        CbSecRest = New ComboBox()
        LbMinTitle = New Label()
        LbSecTitle = New Label()
        CbStart = New Button()
        CbStop = New Button()
        CbClose = New Button()
        CbWorkWav = New Button()
        CbRestWav = New Button()
        LbWavPathWork = New Label()
        LbWavPathRest = New Label()
        TimerAll = New Timer(components)
        TimerRest = New Timer(components)
        OpenFileDialogLast = New OpenFileDialog()
        CbLastSec = New ComboBox()
        CbLastMin = New ComboBox()
        CbLastHour = New ComboBox()
        LbLast = New Label()
        CbLastWork = New CheckBox()
        CbLastRest = New CheckBox()
        CbSelectWavLast = New Button()
        LbPathLast = New Label()
        CbPause = New Button()
        SuspendLayout()
        ' 
        ' LbWorkTitle
        ' 
        LbWorkTitle.AutoSize = True
        LbWorkTitle.Location = New Point(12, 30)
        LbWorkTitle.Name = "LbWorkTitle"
        LbWorkTitle.Size = New Size(35, 15)
        LbWorkTitle.TabIndex = 0
        LbWorkTitle.Text = "Work"
        ' 
        ' LbRestTitle
        ' 
        LbRestTitle.AutoSize = True
        LbRestTitle.Location = New Point(12, 59)
        LbRestTitle.Name = "LbRestTitle"
        LbRestTitle.Size = New Size(29, 15)
        LbRestTitle.TabIndex = 1
        LbRestTitle.Text = "Rest"
        ' 
        ' CbHourWork
        ' 
        CbHourWork.FormattingEnabled = True
        CbHourWork.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        CbHourWork.Location = New Point(53, 27)
        CbHourWork.Name = "CbHourWork"
        CbHourWork.Size = New Size(62, 23)
        CbHourWork.TabIndex = 110
        CbHourWork.Text = "0"
        ' 
        ' CbHourRest
        ' 
        CbHourRest.FormattingEnabled = True
        CbHourRest.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        CbHourRest.Location = New Point(53, 56)
        CbHourRest.Name = "CbHourRest"
        CbHourRest.Size = New Size(62, 23)
        CbHourRest.TabIndex = 150
        CbHourRest.Text = "0"
        ' 
        ' LbHourTitle
        ' 
        LbHourTitle.AutoSize = True
        LbHourTitle.Location = New Point(63, 9)
        LbHourTitle.Name = "LbHourTitle"
        LbHourTitle.Size = New Size(34, 15)
        LbHourTitle.TabIndex = 4
        LbHourTitle.Text = "Hour"
        ' 
        ' CbMinWork
        ' 
        CbMinWork.FormattingEnabled = True
        CbMinWork.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"})
        CbMinWork.Location = New Point(121, 27)
        CbMinWork.Name = "CbMinWork"
        CbMinWork.Size = New Size(62, 23)
        CbMinWork.TabIndex = 120
        CbMinWork.Text = "0"
        ' 
        ' CbMinRest
        ' 
        CbMinRest.FormattingEnabled = True
        CbMinRest.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"})
        CbMinRest.Location = New Point(121, 56)
        CbMinRest.Name = "CbMinRest"
        CbMinRest.Size = New Size(62, 23)
        CbMinRest.TabIndex = 160
        CbMinRest.Text = "0"
        ' 
        ' CbSecWork
        ' 
        CbSecWork.FormattingEnabled = True
        CbSecWork.Items.AddRange(New Object() {"0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        CbSecWork.Location = New Point(189, 27)
        CbSecWork.Name = "CbSecWork"
        CbSecWork.Size = New Size(62, 23)
        CbSecWork.TabIndex = 130
        CbSecWork.Text = "10"
        ' 
        ' CbSecRest
        ' 
        CbSecRest.FormattingEnabled = True
        CbSecRest.Items.AddRange(New Object() {"0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        CbSecRest.Location = New Point(189, 56)
        CbSecRest.Name = "CbSecRest"
        CbSecRest.Size = New Size(62, 23)
        CbSecRest.TabIndex = 170
        CbSecRest.Text = "5"
        ' 
        ' LbMinTitle
        ' 
        LbMinTitle.AutoSize = True
        LbMinTitle.Location = New Point(137, 9)
        LbMinTitle.Name = "LbMinTitle"
        LbMinTitle.Size = New Size(28, 15)
        LbMinTitle.TabIndex = 9
        LbMinTitle.Text = "Min"
        ' 
        ' LbSecTitle
        ' 
        LbSecTitle.AutoSize = True
        LbSecTitle.Location = New Point(204, 9)
        LbSecTitle.Name = "LbSecTitle"
        LbSecTitle.Size = New Size(25, 15)
        LbSecTitle.TabIndex = 10
        LbSecTitle.Text = "Sec"
        ' 
        ' CbStart
        ' 
        CbStart.Location = New Point(12, 114)
        CbStart.Name = "CbStart"
        CbStart.Size = New Size(75, 23)
        CbStart.TabIndex = 240
        CbStart.Text = "Start"
        CbStart.UseVisualStyleBackColor = True
        ' 
        ' CbStop
        ' 
        CbStop.Location = New Point(90, 114)
        CbStop.Name = "CbStop"
        CbStop.Size = New Size(75, 23)
        CbStop.TabIndex = 250
        CbStop.Text = "Stop"
        CbStop.UseVisualStyleBackColor = True
        ' 
        ' CbClose
        ' 
        CbClose.Location = New Point(252, 113)
        CbClose.Name = "CbClose"
        CbClose.Size = New Size(75, 23)
        CbClose.TabIndex = 270
        CbClose.Text = "Close"
        CbClose.UseVisualStyleBackColor = True
        ' 
        ' CbWorkWav
        ' 
        CbWorkWav.Location = New Point(257, 27)
        CbWorkWav.Name = "CbWorkWav"
        CbWorkWav.Size = New Size(120, 23)
        CbWorkWav.TabIndex = 140
        CbWorkWav.Text = "Select wav(work)"
        CbWorkWav.UseVisualStyleBackColor = True
        ' 
        ' CbRestWav
        ' 
        CbRestWav.Location = New Point(257, 56)
        CbRestWav.Name = "CbRestWav"
        CbRestWav.Size = New Size(120, 23)
        CbRestWav.TabIndex = 180
        CbRestWav.Text = "Select wav(rest)"
        CbRestWav.UseVisualStyleBackColor = True
        ' 
        ' LbWavPathWork
        ' 
        LbWavPathWork.AutoSize = True
        LbWavPathWork.Location = New Point(383, 31)
        LbWavPathWork.Name = "LbWavPathWork"
        LbWavPathWork.Size = New Size(60, 15)
        LbWavPathWork.TabIndex = 16
        LbWavPathWork.Text = "(non wav)"
        ' 
        ' LbWavPathRest
        ' 
        LbWavPathRest.AutoSize = True
        LbWavPathRest.Location = New Point(383, 60)
        LbWavPathRest.Name = "LbWavPathRest"
        LbWavPathRest.Size = New Size(60, 15)
        LbWavPathRest.TabIndex = 17
        LbWavPathRest.Text = "(non wav)"
        ' 
        ' OpenFileDialogLast
        ' 
        OpenFileDialogLast.FileName = "OpenFileDialog1"
        OpenFileDialogLast.InitialDirectory = "%windir%\media\"
        ' 
        ' CbLastSec
        ' 
        CbLastSec.FormattingEnabled = True
        CbLastSec.Items.AddRange(New Object() {"0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        CbLastSec.Location = New Point(189, 85)
        CbLastSec.Name = "CbLastSec"
        CbLastSec.Size = New Size(62, 23)
        CbLastSec.TabIndex = 210
        CbLastSec.Text = "3"
        ' 
        ' CbLastMin
        ' 
        CbLastMin.FormattingEnabled = True
        CbLastMin.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"})
        CbLastMin.Location = New Point(121, 85)
        CbLastMin.Name = "CbLastMin"
        CbLastMin.Size = New Size(62, 23)
        CbLastMin.TabIndex = 200
        CbLastMin.Text = "0"
        ' 
        ' CbLastHour
        ' 
        CbLastHour.FormattingEnabled = True
        CbLastHour.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        CbLastHour.Location = New Point(53, 85)
        CbLastHour.Name = "CbLastHour"
        CbLastHour.Size = New Size(62, 23)
        CbLastHour.TabIndex = 190
        CbLastHour.Text = "0"
        ' 
        ' LbLast
        ' 
        LbLast.AutoSize = True
        LbLast.Location = New Point(12, 88)
        LbLast.Name = "LbLast"
        LbLast.Size = New Size(28, 15)
        LbLast.TabIndex = 18
        LbLast.Text = "Last"
        ' 
        ' CbLastWork
        ' 
        CbLastWork.AutoSize = True
        CbLastWork.Location = New Point(257, 89)
        CbLastWork.Name = "CbLastWork"
        CbLastWork.Size = New Size(54, 19)
        CbLastWork.TabIndex = 220
        CbLastWork.Text = "Work"
        CbLastWork.UseVisualStyleBackColor = True
        ' 
        ' CbLastRest
        ' 
        CbLastRest.AutoSize = True
        CbLastRest.Location = New Point(317, 88)
        CbLastRest.Name = "CbLastRest"
        CbLastRest.Size = New Size(48, 19)
        CbLastRest.TabIndex = 230
        CbLastRest.Text = "Rest"
        CbLastRest.UseVisualStyleBackColor = True
        ' 
        ' CbSelectWavLast
        ' 
        CbSelectWavLast.Location = New Point(371, 86)
        CbSelectWavLast.Name = "CbSelectWavLast"
        CbSelectWavLast.Size = New Size(120, 23)
        CbSelectWavLast.TabIndex = 231
        CbSelectWavLast.Text = "Select wav(last)"
        CbSelectWavLast.UseVisualStyleBackColor = True
        ' 
        ' LbPathLast
        ' 
        LbPathLast.AutoSize = True
        LbPathLast.Location = New Point(497, 92)
        LbPathLast.Name = "LbPathLast"
        LbPathLast.Size = New Size(60, 15)
        LbPathLast.TabIndex = 262
        LbPathLast.Text = "(non wav)"
        ' 
        ' CbPause
        ' 
        CbPause.Location = New Point(171, 113)
        CbPause.Name = "CbPause"
        CbPause.Size = New Size(75, 23)
        CbPause.TabIndex = 260
        CbPause.Text = "Pause"
        CbPause.UseVisualStyleBackColor = True
        ' 
        ' SetTimerForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(717, 148)
        Controls.Add(CbPause)
        Controls.Add(LbPathLast)
        Controls.Add(CbSelectWavLast)
        Controls.Add(CbLastRest)
        Controls.Add(CbLastWork)
        Controls.Add(CbLastSec)
        Controls.Add(CbLastMin)
        Controls.Add(CbLastHour)
        Controls.Add(LbLast)
        Controls.Add(LbWavPathRest)
        Controls.Add(LbWavPathWork)
        Controls.Add(CbRestWav)
        Controls.Add(CbWorkWav)
        Controls.Add(CbClose)
        Controls.Add(CbStop)
        Controls.Add(CbStart)
        Controls.Add(LbSecTitle)
        Controls.Add(LbMinTitle)
        Controls.Add(CbSecRest)
        Controls.Add(CbSecWork)
        Controls.Add(CbMinRest)
        Controls.Add(CbMinWork)
        Controls.Add(LbHourTitle)
        Controls.Add(CbHourRest)
        Controls.Add(CbHourWork)
        Controls.Add(LbRestTitle)
        Controls.Add(LbWorkTitle)
        Name = "SetTimerForm"
        Text = "Set Timer"
        ResumeLayout(False)
        PerformLayout()
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
    Friend WithEvents TimerAll As Timer
    Friend WithEvents TimerRest As Timer
    Friend WithEvents OpenFileDialogLast As OpenFileDialog
    Friend WithEvents CbLastSec As ComboBox
    Friend WithEvents CbLastMin As ComboBox
    Friend WithEvents CbLastHour As ComboBox
    Friend WithEvents LbLast As Label
    Friend WithEvents CbLastWork As CheckBox
    Friend WithEvents CbLastRest As CheckBox
    Friend WithEvents CbSelectWavLast As Button
    Friend WithEvents LbPathLast As Label
    Friend WithEvents CbPause As Button

End Class
