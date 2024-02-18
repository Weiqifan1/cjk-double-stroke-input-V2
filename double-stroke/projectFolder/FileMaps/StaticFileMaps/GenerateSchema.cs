namespace double_stroke.projectFolder.StaticFileMaps;

public static class GenerateSchema
{
    //TODO inplement functions
    
    public static Dictionary<string, SchemeRecord> generateCharToSchema(List<SchemeRecord> schemaList)
    {
        Dictionary<string, SchemeRecord> result = 
            new Dictionary<string, SchemeRecord>();
        //get all codes
        foreach (var VARIABLE in schemaList)
        {
            result.Add(VARIABLE.character, VARIABLE);
            
        }
        return result;
    }

    private static HashSet<string> generateAllCodes(List<SchemeRecord> schemaList)
    {
        HashSet<string> result = new HashSet<string>();
        foreach (var VARIABLE in schemaList)
        {
            result.UnionWith(VARIABLE.code4);
            result.UnionWith(VARIABLE.code6);
        }
        return result;
    }

    public static Dictionary<string, HashSet<SchemeRecord>> generateCodeToSchema(List<SchemeRecord> schemaList)
    {
        Dictionary<string, HashSet<SchemeRecord>> result = new Dictionary<string, HashSet<SchemeRecord>>();
        HashSet<string> allCodes = generateAllCodes(schemaList);
        foreach (var VARIABLE in schemaList)
        {
            HashSet<string> codeInVariable = new HashSet<string>();
            codeInVariable.UnionWith(VARIABLE.code4);
            codeInVariable.UnionWith(VARIABLE.code6);
            foreach (var EACHCODEE in codeInVariable)
            {
                    if (!result.ContainsKey(EACHCODEE))
                    {
                        result.Add(EACHCODEE, new HashSet<SchemeRecord> { VARIABLE });
                    }
                    HashSet<SchemeRecord> currentContent = result[EACHCODEE];
                    HashSet<string> currentChars = currentContent.Select(a => a.character).ToHashSet();
                    if (!currentChars.Contains(VARIABLE.character))
                    {
                        result[EACHCODEE].Add(VARIABLE);
                    } 
            }
        }
        return result;
    }
}

/*
 Dictionary<string, HashSet<SchemeRecord>> result = new Dictionary<string, HashSet<SchemeRecord>>();
        HashSet<string> allCodes = generateAllCodes(schemaList);
        foreach (var VARIABLE in schemaList)
        {
            foreach (var code in allCodes)
            {
                if (result.ContainsKey(code))
                {
                    result[code].Add(VARIABLE);
                }
                else
                {
                    result.Add(code, new HashSet<SchemeRecord> { VARIABLE });
                }
            }
        }
        return result;
 
 */