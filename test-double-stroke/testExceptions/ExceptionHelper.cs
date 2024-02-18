namespace test_double_stroke.testExceptions;


using double_stroke.projectFolder.StaticFileMaps;

public class ExceptionHelper
{
    
    public string GetUnicodeOrdinal(UnicodeCharacter uni)
    {
        if (char.IsHighSurrogate(uni.Value[0]) && uni.Value.Length > 1)
        {
            int unicodeOrdinal = char.ConvertToUtf32(uni.Value[0], uni.Value[1]);
            string unicodeString = unicodeOrdinal.ToString();
            return unicodeString;
        }
        else
        {
            int unicodeOrdinal = uni.Value[0];
            string unicodeString = unicodeOrdinal.ToString();
            return unicodeString;
        }
    }
    
    
    private bool idsMatchMatch(
        List<string> initialIds, 
        KeyValuePair<string, CodepointWithExceptionRecord> kv)
    {
        bool result = false;
        for (int i = 0; i < initialIds.Count; i++)
        {
            var matchEach = kv.Value.idsLookup.rolledOutIdsWithNoShape[0].Equals(initialIds[i]);
            if (matchEach)
            {
                result = true;
            }
        }
        return result;
    }
    
    private bool codepointStartsWithInitialCodepoint(string originalCodepointRawCodepoint, List<string> initialCodepoint)
    {
        //kv.Value.originalCodepoint.rawCodepoint.StartsWith(initialCodepoint)
        bool result = false;
        for (int i = 0; i < initialCodepoint.Count; i++)
        {
            if (originalCodepointRawCodepoint.StartsWith(initialCodepoint[i]))
            {
                result = true;
            }
        }
        return result;
    }
    
    public Dictionary<string, CodepointWithExceptionRecord> FiltDict_hasCodeHasIds(
        Dictionary<string, CodepointWithExceptionRecord> foundExceptions, 
        List<string> initialCodepoint, 
        List<string> initialIds)
    {
        var result = foundExceptions
            .Where(kv => 
                codepointStartsWithInitialCodepoint(kv.Value.originalCodepoint.rawCodepoint, initialCodepoint) 
                && idsMatchMatch(initialIds, kv))
            .ToDictionary(kv => kv.Key, kv => kv.Value);
        return result;
    }


    public Dictionary<string, CodepointWithExceptionRecord> FiltDict_hasCodeNotIds(
        Dictionary<string, CodepointWithExceptionRecord> foundExceptions, 
        List<string> initialCodepoint, 
        List<string> initialIds)
    {
        var result = foundExceptions
            .Where(kv =>
                codepointStartsWithInitialCodepoint(kv.Value.originalCodepoint.rawCodepoint, initialCodepoint)
                && !idsMatchMatch(initialIds, kv))
            .ToDictionary(kv => kv.Key, kv => kv.Value);
        return result;
    }


    //kv.Value.idsLookup.rolledOutIdsWithNoShape[0], initialIds, kv
    


    public Dictionary<string, CodepointWithExceptionRecord> FiltDict_NotCodeHasIds(
        Dictionary<string, CodepointWithExceptionRecord> foundExceptions, 
        List<string> initialCodepoint, 
        List<string> initialIds)
    {
        var result = foundExceptions
            .Where(kv => 
                !codepointStartsWithInitialCodepoint(kv.Value.originalCodepoint.rawCodepoint, initialCodepoint)
                && idsMatchMatch(initialIds, kv))
            .ToDictionary(kv => kv.Key, kv => kv.Value);
        return result;
    }
    
    public Dictionary<string, CodepointWithExceptionRecord> FiltDict_NotCodeNotIds(
        Dictionary<string, CodepointWithExceptionRecord> foundExceptions, 
        List<string> initialCodepoint, 
        List<string> initialIds)
    {
        var result = foundExceptions
            .Where(kv => 
                !codepointStartsWithInitialCodepoint(kv.Value.originalCodepoint.rawCodepoint, initialCodepoint) 
                && !idsMatchMatch(initialIds, kv))
            .ToDictionary(kv => kv.Key, kv => kv.Value);
        return result;
    }

    public List<string> displayDict(Dictionary<string, CodepointWithExceptionRecord> dict)
    {
        var resultlist = new List<string>();
        foreach (var keyval in dict)
        {
            var eachstr = "";
            eachstr += keyval.Key + " ";
            eachstr += keyval.Value.codepointExceptions.rawCodepoint + " ";
            string rolledOutToStr = rolledOutToStrFunc(keyval.Value.idsLookup.rolledOutIdsWithNoShape);
            eachstr += rolledOutToStr + " ";
            resultlist.Add(eachstr);
        }
        return resultlist;
    }

    public string rolledOutToStrFunc(List<string> idsLookupRolledOutIdsWithNoShape)
    {
        string resultStr = "";
        foreach (var VARIABLE in idsLookupRolledOutIdsWithNoShape)
        {
            resultStr += VARIABLE;
        }
        return resultStr;
        throw new NotImplementedException();
    }
}


    
/*
    //s   "手","扌"   "121"
    //d    "目"  "25111"
    //f    "足",  2512134
    //f     "𧾷"   "251(215|2121)";   //251215  2512121
    //j    "虫"  "251214"
    //k    "木","朩"  "1234"
    //l     "竹","⺮","ケ" "314314"

    //t     "金"   "34112431"
    //y    "食","飠"    "34(1|4)(51154|511211)"
    // "344511211"  "34451154",  "34151154",  "341511211",
    //g     "車"    "1251112"
    //h     "糸"    "(554234|554444)"   "554234"  "554444"
    //v      "言","訁"    "(1|4)111251"     "1111251"    "4111251"
    //b      "馬"    "(12|21)11254444"    "1211254444"   "2111254444"
    //n     "𠁣","𠃛","門"    "25112511"
 */
    
    
/*
[Test]
public void IdentifyDetectedExceptionsThatShouldntBeThere()
{
    Console.WriteLine("test start");
    //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
    //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
    //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;

    Assert.AreEqual(2+2, 4);

    Console.WriteLine("test end");
}

[Test]
public void IdentifyExceptionsThatShouldHaveBeenADifferetException()
{
    Console.WriteLine("test start");
    //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
    //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
    //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;

    Assert.AreEqual(2+2, 4);

    Console.WriteLine("test end");
}*/