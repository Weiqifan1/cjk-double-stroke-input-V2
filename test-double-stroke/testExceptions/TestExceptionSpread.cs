using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using double_stroke.projectFolder.FileMaps.GenerateFilesController;

namespace test_double_stroke.testExceptions;

public class TestExceptionSpread : testSetup
{
    private static string testDirectory = TestContext.CurrentContext.TestDirectory;
    private string charToSchemaPath = Path.Combine(testDirectory,
        FilePaths.dotsAndSlash + FilePaths.charToSchemaPathStr);
    private string codeToSchemaPath = Path.Combine(testDirectory,
        FilePaths.dotsAndSlash + FilePaths.codeToSchemaPathStr);
    
    [Test]
    public void testReadSchemaMaps()
    {
        string charToSchemaJson = File.ReadAllText(charToSchemaPath);
        //string codeToSchemaJson = File.ReadAllText(codeToSchemaPath);

        JsonSerializerOptions options = new JsonSerializerOptions();
        Dictionary<string, SchemeRecord> charToSchemaDict = 
            JsonSerializer.Deserialize<Dictionary<string, SchemeRecord>>(charToSchemaJson, options);
        
        //Dictionary<string, HashSet<SchemeRecord>> codeToSchemaDich = 
        //    JsonSerializer.Deserialize<Dictionary<string, HashSet<SchemeRecord>>>(codeToSchemaJson, options);

        Assert.IsTrue(charToSchemaDict.Count == 28098);
        //Assert.IsTrue(codeToSchemaDich.Count == 62878);

        var keys = jundaShortCodeKeyCounter(charToSchemaDict);

        Dictionary<char, long> fingers = CombineDictionaries(keys, characterMapping());
        
        Dictionary<char, long> rawKeyResult = keys
            .ToDictionary(
                x => x.Key, 
                x => x.Value / 1000000);

        Dictionary<char, long> fingerKeyResult = fingers
                    .ToDictionary(
                        x => x.Key, 
                        x => x.Value / 1000000);
        
        //calculate the distribution of shortcut elements
        Dictionary<char, long> shortcurRawCounterJunda = shortcutKeyCounterJunda(charToSchemaDict);
        Dictionary<char, long> shortcurRawCounterTzai = shortcutKeyCounterTzai(charToSchemaDict);
        string keyres = "";
    }

    
    //Test the number of times the hands switch, given that the left hand has to 
    //be used at the end for selection.
    [Test]
    public void testchangesBetweenLeftAndRightHand_Junda()
    {
        double shiftsStandard = shiftsBetweenLeftAndRight(new Dictionary<char, char>(), junda);
        Assert.IsTrue(((long) shiftsStandard) == 347214976);
        
        Dictionary<char, char> changesToTheStandard = new Dictionary<char, char>();
        changesToTheStandard['q'] = 'p';
        changesToTheStandard['w'] = 'o';
        changesToTheStandard['e'] = 'i';
        changesToTheStandard['r'] = 'u';
        changesToTheStandard['t'] = 'y';
        double shifts = shiftsBetweenLeftAndRight(changesToTheStandard, junda);
        string test = "";
        Assert.IsTrue(((long) shifts) == 348138957);
    }
    
    [Test]
    public void testchangesBetweenLeftAndRightHand_tzai()
    {
        double shiftsStandard = shiftsBetweenLeftAndRight(new Dictionary<char, char>(), tzai);
        Assert.IsTrue(((long) shiftsStandard) == 326362176);
        
        Dictionary<char, char> changesToTheStandard = new Dictionary<char, char>();
        changesToTheStandard['q'] = 'p';
        changesToTheStandard['w'] = 'o';
        changesToTheStandard['e'] = 'i';
        changesToTheStandard['r'] = 'u';
        changesToTheStandard['t'] = 'y';
        double shifts = shiftsBetweenLeftAndRight(changesToTheStandard, tzai);
        string test = "";
        Assert.IsTrue(((long) shifts) == 327513059);
    }
    
    private double shiftsBetweenLeftAndRight(
        Dictionary<char, char> changesToTheStandard, 
        Dictionary<string, FrequencyRecord> frequencyRecords)
    {
        double changes = 0;
        foreach (var VARIABLE in frequencyRecords)
        {
            HashSet<string> codes = charToSchema.GetValueOrDefault(VARIABLE.Key).code4;
            double currentDouble = 0;
            foreach (var eachcode in codes)
            {
                int changesCount = countChanges(eachcode, changesToTheStandard);
                currentDouble = currentDouble + ((double)changesCount / (double)codes.Count);
            }
            changes = changes + (currentDouble * VARIABLE.Value.frequency);
        }
        return changes;
    }

    private int countChanges(string eachcode, Dictionary<char, char> changesToTheStandard)
    {
        List<char> charsRaw = eachcode.ToList();
        List<char> charsResult = new List<char>();
        foreach (var VARIABLE in charsRaw)
        {
            if (changesToTheStandard.ContainsKey(VARIABLE))
            {
                var newKey = changesToTheStandard.GetValueOrDefault(VARIABLE);
                charsResult.Add(newKey);
            }
            else
            {
                charsResult.Add(VARIABLE);
            }
        }

        var result = calculateChanges(charsResult);
        return result;
    }

