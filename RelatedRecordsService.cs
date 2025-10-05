using RealStateRentSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

public class RelatedRecordsService
{
    public static DataTable FindRelatedRecords(List<string> phoneNumbers, string currentRecordType, int currentRecordId, string name = "", string eventtext = "")
    {
        DataTable results = new DataTable();
        results.Columns.Add("Type", typeof(string));
        results.Columns.Add("ID", typeof(int));
        results.Columns.Add("Name", typeof(string));
        results.Columns.Add("Phone", typeof(string));
        results.Columns.Add("Active", typeof(bool));
        results.Columns.Add("Event", typeof(string));
        results.Columns.Add("Other", typeof(string));

        if (phoneNumbers == null) phoneNumbers = new List<string>();

        // Base queries
        string phoneQuery = "SELECT Phone.ID, Name as n, p1, m2, p2, m3, Other as o, phoneEvent.Event as event FROM Phone LEFT JOIN phoneEvent ON Phone.ID = phoneEvent.PhoneID WHERE ";
        string rentQuery = "SELECT RealState.ID, Owner as n, Phone_one, Mobile, Phone_Two, Mobile2, Other as o, Event.Event as event, RealState.Active FROM RealState LEFT JOIN Event ON RealState.ID = Event.RealStateID WHERE ";
        string ownQuery = "SELECT RealstateOwne.ID, Owner as n, Phone_one, Mobile, Phone_Two, Mobile2, Other as o, eventown.Event as event, RealstateOwne.Active FROM RealstateOwne LEFT JOIN eventown ON RealstateOwne.ID = eventown.RealStateID WHERE ";
        string careerQuery = "SELECT career.ID, Name as n, p, m, p as ptwo, m as mtwo, Other as o, careerEvent.Event as event FROM career LEFT JOIN careerEvent ON career.ID = careerEvent.careerID WHERE ";

        List<string> conditions = new List<string>();

        // Handle phone number conditions
        foreach (var number in phoneNumbers)
        {
            if (string.IsNullOrWhiteSpace(number)) continue;
            string cond = BuildPhoneCondition(number);
            conditions.Add(cond);
        }

        string phoneConditions = string.Join(" OR ", conditions);
        string rentConditions = phoneConditions;
        string ownConditions = phoneConditions;
        string careerConditions = phoneConditions.Replace("p1", "p").Replace("p2", "p").Replace("m2", "m").Replace("m3", "m");

        // Handle name conditions including Arabic variations
        if (!string.IsNullOrWhiteSpace(name))
        {
            string nameCondition = BuildNameCondition(name);
            rentConditions += (rentConditions != "" ? " OR " : "") + nameCondition.Replace("Name", "Owner").Replace("Other", "Other");
            ownConditions += (ownConditions != "" ? " OR " : "") + nameCondition.Replace("Name", "Owner").Replace("Other", "Other");
            phoneConditions += (phoneConditions != "" ? " OR " : "") + nameCondition.Replace("Owner", "Name").Replace("Other", "Other");
            careerConditions += (careerConditions != "" ? " OR " : "") + nameCondition.Replace("Owner", "Name").Replace("Other", "Other");
        }

        // Handle event conditions
        if (!string.IsNullOrWhiteSpace(eventtext))
        {
            string eventCondition = $"Event LIKE '%{eventtext.Replace("'", "''")}%'";

            rentConditions += (rentConditions != "" ? " AND " : "") + eventCondition;
            ownConditions += (ownConditions != "" ? " AND " : "") + eventCondition.Replace("Event", "eventown.Event");
            phoneConditions += (phoneConditions != "" ? " AND " : "") + eventCondition.Replace("Event", "phoneEvent.Event");
            careerConditions += (careerConditions != "" ? " AND " : "") + eventCondition.Replace("Event", "careerEvent.Event");
        }

        // Append conditions to queries
        if (!string.IsNullOrWhiteSpace(rentConditions)) rentQuery += $"({rentConditions}) AND RealState.ID <> {currentRecordId}";
        if (!string.IsNullOrWhiteSpace(ownConditions)) ownQuery += $"({ownConditions}) AND RealstateOwne.ID <> {currentRecordId}";
        if (!string.IsNullOrWhiteSpace(phoneConditions)) phoneQuery += $"({phoneConditions}) AND Phone.ID <> {currentRecordId}";
        if (!string.IsNullOrWhiteSpace(careerConditions)) careerQuery += $"({careerConditions}) AND career.ID <> {currentRecordId}";

        // Execute queries and merge
        DataTable dtPhone = Form1.get(phoneQuery);
        DataTable dtRent = Form1.get(rentQuery);
        DataTable dtOwn = Form1.get(ownQuery);
        DataTable dtCareer = Form1.get(careerQuery);

        results.Merge(dtRent, true);
        results.Merge(dtOwn, true);
        results.Merge(dtPhone, true);
        results.Merge(dtCareer, true);
        results.AcceptChanges();

        // Filter out opened records
        DataTable finalResults = results.Clone();
        foreach (DataRow row in results.Rows)
        {
            string type = row["Type"].ToString();
            int id = Convert.ToInt32(row["ID"]);
            if (!IsRecordOpened(type, id))
                finalResults.ImportRow(row);
        }

        return finalResults;
    }

    private static string BuildPhoneCondition(string number)
    {
        int index = number.IndexOf('*');
        string cond = "";
        if (index > 0)
        {
            string val = number.Substring(0, index);
            cond = $"(Phone_one LIKE '{val}%' OR Phone_Two LIKE '{val}%' OR Mobile LIKE '{val}%' OR Mobile2 LIKE '{val}%' OR Other LIKE '{val}%')";
        }
        else if (index == 0)
        {
            string val = number.Substring(1);
            cond = $"(Phone_one LIKE '%{val}' OR Phone_Two LIKE '%{val}' OR Mobile LIKE '%{val}' OR Mobile2 LIKE '%{val}' OR Other LIKE '%{val}')";
        }
        else
        {
            cond = $"(Phone_one LIKE '%{number}%' OR Phone_Two LIKE '%{number}%' OR Mobile LIKE '%{number}%' OR Mobile2 LIKE '%{number}%' OR Other LIKE '%{number}%')";
        }
        return cond;
    }

    private static string BuildNameCondition(string name)
    {
        List<string> variations = new List<string> { "أ", "ا", "ه", "ة", "ي", "ى" };
        string cond = "(";
        cond += $"Owner LIKE '%{name.Replace("'", "''")}%' OR Other LIKE '%{name.Replace("'", "''")}%'";
        foreach (var v in variations)
        {
            string temp = name.Replace("أ", "ا").Replace("ه", "ة").Replace("ي", "ى");
            cond += $" OR Owner LIKE '%{temp.Replace("'", "''")}%' ";
        }
        cond += ")";
        return cond;
    }

    private static bool IsRecordOpened(string recordType, int recordId)
    {
        foreach (Form form in Application.OpenForms)
        {
            if (form is Realstate rentForm && rentForm.recored_id == recordId && recordType.Contains("إيجار"))
                return true;
            if (form is RealstateOwner ownForm && ownForm.recored_id == recordId && recordType.Contains("بيع"))
                return true;
            if (form is phone phoneForm && phoneForm.recored_id == recordId && recordType == "الهاتف")
                return true;
            if (form is career careerForm && careerForm.recored_id == recordId && recordType == "مهن")
                return true;
        }
        return false;
    }
}
