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
    public void GenerateSimpAndTradYamlForRIME()
    {
        generateSimpForRIME();
        //generateTradForRIME();
    }

    [Test]
    public void GenerateSimpDictInputYamlForRIME()
    {
        //generateSimpForRIME();
    }
    
    [Test]
    public void GenerateTradDictInputYamlForRIME()
    {
        //generateTradForRIME();
    }
    
    [Test]
    public void GenerateSimpAndTradForWindows()
    {
        //generateSimpForWindowsArray();
        //generateTradForWindowsArray();
    }
    
    [Test]
    public void GenerateSimpDictInputForWindows()
    {
        //generateSimpForWindowsArray();
    }
     
    [Test]
    public void GenerateTradDictInputForWindows()
    {
        //generateTradForWindowsArray();
    }
    private static string generateInputDictforRimeFormat(List<string> printSimplified)
    {
        return printSimplified.Count > 0 ? 
            printSimplified.Aggregate((current, next) => 
                current + "\n" + next) : "";
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
    }

    private void generateTradForRIME()
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