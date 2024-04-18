using System.Text;
using double_stroke.projectFolder.FileMaps;
using double_stroke.projectFolder.StaticFileMaps;
using Microsoft.VisualBasic;

namespace double_stroke.projectFolder.StaticFileMaps;


using System.Data;
using System;
using System.Collections.Generic;
using System.IO;


public class GenerateFileMaps
{
    
    private CodeExceptions exp = new CodeExceptions();
    private GenerateIds genIds = new GenerateIds();
    private Dictionary<string, string> priviledgedExceptions = CodeExceptions.getPriviledgedExceptionCharacters();
    
    public void Run()
    {
        Console.WriteLine("Run - GenerateFileMaps.");
        //var heisigTradPath = "../../../projectFolder/StaticFiles/heisigTrad.txt";
        //var heisigTradLines = removeIntroductionLines(heisigTradPath, 3);
       
        //var jundaMap = generateJundaMap();
        //var tzaiMap = generateTzaiMap();
        var idsPath = "../../../projectFolder/StaticFiles/ids.txt";
        const string codepointPath = "../../../projectFolder/StaticFiles/codepoint-character-sequence.txt";

        var codeExceptionsFromCharacter = exp.generateCodeExceptionsFromCharacter();
        Dictionary<string, IdsBasicRecord> idsMap = genIds.generateIdsMap(idsPath, priviledgedExceptions);
        var codepointMap = generateCodepointMap(
            codeExceptionsFromCharacter, idsMap, codepointPath);
        var codeExceptionsFromCodepoint = exp.generateCodeExceptionsFromCodepoint();
        Dictionary<string, CodepointWithExceptionRecord> foundExceptions = 
            generateFoundEsceptionsMap(codepointMap, codeExceptionsFromCharacter, codeExceptionsFromCodepoint, idsMap);
        
        //
        //扌目趴  虫木竺
        
        var test = "";
    }
    
    
    
    public Dictionary<string, List<string>> GenerateUniDictionary(IEnumerable<string> codepointLines)
    {
        //add the missing codepointLines
        //missing junda:
        //裏 3 秊  1
        //missing tzai:
        // 兀  119  嗀  11
        List<string> missingChars = new List<string>();
        string one1 = "U+F9E7\t裏\t4125111213534";// + Environment.NewLine;
        string two2 = "U+F995\t秊\t31234312"; //+ Environment.NewLine;
        string three3 = "U+FA0C\t兀\t135"; //+ Environment.NewLine;
        string four4 = "U+FA0D\t嗀\t1214512513554";// + Environment.NewLine;
                     
        missingChars.Add(one1);
        missingChars.Add(two2);
        missingChars.Add(three3);
        missingChars.Add(four4);
        
        Dictionary<string, List<string>> uniDict = new Dictionary<string, List<string>>();
        foreach (string input in codepointLines)
        {
            addToUniDict(input, uniDict);
        }

        foreach (var VARIABLE in missingChars)
        {
            addToUniDict(VARIABLE, uniDict);
        }
        
        return uniDict;
    }

    
    private void addToUniDict(string input, Dictionary<string, List<string>> uniDict)
    {
        if (!input.StartsWith("U+")) return;
        string[] splitstr = 
            input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        if (splitstr[1].Equals("鰠^"))
        {
            string test = "";
        }

        var character = UtilityFunctions.firstUnicodeCharacter(splitstr[1]);
        if (!uniDict.ContainsKey(character.Value)) 
        {
            uniDict[character.Value] = new List<string>();
        }
        uniDict[character.Value].Add(splitstr[2]);
    }

    
    public Dictionary<string, CodepointWithExceptionRecord> generateFoundEsceptionsMap(
        Dictionary<string, CodepointBasicRecord> codepointMap, 
        Dictionary<string, CodepointExceptionRecord> codeExceptionsFromids,
        Dictionary<string, CodepointExceptionRecord> codeExceptionsFromCodepoint,
        Dictionary<string, IdsBasicRecord> idsMap)
    {
        Dictionary<string, CodepointWithExceptionRecord> result =
            new Dictionary<string, CodepointWithExceptionRecord>();

        //main debugpoint
        
        
        int numberofmissing = 0;
        foreach (KeyValuePair<string, CodepointBasicRecord> item in codepointMap)
        {
            if (item.Key.Equals("訁"))
            {
                
                string test = "";
            }

            string key = item.Key;
            CodepointBasicRecord value = item.Value;

            CodepointWithExceptionRecord newitem = generateCodepointWithExceptionRecord(
                numberofmissing, 
                key, 
                value, 
                codeExceptionsFromids, 
                codeExceptionsFromCodepoint, 
                idsMap);
            result.Add(key, newitem);
        }
        Console.WriteLine(numberofmissing);

        var isChar = result.GetValueOrDefault("訁");

        return result;
    }

