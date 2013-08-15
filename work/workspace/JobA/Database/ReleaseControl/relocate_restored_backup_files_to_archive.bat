@ECHO OFF

@REM This batch file will back up any restored Releases created in Taxbuilder

@REM log start event to system event log
eventcreate /L Application /T INFORMATION /SO Taxbuilder_Release_Control /ID 100 /D "Relocate restored backup files to archive starting"

for /f "tokens=1-4 delims=/ " %%a in ('date/t') do (
set dw=%%a
set mm=%%b
set dd=%%c
set yy=%%d
)

@REM Set directory variables.
SET basedir=./bin
SET workdir=..
SET zipdir="C:\Program Files\7-Zip"
SET archiveShare=Z:\

@REM Change to working directory
CD %workdir%

@REM Zip up databases
%zipdir%\7z.exe a backup.sql.zip *.bak
if not errorlevel == 0 (eventcreate /L Application /T ERROR /SO Taxbuilder_Release_Control /ID 100 /D "Failure to zip backup files")

@REM Chage the file name to a random name
echo creating %yy%-%mm%-%dd%-restoredReleaseBackup.zip

MOVE backup.sql.zip %archiveShare%RestoredReleases\%yy%-%mm%-%dd%-restoredReleaseBackup.zip
if not errorlevel == 0 (eventcreate /L Application /T ERROR /SO Taxbuilder_Release_Control /ID 100 /D "Failure to move backup files to archive")

@REM Remove old backup files if the move was successful
IF EXIST %archiveShare%RestoredReleases\%yy%-%mm%-%dd%-restoredReleaseBackup.zip del *.bak  

@REM Change back to base dir
CD %basedir%

@REM log completion event to system event log
eventcreate /L Application /T INFORMATION /SO Taxbuilder_Release_Control /ID 100 /D "Relocate restored backup files to archive completed"