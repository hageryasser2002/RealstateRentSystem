using System.Collections.Generic;

public static class SessionManager
{
    private static HashSet<string> _openedRecords = new HashSet<string>();

    public static void AddOpenedRecord(string recordType, int recordId)
    {
        string key = $"{recordType}|{recordId}";
        _openedRecords.Add(key);
    }

    public static bool IsRecordOpened(string recordType, int recordId)
    {
        string key = $"{recordType}|{recordId}";
        return _openedRecords.Contains(key);
    }

    public static void ClearSession()
    {
        _openedRecords.Clear();
    }
}