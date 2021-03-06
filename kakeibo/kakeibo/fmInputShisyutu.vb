﻿Imports MySql.Data.MySqlClient
Imports clsDB
Public Class fmInputShisyutu
    'DB操作のためのインスタンス
    Dim db As clsDB
    'カテゴリ用データテーブル
    Dim dtCategory As DataTable
    '支出DGV用のデータテーブル
    Dim dtExpense As DataTable

    'ユーザーID
    Dim user_id As Integer

    '支出
    Dim expense As Integer

    'カテゴリID
    Dim category_id As Integer

    '日付
    Dim expenseDate As String

    Private Sub fmInputShisyutu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'fmMainからの値取得
        expenseDate = CType(Me.Owner, fmMain).value.ToString
        lblDate.Text = expenseDate

        'ロードイベントでその日の支出一覧とカテゴリ一覧をロード
        db = New clsDB
        db.openDB()
        db.cmd = New MySqlCommand
        db.cmd.CommandText = "SELECT id, category FROM kakeibo.category"
        db.cmd.Connection = db.conn

        db.dr = db.cmd.ExecuteReader()

        'カテゴリDTににDBから取得したデータを格納
        dtCategory = New DataTable
        dtCategory.Load(db.dr)

        cmbCategory.DataSource = dtCategory
        cmbCategory.DisplayMember = "category"
        cmbCategory.ValueMember = "id"

        '選択した日の支出一覧を抽出、一覧表示させる
        db.cmd.CommandText = ""
        db.cmd.CommandText += " SELECT"
        db.cmd.CommandText += " expense,"
        db.cmd.CommandText += " category,"
        db.cmd.CommandText += " expense.is_deleted,"
        db.cmd.CommandText += " expense.id,"
        db.cmd.CommandText += " category_id"
        db.cmd.CommandText += " FROM"
        db.cmd.CommandText += " kakeibo.expense"
        db.cmd.CommandText += " JOIN"
        db.cmd.CommandText += " kakeibo.category"
        db.cmd.CommandText += " ON kakeibo.expense.category_id=kakeibo.category.id"
        db.cmd.CommandText += " WHERE"
        db.cmd.CommandText += " kakeibo.expense.date=@date"

        db.cmd.Parameters.AddWithValue("@date", expenseDate)

        db.cmd.Connection = db.conn

        db.dr = db.cmd.ExecuteReader()

        '支出DTにDBから取得したデータを格納
        dtExpense = New DataTable
        dtExpense.Load(db.dr)

        '支出DGVにバインド
        dgvExpense.DataSource = dtExpense

        '支出DGVのデザイン
        dgvExpense.Columns(2).Visible = False
        dgvExpense.Columns(3).Visible = False
        dgvExpense.Columns(4).Visible = False

        dgvExpense.Columns(0).HeaderText = "支出"
        dgvExpense.Columns(1).HeaderText = "カテゴリ"

        dgvExpense.AllowUserToAddRows = False
        dgvExpense.RowHeadersVisible = False

        dgvExpense.DefaultCellStyle.Font = New Font("Tahoma", 15)

        dgvExpense.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        'カテゴリによって行の色を変更
        For i = 0 To dgvExpense.Rows.Count - 1
            If dgvExpense.Rows(i).Cells(1).Value = "未分類" Then
                dgvExpense.Rows(i).DefaultCellStyle.BackColor = Color.Orange
            ElseIf dgvExpense.Rows(i).Cells(1).Value = "スーパー" Then
                dgvExpense.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf dgvExpense.Rows(i).Cells(1).Value = "コンビニ" Then
                dgvExpense.Rows(i).DefaultCellStyle.BackColor = Color.Blue
            ElseIf dgvExpense.Rows(i).Cells(1).Value = "その他" Then
                dgvExpense.Rows(i).DefaultCellStyle.BackColor = Color.Coral
            End If
        Next

    End Sub

    '変更ボタンクリックでDB更新
    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        '選択されているDGVのidに該当するDTを更新する
        'Dim id As Integer
        'id = dgvExpense.CurrentRow.Cells("id").Value
        'dgvExpense.CurrentRow.Cells("expense").Value = txtExpense.Text
        'dgvExpense.CurrentRow.Cells("category_id").Value = cmbCategory.SelectedValue

        db = New clsDB
        db.openDB()
        db.cmd = New MySqlCommand
        db.cmd.CommandText = ""
        db.cmd.CommandText += "UPDATE"
        db.cmd.CommandText += " kaiibo.expense"
        db.cmd.CommandText += " SET"
        db.cmd.CommandText += " user_id=@user_id,"
        db.cmd.CommandText += " date=@date,"
        db.cmd.CommandText += " expense=@expense,"
        db.cmd.CommandText += " category_id=@category_id"
        db.cmd.CommandText += " WHERE"
        db.cmd.CommandText += " id=@id"

    End Sub

    'DGVのセルをダブルクリックで値を取得して、表示
    Private Sub selectExpense(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpense.CellDoubleClick
        cmbCategory.Text = dgvExpense.CurrentRow.Cells(1).Value.ToString

        txtExpense.Text = dgvExpense.CurrentRow.Cells(0).Value.ToString
    End Sub

    '新規支出の追加
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        user_id = CType(Me.Owner, fmMain).user_id
        expense = txtExpense.Text
        category_id = cmbCategory.SelectedValue

        db = New clsDB
        db.openDB()
        db.cmd = New MySqlCommand
        db.cmd.CommandText = ""
        db.cmd.CommandText += "INSERT INTO"
        db.cmd.CommandText += " expense"
        db.cmd.CommandText += "("
        db.cmd.CommandText += " user_id,"
        db.cmd.CommandText += " date,"
        db.cmd.CommandText += " expense,"
        db.cmd.CommandText += " category_id"
        db.cmd.CommandText += ")"
        db.cmd.CommandText += " VALUE"
        db.cmd.CommandText += " ("
        db.cmd.CommandText += " @user_id,"
        db.cmd.CommandText += " @date,"
        db.cmd.CommandText += " @expense,"
        db.cmd.CommandText += " @category_id"
        db.cmd.CommandText += " )"

        db.cmd.Parameters.AddWithValue("@user_id", user_id)
        db.cmd.Parameters.AddWithValue("@date", expenseDate)
        db.cmd.Parameters.AddWithValue("@expense", expense)
        db.cmd.Parameters.AddWithValue("@category_id", category_id)

        db.cmd.Connection = db.conn

        db.dr = db.cmd.ExecuteReader()

        'fmMainからの値取得
        expenseDate = CType(Me.Owner, fmMain).value.ToString
        lblDate.Text = expenseDate

        'ロードイベントでその日の支出一覧とカテゴリ一覧をロード
        db = New clsDB
        db.openDB()
        db.cmd = New MySqlCommand
        db.cmd.CommandText = "SELECT id, category FROM kakeibo.category"
        db.cmd.Connection = db.conn

        db.dr = db.cmd.ExecuteReader()

        'カテゴリDTににDBから取得したデータを格納
        dtCategory = New DataTable
        dtCategory.Load(db.dr)

        cmbCategory.DataSource = dtCategory
        cmbCategory.DisplayMember = "category"
        cmbCategory.ValueMember = "id"

        '選択した日の支出一覧を抽出、一覧表示させる
        db.cmd.CommandText = ""
        db.cmd.CommandText += " SELECT"
        db.cmd.CommandText += " expense,"
        db.cmd.CommandText += " category,"
        db.cmd.CommandText += " expense.is_deleted,"
        db.cmd.CommandText += " expense.id,"
        db.cmd.CommandText += " category_id"
        db.cmd.CommandText += " FROM"
        db.cmd.CommandText += " kakeibo.expense"
        db.cmd.CommandText += " JOIN"
        db.cmd.CommandText += " kakeibo.category"
        db.cmd.CommandText += " ON kakeibo.expense.category_id=kakeibo.category.id"
        db.cmd.CommandText += " WHERE"
        db.cmd.CommandText += " kakeibo.expense.date=@date"

        db.cmd.Parameters.AddWithValue("@date", expenseDate)

        db.cmd.Connection = db.conn

        db.dr = db.cmd.ExecuteReader()

        '支出DTにDBから取得したデータを格納
        dtExpense = New DataTable
        dtExpense.Load(db.dr)

        '支出DGVにバインド
        dgvExpense.DataSource = dtExpense

        '支出DGVのデザイン
        dgvExpense.Columns(2).Visible = False
        dgvExpense.Columns(3).Visible = False
        dgvExpense.Columns(4).Visible = False

        dgvExpense.Columns(0).HeaderText = "支出"
        dgvExpense.Columns(1).HeaderText = "カテゴリ"

        dgvExpense.AllowUserToAddRows = False
        dgvExpense.RowHeadersVisible = False

        dgvExpense.DefaultCellStyle.Font = New Font("Tahoma", 15)

        dgvExpense.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        'カテゴリによって行の色を変更
        For i = 0 To dgvExpense.Rows.Count - 1
            If dgvExpense.Rows(i).Cells(1).Value = "未分類" Then
                dgvExpense.Rows(i).DefaultCellStyle.BackColor = Color.Orange
            ElseIf dgvExpense.Rows(i).Cells(1).Value = "スーパー" Then
                dgvExpense.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf dgvExpense.Rows(i).Cells(1).Value = "コンビニ" Then
                dgvExpense.Rows(i).DefaultCellStyle.BackColor = Color.Blue
            ElseIf dgvExpense.Rows(i).Cells(1).Value = "その他" Then
                dgvExpense.Rows(i).DefaultCellStyle.BackColor = Color.Coral
            End If
        Next

    End Sub

    '閉じるボタンクリック時、メインフォームのロードイベントを呼び出す
    Private Sub clickExit(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim f As New fmMain
        f.load_fmMain()

        Me.Dispose()

    End Sub
End Class