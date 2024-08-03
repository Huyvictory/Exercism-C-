using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators

    public static bool operator ==(CurrencyAmount amount1, CurrencyAmount amount2)
    {
        if (amount1.currency != amount2.currency)
        {
            throw new ArgumentException("Currencies must be the same");
        }

        return amount1.amount == amount2.amount;
    }

    public static bool operator !=(CurrencyAmount amount1, CurrencyAmount amount2)
    {
        return !(amount1 == amount2);
    }

    // TODO: implement comparison operators
    public static bool operator <(CurrencyAmount amount1, CurrencyAmount amount2)
    {
        if (amount1.currency != amount2.currency)
        {
            throw new ArgumentException("Currencies must be the same");
        }

        return amount1.amount < amount2.amount;
    }

    public static bool operator >(CurrencyAmount amount1, CurrencyAmount amount2)
    {
        if (amount1.currency != amount2.currency)
        {
            throw new ArgumentException("Currencies must be the same");
        }

        return amount1.amount > amount2.amount;
    }

    // TODO: implement arithmetic operators

    public static CurrencyAmount operator +(CurrencyAmount amount1, CurrencyAmount amount2)
    {
        if (amount1.currency != amount2.currency)
        {
            throw new ArgumentException("Currencies must be the same");
        }

        return new CurrencyAmount(amount1.amount + amount2.amount, amount1.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount amount1, CurrencyAmount amount2)
    {
        if (amount1.currency != amount2.currency)
        {
            throw new ArgumentException("Currencies must be the same");
        }

        return new CurrencyAmount(amount1.amount - amount2.amount, amount1.currency);
    }

    public static CurrencyAmount operator *(decimal factor, CurrencyAmount amount)
    {
        return new CurrencyAmount(amount.amount * factor, amount.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount amount, decimal factor)
    {
        return new CurrencyAmount(amount.amount * factor, amount.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount amount, decimal divisor)
    {
        return new CurrencyAmount(amount.amount / divisor, amount.currency);
    }

    // TODO: implement type conversion operators

    public static implicit operator decimal(CurrencyAmount amount)
    {
        return amount.amount;
    }

    public static explicit operator double(CurrencyAmount amount)
    {
        return Convert.ToDouble(amount.amount);
    }
}