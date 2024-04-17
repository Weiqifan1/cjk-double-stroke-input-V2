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
       Assert.That(unknow.originalCodepoint.rawCodepoint, "121(35|53)");
       Assert.That(unknow.codepointAfterExceptionremoval,  "(35|53)");
       Assert.That(unknow.codepointExceptions.allAcceptableElems.Count, 1);
       Assert.That(unknow.codepointExceptions.allAcceptableElems[0], "扌");
       Assert.That(unknow.codepointExceptions.alphabetLetter.Value, "s");
       Assert.That(unknow.letter.Value, "竹");*/
        
        //test content of cookingPot
       Assert.That(cookingPot.originalCodepoint.rawCodepoint.Equals("(34|43)25243125111(5|21)54"));
       Assert.That(cookingPot.codepointAfterExceptionremoval.Equals("(34|43)25243125111(5|21)54"));
       Assert.That(cookingPot.codepointExceptions.Equals(null));
       Assert.That(cookingPot.letter.Value.Equals("甑"));
        
        //test content of 'throwing'
       Assert.That(throwing.originalCodepoint.rawCodepoint.Equals("121(35|53)"));
       Assert.That(throwing.codepointAfterExceptionremoval.Equals("(35|53)"));
       Assert.That(throwing.codepointExceptions.allAcceptableElems.Count.Equals(1));
       Assert.That(throwing.codepointExceptions.allAcceptableElems[0].Equals("扌"));
        //Assert.AreEqual(throwing.codepointExceptions.alphabetLetter.Value, "s");
       Assert.That(throwing.letter.Value.Equals("扔"));
        
        //dictionary count
       Assert.That(codepointWithExceptionsRec.Count.Equals(28098));
        Console.WriteLine("test end");
    }
}    