Imports MySql.Data.MySqlClient
Imports clsDB

Public Class fmRegistration

    'DB接続のための変数宣言
    Dim conn As MySqlConnection 'DB接続のインスタンス
    Dim cmd As MySqlCommand 'SQL実行の準備のインスタンス
    Dim dr As MySqlDataReader ''DBから取得したデータ

    '接続文字列(定数)
    Const connectionString As String = "server=127.0.0.1;port=3307;Database=kakeibo;user id=root;password=1234"

    'SQL実行文
    Dim sqlStr As String
    Private Sub registrate(sender As Object, e As EventArgs) Handles btnRegistration.Click

    End Sub
End Class