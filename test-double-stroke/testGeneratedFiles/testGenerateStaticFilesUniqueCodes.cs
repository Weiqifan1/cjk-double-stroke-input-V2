using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using double_stroke.projectFolder.StaticFileMaps;
using test_double_stroke.testSchemdictValuesBeforePrint;
using test_double_stroke.testSchemeDict;

namespace test_double_stroke.testIds;

public class testGenerateStaticFilesUniqueCodes : testSetup
{


    [Test]
    public void generateStaticFileJundaUnique()
    {
        
        GenerateFileMaps gen = new GenerateFileMaps();
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        string jundaPath = Path.Combine(testDirectory, 
                             FilePaths.dotsAndSlash + FilePaths.jundaPathStr);
       
        //碛
        SchemeRecord over5001 = charToSchema.GetValueOrDefault("碛");
        foreach (var eachCode in over5001.code4)
        {
            var charsWithCode = codeToSchema.GetValueOrDefault(eachCode);
            string test = "";
        } 

        List<string> simplifiedOutputList = 
            OrderingHelper.generatedTupleJundaAboveNine(charToSchema, codeToSchema);

         List<Tuple<string, HashSet<string>>> above9th = OrderingHelper.AllAbove9thMODIFIED(simplifiedOutputList);
        
         HashSet<string> above9thFiltered_1to4 = 
                    OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> { 1, 2, 3, 4});
                
         HashSet<string> above9thFiltered_5to6 = 
                    OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> {5, 6});
        
         HashSet<string> heisigTradAbove9th_1to4 = 
             OrderingHelper.getWithinFreq(above9thFiltered_1to4, junda5001);
         HashSet<string> heisigTradAbove9th_5to6 = 
             OrderingHelper.getWithinFreq(above9thFiltered_5to6, junda5001);
         Assert.That(heisigTradAbove9th_1to4.Count == 0);
         Assert.That(heisigTradAbove9th_5to6.Count == 0);
        
    }
    
    [Test]
    public void generateStaticFileTzaiUnique()
    {
            
        List<string> simplifiedOutputList = 
                 OrderingHelper.generatedTupleTzaiAboveNine(charToSchema, codeToSchema);
     
        List<Tuple<string, HashSet<string>>> above9th = OrderingHelper.AllAbove9thMODIFIED(simplifiedOutputList);
             
        HashSet<string> above9thFiltered_1to4 = 
                         OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> { 1, 2, 3, 4});
                     
        HashSet<string> above9thFiltered_5to6 = 
                         OrderingHelper.AllAboveThe9ThFilter(above9th, new HashSet<int> {5, 6});
             
        HashSet<string> heisigTradAbove9th_1to4 = 
                  OrderingHelper.getWithinFreq(above9thFiltered_1to4, tzai5001);
        HashSet<string> heisigTradAbove9th_5to6 = 
                  OrderingHelper.getWithinFreq(above9thFiltered_5to6, tzai5001);
        Assert.That(heisigTradAbove9th_1to4.Count == 0);
        Assert.That(heisigTradAbove9th_5to6.Count == 0);
             
    }
    
    
    
}