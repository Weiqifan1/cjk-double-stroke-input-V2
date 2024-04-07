using System.Text.RegularExpressions;
using double_stroke.projectFolder.StaticFileMaps;

namespace test_double_stroke;

public static class OrderingHelper
{
    
    public static HashSet<string> AllAboveThe9ThFilter(
        List<Tuple<string, HashSet<string>>> dictList,
        HashSet<int> codelengthToInclude)
    {
        HashSet<string> tempDict = new HashSet<string>();
        foreach (var VARIABLE in dictList)
        {
            if (codelengthToInclude.Contains(VARIABLE.Item1.Length))
            {
                tempDict.UnionWith(VARIABLE.Item2);
            }
        }
        return tempDict;
    }


    public static List<string> generatedTupleJundaAboveNine(
        Dictionary<string, SchemeRecord> charToSchema, 
        Dictionary<string, HashSet<SchemeRecord>> codeToSchema)
    {
        List<Tuple<string, HashSet<string>>> result= new List<Tuple<string, HashSet<string>>>();
        List<Tuple<string, SchemeRecord>> codeToRec = new List<Tuple<string, SchemeRecord>>();
        
        foreach (var eachCodeRecordPair in codeToSchema)
        {
            foreach (var eachRecord in eachCodeRecordPair.Value)
            {
                codeToRec.Add(new Tuple<string, SchemeRecord>(eachCodeRecordPair.Key, eachRecord));
            }
        }

        List<Tuple<string, SchemeRecord>> sorted = createListOfStringReadyForPrint.sortListOfTuplesJunda(codeToRec);

        List<string> readyToGetNinth = createListOfStringReadyForPrint.generatePrintLineFromTuple(sorted);
        return readyToGetNinth;
    }
    
    public static List<string> generatedTupleTzaiAboveNine(
        Dictionary<string, SchemeRecord> charToSchema, 
        Dictionary<string, HashSet<SchemeRecord>> codeToSchema)
    {
        List<Tuple<string, HashSet<string>>> result= new List<Tuple<string, HashSet<string>>>();
        List<Tuple<string, SchemeRecord>> codeToRec = new List<Tuple<string, SchemeRecord>>();
        
        foreach (var eachCodeRecordPair in codeToSchema)
        {
            foreach (var eachRecord in eachCodeRecordPair.Value)
            {
                codeToRec.Add(new Tuple<string, SchemeRecord>(eachCodeRecordPair.Key, eachRecord));
            }
        }

        List<Tuple<string, SchemeRecord>> sorted = 
            createListOfStringReadyForPrint.sortListOfTuplesTzai(codeToRec);

        List<string> readyToGetNinth = 
            createListOfStringReadyForPrint.generatePrintLineFromTuple(sorted);
        return readyToGetNinth;
    }

    public static List<Tuple<string, HashSet<string>>> AllAbove9thMODIFIED(
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

        return result;
    }
    
    
    public static bool jundaAt10(List<SchemeRecord> listSch, long jundaFreq5001)
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
    
    
    public static bool tzaiAt10(List<SchemeRecord> listSch, long tzaiFreq5001)
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

    public static bool longlist(List<SchemeRecord> listSch)
    {
        bool longlist = listSch.Count > 9;

        return longlist;
    }

    
    public static List<List<string>> getSortingInconsistenciesJunda(
        List<string> jundareadytoprint, 
        Dictionary<string, SchemeRecord> charToSchemaDict)
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
    
    public static List<List<string>> getSortingInconsistenciesTzai(
        List<string> jundareadytoprint, 
        Dictionary<string, SchemeRecord> charToSchemaDict)
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


    
    public static List<SchemeRecord> AllAboveThe9Th(
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
    
    public static HashSet<string> getWithinFreq(
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

    public static HashSet<string> getHeisig(
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
}