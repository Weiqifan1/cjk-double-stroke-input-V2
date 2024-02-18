namespace double_stroke.projectFolder.StaticFileMaps;

public static class CodeAlphabet
{

    public static Dictionary<string, string> generateStandardOneAlphabet()
    {

        Dictionary<string, string> result =
            new Dictionary<string, string>();
        result.Add("3", "t");
        result.Add("31", "t");
        result.Add("32", "r");
        result.Add("33", "e");
        result.Add("34", "w");
        result.Add("35", "q");
        
        result.Add("4", "y");
        result.Add("41", "y");
        result.Add("42", "u");
        result.Add("43", "i");
        result.Add("44", "o");
        result.Add("45", "p");
        
        result.Add("1", "g");
        result.Add("11", "g");
        result.Add("12", "f");
        result.Add("13", "d");
        result.Add("14", "s");
        result.Add("15", "a");
        
        result.Add("5", "h");
        result.Add("51", "h");
        result.Add("52", "j");
        result.Add("53", "k");
        result.Add("54", "l");
        result.Add("55", "m");
        
        result.Add("2", "x");
        result.Add("21", "x");
        result.Add("22", "c");
        result.Add("23", "v");
        result.Add("24", "b");
        result.Add("25", "n");
        
        //z should not be included
        return result;
    }
}