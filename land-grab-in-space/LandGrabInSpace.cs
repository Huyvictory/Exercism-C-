using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    private ushort X { get; }
    private ushort Y { get; }

    public override bool Equals(object obj)
    {
        if (obj is Coord coord)
        {
            return coord.X == X && coord.Y == Y;
        }

        return false;
    }

    public static bool operator >(Coord coord1, Coord coord2)
    {
        return coord1.X > coord2.X || coord1.Y > coord2.Y;
    }

    public static bool operator <(Coord coord1, Coord coord2)
    {
        return coord1.X < coord2.X || coord1.Y < coord2.Y;
    }
}

public struct Plot
{
    // TODO: Complete implementation of the Plot struct
    public Plot(Coord origin1, Coord origin2, Coord origin3, Coord origin4)
    {
        Origin1 = origin1;
        Origin2 = origin2;
        Origin3 = origin3;
        Origin4 = origin4;
    }

    private Coord Origin4 { get; }

    private Coord Origin3 { get; }

    private Coord Origin2 { get; }

    private Coord Origin1 { get; }

    public override bool Equals(object obj)
    {
        if (obj is Plot plot)
        {
            return Origin1.Equals(plot.Origin1) && Origin2.Equals(plot.Origin2) && Origin3.Equals(plot.Origin3) &&
                   Origin4.Equals(plot.Origin4);
        }

        return false;
    }

    public static bool operator >(Plot plot1, Plot plot2)
    {
        return plot1.Origin1 > plot2.Origin1 || plot1.Origin2 > plot2.Origin2 || plot1.Origin3 > plot2.Origin3 ||
               plot1.Origin4 > plot2.Origin4;
    }

    public static bool operator <(Plot plot1, Plot plot2)
    {
        return plot1.Origin1 < plot2.Origin1 || plot1.Origin2 < plot2.Origin2 || plot1.Origin3 < plot2.Origin3 ||
               plot1.Origin4 < plot2.Origin4;
    }
}

public class ClaimsHandler
{
    private readonly List<Plot> _claimedPlots = [];

    public void StakeClaim(Plot plot)
    {
        if (!IsClaimStaked(plot))
        {
            _claimedPlots.Add(plot);
        }
    }

    public bool IsClaimStaked(Plot plot)
    {
        foreach (var claimedPlot in _claimedPlots)
        {
            if (plot.Equals(claimedPlot))
            {
                return true;
            }
        }

        return false;
    }

    public bool IsLastClaim(Plot plot)
    {
        var listClaimedPlots = _claimedPlots;
        return plot.Equals(listClaimedPlots.Last());
    }

    public Plot GetClaimWithLongestSide()
    {
        var plotWithLongestSide = new Plot(new Coord(0, 0), new Coord(0, 0), new Coord(0, 0), new Coord(0, 0));
        for (var i = 0; i < _claimedPlots.Count; i++)
        {
            var plot1 = _claimedPlots[i];
            var plot2 = _claimedPlots[i + 1];

            if (plot1 > plot2)
            {
                plotWithLongestSide = plot1;
                break;
            }

            if (plot1 < plot2)
            {
                plotWithLongestSide = plot2;
                break;
            }
        }

        return plotWithLongestSide;
    }
}