using double_stroke.projectFolder.InputMethodFiles;

namespace double_stroke.GenerateInputMethodClass;

using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;
using double_stroke.projectFolder.FileMaps;
using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using test_double_stroke.testSchemdictValuesBeforePrint;

[Explicit]
public class GenerateOtherShapeSystemHelpers : TestSchemaBeforePrintSetup
{
    //FilePaths.dotsAndSlash + FilePaths.windowsArraySimpOutputFile

    [Test]
    public void GenerateCangjie()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;
                  
        string simpDictPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.simpDictSourceFile);
        var simpDictFile = UtilityFunctions.ReadLinesFromFile(simpDictPath);
        
        string punctuationPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.punctuationPathStr);
        var punctuationLines = UtilityFunctions.ReadLinesFromFile(punctuationPath);
             
        List<string> printSimplified = simplifiedOutputList;
       
        
        
        
        
        var gen = new GenerateFileMaps();
        string cangjiePath = FilePaths.dotsAndSlash + FilePaths.cangjie5DictStaticFile;
        string linepattern = @"^\p{L}\t[a-z]+";
        string charpattern = @"^\p{L}";
        string codepattern = @"[a-z]+$";
        List<Tuple<string, string>> foreign = gen.generateForeignInputSystemDict(
            cangjiePath, linepattern, charpattern, codepattern);

        Dictionary<string, string> tup = gen.convertTupleToDict(foreign);
        List<string> semiout = gen.addInfoToOutput(printSimplified, tup);
        
        
        
        semiout.InsertRange(0, punctuationLines);
        //printSimplified.InsertRange(0, new List<string>(){""});
        semiout.InsertRange(0, simpDictFile); 
        
        string resultSimplified = generateInputDictforRimeFormat(semiout);
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.cangjie5DictOutputFile);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        
        
        //File.WriteAllText(simplifiedOutput, resultSimplified);        
        
        Assert.True(true);
        
        
        //generateCangjie5Dict(foreign);

        string test = "";
    }
    
    /*
    public string createForeignIntro()
    public string generateForeignFileStringFromTuplesAndInto(List<Tuple<string, string>> tupples, string into)
    public List<Tuple<string, string>> generateForeignInputSystemDict(string foreignPath)
    */
    
}