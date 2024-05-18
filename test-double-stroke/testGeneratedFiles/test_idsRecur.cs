using double_stroke.projectFolder.FileMaps;
using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using double_stroke.projectFolder.StaticFileMaps;

namespace test_double_stroke.testIds;

public class test_idsRecur
{
    
    protected static Dictionary<string, IdsBasicRecord> idsMap;
    protected static Dictionary<string, FrequencyRecord> junda;
    protected static Dictionary<string, FrequencyRecord> tzai;
    protected static Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
    protected static Dictionary<string, CodepointBasicRecord> codepointMap;
    protected static Dictionary<string, List<UnicodeCharacter>> genRawIds;
    protected static Dictionary<string, string> manualIdsConway;
    protected static Dictionary<string, CodepointBasicRecord> codepointConway;
    
    [SetUp]
    public void Initialize()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        GenerateIds genIds = new GenerateIds();
        string newPathForSaveFile = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.newPathForSaveFileStr);
        idsMap = genIds.readIdsMap(newPathForSaveFile);
        
        
        
        string jundaPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.jundaPathStr);
        //@"..\..\..\..\double-stroke\projectFolder\StaticFiles\Junda2005.txt");
        string tzaiPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.tzaiPathStr);
        //@"..\..\..\..\double-stroke\projectFolder\StaticFiles\Tzai2006.txt");
        string manualConwayPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.manualIdsConwayPathStr);
        string codepointPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.codepointPathStr);
        GenerateFileMaps gen = new GenerateFileMaps();
        junda = gen.generateJundaMap(jundaPath);
        tzai = gen.generateTzaiMap(tzaiPath);
        manualIdsConway = gen.manualIdsConway(manualConwayPath);
        
        CodeExceptions exp = new CodeExceptions();
        codeExceptionsFromIds = exp.generateCodeExceptionsFromCharacter();

        codepointConway = UtilityFunctions.generateCodepointMap(
            codeExceptionsFromIds, idsMap, codepointPath);
        Dictionary<string, string> priviledgedElemn = CodeExceptions.getPriviledgedExceptionCharacters();

        //string newPathForSaveFile2 = Path.Combine(testDirectory, 
        //    FilePaths.dotsAndSlash + FilePaths.newPathForSaveFileStr);
        string idsPath = Path.Combine(testDirectory, FilePaths.dotsAndSlash + FilePaths.idsPathStr);

        genRawIds = 
            UtilityFunctions.generateRawIdsMap(idsPath, priviledgedElemn);
        
        
        string test = "";
    }

    [Test]
    public void generateEverySingleRecur()
    {
        long eachChar = 0;
        List<Tuple<string, string, string, string>> listTuples = new List<Tuple<string, string, string, string>>();
        List<IdsRecur> jundaRecurs = new List<IdsRecur>();
        foreach (string item in junda.Keys) {
            
            IdsRecur res = GenerateIdsRecursionMap.createSingleRecur(
                eachChar,
                genRawIds,  
                manualIdsConway, codepointConway,  item);
            jundaRecurs.Add(res);
            var testRegenerated = new Tuple<string, string, string, string>
                (res.elem, res.rawConway, res.regeneratedConway, res.unambigousConway);
            listTuples.Add(testRegenerated);
            try
            {
                Assert.AreEqual(testRegenerated.Item2, testRegenerated.Item3);
            }
            catch (Exception e)
            {
                string regeneratedConwayTest = "";
            }

            eachChar++;
        }

        string test = "123";
    }

}