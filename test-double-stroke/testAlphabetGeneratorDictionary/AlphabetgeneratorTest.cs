namespace test_double_stroke.testAlphabetGeneratorDictionary;
    
using double_stroke.projectFolder.StaticFileMaps;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using test_double_stroke;

public class AlphabetgeneratorTest
{

    private AlphabetGenerator primaryGen;
    
    [OneTimeSetUp]
    public void Setup()
    {
        AlphabetGenerator alphabetGen = new AlphabetGenerator(CodeAlphabet.generateStandardOneAlphabet());
        this.primaryGen = alphabetGen;
    }

    [Test]
    public void FirstAlphabetGeneratorTest_21()
    {
        Assert.AreEqual( "", primaryGen.gen21(""));
        Assert.AreEqual( "h", primaryGen.gen21("1"));
        Assert.AreEqual( "j", primaryGen.gen21("12"));
        Assert.AreEqual( "jt", primaryGen.gen21("123"));
        Assert.AreEqual( "jw", primaryGen.gen21("1234"));
        Assert.AreEqual( "jwg", primaryGen.gen21("12345"));
        Assert.AreEqual( "jwg", primaryGen.gen21("123451"));
        Assert.AreEqual( "jwj", primaryGen.gen21("1234512"));
        Assert.AreEqual( "jwv", primaryGen.gen21("12345123"));
        Assert.AreEqual( "jww", primaryGen.gen21("123451234"));
        Assert.AreEqual( "jwp", primaryGen.gen21("1234512345"));
        Assert.AreEqual( "jws", primaryGen.gen21("12345123454"));
        Assert.AreEqual( "jwi", primaryGen.gen21("123451234543"));
        Assert.AreEqual( "jwr", primaryGen.gen21("1234512345432"));
        Assert.AreEqual( "jwn", primaryGen.gen21("12345123454321"));
        
    }
    
    [Test]
    public void FirstAlphabetGeneratorTest_31()
    {
        Assert.AreEqual( "", primaryGen.gen31(""));
        Assert.AreEqual( "h", primaryGen.gen31("1"));
        Assert.AreEqual( "j", primaryGen.gen31("12"));
        Assert.AreEqual( "jt", primaryGen.gen31("123"));
        Assert.AreEqual( "jw", primaryGen.gen31("1234"));
        Assert.AreEqual( "jwg", primaryGen.gen31("12345"));
        Assert.AreEqual( "jwg", primaryGen.gen31("123451"));
        Assert.AreEqual( "jwgn", primaryGen.gen31("1234512"));
        Assert.AreEqual( "jwgv", primaryGen.gen31("12345123"));
        Assert.AreEqual( "jwgw", primaryGen.gen31("123451234"));
        Assert.AreEqual( "jwgp", primaryGen.gen31("1234512345"));
        Assert.AreEqual( "jwgs", primaryGen.gen31("12345123454"));
        Assert.AreEqual( "jwgi", primaryGen.gen31("123451234543"));
        Assert.AreEqual( "jwgr", primaryGen.gen31("1234512345432"));
        Assert.AreEqual( "jwgn", primaryGen.gen31("12345123454321"));
        
    }
    
    [Test]
    public void FirstAlphabetGeneratorTest_51()
    {
        Assert.AreEqual( "", primaryGen.gen31(""));
        Assert.AreEqual( "h", primaryGen.gen31("1"));
        Assert.AreEqual( "j", primaryGen.gen31("12"));
        Assert.AreEqual( "jt", primaryGen.gen31("123"));
        Assert.AreEqual( "jw", primaryGen.gen51("1234"));
        Assert.AreEqual( "jwg", primaryGen.gen51("12345"));
        Assert.AreEqual( "jwg", primaryGen.gen51("123451"));
        Assert.AreEqual( "jwgn", primaryGen.gen51("1234512"));
        Assert.AreEqual( "jwgv", primaryGen.gen51("12345123"));
        Assert.AreEqual( "jwgvy", primaryGen.gen51("123451234"));
        Assert.AreEqual( "jwgvp", primaryGen.gen51("1234512345"));
        Assert.AreEqual( "jwgvpy", primaryGen.gen51("12345123454"));
        Assert.AreEqual( "jwgvpi", primaryGen.gen51("123451234543"));
        Assert.AreEqual( "jwgvpr", primaryGen.gen51("1234512345432"));
        Assert.AreEqual( "jwgvpn", primaryGen.gen51("12345123454321"));
        
    }
    
}    