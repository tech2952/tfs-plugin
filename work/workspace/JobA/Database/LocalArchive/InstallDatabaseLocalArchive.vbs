' Confidential and Proprietary
' (c) 2003 RIA Group, All rights reserved
'
'Install Database script
'Expected Directory / File structure:
'[InstallDir]
'    	--> procs.sql   --> not used so far
'    	--> tables.sql


Function CheckVisualClue()
	objDisplay.CheckNext
End Function
Function RunSQLCommand (scriptName, outputFileName)
	RunSQLCommandWithDatabase scriptName, outputFileName, strDatabaseName
End Function
Function RunSQLCommandWithDatabase (scriptName, outputFileName, DatabaseName)
	strScript = strSourceDir + scriptName
	if UseTrusted then
		strSQLCommand = "-S" + strServerName + " -d" + DatabaseName + " -i" + """" + strScript + """" + " -o" + """" & strTempDir & "\" & outputFileName + """" + " -E"
	else 
		strSQLCommand = "-S" + strServerName + " -d" + DatabaseName + " -i" + """" + strScript + """" + " -o" + """" & strTempDir & "\" & outputFileName + """" + " -U" & strUserName & " -P" + strUserPassword
	end if
	strCmd = strISQLw + " " + strSQLCommand
	
	if bDebug then
		logFile.WriteLine strCmd
	end if
	wshShell.Run  strCmd, 0, TRUE
End Function
Function OutputGeneratedScript(RecordSet)
	if err.Description <> "" then
		logFile.WriteLine "Error.Function Start Generating Output Script: " & err.Description
		err.clear
	end if
	if bDebug then logFile.WriteLine "GenerateScript Started: " & now
	RecordSet.MoveFirst
	if err.Description <> "" then
		logFile.WriteLine "Error.MoveFirst Generating Output Script: " & err.Description
		err.clear
	end if
    Set OutputFile = fsoLog.CreateTextFile(strSourceDir & "UpdateScript.sql", TRUE)
    While Not Recordset.EOF
		OutputFile.WriteLine RecordSet.GetString
		RecordSet.MoveNext
	Wend
	if err.Description <> "" then
		logFile.WriteLine "Error.MoveNext Generating Output Script: " & err.Description
		err.clear
	end if

	if bDebug then logFile.WriteLine "GenerateScript Ended: " & now
End Function

