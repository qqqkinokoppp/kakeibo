Imports MySql.Data.MySqlClient
Imports clsDB
Public Class fmInputShisyutu
    'DB操作のためのインスタンス
    Dim db As clsDB
    'カテゴリ用データテーブル
    Dim dtCategory As DataTable
    '支出DGV用のデータテーブル
    Dim dtExpense As DataTable

    Private Sub fmInputShisyutu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        db.cmd.CommandText = "SELECT"
        db.cmd.CommandText += " expense,"
        db.cmd.CommandText += " category,"
        db.cmd.CommandText += " date"
        db.cmd.CommandText += " FROM"
        db.cmd.CommandText += " kakeibo.expense"
        db.cmd.CommandText += " JOIN"
        db.cmd.CommandText += " kakeibo.category"
        db.cmd.CommandText += " ON kakeibo.expense.caegeory_id=kakeibo.category.id"
        db.cmd.CommandText += " WHERE"
        db.cmd.CommandText += "kakeibo.expense.date=@date"

        'db.cmd.Parameters.AddWithValue("@date", )

        'db.cmd.Connection = db.conn

        'db.dr = db.cmd.ExecuteReader()

        '支出DTにDBから取得したデータを格納
        'dtExpense = New DataTable
        'dtExpense.Load(db.dr)

        'dgvExpense.DataSource = dtExpense

        'Console.WriteLine("1")

    End Sub
End Class