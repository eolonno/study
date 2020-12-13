pathIn = "1.vbs"
pathOut = "2.txt"

Set fso=WScript.CreateObject("Scripting.FileSystemObject")
Set file=fso.CreateTextFile("2.txt")
file.Close

Set fso = CreateObject("Scripting.FileSystemObject")
fso.CopyFile pathIn, PathOut