using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (string.IsNullOrEmpty(identifier))
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder(identifier);

        string finalOutput;

        sb.Replace(" ", "_");

        sb.Replace("\0", "CTRL");

        finalOutput = ConvertKebabToCamelCase(sb.ToString());

        finalOutput = onlyAllowLetterCharacters(finalOutput);

        finalOutput = OmitLowercaseGreekLetters(finalOutput);

        return finalOutput;
    }

    public static string ConvertKebabToCamelCase(string input)
    {
        string[] parts = input.Split('-');
        StringBuilder result = new StringBuilder(parts[0]);

        for (int i = 1; i < parts.Length; i++)
        {
            if (parts[i].Length > 0)
            {
                result.Append(char.ToUpper(parts[i][0], CultureInfo.InvariantCulture));
                if (parts[i].Length > 1)
                {
                    result.Append(parts[i].Substring(1));
                }
            }
        }

        return result.ToString();
    }

    public static string onlyAllowLetterCharacters(string input)
    {
        StringBuilder result = new StringBuilder(input);

        foreach (char c in input)
        {
            if (!char.IsLetter(c) && c != '_')
            {
                result.Remove(result.ToString().IndexOf(c), 1);
            }
        }

        return result.ToString();
    }

    public static string OmitLowercaseGreekLetters(string input)
    {
        return Regex.Replace(input, @"[\u0370-\u03FF\u1F00-\u1FFF-[\u039F]]", string.Empty);
    }
}
