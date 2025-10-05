using RealStateRentSystem;
using System.Collections.Generic;
using System.Linq;

public static class PhoneNormalizer
{
    public static string NormalizePhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
            return string.Empty;

        // Remove all non-digit characters
        string normalized = new string(phoneNumber.Where(char.IsDigit).ToArray());

        // Handle common prefixes
        if (normalized.StartsWith("00963"))
            normalized = normalized.Substring(5);
        else if (normalized.StartsWith("963"))
            normalized = normalized.Substring(3);
        else if (normalized.StartsWith("0"))
            normalized = normalized.Substring(1);

        return normalized;
    }

    public static List<string> ExtractNormalizedNumbers(Realstate form)
    {
        List<string> numbers = new List<string>();

        // Extract and normalize all phone fields
        string[] phoneFields = {
            form.txtPhoneOne.Text,
            form.txtMobile.Text,
            form.txtMobile2.Text,
            form.txtOther.Text
        };

        foreach (string phoneField in phoneFields)
        {
            string normalized = NormalizePhoneNumber(phoneField);
            if (!string.IsNullOrEmpty(normalized))
                numbers.Add(normalized);
        }

        return numbers.Distinct().ToList();
    }

    //public static List<string> ExtractNormalizedNumbers(RealstateOwner form)
    //{
    //    List<string> numbers = new List<string>();

    //    // Extract and normalize all phone fields
    //    string[] phoneFields = {
    //        form.p1,
    //        form.p2,
    //        form.m1,
    //        form.m2
    //    };

    //    foreach (string phoneField in phoneFields)
    //    {
    //        string normalized = NormalizePhoneNumber(phoneField);
    //        if (!string.IsNullOrEmpty(normalized))
    //            numbers.Add(normalized);
    //    }

    //    return numbers.Distinct().ToList();
    //}


}