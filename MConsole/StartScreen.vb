Imports System.IO
Imports System.Resources

Module StartScreen
    Public c As String 'Command text variable
    Public verstr As String = "0.5" 'Version
    Public fullver As String = "0.5.20190925" 'Full version
    Public synerr As String = "is not a command. Type help If you forget commands." 'Syntax error message
    Dim commandlist As String() = {"***", "***", "***"} 'Commands history
    Public commands As List(Of String) = New List(Of String)(commandlist)
    Public currentdir As String = "C:\Users\Martin\Documents\GitHub\MConsole\MConsole\bin\Debug\testfolder" 'AppDomain.CurrentDomain.BaseDirectory 'Current directory
    Public iconStrings() As String 'MConsole icon string array
    Public msgTickColor As ConsoleColor = ConsoleColor.Green 'Message default color, may changable by themes or settings manually (in future versions)
    Public msgWarningColor As ConsoleColor = ConsoleColor.Yellow
    Public msgErrorColor As ConsoleColor = ConsoleColor.Red
    Public msgInfoColor As ConsoleColor = ConsoleColor.DarkGray
    Public msgNewsColor As ConsoleColor = ConsoleColor.White
    Public msgQuestionColor As ConsoleColor = ConsoleColor.White

    'Public Sub of colorized text
    Sub ConsoleWriteColored(ByVal color As ConsoleColor, ByVal newline As Boolean, ByVal text As String, Optional ByVal arg0 As Object = Nothing, Optional ByVal arg1 As Object = Nothing, Optional ByVal arg2 As Object = Nothing)
        Dim originalColor As ConsoleColor = Console.ForegroundColor
        If My.Settings.Colorized Then
            Console.ForegroundColor = color
        End If
        If newline Then
            Console.WriteLine(text, arg0, arg1, arg2)
        Else
            Console.Write(text, arg0, arg1, arg2)
        End If
        If My.Settings.Colorized Then
            Console.ForegroundColor = originalColor
        End If
    End Sub

    'Public Sub of colorized centered text
    Sub CenterWriteColored(ByVal color As ConsoleColor, ByVal newline As Boolean, ByVal centered As Boolean, ByVal text As String, Optional ByVal arg0 As Object = Nothing, Optional ByVal arg1 As Object = Nothing, Optional ByVal arg2 As Object = Nothing)
        Dim originalColor As ConsoleColor = Console.ForegroundColor
        If My.Settings.Colorized Then
            Console.ForegroundColor = color
        End If
        If centered Then
            If newline Then
                Console.WriteLine(text.PadLeft((Console.WindowWidth / 2) + (text.Length / 2)), arg0, arg1, arg2)
            Else
                Console.Write(text.PadLeft((Console.WindowWidth / 2) + (text.Length / 2)), arg0, arg1, arg2)
            End If
            If My.Settings.Colorized Then
                Console.ForegroundColor = originalColor
            End If
        Else
            If newline Then
                Console.WriteLine(text, arg0, arg1, arg2)
            Else
                Console.Write(text, arg0, arg1, arg2)
            End If
            If My.Settings.Colorized Then
                Console.ForegroundColor = originalColor
            End If
        End If
    End Sub

    'Public Sub of colorized text message
    Sub MessageColored(ByVal genre As Integer, ByVal newline As Boolean, ByVal content As String, Optional ByVal arg0 As Object = Nothing, Optional ByVal arg1 As Object = Nothing, Optional ByVal arg2 As Object = Nothing)
        Dim originalColor As ConsoleColor = Console.ForegroundColor
        If Console.OutputEncoding.ToString.Contains("UTF8") Then
            If My.Settings.Colorized Then
                Select Case genre
                    Case 0
                        Console.ForegroundColor = msgTickColor
                        content = ChrW(10003) + " " + content 'Tick
                    Case 1
                        Console.ForegroundColor = msgWarningColor
                        content = ChrW(9888) + " " + content 'Warning
                    Case 2
                        Console.ForegroundColor = msgErrorColor
                        content = ChrW(10060) + " " + content 'Error
                    Case 3
                        Console.ForegroundColor = msgInfoColor
                        content = ChrW(9432) + " " + content 'Info
                    Case 4
                        Console.ForegroundColor = msgNewsColor
                        content = ChrW(9733) + " " + content 'News
                    Case 5
                        Console.ForegroundColor = msgQuestionColor
                        content = "? " + content 'Question
                    Case Else
                        content = content 'No character or used other invalid setting unexpectedly
                End Select
            Else
                Console.ForegroundColor = originalColor
                Select Case genre
                    Case 0
                        content = ChrW(10003) + " " + content 'Tick
                    Case 1
                        content = ChrW(9888) + " " + content 'Warning
                    Case 2
                        content = ChrW(10060) + " " + content 'Error
                    Case 3
                        content = ChrW(9432) + " " + content 'Info
                    Case 4
                        content = ChrW(9733) + " " + content 'News
                    Case 5
                        content = "? " + content 'Question
                    Case Else
                        content = content 'No character or used other invalid setting unexpectedly
                End Select
            End If
        Else
            If My.Settings.Colorized Then
                Select Case genre
                    Case 0
                        Console.ForegroundColor = msgTickColor 'Tick
                    Case 1
                        Console.ForegroundColor = msgWarningColor 'Warning
                    Case 2
                        Console.ForegroundColor = msgErrorColor 'Error
                    Case 3
                        Console.ForegroundColor = msgInfoColor 'Info
                    Case 4
                        Console.ForegroundColor = msgNewsColor 'News
                    Case 5
                        Console.ForegroundColor = msgQuestionColor 'Question
                    Case Else
                        content = content 'No character or used other invalid setting unexpectedly
                End Select
            Else
                Console.ForegroundColor = originalColor 'No character set are allowed to use in non-UTF8 text encoding enviromnent
            End If
        End If
        If newline Then
            Console.WriteLine(content, arg0, arg1, arg2)
        Else
            Console.Write(content, arg0, arg1, arg2)
        End If
        If My.Settings.Colorized Then
            Console.ForegroundColor = originalColor
        End If
    End Sub

    Sub Main()
        Console.OutputEncoding = Text.Encoding.UTF8
        'Console.WriteLine("New encoding: {0}", Console.OutputEncoding.ToString)
        'ConsoleWriteColored(ConsoleColor.Red, True, "Testing...")
        'Console.ReadKey()

        'CheckFile()

        'My.Settings.Colorized = True
        'My.Settings.themeStatus = True
        ThemeSelector(My.Settings.selectedTheme)
        'Debug.Write("Colorized: ")
        'Debug.WriteLine(My.Settings.Colorized)
        'Debug.Write("Themed: ")
        'Debug.WriteLine(My.Settings.themeStatus)

        'Threading.Thread.Sleep(2000)
        'Console.Clear()

        Console.Title = "Welcome To MConsole..."
        Console.Clear()



        iconStrings = {"-................................................-",
             "-````````````````````````````````````````````````-",
         "-````````````````````````````````````````````````-",
         "-````````````````````````````````````````````````-",
         "-````````````````````````````````````````````````-",
         "-````````````````````````````````````````````````-",
         "-````````````````-ooo/``````/ooo-````````````````-",
         "-````````````````+ssss.````.ssss+````````````````-",
         "-```````````````-sssss/````+sssss-```````````````-",
         "-````````.:++```+ssssss.``.ssssss+```/+:.````````-",
         "-`````-/osso/``-sssssss/``+sssssss-``:osso/-`````-",
         "-`.:+ssso/-````+ssssssss.-ssssssss+````-/+sss+:.`-",
         "-/sssso-``````-sssss:sss++ss++sssss-``````-ossss/-",
         "-``-/osso/-.``+sssso`/ssssss.-sssss+```-/osso/-.`-",
         "-`````.:+sss/-sssss-`.sssss/``+sssss-:sss+/-`````-",
         "-````````.-/++ssss+```/ssss.``.sssss+/+:.````````-",
         "-```````````-sssss-```.sss/````+sssss-```````````-",
         "-```````````+ssss+`````/ss.````.sssss+```````````-",
         "-``````````.ooooo-`````.+/``````/ooooo.``````````-",
         "-````````````````````````````````````````````````-",
         "-````````````````````````````````````````````````-",
         "-````````````````````````````````````````````````-",
         "-````````````````````````````````````````````````-",
         "-````````````````````````````````````````````````-",
         "-................................................-"}




        If My.Settings.centeredTitle Then
            For Each i As String In iconStrings
                CenterWriteColored(ConsoleColor.Blue, True, True, i)
            Next
            CenterWriteColored(ConsoleColor.DarkGray, True, True, "MConsole v.{0} Pre-alpha", verstr)
            CenterWriteColored(ConsoleColor.DarkGray, True, True, "A command console based on VB.net.")
            CenterWriteColored(ConsoleColor.DarkGray, True, True, "Copyright (c) 2018-2019 Martin C.")
            CenterWriteColored(ConsoleColor.DarkGray, True, True, "This Console is still in under construction.")
        Else
            For Each i As String In iconStrings
                ConsoleWriteColored(ConsoleColor.Blue, True, i)
            Next
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "MConsole v.{0} Pre-alpha", verstr)
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "A command console based on VB.net.")
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "Copyright (c) 2018-2019 Martin C.")
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "This Console is still in under construction.")
        End If
        Threading.Thread.Sleep(2000)
        Console.Clear()
        MainTitle()
    End Sub

    Sub MainTitle()
        If My.Settings.titleStatus = True Then
            Console.Title = "MConsole Pre-alpha - " + My.Settings.titleContent
        Else
            Console.Title = "MConsole Pre-alpha"
        End If
        If My.Settings.centeredTitle Then

            CenterWriteColored(ConsoleColor.DarkGray, True, True, "MConsole v.{0} Pre-alpha", verstr)
            CenterWriteColored(ConsoleColor.DarkGray, True, True, "Copyright (c) 2018-2019 Martin C.")

        Else

            ConsoleWriteColored(ConsoleColor.DarkGray, True, "MConsole v.{0} Pre-alpha", verstr)
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "Copyright (c) 2018-2019 Martin C.")

        End If
        Threading.Thread.Sleep(500)
        My.Settings.username = Environment.UserName
        If My.Settings.greetingsStatus = True Then
            Try
                Console.WriteLine(My.Settings.greetings, My.Settings.username)
            Catch ex As Exception

            End Try
        Else
            Select Case Date.Now.ToString("HH")
                Case 0 To 11
                    Console.WriteLine("Good morning, {0}, welcome to MConsole.", My.Settings.username)
                Case 12 To 14
                    Console.WriteLine("Good afternoon, {0}, welcome to MConsole.", My.Settings.username)
                Case 18 To 23
                    Console.WriteLine("Good evening, {0}, welcome to MConsole.", My.Settings.username)
                Case Else
                    Console.WriteLine("Hi there, {0}, welcome to MConsole.", My.Settings.username)
            End Select
        End If



        Dim r As Random = New Random
        Dim FinishedList As New List(Of String)
        Dim Lines = My.Resources.tips.Split(vbCrLf)
        Dim temp As String = ""
        For Each line In Lines
            temp = line.Replace(vbLf, "")
            If Not String.IsNullOrWhiteSpace(temp) Then
                FinishedList.Add(temp)
            End If
        Next
        Dim listindex As Integer = Int(r.Next(0, FinishedList.Count))
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Tips: {0}", FinishedList.Item(listindex))


        'Console.WriteLine("Hi there, {0}, welcome to MConsole", My.Settings.username)
        'Console.WriteLine("Hours now: {0}", CInt(Date.Now.ToString("HH")))
        If My.Settings.ssLocationDisp = True Then
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "Location: {0}", currentdir)
        End If
        MainConsole()
    End Sub
End Module
