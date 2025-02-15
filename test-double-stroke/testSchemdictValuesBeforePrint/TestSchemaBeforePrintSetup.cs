﻿using double_stroke.projectFolder.FileMaps.GenerateFilesController;

namespace test_double_stroke.testSchemdictValuesBeforePrint;

using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

public class TestSchemaBeforePrintSetup
{
    public int jundaFreq5001 = 183;
    public int tzaiFreq5001 = 88;
   
    public static JsonSerializerOptions options = new JsonSerializerOptions();
    public static string testDirectory = TestContext.CurrentContext.TestDirectory;
    public static string charToSchemaPath = Path.Combine(testDirectory,
        FilePaths.dotsAndSlash + FilePaths.charToSchemaPathStr);    
    //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\charToSchemaMap.txt");
    public static string codeToSchemaPath = Path.Combine(testDirectory,
        FilePaths.dotsAndSlash + FilePaths.codeToSchemaPathStr);    
    //@"..\..\..\..\double-stroke\projectFolder\GeneratedFiles\codeToSchemaMap.txt");
    public Dictionary<string, SchemeRecord> charToSchemaDict;
    public Dictionary<string, HashSet<SchemeRecord>> codeToSchemaDict;

    public Dictionary<string, List<SchemeRecord>> simplifiedDictList;
    public Dictionary<string, List<SchemeRecord>> traditionalDictList;
    public List<Dictionary<string, List<SchemeRecord>>> simplifiedListDictList;
    public List<Dictionary<string, List<SchemeRecord>>> traditionalListDictList;
    public List<List<Tuple<string, List<SchemeRecord>>>> simplifiedListListTupples;
    public List<List<Tuple<string, List<SchemeRecord>>>> traditionalListListTupples;
    public List<Tuple<string, SchemeRecord>> simplifiedListTuples;
    public List<Tuple<string, SchemeRecord>> traditionalListTuples;
    public List<string> simplifiedOutputList;
    public List<string> traditionalOutputList;
    public Dictionary<string, AlternativeCharsetRecord> heisigSimp;
    public Dictionary<string, AlternativeCharsetRecord> heisigTrad;
    
    [OneTimeSetUp]
    public void Setup()
    {
        string charToSchemaJson = File.ReadAllText(charToSchemaPath);
        string codeToSchemaJson = File.ReadAllText(codeToSchemaPath);
        GenerateFileMaps generateFileMaps = new GenerateFileMaps();
        charToSchemaDict = 
            JsonSerializer.Deserialize<Dictionary<string, SchemeRecord>>(charToSchemaJson, options);
        
        codeToSchemaDict = 
            JsonSerializer.Deserialize<Dictionary<string, HashSet<SchemeRecord>>>(codeToSchemaJson, options);

        heisigSimp = generateFileMaps.generateHeisigSimpMap();
        heisigTrad = generateFileMaps.generateHeisigTradMap();
        
        simplifiedDictList = createListOfStringReadyForPrint
            .replaceHashSetToList(true, codeToSchemaDict);
        traditionalDictList = createListOfStringReadyForPrint
            .replaceHashSetToList(false, codeToSchemaDict);
        
        simplifiedListDictList = createListOfStringReadyForPrint.splicIntoCodeLengths(simplifiedDictList);
        traditionalListDictList= createListOfStringReadyForPrint.splicIntoCodeLengths(traditionalDictList);

        simplifiedListListTupples = 
            createListOfStringReadyForPrint.getNestedListFromListOfDicts(simplifiedListDictList);
        traditionalListListTupples =
            createListOfStringReadyForPrint.getNestedListFromListOfDicts(traditionalListDictList);

        simplifiedListTuples = createListOfStringReadyForPrint.getSortedListOfTuples(simplifiedListListTupples);
        traditionalListTuples = createListOfStringReadyForPrint.getSortedListOfTuples(traditionalListListTupples);

        simplifiedOutputList = createListOfStringReadyForPrint.listOfTuplesToStringsJuda(simplifiedListTuples);
        traditionalOutputList = createListOfStringReadyForPrint.listOfTuplesToStringsTzai(traditionalListTuples);
        
        GenerateFileMaps gen = new GenerateFileMaps();
        string jundaPath = Path.Combine(testDirectory, 
                             FilePaths.dotsAndSlash + FilePaths.jundaPathStr);
                             //@"..\..\..\..\double-stroke\projectFolder\StaticFiles\Junda2005.txt");
        string tzaiPath = Path.Combine(testDirectory, 
                             FilePaths.dotsAndSlash + FilePaths.tzaiPathStr);
        
        string test = "";
    }

    /*
    private Dictionary<string, List<SchemeRecord>> simplifiedDictList;
    private Dictionary<string, List<SchemeRecord>> traditionalDictList;
    private List<Dictionary<string, List<SchemeRecord>>> simplifiedListDictList;
    private List<Dictionary<string, List<SchemeRecord>>> traditionalListDictList;
    private List<List<Tuple<string, List<SchemeRecord>>>> simplifiedListListTupples;
    private List<List<Tuple<string, List<SchemeRecord>>>> traditionalListListTupples;
    private List<Tuple<string, SchemeRecord>> simplifiedListTuples;
    private List<Tuple<string, SchemeRecord>> traditionalListTuples;
    private List<string> simplifiedListString;
    private List<string> traditionalListString;
     */
    
}