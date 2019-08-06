Imports System.IO

Module Home
    Sub MainConsole()
        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory)
        Console.Write(vbCrLf + " " + vbCrLf + ">")
        c = Console.ReadLine()
        If c.ToLower <> "cv" And c.ToLower <> "commandview" And c.ToLower <> "history" Then
            commands.RemoveAt(2)
            commands.Insert(0, c)
        End If
        Select Case c.ToLower
            Case "about"
                About()
            Case "alldrives", "alldrivesinfo", "driveslist", "drivelist"
                Dim alldrive() As IO.DriveInfo = IO.DriveInfo.GetDrives()
                Dim d As IO.DriveInfo
                For Each d In alldrive
                    Console.WriteLine("Drive {0}", d.Name)
                    Console.WriteLine("Drive type: {0}", d.DriveType)
                    If d.IsReady = True Then
                        If Not d.VolumeLabel = "" Then
                            Console.WriteLine("Volume Label {0}", d.VolumeLabel)
                        Else
                            Console.WriteLine("No Volume Label")
                        End If
                        Console.WriteLine("File System: {0}", d.DriveFormat)
                        Console.WriteLine("Available Space: {0,15} bytes", d.AvailableFreeSpace)
                        Console.WriteLine("Total Free Space: {0,15} bytes", d.TotalFreeSpace)
                        Console.WriteLine("Total Size: {0,15} bytes", d.TotalSize)
                    End If
                Next
                MainConsole()
            Case "applog"
                Applog()
            Case "calc"
                Dim temp As String, c1 As Double, op As String, c2 As Double, last As Boolean
                Console.WriteLine("Calculator")
                'c1
                temp = Console.ReadLine()
                If IsNumeric(temp) Then
                    c1 = temp
                    temp = Nothing
                Else
                    Console.WriteLine("c1 Error")
                    MainConsole()
                End If
                's
                temp = Console.ReadLine()
                If temp = "+" Or temp = "-" Or temp = "*" Or temp = "/" And temp.Count = 1 Then
                    op = temp
                    temp = Nothing
                Else
                    Console.WriteLine("s Error")
                    MainConsole()
                End If
                'c2
                temp = Console.ReadLine()
                If IsNumeric(temp) Then
                    c2 = temp
                    temp = Nothing
                Else
                    Console.WriteLine("c2 Error")
                    MainConsole()
                End If
                Console.Write("=")
                If op = "+" Then
                    Console.WriteLine(c1 + c2)
                ElseIf op = "-" Then
                    Console.WriteLine(c1 - c2)
                ElseIf op = "*" Then
                    Console.WriteLine(c1 * c2)
                ElseIf op = "/" Then
                    Console.WriteLine(c1 / c2)
                End If

                Console.WriteLine("")
                MainConsole()

            Case "cls", "clear"
                Console.Clear()
                MainConsole()
            Case "currentfs", "fs", "filesystem", "fsinfo"
                Dim alldrive() As IO.DriveInfo = IO.DriveInfo.GetDrives()
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
            Case "copy"
                Dim filetarget, copydir As String
                Console.Write("Target file: ")
                filetarget = Console.ReadLine()
                Console.Write("New file directory with new file name: ")
                copydir = Console.ReadLine()
                My.Computer.FileSystem.CopyFile(filetarget, copydir)
                Console.Write("Please go to file directory to see the rename results.")
                MainConsole()
            Case "copydir"
                Dim dirname, newdir As String
                Console.Write("Folder directory/location and name: ")
                dirname = Console.ReadLine()
                Console.Write("New folder directory/location: ")
                newdir = Console.ReadLine()
                If (Not System.IO.Directory.Exists(dirname)) Then
                    My.Computer.FileSystem.CopyDirectory(dirname, newdir)
                    Console.Write("Directory/folder copied.")
                Else
                    Console.Write("Directory/folder already exists. Unable to copy.")
                End If
                MainConsole()
            Case "cv", "commandview", "history"
                CommandView()
            Case "date"
                Console.WriteLine("Today's date: " + Date.Now.ToShortDateString)
                Console.WriteLine("Time: " + Date.Now.ToLongTimeString)
                MainConsole()
            Case "dir"
                Dim d As String
                Console.Write("Please type a directory" + vbCrLf + "Directory: ")
                d = Console.ReadLine()
                For Each Dir As String In IO.Directory.GetDirectories(d)
                    Console.WriteLine(Dir)
                Next
                For Each DirFile As String In IO.Directory.EnumerateFiles(d)
                    Console.WriteLine(DirFile)
                Next
                MainConsole()
            Case "dirlist"
                Dim d As String
                Console.WriteLine("This displays all of the entries of file system you using.")
                Console.WriteLine("Please type a directory")
                Console.Write("Directory: ")
                d = Console.ReadLine()
                For Each Sentr As String In IO.Directory.EnumerateFileSystemEntries(d)
                    Console.WriteLine(Sentr)
                Next
                MainConsole()
            Case "drives", "drivepart", "dpart", "dp"
                Dim drive = IO.DriveInfo.GetDrives
                Console.WriteLine("Partition(s) you have")
                For Each info In drive
                    Console.WriteLine(info.Name)
                Next
                MainConsole()
            Case "echo", "say", "shout"
                Dim ec As String
                Dim ecount, etime As Integer
                If c = "echo" Then
                    Console.Write("echo>")
                    ec = Console.ReadLine()
                ElseIf c = "say" Then
                    Console.Write("say>")
                    ec = Console.ReadLine()
                ElseIf c = "shout" Then
                    Console.Write("shout>")
                    ec = Console.ReadLine()
                End If
                Console.Write("Display Time>")
                etime = Console.ReadLine()
                If Not ec = "" Then
                    Do Until ecount = etime
                        Console.WriteLine(ec)
                        ecount += 1
                    Loop
                Else
                    MainConsole()
                End If
                MainConsole()
            Case "exit"
                Console.WriteLine("Do you want to exit? [Yes/No]")
                Dim decide As String
                decide = Console.ReadLine()
                Select Case decide
                    Case "yes", "y"
                        Environment.Exit(0)
                    Case "no", "n"
                        MainConsole()
                    Case Else
                        MainConsole()
                End Select
            Case "help"
                Help()
            Case "md", "makedir", "newdir"
                Dim dirname As String
                Console.Write("New folder directory/location and name: ")
                dirname = Console.ReadLine()
                If (Not System.IO.Directory.Exists(dirname)) Then
                    IO.Directory.CreateDirectory(dirname)
                    Console.WriteLine("Directory/folder created.")
                Else
                    Console.WriteLine("Directory/folder already exists. Unable to create.")
                End If
                MainConsole()
            Case "move"
                Dim filetarget, copydir As String
                Console.Write("Target file: ")
                filetarget = Console.ReadLine()
                Console.Write("New file location with new file name: ")
                copydir = Console.ReadLine()
                My.Computer.FileSystem.MoveFile(filetarget, copydir)
                Console.WriteLine("Please go to file directory to see the rename results.")
                MainConsole()
            Case "movedir"
                Dim dirname, newdir As String
                Console.Write("Folder directory/location and name: ")
                dirname = Console.ReadLine()
                Console.Write("New folder directory/location: ")
                newdir = Console.ReadLine()
                If (Not System.IO.Directory.Exists(dirname)) Then
                    My.Computer.FileSystem.MoveDirectory(dirname, newdir)
                    Console.WriteLine("Directory/folder moved.")
                Else
                    Console.WriteLine("Directory/folder already exists. Unable to move.")
                End If
                MainConsole()
            Case "open"
                Console.Write("Folder directory/File location (except executable): ")
                Dim target As String = Console.ReadLine()
                Dim p() As Process = Process.GetProcessesByName(target)
                Dim ext As String = IO.Path.GetExtension(target)
                If p.Count > 0 Then
                    Process.Start(target)
                    MainConsole()
                ElseIf target = String.Empty Then
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
                    Console.WriteLine("Cannot run. Your file is an executable or may be a shortcut link to the an executable file.")
                    Console.WriteLine("Please use run command instead.")
                    MainConsole()
                Else
                    Console.WriteLine("Cannot run. Your folder directory/file location may not vaild.")
                    MainConsole()
                End If
            Case "rename", "ren", "rn"
                Dim filetarget, renamev As String
                Console.Write("Target file: ")
                filetarget = Console.ReadLine()
                Console.Write("Rename name: ")
                renamev = Console.ReadLine()
                My.Computer.FileSystem.RenameFile(filetarget, renamev)
                Console.WriteLine("Please go to file directory to see the rename results.")
                MainConsole()
            Case "restart", "rs"
                Threading.Thread.Sleep(2000)
                Console.Clear()
                Threading.Thread.Sleep(1000)
                Main()
            Case "run"
                Console.WriteLine("Be aware that this action may harm your computer because not all application are safe!")
                Console.Write("Run: ")
                Dim target As String = Console.ReadLine()
                Dim p() As Process = Process.GetProcessesByName(target)
                Dim ext As String = IO.Path.GetExtension(target)
                If p.Count > 0 Then
                    Process.Start(target)
                    MainConsole()
                ElseIf target = String.Empty Then
                    MainConsole()
                Else
                    Console.Write("Cannot run. Your folder directory/file location may not vaild.")
                    MainConsole()
                End If
            Case "set", "setting", "settings"
                Console.WriteLine("Settings")
                c = Console.ReadLine()
                Select Case c.ToLower
                    Case "dev", "devmode"
                        Console.WriteLine("This mode will give some unfinished functions for developers to test. Use at your own risk.")
                        Console.WriteLine("Development mode")
                        c = Console.ReadLine()
                        Select Case c.ToLower
                            Case "start", "open", "enable", "yes", "y"
                                If d = False Then
                                    d = True
                                Else
                                    Console.WriteLine("Development mode has already been enabled.")
                                End If
                            Case "stop", "close", "disable", "no", "n"
                                If d = True Then
                                    d = False
                                Else
                                    Console.WriteLine("Development mode has already been disabled.")
                                End If
                        End Select
                    Case "back", "exit"
                        MainConsole()
                End Select
            Case "sysinfo", "systeminfo"
                Console.WriteLine("System info")
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

            Case "time"
                Console.WriteLine("Time Now: " + Date.Now.ToLongTimeString)
                Console.WriteLine("Date: " + Date.Now.ToShortDateString)
                MainConsole()
            Case "ver", "version"
                Ver()
            Case Else
                Console.WriteLine(c + synerr)
                Threading.Thread.Sleep(500)
                MainConsole()
                On Error GoTo Handler
                Throw New DivideByZeroException()
Handler:
                If (TypeOf Err.GetException() Is DivideByZeroException) Then
                    Console.WriteLine("!An error appeared in MConsole. Console progress is terminated. You need to restart the console to continue.")
                    Console.Read()
                    Environment.Exit(0)
                End If
        End Select
    End Sub
End Module
