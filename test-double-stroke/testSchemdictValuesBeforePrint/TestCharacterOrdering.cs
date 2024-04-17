using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.RegularExpressions;
using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace test_double_stroke.testSchemdictValuesBeforePrint;

public class TestCharacterOrdering : TestSchemaBeforePrintSetup
{

     public Dictionary<string, FrequencyRecord> junda;
     public Dictionary<string, FrequencyRecord> tzai;
     public Dictionary<string, FrequencyRecord> junda5001;
     public Dictionary<string, FrequencyRecord> tzai5001;
    
    [SetUp]
    public void Initialize()
    {
        GenerateFileMaps gen = new GenerateFileMaps();
        string jundaPath = Path.Combine(testDirectory, 
                             FilePaths.dotsAndSlash + FilePaths.jundaPathStr);
                             //@"..\..\..\..\double-stroke\projectFolder\StaticFiles\Junda2005.txt");
        string tzaiPath = Path.Combine(testDirectory, 
                             FilePaths.dotsAndSlash + FilePaths.tzaiPathStr);
        junda = gen.generateJundaMap(jundaPath);
        tzai = gen.generateTzaiMap(tzaiPath);
        junda5001 = gen.extractFirst5001Junda(jundaPath);
        tzai5001 = gen.extractFirst5001Tzai(tzaiPath);
        string test = "";
    }
    
    [Test]
    public void testJundaAfterNine_heisig()
    { 
        List<Tuple<string, HashSet<string>>> above9th = OrderingHelper.AllAbove9thMODIFIED(simplifiedOutputList);

        HashSet<string> above9thFiltered_1to4 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> { 1, 2, 3, 4});
        
