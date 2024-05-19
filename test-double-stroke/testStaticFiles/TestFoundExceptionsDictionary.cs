namespace test_double_stroke.testStaticFiles;
   

using double_stroke.projectFolder.StaticFileMaps;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using test_double_stroke;


public class TestFoundExceptionsDictionary : testSetup
{
    

    [Test]
    public void IdentifyMissingJundaAndTzaiCharacters()
    {
        GenerateFileMaps gen = new GenerateFileMaps();
        
        Dictionary<string, CodepointWithExceptionRecord> codepointWithExceptionsRec = foundExceptions;

        CodepointWithExceptionRecord unknow = codepointWithExceptionsRec.GetValueOrDefault("签");
        CodepointWithExceptionRecord cookingPot = codepointWithExceptionsRec.GetValueOrDefault("甑");
        CodepointWithExceptionRecord throwing = codepointWithExceptionsRec.GetValueOrDefault("扔");
        
        /*
        //test content of 'unknow'
        Assert.AreEqual(unknow.originalCodepoint.rawCodepoint, "121(35|53)");
        Assert.AreEqual(unknow.codepointAfterExceptionremoval,  "(35|53)");
        Assert.AreEqual(unknow.codepointExceptions.allAcceptableElems.Count, 1);
        Assert.AreEqual(unknow.codepointExceptions.allAcceptableElems[0], "扌");
        Assert.AreEqual(unknow.codepointExceptions.alphabetLetter.Value, "s");
        Assert.AreEqual(unknow.letter.Value, "竹");*/
        
        //test content of cookingPot
        Assert.AreEqual(cookingPot.originalCodepoint.rawCodepoint, "(34|43)25243125111(5|21)54");
        Assert.AreEqual(cookingPot.codepointAfterExceptionremoval,  "(34|43)25243125111(5|21)54");
        Assert.AreEqual(cookingPot.codepointExceptions, null);
        Assert.AreEqual(cookingPot.letter.Value, "甑");
        
        //test content of 'throwing'
        Assert.AreEqual(throwing.originalCodepoint.rawCodepoint, "121(35|53)");
        Assert.AreEqual(throwing.codepointAfterExceptionremoval,  "(35|53)");
        Assert.AreEqual(throwing.codepointExceptions.allAcceptableElems.Count, 1);
        Assert.AreEqual(throwing.codepointExceptions.allAcceptableElems[0], "扌");
        //Assert.AreEqual(throwing.codepointExceptions.alphabetLetter.Value, "s");
        Assert.AreEqual(throwing.letter.Value, "扔");
        
        //dictionary count
        Assert.AreEqual(28098, codepointWithExceptionsRec.Count);
        Console.WriteLine("test end");
    }
}    