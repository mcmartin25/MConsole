Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation

Module Home
    Sub MainConsole()
        'Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory)
        Console.WriteLine()
        ConsoleWriteColored(ConsoleColor.DarkGray, False, ">")
        c = Console.ReadLine()
        If My.Settings.recCommand = True And c.ToLower <> "cv" And c.ToLower <> "commandview" And c.ToLower <> "history" Then
            commands.RemoveAt(2)
            commands.Insert(0, c)
        End If
        Select Case c.ToLower
            Case "about"
                About()
            Case "alldrives", "alldrivesinfo", "driveinfo", "driveslist", "drivelist", "currentfs", "fs", "filesystem", "fsinfo"
                Drivesinfo()
            Case "applog"
                Applog()
            Case "calc"
                Console.WriteLine("Calculator")
                Calc()
            Case "cls", "clear"
                Console.Clear()
                MainConsole()
            Case "copy"
                Copy()
            Case "copydir"
                Copydir()
            Case "cv", "commandview", "history"
                CommandView()
            Case "changedir", "cd", "chgdir"
                ChangeDir()
            Case "date"
                Datetimedisp("d")
            Case "dir", "dirlist", "list"
                Dir()
            Case "drives", "drivepart", "dpart", "dp"
                DrivePart()
            Case "echo", "say", "shout"
                EchoText()
            Case "editfile", "edit"
                EditFile()
            Case "exit"
                ExitMsg()
            Case "help"
                Info.Help()
            Case "makefile", "create"
                MakeFile()
            Case "md", "makedir", "newdir"
                Makedir()
            Case "move"
                Move()
            Case "movedir"
                Movedir()
            Case "network"
                Dim mode As ConsoleKeyInfo
                MessageColored(3, False, "Detailed or summary? [d/s]")
                mode = Console.ReadKey
                If mode.Key = ConsoleKey.D Then
                    NetworkInfo(True)
                ElseIf mode.key = ConsoleKey.s Then
                    NetworkInfo(False)
                End If
            Case "note"
                Note()
            Case "open"
                Open()
            Case "ping"
                Ping()
            Case "rename", "ren", "rn"
                Rename()
            Case "renamedir", "rendir", "rndir"
                Renamedir()
            Case "restart", "rs"
                RestartApp(False)
            Case "rnd", "random"
                Console.WriteLine(Rnd())
                MainConsole()
            Case "run"
                Run()
            Case "set", "setting", "settings"
                Settings(True)
            Case "sym", "htmlsym"
                HTMLSymbolConvert()
            Case "sysinfo", "systeminfo"
                Systeminfo()
            Case "time"
                Datetimedisp("t")
            Case "ver", "version"
                Ver()
            Case "where"
                WhereAmI()
            Case "who"
                WhoAmI()
            Case Else
                If c <> String.Empty Then
                    'Console.WriteLine(c + synerr)
                    MessageColored(2, True, "{0} {1}", c, synerr)
                    Threading.Thread.Sleep(500)
                    MainConsole()
                Else
                    MainConsole()
                End If
                Try
                    Throw New DivideByZeroException()
                Catch ex As Exception
                    'If (TypeOf Err.GetException() Is DivideByZeroException) Then
                    'Console.WriteLine("An error appeared in MConsole. Console progress is terminated. Restarting the console...")
                    MessageColored(2, True, "An error appeared in MConsole. Console progress is terminated. Restarting the console...")
                    Debug.Write("MConsole progress is terminated, due to entered invaild connand """)
                    Debug.Write(c)
                    Debug.Write(""". Now we are restarting the console... Error code: ") 'System.DivideByZeroException
                    Debug.WriteLine(ex.Message)
                    Threading.Thread.Sleep(2000)
                    Console.Clear()
                    Threading.Thread.Sleep(1000)
                    Main()
                    'End If
                End Try
        End Select
    End Sub

    Sub Calc()
        Dim temp As String
        Dim arraytemp() As String
        Dim c1 As Double
        Dim op As String
        Dim c2 As Double
        Dim last As Double
        temp = Console.ReadLine()
        If temp = "exit" Then
            MainConsole()
        ElseIf temp.Contains(" ") Then
            arraytemp = temp.Split(" ")
            If IsNumeric(arraytemp(0)) Then
                c1 = arraytemp(0)
            ElseIf arraytemp(0) = "last" Then
                Debug.WriteLine("last++")
                c1 = last
            End If
            If arraytemp(1) = "+" Or arraytemp(1) = "-" Or arraytemp(1) = "*" Or arraytemp(1) = "/" And arraytemp(1).Count = 1 Then
                op = arraytemp(1)
            Else
                op = "+"
            End If
            If IsNumeric(arraytemp(2)) Then
                c2 = arraytemp(2)
            Else
                MessageColored(2, True, "Calculate command error")
                MainConsole()
            End If
        Else
            MessageColored(2, True, "Calculate command error")
            MainConsole()
        End If

        If op = "+" Then
            last = c1 + c2
            Console.WriteLine(c1 + c2)
        ElseIf op = "-" Then
            last = c1 - c2
            Console.WriteLine(c1 - c2)
        ElseIf op = "*" Then
            last = c1 * c2
            Console.WriteLine(c1 * c2)
        ElseIf op = "/" Then
            last = c1 / c2
            Console.WriteLine(c1 / c2)
        End If
        For i = 0 To UBound(arraytemp)
            Debug.Write(i)
            Debug.Write(": ")
            Debug.WriteLine(arraytemp(i))
        Next

        Debug.Write("c1: ")
        Debug.WriteLine(c1)
        Debug.Write("op: ")
        Debug.WriteLine(op)
        Debug.Write("c2: ")
        Debug.WriteLine(c2)

        Debug.Write("last: ")
        Debug.WriteLine(last)

        Calc()
    End Sub

    Sub ChangeDir()
        Dim newdir As String
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "The current directory is {0}.", currentdir)
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Folder directory/location: ")
        newdir = Console.ReadLine()
        If (System.IO.Directory.Exists(newdir)) Then
            currentdir = newdir
            MessageColored(0, True, "Current directory changed to {1}.", currentdir)
        ElseIf newdir = String.Empty Then
            MainConsole()
        Else
            MessageColored(2, True, "Directory/folder {0} does not exist. Unable to change current directory.", newdir)
        End If
        MainConsole()
    End Sub

    Sub Copy()
        Dim filetarget, copydir As String
        Console.Write("Target file: {0}", currentdir)
        filetarget = Console.ReadLine()
        Console.Write("New file directory with new file name: ")
        copydir = Console.ReadLine()
        If Not File.Exists(copydir) Then
            My.Computer.FileSystem.CopyFile(currentdir + filetarget, copydir)
            MessageColored(0, True, " File {0} has been copied to new directory with file named {1}.", currentdir + filetarget, copydir)
        ElseIf filetarget = String.Empty Or copydir = String.Empty Then
            MessageColored(3, True, "Canceled.")
            MainConsole()
        Else
            MessageColored(0, True, "File {0} already exists. Unable to copy file to new directory.", copydir)
        End If
        MainConsole()
    End Sub

    Sub Copydir() 'Simliar as dir(copy mode)
        Dim dirname, newdir As String
        Console.Write("Folder directory/location and name: {0}", currentdir)
        dirname = Console.ReadLine()
        Console.Write("New folder directory/location: ")
        newdir = Console.ReadLine()
        If Not Directory.Exists(dirname) Then
            My.Computer.FileSystem.CopyDirectory(currentdir + dirname, newdir)
            MessageColored(0, True, "Directory/folder {0} has been copied to new directory {1}.", dirname, newdir)
        ElseIf dirname = String.Empty Or newdir = String.Empty Then
            MessageColored(3, True, "Canceled.")
            MainConsole()
        Else
            MessageColored(2, True, "Directory/folder {0} already exists. Unable to copy.", newdir)
        End If
        MainConsole()
    End Sub

    Sub Datetimedisp(ByVal mode As String)
        If mode = "d" Then
            ConsoleWriteColored(ConsoleColor.DarkGray, False, "Today's date: ")
            Console.WriteLine(Date.Now.ToShortDateString)
            ConsoleWriteColored(ConsoleColor.DarkGray, False, "Time: ")
            Console.WriteLine(Date.Now.ToLongTimeString)
        ElseIf mode = "t" Then
            ConsoleWriteColored(ConsoleColor.DarkGray, False, "Time now: ")
            Console.WriteLine(Date.Now.ToLongTimeString)
            ConsoleWriteColored(ConsoleColor.DarkGray, False, "Date: ")
            Console.WriteLine(Date.Now.ToShortDateString)
        End If
        MainConsole()
    End Sub

    Sub Dir()
        If Directory.GetDirectories(currentdir).Count = 0 And Directory.EnumerateFiles(currentdir).Count = 0 Then
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "No files or folders/directory included in folder/directory {0}", currentdir)
        Else
            For Each Dir As String In Directory.GetDirectories(currentdir)
                Console.WriteLine(Dir)
            Next
            For Each DirFile As String In Directory.EnumerateFiles(currentdir)
                Console.WriteLine(DirFile)
            Next
        End If
        MainConsole()
    End Sub

    Sub DrivePart()
        Dim drives = DriveInfo.GetDrives
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Partition(s) you have")
        For Each drive In drives
            Console.WriteLine(drive.Name)
        Next
        MainConsole()
    End Sub

    Sub Drivesinfo()
        Dim alldrive() As DriveInfo = DriveInfo.GetDrives()
        'Dim listnum As Integer = 0
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Type any available (logical) drives name (not label)")
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "These are all your available (logical) drive(s) you can check.")
        Console.WriteLine()

        For Each d As DriveInfo In alldrive
            Console.WriteLine(d.Name)
            'listnum += 1
        Next
        Console.WriteLine("***")
        c = Console.ReadLine()
        Select Case c.ToLower
            Case "exit", "back"
                MainConsole()
            Case Else
                Try
                    Dim driveName As String = c
                    Dim drive As New DriveInfo(driveName)

                    If drive.IsReady = True Then
                        Console.WriteLine("This drive is ready.")
                        Console.WriteLine("Drive Name: {0}", drive.Name)
                        Console.WriteLine("Volume Label: {0}", drive.VolumeLabel)
                        Console.WriteLine("Drive Type: {0}", drive.DriveType.ToString())
                        Console.WriteLine("Drive Format: {0}", drive.DriveFormat)
                        Console.WriteLine("Total Size: {0} GB", drive.TotalSize / 1024 / 1024 / 1024)
                        Console.WriteLine("Free Disk Space: {0} GB", (drive.TotalFreeSpace / 1024 / 1024 / 1024))
                    Else
                        Console.WriteLine("This drive isn't ready yet, or it doesn't exist. Please make sure this drive is already plugged in.")
                    End If
                    'Throw New ArgumentException()
                Catch ex As Exception
                    'If (TypeOf Err.GetException() Is ArgumentException) Then
                    Console.WriteLine("You typed an invalid drive name. Turning back to main screen...")
                    MainConsole()
                    'End If
                End Try
                MainConsole()
        End Select
    End Sub

    Sub EchoText()
        Dim ec As String
        Dim ecount, etime As Integer
        If c = "echo" Then
            ConsoleWriteColored(ConsoleColor.DarkGray, False, "echo>")
        ElseIf c = "say" Then
            ConsoleWriteColored(ConsoleColor.DarkGray, False, "say>")
        ElseIf c = "shout" Then
            ConsoleWriteColored(ConsoleColor.DarkGray, False, "shout>")
        End If
        ec = Console.ReadLine()
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "Display Time>")
        etime = Console.ReadLine()
        If Not ec = String.Empty Or etime = String.Empty Then
            Do Until ecount = etime
                Console.WriteLine(ec)
                ecount += 1
            Loop
        Else
            MainConsole()
        End If
        MainConsole()
    End Sub

    Sub ExitMsg()
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Do you want to exit? [Y/N]")
        Dim decide As ConsoleKeyInfo
        decide = Console.ReadKey()
        Select Case decide.Key
            Case ConsoleKey.Y
                Try
                    My.Settings.Save()
                    MessageColored(0, True, "Settings saved successfully.")
                Catch ex As Exception
                    MessageColored(2, True, "There is something wrong about saving config. Cannot save settings.")
                End Try
                Threading.Thread.Sleep(2000)
                Environment.Exit(0)
            Case ConsoleKey.N
                MainConsole()
            Case Else
                MainConsole()
        End Select
    End Sub

    Sub Fsinfo()
        Dim alldrive() As DriveInfo = IO.DriveInfo.GetDrives()
        Dim d As IO.DriveInfo
        For Each d In alldrive
            Console.WriteLine("Drive {0}", d.Name)
            If d.IsReady = True Then
                Console.WriteLine("File System: {0}", d.DriveFormat)
            End If
            Console.WriteLine("Drive type: {0}", d.DriveType)
        Next
        Console.WriteLine("Type allldrives to display detailed info.")
        MainConsole()
    End Sub

    Sub HTMLSymbolConvert()
        Dim text As String
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Please seperate by using space if need to convert from text to the HTML symbol code, or error will be encountered.")
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "Content: ")
        text = Console.ReadLine
        If text.StartsWith("&#") And text.EndsWith(";") And Not text.Contains("[A-Z]") Then
            'HTML Code > Text
            Dim stringArray() As String = text.Split(" ")
            Try
                For Each item In stringArray
                    Console.Write(Chr(System.Text.RegularExpressions.Regex.Replace(item, "[&#;]", String.Empty)))
                Next
            Catch ex As Exception
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "The value is not correct. Tips: If you want to convert a HTML code as a string, add a extra space after the semicolon.")
            End Try
        ElseIf IsNumeric(text) Then
            Try
                Console.WriteLine(ChrW(text))

            Catch ex As Exception
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "The value is not correct. Tips: If you want to convert a HTML code as a string, add a extra space.")
            End Try
        Else
            'Text > HTML Code
            Dim sb As New Text.StringBuilder()
            Dim charArray() As Char = text.ToCharArray()
            For i = 0 To charArray.Length - 1
                sb.Append((String.Format("&#{0};", Asc(charArray(i)))) & " ")
            Next
            Console.WriteLine(sb.ToString)
        End If

        MainConsole()
    End Sub

    Sub Listdir() 'Simliar as dir(list mode)
        'Dim d As String
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "This displays all of the entries of file system you using.")
        'Console.WriteLine("Please type a directory")
        'Console.Write("Directory: ")
        'd = Console.ReadLine()
        For Each Sentr As String In IO.Directory.EnumerateFileSystemEntries(currentdir)
            Console.WriteLine(Sentr)
        Next
        MainConsole()
    End Sub

    Sub Makedir()
        Dim dirname As String
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "New folder directory/location and name: {0}", currentdir)
        dirname = Console.ReadLine()
        If (Not System.IO.Directory.Exists(dirname)) Then
            IO.Directory.CreateDirectory(dirname)
            MessageColored(0, True, "New directory/folder has been created in directory/folder {0}.", dirname)
        ElseIf dirname = String.Empty Then
            MessageColored(3, True, "Discarded.")
            MainConsole()
        Else
            MessageColored(2, True, "Directory/folder {0} exists. Unable to create.", dirname)
        End If
        MainConsole()
    End Sub

    'EditFile sub. Move back when finished.
    Sub EditFile()
        Dim filetarget As String
        Dim content As String = Nothing
        Dim found As Boolean = False
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "File name with extension: {0}", currentdir)
        filetarget = Console.ReadLine()
        If Not String.IsNullOrEmpty(filetarget) Or File.Exists(currentdir + filetarget) Then
            found = True
        Else
            MessageColored(2, True, "This target filename is null or file not exist. Cannot open file.")
        End If
        If found Then
            content = File.ReadAllText(currentdir + filetarget)

            ConsoleWriteColored(ConsoleColor.DarkGray, True, "Content (Press Esc key to save or discard changes): ")

            Dim stringList() As String = content.Split(vbCrLf)

            Console.WriteLine()
            'Console.WriteLine("Final content: ")
            For Each line In stringList
                Console.Write(line)
            Next


            Dim cki As ConsoleKeyInfo
            Do
                cki = Console.ReadKey(True)
                If Char.IsLetterOrDigit(cki.KeyChar) Or Char.IsNumber(cki.KeyChar) Or Char.IsSymbol(cki.KeyChar) Or Char.IsWhiteSpace(cki.KeyChar) Then 'Or Char.IsSeparator(cki.KeyChar) Then

                    'If cki.Key = ConsoleKey.Enter Then
                    'Console.WriteLine()
                    'End If
                    Console.Write("{0}", cki.KeyChar)
                    content += cki.KeyChar
                End If
                If cki.Key = ConsoleKey.Backspace Then
                    If Console.CursorLeft > 0 Then
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop)
                        Console.Write(" ")
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop)
                        content = content.Remove(content.Length - 1, 1)
                    Else
                        'Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1)
                        'Console.Write(" ")
                        Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop)
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1)
                        content = content.Remove(content.Length - 1, 1)
                    End If
                    Debug.WriteLine("Left: {0}, Top: {1}", Console.CursorLeft, Console.CursorTop)
                End If
            Loop While cki.Key <> ConsoleKey.Escape



            MessageColored(3, False, "Save or discard changes of file {0}? [Y/N]", filetarget)
            Dim decide As ConsoleKeyInfo
            decide = Console.ReadKey
            Console.WriteLine()
            Console.WriteLine(currentdir + filetarget)
            Select Case decide.Key
                Case ConsoleKey.Y
                    Try
                            File.WriteAllText(currentdir + filetarget, content)
                        MessageColored(0, True, "File {0} saved.", filetarget)
                    Catch ex As Exception
                        MessageColored(2, True, "There is something wrong about saving file, usually due to the filename error. Cannot save file.")
                    End Try
                Case ConsoleKey.N
                    MessageColored(3, True, "Discarded.")
                Case Else
                    MessageColored(3, True, "Invalid key command. Discarded.")
            End Select

        End If
        MainConsole()
    End Sub

    Sub MakeFile()
        Dim filetarget As String
        Dim content As String = Nothing
        Dim tester As Boolean = False
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "New file name with extension: {0}", currentdir)
        filetarget = Console.ReadLine()
        If String.IsNullOrEmpty(filetarget) Or Not File.Exists(currentdir + filetarget) Then
            tester = True
            MessageColored(3, True, "This session will be a testing session, no file will will be saved.")
        End If
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Content (Press Esc key to save or discard changes): ")
        Dim cki As ConsoleKeyInfo
        Do
            cki = Console.ReadKey(True)
            If Char.IsLetterOrDigit(cki.KeyChar) Or Char.IsNumber(cki.KeyChar) Or Char.IsSymbol(cki.KeyChar) Or Char.IsWhiteSpace(cki.KeyChar) Then 'Or Char.IsSeparator(cki.KeyChar) Then

                'If cki.Key = ConsoleKey.Enter Then
                'Console.WriteLine()
                'End If
                Console.Write("{0}", cki.KeyChar)
                content += cki.KeyChar
            End If
            If cki.Key = ConsoleKey.Backspace Then
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop)
                Console.Write(" ")
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop)

                'Console.WriteLine(String.Join(", ", myList) + "\b\b")
                content = content.Remove(content.Length - 1, 1)
            End If
        Loop While cki.Key <> ConsoleKey.Escape

        Dim stringList() As String = content.Split(vbCrLf)

        Console.WriteLine()
        Console.WriteLine("Final content: ")
        For Each line In stringList

            Console.WriteLine(line)
        Next
        Console.WriteLine()
        If tester = False Then

            MessageColored(3, False, "Save or discard changes of file {0}? [Y/N]", filetarget)
            Dim decide As ConsoleKeyInfo
            decide = Console.ReadKey
            Console.WriteLine()
            Console.WriteLine(currentdir + filetarget)
            Select Case decide.Key
                Case ConsoleKey.Y
                    If Not File.Exists(currentdir + filetarget) Then
                        Try
                            File.WriteAllText(currentdir + filetarget, content)
                            MessageColored(0, True, "File {0} created and saved.", filetarget)
                        Catch ex As Exception
                            MessageColored(2, True, "There is something wrong about saving file, usually due to the filename error. Cannot create file.")
                        End Try
                    Else
                        MessageColored(2, True, "File {0} already exists in folder {1}. Cannot create file.", filetarget, currentdir)
                    End If
                Case ConsoleKey.N
                    MessageColored(3, True, "Discarded.")
                Case Else
                    MessageColored(3, True, "Invalid key command. Discarded.")
            End Select
        Else
            MessageColored(3, True, "Turn back to home screen...")
        End If


        MainConsole()
    End Sub

    Sub Move()
        Dim filetarget, movedir As String
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "Target file: {0}", currentdir)
        filetarget = Console.ReadLine()
        Console.Write("New file directory with new file name: ")
        movedir = Console.ReadLine()
        If Not File.Exists(movedir) Then
            My.Computer.FileSystem.MoveFile(currentdir + filetarget, movedir)
            MessageColored(0, True, "File {0} has been moved to new directory with file named {1}.", currentdir + filetarget, movedir)
        ElseIf filetarget = String.Empty Or movedir = String.Empty Then
            MessageColored(3, True, "Discarded.")
            MainConsole()
        Else
            MessageColored(2, True, "File {0} already exists. Unable to move file to new directory.", movedir)
        End If
        MainConsole()
    End Sub

    Sub Movedir() 'Simliar as move(dir mode)
        Dim dirname, newdir As String
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "Folder directory/location and name: {0}", currentdir)
        dirname = Console.ReadLine()
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "New folder directory/location: ")
        newdir = Console.ReadLine()
        If (Not Directory.Exists(dirname)) Then
            My.Computer.FileSystem.MoveDirectory(dirname, newdir)
            MessageColored(0, True, "Directory/folder {0} moved to new directory/folder {1}.", dirname, newdir)
        ElseIf dirname = String.Empty Or newdir = String.Empty Then
            MessageColored(3, True, "Discarded.")
            MainConsole()
        Else
            MessageColored(2, True, "Directory/folder {0} exists. Unable to move.", newdir)
        End If
        MainConsole()
    End Sub

    Sub NetworkInfo(ByVal detailed As Boolean)
        Dim computerprop As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipstat As IPGlobalStatistics = computerprop.GetIPv4GlobalStatistics
        Console.WriteLine()
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "This computer: ")
        Console.WriteLine(My.Computer.Name)
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "This computer host name on network: ")
        Console.WriteLine(computerprop.HostName)
        Console.WriteLine(computerprop.DomainName)
        If My.Computer.Network.IsAvailable Then
            MessageColored(0, True, "Your network is available.")
            'Console.WriteLine("DNS host name: {0}", System.Net.Dns.GetHostName)
            'Console.WriteLine("Network: {0}")

            Dim ipv4s As String = Dns.GetHostEntry(Dns.GetHostName).AddressList(0).MapToIPv4.ToString()
            Dim ipv4s2 As String = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(Function(a As IPAddress) Not a.IsIPv6LinkLocal AndAlso Not a.IsIPv6Multicast AndAlso Not a.IsIPv6SiteLocal).First().ToString()

            Dim ipv6s As String = Dns.GetHostEntry(Dns.GetHostName).AddressList(0).ToString()

            ConsoleWriteColored(ConsoleColor.DarkGray, False, "IPv4: ")
            Console.WriteLine("{0} or {1}", ipv4s, ipv4s2)

            ConsoleWriteColored(ConsoleColor.DarkGray, False, "IPv6: ")
            Console.WriteLine("IPv6: {0}", ipv6s)

            Console.WriteLine()

            If detailed Then

                Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces
                If nics.Length < 0 Or nics Is Nothing Then
                    ConsoleWriteColored(ConsoleColor.DarkGray, False, "No NICS")
                    Exit Sub
                End If

                For Each netadapter As NetworkInterface In nics
                    Dim intproperties As IPInterfaceProperties = netadapter.GetIPProperties()
                    Console.WriteLine(netadapter.Name)
                    Console.WriteLine(netadapter.Description)

                    Select Case netadapter.NetworkInterfaceType
                        Case 48
                            Console.WriteLine("")
                            Console.WriteLine("")
                            Console.WriteLine("")
                            Console.WriteLine("")
                            Console.WriteLine("")
                            Console.WriteLine("")
                            Console.WriteLine(" ______________")
                            Console.WriteLine("|\_____________\")
                            Console.WriteLine("\|___o__o__o___|")
                        Case 20, 21, 63
                            Console.WriteLine("   ____")
                            Console.WriteLine("/||    |```````|")
                            Console.WriteLine("|||    |```````|")
                            Console.WriteLine("|||    | o o o |")
                            Console.WriteLine("|||    | o o o |")
                            Console.WriteLine("|||    | o o o |")
                            Console.WriteLine("|||____| o o o |")
                            Console.WriteLine("||/____/_______|")
                            Console.WriteLine("|/____________/")
                        Case 71
                            Console.WriteLine("")
                            Console.WriteLine("")
                            Console.WriteLine("   ||   )))")
                            Console.WriteLine("   ||")
                            Console.WriteLine("   ||")
                            Console.WriteLine("   ||")
                            Console.WriteLine(" __||__________")
                            Console.WriteLine("|\_____________\")
                            Console.WriteLine("\|_____________|")
                        Case 144
                            Console.WriteLine("  ____________")
                            Console.WriteLine(" |\_______|````|")
                            Console.WriteLine(" |||``````|-  -|")
                            Console.WriteLine(" |||      |____|")
                            Console.WriteLine(" |||_______|  |")
                            Console.WriteLine(" \|________|  |")
                            Console.WriteLine("|\____\|__||  |\")
                            Console.WriteLine("||         |  ||")
                            Console.WriteLine("\|_________|  ||")
                        Case 6, 26, 69, 62, 117
                            Console.WriteLine("  ____________")
                            Console.WriteLine(" |\_______|`||`|")
                            Console.WriteLine(" |||``````| || |")
                            Console.WriteLine(" |||      |____|")
                            Console.WriteLine(" |||_______|  |")
                            Console.WriteLine(" \|________|  |")
                            Console.WriteLine("|\____\|__||  |\")
                            Console.WriteLine("||         |  ||")
                            Console.WriteLine("\|_________|  ||")
                        Case 237, 243, 244
                            Console.WriteLine("  ____________")
                            Console.WriteLine(" |\___________\")
                            Console.WriteLine(" |||`````````||")
                            Console.WriteLine(" |||         ||")
                            Console.WriteLine(" |||  ((( o )))")
                            Console.WriteLine(" |||     / \ ||")
                            Console.WriteLine(" |||    /   \||")
                            Console.WriteLine(" |||___/     \|")
                            Console.WriteLine(" \|___/_______\")
                        Case Else
                            Console.WriteLine("  ____________")
                            Console.WriteLine(" |\___________\")
                            Console.WriteLine(" |||`````````||")
                            Console.WriteLine(" |||         ||")
                            Console.WriteLine(" |||_________||")
                            Console.WriteLine(" \|___________|")
                            Console.WriteLine("|\____\|__|____\")
                            Console.WriteLine("||          oo |")
                            Console.WriteLine("\|_____________|")
                    End Select

                    Select Case netadapter.NetworkInterfaceType
                    'Some connection type may outdated/discontinued, 
                    'but may have some possibility reasons that why still support them, 
                    'that's why I put the full list from Microsoft website to here.
                        Case 94
                            Console.WriteLine("Asymmetric Digital Subscriber Line (ADSL)")
                        Case 37
                            Console.WriteLine("Asynchronous Transfer Mode (ATM)")
                        Case 20
                            Console.WriteLine("Basic rate interface Integrated Services Digital Network (ISDN)")
                        Case 6
                            Console.WriteLine("Ethernet (with IEEE standard 802.3)")
                        Case 26
                            Console.WriteLine("Ethernet 3 megabit/second connection (with IETF RFC 895 standard)")
                        Case 69
                            Console.WriteLine("Fast Ethernet connection with optical fiber (100Base-FX)")
                        Case 62
                            Console.WriteLine("Fast Ethernet connection over twisted pair (100Base-T)")
                        Case 15
                            Console.WriteLine("Fiber Distributed Data Interface (FDDI)")
                        Case 48
                            Console.WriteLine("Generic modem")
                        Case 117
                            Console.WriteLine("Gigabit Ethernet Connection")
                        Case 144
                            Console.WriteLine("High Performance Serial Bus")
                        Case 114
                            Console.WriteLine("Internet Protocol (IP) with Asynchronous Transfer Mode (ATM) combined")
                        Case 63
                            Console.WriteLine("Integrated Services Digital Network (ISDN)")
                        Case 24
                            Console.WriteLine("Loopback adapter")
                        Case 143
                            Console.WriteLine("Multirate Digital Subscriber Line")
                        Case 23
                            Console.WriteLine("Point-To-Point protocol (PPP)")
                        Case 21
                            Console.WriteLine("Primary rate interface Integrated Services Digital Network (ISDN)")
                        Case 95
                            Console.WriteLine("Rate Adaptive Digital Subscriber Line (RADSL)")
                        Case 28
                            Console.WriteLine("Serial Line Internet Protocol (SLIP) (with IETF RFC 1055 standard)")
                        Case 96
                            Console.WriteLine("Symmetric Digital Subscriber Line (SDSL)")
                        Case 9
                            Console.WriteLine("Token-Ring connection (with IEEE standard 802.5 standard)")
                        Case 131
                            Console.WriteLine("Tunnel connection")
                        Case 1
                            Console.WriteLine("Unknown interface")
                        Case 97
                            Console.WriteLine("Very High Data Rate Digital Subscriber Line (VDSL)")
                        Case 71
                            Console.WriteLine("Wireless LAN connection (with IEEE 802.11 standard)")
                        Case 237
                            Console.WriteLine("Mobile broadband interface for WiMax devices")
                        Case 243
                            Console.WriteLine("Mobile broadband interface for GSM-based devices")
                        Case 244
                            Console.WriteLine("Mobile broadband interface for CDMA-based devices")
                    End Select

                    Console.WriteLine("Adapter ID {0}", netadapter.Id)
                    If String.IsNullOrWhiteSpace(netadapter.GetPhysicalAddress.ToString) Then
                        Console.WriteLine("This adapter doesn't have a MAC address or unable to provide.")
                    Else
                        Console.WriteLine("This adapter's MAC address is {0}", netadapter.GetPhysicalAddress)
                    End If

                    'Console.WriteLine(netadapter.IsReceiveOnly)
                    Select Case netadapter.IsReceiveOnly
                        Case True
                            Console.WriteLine("This is a receive-only adapter.")
                        Case False
                            Console.WriteLine("This is not a receive-only adapter.")
                    End Select


                    Select Case netadapter.OperationalStatus.ToString
                        Case "Dormant"
                            Console.WriteLine("Not transmit yet, waiting for events")
                        Case "Down"
                            Console.WriteLine("Unable to transmit data")
                        Case "LowerLayerDown"
                            Console.WriteLine("Unable to transmit data due to runs on top of others")
                        Case "NotPresent"
                            Console.WriteLine("Not Present")
                        Case "Testing"
                            Console.WriteLine("Testing")
                        Case "Unknown"
                            Console.WriteLine("Unknown status")
                        Case "Up"
                            Console.WriteLine("Able to transmit data")
                    End Select
                    'Console.WriteLine("{0}", netadapter.OperationalStatus)

                    Select Case netadapter.OperationalStatus.ToString
                        Case "Down", "NotPresent"
                        Case Else
                            Select Case netadapter.Speed / 1024
                                Case Is < 100
                                    Console.WriteLine("Speed: {0} kbps", netadapter.Speed / 1000)
                                Case Is < 1000000
                                    Console.WriteLine("Speed: {0} Mbps", netadapter.Speed / 1000000)
                                Case Is < 10000000
                                    Console.WriteLine("Speed: {0} Gbps", netadapter.Speed / 1000000000)
                                Case Else
                                    Console.WriteLine("Speed: {0} bps", netadapter.Speed)
                            End Select
                    End Select


                    Select Case netadapter.SupportsMulticast
                        Case True
                            Console.WriteLine("This adapter supports multicast.")
                        Case False
                            Console.WriteLine("This adapter doesn't support multicast.")
                    End Select

                    Console.WriteLine()

                Next
            End If

            ConsoleWriteColored(ConsoleColor.DarkGray, True, "Inbound Packet Data:")
            Console.WriteLine("  ____________")
            Console.WriteLine(" |\___________\   <= Received: ")
            Console.WriteLine(" |||`````````||      {0}", ipstat.ReceivedPackets.ToString)
            Console.WriteLine(" |||         ||   => Delivered: ")
            Console.WriteLine(" |||_________||      {0}", ipstat.ReceivedPacketsDelivered.ToString)
            Console.WriteLine(" \|___________|    x Discarded:")
            Console.WriteLine("|\____\|__|____\     {0}", ipstat.ReceivedPacketsDiscarded.ToString)
            Console.WriteLine("||          oo | <=> Forwarded:")
            Console.WriteLine("\|_____________|     {0}", ipstat.ReceivedPacketsForwarded.ToString)

            Console.WriteLine()

        Else
            MessageColored(2, True, "Your network is unavailable.")
        End If
        MainConsole()
    End Sub

    Sub Note() 'ByVal title As String, ByVal content As String, ByVal remindtime As Date
        'Doesn't have file-save option yet
        ConsoleWriteColored(ConsoleColor.DarkGray, False, ">")
        c = Console.ReadLine
        Select Case c
            Case "create"
                Dim remindgenre As Integer '0 = reminder, 1 = event, 2 = note
                Dim title As String
                Dim content As String
                Dim remindtime As String
                Dim wellformat As Boolean = False
                Dim dateformat As Date
                Dim datetimediff As Long
                Dim keyinput As ConsoleKeyInfo
                MessageColored(3, True, "Reminder, event or note? [R/E/N]")
                keyinput = Console.ReadKey
                Select Case keyinput.Key
                    Case ConsoleKey.R
                        remindgenre = 0
                    Case ConsoleKey.E
                        remindgenre = 1
                    Case ConsoleKey.N
                        remindgenre = 2
                    Case Else
                        MessageColored(3, True, "Turning back to main screen...")
                        MainConsole()
                End Select
                Console.WriteLine()
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Title: ")
                title = Console.ReadLine
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Content: ")
                content = Console.ReadLine
                If remindgenre = 0 Or remindgenre = 1 Then
                    ConsoleWriteColored(ConsoleColor.DarkGray, True, "Date [MM/dd/yyyy]: ")
                    While Not wellformat
                        remindtime = Console.ReadLine
                        wellformat = Date.TryParseExact(remindtime, "MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, dateformat)
                    End While
                End If
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Reminder genre: ")
                Debug.WriteLine(remindgenre)
                Select Case remindgenre
                    Case 0
                        Debug.Write("Reminder result...")
                        If wellformat Then
                            datetimediff = DateDiff(DateInterval.Day, Date.Today, CDate(remindtime))
                            MessageColored(0, True, "Your reminder {0} has been created, {1} days from this event", title, datetimediff)
                        End If
                    Case 1
                        If wellformat Then
                            datetimediff = DateDiff(DateInterval.Day, Date.Today, CDate(remindtime))
                            MessageColored(0, True, "Your event {0} has been created, {1} days from this event", title, datetimediff)
                        End If
                    Case 2
                        MessageColored(0, True, "Saved.")
                End Select
            Case "cancel", "delete"
            Case "exit"
        End Select
        MainConsole()
    End Sub

    Sub Open()
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "Folder directory/File name (except executable): {0}", currentdir)
        Dim target As String = Console.ReadLine()
        Dim p() As Process = Process.GetProcessesByName(target)
        Dim ext As String = IO.Path.GetExtension(target)
        If p.Count > 0 Then
            Process.Start(currentdir + target)
            MainConsole()
        ElseIf target = String.Empty Or target = "\" Then
            Process.Start(currentdir + "\")
            MainConsole()
        ElseIf ext = ".cmd" Or
            ext = ".bin" Or
            ext = ".bat" Or
            ext = ".exe" Or
            ext = ".ex_" Or
            ext = ".ps1" Or
            ext = ".sct" Or
            ext = ".shb" Or
            ext = ".ws" Or
            ext = ".wsf" Or
            ext = ".ink" Then
            MessageColored(2, True, "Cannot run. Your file is an executable or may be a shortcut link to the an executable file. Please use run command instead.")
            MainConsole()
        Else
            MessageColored(0, True, "Cannot run. Your folder directory/file location may not vaild.")
            MainConsole()
        End If
    End Sub

    Sub Opendir() 'Simliar as open(dir mode) or changedir

    End Sub

    Sub Ping()
        Dim target As String
        Dim ipaddresssample As IPAddress
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "IP or URL: ")
        target = Console.ReadLine
        Dim isvalidip As Boolean = IPAddress.TryParse(target, ipaddresssample)
        Dim isvalidURL As Boolean = Uri.IsWellFormedUriString(target, UriKind.RelativeOrAbsolute)
        If isvalidip Then
            If My.Computer.Network.Ping(target) Then
                MessageColored(0, True, "Server {0} pinged successfully.", target)
            Else
                MessageColored(2, True, "Server {0} ping request timed out.", target)
            End If
        ElseIf isvalidURL Then
            If My.Computer.Network.Ping(target) Then
                MessageColored(0, True, "Server {0} pinged successfully.", target)
            Else
                MessageColored(2, True, "Server {0} ping request timed out.", target)
            End If
        ElseIf String.IsNullOrWhiteSpace(target) Then
            MessageColored(2, True, "This input cannot be empty.")
        Else
            MessageColored(2, True, "The address is not valid.")
        End If
        MainConsole()
    End Sub

    Sub Rename()
        Dim filetarget, rv As String
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "Target file: {0}", currentdir)
        filetarget = Console.ReadLine()
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "Rename to: ")
        rv = Console.ReadLine()
        If Not File.Exists(filetarget) Then
            My.Computer.FileSystem.RenameFile(currentdir + filetarget, rv)
            MessageColored(0, True, "Changed file to {0}.", rv)
        ElseIf filetarget = String.Empty Or rv = String.Empty Then
            MessageColored(3, True, "Rename changes discarded.")
            MainConsole()
        Else
            MessageColored(2, True, "File with name {0} already exists. Unable to rename file.", rv)
        End If
        MainConsole()
    End Sub

    Sub Renamedir() 'Simliar as rename(dir mode)
        Dim rv As String
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Target directory/folder: {0}", currentdir)
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "Rename to: ")
        rv = Console.ReadLine()
        If Not File.Exists(currentdir) Then
            My.Computer.FileSystem.RenameDirectory(currentdir, rv)
            Console.WriteLine("Changed directory/folder name to {0}.", rv)
        ElseIf rv = String.Empty Then
            MainConsole()
        Else
            Console.WriteLine("Directory/folder with name {0} already exists. Unable to rename.", rv)
        End If
        MainConsole()
    End Sub

    Sub RestartApp(ByVal msg As Boolean)
        If msg = True Then
            MessageColored(3, True, "You need to restart MConsole to take the effect, restart now? [Y/N]")
            Dim decide As ConsoleKeyInfo
            decide = Console.ReadKey()
            Select Case decide.Key
                Case ConsoleKey.N
                    Console.WriteLine()
                    ConsoleWriteColored(ConsoleColor.DarkGray, False, "Turning back to main screen...")
                    MainConsole()
                    'Exit Sub
                Case Else
                    My.Settings.Save()
                    Threading.Thread.Sleep(2000)
                    Console.Clear()
                    Threading.Thread.Sleep(1000)
                    Main()
            End Select
        Else
            My.Settings.Save()
            Threading.Thread.Sleep(2000)
            Console.Clear()
            Threading.Thread.Sleep(1000)
            Main()
        End If
    End Sub

    Sub Run()
        MessageColored(1, True, "Be aware that this action may harm your computer because not all application are safe!")
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "Run: ")
        Dim target As String = Console.ReadLine()
        Dim p() As Process = Process.GetProcessesByName(target)
        Dim ext As String = IO.Path.GetExtension(target)
        If p.Count > 0 Then
            Process.Start(target)
            MainConsole()
        ElseIf target = String.Empty Then
            MainConsole()
        Else
            MessageColored(2, True, "Cannot run. Your folder directory/file location may not vaild.")
            MainConsole()
        End If
    End Sub

    Sub Systeminfo()
        MessageColored(3, True, "System info")
        Dim osname As String = My.Computer.Info.OSFullName
        Select Case True
            Case osname.Contains("XP")
                Select Case True
                    Case osname.Contains("Pro") Or osname.Contains("專業")
                        Console.WriteLine("Windows XP Professional")
                    Case osname.Contains("Home") Or osname.Contains("家用")
                        Console.WriteLine("Windows XP Home")
                    Case Else
                        Console.WriteLine("Windows XP")
                End Select
            Case osname.Contains("Vista")
                Select Case True
                    Case osname.Contains("Starter") Or osname.Contains("簡易")
                        Console.WriteLine("Windows Vista Starter")
                    Case osname.Contains("Home") Or osname.Contains("家用")
                        Console.WriteLine("Windows Vista Home")
                    Case osname.Contains("Pro") Or osname.Contains("專業")
                        Console.WriteLine("Windows Vista Pro")
                    Case osname.Contains("Ultimate") Or osname.Contains("旗艦")
                        Console.WriteLine("Windows Vista Ultimate")
                    Case Else
                        Console.WriteLine("Windows Vista")
                End Select
            Case osname.Contains("7")
                Select Case True
                    Case osname.Contains("Starter") Or osname.Contains("簡易")
                        Console.WriteLine("Windows 7 Starter")
                    Case osname.Contains("Home") Or osname.Contains("家用")
                        Console.WriteLine("Windows 7 Home")
                    Case osname.Contains("Pro") Or osname.Contains("專業")
                        Console.WriteLine("Windows 7 Pro")
                    Case osname.Contains("Ultimate") Or osname.Contains("旗艦")
                        Console.WriteLine("Windows 7 Ultimate")
                    Case Else
                        Console.WriteLine("Windows 7")
                End Select
            Case osname.Contains("8")
                Select Case True
                    Case osname.Contains("Pro") Or osname.Contains("專業")
                        Console.WriteLine("Windows 8 Ultimate")
                    Case Else
                        Console.WriteLine("Windows 8")
                End Select
            Case osname.Contains("8.1")
                Console.WriteLine("Windows 8.1")
            Case osname.Contains("10")
                Select Case True
                    Case osname.Contains("Pro") Or osname.Contains("專業")
                        Console.WriteLine("Windows 10 Pro")
                    Case osname.Contains("Home") Or osname.Contains("家用")
                        Console.WriteLine("Windows 10 Home")
                    Case Else
                        Console.WriteLine("Windows 10")
                End Select
            Case Else
                Console.WriteLine("Unidentified Windows version")
                If Not osname.Contains("Windows") Then
                    Console.WriteLine("Non-Windows Operating System, Unidentified version")
                End If
        End Select
        If osname.Contains("Windows") Then
            Console.WriteLine("Version " + Environment.OSVersion.Version.ToString)
            MainConsole()
        Else
            MainConsole()
        End If
    End Sub

    Sub WhereAmI()
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "You are now in the directory/folder ")
        Console.WriteLine(currentdir)
        MainConsole()
    End Sub

    Sub WhoAmI()
        If Not String.IsNullOrWhiteSpace(My.Settings.username) Then
            Console.WriteLine(My.Settings.username)
        Else
            MessageColored(3, True, "You hid your username by default. Go to the settings and change it.")
        End If
        MainConsole()
    End Sub
End Module
