using double_stroke.projectFolder.FileMaps;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

//using Newtonsoft.Json;

namespace double_stroke.projectFolder.StaticFileMaps;

public class GenerateIds
{

    private Dictionary<string, string> priviledgedExceptions = CodeExceptions.getPriviledgedExceptionCharacters();

    public void generateAndSaveIdsMap(string idsPath, string newPathForSaveFile)
    {
        Dictionary<string, IdsBasicRecord> idsMap = generateIdsMap(idsPath, priviledgedExceptions);
        string json = JsonSerializer.Serialize(idsMap);
        File.WriteAllText(newPathForSaveFile, json);

        var bamboo = idsMap.GetValueOrDefault("竹");

        var tre2 = idsMap.GetValueOrDefault("是");
        
        string test = "";
        /*
        result.Add("𧾷");
        result.Add("足");
        result.Add("竹");
        result.Add("⺮");*/
    }

    public Dictionary<string, IdsBasicRecord> readIdsMap(string idsPath)
    {
        
        string jsonFromFile = File.ReadAllText(idsPath);

        JsonSerializerOptions options = new JsonSerializerOptions();
        Dictionary<string, IdsBasicRecord> resultDictionary = 
            JsonSerializer.Deserialize<Dictionary<string, IdsBasicRecord>>(jsonFromFile, options);
        return resultDictionary;
    }

    public Dictionary<string, IdsBasicRecord> generateIdsMap(
        string idsPath, Dictionary<string, string> priviledgedElemn)
    {
        //IdsBasicRecord(
        //string rawIds,
        //    List<UnicodeCharacter> rolledOutIds,
        //List<UnicodeCharacter> rolledOutIdsWithNoShape
        var latin = latinCharcters();
        var allUnwanted = irrelevantShapeAndLatinCharacters();
        Dictionary<string, List<UnicodeCharacter>> genRawIds = 
            generateRawIdsMap(idsPath, priviledgedElemn);
        var endResult = new Dictionary<string, IdsBasicRecord>();
        foreach (var item in genRawIds)
        {
            if (item.Key.Equals("是")) //"朩"))//"𢺓")) 签
            {
                var testRes = "";
            }

            List<UnicodeCharacter> rollOut = getRecursiveRawId(
                new UnicodeCharacter(item.Key), genRawIds, latin);
            List<UnicodeCharacter> rollOutNoUnwanted = rollOut.Where(n => !allUnwanted.Contains(n)).ToList();
            List<string> rawitems = genRawIds.GetValueOrDefault(item.Key).Select(uc => uc.Value).ToList();
            /*
            if (priviledgedElemn.Contains(item.Key))
            {
                rollOut = new List<UnicodeCharacter> { new UnicodeCharacter(item.Key)};
                rollOutNoUnwanted = new List<UnicodeCharacter> { new UnicodeCharacter(item.Key)};
                rawitems = new List<string> { item.Key };
            }*/

            if (rollOutNoUnwanted.Count > 0)
            {
                IdsBasicRecord basicRec = new IdsBasicRecord(
                    rawitems,
                    rollOut.Select(uc => uc.Value).ToList(), 
                    rollOutNoUnwanted.Select(uc => uc.Value).ToList());
                endResult.Add(item.Key, basicRec);
            }
            //var rolledOutIds = generateRolledOutids(item.Key, tempDictionary);
            //var rolledOutIdsWithNoShape = UtilityFunctions.removeUnvantedCharacters(rolledOutIds, charsToRemove);
            //var idsBasicRecord = new IdsBasicRecord(item.Value.rawIds, rolledOutIds, rolledOutIdsWithNoShape);
            //endResult.Add(item.Key, idsBasicRecord);
        }
        return endResult;
        
    }
    
    private List<UnicodeCharacter> getRecursiveRawId(
        UnicodeCharacter character, 
        Dictionary<string, List<UnicodeCharacter>> rawIdsDict,
        List<UnicodeCharacter> unwanted)
    {
        List<UnicodeCharacter> resultSet = new List<UnicodeCharacter>();
        if (character.Value.Equals("𥺛") )//"𢺓" //|| character.Value.Equals()
        {
            var test = "";
        }
        if (!rawIdsDict.TryGetValue(character.Value, out List<UnicodeCharacter> listValues))
            return resultSet; //character not in dictionary
        foreach (var item in listValues)
        {
            if (!unwanted.Contains(item)) //ignore self-references
            {
                if (!rawIdsDict.ContainsKey(item.Value) || item.Equals(character))
                {
                    resultSet.Add(item);
                }
                else
                {
                    resultSet.AddRange(getRecursiveRawId(item, rawIdsDict, unwanted));
                }
            }
            //resultSet.AddRange(getRecursiveRawId(item, rawIdsDict, unwanted));
        }
        if (character.Value.Equals("𥺛") )//"𢺓" //|| character.Value.Equals()
        {
            var test = "";
        }
        return resultSet;
    }

    /*
    if (character.Value.Equals("𢺓") ) //|| character.Value.Equals()
        {
            var test = "";
        }
     */

    private Dictionary<string, List<UnicodeCharacter>> generateRawIdsMap(
        string idsPath, Dictionary<string, string> priviledgedElemn)
    {
        var idsLines = UtilityFunctions.removeIntroductionLines(idsPath, 2);
        Dictionary<string, List<UnicodeCharacter>> tempDictionary = 
            new Dictionary<string, List<UnicodeCharacter>>();
        var charsToRemove = irrelevantShapeAndLatinCharacters();

        foreach (string eachRawIdsLine in idsLines)
        {
            string[] splitstr = 
                eachRawIdsLine.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = UtilityFunctions.firstUnicodeCharacter(splitstr[1]);
            List<UnicodeCharacter> strSplitIds = UtilityFunctions.CreateUnicodeCharacters(splitstr[2]);

            if (character.Equals(new UnicodeCharacter("是")))//"朩")))
            {
                string testWeird = "";
            }

            if (priviledgedElemn.Keys.Contains(character.Value))
            {
                string priviledgeVal = priviledgedElemn.GetValueOrDefault(character.Value);
                tempDictionary.TryAdd(character.Value, new List<UnicodeCharacter>{new UnicodeCharacter(priviledgeVal)});
            }
            else
            {
                tempDictionary.TryAdd(character.Value, strSplitIds);
            }

        }
        return tempDictionary;
    }
    
    private List<UnicodeCharacter> irrelevantShapeAndLatinCharacters()
    {
        List<UnicodeCharacter> result = new List<UnicodeCharacter>();
        string ideographicDiscription = UtilityFunctions.ideographicCharacterRange();
        var ideographics = UtilityFunctions.CreateUnicodeCharacters(ideographicDiscription);
        var final = ideographics.Concat(latinCharcters()).ToList();
        return final;
    }

    private List<UnicodeCharacter> latinCharcters()
    {
        string asciiStr = UtilityFunctions.GetAllAsciiCharacters();
        var ascii = UtilityFunctions.CreateUnicodeCharacters(asciiStr);
        return ascii;
    }

}