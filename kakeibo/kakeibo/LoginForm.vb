Imports MySql.Data.MySqlClient
Public Class LoginForm

    Dim userName As String
    Dim password As String

    'DB�ڑ��̂��߂̕ϐ��錾
    Dim conn As MySqlConnection 'DB�ڑ��̃C���X�^���X
    Dim cmd As MySqlCommand 'SQL���s�̏����̃C���X�^���X
    Dim dr As MySqlDataReader ''DB����擾�����f�[�^

    '�ڑ�������(�萔)
    Const connectionString As String = "server=127.0.0.1;port=3307;Database=kakeibo;user id=root;password=1234"

    'SQL���s��
    Dim sqlStr As String

    'DB����擾�����f�[�^���i�[����datatable
    Dim dt As DataTable

    ' TODO: �w�肳�ꂽ���[�U�[������уp�X���[�h���g�p���āA�J�X�^���F�؂����s����R�[�h��}�����܂� 
    ' (https://go.microsoft.com/fwlink/?LinkId=35339 ���Q��)�B  
    ' �J�X�^�� �v�����V�p���́A�ȉ��̂悤�Ɍ��݂̃X���b�h�̃v�����V�p���ɃA�^�b�`�ł��܂�:
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' ���̏ꍇ CustomPrincipal �́A�F�؂����s����̂Ɏg���� IPrincipal �����ł��B
    ' ����ɂ�� My.User �́A���[�U�[������ѕ\�����Ȃǂ� CustomPrincipal �I�u�W�F�N�g�ɗv�񂳂ꂽ ID ����
    ' �Ԃ��܂��B


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        userName = txtUserName.Text.ToString
        password = txtPassword.Text.ToString


        Me.openDB()
        'sqlStr = "SELECT id, user_name, name FROM kakeibo.user WHERE user_name = @user_name AND password = @password"

        cmd = New MySqlCommand()
        cmd.CommandText = "SELECT id, user_name, name FROM kakeibo.user WHERE user_name = (@user_name) And password = (@password)"
        cmd.Parameters.AddWithValue("@user_name", userName)

        cmd.Parameters.AddWithValue("@password", password)


        cmd.Connection = conn

        dr = cmd.ExecuteReader()

        'datatale��DB����擾�����f�[�^���i�[
        dt = New DataTable
        dt.Load(dr)

        If dt.Rows.Count = 0 Then
            MsgBox("�p�X���[�h�ƃ��[�U�[������v���܂���B")
        Else
            fmMain.Show()
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    '*************************************************************************************************
    'DB�֘A�֐�

    'DB�ڑ��̊֐�
    Public Sub openDB()
        conn = New MySqlConnection(connectionString)
        conn.Open()
    End Sub

    'DB�ؒf�̊֐�
    Public Sub closeDB()
        conn.Close()
    End Sub

    'SQL���s
    'Public Function executeSQL(sqlStr As String)
    '    cmd = New MySqlCommand(sqlStr, conn)
    '    'SQL�����s
    '    dr = cmd.ExecuteReader
    '    Return dr
    'End Function

End Class
