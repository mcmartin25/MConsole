Imports System.IO
Imports System.Xml

Module SettingsConsole
    Sub Settings(ByVal titled As Boolean)
        If titled Then
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "Settings")
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "Type help if you need commands in every settings.")
        End If
        ConsoleWriteColored(ConsoleColor.DarkGray, False, ">")
        c = Console.ReadLine()
        Select Case c.ToLower
            Case "back", "exit"
                MessageColored(3, True, "Turning back to main screen...")
                MainConsole()
            Case "dev", "devmode"
                SetDevMode(0)
            Case "display"
                SetDisplay()
            Case "help"
                Help()
            Case "privacy"
                SetPrivacy()
            Case "user"
                SetUser()
            'development mode test settings
            Case "encode", "encoding"
                SetDevMode(1)
            Case Else
                MessageColored(2, True, "{1} {2}", c, synerr)
                Settings(False)
        End Select
    End Sub

    Sub SetDevMode(ByVal mode As Integer)
        Select Case mode
            Case 0
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Development mode")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "This mode will give some unfinished functions and displays for developers to test. Use at your own risk. [Y/N]")
                ConsoleWriteColored(ConsoleColor.DarkGray, False, "devmode>")
                Dim setkey As ConsoleKeyInfo
                setkey = Console.ReadKey()
                Console.WriteLine()
                Select Case setkey.Key
                    Case ConsoleKey.Y
                        My.Settings.DevMode = True
                        MessageColored(0, True, "Saved.")
                        Settings(False)
                    Case ConsoleKey.N
                        My.Settings.DevMode = False
                        MessageColored(0, True, "Saved.")
                        Settings(False)
                    Case Else
                        Settings(False)
                End Select
            Case 1
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Display encoder")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "The current display encoder is ""{0}""", Console.OutputEncoding.ToString)
                If Console.OutputEncoding.ToString.Contains("UTF8") Then
                    ConsoleWriteColored(ConsoleColor.DarkGray, True, "Now we will change to default encoding.")
                    ConsoleWriteColored(ConsoleColor.DarkGray, True, "Use at you own risk. This will make some text and symbols not displayable.")
                Else
                    ConsoleWriteColored(ConsoleColor.DarkGray, True, "Now we will change to UTF-8 encoding.")
                End If
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "This will not saved in the settings and will reset after closed.")
                If Console.OutputEncoding.ToString.Contains("UTF8") Then
                    ConsoleWriteColored(ConsoleColor.DarkGray, False, "encoding[Default]>")
                Else
                    ConsoleWriteColored(ConsoleColor.DarkGray, False, "encoding[UTF8]>")
                End If
                Dim setkey As ConsoleKeyInfo
                setkey = Console.ReadKey()
                Console.WriteLine()
                Select Case setkey.Key
                    Case ConsoleKey.Y
                        If Console.OutputEncoding.ToString.Contains("UTF8") Then
                            Console.OutputEncoding = Text.Encoding.Default
                        Else
                            Console.OutputEncoding = Text.Encoding.UTF8
                        End If
                        MessageColored(0, True, "Saved.")
                    Case ConsoleKey.N
                        'If Console.OutputEncoding.ToString.Contains("UTF8") Then
                        'Console.OutputEncoding = Text.Encoding.Default
                        'Else
                        'Console.OutputEncoding = Text.Encoding.UTF8
                        'End If
                        MessageColored(0, True, "Saved.")
                    Case Else
                        MessageColored(3, True, "Setting changes discarded.")
                End Select
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "The current display encoder is ""{0}""", Console.OutputEncoding.ToString)
                Settings(False)
        End Select
    End Sub

    Sub SetDisplay()
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "display>")
        c = Console.ReadLine()
        Select Case c.ToLower
            Case "center", "align"
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Title alignment")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "This will make a centered title. [Y/N]")
                ConsoleWriteColored(ConsoleColor.DarkGray, False, "centered>")
                Dim setkey As ConsoleKeyInfo
                setkey = Console.ReadKey()
                Console.WriteLine()
                Select Case setkey.Key
                    Case ConsoleKey.Y
                        My.Settings.centeredTitle = True
                        MessageColored(0, True, "Saved.")
                        Settings(False)
                    Case ConsoleKey.N
                        My.Settings.centeredTitle = False
                        MessageColored(0, True, "Saved.")
                        Settings(False)
                    Case Else
                        Settings(False)
                End Select
            Case "color", "colorize"
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "This will enable/disable colorize mode in MConsole. [Y/N]")
                ConsoleWriteColored(ConsoleColor.DarkGray, False, "colorize>")
                Dim setkey As ConsoleKeyInfo
                setkey = Console.ReadKey()
                Console.WriteLine()
                Select Case setkey.Key
                    Case ConsoleKey.Y
                        My.Settings.Colorized = True
                        MessageColored(0, True, "Saved. Colorize mode will be enabled.")
                        MessageColored(3, True, "You need to restart MConsole to take the effect, restarting...")
                        RestartApp(False)
                    Case ConsoleKey.N
                        My.Settings.Colorized = False
                        MessageColored(0, True, "Saved. Colorize mode will not enabled.")
                        MessageColored(3, True, "You need to restart MConsole to take the effect, restarting...")
                        RestartApp(False)
                    Case Else
                        Settings(False)
                End Select
            Case "greetings", "greeting"
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "This let you add greetings when startup.")
                Try
                    Console.WriteLine(My.Settings.greetings, My.Settings.username)
                Catch ex As Exception
                    MessageColored(2, True, "No greetings message or there is something wrong about the message format.")
                End Try
                MessageColored(3, True, "Type exit or back to discard changes.")
                MessageColored(3, True, "Or type none or null to change title back to default.")
                ConsoleWriteColored(ConsoleColor.DarkGray, False, "greetings>")
                c = Console.ReadLine
                Select Case c
                    Case "exit", "back"
                        MessageColored(3, True, "Setting changes discarded.")
                    Case "none", "null"
                        My.Settings.greetingsStatus = False
                        My.Settings.greetings = ""
                        MessageColored(0, True, "Console title changed back to default.")
                    Case "off"
                        My.Settings.greetingsStatus = False
                    Case Else
                        My.Settings.greetingsStatus = True
                        My.Settings.greetings = c
                        MessageColored(0, True, "Saved.")
                        MessageColored(3, True, "You need to restart MConsole to take the effect, restarting...")
                        RestartApp(False)
                End Select

                Settings(False)


            Case "location"
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "This will open/close your current directory display when startup. [Y/N]")
                ConsoleWriteColored(ConsoleColor.DarkGray, False, "location>")
                Dim setkey As ConsoleKeyInfo
                setkey = Console.ReadKey()
                Console.WriteLine()
                Select Case setkey.Key
                    Case ConsoleKey.Y
                        My.Settings.ssLocationDisp = True
                        MessageColored(0, True, "Saved. Current directory will display when startup.")
                    Case ConsoleKey.N
                        My.Settings.ssLocationDisp = False
                        MessageColored(0, True, "Saved. Current directory will not display when startup.")
                        Console.WriteLine("")
                    Case Else
                        Settings(False)
                End Select
                RestartApp(True)
            Case "theme"
                Dim originalTheme As String = My.Settings.selectedTheme
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Display settings - theme chooser")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "This let you choose any theme in MConsole.")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Theme list")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Command   Theme               Color (Foreground, Background)")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "------------------------------------------------------------")
                Console.WriteLine("none      Default theme")
                Console.WriteLine("hc1       High Contrast #1    White, Black")
                Console.WriteLine("hc2       High Contrast #2    Black, Magenta")
                Console.WriteLine("hcw       High Contrast White Black, White")
                Console.WriteLine("context   Context             Magenta, White")
                Console.WriteLine("matrix    Matrix              Green, Black")
                MessageColored(3, True, "Colorized settings will set to disabled as non-displayable text color value.")
                Console.WriteLine()
                ConsoleWriteColored(ConsoleColor.DarkGray, False, "theme>")
                c = Console.ReadLine()
                Select Case c.ToLower
                    Case "exit", "back", "cancel"
                        MessageColored(0, True, "Setting changes discarded.")
                    Case "none"
                        My.Settings.themeStatus = False
                        My.Settings.selectedTheme = "none"
                        MessageColored(0, True, "Console theme changed back to default.")
                    Case "hc1"
                        My.Settings.themeStatus = True
                        My.Settings.selectedTheme = "HC1"
                        MessageColored(0, True, "Console theme set to High contrast #1.")
                    Case "hc2"
                        My.Settings.themeStatus = True
                        My.Settings.selectedTheme = "HC2"
                        MessageColored(0, True, "Console theme set to High contrast #2.")
                    Case "hcw"
                        My.Settings.themeStatus = True
                        My.Settings.selectedTheme = "HCW"
                        MessageColored(0, True, "Console theme set to High Contrast White.")
                    Case "context"
                        My.Settings.themeStatus = True
                        My.Settings.selectedTheme = "context"
                        MessageColored(0, True, "Console theme set to Context.")
                    Case "matrix"
                        My.Settings.themeStatus = True
                        My.Settings.selectedTheme = "matrix"
                        MessageColored(0, True, "Console theme set to Matrix.")
                    Case Else
                        MessageColored(2, True, "{0} is not a valid theme, turning back to settings...", c)
                End Select
                If originalTheme = My.Settings.selectedTheme Then
                    Settings(False)
                Else
                    MessageColored(0, True, "Saved.")
                    MessageColored(3, True, "You need to restart MConsole to take the effect, restarting...")
                    RestartApp(False)
                End If
            Case "tips"
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "This will enable/disable MConsole tips display when startup. [Y/N]")
                ConsoleWriteColored(ConsoleColor.DarkGray, False, "tips>")
                Dim setkey As ConsoleKeyInfo
                setkey = Console.ReadKey()
                Console.WriteLine()
                Select Case setkey.Key
                    Case ConsoleKey.Y
                        My.Settings.tipsDisplay = True
                        MessageColored(0, True, "Saved. MConsole tips will display when startup.")
                    Case ConsoleKey.N
                        My.Settings.tipsDisplay = False
                        MessageColored(0, True, "Saved. MConsole tips will not display when startup.")
                        Console.WriteLine("")
                    Case Else
                        MessageColored(0, True, "Setting changes discarded.")
                        Settings(False)
                End Select
                RestartApp(True)
            Case "title"
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "This let you add customizable title in MConsole.")
                MessageColored(3, True, "This won't delete MConsole system title - just attached with the system title.")
                MessageColored(3, True, "Type exit or back to discard changes.")
                MessageColored(3, True, "Or type none or null to change title back to default.")
                ConsoleWriteColored(ConsoleColor.DarkGray, False, "title>")
                c = Console.ReadLine
                Select Case c
                    Case "exit", "back"
                        MessageColored(3, True, "Setting changes discarded.")
                    Case "none", "null"
                        My.Settings.titleStatus = False
                        My.Settings.titleContent = ""
                        MessageColored(0, True, "Console title changed back to default.")
                    Case Else
                        My.Settings.titleStatus = True
                        My.Settings.titleContent = c
                        MessageColored(0, True, "Saved.")
                        MessageColored(3, True, "You need to restart MConsole to take the effect, restarting...")
                        RestartApp(False)
                End Select

                Settings(False)

            Case "help"
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Display settings")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Command            Description")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "------------------------------")
                Console.WriteLine("location           Enable/Disable currect directory display when startup.")
                Console.WriteLine("color              Enable/Disable colorize mode.")
                Console.WriteLine("colorize           Same as color.")
                Console.WriteLine()
                SetDisplay()
            Case Else
                Settings(False)
        End Select
    End Sub

    Sub SetPrivacy()
        ConsoleWriteColored(ConsoleColor.DarkGray, False, "privacy>")
        c = Console.ReadLine()
        Select Case c.ToLower
            Case "commandview", "history"
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "This will start/stop record your commands history. [Y/N]")
                Dim setkey As ConsoleKeyInfo
                setkey = Console.ReadKey()
                Console.WriteLine()
                Select Case setkey.Key
                    Case ConsoleKey.Y
                        My.Settings.recCommand = True
                        MessageColored(0, True, "Saved.")
                        Settings(False)
                    Case ConsoleKey.N
                        My.Settings.recCommand = False
                        MessageColored(0, True, "Saved.")
                        Settings(False)
                    Case Else
                        MessageColored(3, True, "Setting changes discarded.")
                        Settings(False)
                End Select
            Case "help"
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Privacy settings")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "Command            Description")
                ConsoleWriteColored(ConsoleColor.DarkGray, True, "------------------------------")
                Console.WriteLine("commandview        Enable/Disable record commands history.")
                Console.WriteLine("history            Same as commandview.")
                Console.WriteLine()
                SetPrivacy()
            Case Else
                Settings(False)
        End Select
    End Sub

    Sub SetUser()
        Console.Clear()
        Dim temp As String
        If My.Settings.setusername = True Then
            MessageColored(3, True, "Your current name is {1}.", My.Settings.username)
            'Console.WriteLine("Your current name is {0}.", My.Settings.username)
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "If this name's right then press enter once, or type other name you want to display in this console.")
        Else
            MessageColored(3, True, "You hid your username by default.")
            'Console.WriteLine("You hid your username by default.")
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "Please type a name you want to display in this console.")
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "If you leave the input empty, then your system username will be the default here.")
        End If
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Type ""none"" if you want to hide your username in MConsole this time.")
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Or else, type ""exit"" to discard your changes.")
        c = Console.ReadLine()
        temp = c
        Select Case c.ToLower
            Case "none"
                My.Settings.username = ""
                My.Settings.setusername = False
                MessageColored(0, True, "Saved. Your username will not display on this console.")
                Exit Select
            Case "exit", "back"
                MessageColored(3, True, "Setting changes discarded.")
                Exit Select
            Case String.Empty, " "
                If My.Settings.setusername = True Then
                    My.Settings.username = Environment.UserName
                    MessageColored(0, True, "Saved. Your username set to ""{1}"".", My.Settings.username)
                Else
                    MessageColored(3, True, "Setting changes discarded.")
                    Exit Select
                End If
            Case Else
                My.Settings.username = temp
                My.Settings.setusername = True
                MessageColored(0, True, "Saved. Your username set to ""{1}"".", My.Settings.username)
                Exit Select
        End Select
        Settings(False)
    End Sub

    Sub Help()
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Command            Description")
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "------------------------------")
        Console.WriteLine("devmode            Enable/Disable Development mode.")
        Console.WriteLine("help               Show commands.")
        Console.WriteLine("back               Back to main screen.")
        Console.WriteLine("display            Open diaplay settings.")
        Console.WriteLine("privacy            Open privacy settings.")
        Console.WriteLine("user               Open user settings.")
        Console.WriteLine()
        Settings(False)
    End Sub

    Sub ThemeSelector(ByVal theme As String)
        If My.Settings.themeStatus Then
            Select Case theme
                Case "none", "None" 'If uppercase in some reasons
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    My.Settings.Colorized = True
                Case "HC1"
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.White
                    My.Settings.Colorized = False
                Case "HC2"
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.Magenta
                    My.Settings.Colorized = False
                Case "HCW"
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Black
                    My.Settings.Colorized = False
                Case "context"
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.Magenta
                    My.Settings.Colorized = False
                Case "matrix"
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.Green
                    My.Settings.Colorized = False
                Case Else
                    MessageColored(2, True, "Your theme setting has been destroyed by no reason. Repairing...")
                    My.Settings.selectedTheme = "none"
                    Threading.Thread.Sleep(2000)
            End Select
        Else
            My.Settings.selectedTheme = "none"
            Console.BackgroundColor = ConsoleColor.Black
            Console.ForegroundColor = ConsoleColor.Gray
            My.Settings.Colorized = True
        End If
    End Sub

End Module
