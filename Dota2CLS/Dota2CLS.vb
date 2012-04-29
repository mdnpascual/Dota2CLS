
Public Class Dota2CLS

    Dim GlobalArr() As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Title = "Please Select a File"
        OpenFileDialog1.InitialDirectory = "C:\Program Files (x86)\Steam\steamapps\common\dota 2 beta\dota\replays" 'Default Location
        TextBox1.Clear()
        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As  _
        System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim startTime As DateTime = DateTime.Now
        Dim sr As New IO.StreamReader(OpenFileDialog1.OpenFile())                                               'Stream Reader to Read the large .txt
        TextBox2.Text = OpenFileDialog1.FileName.ToString()                                                     'Puts the Directory of the .txt in the disabled textbox

        ''''''''''''''''''''''''''Fetch CombatLogNames''''''''''''''''''''''''''
        Do Until sr.EndOfStream = True                                                                          'Read whole File
            Dim streambuff As String = sr.ReadLine                                                              'Array to Store CombatLogNames
            Dim CombatLogNames() As String
            'Try
            'Array.Clear(CombatLogNames, 0, CombatLogNames.Length)
            'Catch ex As Exception

            'End Try


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
                            CombatLogNames(x) = streambuff.Trim.Remove(streambuff.IndexOf("(") - 5).Remove(0, _
                            streambuff.Trim.Remove(streambuff.IndexOf("(")).IndexOf("'"))                       'Additional filtering to get only valuable data

                            x += 1                                                                              '+1 to Array counter

                        End If
                    End While
                Else
                    'MsgBox("Something went wrong, Flame the coder of this program!!")                          'Bug Testing code that is disabled
                End If

            End If

            If (sr.EndOfStream = True) Then

                ReDim GlobalArr(CombatLogNames.Length - 1)                                                      'Resizing the Global array to prime it for copying data
                Array.Copy(CombatLogNames, GlobalArr, CombatLogNames.Length)

            End If
        Loop
        ''''''''''''''''''''''''''Fetch CombatLogNames''''''''''''''''''''''''''
        sr.Close()
        ''''''''''''''''''''''''''Fetch CombatLogEntries''''''''''''''''''''''''''
        'Type 0: ["timestamp"] "attackername" hits "targetname" with "inflictorname" for "value" damage (???->"health")
        'Type 1: [Timestamp] "attackername"'s "inflictorname" heals "targetname" for "value" health (???->health)
        'Type 2: [Timestamp] "targetname " receives "inflictorname" debuff from "attackername"
        'Type 3: [Timestamp] "targetname" loses "inflictorname" buff.
        'Type 4: [Timestamp] "targetname" is killed by "attackersname"'s "inflictorname"

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
                Dim x As Integer = 10
                Dim Line As String = sr2.ReadLine()
                Dim type As Integer = 5
                Dim SRCname As Integer = 0
                Dim TGTname As Integer = 0
                Dim ATKname As Integer = 0
                Dim INFname As Integer = 0
                Dim ATIname As Integer = 0
                Dim TGIname As Integer = 0
                Dim Val As Integer = 0
                Dim HP As Integer = 0
                Dim time As String = 0
                Dim TGTSRCname As Integer = 0

                type = CInt(Line.Chars(Line.IndexOf(":") + 2).ToString)

                While (x > 0)

                    Select Case x
                        Case 10
                            SRCname = CInt(sr2.ReadLine().Substring(13))
                        Case 9
                            TGTname = CInt(sr2.ReadLine().Substring(13))
                        Case 8
                            ATKname = CInt(sr2.ReadLine().Substring(15))
                        Case 7
                            INFname = CInt(sr2.ReadLine().Substring(16))
                        Case 6
                            ATIname = CInt(sr2.ReadLine().Substring(19))
                        Case 5
                            TGIname = CInt(sr2.ReadLine().Substring(17))
                        Case 4
                            Val = CInt(sr2.ReadLine().Substring(8))
                        Case 3
                            HP = CInt(sr2.ReadLine().Substring(9))
                        Case 2
                            Dim subparts() As String = sr2.ReadLine().Substring(12).Split(".")
                            time = (Math.Floor((CInt(subparts(0)) / 60)).ToString & ":" & (CInt(subparts(0)) _
                            Mod 60).ToString("00") & "." & (subparts(1).Remove(2).ToString))
                        Case 1
                            TGTSRCname = CInt(sr2.ReadLine().Substring(19))
                        Case Else
                            MsgBox("CODER FAIL, ERROR? LOLOLOLOL")
                    End Select

                    x -= 1
                End While

                Select Case type
                    Case 0
                        TextBox1.AppendText("[" & time & "] " & GlobalArr(ATKname) & " hits " & GlobalArr(TGTname) _
                        & " with " & GlobalArr(INFname) & " for " & Val.ToString & " damage (" & (HP + Val).ToString & "->" & HP.ToString _
                        & ")." & vbNewLine)
                    Case 1
                        TextBox1.AppendText("[" & time & "] " & GlobalArr(ATKname) & "'s " & GlobalArr(INFname) _
                        & " heals " & GlobalArr(TGTname) & " for " & Val.ToString & " health (" & (HP - Val).ToString & "->" & HP.ToString _
                        & ")." & vbNewLine)
                    Case 2
                        TextBox1.AppendText("[" & time & "] " & GlobalArr(TGTname) & " receives " & GlobalArr(INFname) _
                        & " from " & GlobalArr(ATKname) & "." & vbNewLine)
                    Case 3
                        TextBox1.AppendText("[" & time & "] " & GlobalArr(TGTname) & " loses " & GlobalArr(INFname) _
                        & " ." & vbNewLine)
                    Case 4
                        TextBox1.AppendText("[" & time & "] " & GlobalArr(TGTname) & " is killed by " & _
                        GlobalArr(ATKname) & "'s " & GlobalArr(INFname) & "." & vbNewLine)
                    Case Else

                End Select
            End If


        Loop
        sr2.Close()
        Label2.Text = GlobalArr.Length & " CombatLogEntries"
        Dim executionTime As TimeSpan = DateTime.Now - startTime
        Label3.Text = ("Elapsed Time: " & executionTime.Minutes.ToString() & " minutes and " & executionTime.Seconds.ToString() & " seconds.")
        TextBox1.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim x = 0                                                                                       'Counter

        While (x <> GlobalArr.Length)                                                              'Loops the whole array

            Form1.TextBox1.AppendText(GlobalArr(x) & vbNewLine)
            x += 1

        End While

        Form1.Show()
    End Sub

    Private Sub Dota2CLS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Hide()
    End Sub
End Class
