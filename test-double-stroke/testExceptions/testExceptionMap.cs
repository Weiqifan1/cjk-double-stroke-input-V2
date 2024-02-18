namespace test_double_stroke.testExceptions;

public class testExceptionMap : testSetup
{
    [Test]
    public void testISChar()
    {
        var mydict = foundExceptions;

        var isChar = mydict.GetValueOrDefault("是");

        string test = "";
/*
        var handFull =
            exceptionHelper.FiltDict_hasCodeNotIds(
                mydict, new() {"3112"}, new() {"手"});
        var handfullClean = exceptionHelper.displayDict(handFull);

        //handfullClean have been looked through and no characters seem missing
        Assert.AreEqual(69, handfullClean.Count, "Result should be 4");*/
    }

}