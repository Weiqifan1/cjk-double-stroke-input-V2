namespace double_stroke.projectFolder.StaticFileMaps;

//the purpose of the class is to create a map of characters 
//to recursive map of its elements with associated codes
//form here, near redundance-free multi-character word codes 
//can be created

//first step: find out how much redundancy would be caused
public static class GenerateIdsRecursionMap
{
    //TODO: write code and tests
    public static Dictionary<string, IdsRecur> readZhengmaWords()
    {
        Dictionary<string, IdsRecur> result = new Dictionary<string, IdsRecur>();
        return result;
    }
    
    public static IdsRecur createSingleRecur(
        long eachChar,
        Dictionary<string, List<UnicodeCharacter>> genRawIds,
        //Dictionary<string, CodepointBasicRecord> codepointMap,
        Dictionary<string, string> manualIdsConway,
        Dictionary<string, CodepointBasicRecord> codepointConway,
        string hanzi)
    {
        List<UnicodeCharacter> basicIds = genRawIds.GetValueOrDefault(hanzi);
        CodepointBasicRecord basicConway = codepointConway.GetValueOrDefault(hanzi); 
        if (basicIds == null || basicConway == null) { return null; }
        string rawCodes = basicConway.rawCodepoint;
        IdsRecur testres = initiateRecur(
            hanzi,
            hanzi,
            hanzi,  
            genRawIds, 
            manualIdsConway, codepointConway);
        return testres;
    }

    private static IdsRecur initiateRecur(
        string originalCharacter,
        string previousCharacter,
        string character,
        Dictionary<string, List<UnicodeCharacter>> genRawIds,
        Dictionary<string, string> manualIdsConway,
        Dictionary<string, CodepointBasicRecord> codepointConway)
    {
        if (character == "戊")
        {
            string test = "";
        }
        string rawConway;
        string unambigousConway;
        List<UnicodeCharacter> idsFromMapRaw = getIdsFromMap(character, genRawIds);
        var idsFromMapSorted = rearrageRecurList(idsFromMapRaw);
        
        List<UnicodeCharacter> idsFromMap = idsFromMapSorted
            .Where(unicodeCharacter => unicodeCharacter != null 
                   && !IsAscii(unicodeCharacter.Value))
            .ToList();
        List<IdsRecur> recurList = new List<IdsRecur>();
        
        if (manualIdsConway.ContainsKey(character) || 
            (idsFromMap.Count == 1 && idsFromMap[0].Value == character))
        {
            
            if (!manualIdsConway.ContainsKey(character) && 
                !codepointConway.ContainsKey(character))
            {
                string conwayOrNullStr = getRawConwayOrNullStr(previousCharacter, codepointConway);
                string conwayOriginal = getRawConwayOrNullStr(originalCharacter, codepointConway);
                throw new Exception("original: " + originalCharacter +
                                    " originalConway: " + conwayOriginal + " " +
                    "previous: " + previousCharacter + 
                    " rawConwayOfPrevious: " + 
                    conwayOrNullStr +
                    " " + character + " doesnt have any conway codes");
            } 
            else if (!manualIdsConway.ContainsKey(character) &&
                       conwayCodeIsAmbigous(character, codepointConway))
            {
                var originalTestChar = originalCharacter;
                var originalConwayCode = codepointConway.GetValueOrDefault(originalCharacter);
                throw new Exception(character + " is ambigous: " + 
                                    codepointConway.GetValueOrDefault(character));
            }
            else
            {
                try {
                    rawConway = getRawConway(manualIdsConway, codepointConway, character);
                    unambigousConway = getUnambigousCnway(new List<IdsRecur>(), manualIdsConway, codepointConway, character);
                }
                catch (Exception x)
                {
                    throw x;
                }

            }

            if (new List<string>{"道","那" }.Contains(character))
            {
                string test = "";
            }
            string regeneratedRawConwayV2 = createRegeneratedRawConway(character, recurList, rawConway, unambigousConway);
            return new IdsRecur(character, rawConway, unambigousConway, regeneratedRawConwayV2, new List<IdsRecur>());
        }
        var nonNull = idsFromMap.Where(item => item != null).ToList();

        foreach (var VARIABLE in nonNull)
        {
            //var previousCharConway = codepointConway.GetValueOrDefault(previousCharacter);
            
            if (VARIABLE.Value == "白")
            {
                var previousCharConway = codepointConway.GetValueOrDefault(previousCharacter);
                string test = "";
            }

            recurList.Add(
                initiateRecur(originalCharacter,
                    character,
                    VARIABLE.Value, 
                    genRawIds, 
                    manualIdsConway, codepointConway));
        }
        
        try {
            rawConway = getRawConway(manualIdsConway, codepointConway, character);
            unambigousConway = getUnambigousCnway(recurList, manualIdsConway, codepointConway, character);
        }
        catch (Exception x)
        {
            throw x;
        }

        //"勺","白","的", 
        if (new List<string>{"道" }.Contains(character))
        {
            string test = "";
        }

        string regeneratedRawConway = createRegeneratedRawConway(character, recurList, rawConway, unambigousConway) ;
        return new IdsRecur(character, rawConway, unambigousConway, regeneratedRawConway, recurList);
    }

    private static string createRegeneratedRawConway(string character,
        List<IdsRecur> recurList, string rawConway, string unambigousConway)
    {
        if (IsWithinUnicodeRangeOrEmpty(character))
        {
            return "";
        } 

        string result = "";
        foreach (var VARIABLE in recurList)
        {
            if (VARIABLE.regeneratedConway != null && VARIABLE.regeneratedConway.Length > 0)
            {
                result = result + VARIABLE.regeneratedConway;
            }
        }
        if (result == "" && rawConway != "")
        {
            result = rawConway;
        } else if (result == "" && unambigousConway != "")
        {
            result = unambigousConway;
        }
        return result;
    }

