using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        var position = shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 or 4 => "midfielder",
            5 => "right back",
            6 or 7 or 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => throw new ArgumentOutOfRangeException(nameof(shirtNum))
        };

        return position;
    }

    public static string AnalyzeOffField(object report)
    {
        var announcement = report switch
        {
            int numberObj => $"There are {numberObj} supporters at the match.",
            string stringObj => stringObj,
            Foul foulObj => foulObj.GetDescription(),
            Injury injuryObj => $"Oh no! {injuryObj.GetDescription()} Medics are on the field.",
            Incident incidentObj => incidentObj.GetDescription(),
            Manager mangerObj
                => $"{mangerObj.Name} {(!string.IsNullOrEmpty(mangerObj.Club) ? $"({mangerObj.Club})" : string.Empty)}"
                    .Trim(),
            _ => throw new ArgumentException(),
        };

        return announcement;
    }
}