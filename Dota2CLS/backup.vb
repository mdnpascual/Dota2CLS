Select Case type                                                                                'This Case now Translate the Dem_Packet to Combat Log Sentence
                    Case 0
                        'SearchableRichTextBox1.AppendText("[" & time & "] " & GlobalArr(ATKname) & " hits " & GlobalArr(TGTname) _
                        '& " with " & GlobalArr(INFname) & " for ")
                        'AppendText(Val.ToString, Color.DarkRed, Color.Transparent, False)
                        'SearchableRichTextBox1.AppendText(" damage (" & (HP + Val).ToString & "->" & HP.ToString _
                        '& ")." & vbNewLine)

                        'SearchableRichTextBox1.AppendText("[" & time & "] " & GlobalArr(ATKname) & " hits " & GlobalArr(TGTname) _
                        '& " with " & GlobalArr(INFname) & " for " & Val.ToString & " damage (" & (HP + Val).ToString & "->" & HP.ToString _
                        '& ")." & vbNewLine)

                        'AddStringSlow("[" & time & "] " & GlobalArr(ATKname) & " hits " & GlobalArr(TGTname) _
                        '& " with " & GlobalArr(INFname) & " for " & Val.ToString & " damage (" & (HP + Val).ToString & "->" & HP.ToString _
                        '& ")." & vbNewLine)

                        AddStringFastest("[" & time & "] " & GlobalArr(ATKname) & " hits " & GlobalArr(TGTname) _
                        & " with " & GlobalArr(INFname) & " for " & Val.ToString & " damage (" & (HP + Val).ToString & "->" & HP.ToString _
                        & ")." & vbNewLine)
                    Case 1
                        'SearchableRichTextBox1.AppendText("[" & time & "] " & GlobalArr(ATKname) & "'s " & GlobalArr(INFname) _
                        '& " heals " & GlobalArr(TGTname) & " for " & Val.ToString & " health (" & (HP - Val).ToString & "->" & HP.ToString _
                        '& ")." & vbNewLine)

                        'AddStringSlow("[" & time & "] " & GlobalArr(ATKname) & " hits " & GlobalArr(TGTname) _
                        '& " with " & GlobalArr(INFname) & " for " & Val.ToString & " damage (" & (HP + Val).ToString & "->" & HP.ToString _
                        '& ")." & vbNewLine)

                        AddStringFastest("[" & time & "] " & GlobalArr(ATKname) & "'s " & GlobalArr(INFname) _
                        & " heals " & GlobalArr(TGTname) & " for " & Val.ToString & " health (" & (HP - Val).ToString & "->" & HP.ToString _
                        & ")." & vbNewLine)
                    Case 2
                        'SearchableRichTextBox1.AppendText("[" & time & "] " & GlobalArr(TGTname) & " receives " & GlobalArr(INFname) _
                        '& " from " & GlobalArr(ATKname) & "." & vbNewLine)

                        'AddStringSlow("[" & time & "] " & GlobalArr(ATKname) & " hits " & GlobalArr(TGTname) _
                        '& " with " & GlobalArr(INFname) & " for " & Val.ToString & " damage (" & (HP + Val).ToString & "->" & HP.ToString _
                        '& ")." & vbNewLine)

                        AddStringFastest("[" & time & "] " & GlobalArr(TGTname) & " receives " & GlobalArr(INFname) _
                        & " from " & GlobalArr(ATKname) & "." & vbNewLine)
                    Case 3
                        'SearchableRichTextBox1.AppendText("[" & time & "] " & GlobalArr(TGTname) & " loses " & GlobalArr(INFname) _
                        '& " ." & vbNewLine)

                        'AddStringSlow("[" & time & "] " & GlobalArr(TGTname) & " loses " & GlobalArr(INFname) _
                        '& " ." & vbNewLine)

                        AddStringFastest("[" & time & "] " & GlobalArr(TGTname) & " loses " & GlobalArr(INFname) _
                        & " ." & vbNewLine)
                    Case 4
                        'SearchableRichTextBox1.AppendText("[" & time & "] " & GlobalArr(TGTname) & " is killed by " & _
                        'GlobalArr(ATKname) & "'s " & GlobalArr(INFname) & "." & vbNewLine)

                        'AddStringSlow("[" & time & "] " & GlobalArr(ATKname) & " hits " & GlobalArr(TGTname) _
                        '& " with " & GlobalArr(INFname) & " for " & Val.ToString & " damage (" & (HP + Val).ToString & "->" & HP.ToString _
                        '& ")." & vbNewLine)

                        AddStringFastest("[" & time & "] " & GlobalArr(TGTname) & " is killed by " & _
                        GlobalArr(ATKname) & "'s " & GlobalArr(INFname) & "." & vbNewLine)
                    Case Else