    private int calculateChanges(List<char> charsResult)
    {
        int result = 0;
        List<Tuple<char, char>> pairs = PairChars(charsResult);
        foreach (var VARIABLE in pairs)
        {
            if (leftHand().Contains(VARIABLE.Item1) && righttHand().Contains(VARIABLE.Item2))
            {
                result++;
            }
            else if (righttHand().Contains(VARIABLE.Item1) && leftHand().Contains(VARIABLE.Item2))
            {
                result++;
            } 
        }
        return result;
    }

    private static HashSet<char> leftHand()
    {
        return new HashSet<char>
        {
            'q', 'w', 'e', 'r', 't', 'a', 's', 'd', 'f',
            'g', 'z', 'x', 'c', 'v', 'b'
        };
    }
    
    
    private static HashSet<char> righttHand()
    {
        return new HashSet<char>
        {
            'y', 'u', 'i', 'o', 'p', 'h', 'j', 'k', 'l',
            'n', 'm'
        };
    }


    private List<Tuple<char, char>> PairChars(List<char> charList)
    {
        List<Tuple<char, char>> result = new List<Tuple<char, char>>();

        for (int i = 0; i < charList.Count; i++)
        {
            char nextChar = (i != charList.Count - 1) ? charList[i + 1] : 'q';
            result.Add(new Tuple<char, char>(charList[i], nextChar));
        }

        return result;
    }

    private Dictionary<char, long> shortcutKeyCounterJunda(Dictionary<string, SchemeRecord> charToSchemaDict)
    {
        Dictionary<char, long> result = new Dictionary<char, long>(); 
        foreach (var eachCharPair in charToSchemaDict)
        {
            //get only pairs with shortcurKeys
            char excLet = eachCharPair.Value.exceptionLetter == null ? (char)1  : eachCharPair.Value.exceptionLetter.ToCharArray()[0];
            if (excLet != (char)1)
            {
                long oldNumber = result.ContainsKey(excLet) ? result[excLet] : 0;
                long jundaNumsFixed = eachCharPair.Value.jundaNumber ?? 0;
                if (excLet == 't' && jundaNumsFixed != 0)
                {
                    string test = "";
                }

                long newNumber = oldNumber + jundaNumsFixed;
                result[excLet] = newNumber; // using the indexer to add or update key-value pairs
            }
        }
        return result;
    }
    
    private Dictionary<char, long> shortcutKeyCounterTzai(Dictionary<string, SchemeRecord> charToSchemaDict)
    {
        Dictionary<char, long> result = new Dictionary<char, long>(); 
        foreach (var eachCharPair in charToSchemaDict)
        {
            //get only pairs with shortcurKeys
            char excLet = eachCharPair.Value.exceptionLetter == null ? (char)1  : eachCharPair.Value.exceptionLetter.ToCharArray()[0];
            if (excLet != (char)1)
            {
                long oldNumber = result.ContainsKey(excLet) ? result[excLet] : 0;
                long jundaNumsFixed = eachCharPair.Value.tzaiNumber ?? 0;
                long newNumber = oldNumber + jundaNumsFixed;
                result[excLet] = newNumber; // using the indexer to add or update key-value pairs
            }
        }
        return result;
    }
    
    private Dictionary<char, long> CombineDictionaries(
        Dictionary<char, long> dictA, 
        Dictionary<char, HashSet<char>> dictB)
    {
        var resultDictionary = new Dictionary<char, long>();
    
        foreach (var pair in dictB)
        {
            long sum = 0;
            foreach (var ch in pair.Value)
            {
                if (dictA.ContainsKey(ch))
                    sum += dictA[ch];
            }
            resultDictionary[pair.Key] = sum;
        }

        return resultDictionary;
    }

    private Dictionary<char, HashSet<char>> characterMapping()
    {
        Dictionary<char, HashSet<char>> myDictionary = new Dictionary<char, HashSet<char>>
        {
            {'a', new HashSet<char> {'q', 'a', 'z'}},
            {'s', new HashSet<char> {'w', 's', 'x'}},
            {'d', new HashSet<char> {'e', 'd', 'c'}},
            {'f', new HashSet<char> {'r', 'f', 'v'}},
            {'g', new HashSet<char> {'t', 'g', 'b'}},
            {'h', new HashSet<char> {'y', 'h', 'n'}},
            {'j', new HashSet<char> {'u', 'j', 'm'}},
            {'k', new HashSet<char> {'i', 'k'}},
            {'l', new HashSet<char> {'o', 'l'}},
            {';', new HashSet<char> {'p'}},
            
        };
        return myDictionary;
    }

    private Dictionary<char, long> jundaShortCodeKeyCounter(Dictionary<string, SchemeRecord> charToSchemaDict)
    {
        Dictionary<char, long> result = new Dictionary<char, long>(); 
        foreach (var eachCharPair in charToSchemaDict)
        {
            int numberOf4Codes = eachCharPair.Value.code4.Count > 1 ? eachCharPair.Value.code4.Count : 1;
            List<char> charList = new List<char>(eachCharPair.Value.code4
                     .SelectMany(s => s.ToCharArray()));
            foreach (var shortCodeChar in charList)
            {
                long oldNumber = result.ContainsKey(shortCodeChar) ? result[shortCodeChar] : 0;
                long jundaNumsFixed = eachCharPair.Value.jundaNumber ?? 0;
                long newNumber = oldNumber + (jundaNumsFixed / numberOf4Codes);
                result[shortCodeChar] = newNumber; // using the indexer to add or update key-value pairs
            }
            
        }
        return result;
    }

}