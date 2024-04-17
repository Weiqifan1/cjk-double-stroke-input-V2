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
public class GenerateOtherShapeSystemHelpers
{
    //FilePaths.dotsAndSlash + FilePaths.windowsArraySimpOutputFile
    
     
    [Test]
    public void GenerateSimpFiles()
    {
        //generateSimpDict();
        //generateSimpSchema();
    }    
         
    [Test]
    public void GenerateCangjie5HelperFiles()
    {
        //generateCangjie5Dict();
        //generateCangjie5Schema();
    }
    

    private void generateSimpSchema()
    {
        string comment = "POFsimp";
        string schemaId = "POFsimp";
        string name = "POFsimp";
        string dictionary = "POFsimp";
        string reverseLookup = "`[a-z,.]*$";
        string outputPath = 
            FilePaths.dotsAndSlash + 
            FilePaths.simpSchemaOutputFile;
        
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        string text = generatePOFSimpSchema.generate(
            comment,
            schemaId,
            name,
            dictionary,
            reverseLookup);
        
        string windowsTradArrauOutput = Path.Combine(testDirectory,
            outputPath);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(windowsTradArrauOutput, text);
        
        string test = "";
    }


    private void generateSimpDict()
    {
        string comment = "POFsimp";
        string name = "POFsimp";
        string outputPath =
            FilePaths.dotsAndSlash +
            FilePaths.simpDictOutputFile;
        
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        string text = generatePOFSimpDict.generate(
            comment,
            name);
        
        string windowsTradArrauOutput = Path.Combine(testDirectory, outputPath);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(windowsTradArrauOutput, text);
        
        string test = "";
    }
    
    private void generateCangjie5Schema()
    {
        string comment = "A POF system that also shows the cangjie 5 codes for each character";
        string schemaId = "POFsimpCJ5";
        string name = "POFsimpCJ5";
        string dictionary = "POFsimpCJ5";
        string reverseLookup = "`[a-z,.]*$";
        string outputPath = 
            FilePaths.dotsAndSlash + 
            FilePaths.simpSchemaOutputFile_cangjie5;
        
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        string text = generatePOFSimpSchema.generate(
            comment,
            schemaId,
            name,
            dictionary,
            reverseLookup);
        
        string windowsTradArrauOutput = Path.Combine(testDirectory,
            outputPath);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(windowsTradArrauOutput, text);
        
        string test = "";
    }


    private void generateCangjie5Dict()
    {
        string comment = "A POF system that also shows the cangjie 5 codes for each character";
        string name = "POFsimpCJ5";
        string outputPath =
            FilePaths.dotsAndSlash +
            FilePaths.simpDictOutputFile_cangjie5;
        
        string testDirectory = TestContext.CurrentContext.TestDirectory;
        string text = generatePOFSimpDict.generate(
            comment,
            name);
        
        string windowsTradArrauOutput = Path.Combine(testDirectory, outputPath);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(windowsTradArrauOutput, text);
        
        string test = "";
    }

    /*
    private void generateSimpForRIME()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;

        string simpDictPath = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpDictSourceFile);
        var simpDictFile = UtilityFunctions.ReadLinesFromFile(simpDictPath);

        string punctuationPath = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.punctuationPathStr);
        var punctuationLines = UtilityFunctions.ReadLinesFromFile(punctuationPath);

        List<string> printSimplified = simplifiedOutputList;
        printSimplified.InsertRange(0, punctuationLines);
        //printSimplified.InsertRange(0, new List<string>(){""});
        printSimplified.InsertRange(0, simpDictFile);

        string resultSimplified = generateInputDictforRimeFormat(printSimplified);

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpDictOutputFile);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);

        Assert.True(true);
    }*/
}