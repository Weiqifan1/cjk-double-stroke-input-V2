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
        
        result.Add("1", "h");
        result.Add("11", "h");
        result.Add("12", "j");
        result.Add("13", "k");
        result.Add("14", "l");
        result.Add("15", "m");
        
        result.Add("5", "g");
        result.Add("51", "g");
        result.Add("52", "f");
        result.Add("53", "d");
        result.Add("54", "s");
        result.Add("55", "a");
        
        result.Add("2", "n");
        result.Add("21", "n");
        result.Add("22", "b");
        result.Add("23", "v");
        result.Add("24", "c");
        result.Add("25", "x");
        
        //z should not be included
        return result;
    }
    
    public static Dictionary<string, string> generateUmbrellaShapeAlphabet()
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
        
        result.Add("1", "h");
        result.Add("11", "h");
        result.Add("12", "j");
        result.Add("13", "k");
        result.Add("14", "l");
        result.Add("15", "m");
        
        result.Add("5", "g");
        result.Add("51", "g");
        result.Add("52", "f");
        result.Add("53", "d");
        result.Add("54", "s");
        result.Add("55", "a");
        
        result.Add("2", "n");
        result.Add("21", "n");
        result.Add("22", "b");
        result.Add("23", "v");
        result.Add("24", "c");
        result.Add("25", "x");
        
        //z should not be included
        return result;
    }
}