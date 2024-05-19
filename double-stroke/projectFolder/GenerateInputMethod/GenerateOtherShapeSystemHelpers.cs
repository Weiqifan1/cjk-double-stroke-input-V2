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
        string trad = "POFtradPinyin";
        string simp = "POFsimpPinyin";
        string version = "1.0";
        string date = "2024-05-15";
        
        generateTradPinyinSchemaForRIME(trad, version, date);//generateTradTerraPinyinSchemaForRIME();
        generateSimpPinyinSchemaForRIME(simp, version, date);
        generateSimpPinyinDictForRime(simp, version);
        generateTradPinyinDictForRime(trad, version);
        // array30_main.dict
        string test = "";
    }
    
    [Test]
    public void generateBoshiamyFinal()
    {
        string trad = "POFtradBoshiamy";
        string simp = "POFsimpBoshiamy";
        string version = "1.0";
        string date = "2024-05-15";
        
        generateTradBoshiamySchemaForRIME(trad, version, date);
        generateSimpBoshiamySchemaForRIME(trad, version, date);
        generateSimpBoshiamyDictForRime(simp, version);
        generateTradBoshiamyDictForRime(trad, version);
        string test = "";
    }
    
    [Test]
    public void generateDayi4Final()
    {
        string trad = "POFtradDayi4";
        string version = "1.0";
        string date = "2024-05-15";
        
        generateTradDayi4SchemaForRIME(trad, version, date);
        generateTradDayi4DictForRime(trad, version);
        string test = "";
    }
    
    [Test]
    public void generateZhengmaFinal()
    {
        string trad = "POFtradZhengma";
        string simp = "POFsimpZhengma";
        string version = "1.0";
        string date = "2024-05-15";
        
        generateTradZhengmaSchemaForRIME(trad, version, date);
        generateSimpZhengmaSchemaForRIME(simp, version, date);
        generateSimpZhengmaDictForRime(simp, version);
        generateTradZhengmaDictForRime(trad, version);
        string test = "";
    }
    
    [Test]
    public void generateWubi86Final()
    {
        string trad = "POFtradPinyin";
        string simp = "POFsimpPinyin";
        string version = "1.0";
        string date = "2024-05-15";
        
        generateTradWubi86SchemaForRIME(trad, version, date);
        generateSimpWubi86SchemaForRIME(simp, version, date);
        generateSimpWubi86DictForRime(simp, version);
        generateTradWubi86DictForRime(trad, version);
        string test = "";
    }
    
    [Test]
    public void generateArray30Final()
    {
        string trad = "POFtradWubi86";
        string simp = "POFsimpWubi86";
        string version = "1.0";
        string date = "2024-05-15";
        
        generateTradArray30SchemaForRIME(trad, version, date);
        generateSimpArray30SchemaForRIME(simp, version, date);
        generateSimpArray30DictForRime(simp, version);
        generateTradArray30DictForRime(trad, version);
        string test = "";
    }

    [Test]
    public void generateCangjie5Final()
    {
        string trad = "POFtradCJ5";
        string simp = "POFsimpCJ5";
        string version = "1.0";
        string date = "2024-05-15";
        
        generateTradCangjieSchemaForRIME(trad, version, date);
        generateSimpCangjieSchemaForRIME(simp, version, date);
        generateSimpCangjieDictForRime(simp, version);
        generateTradCangjieDictForRime(trad, version);
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
    
    private void generateTradPinyinDictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.TerraPinyinDictStaticFile, //Array30DictStaticFile,
            FilePaths.tradDictSourceFile,
            FilePaths.TerraPiyintradDictOutputFile,  //TerraPinyinsimpDictOutputFile ,//.Array30tradDictOutputFile,
            @"^\p{L}\t[a-z0-9]+", // @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z0-9]+",
            systemName,
            version
        );
    }

    private void generateSimpPinyinDictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.TerraPinyinDictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.TerraPinyinsimpDictOutputFile, //Array30simpDictOutputFile,
            @"^\p{L}\t[a-z0-9]+",
            @"^\p{L}",
            @"\t[a-z0-9]+",
            systemName,
            version
        );
    }

    private void generateTradPinyinSchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Terra Pinyin codes"+
            "\r\n    based on: https://github.com/rime/rime-terra-pinyin", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z0-9]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaTerraPinyinOutputFile);//FilePaths.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpPinyinSchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Terra Pinyin codes"+
            "\r\n    based on: https://github.com/rime/rime-terra-pinyin", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z0-9]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaTerraPinyinOutputFile);//FilePaths.simpSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }    
    
    private void generateTradBoshiamyDictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.BoshiamyDictStaticFile ,//.Array30DictStaticFile,
            FilePaths.tradDictSourceFile ,//.tradDictSourceFile,
            FilePaths.BoshiamytradDictOutputFile, //.Array30tradDictOutputFile,
            @"[a-z]+\t\p{L}", // @"^\p{L}\t[a-z]+",
            @"\t\p{L}\t",
            @"[a-z]+",
            systemName,
            version
        );
    }
    
    private void generateSimpBoshiamyDictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.BoshiamyDictStaticFile ,//.Array30DictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.BoshiamysimpDictOutputFile ,//.Array30simpDictOutputFile,
            @"[a-z]+\t\p{L}",
            @"\t\p{L}\t",
            @"[a-z]+",
            systemName,
            version
        );
    }

    private void generateTradBoshiamySchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Boshiamy codes"+
            "\r\n    based on: https://github.com/vicamo/ibus-table-boshiamy/blob/master/tables/boshiamy.txt", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaBoshiamyOutputFile);//.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpBoshiamySchemaForRIME(
        string systemName, 
        string version,
        string versionDate)
    {
        
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Boshiamy codes" +
            "\r\n    based on: https://github.com/vicamo/ibus-table-boshiamy/blob/master/tables/boshiamy.txt", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaBoshiamyOutputFile); //.simpSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    
    private void generateTradDayi4DictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.Dayi4DictStaticFile ,//.Array30DictStaticFile,
            FilePaths.tradDictSourceFile ,//.tradDictSourceFile,
            FilePaths.Dayi4tradDictOutputFile, //.Array30tradDictOutputFile,
            @"^\p{L}\t[a-z,./;0-9]+", // @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z,./;0-9]+",
            systemName,
            version
        );
    }    
    
    private void generateTradDayi4SchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Dayi4 codes"+
            "\r\n    based on: https://github.com/chiahsien/RimeDayi", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z,./;0-9]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaDayi4OutputFile);//.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateTradZhengmaDictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.ZhengmaDictStaticFile ,//.Array30DictStaticFile,
            FilePaths.tradDictSourceFile ,//.tradDictSourceFile,
            FilePaths.ZhengmatradDictOutputFile, //.Array30tradDictOutputFile,
            @"^\p{L}\t[a-z]+", // @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            systemName,
            version
        );
    }
    
    private void generateSimpZhengmaDictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.ZhengmaDictStaticFile ,//.Array30DictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.ZhengmasimpDictOutputFile ,//.Array30simpDictOutputFile,
            @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            systemName,
            version
        );
    }

    private void generateTradZhengmaSchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Zhengma codes"+
            "\r\n    based on: https://github.com/Openvingen/rime-zhengma/blob/master/zmbig.dict.yaml", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaZhengmaOutputFile);//.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpZhengmaSchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Zhengma codes"+
            "\r\n    based on: https://github.com/Openvingen/rime-zhengma/blob/master/zmbig.dict.yaml", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaZhengmaOutputFile); //.simpSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
   
    private void generateTradWubi86DictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.Wubi86DictStaticFile ,//.Array30DictStaticFile,
            FilePaths.tradDictSourceFile ,//.tradDictSourceFile,
            FilePaths.Wubi86tradDictOutputFile, //.Array30tradDictOutputFile,
            @"^\p{L}\t[a-z]+", // @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            systemName,
            version
        );
    }
    
    private void generateSimpWubi86DictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.Wubi86DictStaticFile ,//.Array30DictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.Wubi86simpDictOutputFile ,//.Array30simpDictOutputFile,
            @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            systemName,
            version
        );
    }

    private void generateTradWubi86SchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Wubi 86 codes"+
            "\r\n    based on: https://github.com/rime/rime-wubi", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaWubi86OutputFile);//.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpWubi86SchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Wubi 86 codes"+
            "\r\n    based on: https://github.com/rime/rime-wubi", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z]*$" //REVERSELOOKUP
        );

        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaWubi86OutputFile); //.simpSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateTradArray30DictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.Array30DictStaticFile,
            FilePaths.tradDictSourceFile,
            FilePaths.Array30tradDictOutputFile,
            @"^\p{L}\t[a-z,./;]+", // @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z,./;]+",
            systemName,
            version
        );
    }
    
    private void generateSimpArray30DictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.Array30DictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.Array30simpDictOutputFile,
            @"^\p{L}\t[a-z,./;]+",
            @"^\p{L}",
            @"\t[a-z,./;]+",
            systemName,
            version
        );
    }
    

    private void generateTradArray30SchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Array 30 codes"+
            "\r\n    based on: https://github.com/rime/rime-array", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z,./;]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpArray30SchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Array 30 codes"+
            "\r\n    based on: https://github.com/rime/rime-array", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z,./;]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaArray30OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    
    private void generateTradCangjieDictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.cangjie5DictStaticFile,
            FilePaths.tradDictSourceFile,
            FilePaths.cangjie5tradDictOutputFile,
            @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            systemName,
            version
        );
    }

    private void generateSimpCangjieDictForRime(
        string systemName, 
        string version)
    {
        GenerateAnyForeignInputMethod(
            FilePaths.cangjie5DictStaticFile,
            FilePaths.simpDictSourceFile,
            FilePaths.cangjie5simpDictOutputFile,
            @"^\p{L}\t[a-z]+",
            @"^\p{L}",
            @"\t[a-z]+",
            systemName,
            version
        );
    }
    

    private void generateTradCangjieSchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Cangjie5 codes"+
            "\r\n    based on: https://github.com/rime/rime-cangjie", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z,.]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.tradSchemaCangjie5OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
    private void generateSimpCangjieSchemaForRIME(
        string systemName, 
        string version, 
        string versionDate)
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            systemName, // SCHEMAID
            "cmlykke", // AUTHOR
            version, //VERSION
            "\r\n    Version date: " + 
            versionDate + 
            "\r\n    A translator of POF codes to Cangjie5 codes"+
            "\r\n    based on: https://github.com/rime/rime-cangjie", // \r\n    EXTRA\r\n    DESCRIPTION
            systemName, //DICTIONARY
            "`[a-z,.]*$" //REVERSELOOKUP
        ); 
        
        string simplifiedOutput = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaCangjie5OutputFile);
        
        string resultSimplified = generateInputDictforRimeFormat(testIntro);
        //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
        File.WriteAllText(simplifiedOutput, resultSimplified);     
    }
    
}