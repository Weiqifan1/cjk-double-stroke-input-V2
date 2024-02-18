using System.Text;
using double_stroke.projectFolder.StaticFileMaps;

namespace double_stroke.projectFolder.FileMaps;

public static class UtilityFunctions
{
    public static UnicodeCharacter firstUnicodeCharacter(string rawCharacter)
    {
        List<UnicodeCharacter> clean  = CreateUnicodeCharacters(rawCharacter);
        return clean[0];
    }
    
    public static List<UnicodeCharacter> CreateUnicodeCharacters(string input)
    {
        var characters = new List<UnicodeCharacter>();
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsHighSurrogate(input[i]) && i + 1 < input.Length && char.IsLowSurrogate(input[i + 1]))
            {
                // Unicode character is a surrogate pair
                characters.Add(new UnicodeCharacter(input.Substring(i, 2)));
                i++; // because we processed two chars
            }
            else
            {
                // Unicode character is a single char
                characters.Add(new UnicodeCharacter(input[i].ToString()));
            }
        }
        return characters;
    }
    
    
    public static List<string> ReadLinesFromFile(string filename)
    {
        try
        {
            var lines = new List<string>();
            StreamReader reader = new StreamReader(filename);

            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    
    public static string ideographicCharacterRange()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0x2FF0; i <= 0x2FFF; i++)
        {
            sb.Append(char.ConvertFromUtf32(i)); // Converts int to Unicode character and appends it to string builder
        }
        string output = sb.ToString(); // Holds all the characters from U+2FF0 to U+2FFF
        return output;
    }

    public static string GetAllAsciiCharacters()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i <= 127; i++)
        {
            sb.Append((char)i);
        }
        return sb.ToString();
    }
    
    
    public static List<UnicodeCharacter> removeUnvantedCharacters(
        List<UnicodeCharacter> rolldOutids, 
        List<UnicodeCharacter> charsToRemove)
    {
        List<UnicodeCharacter> result = new List<UnicodeCharacter>();
        foreach (var VARIABLE in rolldOutids)
        {
            if (!charsToRemove.Contains(VARIABLE))
            {
                result.Add(VARIABLE);
            }
        }
        return result;
    }
    
    
    public static List<string> removeIntroductionLines(string filePath, int introductoryLineLimmit)
    {
        var rawLines = UtilityFunctions.ReadLinesFromFile(filePath);
        var resultLines = rawLines.Skip(introductoryLineLimmit).ToList();
        return resultLines;
    }
    
}