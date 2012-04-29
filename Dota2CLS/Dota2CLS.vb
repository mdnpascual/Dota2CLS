
Public Class Dota2CLS


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Title = "Please Select a File"
        OpenFileDialog1.InitialDirectory = "C:\Program Files (x86)\Steam\steamapps\common\dota 2 beta\dota\replays" 'Default Location

        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim sr As New IO.StreamReader(OpenFileDialog1.OpenFile())                                               'Stream Reader to Read the large .txt
        TextBox2.Text = OpenFileDialog1.FileName.ToString()                                                     'Puts the Directory of the .txt in the disabled textbox


        ''''''''''''''''''''''''''Fetch CombatLogNames''''''''''''''''''''''''''
        Do Until sr.EndOfStream = True                                                                          'Read whole File
            Dim streambuff As String = sr.ReadLine                                                              'Array to Store CombatLogNames
            Dim CombatLogNames() As String

            If streambuff.Contains("CombatLogNames flags:0x1") Then                                             'Keyowrod to Filter CombatLogNames Packets in the .txt

                Dim check As String = streambuff                                                                'Duplicate of the Line being read
                Dim index1 As Char = check.Substring(check.IndexOf("(") + 1)                                    'v
                Dim index2 As Char = check.Substring(check.IndexOf("(") + 2)                                    'Used to bypass the first CombatLogNames packet that contain only 1 entry

                If (check.IndexOf("(") <> -1 And index1 <> "" And index2 <> " ") Then                           'Stricter Filters for CombatLogNames

                    Dim endCLN As Integer = 0                                                                   'Signifies the end of CombatLogNames Packet
                    Dim x As Integer = 0                                                                        'Counter for array

                    While (endCLN = 0 And streambuff <> "---- CNETMsg_Tick")                                    'Loops until the end keyword for CombatLogNames is seen

                        streambuff = sr.ReadLine                                                                'Reads a new line to flush out "CombatLogNames flags:0x1" which is unneeded
                        If (streambuff.Contains("---- CNETMsg_Tick") = True) Then

                            endCLN = 1                                                                          'Value change to determine end of CombatLogName packet

                        Else

                            ReDim Preserve CombatLogNames(x)                                                    'Resizes the array while preserving the values
                            CombatLogNames(x) = streambuff.Trim.Remove(streambuff.IndexOf("(") - 5).Remove(0, streambuff.Trim.Remove(streambuff.IndexOf("(")).IndexOf("'")) 'Additional filtering to get only valuable data
                            'String is Removed of Spaces (trim) then removed "0 bytes" (first remove) and removal of #xx value (2nd remove)
                            x += 1                                                                              '+1 to Array counter

                        End If
                    End While
                Else
                    'MsgBox("Something went wrong, Flame the coder of this program!!")                          'Bug Testing code that is disabled
                End If

            End If

            If (sr.EndOfStream = True) Then                                                                     'Used to flush CombatLogNames list in GUI

                Dim x = 0                                                                                       'Counter

                While (x <> CombatLogNames.Length)                                                              'Loops the whole array

                    TextBox1.AppendText("#" & x & ": " & CombatLogNames(x) & vbNewLine)                         'Displays the string in textbox 
                    x += 1

                End While
            End If
        Loop
        ''''''''''''''''''''''''''Fetch CombatLogNames''''''''''''''''''''''''''
        sr.Close()
        ''''''''''''''''''''''''''Fetch CombatLogEntries''''''''''''''''''''''''''
        'Type 0: ["timestamp"] "attackername" hits "targetname" with "inflictorname" for "value" damage (???->"health")
        'Type 1: [Timestamp] "attackername"'s "inflictorname" heals "targetname" for "value" health (???->health)
        'Type 2: [Timestamp] "targetname " receives "inflictorname" debuff from "attackername"
        'Type 3: [Timestamp] "targetname" loses "inflictorname" buff.
        'Type 5: [Timestamp] "targetname" is killed by "attackersname"'s "inflictorname"

        Dim sr2 As New IO.StreamReader(OpenFileDialog1.OpenFile())

        Dim streambuff2 As String = ""
        Dim CombatLogData() As String
        Dim Before1 As String = ""
        Dim Keyword As String = ""
        Dim KFound As Integer = 0

        Do Until sr2.EndOfStream = True

            Before1 = streambuff2
            streambuff2 = sr2.ReadLine()

            If streambuff2.Contains("name: ""dota_combatlog""") Then
                Keyword = Before1.Trim().Replace(" ", "")
                KFound = 1
            End If

            If (KFound = 1 And streambuff2.Contains(Keyword)) Then
                Dim x As Integer = 11
                Dim Line As String = sr2.ReadLine()
                Dim type As Integer = 0

                While (x > 0)
                    type = CInt(Line.Chars(Line.IndexOf(":") + 2).ToString)

                    Select Case type

                    End Select


                    x -= 1
                End While

            End If


        Loop


    End Sub
End Class
