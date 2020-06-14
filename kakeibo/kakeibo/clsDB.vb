
Imports MySql.Data.MySqlClient

Public Class clsDB
    'DB操作のためのクラス

    'DB接続のための変数宣言
    Public conn As MySqlConnection 'DB接続のインスタンス
    Public cmd As MySqlCommand 'SQL実行の準備のインスタンス
    Public dr As MySqlDataReader ''DBから取得したデータ

    '接続文字列(定数)
    Public Const connectionString As String = "server=127.0.0.1;port=3307;Database=kakeibo;user id=root;password=1234"

    'SQL実行文
    Public sqlStr As String

    '*************************************************************************************************
    'DB関連関数

    'DB接続の関数
    Public Sub openDB()
        conn = New MySqlConnection(connectionString)
        conn.Open()
    End Sub

    'DB切断の関数
    Public Sub closeDB()
        conn.Close()
    End Sub

    'SQL実行
    Public Function executeSQL(sqlStr As String)
        cmd = New MySqlCommand(sqlStr, conn)
        'SQL文実行
        dr = cmd.ExecuteReader
        Return dr
    End Function

End Class
