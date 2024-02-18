
using double_stroke.projectFolder.StaticFileMaps;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using test_double_stroke;

public class Tests : testSetup
{
    [Test]
    public void IdentifyMissingJundaAndTzaiCharacters()
    {
        GenerateFileMaps gen = new GenerateFileMaps();
        Console.WriteLine("test start");
        //var result1 = foundExceptions[new UnicodeCharacter("扳")];
        Console.WriteLine("next");


        Dictionary<string, FrequencyRecord> missingJunda = new Dictionary<string, FrequencyRecord>();
        Dictionary<string, FrequencyRecord> missingTzai = new Dictionary<string, FrequencyRecord>();
        
        foreach (var VARIABLE in junda.Keys)
        {
            if (!foundExceptions.ContainsKey(VARIABLE))
            {
                missingJunda.Add(VARIABLE, junda.GetValueOrDefault(VARIABLE));
            }
        }
        foreach (var VARIABLE in tzai.Keys)
        {
            if (!foundExceptions.ContainsKey(VARIABLE))
            {
                missingTzai.Add(VARIABLE, tzai.GetValueOrDefault(VARIABLE));
            }
        }
        
        //missing junda:
        //裏 3 秊  1
        
        //missing tzai:
        // 兀  119  嗀  11

        var result1 = foundExceptions.GetValueOrDefault("裏");
        var result2 = foundExceptions.GetValueOrDefault("秊");
        var result3 = foundExceptions.GetValueOrDefault("兀");
        var result4 = foundExceptions.GetValueOrDefault("嗀");
        
        Assert.AreEqual(missingJunda.Count, 0);
        Assert.AreEqual(missingTzai.Count, 0);

        Console.WriteLine("test end");
    }
    
}