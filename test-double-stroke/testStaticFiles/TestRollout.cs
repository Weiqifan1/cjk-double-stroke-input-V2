using double_stroke.projectFolder.StaticFileMaps;

namespace test_double_stroke.testStaticFiles;

public class TestRollout: testSetup
{

    [Test]
    public void singleParenTest()
    {
        var test2 = foundExceptions.GetValueOrDefault("留");
        //(35352|35453)25121
        HashSet<string> result = RolloutStrokes.rolloutString(test2.originalCodepoint.rawCodepoint);

        HashSet<string> compare = new HashSet<string>();
        compare.Add("3535225121");
        compare.Add("3545325121");
        Assert.That(result.SetEquals(compare));
    }
    
    
    [Test]
    public void TwoParenTest()
    {
        var test2 = foundExceptions.GetValueOrDefault("甑");
        //(34|43)25243125111(5|21)54
        HashSet<string> result = RolloutStrokes.rolloutString(test2.originalCodepoint.rawCodepoint);

        HashSet<string> compare = new HashSet<string>();
        compare.Add("3425243125111554");
        compare.Add("34252431251112154");
        compare.Add("4325243125111554");
        compare.Add("43252431251112154");
        Assert.That(result.SetEquals(compare));
    }
    
    [Test]
    public void TestEmptyAlternative()
    {
        var test3 = foundExceptions.GetValueOrDefault("鰠");
        //35251214444544(|4)251214
        HashSet<string> result = RolloutStrokes.rolloutString(test3.originalCodepoint.rawCodepoint);

        HashSet<string> compare = new HashSet<string>();
        compare.Add("352512144445444251214");
        compare.Add("35251214444544251214");
        Assert.That(result.SetEquals(compare));
    }
    
    [Test]
    public void TestTrippleAlternative()
    {
        var test4 = foundExceptions.GetValueOrDefault("鵑");
        //251(2511|3511|3541)32511154444
        HashSet<string> result = RolloutStrokes.rolloutString(test4.originalCodepoint.rawCodepoint);

        HashSet<string> compare = new HashSet<string>();
        compare.Add("251251132511154444");
        compare.Add("251351132511154444");
        compare.Add("251354132511154444");
        Assert.That(result.SetEquals(compare));
    }
    
    [Test]
    public void TestHandleRepetition1Symbol()
    {
        var test9 = foundExceptions.GetValueOrDefault("鏵");
        //34112431(122|1212|2112)1\1112
        
        HashSet<string> result = RolloutStrokes.rolloutString(test9.originalCodepoint.rawCodepoint);

        HashSet<string> compare = new HashSet<string>();
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "34112431  122  1  122   112", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "34112431  122  1  1212   112", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "34112431  122  1  2112   112", @"\s", ""));
        
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "34112431  1212  1  122   112", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "34112431  1212  1  1212   112", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "34112431  1212  1  2112   112", @"\s", ""));
        
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "34112431  2112  1  122   112", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "34112431  2112  1  1212   112", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "34112431  2112  1  2112   112", @"\s", ""));
        
        Assert.That(result.SetEquals(compare));
    }
    
    [Test]
    public void TestHandleRepetitionMultipleSymbols()
    {
        string test = "1(1|2)2(4|5)3(6|7)4\\15\\36";
        HashSet<string> result = RolloutStrokes.rolloutString(test);

        HashSet<string> compare = new HashSet<string>();
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1   1   2   4   3   6   4  1  5  6    6", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1   1   2   5   3   7   4  2  5  6    6", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1   1   2   5   3   6   4  1  5  6    6", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1   2   2   5   3   7   4  2  5  7    6", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1   2   2   5   3   6   4  1  5  7    6", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1   2   2   5   3   7   4  2  5  7    6", @"\s", ""));

        foreach (var VARIABLE in compare)
        {
            Assert.That(result.Contains(VARIABLE));
        }
        
        Assert.That(result.Count.Equals(32));
    }


    [Test]
    public void TestHandleRepetitionOfThirdParen()
    {
        var test6 = foundExceptions.GetValueOrDefault("藣");
        //(122|1212|2112)2522154(2511|3511|3541)(15|35|53)\3
        
        HashSet<string> result = RolloutStrokes.rolloutString(test6.originalCodepoint.rawCodepoint);
        
        HashSet<string> compare = new HashSet<string>();
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1212  2522154  3511  35   53", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1212  2522154  3541  35   35", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1212  2522154  3541  35   53", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1212  2522154  3541  53   53", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "2112  2522154  3541  53   35", @"\s", ""));
        

        foreach (var VARIABLE in compare)
        {
            Assert.That(result.Contains(VARIABLE));
        }
        
        Assert.That(result.Count.Equals(81));
    }

    
    [Test]
    public void TestHandleTwoIdenticalRepetitionInSuccession()
    {
        var test8 = foundExceptions.GetValueOrDefault("譶");
        //(1111251|4111251)\1\1
        
        
        HashSet<string> result = RolloutStrokes.rolloutString(test8.originalCodepoint.rawCodepoint);
        
        HashSet<string> compare = new HashSet<string>();
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1111251  1111251  1111251", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1111251  1111251  4111251", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1111251  4111251  1111251", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "1111251  4111251  4111251", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "4111251  1111251  1111251", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "4111251  1111251  4111251", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "4111251  4111251  1111251", @"\s", ""));
        compare.Add(System.Text.RegularExpressions.Regex.Replace(
            "4111251  4111251  4111251", @"\s", ""));

        foreach (var VARIABLE in compare)
        {
            Assert.That(result.Contains(VARIABLE));
        }
        
        Assert.That(result.Count.Equals(8));
    }
    
}