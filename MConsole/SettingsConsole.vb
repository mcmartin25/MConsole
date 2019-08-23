Imports System.IO
Imports System.Xml

Module SettingsConsole
    Sub Settings(ByVal titled As Boolean)
        If titled Then
            Console.WriteLine("Settings")
            Console.WriteLine("Type help if you need commands in every settings.")
        End If
        Console.Write(">")
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
                Settings(False)
        End Select
    End Sub

    Sub SetDevMode()
        Console.WriteLine("Development mode")
        Console.WriteLine("This mode will give some unfinished functions for developers to test. Use at your own risk. [Y/N]")
        Dim setkey As ConsoleKeyInfo
        setkey = Console.ReadKey()
        Console.WriteLine()
        Select Case setkey.Key
            Case ConsoleKey.Y
                My.Settings.DevMode = True
                Console.WriteLine("Saved.")
                Settings(False)
            Case ConsoleKey.N
                My.Settings.DevMode = False
                Console.WriteLine("Saved.")
                Settings(False)
            Case Else
                Settings(False)
        End Select
    End Sub

    Sub SetDisplay()
        Console.Write("display>")
        c = Console.ReadLine()
        Select Case c.ToLower
            Case "location"
                Console.WriteLine("This will open/close your current directory display when startup. [Y/N]")
                Console.Write("location>")
                Dim setkey As ConsoleKeyInfo
                setkey = Console.ReadKey()
                Console.WriteLine()
                Select Case setkey.Key
                    Case ConsoleKey.Y
                        My.Settings.ssLocationDisp = True
                        Console.WriteLine("Current directory will display when startup.")
                    Case ConsoleKey.N
                        My.Settings.ssLocationDisp = False
                        Console.WriteLine("Current directory will not display when startup.")
                    Case Else
                        Settings(False)
                End Select
                RestartApp(True)
            Case "help"
                Console.WriteLine("Display settings")
                Console.WriteLine("Command            Description")
                Console.WriteLine("------------------------------")
                Console.WriteLine("location           Enable/Disable currect directory display when startup.")
                Console.WriteLine()
                SetDisplay()
            Case Else
                Settings(False)
        End Select
    End Sub

    Sub SetPrivacy()
        Console.Write("privacy>")
        c = Console.ReadLine()
        Select Case c.ToLower
            Case "commandview", "history"
                Console.WriteLine("This will start/stop record your commands history. [Y/N]")
                Dim setkey As ConsoleKeyInfo
                setkey = Console.ReadKey()
                Console.WriteLine()
                Select Case setkey.Key
                    Case ConsoleKey.Y
                        My.Settings.recCommand = True
                        Console.WriteLine("Saved.")
                        Settings(False)
                    Case ConsoleKey.N
                        My.Settings.recCommand = False
                        Console.WriteLine("Saved.")
                        Settings(False)
                    Case Else
                        Settings(False)
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
                Settings(False)
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
            Console.WriteLine("If you leave the input empty, then your system username will be the default here.")
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
        Settings(False)
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
        Settings(False)
    End Sub

    Sub ReadConfig(ByVal path As String) 'Read config
        Try
            Dim reader As New XmlTextReader(path)
            While reader.Read()
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        Console.WriteLine("<" + reader.Name & ">")
                        Exit Select
                    Case XmlNodeType.Text
                        Console.WriteLine(reader.Value)
                        Exit Select
                    Case XmlNodeType.EndElement
                        Console.WriteLine("")
                        Exit Select
                End Select
            End While
        Catch ex As Exception
            Console.WriteLine("Read Config Error!")
            Console.WriteLine("{0}", ex.Message)
            Console.WriteLine("{0}", ex.StackTrace)
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
        End Try
    End Sub

    Sub CreateConfig(ByVal path As String) 'Create config on startup
        Dim xwriter As XmlWriter
        Debug.WriteLine("Creating Config...")
        Try
            Dim xset As XmlWriterSettings = New XmlWriterSettings()
            xset.Indent = True
            xset.NewLineOnAttributes = True
            xwriter = XmlWriter.Create(path, xset)
            xwriter.WriteStartDocument()

            'display settings
            xwriter.WriteStartElement("settings")
            'xwriter.WriteAttributeString("category", "display")

            xwriter.WriteStartElement("display")
            xwriter.WriteAttributeString("filelocation", My.Settings.ssLocationDisp)
            xwriter.WriteEndElement()

            xwriter.WriteStartElement("privacy")
            xwriter.WriteAttributeString("history", My.Settings.recCommand)
            xwriter.WriteEndElement()

            xwriter.WriteStartElement("user")
            xwriter.WriteAttributeString("status", My.Settings.setusername)
            xwriter.WriteAttributeString("name", My.Settings.username)
            xwriter.WriteEndElement()

            xwriter.WriteStartElement("devmode")
            xwriter.WriteAttributeString("status", My.Settings.DevMode)
            xwriter.WriteEndElement()

            xwriter.WriteEndElement()

            xwriter.WriteEndDocument()

            xwriter.Flush()
            xwriter.Close()

            Debug.WriteLine("Create Config success, turning back to main screen...")
        Catch ex As Exception
            Console.WriteLine("Create Config Error!")
            Console.WriteLine("{0}", ex.Message)
            Console.WriteLine("{0}", ex.StackTrace)
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
        End Try
    End Sub

    Sub WriteConfig(ByVal path As String) 'Edit config
        Dim xwriter As XmlWriter
        Debug.WriteLine("Creating Config...")
        Try
            Dim xset As XmlWriterSettings = New XmlWriterSettings()
            xset.Indent = True
            xset.NewLineOnAttributes = False
            xwriter = XmlWriter.Create(path, xset)
            xwriter.WriteStartDocument()

            xwriter.WriteEndDocument()

            xwriter.Flush()
            xwriter.Close()

            Debug.WriteLine("Create Config success, turning back to main screen...")
        Catch ex As Exception
            Console.WriteLine("Create Config Error!")
            Console.WriteLine("{0}", ex.Message)
            Console.WriteLine("{0}", ex.StackTrace)
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
        End Try
    End Sub

End Module