    private static string getRawConwayOrNullStr(string character, Dictionary<string, CodepointBasicRecord> codepointConway)
    {
        if (!codepointConway.ContainsKey(character) 
            || codepointConway.GetValueOrDefault(character).rawCodepoint == null)
        {
            return "null";
        }
        else
        {
            return codepointConway.GetValueOrDefault(character).rawCodepoint;
        }
    }

    private static string getUnambigousCnway(
        List<IdsRecur> idsRecur,
        Dictionary<string, string> manualIdsConway, 
        Dictionary<string, CodepointBasicRecord> codepointConway, 
        string character)
    {
        if (IsWithinUnicodeRangeOrEmpty(character))
        {
            return "";
        }
        string? manual = manualIdsConway.GetValueOrDefault(character);
        if (manual != null)
        {
            return manual;
        }
        CodepointBasicRecord? rawConwayObj = codepointConway.GetValueOrDefault(character);
        if (rawConwayObj != null && 
            rawConwayObj.rawCodepoint != null && 
            !conwayCodeIsAmbigous(character, codepointConway))
        {
            return rawConwayObj.rawCodepoint;
        }

        if (idsRecur.Count > 0)
        {
            string result = "";
            foreach (var VARIABLE in idsRecur)
            {
                result = result + VARIABLE.unambigousConway;
            }
            return result;
        }
        else
        {
            throw new Exception(character + ": No Unambigous conway code");
        }
    }
    private static bool IsWithinUnicodeRangeOrEmpty(string input)
    {
        List<(int start, int end)> ranges = new List<(int, int)> 
        {
            (65, 90),  // ranges for ASCII A-Z
            (97, 122),  // ranges for ASCII a-z
            (12272, 12287) // ranges for Ideographic Description Characters
        };
        
        if (string.IsNullOrEmpty(input)) return true;
    
        int unicodeOrdinal = char.ConvertToUtf32(input, 0);
    
        foreach (var range in ranges)
        {
            if (unicodeOrdinal >= range.start && unicodeOrdinal <= range.end)
            {
                return true;
            }
        }
    
        return false;
    }
    private static string getRawConway(
        Dictionary<string, string> manualIdsConway, 
        Dictionary<string, CodepointBasicRecord> codepointConway, 
        string character)
    {
        //"的", "白",
        if (new List<string>{"𤴓"}.Contains(character))
        {
            string test = "";
        }
        if (IsWithinUnicodeRangeOrEmpty(character))
        {
            return "";
        }
        
        CodepointBasicRecord? rawConwayObj = codepointConway.GetValueOrDefault(character);
        if (rawConwayObj != null && rawConwayObj.rawCodepoint != null)
        {
            return rawConwayObj.rawCodepoint;
        }
        if (!manualIdsConway.ContainsKey(character))
        {
            return null;
            //throw new Exception(character + ": No Raw conway code");
        }
        return manualIdsConway.GetValueOrDefault(character);
    }

    private static bool conwayCodeIsAmbigous(
        string character, 
        Dictionary<string, CodepointBasicRecord> codepointConway)
    {
        if (character == "一")
        {
            string test = "";
        }

        if (!codepointConway.ContainsKey(character))
        {
            return true;
        }
        var conwayresult = codepointConway.GetValueOrDefault(character);
        char[] characters = new[] { '(', ')', '|' };
        bool result = conwayresult.rawCodepoint.IndexOfAny(characters) >= 0;
        return result;
    }

    public static bool IsAscii(string value)
    {
        return value.All(c => c <= 127);
    }
    
    private static List<UnicodeCharacter> getIdsFromMap(
        string character,
        Dictionary<string, List<UnicodeCharacter>> genRawIds)
    {
        if (genRawIds.ContainsKey(character))
        {
            return genRawIds.GetValueOrDefault(character).Select(uc => uc).ToList();    
        }

        return new List<UnicodeCharacter>();
    }


    private static Dictionary<string, string> elemToRawConway()
    {
        Dictionary<string, string> res = new Dictionary<string, string>();

        res["key1"] = "value1"; 
        res["key1"] = "value1"; 
        res["key1"] = "value1"; 
        
        return res;
    }

    
    private static List<UnicodeCharacter> rearrageRecurList(List<UnicodeCharacter> recurListRaw)
    {
        if (recurListRaw == null || recurListRaw.Count == 0)
        {
            return new List<UnicodeCharacter>();
        }
        if (
            (recurListRaw[0].Value == "⿺" && recurListRaw[1].Value == "辶") ||
            (recurListRaw[0].Value == "⿺" && recurListRaw[1].Value == "廴")
            )
        {
            var first = recurListRaw[0];
            var second = recurListRaw[1];
            var updatedList = recurListRaw.Skip(2).ToList();
            updatedList.Insert(0, first);
            updatedList.Add(second);
            return updatedList;
        }

        if ((recurListRaw[0].Value == "⿱" && recurListRaw[1].Value == "竹")) //⺮
        {
            var first = recurListRaw[0];
            //var second = recurListRaw[1];
            var second = new UnicodeCharacter("⺮");
            var updatedList = recurListRaw.Skip(2).ToList();
            List<UnicodeCharacter> resultList = new List<UnicodeCharacter>();
            resultList.Add(first);
            resultList.Add(second);
            resultList.AddRange(updatedList);
            return resultList;
        }

        return recurListRaw;
    }
}