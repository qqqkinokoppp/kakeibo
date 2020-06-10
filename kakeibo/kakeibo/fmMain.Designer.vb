<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblSun = New System.Windows.Forms.Label()
        Me.lblMon = New System.Windows.Forms.Label()
        Me.lblTue = New System.Windows.Forms.Label()
        Me.lblWed = New System.Windows.Forms.Label()
        Me.lblThu = New System.Windows.Forms.Label()
        Me.lblFri = New System.Windows.Forms.Label()
        Me.lblSat = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblSun
        '
        Me.lblSun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSun.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSun.ForeColor = System.Drawing.Color.Red
        Me.lblSun.Location = New System.Drawing.Point(199, 75)
        Me.lblSun.Name = "lblSun"
        Me.lblSun.Size = New System.Drawing.Size(80, 30)
        Me.lblSun.TabIndex = 0
        Me.lblSun.Text = "日"
        Me.lblSun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMon
        '
        Me.lblMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMon.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMon.Location = New System.Drawing.Point(285, 75)
        Me.lblMon.Name = "lblMon"
        Me.lblMon.Size = New System.Drawing.Size(80, 30)
        Me.lblMon.TabIndex = 1
        Me.lblMon.Text = "月"
        Me.lblMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTue
        '
        Me.lblTue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTue.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTue.Location = New System.Drawing.Point(371, 75)
        Me.lblTue.Name = "lblTue"
        Me.lblTue.Size = New System.Drawing.Size(80, 30)
        Me.lblTue.TabIndex = 2
        Me.lblTue.Text = "火"
        Me.lblTue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWed
        '
        Me.lblWed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWed.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblWed.Location = New System.Drawing.Point(457, 75)
        Me.lblWed.Name = "lblWed"
        Me.lblWed.Size = New System.Drawing.Size(80, 30)
        Me.lblWed.TabIndex = 3
        Me.lblWed.Text = "水"
        Me.lblWed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblThu
        '
        Me.lblThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThu.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblThu.Location = New System.Drawing.Point(543, 75)
        Me.lblThu.Name = "lblThu"
        Me.lblThu.Size = New System.Drawing.Size(80, 30)
        Me.lblThu.TabIndex = 4
        Me.lblThu.Text = "木"
        Me.lblThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFri
        '
        Me.lblFri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFri.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFri.Location = New System.Drawing.Point(629, 75)
        Me.lblFri.Name = "lblFri"
        Me.lblFri.Size = New System.Drawing.Size(80, 30)
        Me.lblFri.TabIndex = 5
        Me.lblFri.Text = "金"
        Me.lblFri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSat
        '
        Me.lblSat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSat.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSat.ForeColor = System.Drawing.Color.Blue
        Me.lblSat.Location = New System.Drawing.Point(715, 75)
        Me.lblSat.Name = "lblSat"
        Me.lblSat.Size = New System.Drawing.Size(80, 30)
        Me.lblSat.TabIndex = 6
        Me.lblSat.Text = "土"
        Me.lblSat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(473, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "年"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(623, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "月"
        '
        'cmbYear
        '
        Me.cmbYear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Items.AddRange(New Object() {"2020", "2021", "2022", "2023"})
        Me.cmbYear.Location = New System.Drawing.Point(346, 21)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(121, 24)
        Me.cmbYear.TabIndex = 11
        '
        'cmbMonth
        '
        Me.cmbMonth.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cmbMonth.Location = New System.Drawing.Point(498, 21)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(121, 24)
        Me.cmbMonth.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(197, 483)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 12)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Label3"
        '
        'fmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 622)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbMonth)
        Me.Controls.Add(Me.cmbYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSat)
        Me.Controls.Add(Me.lblFri)
        Me.Controls.Add(Me.lblThu)
        Me.Controls.Add(Me.lblWed)
        Me.Controls.Add(Me.lblTue)
        Me.Controls.Add(Me.lblMon)
        Me.Controls.Add(Me.lblSun)
        Me.IsMdiContainer = True
        Me.Name = "fmMain"
        Me.Text = "家計簿（仮）"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSun As Label
    Friend WithEvents lblMon As Label
    Friend WithEvents lblTue As Label
    Friend WithEvents lblWed As Label
    Friend WithEvents lblThu As Label
    Friend WithEvents lblFri As Label
    Friend WithEvents lblSat As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbYear As ComboBox
    Friend WithEvents cmbMonth As ComboBox
    Friend WithEvents Label3 As Label
End Class
