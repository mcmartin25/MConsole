﻿Module Info
    Sub Help()
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "If you want to find the content in this console, press Ctrl+F then type.")
        Console.WriteLine()
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Command            Description")
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "------------------------------")
        Console.WriteLine("about              Display MConsole info.")
        Console.WriteLine("alldrives          Display file system for each partition.")
        Console.WriteLine("alldrivesinfo      Same as alldrives.")
        Console.WriteLine("applog             Display features and logs of MConsole.")
        Console.WriteLine("calc               Calculate with simple operators.")
        Console.WriteLine("cd                 Change current directory/folder.")
        Console.WriteLine("changedir          Same as cd.")
        Console.WriteLine("chgdir             Same as cd.")
        Console.WriteLine("clear              Clear screen.")
        Console.WriteLine("cls                Clear screen.")
        Console.WriteLine("commandview        Show typed command history. (Up to 3 command)")
        Console.WriteLine("copy               Copy file.")
        Console.WriteLine("copydir            Copy directory.")
        Console.WriteLine("currentfs          Same as alldrives.")
        Console.WriteLine("cv                 Same as commandview.")
        Console.WriteLine("date               Display date.")
        Console.WriteLine("dir                Display current directory and its contents.")
        Console.WriteLine("dirlist            Same as dir.")
        Console.WriteLine("dp                 Same as drives.")
        Console.WriteLine("dpart              Same as drives.")
        Console.WriteLine("driveinfo          Same as alldrives.")
        Console.WriteLine("drivelist          Same as alldriveinfo.")
        Console.WriteLine("drivepart          Same as drives.")
        Console.WriteLine("drives             Show all partition(s) you have on your disk(s).")
        Console.WriteLine("driveslist         Same as alldriveinfo.")
        Console.WriteLine("echo               Display copy messages what you type.")
        Console.WriteLine("exit               Exit MConsole.")
        Console.WriteLine("filesystem         Same as alldrives.")
        Console.WriteLine("fs                 Same as alldrives.")
        Console.WriteLine("fsinfo             Same as alldrives.")
        Console.WriteLine("help               Display all the commands.")
        Console.WriteLine("history            Same as commandview.")
        Console.WriteLine("list               Same as dir.")
        Console.WriteLine("makedir            Same as md.")
        Console.WriteLine("makefile           Create text-based file.")
        Console.WriteLine("md                 Make a new directory.")
        Console.WriteLine("move               Move file to new directory.")
        Console.WriteLine("network            Show network information.")
        Console.WriteLine("movedir            Move directory to new directory/location.")
        Console.WriteLine("newdir             Same as md.")
        Console.WriteLine("open               Open file or folder. (This cannot run executable.)")
        Console.WriteLine("ping               Ping server.")
        Console.WriteLine("rename             Rename file.")
        Console.WriteLine("renamedir          Rename folder.")
        Console.WriteLine("rendir             Same as renamedir.")
        Console.WriteLine("restart            Restart the console. (That wouldn't restart your computer.)")
        Console.WriteLine("rn                 Same as rename.")
        Console.WriteLine("rndir              Same as renamedir.")
        Console.WriteLine("rs                 Same as restart.")
        Console.WriteLine("run                Run executable, open file or folder.")
        Console.WriteLine("say                Same as echo.")
        Console.WriteLine("set                Same as settings.")
        Console.WriteLine("setting            Same as settings.")
        Console.WriteLine("settings           Open settings.")
        Console.WriteLine("shout              Same as echo.")
        Console.WriteLine("sysinfo            Show your host system you using.")
        Console.WriteLine("systeminfo         Same as sysinfo.")
        Console.WriteLine("time               Display time.")
        Console.WriteLine("ver                Display version of MConsole.")
        Console.WriteLine("version            Same as ver.")
        Console.WriteLine("where              Show current directory location.")
        Console.WriteLine("who                Show your current username value.")
        MainConsole()
        'ping, network, makefile
    End Sub
    Sub About()
        Console.Clear()


        If My.Settings.centeredTitle Then

            For Each i As String In iconStrings
                CenterWriteColored(ConsoleColor.Blue, True, True, i)
            Next
            CenterWriteColored(ConsoleColor.DarkGray, True, True, "MConsole v.{0} Pre-alpha", verstr)
            CenterWriteColored(ConsoleColor.DarkGray, True, True, "MConsole Pre-Alpha Version {0}", fullver)
            CenterWriteColored(ConsoleColor.DarkGray, True, True, "Copyright (c) 2018-2019 Martin C. All rights reserved.")
            CenterWriteColored(ConsoleColor.DarkGray, True, True, "Type applog command to see its features and logs.")
        Else
            For Each i As String In iconStrings
                ConsoleWriteColored(ConsoleColor.Blue, True, i)
            Next
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "MConsole v.{0} Pre-alpha", verstr)
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "MConsole Pre-Alpha Version {0}", fullver)
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "Copyright (c) 2018-2019 Martin C. All rights reserved.")
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "Type applog command to see its features and logs.")
        End If
        Console.ReadKey()
        'Threading.Thread.Sleep(500)
        Console.Clear()
        MainConsole()
    End Sub
    Sub Applog()
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Features")
        Console.WriteLine("* Change encode settings to UTF-8")
        Console.WriteLine("* Add command: ping, network, makefile")
        Console.WriteLine("* Add theme, title alignment, greetings and encode settings")
        Console.WriteLine("* Optimized exit and restart message, about screen, Tips, welcome text")
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "-----")
        ConsoleWriteColored(ConsoleColor.DarkGray, True, "Applog")
        Console.WriteLine("Version 0.1.20180120")
        Console.WriteLine("* First version of MConsole")
        Console.WriteLine("Version 0.1.20180121")
        Console.WriteLine("* Add command: app")
        Console.WriteLine("* Add features: AppConsole, Calc, Writer, Last Command Watcher, MPlayer")
        Console.WriteLine("Version 0.1.20180121.1")
        Console.WriteLine("* Small bug fixes")
        Console.WriteLine("* Add features: Clipboard Manager")
        Console.WriteLine("* Content-correcting")
        Console.WriteLine("Version 0.1.20180121.2(20180130)")
        Console.WriteLine("* Small bug fixes")
        Console.WriteLine("Version 0.1.20180121.3")
        Console.WriteLine("* Application icon added")
        Console.WriteLine("* Optimized: Calc")
        Console.WriteLine("Version 0.1.20180121.4(20180227)")
        Console.WriteLine("* Add features: echo, sysinfo")
        Console.WriteLine("Version 0.1.20180121.5(20180306)")
        Console.WriteLine("* Add testing features: martinui(console), debug")
        Console.WriteLine("Version 0.1.20180313")
        Console.WriteLine("* Add command: drives, alldrives,")
        Console.WriteLine("* Change fsinfo to dirlist")
        Console.WriteLine("Version 0.1.20180313.1(20180314)")
        Console.WriteLine("* Removed features: martinui(console), debug")
        Console.WriteLine("Version 0.1.20180313.2(20180325)")
        Console.WriteLine("! An update before Version 0.2")
        Console.WriteLine("* Add Start Screen")
        Console.WriteLine("* Code-correcting")
        Console.WriteLine("Version 0.2.20180325")
        Console.WriteLine("* Customized Start Screen")
        Console.WriteLine("* Change display method of ""Known Issues by last build"" from list to table")
        Console.WriteLine("* All the known issues list by last build are splitted from applog to issuelist.")
        Console.WriteLine("* Code-correcting")
        Console.WriteLine("* Content-correcting")
        Console.WriteLine("* Bug fixes")
        Console.WriteLine("* Add command: restart, issuelist")
        Console.WriteLine("Version 0.2.20180329")
        Console.WriteLine("* Code-correcting")
        Console.WriteLine("* Content-correcting")
        Console.WriteLine("* Removed features: Write, MPlayer")
        Console.WriteLine("Version 0.2.20180329.1(20180330)")
        Console.WriteLine("* Removed command: issuelist")
        Console.WriteLine("* Code-correcting")
        Console.WriteLine("* Removed features: appcm")
        Console.WriteLine("Version 0.2.20180420")
        Console.WriteLine("* Add features: Write, countdown")
        Console.WriteLine("* Add exit message")
        Console.WriteLine("* Code-correcting")
        Console.WriteLine("* Bug-fixes")
        Console.WriteLine("Version 0.2.20180420.1")
        Console.WriteLine("* Bug-fixes")
        Console.WriteLine("Version 0.2.20180510")
        Console.WriteLine("* System Bug-fixes")
        Console.WriteLine("* Bug-fixes for Calc, countdown and AppConsole")
        Console.WriteLine("Version 0.3.20190623")
        Console.WriteLine("* Remove AppConsole compoments")
        Console.WriteLine("* Code-correcting and bug-fixes")
        Console.WriteLine("* Content-correcting in Help Sub")
        Console.WriteLine("* Change copyright text")
        Console.WriteLine("Version 0.4.20190806")
        Console.WriteLine("* Optimized code")
        Console.WriteLine("* Add command: clear, open, run, commandview, cv, history")
        Console.WriteLine("* Add main app folder location(for development purpose)")
        Console.WriteLine("* Bug-fixes")
        Console.WriteLine("Version 0.4.20190811")
        Console.WriteLine("* Add command: where, list, renamedir, rendir, rndir")
        Console.WriteLine("* Optimized: calc, alldrivesinfo, dir")
        Console.WriteLine("* Code-correcting and bug-fixes")
        Console.WriteLine("Version 0.4.20190812")
        Console.WriteLine("* Add options in settings: display commandview, directory location")
        Console.WriteLine("* Optimized: restart")
        Console.WriteLine("Version 0.4.20190818")
        Console.WriteLine("* Add username function")
        Console.WriteLine("* Add who command")
        Console.WriteLine("* Optimized: Settings")
        Console.WriteLine("* Optimized code")
        Console.WriteLine("* content-changing And bug-fixes")
        Console.WriteLine("Version 0.5.20190925")
        Console.WriteLine("* Colorized UI")
        Console.WriteLine("* Change encode settings to UTF-8")
        Console.WriteLine("* Add command: ping, network, makefile")
        Console.WriteLine("* Add theme, title alignment, greetings and encode settings")
        Console.WriteLine("* Optimized exit and restart message, about screen, Tips, welcome text")
        Console.WriteLine("* Content-changing and bug-fixes")
        '...
        'Console.WriteLine("* ")
        'Console.WriteLine("-----")
        'Console.WriteLine("Type issuelist to see all the known issues by last build.")
        'Console.WriteLine("-----")
        Threading.Thread.Sleep(500)
        MainConsole()
    End Sub
    Sub Ver()
        Console.WriteLine("MConsole v.{0} Pre-alpha", verstr)
        Threading.Thread.Sleep(500)
        MainConsole()
    End Sub

    Sub CommandView()
        If My.Settings.recCommand = True Then
            ConsoleWriteColored(ConsoleColor.DarkGray, True, "For security reasons, only the newest 3 commands (sub-commands included) will be list here.")
            Console.WriteLine("")
            For Each item In commands
                Console.WriteLine(item)
            Next
            MainConsole()
        Else
            'Console.WriteLine("You disabled commandview/history function, please enable it.")
            MessageColored(2, True, "You disabled commandview/history function, please enable it.")
            MainConsole()
        End If
    End Sub
End Module
