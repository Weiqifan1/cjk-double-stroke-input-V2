namespace test_double_stroke.testExceptions;
using double_stroke.projectFolder.StaticFileMaps;

public class test_handSmall : testSetup
{
    
    [Test]
    public void handSmall_ThatShouldHaveBeenThere()
    {
        var mydict = foundExceptions;
        
        var handFull =
            exceptionHelper.FiltDict_hasCodeNotIds(
                mydict, 
                new() {"121"},
                new()
                {
                    "十",
                    "土",
                    "扌"
                });
        var handfullClean = exceptionHelper.displayDict(handFull);
        
        //执 is not split
        var smallhandEdge = mydict["执"];
        
        //handfullClean have been looked through and no characters seem missing
        Assert.That(129.Equals(handfullClean.Count), "Result should be 4");
    }
    
    
}