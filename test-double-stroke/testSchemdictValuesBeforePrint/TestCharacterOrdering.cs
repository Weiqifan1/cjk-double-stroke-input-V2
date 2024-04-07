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
    private Dictionary<string, FrequencyRecord> junda;
    private Dictionary<string, FrequencyRecord> junda5001;
    private Dictionary<string, FrequencyRecord> tzai;
    private Dictionary<string, FrequencyRecord> tzai5001;
        
    [SetUp]
    public void Initialize()
    {GenerateFileMaps gen = new GenerateFileMaps();
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
        List<Tuple<string, HashSet<string>>> above9th = AllAbove9thMODIFIED(simplifiedOutputList);

        HashSet<string> above9thFiltered_1to4 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> { 1, 2, 3, 4});
        
        HashSet<string> above9thFiltered_5to6 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> {5, 6});

        HashSet<string> heisigTradAbove9th_1to4 = getHeisig(above9thFiltered_1to4, heisigSimp);
        HashSet<string> heisigTradAbove9th_5to6 = getHeisig(above9thFiltered_5to6, heisigSimp);
        
        Assert.IsTrue(heisigTradAbove9th_1to4.Count == 0);
        Assert.IsTrue(heisigTradAbove9th_5to6.Count == 0);
    }
    
    [Test]
    public void testJundaAfterNine_Junda5001()
    { 
        List<Tuple<string, HashSet<string>>> above9th = AllAbove9thMODIFIED(simplifiedOutputList);

        HashSet<string> above9thFiltered_1to4 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> { 1, 2, 3, 4});
        
        HashSet<string> above9thFiltered_5to6 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> {5, 6});

        HashSet<string> heisigTradAbove9th_1to4 = getWithinFreq(above9thFiltered_1to4, junda5001);
        HashSet<string> heisigTradAbove9th_5to6 = getWithinFreq(above9thFiltered_5to6, junda5001);
        Assert.IsTrue(heisigTradAbove9th_1to4.Count == 0);
        Assert.IsTrue(heisigTradAbove9th_5to6.Count == 0);

    }
    
    [Test]
    public void testTzaiAfterNine_heisig()
    { 
        List<Tuple<string, HashSet<string>>> above9th = AllAbove9thMODIFIED(traditionalOutputList);

        HashSet<string> above9thFiltered_1to4 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> { 1, 2, 3, 4});
        
        HashSet<string> above9thFiltered_5to6 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> {5, 6});

        HashSet<string> heisigTradAbove9th_1to4 = getHeisig(above9thFiltered_1to4, heisigTrad);
        HashSet<string> heisigTradAbove9th_5to6 = getHeisig(above9thFiltered_5to6, heisigTrad);
        
        Assert.IsTrue(heisigTradAbove9th_1to4.Count == 0);
        Assert.IsTrue(heisigTradAbove9th_5to6.Count == 1);
        Assert.IsTrue(heisigTradAbove9th_5to6.Single() == "騾");
    }
    
    [Test]
    public void testTzaiAfterNine_Tzai5001()
    { 
        List<Tuple<string, HashSet<string>>> above9th = AllAbove9thMODIFIED(traditionalOutputList);

        HashSet<string> above9thFiltered_1to4 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> { 1, 2, 3, 4});
        
        HashSet<string> above9thFiltered_5to6 = 
            OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> {5, 6});

        HashSet<string> heisigTradAbove9th_1to4 = getWithinFreq(above9thFiltered_1to4, tzai5001);
        HashSet<string> heisigTradAbove9th_5to6 = getWithinFreq(above9thFiltered_5to6, tzai5001);
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
        List<List<string>> sortingInconsistencies = getSortingInconsistenciesJunda(simplifiedOutputList);
        Assert.True(sortingInconsistencies.Count == 0);
    }

    [Test]
    public void TestPrintOrderMatchesJundaTzaiAndUnicode_tzaiList()
    {
        var checkTzaiSort = traditionalOutputList;
        List<List<string>> sortingInconsistencies = getSortingInconsistenciesTzai(checkTzaiSort);
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
/*
    [Test]
    public void testHeisigTrad_TzaiCountAfterNine()
    {
         List<Tuple<string, HashSet<string>>> above9th = AllAbove9thMODIFIED(traditionalOutputList);

         
        
         var allAboveThe9th = AllAboveThe9Th(traditionalDictList, 
             new HashSet<int>{5,6});

         List<string> heisigAllCodesBeyond9th = allAboveThe9th.
             Where(y => heisigTrad.ContainsKey(y.character)).
             Select(x => x.character).ToList();
        
        var smallCodesAboveThe9th = AllAboveThe9Th(traditionalDictList, 
            new HashSet<int>{1,2,3,4});
            
        List<string> heisigSmallBeyond9th = smallCodesAboveThe9th.
            Where(y => heisigTrad.ContainsKey(y.character)).
            Select(x => x.character).ToList();
        
         Assert.IsTrue(heisigAllCodesBeyond9th.Count == 2);
         Assert.IsTrue(heisigAllCodesBeyond9th[0] == "騾");
         Assert.IsTrue(heisigAllCodesBeyond9th[1] == "騾"); 
         //heisigTrad: 騾 2859 mule  Tzai: 5168 73  Junda: 7167 9
         
         Assert.IsTrue(heisigSmallBeyond9th.Count == 0);
        
         
    }
*/
    
    [Test]
    public void testLengthsSimplified()
    {
        var codesWithManyChars = simplifiedDictList.Values
            .Where(listSch => longlist(listSch)).ToList();
        var number10Junda = codesWithManyChars
            .Where(listSch => jundaAt10(listSch));//.
            //Select(listTooHigh => listTooHigh[9]).ToList();
        
        Assert.IsEmpty(number10Junda);
        
    }

    [Test]
    public void testLengthsTraditional()
    {
        var codesWithManyChars = traditionalDictList.Values
            .Where(listSch => longlist(listSch)).ToList();
        var number10Tzai = codesWithManyChars
            .Where(listSch => tzaiAt10(listSch));//.
        //Select(listTooHigh => listTooHigh[9]).ToList();
        
        Assert.IsEmpty(number10Tzai);
        
    }
    
    private bool jundaAt10(List<SchemeRecord> listSch)
    {
        if (listSch.Count < 10)
        {
            return false;
        }
        var nr10 = listSch[9];
        var junda = nr10.jundaNumber;
        if (junda.HasValue && junda.Value >= jundaFreq5001)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
    private bool tzaiAt10(List<SchemeRecord> listSch)
    {
        if (listSch.Count < 10)
        {
            return false;
        }
        var nr10 = listSch[9];
        var tzai = nr10.tzaiNumber;
        if (tzai.HasValue && tzai.Value >= tzaiFreq5001)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool longlist(List<SchemeRecord> listSch)
    {
        bool longlist = listSch.Count > 9;

        return longlist;
    }

    
    private List<List<string>> getSortingInconsistenciesJunda(List<string> jundareadytoprint)
    {
        List<List<string>> result = new List<List<string>>();
        List<string> eachCompare = new List<string>();
        string previusStr = "";
        string currentString = "";
        string nextString = "";
        long currentJunda = 99999999;
        long currentTzai = 99999999;
        long unicode = 1;
        List<string> currenttupple = new List<string>();
        for (int i = 1; i < jundareadytoprint.Count; i++)
        {
            eachCompare = new List<string>();
            string prev = jundareadytoprint[i - 1];
            string current = jundareadytoprint[i];
            var splitStrPrev = prev.Split('\t').ToList();
            var splitStrCurrent = current.Split('\t').ToList();
            if (splitStrPrev.Count != 2 && splitStrCurrent.Count != 2)
            {
                List<string> temperror = new List<string>();
                temperror.Add(prev);
                temperror.Add(current);
                result.Add(temperror);
                break;
            }

            var schemPrev = charToSchemaDict.GetValueOrDefault(splitStrPrev[0]);
            var schemCurrent = charToSchemaDict.GetValueOrDefault(splitStrCurrent[0]);
            if (splitStrPrev[1] == splitStrCurrent[1])
            {
                
                if (
                    schemPrev.jundaNumber != null 
                    && schemCurrent.jundaNumber != null 
                    && schemPrev.jundaNumber < schemCurrent.jundaNumber)
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current);
                } else if (schemPrev.jundaNumber == null 
                           && schemCurrent.jundaNumber != null)
                {
                     eachCompare.Add(prev);
                     eachCompare.Add(current);
                } else if (schemPrev.jundaNumber == null 
                           && schemCurrent.jundaNumber == null 
                           && schemPrev.tzaiNumber != null 
                           && schemCurrent.tzaiNumber != null 
                           && schemPrev.tzaiNumber < schemCurrent.tzaiNumber)
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current);
                } else if (schemPrev.jundaNumber == null 
                           && schemCurrent.jundaNumber == null
                           && schemPrev.tzaiNumber == null
                           && schemCurrent.tzaiNumber != null)
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current);
                } else if (schemPrev.jundaNumber == null 
                           && schemCurrent.jundaNumber == null
                           && schemPrev.tzaiNumber == null
                           && schemCurrent.tzaiNumber == null 
                           && char.ConvertToUtf32(splitStrPrev[0], 0) > 
                           char.ConvertToUtf32(splitStrCurrent[0], 0))
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current); 
                }

                if (splitStrPrev[1].Length > splitStrCurrent[1].Length)
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current); 
                } 
                
                if (string.Compare(splitStrPrev[1], splitStrCurrent[1], 
                        StringComparison.OrdinalIgnoreCase) > 0)
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current); 
                }
            }
            
            if (eachCompare.Count > 0)
            {
                result.Add(eachCompare);
            }
        }
        return result;
    }
    
    private List<List<string>> getSortingInconsistenciesTzai(List<string> jundareadytoprint)
    {
        List<List<string>> result = new List<List<string>>();
        List<string> eachCompare = new List<string>();
        string previusStr = "";
        string currentString = "";
        string nextString = "";
        long currentJunda = 99999999;
        long currentTzai = 99999999;
        long unicode = 1;
        List<string> currenttupple = new List<string>();
        for (int i = 1; i < jundareadytoprint.Count; i++)
        {
            eachCompare = new List<string>();
            string prev = jundareadytoprint[i - 1];
            string current = jundareadytoprint[i];
            var splitStrPrev = prev.Split('\t').ToList();
            var splitStrCurrent = current.Split('\t').ToList();
            if (splitStrPrev.Count != 2 && splitStrCurrent.Count != 2)
            {
                List<string> temperror = new List<string>();
                temperror.Add(prev);
                temperror.Add(current);
                result.Add(temperror);
                break;
            }

            var schemPrev = charToSchemaDict.GetValueOrDefault(splitStrPrev[0]);
            var schemCurrent = charToSchemaDict.GetValueOrDefault(splitStrCurrent[0]);
            if (splitStrPrev[1] == splitStrCurrent[1])
            {
                
                if (
                    schemPrev.tzaiNumber != null 
                    && schemCurrent.tzaiNumber != null 
                    && schemPrev.tzaiNumber < schemCurrent.tzaiNumber)
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current);
                } else if (schemPrev.tzaiNumber == null 
                           && schemCurrent.tzaiNumber != null)
                {
                     eachCompare.Add(prev);
                     eachCompare.Add(current);
                } else if (schemPrev.tzaiNumber == null 
                           && schemCurrent.tzaiNumber == null 
                           && schemPrev.jundaNumber != null 
                           && schemCurrent.jundaNumber != null 
                           && schemPrev.jundaNumber < schemCurrent.jundaNumber)
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current);
                } else if (schemPrev.tzaiNumber == null 
                           && schemCurrent.tzaiNumber == null
                           && schemPrev.jundaNumber == null
                           && schemCurrent.jundaNumber != null)
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current);
                } else if (schemPrev.tzaiNumber == null 
                           && schemCurrent.tzaiNumber == null
                           && schemPrev.jundaNumber == null
                           && schemCurrent.jundaNumber == null 
                           && char.ConvertToUtf32(splitStrPrev[0], 0) > 
                           char.ConvertToUtf32(splitStrCurrent[0], 0))
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current); 
                }

                if (splitStrPrev[1].Length > splitStrCurrent[1].Length)
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current); 
                } 
                
                if (string.Compare(splitStrPrev[1], splitStrCurrent[1], 
                        StringComparison.OrdinalIgnoreCase) > 0)
                {
                    eachCompare.Add(prev);
                    eachCompare.Add(current); 
                }
            }
            
            if (eachCompare.Count > 0)
            {
                result.Add(eachCompare);
            }
        }
        return result;
    }

    private List<Tuple<string, HashSet<string>>> AllAbove9thMODIFIED(
        List<string> outputList)
    {
       List<Tuple<string, HashSet<string>>> result = new List<Tuple<string, HashSet<string>>>();
       HashSet<string> over9thCharsByCode = new HashSet<string>();
       
       //-- skriv bedre code her
       string previousCode = "test2";
       string currentCode = "test";
       int numberOfChars = 0;
       long indexcount = -1;
       foreach (var VARIABLE in outputList)
       {
           indexcount += 1;
           string[] splitInput = Regex.Split(VARIABLE, @"\s+");
           previousCode = currentCode;
           currentCode = splitInput[1];
           if (previousCode == currentCode)
           {
               if (currentCode == "dngw")
               {
                   string res = "";
               }

               if (splitInput[0] == "碩")
               {
                   string tes = "";
               }

               numberOfChars += 1;
               if (numberOfChars > 9)
               {
                    over9thCharsByCode.Add(splitInput[0]);
               }
           }
           else
           {
               numberOfChars = 1;
               if (over9thCharsByCode.Count > 0)
               {
                   result.Add(
                       new Tuple<string, HashSet<string>>(previousCode, over9thCharsByCode)
                       );
               }
               over9thCharsByCode = new HashSet<string>();
           }
       }

/*
       HashSet<string> codes = new HashSet<string>();
        foreach (var VARIABLE in outputList)
        {
            string[] splitInput = Regex.Split(VARIABLE, @"\s+");
            codes.Add(splitInput[1]);
        }

        foreach (var eachCode in codes)
        {
            HashSet<string> over9thCharsByCode = new HashSet<string>();
            int numberOfChars = 0;
            foreach (var eachChar in outputList)
            {
                string[] splitInput = Regex.Split(eachChar, @"\s+"); 
                if (splitInput[1] == eachCode)
                {
                    numberOfChars += 1;
                    if (numberOfChars > 9)
                    {
                        over9thCharsByCode.Add(splitInput[0]);
                    }
                }
            }

            if (over9thCharsByCode.Count > 0)
            {
                Tuple<string, HashSet<string>> myTuple =
                    new Tuple<string, HashSet<string>>(eachCode, over9thCharsByCode);
                result.Add(myTuple);
            }
        }*/
        return result;
    }

    
    private List<SchemeRecord> AllAboveThe9Th(
        Dictionary<string, List<SchemeRecord>> dictList,
        HashSet<int> codelengthToInclude)
    {
        Dictionary<string, List<SchemeRecord>> tempDict =
            dictList.Where(pair => 
                codelengthToInclude.Contains(pair.Key.Length))
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        var codesWithManyChars = tempDict
            .Values.Where(listSch => longlist(listSch)).ToList();
        
        List<SchemeRecord> allAboveThe9th = new List<SchemeRecord>();
        foreach (var VARIABLE in codesWithManyChars)
        {
            for (int i = 0; i < VARIABLE.Count; i++)
            {
                var current = VARIABLE[i];
                if (i > 8)
                {
                    allAboveThe9th.Add(current);
                }
            }
        }

        return allAboveThe9th;
    }
    private HashSet<string> getWithinFreq(
         HashSet<string> above9ThFiltered, 
         Dictionary<string, FrequencyRecord> charToFreqDict)
    {
        HashSet<string> result = new HashSet<string>();
        foreach (var VARIABLE in above9ThFiltered)
        {
            if (charToFreqDict.ContainsKey(VARIABLE))
            {
                result.Add(VARIABLE);
            }
        }
        return result;
    }   

    private HashSet<string> getHeisig(
        HashSet<string> above9ThFiltered, 
        Dictionary<string, AlternativeCharsetRecord> heisig)
    {
        HashSet<string> result = new HashSet<string>();
        foreach (var VARIABLE in above9ThFiltered)
        {
            if (heisig.ContainsKey(VARIABLE))
            {
                result.Add(VARIABLE);
            }
        }
        return result;
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