        HashSet<string> above9thFiltered_5to6 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> {5, 6});

        HashSet<string> heisigTradAbove9th_1to4 = 
            OrderingHelper.getHeisig(above9thFiltered_1to4, heisigSimp);
        HashSet<string> heisigTradAbove9th_5to6 = 
            OrderingHelper.getHeisig(above9thFiltered_5to6, heisigSimp);
        
       Assert.That(heisigTradAbove9th_1to4.Count == 0);
       Assert.That(heisigTradAbove9th_5to6.Count == 0);
    }
    
    [Test]
    public void testJundaAfterNine_Junda5001()
    { 
        List<Tuple<string, HashSet<string>>> above9th = 
            OrderingHelper.AllAbove9thMODIFIED(simplifiedOutputList);

        HashSet<string> above9thFiltered_1to4 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> { 1, 2, 3, 4});
        
        HashSet<string> above9thFiltered_5to6 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> {5, 6});

        HashSet<string> heisigTradAbove9th_1to4 = 
            OrderingHelper.getWithinFreq(above9thFiltered_1to4, junda5001);
        HashSet<string> heisigTradAbove9th_5to6 = 
            OrderingHelper.getWithinFreq(above9thFiltered_5to6, junda5001);
       Assert.That(heisigTradAbove9th_1to4.Count == 0);
       Assert.That(heisigTradAbove9th_5to6.Count == 0);

    }
    
    [Test]
    public void testTzaiAfterNine_heisig()
    { 
        List<Tuple<string, HashSet<string>>> above9th = 
            OrderingHelper.AllAbove9thMODIFIED(traditionalOutputList);

        HashSet<string> above9thFiltered_1to4 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> { 1, 2, 3, 4});
        
        HashSet<string> above9thFiltered_5to6 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> {5, 6});

        HashSet<string> heisigTradAbove9th_1to4 = 
            OrderingHelper.getHeisig(above9thFiltered_1to4, heisigTrad);
        HashSet<string> heisigTradAbove9th_5to6 = 
            OrderingHelper.getHeisig(above9thFiltered_5to6, heisigTrad);
        
       Assert.That(heisigTradAbove9th_1to4.Count == 0);
       Assert.That(heisigTradAbove9th_5to6.Count == 1);
       Assert.That(heisigTradAbove9th_5to6.Single() == "騾");
    }
    
    [Test]
    public void testTzaiAfterNine_Tzai5001()
    { 
        List<Tuple<string, HashSet<string>>> above9th = 
            OrderingHelper.AllAbove9thMODIFIED(traditionalOutputList);

        HashSet<string> above9thFiltered_1to4 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> { 1, 2, 3, 4});
        
        HashSet<string> above9thFiltered_5to6 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> {5, 6});

        HashSet<string> heisigTradAbove9th_1to4 = 
            OrderingHelper.getWithinFreq(above9thFiltered_1to4, tzai5001);
        HashSet<string> heisigTradAbove9th_5to6 = 
            OrderingHelper.getWithinFreq(above9thFiltered_5to6, tzai5001);
       Assert.That(heisigTradAbove9th_1to4.Count == 0);
       Assert.That(heisigTradAbove9th_5to6.Count == 0);
        //Assert.IsTrue(heisigTradAbove9th_5to6.Single() == "馱");
        // "馱" Tzai 4555, to carry on ones back
    }
    
    
    [Test]
    public void TestPrintOrderTVIHcharacters_JundaList()
    {
        string code = "tvig"; 
        var simp = simplifiedOutputList;
        var index = simp.IndexOf("秀\t"+code);
   
        //秀	tvih Tzai 20948 Junda 24620 UNI 
        Assert.That(simp[index].Equals("秀\t" + code));
        //秃	tvih Tzai 0     Junda 3640  UNI 
        Assert.That(simp[index+1].Equals("秃\t"+ code));
        //稠	tvih Tzai 334   Junda 1194  UNI 
        Assert.That(simp[index+2].Equals("稠\t"+code));  
        //黏	tvih Tzai 2958  Junda 862   UNI  
        Assert.That(simp[index+3].Equals("黏\t"+code));
        //禿	tvih Tzai 2552  Junda 10    UNI 
        Assert.That(simp[index+4].Equals("禿\t"+code));
        //秳	tvih Tzai 0     Junda 1     UNI 31219 
        Assert.That(simp[index+5].Equals("秳\t"+code));  
        //穚	tvih Tzai 30    Junda 0     UNI 
        Assert.That(simp[index+6].Equals("穚\t"+code));
        //秪	tvih Tzai 11    Junda 0     UNI 
        Assert.That(simp[index+7].Equals("秪\t"+code));
        //䄧	tvih Tzai 0     Junda 0     UNI 16679 
        Assert.That(simp[index+8].Equals("䄧\t"+code)); 
        //䄪	tvih Tzai 0     Junda 0     UNI 16682 
        Assert.That(simp[index+9].Equals("䄪\t"+code)); 
        //䅂	tvih Tzai 0     Junda 0     UNI 16706 
        Assert.That(simp[index+10].Equals("䅂\t"+code)); 
        //䅮	tvih Tzai 0     Junda 0     UNI 16750 
        Assert.That(simp[index+11].Equals("䅮\t"+code)); 
        //䆌	tvih Tzai 0     Junda 0     UNI 16780 
        Assert.That(simp[index+12].Equals("䆌\t"+code)); 
        //䵕	tvih Tzai 0     Junda 0     UNI 19797 
        Assert.That(simp[index+13].Equals("䵕\t"+code)); 
        //秴	tvih Tzai 0     Junda 0     UNI 31220 
        Assert.That(simp[index+14].Equals("秴\t"+code)); 
        
        Assert.That(true);
    }
    
    [Test]
    public void TestPrintOrderTVIHcharacters_TzaiList()
    {
        string code = "tvig"; 
        var trad = traditionalOutputList;
        var index = trad.IndexOf("秀\t"+code);
   
        //秀	tvih Tzai 20948 Junda 24620 UNI 
        Assert.That(trad[index].Equals("秀\t"+code));
        //黏	tvih Tzai 2958  Junda 862   UNI  
        Assert.That(trad[index+1].Equals("黏\t"+code));
        //禿	tvih Tzai 2552  Junda 10    UNI 
        Assert.That(trad[index+2].Equals("禿\t"+code));
        //稠	tvih Tzai 334   Junda 1194  UNI 
        Assert.That(trad[index+3].Equals("稠\t"+code));  
        //穚	tvih Tzai 30    Junda 0     UNI 
         Assert.That(trad[index+4].Equals("穚\t"+code));
        //秪	tvih Tzai 11    Junda 0     UNI 
        Assert.That(trad[index+5].Equals("秪\t"+code));
        //秃	tvih Tzai 0     Junda 3640  UNI 
         Assert.That(trad[index+6].Equals("秃\t"+code));
        //秳	tvih Tzai 0     Junda 1     UNI 31219 
        Assert.That(trad[index+7].Equals("秳\t"+code)); 
        //䄧	tvih Tzai 0     Junda 0     UNI 16679 
        Assert.That(trad[index+8].Equals("䄧\t"+code)); 
        //䄪	tvih Tzai 0     Junda 0     UNI 16682 
        Assert.That(trad[index+9].Equals("䄪\t"+code)); 
        //䅂	tvih Tzai 0     Junda 0     UNI 16706 
        Assert.That(trad[index+10].Equals("䅂\t"+code)); 
        //䅮	tvih Tzai 0     Junda 0     UNI 16750 
        Assert.That(trad[index+11].Equals("䅮\t"+code)); 
        //䆌	tvih Tzai 0     Junda 0     UNI 16780 
        Assert.That(trad[index+12].Equals("䆌\t"+code)); 
        //䵕	tvih Tzai 0     Junda 0     UNI 19797 
        Assert.That(trad[index+13].Equals("䵕\t"+code)); 
        //秴	tvih Tzai 0     Junda 0     UNI 31220 
        Assert.That(trad[index+14].Equals("秴\t"+code)); 
        
        Assert.That(true);
    }
    
    [Test]
    public void TestPrintOrderMatchesJundaTzaiAndUnicode_jundaList()
    {
        var checkJundaSort = simplifiedOutputList;
        List<List<string>> sortingInconsistencies = 
            OrderingHelper.getSortingInconsistenciesJunda(simplifiedOutputList, charToSchemaDict);
        Assert.That(sortingInconsistencies.Count == 0);
    }

    [Test]
    public void TestPrintOrderMatchesJundaTzaiAndUnicode_tzaiList()
    {
        var checkTzaiSort = traditionalOutputList;
        List<List<string>> sortingInconsistencies = 
            OrderingHelper.getSortingInconsistenciesTzai(checkTzaiSort, charToSchemaDict);
        Assert.That(sortingInconsistencies.Count == 0);
    }
    
    [Test]
    public void TestCharToSchemaDictMapCorrespondToJundaAndTzai()
    {
        HashSet<string> characters = charToSchemaDict.Keys.ToHashSet();
        HashSet<string> freqChars = new HashSet<string>();
        freqChars.UnionWith(junda.Keys);
        freqChars.UnionWith(tzai.Keys);

        HashSet<string> freqCharsNotFound = new HashSet<string>();
        foreach (string freqChar in freqChars) {
            if (!characters.Contains(freqChar))
            {
                freqCharsNotFound.Add(freqChar);
            }
        }
        Assert.That(freqCharsNotFound.Count == 0);
    }

    [Test]
    public void testTop5001SimplifiedCharacterExeptions()
    {
        
        var junda5001Keys = junda5001.Keys.ToHashSet();
        var jundaRecord = SchemeRecordsBySchemeLetter(junda5001Keys);

        Assert.That(jundaRecord.Count == 11);
        
        var sLet = jundaRecord.GetValueOrDefault("l");
        Assert.That(sLet.Count == 238);
        var dLet = jundaRecord.GetValueOrDefault("k");
         Assert.That(dLet.Count == 42);
        var fLet = jundaRecord.GetValueOrDefault("j");
         Assert.That(fLet.Count == 78);
        var jLet = jundaRecord.GetValueOrDefault("f");
         Assert.That(jLet.Count == 72);
        var kLet = jundaRecord.GetValueOrDefault("d");
         Assert.That(kLet.Count == 180);
        var lLet = jundaRecord.GetValueOrDefault("s");
        Assert.That(lLet.Count == 54);
        var hLet = jundaRecord.GetValueOrDefault("p");
         Assert.That(hLet.Count == 1);
         // 結 187 hffh
         // 經 469 hamx
        var vLet = jundaRecord.GetValueOrDefault("o");
         Assert.That(vLet.Count == 4);
         // 言 120308 v ggng ygng
         // 變 202 vmuw vmow
         // 這 483 vpy vol vpl
        var tLet = jundaRecord.GetValueOrDefault("i");
          Assert.That(tLet == null); 
          // 金 167912 t wgbt
          // 鎗 216 twah twph
          // 鏡 184 tyiq 
          // 鑫 670 twgt
        var nLet = jundaRecord.GetValueOrDefault("u");
        Assert.That(nLet.Count == 2); //間 207 nng
        
        var rLet = jundaRecord.GetValueOrDefault("r");
        Assert.That(rLet == null); //食 58110 y wagw wpgw
       
        var eLet = jundaRecord.GetValueOrDefault("e");
        Assert.That(eLet.Count == 3); //食 58110 y wagw wpgw       
        
        var wLet = jundaRecord.GetValueOrDefault("w");
        Assert.That(wLet.Count == 1); //食 58110 y wagw wpgw        
       //  結經 變這  鎗鏡鑫 //
    }

    [Test]
    public void testTop5001TzaiCharacterExeptions()
    {
        var tzai5001Keys = tzai5001.Keys.ToHashSet();
        var tzaiRecord = SchemeRecordsBySchemeLetter(tzai5001Keys);
        
        //var schemes = junda5001Schema.Values.Select(obj => obj.exceptionLetter).ToHashSet();
        var test = "";
    }
    
    private Dictionary<string, List<SchemeRecord>> SchemeRecordsBySchemeLetter(HashSet<string> junda5001Keys)
    {
        Dictionary<string, List<SchemeRecord>> junda5001Schema = new Dictionary<string, List<SchemeRecord>>();
        foreach (var VARIABLE in charToSchemaDict)
        {
            if (junda5001Keys.Contains(VARIABLE.Key))
            {
                if (VARIABLE.Value.exceptionLetter != null 
                    && junda5001Schema.Keys.Contains(VARIABLE.Value.exceptionLetter))
                {
                    var currentletterList = junda5001Schema.GetValueOrDefault(VARIABLE.Value.exceptionLetter);
                    currentletterList.Add(VARIABLE.Value);
                    //junda5001Schema.Add(VARIABLE.Value.exceptionLetter, currentletterList);
                } else if (VARIABLE.Value.exceptionLetter != null)
                {
                    junda5001Schema.Add(VARIABLE.Value.exceptionLetter, new List<SchemeRecord> {VARIABLE.Value});
                }
            }
        }

        return junda5001Schema;
    }
    
    [Test]
    public void testLengthsSimplified()
    {
        var codesWithManyChars = simplifiedDictList.Values
            .Where(listSch => OrderingHelper.longlist(listSch)).ToList();
        var number10Junda = codesWithManyChars
            .Where(listSch => OrderingHelper.jundaAt10(listSch, jundaFreq5001));//.
            //Select(listTooHigh => listTooHigh[9]).ToList();
        
        Assert.That(number10Junda.ToList().Count == 0);
        
    }

    [Test]
    public void testLengthsTraditional()
    {
        var codesWithManyChars = traditionalDictList.Values
            .Where(listSch => OrderingHelper.longlist(listSch)).ToList();
        var number10Tzai = codesWithManyChars
            .Where(listSch => OrderingHelper.tzaiAt10(listSch, tzaiFreq5001));//.
        //Select(listTooHigh => listTooHigh[9]).ToList();
        
        Assert.That(number10Tzai.ToList().Count == 0);
        
    }
    

    /*
     
     var allAboveThe9th = AllAboveThe9Th(simplifiedDictList,
                new HashSet<int>{1,2,3,4,5,6});
     
             List<long> greatInts = allAboveThe9th.
                 Where(y => y.jundaNumber != null).
                 Select(x => x.jundaNumber.Value).ToList().
                 OrderByDescending(z => z).ToList();
             
            Assert.That(greatInts[0] < jundaFreq5001);
     
     */
    
}