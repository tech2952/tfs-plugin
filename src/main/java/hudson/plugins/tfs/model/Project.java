package hudson.plugins.tfs.model;

import hudson.plugins.tfs.commands.BriefHistoryCommand;
import hudson.plugins.tfs.commands.DetailedHistoryCommand;
import hudson.plugins.tfs.commands.GetFilesToWorkFolderCommand;
import hudson.plugins.tfs.commands.RemoteChangesetVersionCommand;
import hudson.plugins.tfs.commands.WorkspaceChangesetVersionCommand;

import java.io.IOException;
import java.io.Reader;
import java.text.ParseException;
import java.util.Calendar;
import java.util.List;

import org.apache.commons.io.IOUtils;
import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.HashCodeBuilder;

public class Project {

    private final String projectPath;
    private final Server server;

    public Project(Server server, String projectPath) {
        this.server = server;
        this.projectPath = projectPath;
    }

    public String getProjectPath() {
        return projectPath;
    }

    /**
     * Returns a list of change sets containing modified items.
     * @param fromTimestamp the timestamp to get history from
     * @param toTimestamp the timestamp to get history to
     * @return a list of change sets
     */
    public List<ChangeSet> getDetailedHistory(Calendar fromTimestamp, Calendar toTimestamp) throws IOException, InterruptedException, ParseException {
        DetailedHistoryCommand command = new DetailedHistoryCommand(server, projectPath, fromTimestamp, toTimestamp);
        Reader reader = null;
        try {
            reader = server.execute(command.getArguments());
            return command.parse(reader);
        } finally {
            IOUtils.closeQuietly(reader);
        }
    }

    /**
     * Returns a list of change sets not containing the modified items.
     * @param fromTimestamp the timestamp to get history from
     * @param toTimestamp the timestamp to get history to
     * @return a list of change sets
     */
    public List<ChangeSet> getBriefHistory(Calendar fromTimestamp, Calendar toTimestamp) throws IOException, InterruptedException, ParseException {
        BriefHistoryCommand command = new BriefHistoryCommand(server, projectPath, fromTimestamp, toTimestamp);
        Reader reader = null;
        try {
            reader = server.execute(command.getArguments());
            return command.parse(reader);
        } finally {
            IOUtils.closeQuietly(reader);
        }
    }

    /**
     * Returns a list of change sets not containing the modified items.
     * @param fromChangeset the changeset number to get history from
     * @param toTimestamp the timestamp to get history to
     * @return a list of change sets
     */
    public List<ChangeSet> getBriefHistory(int fromChangeset, Calendar toTimestamp) throws IOException, InterruptedException, ParseException {
        BriefHistoryCommand command = new BriefHistoryCommand(server, projectPath, fromChangeset, toTimestamp);
        Reader reader = null;
        try {
            reader = server.execute(command.getArguments());
            return command.parse(reader);
        } finally {
            IOUtils.closeQuietly(reader);
        }
    }

    /**
     * Gets all files from server.
     * @param localPath the local path to get all files into
     */
    public void getFiles(String localPath) throws IOException, InterruptedException {
        GetFilesToWorkFolderCommand command = new GetFilesToWorkFolderCommand(server, localPath);
        server.execute(command.getArguments()).close();
    }

    /**
     * Gets all files from server.
     * @param localPath the local path to get all files into
     * @param versionSpec the version spec to use when getting the files
     */
    public void getFiles(String localPath, String versionSpec) throws IOException, InterruptedException {
        GetFilesToWorkFolderCommand command = new GetFilesToWorkFolderCommand(server, localPath, versionSpec);
        server.execute(command.getArguments()).close();
    }

    /**
     * Gets workspace changeset version for specified local path.
     * 
     * @param localPath for which to get latest workspace changeset version
     * @param workspaceName name of workspace for which to get latest changeset version
     * @return workspace changeset version for specified local path
     */
    public String getWorkspaceChangesetVersion(String localPath, String workspaceName, String workspaceOwner) 
                                                                                       throws IOException, 
                                                                                              InterruptedException, 
                                                                                              ParseException {
        WorkspaceChangesetVersionCommand command = new WorkspaceChangesetVersionCommand(server,projectPath,workspaceName, workspaceOwner);
        Reader reader = null;
        try {
            reader = server.execute(command.getArguments());
            return command.parse(reader);
        } finally {
            IOUtils.closeQuietly(reader);
        }
    }

    /**
     * Gets remote changeset version for specified remote path, as of toTimestamp.
     * 
     * @param remotePath for which to get latest changeset version
     * @param toTimestamp the date/time of the last build
     * @return changeset version for specified remote path
     */
    public int getRemoteChangesetVersion(String remotePath, Calendar toTimestamp)
            throws IOException, InterruptedException, ParseException {
        RemoteChangesetVersionCommand command = new RemoteChangesetVersionCommand(server, projectPath, toTimestamp);
        Reader reader = null;
        try {
            reader = server.execute(command.getArguments());
            final String changesetString = command.parse(reader);
            return Integer.parseInt(changesetString, 10);
        } finally {
            IOUtils.closeQuietly(reader);
        }
    }

    /**
     * Gets remote changeset version for the project's remote path, as of toTimestamp.
     * 
     * @param toTimestamp the date/time of the last build
     * @return changeset version for the project's remote path
     */
    public int getRemoteChangesetVersion(Calendar toTimestamp)
            throws IOException, InterruptedException, ParseException {
        return getRemoteChangesetVersion(projectPath, toTimestamp);
    }
    
    @Override
    public int hashCode() {
        return new HashCodeBuilder(13, 27).append(projectPath).toHashCode();
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if ((obj == null) || (getClass() != obj.getClass()))
            return false;
        final Project other = (Project) obj;
        EqualsBuilder builder = new EqualsBuilder();
        builder.append(this.projectPath, other.projectPath);
        return builder.isEquals();
    }
}
