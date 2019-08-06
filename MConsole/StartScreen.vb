Module StartScreen
    Public c As String 'Command text variable
    Public verstr As String = "0.4"
    Public fullver As String = "0.4.20190806"
    Public synerr As String = " is not a command. Type help if you forget commands." 'Syntax error message
    Public d As Boolean
    Dim commandlist As String() = {"***", "***", "***"}
    Public commands As List(Of String) = New List(Of String)(commandlist)

    Sub Main()
        Console.Title = "Welcome to MConsole..."
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
        Console.WriteLine("MConsole v." + verstr + " Pre-alpha")
        Console.WriteLine("A command console based on VB.net.")
        Console.WriteLine("Copyright (c) 2018-2019 Martin C.")
        Console.WriteLine("This Console is still in under construction.")
        Threading.Thread.Sleep(2000)
        Console.Clear()
        MainTitle()
    End Sub
    Sub MainTitle()
        Console.Title = "MConsole Pre-alpha"
        Console.WriteLine("MConsole v." + verstr + " Pre-alpha")
        Console.WriteLine("Copyright (c) 2018-2019 Martin C.")
        Threading.Thread.Sleep(500)
        Console.WriteLine("Location: " + AppDomain.CurrentDomain.BaseDirectory)
        MainConsole()
    End Sub
End Module
