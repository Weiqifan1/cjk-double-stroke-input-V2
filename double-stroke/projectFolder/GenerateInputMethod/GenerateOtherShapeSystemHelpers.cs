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
    public void generateTerraPinyinFinal()
    {
        generateTradPinyinSchemaForRIME();//generateTradTerraPinyinSchemaForRIME();
        generateSimpPinyinSchemaForRIME();
        generateSimpPinyinDictForRime();
        generateTradPinyinDictForRime();
        // array30_main.dict
        string test = "";
    }
    
    [Test]
    public void generateBoshiamyFinal()
    {
        generateTradBoshiamySchemaForRIME();
        generateSimpBoshiamySchemaForRIME();
        generateSimpBoshiamyDictForRime();
        generateTradBoshiamyDictForRime();
        string test = "";
    }
    
    [Test]
    public void generateDayi4Final()
    {
        generateTradDayi4SchemaForRIME();
        generateTradDayi4DictForRime();
        string test = "";
    }
    
    [Test]
    public void generateZhengmaFinal()
    {
        generateTradZhengmaSchemaForRIME();
        generateSimpZhengmaSchemaForRIME();
        generateSimpZhengmaDictForRime();
        generateTradZhengmaDictForRime();
        string test = "";
    }
    
    [Test]
    public void generateWubi86Final()
    {
        generateTradWubi86SchemaForRIME();
        generateSimpWubi86SchemaForRIME();
        generateSimpWubi86DictForRime();
        generateTradWubi86DictForRime();
        string test = "";
    }
    
    [Test]
    public void generateArray30Final()
    {
        generateTradArray30SchemaForRIME();
        generateSimpArray30SchemaForRIME();
        generateSimpArray30DictForRime();
        generateTradArray30DictForRime();
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
    
    private void generateTradPinyinDictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.TerraPinyinDictStaticFile, //Array30DictStaticFile,
            FilePaths.tradDictSourceFile,
            FilePaths.TerraPiyintradDictOutputFile,  //TerraPinyinsimpDictOutputFile ,//.Array30tradDictOutputFile,
            @"^\p{L}\t[a-z0-9]+", // @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z0-9]+",
            "POFtradPinyin",
            "1.0"
        );
    }

    private void generateSimpPinyinDictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.TerraPinyinDictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.TerraPinyinsimpDictOutputFile, //Array30simpDictOutputFile,
            @"^\p{L}\t[a-z0-9]+",
            @"^\p{L}",
            @"\t[a-z0-9]+",
            "POFsimpPinyin",
            "1.0"
        );
    }

    private void generateTradPinyinSchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFtradPinyin", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Terra Pinyin codes\r\n    based on: https://github.com/rime/rime-terra-pinyin", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFtradPinyin", //DICTIONARY
            "`[a-z0-9]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaTerraPinyinOutputFile);//FilePaths.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpPinyinSchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFsimpPinyin", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Terra Pinyin codes\r\n    based on: https://github.com/rime/rime-terra-pinyin", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFsimpPinyin", //DICTIONARY
            "`[a-z0-9]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaTerraPinyinOutputFile);//FilePaths.simpSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }    
    
    private void generateTradBoshiamyDictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.BoshiamyDictStaticFile ,//.Array30DictStaticFile,
            FilePaths.tradDictSourceFile ,//.tradDictSourceFile,
            FilePaths.BoshiamytradDictOutputFile, //.Array30tradDictOutputFile,
            @"[a-z]+\t\p{L}", // @"^\p{L}\t[a-z]+",
            @"\t\p{L}\t",
            @"[a-z]+",
            "POFtradBoshiamy",
            "1.0"
        );
    }
    
    private void generateSimpBoshiamyDictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.BoshiamyDictStaticFile ,//.Array30DictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.BoshiamysimpDictOutputFile ,//.Array30simpDictOutputFile,
            @"[a-z]+\t\p{L}",
            @"\t\p{L}\t",
            @"[a-z]+",
            "POFsimpBoshiamy",
            "1.0"
        );
    }

    private void generateTradBoshiamySchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFtradBoshiamy", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Boshiamy codes\r\n    based on: https://github.com/vicamo/ibus-table-boshiamy/blob/master/tables/boshiamy.txt", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFtradBoshiamy", //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaBoshiamyOutputFile);//.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpBoshiamySchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFsimpBoshiamy", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Boshiamy codes\r\n    based on: https://github.com/vicamo/ibus-table-boshiamy/blob/master/tables/boshiamy.txt", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFsimpBoshiamy", //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaBoshiamyOutputFile); //.simpSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    
    private void generateTradDayi4DictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.Dayi4DictStaticFile ,//.Array30DictStaticFile,
            FilePaths.tradDictSourceFile ,//.tradDictSourceFile,
            FilePaths.Dayi4tradDictOutputFile, //.Array30tradDictOutputFile,
            @"^\p{L}\t[a-z,./;0-9]+", // @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z,./;0-9]+",
            "POFtradDayi4",
            "1.0"
        );
    }    
    
    private void generateTradDayi4SchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFtradDayi4", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Dayi4 codes\r\n    based on: https://github.com/chiahsien/RimeDayi", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFtradDayi4", //DICTIONARY
            "`[a-z,./;0-9]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaDayi4OutputFile);//.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateTradZhengmaDictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.ZhengmaDictStaticFile ,//.Array30DictStaticFile,
            FilePaths.tradDictSourceFile ,//.tradDictSourceFile,
            FilePaths.ZhengmatradDictOutputFile, //.Array30tradDictOutputFile,
            @"^\p{L}\t[a-z]+", // @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            "POFtradZhengma",
            "1.0"
        );
    }
    
    private void generateSimpZhengmaDictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.ZhengmaDictStaticFile ,//.Array30DictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.ZhengmasimpDictOutputFile ,//.Array30simpDictOutputFile,
            @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            "POFsimpZhengma",
            "1.0"
        );
    }

    private void generateTradZhengmaSchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFtradZhengma", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Zhengma codes\r\n    based on: https://github.com/Openvingen/rime-zhengma/blob/master/zmbig.dict.yaml", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFtradZhengma", //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaZhengmaOutputFile);//.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpZhengmaSchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFsimpZhengma", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Zhengma codes\r\n    based on: https://github.com/Openvingen/rime-zhengma/blob/master/zmbig.dict.yaml", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFsimpZhengma", //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaZhengmaOutputFile); //.simpSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
   
    private void generateTradWubi86DictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.Wubi86DictStaticFile ,//.Array30DictStaticFile,
            FilePaths.tradDictSourceFile ,//.tradDictSourceFile,
            FilePaths.Wubi86tradDictOutputFile, //.Array30tradDictOutputFile,
            @"^\p{L}\t[a-z]+", // @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            "POFtradWubi86",
            "1.0"
        );
    }
    
    private void generateSimpWubi86DictForRime()
    {
        GenerateAnyForeignInputMethod(
            FilePaths.Wubi86DictStaticFile ,//.Array30DictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.Wubi86simpDictOutputFile ,//.Array30simpDictOutputFile,
            @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            "POFsimpWubi86",
            "1.0"
        );
    }

    private void generateTradWubi86SchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFtradWubi86", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Wubi 86 codes\r\n    based on: https://github.com/rime/rime-wubi", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFtradWubi86", //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaWubi86OutputFile);//.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpWubi86SchemaForRIME()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFsimpWubi86", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "\r\n    A translator of POF codes to Wubi 86 codes\r\n    based on: https://github.com/rime/rime-wubi", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFsimpWubi86", //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaWubi86OutputFile); //.simpSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
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
            @"^\p{L}\t[a-z,./;]+",
            @"^\p{L}",
            @"\t[a-z,./;]+",
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
            "\r\n    A translator of POF codes to Array 30 codes\r\n    based on: https://github.com/rime/rime-array", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFtradAr30", //DICTIONARY
            "`[a-z,./;]*$" //REVERSELOOKUP
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
            "\r\n    A translator of POF codes to Array 30 codes\r\n    based on: https://github.com/rime/rime-array", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFsimpAr30", //DICTIONARY
            "`[a-z,./;]*$" //REVERSELOOKUP
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
            "\r\n    A translator of POF codes to Cangjie5 codes\r\n    based on: https://github.com/rime/rime-cangjie", // \r\n    EXTRA\r\n    DESCRIPTION
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
            "\r\n    A translator of POF codes to Cangjie5 codes\r\n    based on: https://github.com/rime/rime-cangjie", // \r\n    EXTRA\r\n    DESCRIPTION
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