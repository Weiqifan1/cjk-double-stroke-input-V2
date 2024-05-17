using System.Text;
using double_stroke.projectFolder.StaticFileMaps;

namespace double_stroke.projectFolder.FileMaps;

public static class UtilityFunctions
{
    
    public static Dictionary<string, List<UnicodeCharacter>> generateRawIdsMap(
        string idsPath, Dictionary<string, string> priviledgedElemn)
    {
        var idsLines = UtilityFunctions.removeIntroductionLines(idsPath, 2);
        Dictionary<string, List<UnicodeCharacter>> tempDictionary = 
            new Dictionary<string, List<UnicodeCharacter>>();
        var charsToRemove = irrelevantShapeAndLatinCharacters();

        foreach (string eachRawIdsLine in idsLines)
        {
            string[] splitstr = 
                eachRawIdsLine.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = UtilityFunctions.firstUnicodeCharacter(splitstr[1]);
            List<UnicodeCharacter> strSplitIds = UtilityFunctions.CreateUnicodeCharacters(splitstr[2]);

            if (character.Equals(new UnicodeCharacter("是")))//"朩")))
            {
                string testWeird = "";
            }

            if (priviledgedElemn.Keys.Contains(character.Value))
            {
                string priviledgeVal = priviledgedElemn.GetValueOrDefault(character.Value);
                tempDictionary.TryAdd(character.Value, new List<UnicodeCharacter>{new UnicodeCharacter(priviledgeVal)});
            }
            else
            {
                tempDictionary.TryAdd(character.Value, strSplitIds);
            }

        }
        return tempDictionary;
    }
    
    public static List<UnicodeCharacter> irrelevantShapeAndLatinCharacters()
    {
        List<UnicodeCharacter> result = new List<UnicodeCharacter>();
        string ideographicDiscription = UtilityFunctions.ideographicCharacterRange();
        var ideographics = UtilityFunctions.CreateUnicodeCharacters(ideographicDiscription);
        var final = ideographics.Concat(latinCharcters()).ToList();
        return final;
    }
    
    
    public static List<UnicodeCharacter> latinCharcters()
    {
        string asciiStr = UtilityFunctions.GetAllAsciiCharacters();
        var ascii = UtilityFunctions.CreateUnicodeCharacters(asciiStr);
        return ascii;
    }

    public static Dictionary<string, CodepointBasicRecord> generateCodepointMap(
        Dictionary<string, CodepointExceptionRecord> codeExceptions,
        Dictionary<string, IdsBasicRecord> idsMap,
        string codepointPath)
    {
        const int introLinesCount = 87;
        var codepointLines = UtilityFunctions.removeIntroductionLines(codepointPath, introLinesCount);
        var uniDict = GenerateUniDictionary(codepointLines);
        //var test = uniDict.GetValueOrDefault("鰠");
        var result = GenerateFinalUnicodeMap(uniDict, codeExceptions, idsMap);
        return result;
    }
    
    
    public static Dictionary<string, List<string>> GenerateUniDictionary(IEnumerable<string> codepointLines)
    {
        //add the missing codepointLines
        //missing junda:
        //裏 3 秊  1
        //missing tzai:
        // 兀  119  嗀  11
        List<string> missingChars = new List<string>();
        string one1 = "U+F9E7\t裏\t4125111213534";// + Environment.NewLine;
        string two2 = "U+F995\t秊\t31234312"; //+ Environment.NewLine;
        string three3 = "U+FA0C\t兀\t135"; //+ Environment.NewLine;
        string four4 = "U+FA0D\t嗀\t1214512513554";// + Environment.NewLine;
                     
        missingChars.Add(one1);
        missingChars.Add(two2);
        missingChars.Add(three3);
        missingChars.Add(four4);
        
        Dictionary<string, List<string>> uniDict = new Dictionary<string, List<string>>();
        foreach (string input in codepointLines)
        {
            addToUniDict(input, uniDict);
        }

        foreach (var VARIABLE in missingChars)
        {
            addToUniDict(VARIABLE, uniDict);
        }
        
        return uniDict;
    }
    
    
    
    private static Dictionary<string, CodepointBasicRecord> GenerateFinalUnicodeMap(
        Dictionary<string, List<string>> uniDict, 
        Dictionary<string, CodepointExceptionRecord> codeExceptions, 
        Dictionary<string, IdsBasicRecord> idsMap)
    {
        var finalUnicodeMap = new Dictionary<string, CodepointBasicRecord>();
        foreach (var entry in uniDict)
        {
            if (entry.Key.Equals("鰠"))
            {
                string test = "";
            }

            var character = new UnicodeCharacter(entry.Key);
            CodepointBasicRecord prelimEntry = generateCodepointRecord(entry, codeExceptions, idsMap);
            finalUnicodeMap[character.Value] = prelimEntry; 
        }
        return finalUnicodeMap;
    }
    
    
    private static void addToUniDict(string input, Dictionary<string, List<string>> uniDict)
    {
        if (!input.StartsWith("U+")) return;
        string[] splitstr = 
            input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        if (splitstr[1].Equals("鰠^"))
        {
            string test = "";
        }

        var character = UtilityFunctions.firstUnicodeCharacter(splitstr[1]);
        if (!uniDict.ContainsKey(character.Value)) 
        {
            uniDict[character.Value] = new List<string>();
        }
        uniDict[character.Value].Add(splitstr[2]);
    }
    
    
    private static CodepointBasicRecord generateCodepointRecord(
        KeyValuePair<string, List<string>> entry, 
        Dictionary<string, CodepointExceptionRecord> codeExceptions, 
        Dictionary<string, IdsBasicRecord> idsMap)
    {
        if (entry.Value.Count != 1)
        {
            throw new FormatException("CodepointBasicRecord is given badly formatted: " + entry);
        }

        string firstItemInEntry = entry.Value[0];
        CodepointBasicRecord result = new CodepointBasicRecord(firstItemInEntry);

        string test = "";
        return result;
    }
    
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