    private CodepointWithExceptionRecord generateCodepointWithExceptionRecord(
        int numberofmissing,
        string key, 
        CodepointBasicRecord value, 
        Dictionary<string, CodepointExceptionRecord> codeExceptionsIds,
        Dictionary<string, CodepointExceptionRecord> codeExceptionsFromCodepoint,
        Dictionary<string, IdsBasicRecord> idsMap)
    {
        var localtestvalue = key;
        //CodepointWithExceptionRecord? record = null;
        var newUnicode = new UnicodeCharacter("訁");//new UnicodeCharacter("劧");
        var mybool1 = localtestvalue.Equals(newUnicode.Value);
        if (mybool1)
        {
            var mybool2 = localtestvalue.Equals(newUnicode);
            string test = "";
        }

        IdsBasicRecord? idsLookup = idsMap.GetValueOrDefault(key);
        CodepointExceptionRecord? exceptionMatchByIds = 
            getExceptionMatchByIdsElement(numberofmissing, key, value, idsLookup, codeExceptionsIds);
        CodepointExceptionRecord? exceptionMatchByCodepoint = 
            getExceptionMatchByCodepoint(
                numberofmissing, new UnicodeCharacter(key),
                value, idsLookup, codeExceptionsFromCodepoint);
        string codepointAfterExp = getCodepointAfterExp(value, exceptionMatchByCodepoint, exceptionMatchByIds, idsLookup);
        CodepointWithExceptionRecord record = new CodepointWithExceptionRecord(
            exceptionMatchByIds,
            exceptionMatchByCodepoint,
            value,
            codepointAfterExp,
            new UnicodeCharacter(key),
            idsLookup);
        return record;
    }

    private string getCodepointAfterExp(
        CodepointBasicRecord value, 
        CodepointExceptionRecord? exceptionsByCodepoint, 
        CodepointExceptionRecord? exceptionMatchByIds, 
        IdsBasicRecord? idsLookup)
    {
        HashSet<string> allvalues = new HashSet<string>();
        int longestNum = 0;
        if (exceptionsByCodepoint != null)
        {
            foreach (var VARIABLE in exceptionsByCodepoint.rawCodepoint)
            {
                if (value.rawCodepoint.StartsWith(VARIABLE) && 
                    idsLookup != null &&
                    exceptionsByCodepoint.allAcceptableElems.Contains(idsLookup.rolledOutIdsWithNoShape[0]) &&
                    VARIABLE.Length > longestNum)
                {
                    longestNum = VARIABLE.Length;
                }
            }
        }
        string result = value.rawCodepoint.Substring(longestNum);
        return result;
    }

    private string getCodevalueMinusException(
        UnicodeCharacter key, 
        CodepointBasicRecord value, 
        CodepointExceptionRecord exceptionMatch)
    {
        bool noMatch = true;
        string remainder = null;
        foreach (var VARIABLE in exceptionMatch.rawCodepoint)
        {
            if (value.rawCodepoint.StartsWith(VARIABLE))
            {
                noMatch = false;
                remainder = value.rawCodepoint.Substring(VARIABLE.Length);
                return remainder;
            }
        }
        if (noMatch || remainder == null)
        {
            throw new FormatException("The found exception doesnt match the original full codepoint for character: " +
                                      key.Value + " val: " + value.rawCodepoint + " exception: " + exceptionMatch.character);
        }
        return remainder;
    }

