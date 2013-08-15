clear-host
write-output "------------------------------------Script Start------------------------------------"
write-output " Restore Release Backup "
write-output "------------------------------------------------------------------------------------"
 
# set file paths
$LocalWorkspaceFolder="D:\ReleaseDailyBackups"
$RemoteBackupFolder="Z:\"
$7Zip="C:\Progra~1\7-Zip\7z.exe a"
$timestamp = Get-Date -format yyyyMMddHHmmss
$Log="D:\ReleaseDailyBackups\logs\ReleaseControlRestoredReleaseBackup_$timestamp.txt"
$BackupZipFile = [String]::Format("{0}\{1}_{2}", $LocalWorkspaceFolder,$TimeStamp, "restoredReleaseBackup.zip") 
$erroractionpreference = "Continue"

try
{
    write-output "Start zip ..."     
    invoke-expression "$7Zip $BackupZipFile $LocalWorkspaceFolder\*.bak -tzip"
    write-output "End of zip"
 
    # invoke-expression "$Robocopy $LocalWorkspaceFolder $RemoteBackupFolder *.zip /LOG:$Log /NP"
    
    write-output "Start copy..."
    invoke-expression "copy-item $LocalWorkspaceFolder\*.zip $RemoteBackupFolder"
    write-output "End of copy"

    write-output "Start removing the zip file ..."
    invoke-expression "remove-item $LocalWorkspaceFolder\*.zip"
    write-output "End of removing the zip file"

    write-output "Start removing bak files"    
    invoke-expression "remove-item $LocalWorkspaceFolder\*.bak"
    write-output "End of removing the bak files"
     
    # Check the log for errors etc and log to eventlog/twitter
    #invoke-expression "$RobocopyLogger $Log 1"
 
    # write all events to the logs
    write-eventlog -LogName "Application" -Source "Taxbuilder_Release_Control" -EventId 100 -Message "Release Control Restored Release BackUp Script ran"
    write-output "Writting SUCCESS to EventLog"
    write-output "Writting SUCCESS to EventLog" | out-file $Log
}
catch
{
    # error occurred so lets report it
    write-output "ERROR OCCURRED" $error
    write-output "ERROR OCCURRED" $error | out-file $Log -append
 
    # write an event to the event log
    write-output "Writing FAIL to EventLog"
    write-output "Writing FAIL to EventLog" | out-file $Log -append
    write-eventlog -LogName "Application" -Source "Taxbuilder_Release_Control" -EventId 100 -Message "Release Control Restored Release BackUp Script failed" -EntryType Error
}
 
write-output "------------------------------------Script end------------------------------------"
