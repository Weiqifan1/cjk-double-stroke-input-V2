using System.Net.Mail;

namespace double_stroke.projectFolder.StaticFileMaps;

public class AlphabetGenerator
{
    private Dictionary<string, string> currentAlphabet;

    public AlphabetGenerator(Dictionary<string, string> currentAlphabet)
    {
        this.currentAlphabet = currentAlphabet;
    }


    public string gen51(string inputNumberCode)
    {
        string result = "";
        if (inputNumberCode.Length == 0)
        {
            result = "";
        } else if (
            inputNumberCode.Length < 12 
            && inputNumberCode.Length % 2 == 0)
        {
            result = genEven(inputNumberCode);
        } else if (inputNumberCode.Length < 12 
                   && inputNumberCode.Length % 2 == 1)
        {
            result = genUneven(inputNumberCode);
        }
        else
        {
            result = gen51LenOver11(inputNumberCode);
        }

        return result;
    }

    
    private string gen51LenOver11(string inputNumberCode)
    {
        
        List<string> head = SplitEvenStringIntoPairs(inputNumberCode.Substring(0, 10));
        List<string> tail = SplitEvenStringIntoPairs(inputNumberCode.Substring(inputNumberCode.Length-2));
        List<string> touse = new List<string>{head[0],head[1],head[2],head[3],head[4],tail[0]};
        List<string> converted = touse.Select(x => currentAlphabet.GetValueOrDefault(x)).ToList();
        string result = string.Join("", converted);
        return result;
    }

    public string gen31(string inputNumberCode)
    {
        string result = "";
        if (inputNumberCode.Length == 0)
        {
            result = "";
        } else if (
            inputNumberCode.Length < 8 
            && inputNumberCode.Length % 2 == 0)
        {
            result = genEven(inputNumberCode);
        } else if (inputNumberCode.Length < 8 
                   && inputNumberCode.Length % 2 == 1)
        {
            result = genUneven(inputNumberCode);
        }
        else
        {
            result = gen31LenOver7(inputNumberCode);
        }

        return result;
    }

    
    public string gen21(string inputNumberCode)
    {
        string result = "";
        if (inputNumberCode.Length == 0)
        {
            result = "";
        } else if (
            inputNumberCode.Length < 6 
            && inputNumberCode.Length % 2 == 0)
        {
            result = genEven(inputNumberCode);
        } else if (inputNumberCode.Length < 6 
                   && inputNumberCode.Length % 2 == 1)
        {
            result = genUneven(inputNumberCode);
        }
        else
        {
            result = gen21LenOver5(inputNumberCode);
        }

        return result;
    }

    private string gen21LenOver5(string inputNumberCode)
    {
        List<string> head = SplitEvenStringIntoPairs(inputNumberCode.Substring(0, 4));
        List<string> tail = SplitEvenStringIntoPairs(inputNumberCode.Substring(inputNumberCode.Length-2));
        List<string> touse = new List<string>{head[0],head[1],tail[0]};
        List<string> converted = touse.Select(x => currentAlphabet.GetValueOrDefault(x)).ToList();
        string result = string.Join("", converted);
        return result;
    }

    private string genEven(string inputNumberCode)
    {
        List<string> head = SplitEvenStringIntoPairs(inputNumberCode);
        List<string> touse = head;
        
        List<string> converted = touse.Select(x => currentAlphabet.GetValueOrDefault(x)).ToList();
        string result = string.Join("", converted);
        return result;
    }

    private string genUneven(string inputNumberCode)
    {
        string minOne = inputNumberCode.Substring(inputNumberCode.Length-1);
        string first = inputNumberCode.Substring(0, inputNumberCode.Length - 1);
        List<string> head = SplitEvenStringIntoPairs(first);
        List<string> touse = head;
        touse.Add(minOne);
        
        List<string> converted = touse.Select(x => currentAlphabet.GetValueOrDefault(x)).ToList();
        string result = string.Join("", converted);
        return result;
    }

    private string gen31LenOver7(string inputNumberCode)
    {
        List<string> head = SplitEvenStringIntoPairs(inputNumberCode.Substring(0, 6));
        List<string> tail = SplitEvenStringIntoPairs(inputNumberCode.Substring(inputNumberCode.Length-2));
        List<string> touse = new List<string>{head[0],head[1],head[2],tail[0]};
        List<string> converted = touse.Select(x => currentAlphabet.GetValueOrDefault(x)).ToList();
        string result = string.Join("", converted);
        return result;
    }
    
    private List<string> SplitEvenStringIntoPairs(string input)
    {
        if (input.Length % 2 != 0)
        {
            throw new ArgumentException("Input string length must be even");
        }

        var result = new List<string>();

        for (int i = 0; i < input.Length; i += 2)
        {
            result.Add(input.Substring(i, 2));
        }

        return result;
    }

}