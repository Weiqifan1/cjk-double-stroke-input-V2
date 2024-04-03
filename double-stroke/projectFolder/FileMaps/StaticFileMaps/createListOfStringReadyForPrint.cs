using System.Data;
using System.Runtime.CompilerServices;

namespace double_stroke.projectFolder.StaticFileMaps;

public static class createListOfStringReadyForPrint
{
    private static string separator = ((char)9).ToString(); //32 == space 9 == tab
    private static int maxCodeLength = 6;

    //change Hashset to list
    public static Dictionary<string, List<SchemeRecord>>
        replaceHashSetToList(bool simplified, Dictionary<string, HashSet<SchemeRecord>> codeToChars)
    {
        Dictionary<string, List<SchemeRecord>> result = new Dictionary<string, List<SchemeRecord>>();
        //create a function that sortThehashmapsIntoLists
        result = codeToChars.ToDictionary(pair => pair.Key, pair => hashsetSortedToAList(simplified, pair.Value));
        return result;
    }

    //split dictionary into list of dictionaries based on code length
    public static List<Dictionary<string, List<SchemeRecord>>>
        splicIntoCodeLengths(Dictionary<string, List<SchemeRecord>> codeToChars)
    {
        List<Dictionary<string, List<SchemeRecord>>> result = new List<Dictionary<string, List<SchemeRecord>>>();
        for (int i = 1; i <= maxCodeLength; i++)
        {
            Dictionary<string, List<SchemeRecord>> extracted = extractCodesOfLength(i, codeToChars);
            result.Add(extracted);
        }

        return result;
    }

    //get a list of list of tuples
    public static List<List<Tuple<string, List<SchemeRecord>>>>
        getNestedListFromListOfDicts(List<Dictionary<string, List<SchemeRecord>>> listOfDicts)
    {
        List<List<Tuple<string, List<SchemeRecord>>>> result = new List<List<Tuple<string, List<SchemeRecord>>>>();
        foreach (var VARIABLE in listOfDicts)
        {
            var eachCharLength = changeDictionaryIntoListOfTuples(VARIABLE);
            result.Add(eachCharLength);
        }
        return result;
    }

    //flatten the nested code into listOfTuples
    public static List<Tuple<string, SchemeRecord>>
        getSortedListOfTuples(List<List<Tuple<string, List<SchemeRecord>>>> nestedListOfTuples)
    {
        List<Tuple<string, SchemeRecord>> result = new List<Tuple<string, SchemeRecord>>();
        foreach (var listOfCodelength in nestedListOfTuples)
        {
            foreach (var codeToSchemas in listOfCodelength)
            {
                foreach (var listOfRecords in codeToSchemas.Item2)
                {
                    result.Add(new Tuple<string, SchemeRecord>(codeToSchemas.Item1, listOfRecords));
                }
            }
        }
        return result;
    }

    
    //list of tupples to list of strings
    public static List<string> listOfTuplesToStringsJuda(List<Tuple<string, SchemeRecord>> tuppleList)
    {
        GenerateFileMaps fileMaps = new GenerateFileMaps();
        var simpHeisig = fileMaps.generateHeisigSimpMap();
        var tradHeisig = fileMaps.generateHeisigTradMap();
        
        var sortetTuple = 
            tuppleList.OrderBy(tuple => tuple.Item1.Length)
            .ThenBy(tuple => tuple.Item1)
            //.ThenByDescending(tuple => simpHeisig.ContainsKey(tuple.Item2.character))
            //.ThenByDescending(tuple => tradHeisig.ContainsKey(tuple.Item2.character))
            .ThenByDescending(tuple => tuple.Item2.jundaNumber.HasValue)
            .ThenByDescending(tuple => tuple.Item2.jundaNumber)
            .ThenByDescending(tuple => tuple.Item2.tzaiNumber.HasValue)
            .ThenByDescending(tuple => tuple.Item2.tzaiNumber)
            .ThenBy(tuple => tuple.Item2.character, 
                StringComparer.Ordinal);

        List<string> result = new List<string>();
        foreach (var VARIABLE in sortetTuple)
        {
            string eachline = VARIABLE.Item2.character + separator + VARIABLE.Item1;
            result.Add(eachline);
        }
        return result;
    }
    
    

