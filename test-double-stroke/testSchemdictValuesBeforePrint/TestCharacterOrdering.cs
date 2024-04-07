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
        
        Assert.IsTrue(heisigTradAbove9th_1to4.Count == 0);
        Assert.IsTrue(heisigTradAbove9th_5to6.Count == 0);
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
        Assert.IsTrue(heisigTradAbove9th_1to4.Count == 0);
        Assert.IsTrue(heisigTradAbove9th_5to6.Count == 0);

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
        
        Assert.IsTrue(heisigTradAbove9th_1to4.Count == 0);
        Assert.IsTrue(heisigTradAbove9th_5to6.Count == 1);
        Assert.IsTrue(heisigTradAbove9th_5to6.Single() == "騾");
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
        Assert.IsTrue(heisigTradAbove9th_1to4.Count == 0);
        Assert.IsTrue(heisigTradAbove9th_5to6.Count == 0);
        //Assert.IsTrue(heisigTradAbove9th_5to6.Single() == "馱");
        // "馱" Tzai 4555, to carry on ones back
    }
    
    
    [Test]
    public void TestPrintOrderTVIHcharacters_JundaList()
    {
        var simp = simplifiedOutputList;
        var index = simp.IndexOf("秀\ttvih");
   
        //秀	tvih Tzai 20948 Junda 24620 UNI 
        Assert.AreEqual(simp[index], "秀\ttvih");
        //秃	tvih Tzai 0     Junda 3640  UNI 
        Assert.AreEqual(simp[index+1], "秃\ttvih");
        //稠	tvih Tzai 334   Junda 1194  UNI 
        Assert.AreEqual(simp[index+2], "稠\ttvih");  
        //黏	tvih Tzai 2958  Junda 862   UNI  
        Assert.AreEqual(simp[index+3], "黏\ttvih");
        //禿	tvih Tzai 2552  Junda 10    UNI 
        Assert.AreEqual(simp[index+4], "禿\ttvih");
        //秳	tvih Tzai 0     Junda 1     UNI 31219 
        Assert.AreEqual(simp[index+5], "秳\ttvih");  
        //穚	tvih Tzai 30    Junda 0     UNI 
        Assert.AreEqual(simp[index+6], "穚\ttvih");
        //秪	tvih Tzai 11    Junda 0     UNI 
        Assert.AreEqual(simp[index+7], "秪\ttvih");
        //䄧	tvih Tzai 0     Junda 0     UNI 16679 
        Assert.AreEqual(simp[index+8], "䄧\ttvih"); 
        //䄪	tvih Tzai 0     Junda 0     UNI 16682 
        Assert.AreEqual(simp[index+9], "䄪\ttvih"); 
        //䅂	tvih Tzai 0     Junda 0     UNI 16706 
        Assert.AreEqual(simp[index+10], "䅂\ttvih"); 
        //䅮	tvih Tzai 0     Junda 0     UNI 16750 
        Assert.AreEqual(simp[index+11], "䅮\ttvih"); 
        //䆌	tvih Tzai 0     Junda 0     UNI 16780 
        Assert.AreEqual(simp[index+12], "䆌\ttvih"); 
        //䵕	tvih Tzai 0     Junda 0     UNI 19797 
        Assert.AreEqual(simp[index+13], "䵕\ttvih"); 
        //秴	tvih Tzai 0     Junda 0     UNI 31220 
        Assert.AreEqual(simp[index+14], "秴\ttvih"); 
        
        Assert.True(true);
    }
    
    [Test]
    public void TestPrintOrderTVIHcharacters_TzaiList()
    {
        var trad = traditionalOutputList;
        var index = trad.IndexOf("秀\ttvih");
   
        //秀	tvih Tzai 20948 Junda 24620 UNI 
        Assert.AreEqual(trad[index], "秀\ttvih");
        //黏	tvih Tzai 2958  Junda 862   UNI  
        Assert.AreEqual(trad[index+1], "黏\ttvih");
        //禿	tvih Tzai 2552  Junda 10    UNI 
        Assert.AreEqual(trad[index+2], "禿\ttvih");
        //稠	tvih Tzai 334   Junda 1194  UNI 
        Assert.AreEqual(trad[index+3], "稠\ttvih");  
        //穚	tvih Tzai 30    Junda 0     UNI 
         Assert.AreEqual(trad[index+4], "穚\ttvih");
        //秪	tvih Tzai 11    Junda 0     UNI 
        Assert.AreEqual(trad[index+5], "秪\ttvih");
        //秃	tvih Tzai 0     Junda 3640  UNI 
         Assert.AreEqual(trad[index+6], "秃\ttvih");
        //秳	tvih Tzai 0     Junda 1     UNI 31219 
        Assert.AreEqual(trad[index+7], "秳\ttvih"); 
        //䄧	tvih Tzai 0     Junda 0     UNI 16679 
        Assert.AreEqual(trad[index+8], "䄧\ttvih"); 
        //䄪	tvih Tzai 0     Junda 0     UNI 16682 
        Assert.AreEqual(trad[index+9], "䄪\ttvih"); 
        //䅂	tvih Tzai 0     Junda 0     UNI 16706 
        Assert.AreEqual(trad[index+10], "䅂\ttvih"); 
        //䅮	tvih Tzai 0     Junda 0     UNI 16750 
        Assert.AreEqual(trad[index+11], "䅮\ttvih"); 
        //䆌	tvih Tzai 0     Junda 0     UNI 16780 
        Assert.AreEqual(trad[index+12], "䆌\ttvih"); 
        //䵕	tvih Tzai 0     Junda 0     UNI 19797 
        Assert.AreEqual(trad[index+13], "䵕\ttvih"); 
        //秴	tvih Tzai 0     Junda 0     UNI 31220 
        Assert.AreEqual(trad[index+14], "秴\ttvih"); 
        
        Assert.True(true);
    }
    
    [Test]
    public void TestPrintOrderMatchesJundaTzaiAndUnicode_jundaList()
    {
        var checkJundaSort = simplifiedOutputList;
        List<List<string>> sortingInconsistencies = 
            OrderingHelper.getSortingInconsistenciesJunda(simplifiedOutputList, charToSchemaDict);
        Assert.True(sortingInconsistencies.Count == 0);
    }

    [Test]
    public void TestPrintOrderMatchesJundaTzaiAndUnicode_tzaiList()
    {
        var checkTzaiSort = traditionalOutputList;
        List<List<string>> sortingInconsistencies = 
            OrderingHelper.getSortingInconsistenciesTzai(checkTzaiSort, charToSchemaDict);
        Assert.True(sortingInconsistencies.Count == 0);
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
        Assert.True(freqCharsNotFound.Count == 0);
    }

    [Test]
    public void testTop5001SimplifiedCharacterExeptions()
    {
        
        var junda5001Keys = junda5001.Keys.ToHashSet();
        var jundaRecord = SchemeRecordsBySchemeLetter(junda5001Keys);

        Assert.True(jundaRecord.Count == 11);
        
        var sLet = jundaRecord.GetValueOrDefault("s");
        Assert.True(sLet.Count == 238);
        var dLet = jundaRecord.GetValueOrDefault("d");
         Assert.True(dLet.Count == 42);
        var fLet = jundaRecord.GetValueOrDefault("f");
         Assert.True(fLet.Count == 54);
        var jLet = jundaRecord.GetValueOrDefault("j");
         Assert.True(jLet.Count == 78);
        var kLet = jundaRecord.GetValueOrDefault("k");
         Assert.True(kLet.Count == 180);
        var lLet = jundaRecord.GetValueOrDefault("l");
        Assert.True(lLet.Count == 72);
        var hLet = jundaRecord.GetValueOrDefault("h");
         Assert.True(hLet.Count == 2);
         // 結 187 hffh
         // 經 469 hamx
        var vLet = jundaRecord.GetValueOrDefault("v");
         Assert.True(vLet.Count == 3);
         // 言 120308 v ggng ygng
         // 變 202 vmuw vmow
         // 這 483 vpy vol vpl
        var tLet = jundaRecord.GetValueOrDefault("t");
          Assert.True(tLet.Count == 4); 
          // 金 167912 t wgbt
          // 鎗 216 twah twph
          // 鏡 184 tyiq 
          // 鑫 670 twgt
        var nLet = jundaRecord.GetValueOrDefault("n");
          Assert.True(nLet.Count == 1); //間 207 nng
        var yLet = jundaRecord.GetValueOrDefault("y");
        Assert.True(yLet.Count == 1); //食 58110 y wagw wpgw
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
        
        Assert.IsEmpty(number10Junda);
        
    }

    [Test]
    public void testLengthsTraditional()
    {
        var codesWithManyChars = traditionalDictList.Values
            .Where(listSch => OrderingHelper.longlist(listSch)).ToList();
        var number10Tzai = codesWithManyChars
            .Where(listSch => OrderingHelper.tzaiAt10(listSch, tzaiFreq5001));//.
        //Select(listTooHigh => listTooHigh[9]).ToList();
        
        Assert.IsEmpty(number10Tzai);
        
    }
    

    /*
     
     var allAboveThe9th = AllAboveThe9Th(simplifiedDictList,
                new HashSet<int>{1,2,3,4,5,6});
     
             List<long> greatInts = allAboveThe9th.
                 Where(y => y.jundaNumber != null).
                 Select(x => x.jundaNumber.Value).ToList().
                 OrderByDescending(z => z).ToList();
             
             Assert.IsTrue(greatInts[0] < jundaFreq5001);
     
     */
    
}