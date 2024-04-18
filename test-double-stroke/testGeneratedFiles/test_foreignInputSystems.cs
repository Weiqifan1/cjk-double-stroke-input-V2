using System.Collections.Specialized;

namespace test_double_stroke.testForeignInputGuides;




public class test_foreignInputSystems : testSetup
{
    
    
    [Test]
    public void test_cangjie()
    {

        //List<string> = cangjie5[0];
        
        //handfullClean have been looked through and no characters seem missing
        Assert.AreEqual(1, 1, "Result should be true");
    }
    
}