    //list of tupples to list of strings
    public static List<string> listOfTuplesToStringsTzai(List<Tuple<string, SchemeRecord>> tuppleList)
    {
        GenerateFileMaps fileMaps = new GenerateFileMaps();
        var simpHeisig = fileMaps.generateHeisigSimpMap();
        var tradHeisig = fileMaps.generateHeisigTradMap();
        
        var sortetTuple = 
            tuppleList.OrderBy(tuple => tuple.Item1.Length)
            .ThenBy(tuple => tuple.Item1)
            //.ThenByDescending(tuple => tradHeisig.ContainsKey(tuple.Item2.character))
            //.ThenByDescending(tuple => simpHeisig.ContainsKey(tuple.Item2.character))
            .ThenByDescending(tuple => tuple.Item2.tzaiNumber.HasValue)
            .ThenByDescending(tuple => tuple.Item2.tzaiNumber)
            .ThenByDescending(tuple => tuple.Item2.jundaNumber.HasValue)
            .ThenByDescending(tuple => tuple.Item2.jundaNumber)
            .ThenBy(tuple => tuple.Item2.character, 
                StringComparer.Ordinal);

        List<string> result = new List<string>();
        foreach (var VARIABLE in sortetTuple)
        {
            string eachline = VARIABLE.Item2.character + separator + VARIABLE.Item1;
            result.Add(eachline);
        }
        return result;
    }




/*
public static List<Tuple<string, SchemeRecord>>
    generateTuppleListFromDictionary(List<Tuple<string, List<SchemeRecord>>> rollOutEachSchemeList)
{
    List<Tuple<string, SchemeRecord>> result = new List<Tuple<string, SchemeRecord>>();
    foreach (Tuple<string, List<SchemeRecord>> codeCharPair in rollOutEachSchemeList)
    {
        string currentKey = codeCharPair.Item1;
        foreach (SchemeRecord schemerecord in codeCharPair.Item2)
        {
            Tuple<string, SchemeRecord> tuppleToadd = new Tuple<string, SchemeRecord>(currentKey, schemerecord);
            result.Add(tuppleToadd);
        }
    }
    return result;
}*/


    //##################### helper functions ########################
    
    private static List<SchemeRecord> hashsetSortedToAList(bool simplified, HashSet<SchemeRecord> hashsetOfChars)
    {
        List<SchemeRecord> result = new List<SchemeRecord>(hashsetOfChars);
        SchemeRecordComparator comparator = new SchemeRecordComparator(simplified);
        result.Sort(comparator);
        return result;
    }
    
    
    private static Dictionary<string, List<SchemeRecord>> 
        extractCodesOfLength(int i, Dictionary<string, List<SchemeRecord>> codeToChars)
    {
        Dictionary<string, List<SchemeRecord>> result = new Dictionary<string, List<SchemeRecord>>();
        foreach (var VARIABLE in codeToChars)
        {
            if (VARIABLE.Key.Length == i)
            {
                result.Add(VARIABLE.Key, VARIABLE.Value);
            }
        }
        return result;
    }

    private static List<Tuple<string, List<SchemeRecord>>>
        changeDictionaryIntoListOfTuples(Dictionary<string, List<SchemeRecord>> dict)
    {
        List<Tuple<string, List<SchemeRecord>>> list = dict
            .Select(item => new Tuple<string, List<SchemeRecord>>(item.Key, item.Value))
            .ToList();
        return list;
    }
    
    /*
    private static List<Tuple<string, List<SchemeRecord>>> dictToTupleList(Dictionary<string, List<SchemeRecord>> codeToChars)
    {
        List<Tuple<string, List<SchemeRecord>>> initial =
            codeToChars.Select(kvp =>
                new Tuple<string, List<SchemeRecord>>(kvp.Key, kvp.Value)).ToList();
        Comparison<Tuple<string, List<SchemeRecord>>> comparer = (x, y) =>
            string.Compare(x.Item1, y.Item1, StringComparison.Ordinal);
        initial.Sort(comparer);
        return initial;
    }*/
    
    
    /*
    private static List<Tuple<string, SchemeRecord>> sortTupleListByFrequency(bool simplified, List<Tuple<string, SchemeRecord>> result)
    {
        result.OrderBy(tuple => tuple.Item2, new SchemeRecordComparator(simplified));
        return result;
    }*/
    
    //split the dictionary into codelengths
    
    

    //list.Sort(new CustomComparer(myExtraVariable));
    
}