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
        Assert.AreEqual( "g", primaryGen.gen21("1"));
        Assert.AreEqual( "f", primaryGen.gen21("12"));
        Assert.AreEqual( "ft", primaryGen.gen21("123"));
        Assert.AreEqual( "fw", primaryGen.gen21("1234"));
        Assert.AreEqual( "fwh", primaryGen.gen21("12345"));
        Assert.AreEqual( "fwh", primaryGen.gen21("123451"));
        Assert.AreEqual( "fwf", primaryGen.gen21("1234512"));
        Assert.AreEqual( "fwv", primaryGen.gen21("12345123"));
        Assert.AreEqual( "fww", primaryGen.gen21("123451234"));
        Assert.AreEqual( "fwp", primaryGen.gen21("1234512345"));
        Assert.AreEqual( "fwl", primaryGen.gen21("12345123454"));
        Assert.AreEqual( "fwi", primaryGen.gen21("123451234543"));
        Assert.AreEqual( "fwr", primaryGen.gen21("1234512345432"));
        Assert.AreEqual( "fwx", primaryGen.gen21("12345123454321"));
        
    }
    
    [Test]
    public void FirstAlphabetGeneratorTest_31()
    {
        Assert.AreEqual( "", primaryGen.gen31(""));
        Assert.AreEqual( "g", primaryGen.gen31("1"));
        Assert.AreEqual( "f", primaryGen.gen31("12"));
        Assert.AreEqual( "ft", primaryGen.gen31("123"));
        Assert.AreEqual( "fw", primaryGen.gen31("1234"));
        Assert.AreEqual( "fwh", primaryGen.gen31("12345"));
        Assert.AreEqual( "fwh", primaryGen.gen31("123451"));
        Assert.AreEqual( "fwhx", primaryGen.gen31("1234512"));
        Assert.AreEqual( "fwhv", primaryGen.gen31("12345123"));
        Assert.AreEqual( "fwhw", primaryGen.gen31("123451234"));
        Assert.AreEqual( "fwhp", primaryGen.gen31("1234512345"));
        Assert.AreEqual( "fwhl", primaryGen.gen31("12345123454"));
        Assert.AreEqual( "fwhi", primaryGen.gen31("123451234543"));
        Assert.AreEqual( "fwhr", primaryGen.gen31("1234512345432"));
        Assert.AreEqual( "fwhx", primaryGen.gen31("12345123454321"));
        
    }
    
    [Test]
    public void FirstAlphabetGeneratorTest_51()
    {
        Assert.AreEqual( "", primaryGen.gen31(""));
        Assert.AreEqual( "g", primaryGen.gen31("1"));
        Assert.AreEqual( "f", primaryGen.gen31("12"));
        Assert.AreEqual( "ft", primaryGen.gen31("123"));
        Assert.AreEqual( "fw", primaryGen.gen51("1234"));
        Assert.AreEqual( "fwh", primaryGen.gen51("12345"));
        Assert.AreEqual( "fwh", primaryGen.gen51("123451"));
        Assert.AreEqual( "fwhx", primaryGen.gen51("1234512"));
        Assert.AreEqual( "fwhv", primaryGen.gen51("12345123"));
        Assert.AreEqual( "fwhvy", primaryGen.gen51("123451234"));
        Assert.AreEqual( "fwhvp", primaryGen.gen51("1234512345"));
        Assert.AreEqual( "fwhvpy", primaryGen.gen51("12345123454"));
        Assert.AreEqual( "fwhvpi", primaryGen.gen51("123451234543"));
        Assert.AreEqual( "fwhvpr", primaryGen.gen51("1234512345432"));
        Assert.AreEqual( "fwhvpx", primaryGen.gen51("12345123454321"));
        
    }
    
}    