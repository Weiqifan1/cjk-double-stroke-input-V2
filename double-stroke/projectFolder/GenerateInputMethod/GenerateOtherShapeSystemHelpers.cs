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
    public void generateArray30Final()
    {
        generateTradArray30SchemaForRIME();
        generateSimpArray30SchemaForRIME();
        generateSimpArray30DictForRime();
        generateTradArray30DictForRime();
        // array30_main.dict
        string test = "";
    }

    [Test]
    public void generateCangjie5Final()
    {
        generateTradCangjieSchemaForRIME();
        generateSimpCangjieSchemaForRIME();
        generateSimpCangjieDictForRime();
        generateTradCangjieDictForRime();
    }

    
    private void GenerateAnyForeignInputMethod(
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
        
        string test = "";
    }
    
    private void generateTradArray30DictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.Array30DictStaticFile,
            FilePaths.tradDictSourceFile,
            FilePaths.Array30tradDictOutputFile,
            @"^\p{L}\t[a-z,./;]+", // @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z,./;]+",
            "POFtradAr30",
            "1.0"
        );
    }

    private void generateSimpArray30DictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.Array30DictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.Array30simpDictOutputFile,
            @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            "POFsimpAr30",
            "1.0"
        );
    }
    

    private void generateTradArray30SchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFtradAr30", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Array 30 codes\r\n    based on ", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFtradAr30", //DICTIONARY
            "`[a-z,.]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpArray30SchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFsimpAr30", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Array 30 codes\r\n    based on ", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFsimpAr30", //DICTIONARY
            "`[a-z,.]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    
    private void generateTradCangjieDictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.cangjie5DictStaticFile,
            FilePaths.tradDictSourceFile,
            FilePaths.cangjie5tradDictOutputFile,
            @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            "POFtradCJ5",
            "1.0"
        );
    }

    private void generateSimpCangjieDictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.cangjie5DictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.cangjie5simpDictOutputFile,
            @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            "POFsimpCJ5",
            "1.0"
        );
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
    
}