Module StartScreen
    Public c As String 'Command text variable
    Public verstr As String = "0.4" 'Version
    Public fullver As String = "0.4.20190812" 'Full version
    Public synerr As String = " Is Not a command. Type help If you forget commands." 'Syntax error message
    'Public dev As Boolean = False 'Settings: Dev Mode
    'Public locationdisp As Boolean = True  'Settings: Enable/Disable location display
    'Public recCommand As Boolean = True
    Dim commandlist As String() = {"***", "***", "***"} 'Commands history
    Public commands As List(Of String) = New List(Of String)(commandlist)
    Public currentdir As String = AppDomain.CurrentDomain.BaseDirectory 'Current directory

    Sub Main()
        Console.Title = "Welcome To MConsole..."
        Console.Clear()
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
        If My.Settings.ssLocationDisp = True Then
            Console.WriteLine("Location: {0}", currentdir)
        End If
        MainConsole()
    End Sub
End Module
