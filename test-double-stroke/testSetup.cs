﻿using double_stroke.projectFolder.FileMaps;
using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using test_double_stroke.testExceptions;
using test_double_stroke.testSchemdictValuesBeforePrint;

namespace test_double_stroke;

using double_stroke.projectFolder.StaticFileMaps;

public class testSetup
{
    
    protected static Dictionary<string, IdsBasicRecord> idsMap;
    protected static Dictionary<string, CodepointWithExceptionRecord> foundExceptions;
    protected static Dictionary<string, CodepointExceptionRecord> codeExceptionsFromIds;
    protected static Dictionary<string, CodepointExceptionRecord> codeExceptionsFromCodepoint;
    protected static Dictionary<string, FrequencyRecord> junda;
    protected static Dictionary<string, FrequencyRecord> tzai;
    protected static ExceptionHelper exceptionHelper = new ExceptionHelper();
    protected static GenerateIds genIds = new GenerateIds();
    protected static Dictionary<string, SchemeRecord> charToSchema;
    protected static Dictionary<string, HashSet<SchemeRecord>> codeToSchema;
    protected static Dictionary<string, FrequencyRecord> junda5001;
    protected static Dictionary<string, FrequencyRecord> tzai5001;
    protected static Dictionary<string, IdsRecur> idsrecur;

    
    [OneTimeSetUp]
    public void Setup()
    {
        
        //find exceptions in the CodeException file new UnicodeCharacter("手")
        string testDirectory = TestContext.CurrentContext.TestDirectory;

        string idsPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.idsPathStr);
        //"double-stroke\\projectFolder\\StaticFiles\\ids.txt";
            //@"..\..\..\..\double-stroke\projectFolder\StaticFiles\ids.txt");
        string codepointPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.codepointPathStr);
            //@"..\..\..\..\double-stroke\projectFolder\StaticFiles\codepoint-character-sequence.txt");
        string newPathForSaveFile = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.newPathForSaveFileStr);
        
            //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\idsMap.txt");
        
            //C:\Users\CMLyk\RiderProjects\cjk-double-stroke-input-V2\
            //double-stroke\projectFolder\StaticFiles\ids.txt
            /*
             'C:\Users\CMLyk\RiderProjects\cjk-double-stroke-input-V2\
             double-stroke\projectFolder\GeneratedFiles\idsMap.txt'.
             */
            /*
             C:\Users\CMLyk\RiderProjects\cjk-double-stroke-input-V2\
             bin\double-stroke\projectFolder\GeneratedFiles\idsMap.txt'.
             */
            /*
             C:\Users\CMLyk\RiderProjects\cjk-double-stroke-input-V2\
             bin\Debug\double-stroke\projectFolder\GeneratedFiles\idsMap.txt'
             */
            
        GenerateIds genIds = new GenerateIds();
        GenerateFileMaps gen = new GenerateFileMaps();
        CodeExceptions exp = new CodeExceptions();
        codeExceptionsFromIds = exp.generateCodeExceptionsFromCharacter();
        codeExceptionsFromCodepoint = exp.generateCodeExceptionsFromCodepoint();
        idsMap = genIds.readIdsMap(newPathForSaveFile);
        var codepointMap = UtilityFunctions.generateCodepointMap(
            codeExceptionsFromIds, idsMap, codepointPath);
        foundExceptions = gen.generateFoundEsceptionsMap(codepointMap, codeExceptionsFromIds, codeExceptionsFromCodepoint, idsMap);

        var isCharFoundExcep = foundExceptions.GetValueOrDefault("是");

        //var jundaPath = "../../../projectFolder/StaticFiles/Junda2005.txt";
        //var tzaiPath = "../../../projectFolder/StaticFiles/Tzai2006.txt";
        
        string jundaPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.jundaPathStr);
            //@"..\..\..\..\double-stroke\projectFolder\StaticFiles\Junda2005.txt");
        string tzaiPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.tzaiPathStr);
            //@"..\..\..\..\double-stroke\projectFolder\StaticFiles\Tzai2006.txt");
        
        junda = gen.generateJundaMap(jundaPath);
        tzai = gen.generateTzaiMap(tzaiPath);
        codeToSchema = getCodeToSchema();
        charToSchema = getCharToSchema();
        junda5001 = gen.extractFirst5001Junda(jundaPath);
        tzai5001 = gen.extractFirst5001Tzai(tzaiPath);
        //idsrecur = GenerateIdsRecursionMap.readZhengmaWords();
        string test = "";
    }
    
    private static Dictionary<string, HashSet<SchemeRecord>> getCodeToSchema()
    {
        List<SchemeRecord> schemeRecList = 
                            generateTestSchemeDict.schemeFromDictionary(foundExceptions, junda, tzai);
        Dictionary<string,HashSet<SchemeRecord>> codeToSchemas = 
                    GenerateSchema.generateCodeToSchema(schemeRecList);
        return codeToSchemas;
    }

    private static Dictionary<string, SchemeRecord> getCharToSchema()
    {
        List<SchemeRecord> schemeRecList = 
                    generateTestSchemeDict.schemeFromDictionary(foundExceptions, junda, tzai);
        
        Dictionary<string, SchemeRecord> charToSchema = 
                    GenerateSchema.generateCharToSchema(schemeRecList);
        return charToSchema;
    }
    
}