    private CodepointExceptionRecord? getExceptionMatchByCodepoint(
        int numberofmissing, 
        UnicodeCharacter key, 
        CodepointBasicRecord value, 
        IdsBasicRecord? idsLookup, 
        Dictionary<string, CodepointExceptionRecord> codeExceptionsFromCodepoint)
    {
        CodepointExceptionRecord? result = null;
        foreach (var VARIABLE in codeExceptionsFromCodepoint)
        {
            if (value.rawCodepoint.StartsWith(VARIABLE.Key))
            {
                result = codeExceptionsFromCodepoint.GetValueOrDefault(VARIABLE.Key);
                return result;
            }
        }
        return result;
    }
    
    private CodepointExceptionRecord? getExceptionMatchByIdsElement(
        int numberofmissing, 
        string key, 
        CodepointBasicRecord value, 
        IdsBasicRecord? idsLookup, 
        Dictionary<string, CodepointExceptionRecord> codeExceptions)
    {
        if (idsLookup.Equals(null)  && numberofmissing < 10) 
        {
            throw new FormatException("key is not in ids: " + key + " val: " + value);
        }
        else if (idsLookup != null)
        {
            var joinedExceptions = String.Join("", idsLookup.rolledOutIdsWithNoShape);
            foreach (var VARIABLE in codeExceptions)
            {
                if (VARIABLE.Value.allAcceptableElems.Any(prefix => joinedExceptions.StartsWith(prefix)))
                {
                    return VARIABLE.Value;
                }
            }
            //var firstIdsMatch = idsLookup.rolledOutIdsWithNoShape[0];//𠂊亅𠂊亅
            //var exceptionMatch = codeExceptions.GetValueOrDefault(firstIdsMatch);
            //return exceptionMatch;
        }
        return null;
    }

    
    
    /*
    public Dictionary<string, IdsBasicRecord> generateIdsMap()
    {
        var idsPath = "../../../projectFolder/StaticFiles/ids.txt";
        var idsLines = removeIntroductionLines(idsPath, 2);
        UtilityFunctions util = new UtilityFunctions();
        Dictionary<string, IdsBasicRecord> result = 
            new Dictionary<string, IdsBasicRecord>();
        Dictionary<string, List<UnicodeCharacter>> tempDictionary = 
            new Dictionary<string, List<UnicodeCharacter>>();
        var charsToRemove = irrelevantShapeAndLatinCharacters();
        //List<UnicodeCharacter> rolledOutIds(character, )
        //IdsBasicRecord record = new IdsBasicRecord(input, );
        foreach (string input in idsLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = util.firstUnicodeCharacter(splitstr[1]);
            List<UnicodeCharacter> strSplitIds = util.CreateUnicodeCharacters(splitstr[2]);
            tempDictionary.Add(character, strSplitIds);
        }
        
        foreach (string input in idsLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = util.firstUnicodeCharacter(splitstr[1]);
            List<UnicodeCharacter> rolldOutids = generateRolledOutids(character, tempDictionary);
            var rolledOutWithNoShape = removeUnvantedCharacters(rolldOutids, charsToRemove);
            IdsBasicRecord basic = new IdsBasicRecord(input, rolldOutids, rolledOutWithNoShape);
            result.Add(character, basic);
        }
        return result;
    }
*/
    
    
    public Dictionary<string, CodepointBasicRecord> generateCodepointMap(
        Dictionary<string, CodepointExceptionRecord> codeExceptions,
        Dictionary<string, IdsBasicRecord> idsMap,
        string codepointPath)
    {
        const int introLinesCount = 87;
        var codepointLines = UtilityFunctions.removeIntroductionLines(codepointPath, introLinesCount);
        var uniDict = GenerateUniDictionary(codepointLines);
        //var test = uniDict.GetValueOrDefault("鰠");
        var result = GenerateFinalUnicodeMap(uniDict, codeExceptions, idsMap);
        return result;
    }

