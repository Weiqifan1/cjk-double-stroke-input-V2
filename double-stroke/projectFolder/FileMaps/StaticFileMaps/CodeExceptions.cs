namespace double_stroke.projectFolder.StaticFileMaps;

public class CodeExceptions
{
    private static Dictionary<string, string> charToLetter = generateStandardOneAlphabet(); 
    static Dictionary<string, string> generateStandardOneAlphabet()
    {

    
        var result = new Dictionary<string, string>();
        result.Add("手", "l");//l  tobe f
        result.Add("扌", "l");//l  tobe f
        result.Add("目", "k");//k  tobe jj
        result.Add("虫", "j");//f  tobe l
        result.Add("𧾷", "s");//j  tobe k
        result.Add("足", "s");//j  tobe k
        result.Add("木", "d");//d  tobe d
        result.Add("竹", "f");//s  tobe s
        
        result.Add("門", "p");//p
        result.Add("金", "o");//o
        result.Add("車", "i");//i
        result.Add("糸", "u");//u
        result.Add("糹", "u");//u
        result.Add("食", "w");//w
        result.Add("飠", "w");//w
        result.Add("言", "e");//e
        result.Add("馬", "r");//r
        
        return result;
    }
    public static Dictionary<string, string> getPriviledgedExceptionCharacters()
    {
        var result = new Dictionary<string, string>();
        result.Add("金", "金");
        result.Add("𧾷", "𧾷");
        result.Add("足", "足");
        result.Add("竹", "竹");
        result.Add("⺮", "竹");
        result.Add("朩", "木");
        result.Add("食", "食");
        result.Add("飠", "飠");
        result.Add("門", "門");
        result.Add("馬", "馬");
        result.Add("糸", "糸");
        result.Add("糹", "糹");
        return result;
    }

    public Dictionary<string, CodepointExceptionRecord> generateCodeExceptionsFromCharacter()
    {
        
        string uniHandOne = new UnicodeCharacter("手").Value;
        CodepointExceptionRecord uniHandOne_except = new CodepointExceptionRecord(
            uniHandOne, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("手")),
            new HashSet<string>(){"3112"},
            new List<string>(){new UnicodeCharacter("手").Value},
            new List<string>()
            );
        
