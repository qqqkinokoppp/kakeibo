Module Module1

    '引数をSHA56でハッシュ化する

    Function hash(str As String)
        Dim origByte As Byte() = System.Text.Encoding.UTF8.GetBytes(str)

        Dim sha256 As System.Security.Cryptography.SHA256 = New System.Security.Cryptography.SHA256CryptoServiceProvider()
        Dim hashValue As Byte() = sha256.ComputeHash(origByte)
        'byte型配列を16進数の文字列に変換
        Dim result As New System.Text.StringBuilder()
        Dim b As Byte
        For Each b In hashValue
            result.Append(b.ToString("x2"))
        Next

        Dim result2 As String = result.ToString

        Return result2

    End Function
End Module