    private Dictionary<string, CodepointBasicRecord> GenerateFinalUnicodeMap(
        Dictionary<string, List<string>> uniDict, 
        Dictionary<string, CodepointExceptionRecord> codeExceptions, 
        Dictionary<string, IdsBasicRecord> idsMap)
    {
        var finalUnicodeMap = new Dictionary<string, CodepointBasicRecord>();
        foreach (var entry in uniDict)
        {
            if (entry.Key.Equals("鰠"))
            {
                string test = "";
            }

            var character = new UnicodeCharacter(entry.Key);
            CodepointBasicRecord prelimEntry = generateCodepointRecord(entry, codeExceptions, idsMap);
            finalUnicodeMap[character.Value] = prelimEntry; 
        }
        return finalUnicodeMap;
    }

    private CodepointBasicRecord generateCodepointRecord(
        KeyValuePair<string, List<string>> entry, 
        Dictionary<string, CodepointExceptionRecord> codeExceptions, 
        Dictionary<string, IdsBasicRecord> idsMap)
    {
        if (entry.Value.Count != 1)
        {
            throw new FormatException("CodepointBasicRecord is given badly formatted: " + entry);
        }

        string firstItemInEntry = entry.Value[0];
        CodepointBasicRecord result = new CodepointBasicRecord(firstItemInEntry);

        string test = "";
        return result;
    }

    /*
    public Dictionary<string, CodepointBasicRecord> generateCodepointMap()
    {
        var codepointPath = "../../../projectFolder/StaticFiles/codepoint-character-sequence.txt";
        var codepointLines = removeIntroductionLines(codepointPath, 87);
        //var dictionary = new Dictionary<string, CodepointBasicRecord>();
        UtilityFunctions util = new UtilityFunctions();
        Dictionary<string, List<string>> uniDict = new Dictionary<string, List<string>>();
        
        foreach (string input in codepointLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if (input.StartsWith("U+"))
            {
                var character = util.firstUnicodeCharacter(splitstr[1]);

                if (uniDict.ContainsKey(character.Value))
                {
                    List<string> currentVals = uniDict[character.Value];
                    currentVals.Add(splitstr[2]);
                    uniDict.Add(character.Value, currentVals);
                }
                uniDict.Add(character.Value, [splitstr[2]]);
            } else
            {
                string test = "";
            }
        }

        Dictionary<string, CodepointBasicRecord> finalUnicodeMap =
            new Dictionary<string, CodepointBasicRecord>();
        foreach (var entry in uniDict)
        {
            var character = new UnicodeCharacter(entry.Key, entry.Value[0]);
            var entVal = entry.Value;
            if (entVal.Count > 1)
            {
                throw new NotImplementedException(); 
            }
            else
            {
                var codepointRecord = new CodepointBasicRecord(entry.Value[0]);
                finalUnicodeMap.Add(character, codepointRecord);
            }

            //var codepointRecord = new CodepointBasicRecord(entry.Value);
            //finalUnicodeMap.Add(character, codepointRecord);
        }
        return finalUnicodeMap;
    }
*/
    public Dictionary<string, AlternativeCharsetRecord> generateHeisigTradMap()
    {
        var heisigTradPath =  "../../../double-stroke/projectFolder/StaticFiles/heisigTrad.txt";
        var heisigTrad = 
            generateHeisigMap(WritingSystemEnum.HeisigTraditional, heisigTradPath);
        return heisigTrad;
    }
    
    public Dictionary<string, AlternativeCharsetRecord> generateHeisigSimpMap()
    {
        var heisigSimpPath = "../../../double-stroke/projectFolder/StaticFiles/heisigSimp.txt";
        var heisigSimp = 
            generateHeisigMap(WritingSystemEnum.HeisigSimplified, heisigSimpPath);
        return heisigSimp;
    }
    
