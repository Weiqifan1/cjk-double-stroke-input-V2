namespace test_double_stroke.testExceptions;


using double_stroke.projectFolder.StaticFileMaps;


public class test_handFull : testSetup
{
    
    
    [Test]
    public void handFull_ThatShouldHaveBeenThere()
    {
        var mydict = foundExceptions;

        var handFull =
            exceptionHelper.FiltDict_hasCodeNotIds(
                mydict, new() {"3112"}, new() {"手"});
        var handfullClean = exceptionHelper.displayDict(handFull);

        //handfullClean have been looked through and no characters seem missing
        Assert.That(handfullClean.Count.Equals(69));
    }
    
}