using double_stroke.projectFolder.StaticFileMaps;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace test_double_stroke.testStaticFiles;


public class TestAlternativeCharsets: testSetup
{
    //AlternativeCharsets
    
    
    [Test]
    public void totalMissingChars()
    {
        HashSet<string> miss = getMissing();
        Dictionary<string, List<string>> sorted = GroupByUnicodeBlock(miss);//new Dictionary<string, List<string>>();
        
        Assert.IsTrue(1 == 2);
    }

    private static HashSet<string> getMissing()
    {
        HashSet<string> allChars = AlternativeCharsets.getAllchars();

        HashSet<string> exceptChars = foundExceptions.Keys.ToHashSet();

        HashSet<string> missingChars = new HashSet<string>();

        foreach (var VARIABLE in allChars)
        {
            if (!exceptChars.Contains(VARIABLE))
            {
                missingChars.Add(VARIABLE);
            }
        }
        return missingChars;
    }
    /*
    
    public Dictionary<string, List<string>> GroupByUnicodeBlock(HashSet<string> characters)
    {
        var result = new Dictionary<string, List<string>>();

        foreach (string character in characters)
        {
            int codepoint = char.ConvertToUtf32(character, 0);
            UnicodeCategory unicodeBlock = CharUnicodeInfo.GetUnicodeCategory(codepoint);

            string blockName = unicodeBlock.ToString();

            if (!result.ContainsKey(blockName))
            {
                result[blockName] = new List<string>();
            }

            result[blockName].Add(character);
        }

        foreach (var unicodeBlock in result.Keys.ToList())
        {
            result[unicodeBlock] = result[unicodeBlock].OrderBy(char.ConvertToUtf32).ToList();
        }

        return result;
    }
    */
    public Dictionary<string, List<string>> GroupByUnicodeBlock(HashSet<string> characters)
    {
        var result = new Dictionary<string, List<string>>();

        foreach (string character in characters)
        {
            int codepoint = char.ConvertToUtf32(character, 0);
            UnicodeCategory unicodeBlock = CharUnicodeInfo.GetUnicodeCategory(codepoint);

            string blockName = unicodeBlock.ToString();

            if (!result.ContainsKey(blockName))
            {
                result[blockName] = new List<string>();
            }

            result[blockName].Add(character);
        }

        foreach (var unicodeBlock in result.Keys.ToList())
        {
            result[unicodeBlock] = result[unicodeBlock].OrderBy(c => char.ConvertToUtf32(c, 0)).ToList();
        }

        return result;
    }
}