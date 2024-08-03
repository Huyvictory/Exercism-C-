using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (var bird in birdsPerDay)
        {
            if (bird == 0)
            {
                return true;
            }
        }

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int birdsCounted = 0;

        for (int i = 0; i < numberOfDays; i++)
        {
            birdsCounted += birdsPerDay[i];
        }

        return birdsCounted;
    }

    public int BusyDays()
    {
        int numbersOfBusyDays = 0;

        foreach (var item in birdsPerDay)
        {
            if (item >= 5)
            {
                numbersOfBusyDays++;
            }
        }

        return numbersOfBusyDays;
    }
}
