using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace test_double_stroke.testSchemdictValuesBeforePrint;

public class TestCharacterOrdering : TestSchemaBeforePrintSetup
{
    
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

    
}