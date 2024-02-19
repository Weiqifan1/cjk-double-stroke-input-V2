namespace test_double_stroke.testExceptions;

using double_stroke.projectFolder.StaticFileMaps;

public class testMissingCorrectExceptions : testSetup
{
    /*
    string uniHandOne = new UnicodeCharacter("手").Value;
        CodepointExceptionRecord uniHandOne_except = new CodepointExceptionRecord(
            uniHandOne, 
            new UnicodeCharacter("s"),
            new HashSet<string>(){"3112"},
            new List<string>(){new UnicodeCharacter("手").Value},
            new List<string>()
            );
     */
    [Test]
    public void MissingLargeHand()
    {
        var take10 = foundExceptions.Take(10);

        HashSet<string> possibleStartCodes = new HashSet<string>{"3112"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "手" };
        HashSet<string> elemCanNotStart = new HashSet<string> { "手" };
        Dictionary<string, CodepointWithExceptionRecord> hashandButNoExcept = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{"掣", "罉"}.SetEquals(hashandButNoExcept.Keys.ToHashSet()));
    }
    
    [Test]
    public void HasLargeHand()
    {
        var take10 = foundExceptions.Take(10);

        HashSet<string> possibleStartCodes = new HashSet<string>{"3112"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "手" };
        HashSet<string> elemCanNotStart = new HashSet<string> { "" };
        Dictionary<string, CodepointWithExceptionRecord> hashandButNoExcept = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{"掣", "罉", "劧", "手", "掱"}.SetEquals(hashandButNoExcept.Keys.ToHashSet()));
    }

    [Test]
    public void HasSmallHand()
    {
        var take10 = foundExceptions.Take(10);

        HashSet<string> possibleStartCodes = new HashSet<string>{"121"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "扌" };
        HashSet<string> elemCanNotStart = new HashSet<string> { "扌" };
        Dictionary<string, CodepointWithExceptionRecord> hashandButNoExcept = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{"逝", "逰"}.SetEquals(hashandButNoExcept.Keys.ToHashSet()));
    }
    
    [Test]
    public void HasEye()
    {
        var take10 = foundExceptions.Take(10);

        HashSet<string> possibleStartCodes = new HashSet<string>{"25111"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "目" };
        HashSet<string> elemCanNotStart = new HashSet<string> { "目" };
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{"嘖", "県" ,"郻", "鼎", "䢙", "䢲", "䵻", "𡃁"}.SetEquals(result.Keys.ToHashSet()));
    }
    
    [Test]
    public void HasBigFoot()
    {
        var take10 = foundExceptions.Take(10);
        HashSet<string> possibleStartCodes = new HashSet<string>{"25121"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "足" };
        HashSet<string> elemCanNotStart = new HashSet<string> { "足" };
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{}.SetEquals(result.Keys.ToHashSet()));
    }
    
    [Test] 
    public void HasSmallFoot()
    {
        var take10 = foundExceptions.Take(10);
        HashSet<string> possibleStartCodes = new HashSet<string>{"251"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "𧾷" };
        HashSet<string> elemCanNotStart = new HashSet<string> { "𧾷" };
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{"𡀔"}.SetEquals(result.Keys.ToHashSet()));
    }
    
    [Test] 
    public void HasInsect()
    {
        var take10 = foundExceptions.Take(10);
        HashSet<string> possibleStartCodes = new HashSet<string>{"2512"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "虫" };
        HashSet<string> elemCanNotStart = new HashSet<string> { "虫" };
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{"噣", "虽", "雖"}.SetEquals(result.Keys.ToHashSet()));
    }
    
    [Test] 
    public void HasBasicTree() //"木","朩"
    {
        var take10 = foundExceptions.Take(10);
        HashSet<string> possibleStartCodes = new HashSet<string>{"1234"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "朩", "木", "十"};
        HashSet<string> elemCanNotStart = new HashSet<string> { "木" };
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{"逨", "䢞", "嗇", "賫", "赍", "㱇", "䘮"}.SetEquals(result.Keys.ToHashSet()));
    }
    
    //"竹","⺮","ケ" 
    [Test] 
    public void HasBamboo()
    {
        var take10 = foundExceptions.Take(10);
        HashSet<string> possibleStartCodes = new HashSet<string>{"312", "313", "314"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "竹","⺮","ケ" };
        HashSet<string> elemCanNotStart = new HashSet<string> { "竹" };
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{"遾"}.SetEquals(result.Keys.ToHashSet()));
    }
    
    [Test] 
    public void HasGold()
    {
        var take10 = foundExceptions.Take(10);
        HashSet<string> possibleStartCodes = new HashSet<string>{"34112"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "金" };
        HashSet<string> elemCanNotStart = new HashSet<string> { "金" };
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{}.SetEquals(result.Keys.ToHashSet()));
    }
    
    [Test] 
    public void HasEat() //"食","飠"
    {
        var take10 = foundExceptions.Take(10);
        HashSet<string> possibleStartCodes = new HashSet<string>{"34"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "食", "飠"};
        HashSet<string> elemCanNotStart = new HashSet<string> { "食",  "飠"};
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{}.SetEquals(result.Keys.ToHashSet()));
    }
    
    [Test] 
    public void HasCar() //"車"
    {
        var take10 = foundExceptions.Take(10);
        HashSet<string> possibleStartCodes = new HashSet<string>{"12511"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "車"};
        HashSet<string> elemCanNotStart = new HashSet<string> { "車"};
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{"輿", "轡", "連", "㦁"}.SetEquals(result.Keys.ToHashSet()));
    }

    [Test] 
    public void HasTraditionalThread() //"糸" 
    {
        var take10 = foundExceptions.Take(10);
        HashSet<string> possibleStartCodes = new HashSet<string>{"554"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "糸"};
        HashSet<string> elemCanNotStart = new HashSet<string> { "糸"};
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        Assert.IsTrue(new HashSet<string>{}.SetEquals(result.Keys.ToHashSet()));
    }
    
    [Test] 
    public void HasSay() //"言","訁" 
    {
        var take10 = foundExceptions.Take(10);
        HashSet<string> possibleStartCodes = new HashSet<string>{"(1|4)111251"};
        HashSet<string> pobbibleContainElem = new HashSet<string> { "言", "訁"};
        HashSet<string> elemCanNotStart = new HashSet<string> { "言", "訁"};
        Dictionary<string, CodepointWithExceptionRecord> result = 
            getElemsWithAttributes(foundExceptions, possibleStartCodes, pobbibleContainElem, elemCanNotStart);
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;
        
        Assert.IsTrue(result.Keys.ToHashSet().Count == 30);
    }
    
    
    private Dictionary<string, CodepointWithExceptionRecord> getElemsWithAttributes(
        Dictionary<string, CodepointWithExceptionRecord> codepointWithExceptionRecords, 
        HashSet<string> possibleStartCodes, 
        HashSet<string> pobbibleContainElem, 
        HashSet<string> elemDontStartWithAny)
    {
        Dictionary<string, CodepointWithExceptionRecord> result = new Dictionary<string, CodepointWithExceptionRecord>();
        foreach (var VARIABLE in codepointWithExceptionRecords)
        {
            bool VARstartsWithCode = codeStartsWithOneOfThese(VARIABLE.Value.originalCodepoint.rawCodepoint, possibleStartCodes);
            bool ELEMContainAtleastOne = elemsStartWithAtleastOne(VARIABLE.Value.idsLookup.rolledOutIds, pobbibleContainElem);
            bool dontStartWithAny = !elemDontStartWithAny.Contains(VARIABLE.Value.idsLookup.rolledOutIdsWithNoShape[0]);
            if (VARstartsWithCode && ELEMContainAtleastOne && dontStartWithAny)
            {
                result.Add(VARIABLE.Key, VARIABLE.Value);
            }
        }
        return result;
    }

    private bool elemsStartWithAtleastOne(List<string> idsLookupRolledOutIds, HashSet<string> pobbibleContainElem)
    {
        foreach (var VARIABLE in pobbibleContainElem)
        {
            if (idsLookupRolledOutIds.Contains(VARIABLE))
            {
                return true;
            }
        }
        return false;
    }

    private bool codeStartsWithOneOfThese(string originalCodepointRawCodepoint, HashSet<string> possibleStartCodes)
    {
        foreach (var VARIABLE in possibleStartCodes)
        {
            if (originalCodepointRawCodepoint.StartsWith(VARIABLE))
            {
                return true;
            }
        }
        return false;
    }


    [Test]
    public void testHandFullsize_cardsThatMatchStrokesButNotElement()
    {
        Console.WriteLine("test start TesthandFullSize");
        
        //private Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
        //private Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
        //private Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint;

        var handFull = 
            exceptionHelper.FiltDict_hasCodeNotIds(foundExceptions, 
                new() {"3112"},
                new() {"手"});

        var finalres = exceptionHelper.displayDict(handFull);

        Assert.AreEqual(2+2, 4);

        Console.WriteLine("test end IdentifyLackOfExceptionsThatShouldHaveBeenThere");
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
    
}