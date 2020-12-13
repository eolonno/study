Set WshShell = WScript.CreateObject("WScript.Shell")
txt_name=inputbox("Input name")
WshShell.Run "notepad "&txt_name