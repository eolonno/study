Option Explicit
Dim Message, Title, answ, z
Dim WshShell, objEnv
Set WshShell = CreateObject ("WScript.Shell")
Set objEnv = WshShell.Environment("Process")
Message = "System Information" & vbCrLf 
Message = Message & "PROMPT" & objEnv("PROMPT")& vbCrLf
Message = Message & "WinDir:" & objEnv("WINDIR") & vbCrLf
Answ = MsgBox ("Would you create your own var?(y/n)",vbYesNo,_
       "Answer, please") 
If answ=vbYes Then
objEnv("MyVar")= "This is your var"
end If
'reading
Message="List of System vars" & vbCrLf 
For Each z in objEnv
   Message = Message & z & vbCrLf
Next
Title="System Info."
MsgBox Message, vbOKOnly, Title 