        string uniHandTwo = new UnicodeCharacter("扌").Value;
        CodepointExceptionRecord uniHandTwo_except = new CodepointExceptionRecord(
            uniHandTwo, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("扌")),
            new HashSet<string>(){"121"},
            new List<string>(){new UnicodeCharacter("扌").Value},
            new List<string>()
        );
        
        string uniEye = new UnicodeCharacter("目").Value;
        CodepointExceptionRecord uniEye_except = new CodepointExceptionRecord(
            uniEye, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("目")),
            new HashSet<string>(){"25111"},
            new List<string>(){new UnicodeCharacter("目").Value},
            new List<string>()
        );
        
        string uniFootOne = new UnicodeCharacter("足").Value;
        CodepointExceptionRecord uniFootOne_except = new CodepointExceptionRecord(
            uniFootOne, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("足")),
            new HashSet<string>(){"2512134"},
            new List<string>(){new UnicodeCharacter("足").Value},
            new List<string>()
        );
        
        string uniFootTwo = new UnicodeCharacter("𧾷").Value;
        CodepointExceptionRecord uniFootTwo_except = new CodepointExceptionRecord(
            uniFootTwo, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("𧾷")),
            new HashSet<string>(){"251(215|2121)"},
            new List<string>(){new UnicodeCharacter("𧾷").Value},
            new List<string>()
        );
        
        string uniInsect = new UnicodeCharacter("虫").Value;
        CodepointExceptionRecord uniInsect_except = new CodepointExceptionRecord(
            uniInsect, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("虫")),
            new HashSet<string>(){"251214"},
            new List<string>(){new UnicodeCharacter("虫").Value},
            new List<string>()
        );
        
        string uniTreeOne = new UnicodeCharacter("木").Value;
        CodepointExceptionRecord uniTreeOne_except = new CodepointExceptionRecord(
            uniTreeOne, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("木")),
            new HashSet<string>(){"1234"},
            new List<string>()
            {
                new UnicodeCharacter("木").Value, new UnicodeCharacter("朩").Value
            },
            new List<string>()
        );
        /*
        string uniTreeTwo = new UnicodeCharacter("朩").Value;
        CodepointExceptionRecord uniTreeTwo_except = new CodepointExceptionRecord(
            uniTreeTwo, 
            new UnicodeCharacter("k"),
            new HashSet<string>(){"1234"},
            new List<string>(){new UnicodeCharacter("朩").Value},
            new List<string>()
        );*/

        string uniBambooOne = new UnicodeCharacter("竹").Value;//"𠂊亅𠂊亅";//new UnicodeCharacter("竹");
        CodepointExceptionRecord uniBambooOne_except = new CodepointExceptionRecord(
            uniBambooOne, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("竹")),
            new HashSet<string>(){"312312", "314314"},
            new List<string>(){"竹"},
            new List<string>()
        );
        
        string uniGold = new UnicodeCharacter("金").Value;
        CodepointExceptionRecord uniGold_except = new CodepointExceptionRecord(
            uniGold, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("金")),
            new HashSet<string>(){"34112431"},
            new List<string>(){new UnicodeCharacter("金").Value},
            new List<string>()
        );
        
        string uniEatOne = new UnicodeCharacter("食").Value;
        CodepointExceptionRecord uniEatOne_except = new CodepointExceptionRecord(
            uniEatOne, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("食")),
            new HashSet<string>(){"34(1|4)(51154|511211)", "34(1|4)511534", "34(1|4)51154"},
            new List<string>(){new UnicodeCharacter("飠").Value, new UnicodeCharacter("食").Value},
            new List<string>()
        );
        
        string uniEatTwo = new UnicodeCharacter("飠").Value;
        CodepointExceptionRecord uniEatTwo_except = new CodepointExceptionRecord(
            uniEatTwo, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("飠")),
            new HashSet<string>(){"34(1|4)(51154|511211)", "34(1|4)511534", "34(1|4)51154"},
            new List<string>(){new UnicodeCharacter("飠").Value, new UnicodeCharacter("食").Value},
            new List<string>()
        );
        
        string uniCar = new UnicodeCharacter("車").Value;
        CodepointExceptionRecord uniCar_except = new CodepointExceptionRecord(
            uniCar, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("車")),
            new HashSet<string>(){"1251112"},
            new List<string>(){new UnicodeCharacter("車").Value},
            new List<string>()
        );

        
        string uniThread = new UnicodeCharacter("糸").Value;
        CodepointExceptionRecord uniThread_except = new CodepointExceptionRecord(
            uniThread, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("糸")),
            new HashSet<string>(){"(554234|554444)", "554234", "554444"},
            new List<string>(){new UnicodeCharacter("糸").Value, new UnicodeCharacter("糹").Value},
            new List<string>()
        );
        
        string uniThreadAlternative = new UnicodeCharacter("糹").Value;
        CodepointExceptionRecord uniThreadAlternative_except = new CodepointExceptionRecord(
            uniThread, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("糹")),
            new HashSet<string>(){"(554234|554444)", "554234", "554444"},
            new List<string>(){new UnicodeCharacter("糸").Value, new UnicodeCharacter("糹").Value},
            new List<string>()
        );
        
        string uniSayOne = new UnicodeCharacter("言").Value;
        CodepointExceptionRecord uniSayOne_except = new CodepointExceptionRecord(
            uniSayOne, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("言")),
            new HashSet<string>(){"(1|4)111251"}, //, "(1|4)111251(554234|554444)"
            new List<string>()
            {
                new UnicodeCharacter("言").Value, 
                new UnicodeCharacter("訁").Value,
                new UnicodeCharacter("糸").Value,
                new UnicodeCharacter("火").Value,
                new UnicodeCharacter("辶").Value 
            },
            new List<string>()
        );
        
        /*
        UnicodeCharacter uniSayTwo = new UnicodeCharacter("訁");
        CodepointExceptionRecord uniSayTwo_except = new CodepointExceptionRecord(
            uniSayTwo, 
            new UnicodeCharacter("v"),
            "(1|4)111251",
            new List<UnicodeCharacter>(){new UnicodeCharacter("訁")},
            new List<UnicodeCharacter>()
        );*/
        
        string uniHorse = new UnicodeCharacter("馬").Value;
        CodepointExceptionRecord uniHorse_except = new CodepointExceptionRecord(
            uniHorse, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("馬")),
            new HashSet<string>(){"(12|21)11254444"},
            new List<string>(){new UnicodeCharacter("馬").Value},
            new List<string>()
        );
        
        string uniGateOne = new UnicodeCharacter("門").Value;
        CodepointExceptionRecord uniGateOne_except = new CodepointExceptionRecord(
            uniGateOne, 
            new UnicodeCharacter(charToLetter.GetValueOrDefault("門")),
            new HashSet<string>(){"25112511"},
            new List<string>(){new UnicodeCharacter("門").Value},
            new List<string>()
        );
        /*
        UnicodeCharacter uniGateTwo = new UnicodeCharacter("𠁣");
        CodepointExceptionRecord uniGateTwo_except = new CodepointExceptionRecord(
            uniGateTwo, 
            new UnicodeCharacter("n"),
            "25112511",
            new List<UnicodeCharacter>(){new UnicodeCharacter("𠁣")},
            new List<UnicodeCharacter>()
        );*/
        /*
        string uniGateThree = new UnicodeCharacter("𠃛").Value;
        CodepointExceptionRecord uniGateThree_except = new CodepointExceptionRecord(
            uniGateThree, 
            new UnicodeCharacter("n"),
            new HashSet<string>(){"25112511"},
            new List<string>()
            {
                new UnicodeCharacter("𠁣").Value, new UnicodeCharacter("𠃛").Value
            },
            new List<string>()
        );*/

        Dictionary<string, CodepointExceptionRecord> result =
            new Dictionary<string, CodepointExceptionRecord>();
        result.Add(uniHandOne, uniHandOne_except);
        result.Add(uniHandTwo, uniHandTwo_except);
        result.Add(uniEye, uniEye_except);
        result.Add(uniFootOne, uniFootOne_except);
        result.Add(uniFootTwo, uniFootTwo_except);
        result.Add(uniInsect, uniInsect_except);
        result.Add(uniTreeOne, uniTreeOne_except);
        //result.Add(uniTreeTwo, uniTreeTwo_except);
        result.Add(uniBambooOne, uniBambooOne_except);
        //result.Add(uniBambooTwo, uniBambooTwo_except);
        result.Add(uniGold, uniGold_except);
        result.Add(uniEatOne, uniEatOne_except);
        result.Add(uniEatTwo, uniEatTwo_except);
        result.Add(uniCar, uniCar_except);
        result.Add(uniThread, uniThread_except);
        result.Add(uniThreadAlternative, uniThreadAlternative_except);
        
        result.Add(uniSayOne, uniSayOne_except);
        //result.Add(uniSayTwo, uniSayTwo_except);
        result.Add(uniHorse, uniHorse_except);
        result.Add(uniGateOne, uniGateOne_except);
        //result.Add(uniGateTwo, uniGateTwo_except);
        //result.Add(uniGateThree, uniGateThree_except);
        return result;

        //UnicodeCharacter character,
        //UnicodeCharacter alphabetLetter,
        //    List<string> rawCodepoints,
        //List<UnicodeCharacter> mistakenMatches

        //generate exception code for these characters:
        //and write tests for them
        //扌目趴  虫木竺
        //金飣車糽言馬門

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
    }
    
    
    public Dictionary<string, CodepointExceptionRecord> generateCodeExceptionsFromCodepoint()
    {
        Dictionary<string, CodepointExceptionRecord> exceptFromChar = 
            generateCodeExceptionsFromCharacter();
        Dictionary<string, CodepointExceptionRecord> result =
            new Dictionary<string, CodepointExceptionRecord>();
        foreach (KeyValuePair<string, CodepointExceptionRecord> item in exceptFromChar)
        {
            foreach (var VARIABLE in item.Value.rawCodepoint)
            {
                result[VARIABLE] = item.Value;
            }
        }
        return result;
    }
}