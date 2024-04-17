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
        Assert.That( "".Equals(primaryGen.gen21("")));
        Assert.That( "h".Equals(primaryGen.gen21("1")));
        Assert.That( "j".Equals(primaryGen.gen21("12")));
        Assert.That( "jt".Equals(primaryGen.gen21("123")));
        Assert.That( "jw".Equals(primaryGen.gen21("1234")));
        Assert.That( "jwg".Equals(primaryGen.gen21("12345")));
        Assert.That( "jwg".Equals(primaryGen.gen21("123451")));
        Assert.That( "jwj".Equals(primaryGen.gen21("1234512")));
        Assert.That( "jwv".Equals(primaryGen.gen21("12345123")));
        Assert.That( "jww".Equals(primaryGen.gen21("123451234")));
        Assert.That( "jwp".Equals(primaryGen.gen21("1234512345")));
        Assert.That( "jws".Equals(primaryGen.gen21("12345123454")));
        Assert.That( "jwi".Equals(primaryGen.gen21("123451234543")));
        Assert.That( "jwr".Equals(primaryGen.gen21("1234512345432")));
        Assert.That( "jwn".Equals(primaryGen.gen21("12345123454321")));
        
    }
    
    [Test]
    public void FirstAlphabetGeneratorTest_31()
    {
        Assert.That( "".Equals(primaryGen.gen31("")));
        Assert.That( "h".Equals(primaryGen.gen31("1")));
        Assert.That( "j".Equals(primaryGen.gen31("12")));
        Assert.That( "jt".Equals(primaryGen.gen31("123")));
        Assert.That( "jw".Equals(primaryGen.gen31("1234")));
        Assert.That( "jwg".Equals(primaryGen.gen31("12345")));
        Assert.That( "jwg".Equals(primaryGen.gen31("123451")));
        Assert.That( "jwgn".Equals(primaryGen.gen31("1234512")));
        Assert.That( "jwgv".Equals(primaryGen.gen31("12345123")));
        Assert.That( "jwgw".Equals(primaryGen.gen31("123451234")));
        Assert.That( "jwgp".Equals(primaryGen.gen31("1234512345")));
        Assert.That( "jwgs".Equals(primaryGen.gen31("12345123454")));
        Assert.That( "jwgi".Equals(primaryGen.gen31("123451234543")));
        Assert.That( "jwgr".Equals(primaryGen.gen31("1234512345432")));
        Assert.That( "jwgn".Equals(primaryGen.gen31("12345123454321")));
        
    }
    
    [Test]
    public void FirstAlphabetGeneratorTest_51()
    {
        Assert.That( "".Equals(primaryGen.gen31("")));
        Assert.That( "h".Equals(primaryGen.gen31("1")));
        Assert.That( "j".Equals(primaryGen.gen31("12")));
        Assert.That( "jt".Equals(primaryGen.gen31("123")));
        Assert.That( "jw".Equals(primaryGen.gen51("1234")));
        Assert.That( "jwg".Equals(primaryGen.gen51("12345")));
        Assert.That( "jwg".Equals(primaryGen.gen51("123451")));
        Assert.That( "jwgn".Equals(primaryGen.gen51("1234512")));
        Assert.That( "jwgv".Equals(primaryGen.gen51("12345123")));
        Assert.That( "jwgvy".Equals(primaryGen.gen51("123451234")));
        Assert.That( "jwgvp".Equals(primaryGen.gen51("1234512345")));
        Assert.That( "jwgvpy".Equals(primaryGen.gen51("12345123454")));
        Assert.That( "jwgvpi".Equals(primaryGen.gen51("123451234543")));
        Assert.That( "jwgvpr".Equals(primaryGen.gen51("1234512345432")));
        Assert.That( "jwgvpn".Equals(primaryGen.gen51("12345123454321")));
        
    }
    
}    