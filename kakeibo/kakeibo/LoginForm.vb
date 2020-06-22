Imports MySql.Data.MySqlClient
Imports clsDB
Public Class LoginForm

    Dim userName As String
    Public user_id As Integer
    Dim password As String

    'clsDBのインスタンスを格納する変数
    Dim db As clsDB

    'DB接続のための変数宣言
    'Dim conn As MySqlConnection 'DB接続のインスタンス
    'Dim cmd As MySqlCommand 'SQL実行の準備のインスタンス
    'Dim dr As MySqlDataReader ''DBから取得したデータ

    '接続文字列(定数)
    'Const connectionString As String = "server=127.0.0.1;port=3307;Database=kakeibo;user id=root;password=1234"

    'SQL実行文
    'Dim sqlStr As String

    'DBから取得したデータを格納するdatatable
    Dim dt As DataTable

    ' TODO: 指定されたユーザー名およびパスワードを使用して、カスタム認証を実行するコードを挿入します 
    ' (https://go.microsoft.com/fwlink/?LinkId=35339 を参照)。  
    ' カスタム プリンシパルは、以下のように現在のスレッドのプリンシパルにアタッチできます:
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' この場合 CustomPrincipal は、認証を実行するのに使われる IPrincipal 実装です。
    ' これにより My.User は、ユーザー名および表示名などの CustomPrincipal オブジェクトに要約された ID 情報を
    ' 返します。


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        userName = txtUserName.Text.ToString
        password = txtPassword.Text.ToString

        db = New clsDB

        db.openDB()
        'sqlStr = "SELECT id, user_name, name FROM kakeibo.user WHERE user_name = @user_name AND password = @password"

        db.cmd = New MySqlCommand()
        db.cmd.CommandText = "SELECT id, user_name, name FROM kakeibo.user WHERE user_name = (@user_name) And password = (@password)"
        db.cmd.Parameters.AddWithValue("@user_name", userName)

        db.cmd.Parameters.AddWithValue("@password", password)


        db.cmd.Connection = db.conn

        db.dr = db.cmd.ExecuteReader()

        'datataleにDBから取得したデータを格納
        dt = New DataTable
        dt.Load(db.dr)

        'メインフォームに共有するユーザーIDを変数に格納
        user_id = dt.Rows(0)(0)

        Dim f As New fmMain
        f.Owner = Me

        If dt.Rows.Count = 0 Then
            MsgBox("パスワードとユーザー名が一致しません。")
        Else
            fmMain.ShowDialog(Me)
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

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
    'Public Function executeSQL(sqlStr As String)
    '    cmd = New MySqlCommand(sqlStr, conn)
    '    'SQL文実行
    '    dr = cmd.ExecuteReader
    '    Return dr
    'End Function

End Class
