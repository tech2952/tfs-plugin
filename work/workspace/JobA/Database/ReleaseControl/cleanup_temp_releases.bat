@ECHO OFF

@REM This batch file will temporary snapshots that were copied to the archive by Taxbuilder

@REM log start event to system event log
eventcreate /L Application /T INFORMATION /SO Taxbuilder_Release_Control /ID 101 /D "Delete temporary backup files job starting"

@REM Set directory variables.
SET basedir=.
SET workdir=C:\DBA_ARCHIVE

@REM Change to working directory
CD %workdir%

@REM Remove old backup files
echo deleting %workdir%\REL-*.bak
del %workdir%\*.bak  
if not errorlevel == 0 (eventcreate /L Application /T ERROR /SO Taxbuilder_Release_Control /ID 101 /D "Failure to delete temp backup files from local directory")

@REM Change back to base dir
CD %basedir%

@REM log completion event to system event log
eventcreate /L Application /T INFORMATION /SO Taxbuilder_Release_Control /ID 101 /D "Delete temporary backup files job completed"