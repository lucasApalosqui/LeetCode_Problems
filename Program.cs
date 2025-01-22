using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance) => balance switch 
    {
        < 0 => (float)3.213,
        < 1000 => (float)0.5,
        >= 1000 and < 5000 => (float)1.621,
        >= 5000 => (float)2.475
    };

    public static decimal Interest(decimal balance)
    {
        return balance * ((decimal)InterestRate(balance)) / 100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int quant = 0;
        while (balance < targetBalance)
        {
            quant++;
            balance = AnnualBalanceUpdate(balance);
        }

        return quant;

    }
}
