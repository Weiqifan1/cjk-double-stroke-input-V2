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

[Explicit]
public class GenerateInputMethodClass : TestSchemaBeforePrintSetup
{
    [Test]
    public void GenerateSimpAndTradYaml()
    {
       generateSimp();
       generateTrad();
    }

    [Test]
    public void GenerateSimpDictInput()
    {
        generateSimp();
    }
    
    [Test]
    public void GenerateTradDictInput()
    {
        generateTrad();
    }
    
    private void generateSimp()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;
                  
        string simpDictPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.simpDictSourceFile);
        var simpDictFile = UtilityFunctions.ReadLinesFromFile(simpDictPath);
        
        string punctuationPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.punctuationPathStr);
        var punctuationLines = UtilityFunctions.ReadLinesFromFile(punctuationPath);
             
        List<string> printSimplified = simplifiedListString;
        printSimplified.InsertRange(0, punctuationLines);
        //printSimplified.InsertRange(0, new List<string>(){""});
        printSimplified.InsertRange(0, simpDictFile); 
        
        string resultSimplified = printSimplified.Count > 0 ? 
            printSimplified.Aggregate((current, next) => 
                current.Trim() + "\n" + next.Trim()) : "";
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpDictOutputFile);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);        
        
        Assert.True(true);
    }
    
    private void generateTrad()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;
                  
        string tradDictPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.tradDictSourceFile);
        var tradDictFile = UtilityFunctions.ReadLinesFromFile(tradDictPath);
        
        string punctuationPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.punctuationPathStr);
        var punctuationLines = UtilityFunctions.ReadLinesFromFile(punctuationPath);
             
        List<string> printTraditional = traditionalListString;
        printTraditional.InsertRange(0, punctuationLines);
        //printTraditional.InsertRange(0, new List<string>(){""});
        printTraditional.InsertRange(0, tradDictFile); 
        
        string resultTraditional = printTraditional.Count > 0 ? 
            printTraditional.Aggregate((current, next) => 
                current.Trim() + "\n" + next.Trim()) : "";
        
        string traditionalOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradDictOutputFile);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(traditionalOutput, resultTraditional);        
        
        Assert.True(true);
    }

}