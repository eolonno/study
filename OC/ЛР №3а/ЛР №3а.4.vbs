Set fso=WScript.CreateObject("Scripting.FileSystemObject")
Set file=fso.CreateTextFile("4.bat")
file.WriteLine("@start Excel")
file.Close

Set WshShell = WScript.CreateObject("WScript.Shell")
WshShell.Run "4.bat"