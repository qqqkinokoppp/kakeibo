Public Class LoginForm

    ' TODO: �w�肳�ꂽ���[�U�[������уp�X���[�h���g�p���āA�J�X�^���F�؂����s����R�[�h��}�����܂� 
    ' (https://go.microsoft.com/fwlink/?LinkId=35339 ���Q��)�B  
    ' �J�X�^�� �v�����V�p���́A�ȉ��̂悤�Ɍ��݂̃X���b�h�̃v�����V�p���ɃA�^�b�`�ł��܂�:
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' ���̏ꍇ CustomPrincipal �́A�F�؂����s����̂Ɏg���� IPrincipal �����ł��B
    ' ����ɂ�� My.User �́A���[�U�[������ѕ\�����Ȃǂ� CustomPrincipal �I�u�W�F�N�g�ɗv�񂳂ꂽ ID ����
    ' �Ԃ��܂��B

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
