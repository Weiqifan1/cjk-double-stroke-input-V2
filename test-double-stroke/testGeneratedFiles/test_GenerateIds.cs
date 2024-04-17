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
        Assert.That(basic.rolledOutIdsWithNoShape.Count.Equals(1));
        Assert.That(basic2.rolledOutIdsWithNoShape[0].Equals("竹"));
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
            Assert.That(eachPriviledge.rolledOutIdsWithNoShape.Count.Equals(1));
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
        Assert.That(basic.rolledOutIdsWithNoShape.Count.Equals(12));
        Assert.That(new UnicodeCharacter("八").Value.Equals(basic.rolledOutIdsWithNoShape[5]));
        Assert.That(new UnicodeCharacter("一").Value.Equals( basic.rolledOutIdsWithNoShape[11]));
        
    }
    
}