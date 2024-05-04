﻿using double_stroke.projectFolder.InputMethodFiles;

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

/*
    [Test]
    public void generateCangjie5Final()
    {
        
        generateTradCangjieSchemaForRIME();
        generateSimpCangjieSchemaForRIME();
        
        GenerateCangjie(
            FilePaths.cangjie5DictStaticFile,
             FilePaths.simpDictSourceFile,
            FilePaths.cangjie5simpDictOutputFile,
             @"^\p{L}\t[a-z]+",
             @"^\p{L}",
            @"\t[a-z]+",
            "POFsimpCJ5",
            "1.0"
            );
        GenerateCangjie(
            FilePaths.cangjie5DictStaticFile,
            FilePaths.tradDictSourceFile,
            FilePaths.cangjie5tradDictOutputFile,
            @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            "POFtradCJ5",
            "1.0"
        );
        
        string test = "";


    }
*/
    
    private void GenerateCangjie(
        string cangjieSource, // FilePaths.cangjie5DictStaticFile
        string dictSource, // FilePaths.simpDictSourceFile
        string dictOutput, // FilePaths.cangjie5DictOutputFile
        string linepatterninput, // @"^\p{L}\t[a-z]+"
        string charpatterninput, // @"^\p{L}"
        string codepatterninput, // @"\t[a-z]+"
        string introTitle, // POFsimpCJ5
        string dictversion
        )
    {
        string testDirectory = TestContext.CurrentContext.TestDirectory;

        string simpDictPath = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + dictSource);//FilePaths.simpDictSourceFile);
        
        //edit intro lines
        var simpDictFileRaw = UtilityFunctions.ReadLinesFromFile(simpDictPath);
        var simpDictFile = UtilityFunctions.generateDictIntro(simpDictFileRaw);
        
        string punctuationPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.punctuationPathStr);
        var punctuationLines = UtilityFunctions.ReadLinesFromFile(punctuationPath);
             
        List<string> printSimplified = simplifiedOutputList;
        
        var gen = new GenerateFileMaps();
        string cangjiePath = FilePaths.dotsAndSlash + cangjieSource; //FilePaths.cangjie5DictStaticFile;
        string linepattern = linepatterninput; // @"^\p{L}\t[a-z]+";
        string charpattern = charpatterninput;// @"^\p{L}";
        string codepattern = codepatterninput; // @"\t[a-z]+";
        List<Tuple<string, string>> foreign = gen.generateForeignInputSystemDict(
            cangjiePath, linepattern, charpattern, codepattern);

        Dictionary<string, string> tup = gen.convertTupleToDict(foreign);
        List<string> semiout = gen.addInfoToOutput(printSimplified, tup);
        
        
        
        semiout.InsertRange(0, punctuationLines);

        List<string> cangjieDictSimpIntro = UtilityFunctions.introTextForDict(introTitle, dictversion);//gen.generateForeignInputSystemDict();
        semiout.InsertRange(0, cangjieDictSimpIntro);
        //printSimplified.InsertRange(0, new List<string>(){""});
        ////////////////////////////////////////////semiout.InsertRange(0, simpDictFile); 
        
        string resultSimplified = generateInputDictforRimeFormat(semiout);

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + dictOutput); //FilePaths.cangjie5DictOutputFile);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        
        
        File.WriteAllText(simplifiedOutput, resultSimplified);        
        
        Assert.True(true);
        
        
        //generateCangjie5Dict(foreign);

        string test = "";
    }
    
    private void generateForeignSchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFtradCJ5", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Cangjie5 codes\r\n    based on ", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFtradCJ5", //DICTIONARY
            "`[a-z,.]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaCangjie5OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateTradCangjieSchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFtradCJ5", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Cangjie5 codes\r\n    based on ", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFtradCJ5", //DICTIONARY
            "`[a-z,.]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaCangjie5OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpCangjieSchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFsimpCJ5", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Cangjie5 codes\r\n    based on ", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFsimpCJ5", //DICTIONARY
            "`[a-z,.]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaCangjie5OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    /*
    public string createForeignIntro()
    public string generateForeignFileStringFromTuplesAndInto(List<Tuple<string, string>> tupples, string into)
    public List<Tuple<string, string>> generateForeignInputSystemDict(string foreignPath)
    */
    
}