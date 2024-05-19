using double_stroke.projectFolder.StaticFileMaps;
using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.RegularExpressions;
using double_stroke.projectFolder.FileMaps;
using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace test_double_stroke.testSchemdictValuesBeforePrint;


public class TestForeignInputMethods: TestSchemaBeforePrintSetup
{
    private List<SchemeRecord> schemeRecList;

    [Test]
    public void testPOFforeignDictIntro()
    {
        List<string> testIntro = UtilityFunctions.introTextForDict("POFsimp", "1.0");
        
        string simpDictPath = Path.Combine(testDirectory, 
            FilePaths.dotsAndSlash + FilePaths.simpDictSourceFile);
        var simpDictFile = UtilityFunctions.ReadLinesFromFile(simpDictPath);
        
        string test = "";
    }
    

    [Test]
    public void testCangjie()
    {
        
        Assert.IsTrue(cangjie5.Count == 30412);

    }

    
/*
    [Test]
    public void testPOFforeignSchemaIntro()
    {
        List<string> testIntro = UtilityFunctions.introTextForSchema(
            "POFsimp", // SCHEMAID
            "cmlykke", // AUTHOR
            "1.0", //VERSION
            "", // \r\n    EXTRA\r\n    DESCRIPTION
            "POFsimp", //DICTIONARY
            "`[a-z,.]*$" //REVERSELOOKUP
            );

        string simpSchemaPath = Path.Combine(testDirectory,
            FilePaths.dotsAndSlash + FilePaths.simpSchemaSourceFile);
        var simpSchemaFile = UtilityFunctions.ReadLinesFromFile(simpSchemaPath);
        Assert.IsTrue(simpSchemaFile.Count == testIntro.Count);
        for (int i = 0; i < testIntro.Count; i++)
        {
            string testtwo = "";
            string testIntroLine = testIntro[i];
            string rawschemaline = simpSchemaFile[i];
            if (i == 60)
            {
                string counttest;
            }

            Assert.IsTrue(simpSchemaFile[i] == testIntro[i]);
        }

        Assert.IsTrue(simpSchemaFile.SequenceEqual(testIntro));

        string test = "";
    }
    */
    
    /*
    [Test]
    public void handNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "手");

        //Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s", "tf"}));
        //Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        //Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }*/
}
