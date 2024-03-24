using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;
using double_stroke.projectFolder.FileMaps;
using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using test_double_stroke.testSchemdictValuesBeforePrint;

namespace double_stroke.GenerateInputMethodClass;

public class GenerateInputMethodClass : TestSchemaBeforePrintSetup
{
    [Test]
    public void GenerateInput()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        
        //read punctuation
        string punctuationPath = Path.Combine(testDirectory, 
        FilePaths.dotsAndSlash + FilePaths.punctuationPathStr);
        var punctuationLines = UtilityFunctions.ReadLinesFromFile(punctuationPath);
        
        List<string> printSimplified = simplifiedListString;
        printSimplified.InsertRange(0, punctuationLines);
        string resultSimplified = printSimplified.Count > 0 ? 
            printSimplified.Aggregate((current, next) => 
                current.Trim() + "\n" + next.Trim()) : "";
        List<string> printTraditional = traditionalListString;
        printTraditional.InsertRange(0, punctuationLines);
        string resultTraditional = printTraditional.Count > 0 ? 
                    printSimplified.Aggregate((current, next) => 
                        current.Trim() + "\n" + next.Trim()) : "";
        
        
       
        string simplifiedOutput = Path.Combine(testDirectory,
                FilePaths.dotsAndSlash + FilePaths.simplifiedOutputFile);
                //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);        
        
        string traditionalOutput = Path.Combine(testDirectory,
                        FilePaths.dotsAndSlash + FilePaths.traditionalOutputFIle);
                        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");        
        File.WriteAllText(traditionalOutput, resultTraditional);
                
        Assert.True(true);
    }

}