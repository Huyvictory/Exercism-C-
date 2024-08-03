using System;
using System.Globalization;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            var denomination = checked(@base * multiplier);
            return denomination.ToString();
        }
        catch (OverflowException e)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        var gdp = @base * multiplier;
        return float.IsInfinity(gdp) ? "*** Too Big ***" : gdp.ToString(CultureInfo.InvariantCulture);
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            var chiefEconomistSalary = salaryBase * multiplier;
            return chiefEconomistSalary.ToString(CultureInfo.InvariantCulture);
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}