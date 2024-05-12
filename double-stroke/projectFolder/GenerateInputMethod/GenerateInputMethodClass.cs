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
    public void GenerateSimpAndTradDictYamlForRIME()
    {
        generateSimpDictForRIME();
        generateTradDictForRIME();
    }

    [Test]
    public void GenerateSimpAndTradSchemaYamlForRime()
    {
        generateSimpSchemaForRIME();
        generateTradSchemaForRIME();
    }
    
    [Test]
    public void GenerateSimpAndTradForWindows()
    {
        //generateSimpForWindowsArray();
        //generateTradForWindowsArray();
    }
    
    private static string generateInputDictforWindowsFormat(List<string> printSimplified)
    {
        List<string> modifyInput = new List<string>();
        foreach (var each in printSimplified) 
        {
            modifyInput.Add(createWndowsFormat(each, "\t"));
        }

        return modifyInput.Count > 0 ? 
            modifyInput.Aggregate((current, next) => 
                    current + "\n" + next) : "";
        }

    private static string createWndowsFormat(string input, string splitBy)
    {
        var splittet = input.Split(splitBy);
        if (splittet.Length != 2)
        {
            System.Console.WriteLine(input);
        }

        string res = "\"" + splittet[1].ToUpper() + "\"" + "=" + "\"" + splittet[0] + "\"";
        return res;
    }

    private void generateSimpForWindowsArray()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;
                  
        string windowsArrayInfoPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.windowsArrayInfo);
        var windowsArrayFile = UtilityFunctions.ReadLinesFromFile(windowsArrayInfoPath);
        
        string punctuationPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.punctuationPathStr);
        var punctuationLines = UtilityFunctions.ReadLinesFromFile(punctuationPath);
             
        List<string> printSimplified = simplifiedOutputList;
        printSimplified.InsertRange(0, punctuationLines);
        //printSimplified.InsertRange(0, new List<string>(){""});
        //printSimplified.InsertRange(0, windowsArrayFile); 
        
        string resultSimplified = generateInputDictforWindowsFormat(printSimplified);
        string ArrayInfo = generateInputDictforRimeFormat(windowsArrayFile);
        string result = ArrayInfo + "\n" + resultSimplified; 
        
        string windowsOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.windowsArraySimpOutputFile);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(windowsOutput, result);        
        
        Assert.True(true);
    }

    private void generateTradForWindowsArray()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;
                  
        string windowsArrayInfoPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.windowsArrayInfo);
        var windowsArrayFile = UtilityFunctions.ReadLinesFromFile(windowsArrayInfoPath);
        
        string punctuationPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.punctuationPathStr);
        var punctuationLines = UtilityFunctions.ReadLinesFromFile(punctuationPath);
             
        List<string> printTraditional = traditionalOutputList;
        printTraditional.InsertRange(0, punctuationLines);
        //printTraditional.InsertRange(0, new List<string>(){""});
        //printTraditional.InsertRange(0, tradDictFile); 
        
        string resultTraditional = generateInputDictforWindowsFormat(printTraditional);
        string ArrayInfo = generateInputDictforRimeFormat(windowsArrayFile);
        string result = ArrayInfo + "\n" + resultTraditional; 
        
        string windowsTradArrauOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.windowsArrayTradOutputFile);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(windowsTradArrauOutput, result);        
           
        Assert.True(true);
    }

    private void generateSimpSchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFsimp", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFsimp", //DICTIONARY
            "`[a-z,.]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaOutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateTradSchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFtrad", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFtrad", //DICTIONARY
            "`[a-z,.]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaOutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }

    private void generateSimpDictForRIME()
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
    }

    private void generateTradDictForRIME()
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;
                  
        string tradDictPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.tradDictSourceFile);
        var tradDictFile = UtilityFunctions.ReadLinesFromFile(tradDictPath);
        
        string punctuationPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.punctuationPathStr);
        var punctuationLines = UtilityFunctions.ReadLinesFromFile(punctuationPath);
             
        List<string> printTraditional = traditionalOutputList;
        printTraditional.InsertRange(0, punctuationLines);
        //printTraditional.InsertRange(0, new List<string>(){""});
        printTraditional.InsertRange(0, tradDictFile); 
        
        string resultTraditional =  generateInputDictforRimeFormat(printTraditional);
        
        string traditionalOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradDictOutputFile);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(traditionalOutput, resultTraditional);        
        
        Assert.True(true);
    }

}