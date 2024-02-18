using System.Text;
using System.Text.RegularExpressions;

namespace double_stroke.projectFolder.StaticFileMaps;

public static class RolloutStrokes
{
    public static HashSet<string> rolloutString(string input)
    {
        //the input is a single string because each character in the codepoint file
        //can ONLY have one character code.
        
        //replace backslashes with dasg
        var dashString = input.Replace("\\", "-");
        var replaceDashNumPair = ReplaceWithParenPair(dashString);
        HashSet<string> result = PrepareCombinations(replaceDashNumPair);
        return result;
    }
    
    public static string ReplaceWithParenPair(string input)
    {
        // extract parenthetical groups
        var matches = Regex.Matches(input, @"\(([^)]*)\)");
        var replacements = matches.Cast<Match>().Select(m => m.Value).ToArray();
    
        // replace '-' followed by number with the corresponding parenthetical group
        var replacedInput = Regex.Replace(input, @"-\d", m => {
            var index = int.Parse(m.Value.Substring(1)) - 1;
            return index >= 0 && index < replacements.Length ? replacements[index] : m.Value;
        });
    
        return replacedInput;
    }
    
    private static HashSet<string> PrepareCombinations(string input)
    {
        var results = new HashSet<string> {input};
        var regex = new Regex(@"\(([^)]*)\)");
        
        while (true)
        {
            var newResults = new HashSet<string>();
            var replacementsExists = false;
            
            foreach (var sequence in results)
            {
                var match = regex.Match(sequence);
                if (match.Success)
                {
                    replacementsExists = true;
                    var alternatives = match.Groups[1].Value.Split('|');
                    foreach (var alternative in alternatives)
                    {
                        newResults.Add(sequence.Remove(match.Index, match.Length).Insert(match.Index, alternative));
                    }
                }
                else
                {
                    newResults.Add(sequence);
                }
            }

            results = newResults;
            if (!replacementsExists) 
                break;
        }
        
        return results;
    }

}