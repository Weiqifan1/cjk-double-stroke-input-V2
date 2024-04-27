using double_stroke.projectFolder.StaticFileMaps;
using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.RegularExpressions;
using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace test_double_stroke.testSchemdictValuesBeforePrint;


public class TestForeignInputMethods: testSetup
{
    private List<SchemeRecord> schemeRecList;
 
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
