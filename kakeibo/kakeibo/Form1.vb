﻿

Public Class Form1

    '日付のラベル配列の宣言
    Dim day(5, 6) As Label

    '支出のラベル配列の宣言
    Dim expense(5, 6) As Label

    'カレンダー年
    Dim year As Integer

    'カレンダー月
    Dim month As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '曜日ラベルの上位置を日曜日のラベル基準にそろえる
        lblMon.Top = lblSun.Top
        lblTue.Top = lblSun.Top
        lblWed.Top = lblSun.Top
        lblThu.Top = lblSun.Top
        lblFri.Top = lblSun.Top
        lblSat.Top = lblSun.Top

        '各曜日ラベルの右位置を日曜日基準に並べていく
        lblMon.Left = lblSun.Left + 80
        lblTue.Left = lblSun.Left + 80 * 2
        lblWed.Left = lblSun.Left + 80 * 3
        lblThu.Left = lblSun.Left + 80 * 4
        lblFri.Left = lblSun.Left + 80 * 5
        lblSat.Left = lblSun.Left + 80 * 6

        '日付ラベルの表示

        Dim i As Integer
        Dim j As Integer
        For i = 0 To 5
            For j = 0 To 6
                day(i, j) = New Label
                day(i, j).BorderStyle = BorderStyle.FixedSingle
                day(i, j).Width = 80
                day(i, j).Height = 20
                If i = 0 Then
                    day(i, j).Top = lblSun.Top + 30
                    day(i, j).Left = lblSun.Left + 80 * j
                Else
                    day(i, j).Top = day(0, 0).Top + 60 * i
                    day(i, j).Left = day(0, 0).Left + 80 * j
                End If
                'day(i, j).Top = lblSun.Top + 60 * (i + 1)
                'day(i, j).Left = lblSun.Left + 80 * j
                If j = 0 Then
                    day(i, j).ForeColor = Color.Red
                End If
                If j = 6 Then
                    day(i, j).ForeColor = Color.Blue
                End If
                Me.Controls.Add(day(i, j))
            Next
        Next

        '支出ラベルの表示
        For i = 0 To 5
            For j = 0 To 6
                expense(i, j) = New Label
                expense(i, j).BorderStyle = BorderStyle.FixedSingle
                expense(i, j).Width = 80
                expense(i, j).Height = 40
                If i = 0 Then
                    expense(i, j).Top = day(0, 0).Top + 20
                    expense(i, j).Left = day(0, 0).Left + 80 * j
                Else
                    expense(i, j).Top = expense(0, 0).Top + 60 * i
                    expense(i, j).Left = expense(0, 0).Left + 80 * j
                End If
                'day(i, j).Top = lblSun.Top + 60 * (i + 1)
                'day(i, j).Left = lblSun.Left + 80 * j
                If j = 0 Then
                    expense(i, j).ForeColor = Color.Red
                End If
                If j = 6 Then
                    expense(i, j).ForeColor = Color.Blue
                End If
                Me.Controls.Add(expense(i, j))
                AddHandler expense(i, j).Click, AddressOf Me.expenseClick
            Next
        Next


        '年月のコンボボックスに本日の年月をセットする
        Dim dtNow As DateTime = DateTime.Now
        cmbYear.Text = dtNow.Year
        cmbMonth.Text = dtNow.Month

        '年月の変数に本日の年月を格納
        year = dtNow.Year
        month = dtNow.Month


        '今月のカレンダーを表示する
        Me.ShowCalender(year, month)

        '支出ラベルに年月日の名前をつける
        Me.expenseName(year, month)

        Console.WriteLine(expense(0, 3).Name)



    End Sub



    '年のvalidatedイベント
    Private Sub selectYear(sender As Object, e As EventArgs) Handles cmbYear.Validated
        'カレンダーのクリア
        Me.ClearCalender()
        'コンボボックスで選択されている年月のカレンダーを表示
        year = Integer.Parse(cmbYear.Text)
        month = Integer.Parse(cmbMonth.Text)

        'カレンダーの表示
        Me.ShowCalender(year, month)

        '支出ラベルに年月日の名前をつける
        Me.expenseName(year, month)

        '支出ラベルの背景色のクリア
        Me.clearExpenseBackcolor()

        Console.WriteLine(expense(0, 3).Name)
    End Sub

    '月のvalidatedイベント
    Private Sub selectMonth(sender As Object, e As EventArgs) Handles cmbMonth.Validated
        'カレンダーのクリア
        Me.ClearCalender()
        'コンボボックスで選択されている年月のカレンダーを表示
        year = Integer.Parse(cmbYear.Text)
        month = Integer.Parse(cmbMonth.Text)

        'カレンダーの表示
        Me.ShowCalender(year, month)

        '支出ラベルに年月日の名前をつける
        Me.expenseName(year, month)

        '支出ラベルの背景色のクリア
        Me.clearExpenseBackcolor()


        Console.WriteLine(expense(0, 3).Name)
    End Sub

    'カレンダー表示の関数
    Public Sub ShowCalender(year As Integer, month As Integer)
        '月のついたちの曜日を取得
        Dim firstDay As Date = New Date(year, month, 1)
        Dim firstDayWeek As Integer = firstDay.DayOfWeek

        Dim w As Integer = 0 ' 週
        Dim dw As Integer = firstDayWeek ' 曜日 ( 0 〜 6 )
        Dim d As Integer = 1 ' 日
        Dim days As Integer = Date.DaysInMonth(year, month)

        Do
            day(w, dw).Text = d.ToString
            d += 1
            dw += 1
            If 6 < dw Then
                w += 1 ' 次の週
                dw = 0 ' 日曜日
            End If
        Loop While d <= days

    End Sub

    'カレンダーのクリア
    Public Sub ClearCalender()
        For i = 0 To 5
            For j = 0 To 6
                day(i, j).Text = ""
            Next
        Next
    End Sub

    '支出ラベルに日付の名前を付ける関数
    '例：20200512,20201026のように日付をつけていく
    Public Sub expenseName(year As Integer, month As Integer)
        '月のついたちの曜日を取得
        Dim firstDay As Date = New Date(year, month, 1)
        Dim firstDayWeek As Integer = firstDay.DayOfWeek

        Dim w As Integer = 0 ' 週
        Dim dw As Integer = firstDayWeek ' 曜日 ( 0 〜 6 )
        Dim d As Integer = 1 ' 日
        Dim days As Integer = Date.DaysInMonth(year, month)

        Do
            If month < 10 Then
                '月が10月より前の時
                If d < 10 Then
                    '日が１０日より前の時
                    expense(w, dw).Name = year.ToString & "0" & month.ToString & "0" & d.ToString
                Else
                    '日が１０日以降の時
                    expense(w, dw).Name = year.ToString & "0" & month.ToString & d.ToString
                End If
            Else
                '月が１０月以降の時
                If d < 10 Then
                    '日が１０日より前の時
                    expense(w, dw).Name = year.ToString & month.ToString & "0" & d.ToString
                Else
                    '日が１０日以降の時
                    expense(w, dw).Name = year.ToString & month.ToString & d.ToString
                End If
            End If
            d += 1
            dw += 1
            If 6 < dw Then
                w += 1 ' 次の週
                dw = 0 ' 日曜日
            End If
        Loop While d <= days


    End Sub

    '支出ラベルをクリックしたとき、背景色を変える関数
    Private Sub expenseClick(sender As Object, e As EventArgs)
        Dim label = CType(sender, Label)
        label.BackColor = Color.Aqua
    End Sub

    '支出ラベルの背景色のクリア
    Public Sub clearExpenseBackcolor()
        For i = 0 To 5
            For j = 0 To 6
                expense(i, j).BackColor = SystemColors.Control
            Next
        Next
    End Sub

End Class

Public Class program
    Shared Sub Main()
        Dim res As DialogResult
        'ログインダイアログを表示
        Dim f1 As New LoginForm
        res = f1.ShowDialog()
        f1.Dispose()
    End Sub
End Class
