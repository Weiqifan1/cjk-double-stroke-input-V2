using double_stroke.projectFolder.StaticFileMaps;

namespace test_double_stroke.testSchemeDict;

public class TestScheme: testSetup
{
    private List<SchemeRecord> schemeRecList;
    
    [OneTimeSetUp]
    public void Setup()
    {
        schemeRecList = generateTestSchemeDict
            .schemeFromDictionary(foundExceptions, junda, tzai);
    }
    
    
    [Test]
    public void handNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "手");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"s", "tf"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        //Assert.That(hand.exceptionLetter == "s");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.That(hand.rawCodepoint == "3112");
        Assert.That(hand.jundaNumber == 280442);
        Assert.That(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void handCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "扔");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"sq", "sk"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"fdh", "fat"}));
        //Assert.That(hand.exceptionLetter == "s");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"扌"}));
        Assert.That(hand.rawCodepoint == "121(35|53)");
        Assert.That(hand.jundaNumber == 8045);
        Assert.That(hand.tzaiNumber == 931);
    }
    
    
    [Test]
    public void eyeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "目");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"d", "ngg"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"ngg"}));
        //Assert.That(hand.exceptionLetter == "d");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"目"}));
        Assert.That(hand.rawCodepoint == "25111");
        Assert.That(hand.jundaNumber == 180827);
        Assert.That(hand.tzaiNumber == 157966);
        
    }
    
    [Test]
    public void eyeCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "眤");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"dhth", "dheh", "dhqt"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"ngada", "ngadq", "ngadk"}));
        //Assert.That(hand.exceptionLetter == "d");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"目"}));
        Assert.That(hand.rawCodepoint == "25111513(15|35|53)");
        Assert.That(hand.jundaNumber == null);
        Assert.That(hand.tzaiNumber == null);
    }
    
    
    [Test]
    public void footNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "足");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"f", "nfdy"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"nfdy"}));
        //Assert.That(hand.exceptionLetter == "f");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"足"}));
        Assert.That(hand.rawCodepoint == "2512134");
        Assert.That(hand.jundaNumber == 77385);
        Assert.That(hand.tzaiNumber == 47014);
    }
    
    [Test]
    public void footCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "趵");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"fqg", "fqy"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"nfaqg", "nfaqy", "nffdh", "nffdl"}));
        //Assert.That(hand.exceptionLetter == "f");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"𧾷"}));
        Assert.That(hand.rawCodepoint == "251(215|2121)35(1|4)");
        Assert.That(hand.jundaNumber == 53);
        Assert.That(hand.tzaiNumber == 8);
    }
    
    
    
    [Test]
    public void footAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "𧾷");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"f", "nfa", "nffg"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"nfa", "nffg"}));
        //Assert.That(hand.exceptionLetter == "f");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"𧾷"}));
        Assert.That(hand.rawCodepoint == "251(215|2121)");
        Assert.That(hand.jundaNumber == null);
        Assert.That(hand.tzaiNumber == null);
    }
    
    
    [Test]
    public void insectNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "虫");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"j", "nfs"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"nfs"}));
        //Assert.That(hand.exceptionLetter == "j");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"虫"}));
        Assert.That(hand.rawCodepoint == "251214");
        Assert.That(hand.jundaNumber == 18909);
        Assert.That(hand.tzaiNumber == 4789);
    }
    
    [Test]
    public void insectCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "虾");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"jfy"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"nfsfy"}));
        //Assert.That(hand.exceptionLetter == "j");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"虫"}));
        Assert.That(hand.rawCodepoint == "251214124");
        Assert.That(hand.jundaNumber == 2338);
        Assert.That(hand.tzaiNumber == null);
    }
    
    
    [Test]
    public void treeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "木");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"k", "fw"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"fw"}));
        //Assert.That(hand.exceptionLetter == "k");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"木", "朩"}));
        Assert.That(hand.rawCodepoint == "1234");
        Assert.That(hand.jundaNumber == 54433);
        Assert.That(hand.tzaiNumber == 39692);
    }
    
    
    //朩
    [Test]
    public void treeAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "朩");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"k", "fw"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"fw"}));
        //Assert.That(hand.exceptionLetter == "k");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"木", "朩"}));
        Assert.That(hand.rawCodepoint == "1234");
        Assert.That(hand.jundaNumber == null);
        Assert.That(hand.tzaiNumber == null);
    }
    
    [Test]
    public void treeCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "松");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"kwl"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"fwwl"}));
        //Assert.That(hand.exceptionLetter == "k");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"木", "朩"}));
        Assert.That(hand.rawCodepoint == "12343454");
        Assert.That(hand.jundaNumber == 37563);
        Assert.That(hand.tzaiNumber == 28277);
    }
    
    [Test]
    public void bambooNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "竹");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"l", "tvf"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"tvf"}));
        //Assert.That(hand.exceptionLetter == "l");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"竹"}));
        Assert.That(hand.rawCodepoint == "312312");
        Assert.That(hand.jundaNumber == 12000);
        Assert.That(hand.tzaiNumber == 96078);
    }
    
    
    [Test]
    public void bambooAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "⺮");
        Assert.That(hand == null);
        /*
        Assert.That(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.That(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.That(hand.exceptionLetter == "s");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.That(hand.rawCodepoint == "3112");
        Assert.That(hand.jundaNumber == 280442);
        Assert.That(hand.tzaiNumber == 236673);*/
    }
    
    
    [Test]
    public void bambooCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "签");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"lwst"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"tiswst"}));
        //Assert.That(hand.exceptionLetter == "l");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"竹"}));
        Assert.That(hand.rawCodepoint == "3143143414431");
        Assert.That(hand.jundaNumber == 20057);
        Assert.That(hand.tzaiNumber == null);
    }
    
    
    
    [Test]
    public void goldNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "金");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"t", "wgbt"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"wgbt"}));
        //Assert.That(hand.exceptionLetter == "t");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"金"}));
        Assert.That(hand.rawCodepoint == "34112431");
        Assert.That(hand.jundaNumber == 167912);
        Assert.That(hand.tzaiNumber == 108819);
    }
    
    [Test]
    public void goldCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "錯");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"tfxg"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"wgbtfg"}));
        //Assert.That(hand.exceptionLetter == "t");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"金"}));
        Assert.That(hand.rawCodepoint == "3411243112212511");
        Assert.That(hand.jundaNumber == 30);
        Assert.That(hand.tzaiNumber == 168867);
    }
    
    
    [Test]
    public void eatNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "食");
        
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"y", "wagw", "wpgw"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"wagky", "wpgky"}));
        //Assert.That(hand.exceptionLetter == "y");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"食", "飠"}));
        Assert.That(hand.rawCodepoint == "34(1|4)511534");
        Assert.That(hand.jundaNumber == 58110);
        Assert.That(hand.tzaiNumber == 22222);
    }

    
    [Test]
    public void eatAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "飠");

        //Assert.That(hand.code4.SetEquals(new HashSet<string> { "y", "wagl", "wpgl" }));
        //Assert.That(hand.code6.SetEquals(new HashSet<string> { "wagl", "wpgl" }));
        //Assert.That(hand.exceptionLetter == "y");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string> { "飠", "食" }));
        Assert.That(hand.rawCodepoint == "34(1|4)51154");
        Assert.That(hand.jundaNumber == null);
        Assert.That(hand.tzaiNumber == null);
    }
    
    [Test]
    public void eatCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "飼");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"yhng"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"waglhh", "wagxah", "wpglhh", "wpgxah"}));
        //Assert.That(hand.exceptionLetter == "y");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"飠", "食"}));
        Assert.That(hand.rawCodepoint == "34(1|4)(51154|511211)51251");
        Assert.That(hand.jundaNumber == 4);
        Assert.That(hand.tzaiNumber == 1829);
    }

    
    [Test]
    public void carNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "車");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"g", "fhgx"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"fhgx"}));
        //Assert.That(hand.exceptionLetter == "g");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"車"}));
        Assert.That(hand.rawCodepoint == "1251112");
        Assert.That(hand.jundaNumber == 32);
        Assert.That(hand.tzaiNumber == 244964);
    }

    [Test]
    public void carCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "軒");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"ggx"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"fhgxf"}));
        //Assert.That(hand.exceptionLetter == "g");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"車"}));
        Assert.That(hand.rawCodepoint == "1251112112");
        Assert.That(hand.jundaNumber == 5);
        Assert.That(hand.tzaiNumber == 7731);
    }

    
    [Test]
    public void threadNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "糸");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"h", "muw"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"muw"}));
        //Assert.That(hand.exceptionLetter == "h");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"糹", "糸"}));
        Assert.That(hand.rawCodepoint == "554234");
        Assert.That(hand.jundaNumber == null);
        Assert.That(hand.tzaiNumber == 146);
    }
    

    [Test]
    public void threadAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "糹");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"h", "moo"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"moo"}));
        //Assert.That(hand.exceptionLetter == "h");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"糹", "糸"}));
        Assert.That(hand.rawCodepoint == "554444");
        Assert.That(hand.jundaNumber == null);
        Assert.That(hand.tzaiNumber == null);
    }
    
    [Test]
    public void threadCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "絆");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"hwgx", "higx"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"muwwgx", "muwigx", "moowgx", "mooigx"}));
        //Assert.That(hand.exceptionLetter == "h");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"糸", "糹"}));
        Assert.That(hand.rawCodepoint == "(554234|554444)(34|43)112");
        Assert.That(hand.jundaNumber == 1);
        Assert.That(hand.tzaiNumber == 1261);
    }

    
    [Test]
    public void sayNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "言");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"v", "ggng", "ygng"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"ggng", "ygng"}));
        //Assert.That(hand.exceptionLetter == "v");
        Assert.That(hand.foundExceptionElems.SetEquals(
            new HashSet<string>{"言", "訁", "糸", "火", "辶"}));
        Assert.That(hand.rawCodepoint == "(1|4)111251");
        Assert.That(hand.jundaNumber == 120308);
        Assert.That(hand.tzaiNumber == 136534);
    }

    
    [Test]
    public void sayAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "訁");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"v", "ggng", "ygng"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"ggng", "ygng"}));
        //Assert.That(hand.exceptionLetter == "v");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"言", "訁", "糸", "火", "辶"}));
        Assert.That(hand.rawCodepoint == "(1|4)111251");
        Assert.That(hand.jundaNumber == null);
        Assert.That(hand.tzaiNumber == null);
    }

    
    [Test]
    public void sayCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "謬");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"vkqe", "vlae"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"ggnaee", "ggnaye", "ygnaee", "ygnaye"}));
        //Assert.That(hand.exceptionLetter == "v");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"言", "訁", "糸", "火", "辶"}));
        Assert.That(hand.rawCodepoint == "(1|4)111251(533533|541541)34333");
        Assert.That(hand.jundaNumber == 3);
        Assert.That(hand.tzaiNumber == 3290);
    }
    
    [Test]
    public void sayAndRoadCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "這");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"vpy", "vol", "vpl"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>
        //{
        //    "ggnsl", "ggnspy", "ggnsmy", "ygnsl", "ygnspy", "ygnsmy"
        //}));
        //Assert.That(hand.exceptionLetter == "v");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"言", "訁", "糸", "火", "辶"}));
        Assert.That(hand.rawCodepoint == "(1|4)111251(454|4454|4554)");
        Assert.That(hand.jundaNumber == 483);
        Assert.That(hand.tzaiNumber == 986130);
    }
    
    
    [Test]
    public void horseNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "馬");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"b", "fgno", "xgno"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"fgnoo", "xgnoo"}));
        //Assert.That(hand.exceptionLetter == "b");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"馬"}));
        Assert.That(hand.rawCodepoint == "(12|21)11254444");
        Assert.That(hand.jundaNumber == 11);
        Assert.That(hand.tzaiNumber == 88333);
    }

    [Test]
    public void horseCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "騎");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"bdyf"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"fgnoof", "xgnoof"}));
        //Assert.That(hand.exceptionLetter == "b");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"馬"}));
        Assert.That(hand.rawCodepoint == "(12|21)1125444413412512");
        Assert.That(hand.jundaNumber == 3);
        Assert.That(hand.tzaiNumber == 39690);
    }

    
    [Test]
    public void gateNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "門");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"n", "ngng"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"ngng"}));
        //Assert.That(hand.exceptionLetter == "n");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"門"}));
        Assert.That(hand.rawCodepoint == "25112511");
        Assert.That(hand.jundaNumber == 61);
        Assert.That(hand.tzaiNumber == 89827);
    }

    [Test]
    public void gateAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "𠁣");
        Assert.That(hand == null);
        /*
        Assert.That(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.That(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.That(hand.exceptionLetter == "s");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.That(hand.rawCodepoint == "3112");
        Assert.That(hand.jundaNumber == 280442);
        Assert.That(hand.tzaiNumber == 236673);*/
    }

    [Test]
    public void gateCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "閥");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"nraw", "nrai"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"ngngrw", "ngngri"}));
        //Assert.That(hand.exceptionLetter == "n");
        Assert.That(hand.foundExceptionElems.SetEquals(new HashSet<string>{"門"}));
        Assert.That(hand.rawCodepoint == "2511251132(1534|1543)");
        Assert.That(hand.jundaNumber == null);
        Assert.That(hand.tzaiNumber == 1153);
    }

    [Test]
    public void noExceptOne()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "丠");

        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"xgh", "xdh", "xat"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"xgh", "xdh", "xat"}));
        Assert.That(hand.exceptionLetter == null);
        Assert.That(hand.foundExceptionElems == null);
        Assert.That(hand.rawCodepoint == "211(15|35|53)1");
        Assert.That(hand.jundaNumber == null);
        Assert.That(hand.tzaiNumber == null);
    }

    [Test]
    public void noExceptionTwo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "甑");
        
        Assert.That(hand.rolledOutNoShape.SequenceEqual(
            new List<string>{"丷", "囗", "⺌", "日", "瓦"}));
        Assert.That(hand.rolledOutWithShape.SequenceEqual(
            new List<string>{"⿰", "⿱", "丷", "⿱", "⿴", "囗", "⺌", "日", "瓦"}));
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"wnbl", "inbl"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"wnbtnl", "inbtnl"}));
        Assert.That(hand.exceptionLetter == null);
        Assert.That(hand.foundExceptionElems == null);
        Assert.That(hand.rawCodepoint == "(34|43)25243125111(5|21)54");
        Assert.That(hand.jundaNumber == 209);
        Assert.That(hand.tzaiNumber == 14);
    }
    
    //是
    [Test]
    public void noException_IS()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "是");
        
        Assert.That(hand.rolledOutNoShape.SequenceEqual(
            new List<string>{"日", "一", "龰"}));
        Assert.That(hand.rolledOutWithShape.SequenceEqual(
            new List<string>{"⿱", "日", "⿱", "一", "龰"}));
        //Assert.That(hand.code4.SetEquals(new HashSet<string>{"ngfw"}));
        //Assert.That(hand.code6.SetEquals(new HashSet<string>{"ngfdy"}));
        Assert.That(hand.exceptionLetter == null);
        Assert.That(hand.foundExceptionElems == null);
        Assert.That(hand.rawCodepoint == "251112134");
        Assert.That(hand.jundaNumber == 2615490);
        Assert.That(hand.tzaiNumber == 3200626);
    }
    
}