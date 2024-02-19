using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using double_stroke.projectFolder.StaticFileMaps;

namespace test_double_stroke.testIds;

public class test_ids
{

    private Dictionary<string, string> priviledgedExceptions = CodeExceptions.getPriviledgedExceptionCharacters();
    
    [Test]
    public void generateAndSaveIdsMap()
    {
        //DONT DELETE!
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        string idsPath = Path.Combine(testDirectory, 
            @"..\..\..\" + FilePaths.idsPathStr);
            //@"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");
        string newPathForSaveFile = Path.Combine(testDirectory,
            @"..\..\..\" + FilePaths.newPathForSaveFileStr);
            //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\idsMap.txt");
        GenerateIds genIds = new GenerateIds();
        //cjk-double-stroke-input\double-stroke\projectFolder\GeneratedFiles\idsMap.txt
        //genIds.generateAndSaveIdsMap(idsPath, newPathForSaveFile);
    }
    
    [Test]
    public void testReadIdsMap()
    {
        //DONT DELETE!
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        string newPathForSaveFile = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.newPathForSaveFileStr);
            //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\idsMap.txt");
        GenerateIds genIds = new GenerateIds();
        Dictionary<string, IdsBasicRecord>  idsMap = genIds.readIdsMap(newPathForSaveFile);
        
        //𢺓
        var basic = idsMap.GetValueOrDefault("竹");//签
        var basic2 = idsMap.GetValueOrDefault("签");//签
        Assert.AreEqual(1, basic.rolledOutIdsWithNoShape.Count);
        Assert.AreEqual("竹", basic2.rolledOutIdsWithNoShape[0]);
    }
    
    [Test]
    public void readPriviledgedCharactersResults()
    {
        //DONT DELETE!
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        string newPathForSaveFile = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.newPathForSaveFileStr);
            //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\idsMap.txt");
        GenerateIds genIds = new GenerateIds();
        Dictionary<string, IdsBasicRecord>  idsMap = genIds.readIdsMap(newPathForSaveFile);

        var priviledge = CodeExceptions.getPriviledgedExceptionCharacters();

        foreach (var VARIABLE in priviledge.Values)
        {
            var eachPriviledge = idsMap.GetValueOrDefault(VARIABLE);
            Assert.AreEqual(eachPriviledge.rolledOutIdsWithNoShape.Count, 1);
        }

        string test = "";
    }
    
    //getPriviledgedExceptionCharacters
    
    
    [Test]
    public void handFull_ThatShouldHaveBeenThere()
    {
        //var mydict = foundExceptions;
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        
        //string idsPath = Path.Combine(testDirectory, @"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");
        string idsPath = Path.Combine(testDirectory, FilePaths.dotsAndSlash + FilePaths.idsPathStr);

        //var idsPath = "../../../double-stroke/projectFolder/StaticFiles/ids.txt"; 
        GenerateIds genIds = new GenerateIds();
        Dictionary<string, IdsBasicRecord> idsMap = genIds.generateIdsMap(idsPath, priviledgedExceptions);
        
        //𢺓
        var basic = idsMap.GetValueOrDefault("𢺓");
        Assert.AreEqual(12, basic.rolledOutIdsWithNoShape.Count);
        Assert.AreEqual(new UnicodeCharacter("八").Value, basic.rolledOutIdsWithNoShape[5]);
        Assert.AreEqual(new UnicodeCharacter("一").Value, basic.rolledOutIdsWithNoShape[11]);
        
    }
    
}