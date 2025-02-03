using System;
using System.Collections.Generic;

PhoneNumber.Analyze("212-555-1234");
public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber) 
    {
        var phoneTest = phoneNumber.Split('-');
        return ((phoneTest[0].Contains("212") ? true : false), (phoneTest[1].Contains("555") ? true : false), phoneTest[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return (phoneNumberInfo.IsFake == true) ? true : false;
    }


}