    public Dictionary<string, AlternativeCharsetRecord> generateHongkongCharMap()
    {
        var heisigSimpPath = "../../../projectFolder/StaticFiles/wikiHkscs2016.txt";
        Dictionary<string, AlternativeCharsetRecord> heisigSimp = 
            generateHongkongMap(WritingSystemEnum.Hongkong, heisigSimpPath);
        return heisigSimp;
    }
    
    public Dictionary<string, AlternativeCharsetRecord> generateGukjaHanjaCharMap()
    {
        var heisigSimpPath = "../../../projectFolder/StaticFiles/wikiHkscs2016.txt";
        Dictionary<string, AlternativeCharsetRecord> heisigSimp = 
            generateGukjaMap(WritingSystemEnum.Gukja, heisigSimpPath);
        return heisigSimp;
    }
    
    public Dictionary<string, AlternativeCharsetRecord> generateJISX0208CharMap()
    {
        var heisigSimpPath = "../../../projectFolder/StaticFiles/wikiJISX0208.txt";
        Dictionary<string, AlternativeCharsetRecord> heisigSimp = 
            generateJISX0208Map(WritingSystemEnum.JISX0208, heisigSimpPath);
        return heisigSimp;
    }
    
    public Dictionary<string, AlternativeCharsetRecord> generateJoyoCharMap()
    {
        var heisigSimpPath = "../../../projectFolder/StaticFiles/wikiJoyoKanji.txt";
        Dictionary<string, AlternativeCharsetRecord> heisigSimp = 
            generateJoyoMap(WritingSystemEnum.Joyo, heisigSimpPath);
        return heisigSimp;
    }

    private Dictionary<string, AlternativeCharsetRecord> generateJoyoMap(WritingSystemEnum myenum, string mypath)
    {
        Dictionary<string, AlternativeCharsetRecord> charMapFromUnsortedData = 
            generateCharMapFromUnsorted(myenum, mypath);
        return charMapFromUnsortedData;
    }

    private Dictionary<string, AlternativeCharsetRecord> generateJISX0208Map(WritingSystemEnum myenum, string mypath)
    {
        Dictionary<string, AlternativeCharsetRecord> charMapFromUnsortedData = 
            generateCharMapFromUnsorted(myenum, mypath);
        return charMapFromUnsortedData;
    }

    private Dictionary<string, AlternativeCharsetRecord> generateGukjaMap(WritingSystemEnum myenum, string mypath)
    {
        Dictionary<string, AlternativeCharsetRecord> charMapFromUnsortedData = 
            generateCharMapFromUnsorted(myenum, mypath);
        return charMapFromUnsortedData;
    }

    private Dictionary<string, AlternativeCharsetRecord> generateHongkongMap(WritingSystemEnum myenum, string mypath)
    {
        Dictionary<string, AlternativeCharsetRecord> charMapFromUnsortedData = 
            generateCharMapFromUnsorted(myenum, mypath);
        return charMapFromUnsortedData;
    }

    private Dictionary<string, AlternativeCharsetRecord> generateCharMapFromUnsorted(WritingSystemEnum myenum, string mypath)
    {
        throw new NotImplementedException();
    }
    
    public Dictionary<string, FrequencyRecord> generateTzaiMap(string tzaiPath)
    {
        //var tzaiPath = "../../../projectFolder/StaticFiles/Tzai2006.txt";
        var tzaiLines = UtilityFunctions.ReadLinesFromFile(tzaiPath);
        return tzaiMapFromLines(tzaiLines);
    }

    private Dictionary<string, FrequencyRecord> tzaiMapFromLines(List<string> tzaiLines)
    {
        var allOccurrences = CalculateSumTzai(tzaiLines);
        var dictionary = new Dictionary<string, FrequencyRecord>();

        foreach (string input in tzaiLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var character = splitstr[0];
            var freqRecord = new FrequencyRecord(
                WritingSystemEnum.HeisigTraditional,
                long.Parse(splitstr[1]),
                allOccurrences
            );
            dictionary.Add(character, freqRecord);
        }
        return dictionary;
    }

