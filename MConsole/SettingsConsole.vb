Module SettingsConsole
    Sub Settings()
        c = Console.ReadLine()
        Select Case c.ToLower
            Case "dev", "devmode"
                SetDevMode()
            Case "display"
                SetDisplay()
            Case "privacy"
                SetPrivacy()
            Case "user"
                SetUser()
            Case "help"
                Help()
            Case "back", "exit"
                Console.WriteLine("Turning back to main screen...")
                MainConsole()
            Case Else
                Settings()
        End Select
    End Sub

    Sub SetDevMode()
        Console.WriteLine("Development mode")
        Console.WriteLine("This mode will give some unfinished functions for developers to test. Use at your own risk.")
        c = Console.ReadLine()
        Select Case c.ToLower
            Case "start", "open", "enable", "yes", "y", "on"
                My.Settings.DevMode = True
                Console.WriteLine("Saved.")
                Settings()
            Case "stop", "close", "disable", "no", "n", "off"
                My.Settings.DevMode = False
                Console.WriteLine("Saved.")
                Settings()
            Case Else
                Settings()
        End Select
    End Sub

    Sub SetDisplay()
        c = Console.ReadLine()
        Select Case c.ToLower
            Case "location"
                Console.WriteLine("This will open/close your current directory display when startup.")
                c = Console.ReadLine()
                Select Case c.ToLower
                    Case "start", "open", "enable", "yes", "y", "on"
                        My.Settings.ssLocationDisp = True
                        Console.WriteLine("Current directory will display when startup.")
                    Case "stop", "close", "disable", "no", "n", "off"
                        My.Settings.ssLocationDisp = False
                        Console.WriteLine("Current directory will not display when startup.")
                    Case Else
                        Settings()
                End Select
                Console.WriteLine("You need to restart MConsole to apply the effect, restart now? Press n to abort...")
                c = Console.ReadLine()
                Select Case c.ToLower
                    Case "n", "no"
                        Settings()
                    Case Else
                        RestartApp(True)
                End Select
            Case "help"
                Console.WriteLine("Display settings")
                Console.WriteLine("Command            Description")
                Console.WriteLine("------------------------------")
                Console.WriteLine("location           Enable/Disable currect directory display when startup.")
                Console.WriteLine()
                SetDisplay()
            Case Else
                Settings()
        End Select
    End Sub

    Sub SetPrivacy()
        c = Console.ReadLine()
        Select Case c.ToLower
            Case "commandview", "history"
                Console.WriteLine("This will start/stop record your commands history.")
                c = Console.ReadLine()
                Select Case c.ToLower
                    Case "start", "open", "enable", "yes", "y", "on"
                        My.Settings.recCommand = True
                        Console.WriteLine("Saved.")
                        Settings()
                    Case "stop", "close", "disable", "no", "n", "off"
                        My.Settings.recCommand = False
                        Console.WriteLine("Saved.")
                        Settings()
                    Case Else
                        Settings()
                End Select
            Case "help"
                Console.WriteLine("Privacy settings")
                Console.WriteLine("Command            Description")
                Console.WriteLine("------------------------------")
                Console.WriteLine("commandview        Enable/Disable record commands history.")
                Console.WriteLine("history            Same as commandview.")
                Console.WriteLine()
                SetPrivacy()
            Case Else
                Settings()
        End Select
    End Sub

    Sub SetUser()
        Console.Clear()
        Dim temp As String
        If My.Settings.setusername = True Then
            Console.WriteLine("Your current name is {0}.", My.Settings.username)
            Console.WriteLine("If this name's right then press enter once, or type other name you want to display in this console.")
        Else

            Console.WriteLine("You hid your username by default.")
            Console.WriteLine("Please type a name you want to display in this console.")
        End If
        Console.WriteLine("Type ""none"" if you want to hide your username in MConsole this time.")
        Console.WriteLine("Or else, type ""exit"" to discard your changes.")
        c = Console.ReadLine()
        temp = c
        Select Case c.ToLower
            Case "none"
                My.Settings.username = ""
                My.Settings.setusername = False
                Exit Select
            Case "exit", "back"
                Exit Select
            Case String.Empty, " "
                If My.Settings.setusername = True Then
                    My.Settings.username = Environment.UserName
                Else
                    Exit Select
                End If
            Case Else
                My.Settings.username = temp
                My.Settings.setusername = True
                Exit Select
        End Select
        Settings()
    End Sub

    Sub Help()
        Console.WriteLine("Command            Description")
        Console.WriteLine("------------------------------")
        Console.WriteLine("devmode            Enable/Disable Development mode.")
        Console.WriteLine("help               Show commands.")
        Console.WriteLine("back               Back to main screen.")
        Console.WriteLine("display            Open diaplay settings.")
        Console.WriteLine("privacy            Open privacy settings.")
        Console.WriteLine("user               Open user settings.")
        Console.WriteLine()
        Settings()
    End Sub
End Module
