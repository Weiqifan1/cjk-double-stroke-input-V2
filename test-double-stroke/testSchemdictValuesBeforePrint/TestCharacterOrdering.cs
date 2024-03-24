using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;
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
    public void TestPrintOrderMatchesJundaTzaiAndUnicode_jundaList()
    {
        var checkJundaSort = simplifiedListString;
        List<List<string>> sortingInconsistencies = getSortingInconsistenciesJunda(simplifiedListString);
        Assert.True(sortingInconsistencies.Count == 0);
    }

    [Test]
    public void TestPrintOrderMatchesJundaTzaiAndUnicode_tzaiList()
    {
        var checkTzaiSort = traditionalListString;
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


    [Test]
    public void testSortedJundaCountAfterNine()
    {
        var codesWithManyChars = simplifiedDictList.Values.Where(listSch => longlist(listSch)).ToList();

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

        List<long> greatInts = allAboveThe9th.
            Where(y => y.jundaNumber != null).
            Select(x => x.jundaNumber.Value).ToList().
            OrderByDescending(z => z).ToList();
        
        Assert.IsTrue(greatInts[0] < jundaFreq5001);
        
        string test = "";
    }
    
    [Test]
    public void testSortedTzaiCountAfterNine()
    {
        var codesWithManyChars = traditionalDictList.Values.Where(listSch => longlist(listSch)).ToList();

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

        List<long> greatInts = allAboveThe9th.
            Where(y => y.tzaiNumber != null).
            Select(x => x.tzaiNumber.Value).ToList().
            OrderByDescending(z => z).ToList();
        
        Assert.IsTrue(greatInts[0] < tzaiFreq5001);
        
        string test = "";
    }
    
    
    [Test]
    public void testLengthsSimplified()
    {
        var codesWithManyChars = simplifiedDictList.Values.Where(listSch => longlist(listSch)).ToList();
        var number10Junda = codesWithManyChars.Where(listSch => jundaAt10(listSch));//.
            //Select(listTooHigh => listTooHigh[9]).ToList();
        
        Assert.IsEmpty(number10Junda);
        
        string test = "";
    }

    [Test]
    public void testLengthsTraditional()
    {
        var codesWithManyChars = traditionalDictList.Values.Where(listSch => longlist(listSch)).ToList();
        var number10Tzai = codesWithManyChars.Where(listSch => tzaiAt10(listSch));//.
        //Select(listTooHigh => listTooHigh[9]).ToList();
        
        Assert.IsEmpty(number10Tzai);
        
        string test = "";
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
    
}