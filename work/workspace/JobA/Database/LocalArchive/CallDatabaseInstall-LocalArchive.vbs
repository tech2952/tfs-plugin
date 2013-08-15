' Confidential and Proprietary
' (c) 2004 RIA Group, All rights reserved
'
'Call Database Installation Script
'This Script is for hardcoding a database install script, creates database install command line parms

strDebug = "true"
strDatabaseName = "LocalArcTestDB"
strServerName = "cr-dtdv-a03"
strUserName = "sa"
strUserPassword = "password"
strUseTrusted = "true"
strDatabaseDir = "C:"
strSourceDir = ""

'On Error Resume Next
	bError = 0

	Set WshShell = CreateObject("WScript.Shell")
	Set WshEnvironment = WshShell.Environment("process")
	Set fsoLog = CreateObject("Scripting.FileSystemObject")
	'--------------------------------
	'-------- WorkingDir ------------
	'--------------------------------
	strRunDir = Left(WScript.ScriptFullName, InStrRev(WScript.ScriptFullName, "\") -1)
	strSourceDir = strRunDir + "\"
		
	'----------------------------------------------
	'------- Put output files in the WorkingDir ---
	'----------------------------------------------
	Set logFile = fsoLog.CreateTextFile ( strRunDir & "\LocalArchive_Call_Database_Install.txt", TRUE)
	logFile.WriteLine "Log Started: " & now
	
	if strServerName = "(local)" then
		strServerName = WshEnvironment("COMPUTERNAME")
		logFile.WriteLine "ServerName set to: " & now
	end if

	'---------------------------------------------------------------------
	'-------- Database Files Directory (the actual mdbs) -----------------
	'---------------------------------------------------------------------
	'strDatabaseDir = ""
	
	'--------------------------------
	'-------- Debug -----------------
	'--------------------------------
	if strDebug = "true" then
		Flag1 = 1
	else
		Flag1 = 0
	end if
	logFile.WriteLine "Debug: " & strDebug
		
	'--------------------------------
	'------- Get Database Name-------
	'--------------------------------
	strDatabaseName = """" & strDatabaseName & """"
	logFile.WriteLine "Database Name: " & strDatabaseName

	'--------------------------------
	'------- Get Server Name --------
	'--------------------------------	
	strServerName = """" & strServerName & """"
	logFile.WriteLine "Server Name: " & strServerName

	'--------------------------------
	'------- Get Username  ----------
	'--------------------------------	
	logFile.WriteLine "User Name: " & strUserName

	'--------------------------------
	'------- Get SA Password --------
	'--------------------------------	
	logFile.WriteLine "Password is populated"
	Flag2 = 1
	
	'--------------------------------
	'------- Get Use Trusted --------
	'--------------------------------	
	logFile.WriteLine "Use Trusted: " & strUseTrusted
	if strUseTrusted = "true" then
		Flag4 = 1
	else
		Flag4 = 0
	end if
		
	if strSourceDir = "" then
		strSourceDir = strRunDir & "\"
	end if
	logFile.WriteLine "Source Dir: " & strSourceDir

	Flag3 = 0
	Flag5 = 0


	'--------------------------------------------
	'------- Launch Installscript ---------------
	'--------------------------------------------
	strInstallDatabase = strSourceDir + "InstallDatabaseLocalArchive.vbs"
	strFlags = Flag1 & Flag2 & Flag3 & Flag4 & Flag5
	logFile.WriteLine "Flags: " & strFlags
	strCmd = """" & strInstallDatabase & """" & " " & _
			strServerName & " " & _
			strDatabaseName & " " & _
			"""" & strSourceDir & """" & " " & _
			"""" & strDatabaseDir & """" & " " & _
			"""" & strFlags & """" & " " & _
			"""" & strUserName & """" & " " & _
			"""" & strUserPassword & """"
	if Flag1 = 1 then
		logFile.WriteLine strCmd
	end if
	wshShell.Run  strCmd, 0, TRUE 


	'-------------------------
	'-------- Clean Up -------
	'-------------------------
	logFile.Close
	set fsoLog = nothing