On Error Resume Next
	bError = FALSE

	Set WshShell = CreateObject("WScript.Shell")
	Set WshEnvironment = WshShell.Environment("process")
	Set fsoLog = CreateObject("Scripting.FileSystemObject")
	
	strRunDir = Left(WScript.ScriptFullName, InStrRev(WScript.ScriptFullName, "\") -1)
	
	'----------------------------------------
	'------- Get Temp Dir -------------------
	'----------------------------------------	
	strTempDir = strRunDir
	Set logFile = fsoLog.CreateTextFile ( strTempDir & "\LocalArchive_Database_Install.txt", TRUE)

	'--------------------------------------------------------------
	'Check/ Read arguments
	'--------------------------------------------------------------
	if WScript.Arguments.Count = 0 then 
		logFile.WriteLine "No arguments"
		logFile.WriteLine "Usage:"
		logFile.WriteLine "(0)Server Name (Database Server Name)"
		logFile.WriteLine "(1)Database Name (Database Name)"
		logFile.WriteLine "(2)SourceDir (Directory where all files are located"
		logFile.WriteLine "(3)Database Files Directory"
		logFile.WriteLine "(4)Control Flags 00000 (Debug, HasUserPassword, HasDBUserPassword, UseTrusted, HasDBXUser)"
		logFile.WriteLine "(5)User Name (DB login capable of creating Databases)"
		logFile.WriteLine "(6)User Password"
		logFile.WriteLine "Log Ended: " & now
		logFile.Close
		set fsoLog = Nothing
		set WshShell = Nothing
		set WshEnvironment = Nothing
		WScript.Quit
	else
		logFile.WriteLine "Number of arguments: " & WScript.Arguments.Count
		strServerName = """" & WScript.Arguments(0) & """"
		logFile.WriteLine "ServerName = " & strServerName
		strDatabaseName = WScript.Arguments(1)
		logFile.WriteLine "Database Name = " & strDatabaseName
		strSourceDir = WScript.Arguments(2)
		logFile.WriteLine "Source Dir: " & strSourceDir
		strDatabaseDir = WScript.Arguments(3)
		logFile.WriteLine "Database Directory: " & strDatabaseDir
		Flags = WScript.Arguments(4)
		logFile.WriteLine Flags
		'------- Parse Flag Settings ---------
		Flag1 = Mid(Flags, 1, 1)
		Flag2 = Mid(Flags, 2, 1)
		Flag3 = Mid(Flags, 3, 1)
		Flag4 = Mid(Flags, 4, 1)
		Flag5 = Mid(Flags, 5, 1)
		if Flag1 = 1 then 
			bDebug = true
		else
			bDebug = false
		end if
		if Flag2 = 1 then 
			HasPassword = true
		else
			HasPassword = false
		end if
		if Flag3 = 1 then
			HasDBPassword = true
		else
			HasDBPassword = false
		end if
		if Flag4 = 1 then
			UseTrusted = true
		else
			UseTrusted = false
		end if
		if Flag5 = 1 then
			HasDBXPassword = true
		else
			HasDBXPassword = false
		end if
		
		'---- Continue processing command line -----
		strUserName =  WScript.Arguments(5)
		logFile.WriteLine "User Name: " & strUserName
		
		strUserPassword = WScript.Arguments(6)
		if HasPassword then
			logFile.WriteLine "Password is populated"
		else
			logFile.WriteLine "Password is not populated"
			strUserPassword = ""
		end if
		
		
	end if
	
	'--------------------------------------
	'--- Set SQL Command Line EXE Name ----
	'--------------------------------------
	strISQLw = "oSqL.exe"

	if err.Description <> "" then
		logFile.WriteLine "Error1: " & err.Description
		err.clear
	end if

	'-----------------------------------------------
	'------- Connect to the Database Server --------
	'-----------------------------------------------
	Set oCon = CreateObject ("ADODB.Connection")
	oCon.CommandTimeout = 240
	if UseTrusted then
		oCon.ConnectionString = "Provider=SQLOLEDB;Integrated Security=SSPI;Initial Catalog=master;Data Source=" & strServerName
		logfile.WriteLine "connection string parms: UseTrusted; ServerName: " & strServerName
	else
		if strUserPassword = "" then 
			oCon.ConnectionString = "Provider=SQLOLEDB;User ID=" & strUserName & ";Initial Catalog=master;Data Source=" & strServerName
		else
			oCon.ConnectionString = "Provider=SQLOLEDB;User ID=" & strUserName & ";Password=" & strUserPassword & ";Initial Catalog=master;Data Source=" & strServerName
		end if
		logfile.WriteLine "connection string parms: User ID=" & strUsername & ";Data source=" & strServerName
	end if
	if err.Description <> "" then
		logFile.WriteLine "Error2: " & err.Description
		err.clear
	end if
	if bDebug then
		logfile.WriteLine oCon.ConnectionString 
	end if
	
	if err.Description <> "" then
		logFile.WriteLine "Error3: " & err.Description
		err.clear
	end if
	
	oCon.Open
	
	if err.Description <> "" then
		logFile.WriteLine err.Description
		'MsgBox Err.Description, vbOkOnly, "Database Install"
		bError = true
		err.clear
	end if
	
	'----------------------------------------
	'------- Check DatabaseName -------------
	'----------------------------------------
	Set oComm = CreateObject ("ADODB.Command")
	oComm.ActiveConnection = oCon
	oComm.CommandType = 1
	oComm.CommandTimeout = 240
	oComm.CommandText = "Use " + strDatabaseName
	oComm.Execute

	DatabaseExists = False

	if err.Description = "" then
		DatabaseExists = True
		logFile.WriteLine "Database exists: Remove?"
		intReturn = 6 'MsgBox ("Database Exists: Remove?", vbYesNo)
		if intReturn = 6 then
			oComm.CommandText = "Use master"
			oComm.Execute
			if err.Description <> "" then
				logFile.WriteLine err.Description
				'MsgBox Err.Description, vbOkOnly, "Database Install"
				bError = true
			end if
			
			oComm.CommandText = "DROP DATABASE " + strDatabaseName
			oComm.Execute
			if err.Description <> "" then
				logFile.WriteLine err.Description
				'MsgBox Err.Description, vbOkOnly, "Database Install"
				bError = true
			else
				DatabaseExists = false
			end if
		end if
	else
		logFile.WriteLine "Database does not exist: Creating"
		err.Clear
	end if

	'----------------------------------------
	'------- Create DatabaseName ------------
	'----------------------------------------
	if not bError then
		if not DatabaseExists then
			oComm.CommandText = "CREATE DATABASE " + strDatabaseName + " ON PRIMARY ( NAME = " + strDatabaseName + "_dat, FILENAME = '" + strDatabaseDir + "\" + strDatabaseName + "dat.mdf', SIZE = 10MB, MAXSIZE = 500MB, FILEGROWTH = 100MB ) LOG ON ( NAME = " + strDatabaseName + "_log, FILENAME = '" + strDatabaseDir + "\" + strDatabaseName + "log.ldf', SIZE = 5MB, MAXSIZE = 500MB, FILEGROWTH = 50MB)"
			oComm.Execute
			
			if err.Description <> "" then
				logFile.WriteLine err.Description
				'MsgBox Err.Description, vbOkOnly, "Database Install"
				bError = true
			end if
			oComm.CommandText = "Use " + strDatabaseName
			oComm.Execute

		end if
	end if

	'-----------------------------------
	'------- Create UserDefinedTypes ---
	'-----------------------------------	
	if not bError then
		if not DatabaseExists then
			RunSQLCommand "UserDefinedDatatypes.sql", "LocalArchive_UserDDT.txt"
			logFile.WriteLine "Create Tables script ran, please view LocalArchive_UserDDT.txt for output"
		end if
	end if

	'-----------------------------------
	'------- Create Tables -------------
	'-----------------------------------	
	if not bError then
		if not DatabaseExists then
			RunSQLCommand "LocalArchive.sql", "LocalArchive_Tables.txt"
			logFile.WriteLine "Create Tables script ran, please view LocalArchive_Tables.txt for output"
		end if
	end if

	'---------------------------------------------
	'------- Create Procs ------------------------
	'---------------------------------------------
	'if not bError then
	'	RunSQLCommand "procs.sql", "LocalArchive_Procs.txt"
	'	logFile.WriteLine "Create Stored Procedures script ran, please view REVERE_Procs.txt for output"
	'end if


	'------------------------------------------
	'---- Clean up ----------------------------
	'------------------------------------------
	set oComm = Nothing
	oCon.Close
	set oCon = Nothing
	logFile.WriteLine "Log Ended: " & Now
	logFile.Close
	set fsoLog = Nothing
	set WshShell = Nothing
	set WshEnvironment = Nothing
	
	
	'MsgBox "Database creation complete", vbOkOnly, "Database Install"