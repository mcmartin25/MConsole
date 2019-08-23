Imports System.IO

Module StartScreen
    Public c As String 'Command text variable
    Public verstr As String = "0.4" 'Version
    Public fullver As String = "0.4.20190818" 'Full version
    Public synerr As String = " Is Not a command. Type help If you forget commands." 'Syntax error message
    'Public dev As Boolean = False 'Settings: Dev Mode
    'Public locationdisp As Boolean = True  'Settings: Enable/Disable location display
    'Public recCommand As Boolean = True
    Dim commandlist As String() = {"***", "***", "***"} 'Commands history
    Public commands As List(Of String) = New List(Of String)(commandlist)
    Public currentdir As String = AppDomain.CurrentDomain.BaseDirectory 'Current directory

    Sub CheckFile()
        If Not Directory.Exists(currentdir + "settings") Then
            Directory.CreateDirectory(currentdir + "settings")
        End If
        If Not File.Exists(currentdir + "settings\settings.xml") Then
            CreateConfig(currentdir + "settings\settings.xml")
            'File.Create(currentdir + "settings\settings.xml")
            'WriteConfig(currentdir + "settings\settings.xml")
        End If
        If File.Exists(currentdir + "settings\settings.xml") Then
            ReadConfig(currentdir + "settings\settings.xml")
        End If
        Console.ReadKey()
    End Sub

    Sub Main()
        'CheckFile()
        Console.Title = "Welcome To MConsole..."
        Console.Clear()
        If My.Settings.DevMode = True Then
            Console.ForegroundColor = ConsoleColor.Blue
        End If
        Console.WriteLine("-................................................-")
        Console.WriteLine("-````````````````````````````````````````````````-")
        Console.WriteLine("-````````````````````````````````````````````````-")
        Console.WriteLine("-````````````````````````````````````````````````-")
        Console.WriteLine("-````````````````````````````````````````````````-")
        Console.WriteLine("-````````````````````````````````````````````````-")
        Console.WriteLine("-````````````````-ooo/``````/ooo-````````````````-")
        Console.WriteLine("-````````````````+ssss.````.ssss+````````````````-")
        Console.WriteLine("-```````````````-sssss/````+sssss-```````````````-")
        Console.WriteLine("-````````.:++```+ssssss.``.ssssss+```/+:.````````-")
        Console.WriteLine("-`````-/osso/``-sssssss/``+sssssss-``:osso/-`````-")
        Console.WriteLine("-`.:+ssso/-````+ssssssss.-ssssssss+````-/+sss+:.`-")
        Console.WriteLine("-/sssso-``````-sssss:sss++ss++sssss-``````-ossss/-")
        Console.WriteLine("-``-/osso/-.``+sssso`/ssssss.-sssss+```-/osso/-.`-")
        Console.WriteLine("-`````.:+sss/-sssss-`.sssss/``+sssss-:sss+/-`````-")
        Console.WriteLine("-````````.-/++ssss+```/ssss.``.sssss+/+:.````````-")
        Console.WriteLine("-```````````-sssss-```.sss/````+sssss-```````````-")
        Console.WriteLine("-```````````+ssss+`````/ss.````.sssss+```````````-")
        Console.WriteLine("-``````````.ooooo-`````.+/``````/ooooo.``````````-")
        Console.WriteLine("-````````````````````````````````````````````````-")
        Console.WriteLine("-````````````````````````````````````````````````-")
        Console.WriteLine("-````````````````````````````````````````````````-")
        Console.WriteLine("-````````````````````````````````````````````````-")
        Console.WriteLine("-````````````````````````````````````````````````-")
        Console.WriteLine("-................................................-")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("MConsole v.{0} Pre-alpha", verstr)
        Console.WriteLine("A command console based on VB.net.")
        Console.WriteLine("Copyright (c) 2018-2019 Martin C.")
        Console.WriteLine("This Console is still in under construction.")
        Threading.Thread.Sleep(2000)
        Console.Clear()
        MainTitle()
    End Sub
    Sub MainTitle()
        Console.Title = "MConsole Pre-alpha"
        Console.WriteLine("MConsole v.{0} Pre-alpha", verstr)
        Console.WriteLine("Copyright (c) 2018-2019 Martin C.")
        Threading.Thread.Sleep(500)
        My.Settings.username = Environment.UserName
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
        Dim listindex As Integer = Int(r.Next(0, FinishedList.Count) - 1)
        Console.WriteLine("Tips: {0}", FinishedList.Item(listindex))


        'Console.WriteLine("Hi there, {0}, welcome to MConsole", My.Settings.username)
        'Console.WriteLine("Hours now: {0}", CInt(Date.Now.ToString("HH")))
        If My.Settings.ssLocationDisp = True Then
            Console.WriteLine("Location: {0}", currentdir)
        End If
        MainConsole()
    End Sub
End Module
