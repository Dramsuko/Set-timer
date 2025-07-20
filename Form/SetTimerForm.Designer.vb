﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SetTimerForm
    Inherits System.Windows.Forms.Form

    ' Designer が生成するコンポーネント一覧
    Private components As System.ComponentModel.IContainer

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

    ' Windows フォーム デザイナーで必要
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
        ' LbWorkTitle
        '
        Me.LbWorkTitle.AutoSize = True
        Me.LbWorkTitle.Location = New System.Drawing.Point(12, 30)
        Me.LbWorkTitle.Name = "LbWorkTitle"
        Me.LbWorkTitle.Size = New System.Drawing.Size(35, 15)
        Me.LbWorkTitle.TabIndex = 0
        Me.LbWorkTitle.Text = "Work"
        '
        ' LbRestTitle
        '
        Me.LbRestTitle.AutoSize = True
        Me.LbRestTitle.Location = New System.Drawing.Point(12, 59)
        Me.LbRestTitle.Name = "LbRestTitle"
        Me.LbRestTitle.Size = New System.Drawing.Size(29, 15)
        Me.LbRestTitle.TabIndex = 1
        Me.LbRestTitle.Text = "Rest"
        '
        ' CbHourWork
        '
        Me.CbHourWork.FormattingEnabled = True
        Me.CbHourWork.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.CbHourWork.Location = New System.Drawing.Point(53, 27)
        Me.CbHourWork.Name = "CbHourWork"
        Me.CbHourWork.Size = New System.Drawing.Size(62, 23)
        Me.CbHourWork.TabIndex = 110
        Me.CbHourWork.Text = "0"
        '
        ' (中略：DesignerGenerated のコントロール初期化コードをそのまま)
        '
        ' TimerAll
        '
        Me.TimerAll.Interval = 1000
        '
        ' (残りのコントロール設定も同様に並ぶ)
        '
        ' SetTimerForm
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