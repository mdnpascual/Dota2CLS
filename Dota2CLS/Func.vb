Module Func

    Public Sub AddStringFastest(ByVal YourString As String)
        Dota2CLS.SearchableRichTextBox1.SelectionStart = 2000000000
        Dota2CLS.SearchableRichTextBox1.SelectionColor = Color.Silver
        Dota2CLS.SearchableRichTextBox1.SelectedText = YourString
    End Sub


    Public Sub AppendText(ByVal text As String, ByVal ForegroundColor As Color)
        'text = text & vbNewLine
        Dim start As Integer = Dota2CLS.SearchableRichTextBox1.TextLength
        'Dota2CLS.SearchableRichTextBox1.AppendText(text)
        AddStringFastest(text)

        Dota2CLS.SearchableRichTextBox1.Select(start, text.Length)

        Dota2CLS.SearchableRichTextBox1.SelectionColor = ForegroundColor

        'Dota2CLS.SearchableRichTextBox1.SelectionLength = 0
        If Dota2CLS.CheckBox2.Checked = True Then
            Dota2CLS.SearchableRichTextBox1.ScrollToCaret()
            Dota2CLS.SearchableRichTextBox1.Refresh()
        End If
    End Sub

    Public Sub AddStringSlow(ByVal YourString As String)
        Dota2CLS.SearchableRichTextBox1.SelectionStart = Len(Dota2CLS.SearchableRichTextBox1.Text)
        Dota2CLS.SearchableRichTextBox1.SelectedText = YourString
    End Sub

End Module
