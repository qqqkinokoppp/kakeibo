
Imports MySql.Data.MySqlClient
Imports clsDB
Public Class fmMain

    '日付のラベル配列の宣言
    Dim day(5, 6) As Label

    '支出のラベル配列の宣言
    Dim expense(5, 6) As Label

    'カレンダー年
    Dim year As Integer

    'カレンダー月
    Dim month As Integer

    'DB接続のための変数宣言
    'Dim conn As MySqlConnection 'DB接続のインスタンス
    'Dim cmd As MySqlCommand 'SQL実行の準備のインスタンス
    'Dim dr As MySqlDataReader ''DBから取得したデータ

    '接続文字列(定数)
    'Const connectionString As String = "server=127.0.0.1;port=3307;Database=kakeibo;user id=root;password=1234"

    'SQL実行文
    'Dim sqlStr As String

    'clsDBのインスタンスを格納する変数
    Dim db As clsDB

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        db = New clsDB

        db.openDB()

        'SQL文
        db.sqlStr = "SELECT * FROM expense"

        db.dr = db.executeSQL(db.sqlStr)

        db.closeDB()

        'MySQLCommand作成
        'cmd = New MySqlCommand(sqlStr, conn)

        'SQL文実行
        'dr = cmd.ExecuteReader

        '結果を表示
        ' While dr.Read()
        'Console.WriteLine(CStr(dr("expense")))
        'End While


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
                AddHandler expense(i, j).DoubleClick, AddressOf Me.expenseDoubleClick
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
        Me.clearExpenseBackcolor()
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

    '支出ラベルをダブルクリックしたとき、支出入力フォームを立ち上げる
    Private Function expenseDoubleClick(sender As Object, e As EventArgs)
        Dim label = CType(sender, Label)
        Dim value As String = label.Name.ToString
        value = value.Substring(0, 4) & "/" & value.Substring(4, 2) & "/" & value.Substring(6, 2)
        fmInputShisyutu.lblDate.Text = value

        fmInputShisyutu.ShowDialog()
        Return label.Name
    End Function

    '*************************************************************************************************
    'DB関連関数

    'DB接続の関数
    Public Sub openDB()
        db.conn = New MySqlConnection(db.connectionString)
        db.conn.Open()
    End Sub

    'DB切断の関数
    Public Sub closeDB()
        db.conn.Close()
    End Sub

    'SQL実行
    Public Function executeSQL(sqlStr As String)
        db.cmd = New MySqlCommand(sqlStr, db.conn)
        'SQL文実行
        db.dr = db.cmd.ExecuteReader
        Return db.dr
    End Function

End Class

Public Class Program
    Shared Sub Main()
        Dim res As DialogResult
        'ログインダイアログを表示
        Dim f1 As New LoginForm
        res = f1.ShowDialog()
        f1.Dispose()
    End Sub
End Class
