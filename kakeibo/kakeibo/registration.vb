Imports MySql.Data.MySqlClient
Imports clsDB

Public Class fmRegistration

    'DB接続のための変数宣言
    Dim conn As MySqlConnection 'DB接続のインスタンス
    Dim cmd As MySqlCommand 'SQL実行の準備のインスタンス
    Dim dr As MySqlDataReader ''DBから取得したデータ

    '接続文字列(定数)
    Const connectionString As String = "server=127.0.0.1;port=3307;Database=kakeibo;user id=root;password=1234"

    'ユーザー名
    Dim userName As String

    'パスワード
    Dim password As String

    '名前
    Dim name As String

    '目標金額
    Dim mokuhyo As Integer

    'SQL実行文
    Dim sqlStr As String

    'DB操作のための変数
    Dim db As clsDB
    Private Sub registrate(sender As Object, e As EventArgs) Handles btnRegistration.Click

        userName = txtUserName.Text.ToString
        password = txtPassword.Text.ToString
        name = txtName.Text.ToString
        mokuhyo = txtMokuhyo.Text.ToString

        'パスワードのハッシュ化
        password = hash(password)


        'DBへのユーザー情報の登録
        db = New clsDB
        db.openDB()
        db.cmd = New MySqlCommand
        db.cmd.CommandText = ""
        db.cmd.CommandText += "INSERT INTO"
        db.cmd.CommandText += " user"
        db.cmd.CommandText += "("
        db.cmd.CommandText += " user_name,"
        db.cmd.CommandText += " password,"
        db.cmd.CommandText += " name"
        db.cmd.CommandText += ")"
        db.cmd.CommandText += " VALUE"
        db.cmd.CommandText += " ("
        db.cmd.CommandText += " @user_name,"
        db.cmd.CommandText += " @password,"
        db.cmd.CommandText += " @name"
        db.cmd.CommandText += " )"

        db.cmd.Parameters.AddWithValue("@user_name", userName)
        db.cmd.Parameters.AddWithValue("@password", password)
        db.cmd.Parameters.AddWithValue("@name", name)

        db.cmd.Connection = db.conn

        db.dr = db.cmd.ExecuteReader()



    End Sub
End Class