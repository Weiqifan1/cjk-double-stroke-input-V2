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
        

        
        string keyres = "";
    }

    
    public Dictionary<char, long> CombineDictionaries(
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