    public List<List<string>> generateForeignInputSystemDict(string foreignPath)
    {
        var foreignList = UtilityFunctions.ReadLinesFromFile(foreignPath);
        return foreignNestedList(foreignList);
    }

    private List<List<string>> foreignNestedList(List<string> foreignList)
    {
        return new List<List<string>>();
    }

    public Dictionary<string, FrequencyRecord> generateJundaMap(string jundaPath)
    {
        //var jundaPath = "../../../projectFolder/StaticFiles/Junda2005.txt";
        var jundaLines = UtilityFunctions.ReadLinesFromFile(jundaPath);
        return jundaMapFromLines(jundaLines);
    }

    private Dictionary<string, FrequencyRecord> jundaMapFromLines(List<string> jundaLines)
    {
        var allOccurrences = CalculateSumJunda(jundaLines);
        var dictionary = new Dictionary<string, FrequencyRecord>();

        foreach (string input in jundaLines)
        {
            string[] splitstr = input.Split('\t');
            var character = new UnicodeCharacter(splitstr[1]);
            var freqRecord = new FrequencyRecord(
                WritingSystemEnum.HeisigSimplified,
                long.Parse(splitstr[2]),
                allOccurrences
            );
            dictionary.Add(character.Value, freqRecord);
        }
        return dictionary;
    }

    private long CalculateSumTzai(List<string> inputs)
    {
        long sum = 0;
        foreach(var input in inputs)
        {
            var elements = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if(elements.Length > 2 && int.TryParse(elements[1], out var number)) 
            {
                sum += number;
            }
        }
        return sum;
    }
    
    private long CalculateSumJunda(List<string> inputs)
    {
        long sum = 0;
        foreach(var input in inputs)
        {
            var elements = input.Split('\t');
            if(elements.Length > 2 && int.TryParse(elements[2], out var number)) 
            {
                sum += number;
            }
        }
        return sum;
    }
    
    private Dictionary<string, AlternativeCharsetRecord> generateHeisigMap(WritingSystemEnum system, string path)
    {
        var heisigSimpLines = UtilityFunctions.removeIntroductionLines(path, 3);

        var dictionary = new Dictionary<string, AlternativeCharsetRecord>();
        int linenumber = 0;

        foreach (string input in heisigSimpLines)
        {
            linenumber += 1;
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var character = new UnicodeCharacter(splitstr[1]);
            var freqRecord = new AlternativeCharsetRecord(
                system,
                stringToInd(splitstr[0], splitstr, linenumber)
            );
            System.Console.WriteLine(linenumber + " " + splitstr[0]);
            if (!dictionary.ContainsKey(character.Value))
            {
               dictionary.Add(character.Value, freqRecord);
            }

        }
        return dictionary;
    }
    
    int stringToInd(string s, string[] splitStrInput, int linenumber)
    {
        int result = 0;
        try
        {
            result = int.Parse(s);
        }
        catch (Exception ex)
        {
            result = linenumber;
        }
        return result;
    }


    public  Dictionary<string, FrequencyRecord> extractFirst5001Junda(string jundaPath)
    {
        var jundaLines = UtilityFunctions.ReadLinesFromFile(jundaPath);
        Dictionary<string, FrequencyRecord> result = new Dictionary<string, FrequencyRecord>();
        var junda5001Lines = jundaLines.Take(5001).ToList();
        result = jundaMapFromLines(junda5001Lines);
        return result;
    }

    public Dictionary<string, FrequencyRecord> extractFirst5001Tzai(string tzaiPath)
    {
        var tzaiLines = UtilityFunctions.ReadLinesFromFile(tzaiPath);
        Dictionary<string, FrequencyRecord> result = new Dictionary<string, FrequencyRecord>();
        var tzai5001Liens = tzaiLines.Take(5001).ToList();
        result = tzaiMapFromLines(tzai5001Liens);
        return result;
    }
}