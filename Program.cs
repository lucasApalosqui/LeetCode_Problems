//https://leetcode.com/problems/palindrome-number
//Palimdrome Number

using System;

Solution p = new Solution();

Console.WriteLine(p.IsPalindrome(1234567899));


public class Solution
{
    public bool IsPalindrome(int x)
    {
        string verifyNumber;

        if (x < 0)
            return false;

        verifyNumber = x.ToString();
        long newNumber = GerarNumeroContrário(verifyNumber);

        if (newNumber == x)
            return true;

        else
            return false;

    }

    public long GerarNumeroContrário(string number)
    {
        string newNumber = "";
        for (int i = 0; i < number.Length; i++)
        {
            newNumber += number[number.Length - i - 1];
        }
        return Int64.Parse(newNumber);

    }
}