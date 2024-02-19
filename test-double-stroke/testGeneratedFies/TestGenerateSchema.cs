using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using double_stroke.projectFolder.FileMaps.GenerateFilesController;

namespace test_double_stroke.testSchemeDict;

public class TestGenerateSchema : testSetup
{
    private static string testDirectory = TestContext.CurrentContext.TestDirectory;
    private string charToSchemaPath = Path.Combine(testDirectory,
        FilePaths.dotsAndSlash + FilePaths.charToSchemaPathStr);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
    private string codeToSchemaPath = Path.Combine(testDirectory,
        FilePaths.dotsAndSlash + FilePaths.codeToSchemaPathStr);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\codeToSchemaMap.txt");
    
    
    
    [Test]
    public void generateAndSaveSchemaMaps()
    {
        var isCharFoundExcep = foundExceptions.GetValueOrDefault("是");
        
        List<SchemeRecord> schemeRecList = generateTestSchemeDict.schemeFromDictionary(foundExceptions, junda, tzai);

        Dictionary<string, SchemeRecord> charToSchema = GenerateSchema.generateCharToSchema(schemeRecList);
        string charToSchemaJson = JsonSerializer.Serialize(charToSchema);

        var ischar = charToSchema.GetValueOrDefault("是");

        Dictionary<string,HashSet<SchemeRecord>> codeToSchemas = GenerateSchema.generateCodeToSchema(schemeRecList);
        string codeToSchemaJson = JsonSerializer.Serialize(codeToSchemas);
        
        //File.WriteAllText(charToSchemaPath, charToSchemaJson);
        //File.WriteAllText(codeToSchemaPath, codeToSchemaJson);
        
        Assert.IsTrue(schemeRecList.Count == charToSchema.Count);
        Assert.IsTrue(schemeRecList.Count == 28098);
        Assert.IsTrue(codeToSchemas.Count == 62875);
    }
    
    [Test]
    public void testReadSchemaMaps()
    {
        string charToSchemaJson = File.ReadAllText(charToSchemaPath);
        string codeToSchemaJson = File.ReadAllText(codeToSchemaPath);

        JsonSerializerOptions options = new JsonSerializerOptions();
        Dictionary<string, SchemeRecord> charToSchemaDict = 
            JsonSerializer.Deserialize<Dictionary<string, SchemeRecord>>(charToSchemaJson, options);
        
        Dictionary<string, HashSet<SchemeRecord>> codeToSchemaDich = 
            JsonSerializer.Deserialize<Dictionary<string, HashSet<SchemeRecord>>>(codeToSchemaJson, options);

        Assert.IsTrue(charToSchemaDict.Count == 28098);
        Assert.IsTrue(codeToSchemaDich.Count == 62875);
    }
}