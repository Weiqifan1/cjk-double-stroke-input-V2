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
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void handCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "扔");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"sq", "sk"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fdh", "fat"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"扌"}));
        Assert.IsTrue(hand.rawCodepoint == "121(35|53)");
        Assert.IsTrue(hand.jundaNumber == 8045);
        Assert.IsTrue(hand.tzaiNumber == 931);
    }
    
    [Test]
    public void eyeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "目");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"d"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"ngg"}));
        Assert.IsTrue(hand.exceptionLetter == "d");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"目"}));
        Assert.IsTrue(hand.rawCodepoint == "25111");
        Assert.IsTrue(hand.jundaNumber == 180827);
        Assert.IsTrue(hand.tzaiNumber == 157966);
        
    }
    
    [Test]
    public void eyeCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "眤");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"dhth", "dheh", "dhqt"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"ngada", "ngadq", "ngadk"}));
        Assert.IsTrue(hand.exceptionLetter == "d");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"目"}));
        Assert.IsTrue(hand.rawCodepoint == "25111513(15|35|53)");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    
    [Test]
    public void footNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "足");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"f"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"nfdy"}));
        Assert.IsTrue(hand.exceptionLetter == "f");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"足"}));
        Assert.IsTrue(hand.rawCodepoint == "2512134");
        Assert.IsTrue(hand.jundaNumber == 77385);
        Assert.IsTrue(hand.tzaiNumber == 47014);
    }
    
    [Test]
    public void footCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "趵");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"fqg", "fqy"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"nfaqg", "nfaqy", "nffdh", "nffdl"}));
        Assert.IsTrue(hand.exceptionLetter == "f");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"𧾷"}));
        Assert.IsTrue(hand.rawCodepoint == "251(215|2121)35(1|4)");
        Assert.IsTrue(hand.jundaNumber == 53);
        Assert.IsTrue(hand.tzaiNumber == 8);
    }
    
    
    [Test]
    public void footAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "𧾷");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"f"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"nfa", "nffg"}));
        Assert.IsTrue(hand.exceptionLetter == "f");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"𧾷"}));
        Assert.IsTrue(hand.rawCodepoint == "251(215|2121)");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    
    [Test]
    public void insectNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "虫");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"j"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"nfs"}));
        Assert.IsTrue(hand.exceptionLetter == "j");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"虫"}));
        Assert.IsTrue(hand.rawCodepoint == "251214");
        Assert.IsTrue(hand.jundaNumber == 18909);
        Assert.IsTrue(hand.tzaiNumber == 4789);
    }
    
    [Test]
    public void insectCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "虾");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"jfy"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"nfsfy"}));
        Assert.IsTrue(hand.exceptionLetter == "j");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"虫"}));
        Assert.IsTrue(hand.rawCodepoint == "251214124");
        Assert.IsTrue(hand.jundaNumber == 2338);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    
    [Test]
    public void treeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "木");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"k"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fw"}));
        Assert.IsTrue(hand.exceptionLetter == "k");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"木", "朩"}));
        Assert.IsTrue(hand.rawCodepoint == "1234");
        Assert.IsTrue(hand.jundaNumber == 54433);
        Assert.IsTrue(hand.tzaiNumber == 39692);
    }
    
    //朩
    [Test]
    public void treeAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "朩");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"k"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fw"}));
        Assert.IsTrue(hand.exceptionLetter == "k");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"木", "朩"}));
        Assert.IsTrue(hand.rawCodepoint == "1234");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    
    [Test]
    public void treeCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "松");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"kwl"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fwwl"}));
        Assert.IsTrue(hand.exceptionLetter == "k");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"木", "朩"}));
        Assert.IsTrue(hand.rawCodepoint == "12343454");
        Assert.IsTrue(hand.jundaNumber == 37563);
        Assert.IsTrue(hand.tzaiNumber == 28277);
    }
    
    [Test]
    public void bambooNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "竹");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"l"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tvf"}));
        Assert.IsTrue(hand.exceptionLetter == "l");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"竹"}));
        Assert.IsTrue(hand.rawCodepoint == "312312");
        Assert.IsTrue(hand.jundaNumber == 12000);
        Assert.IsTrue(hand.tzaiNumber == 96078);
    }
    
    
    [Test]
    public void bambooAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "⺮");
        Assert.IsTrue(hand == null);
        /*
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);*/
    }
    
    
    [Test]
    public void bambooCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "签");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"lwst"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tiswst"}));
        Assert.IsTrue(hand.exceptionLetter == "l");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"竹"}));
        Assert.IsTrue(hand.rawCodepoint == "3143143414431");
        Assert.IsTrue(hand.jundaNumber == 20057);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    
    [Test]
    public void goldNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "金");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"t"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"wgbt"}));
        Assert.IsTrue(hand.exceptionLetter == "t");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"金"}));
        Assert.IsTrue(hand.rawCodepoint == "34112431");
        Assert.IsTrue(hand.jundaNumber == 167912);
        Assert.IsTrue(hand.tzaiNumber == 108819);
    }
    
    [Test]
    public void goldCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "錯");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"tfxg"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"wgbtfg"}));
        Assert.IsTrue(hand.exceptionLetter == "t");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"金"}));
        Assert.IsTrue(hand.rawCodepoint == "3411243112212511");
        Assert.IsTrue(hand.jundaNumber == 30);
        Assert.IsTrue(hand.tzaiNumber == 168867);
    }
    
    [Test]
    public void eatNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "食");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"y"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"wagky", "wpgky"}));
        Assert.IsTrue(hand.exceptionLetter == "y");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"食", "飠"}));
        Assert.IsTrue(hand.rawCodepoint == "34(1|4)511534");
        Assert.IsTrue(hand.jundaNumber == 58110);
        Assert.IsTrue(hand.tzaiNumber == 22222);
    }

    [Test]
    public void eatAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "飠");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string> { "y" }));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string> { "wagl", "wpgl" }));
        Assert.IsTrue(hand.exceptionLetter == "y");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string> { "飠", "食" }));
        Assert.IsTrue(hand.rawCodepoint == "34(1|4)51154");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    
    [Test]
    public void eatCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "飼");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"yhng"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"waglhh", "wagxah", "wpglhh", "wpgxah"}));
        Assert.IsTrue(hand.exceptionLetter == "y");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"飠", "食"}));
        Assert.IsTrue(hand.rawCodepoint == "34(1|4)(51154|511211)51251");
        Assert.IsTrue(hand.jundaNumber == 4);
        Assert.IsTrue(hand.tzaiNumber == 1829);
    }

    [Test]
    public void carNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "車");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"g"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fhgx"}));
        Assert.IsTrue(hand.exceptionLetter == "g");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"車"}));
        Assert.IsTrue(hand.rawCodepoint == "1251112");
        Assert.IsTrue(hand.jundaNumber == 32);
        Assert.IsTrue(hand.tzaiNumber == 244964);
    }

    [Test]
    public void carCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "軒");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"ggx"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fhgxf"}));
        Assert.IsTrue(hand.exceptionLetter == "g");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"車"}));
        Assert.IsTrue(hand.rawCodepoint == "1251112112");
        Assert.IsTrue(hand.jundaNumber == 5);
        Assert.IsTrue(hand.tzaiNumber == 7731);
    }

    [Test]
    public void threadNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "糸");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"h"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"muw"}));
        Assert.IsTrue(hand.exceptionLetter == "h");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"糹", "糸"}));
        Assert.IsTrue(hand.rawCodepoint == "554234");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == 146);
    }

    [Test]
    public void threadCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "絆");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"hwgx", "higx"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"muwwgx", "muwigx", "moowgx", "mooigx"}));
        Assert.IsTrue(hand.exceptionLetter == "h");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"糸", "糹"}));
        Assert.IsTrue(hand.rawCodepoint == "(554234|554444)(34|43)112");
        Assert.IsTrue(hand.jundaNumber == 1);
        Assert.IsTrue(hand.tzaiNumber == 1261);
    }

    [Test]
    public void sayNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "言");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"v"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"ggng", "ygng"}));
        Assert.IsTrue(hand.exceptionLetter == "v");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"言", "訁"}));
        Assert.IsTrue(hand.rawCodepoint == "(1|4)111251");
        Assert.IsTrue(hand.jundaNumber == 120308);
        Assert.IsTrue(hand.tzaiNumber == 136534);
    }

    [Test]
    public void sayAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "訁");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"v"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"ggng", "ygng"}));
        Assert.IsTrue(hand.exceptionLetter == "v");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"言", "訁"}));
        Assert.IsTrue(hand.rawCodepoint == "(1|4)111251");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == null);
    }

    [Test]
    public void sayCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "謬");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"vkqe", "vlae"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"ggnaee", "ggnaye", "ygnaee", "ygnaye"}));
        Assert.IsTrue(hand.exceptionLetter == "v");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"言", "訁"}));
        Assert.IsTrue(hand.rawCodepoint == "(1|4)111251(533533|541541)34333");
        Assert.IsTrue(hand.jundaNumber == 3);
        Assert.IsTrue(hand.tzaiNumber == 3290);
    }

    [Test]
    public void horseNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "馬");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"b"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fgnoo", "xgnoo"}));
        Assert.IsTrue(hand.exceptionLetter == "b");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"馬"}));
        Assert.IsTrue(hand.rawCodepoint == "(12|21)11254444");
        Assert.IsTrue(hand.jundaNumber == 11);
        Assert.IsTrue(hand.tzaiNumber == 88333);
    }

    [Test]
    public void horseCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "騎");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"bdyf"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fgnoof", "xgnoof"}));
        Assert.IsTrue(hand.exceptionLetter == "b");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"馬"}));
        Assert.IsTrue(hand.rawCodepoint == "(12|21)1125444413412512");
        Assert.IsTrue(hand.jundaNumber == 3);
        Assert.IsTrue(hand.tzaiNumber == 39690);
    }

    [Test]
    public void gateNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "門");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"n"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"ngng"}));
        Assert.IsTrue(hand.exceptionLetter == "n");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"門"}));
        Assert.IsTrue(hand.rawCodepoint == "25112511");
        Assert.IsTrue(hand.jundaNumber == 61);
        Assert.IsTrue(hand.tzaiNumber == 89827);
    }

    [Test]
    public void gateAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "𠁣");
        Assert.IsTrue(hand == null);
        /*
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);*/
    }

    [Test]
    public void gateCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "閥");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"nraw", "nrai"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"ngngrw", "ngngri"}));
        Assert.IsTrue(hand.exceptionLetter == "n");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"門"}));
        Assert.IsTrue(hand.rawCodepoint == "2511251132(1534|1543)");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == 1153);
    }

    [Test]
    public void noExceptOne()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "丠");

        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"xgh", "xdh", "xat"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"xgh", "xdh", "xat"}));
        Assert.IsTrue(hand.exceptionLetter == null);
        Assert.IsTrue(hand.foundExceptionElems == null);
        Assert.IsTrue(hand.rawCodepoint == "211(15|35|53)1");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == null);
    }

    [Test]
    public void noExceptionTwo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "甑");
        
        Assert.IsTrue(hand.rolledOutNoShape.SequenceEqual(
            new List<string>{"丷", "囗", "⺌", "日", "瓦"}));
        Assert.IsTrue(hand.rolledOutWithShape.SequenceEqual(
            new List<string>{"⿰", "⿱", "丷", "⿱", "⿴", "囗", "⺌", "日", "瓦"}));
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"wnbl", "inbl"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"wnbtnl", "inbtnl"}));
        Assert.IsTrue(hand.exceptionLetter == null);
        Assert.IsTrue(hand.foundExceptionElems == null);
        Assert.IsTrue(hand.rawCodepoint == "(34|43)25243125111(5|21)54");
        Assert.IsTrue(hand.jundaNumber == 209);
        Assert.IsTrue(hand.tzaiNumber == 14);
    }
    
    //是
    [Test]
    public void noException_IS()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "是");
        
        Assert.IsTrue(hand.rolledOutNoShape.SequenceEqual(
            new List<string>{"日", "一", "龰"}));
        Assert.IsTrue(hand.rolledOutWithShape.SequenceEqual(
            new List<string>{"⿱", "日", "⿱", "一", "龰"}));
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"ngfw"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"wnbtnl", "inbtnl"}));
        Assert.IsTrue(hand.exceptionLetter == null);
        Assert.IsTrue(hand.foundExceptionElems == null);
        Assert.IsTrue(hand.rawCodepoint == "(34|43)25243125111(5|21)54");
        Assert.IsTrue(hand.jundaNumber == 209);
        Assert.IsTrue(hand.tzaiNumber == 14);
    }
    
}