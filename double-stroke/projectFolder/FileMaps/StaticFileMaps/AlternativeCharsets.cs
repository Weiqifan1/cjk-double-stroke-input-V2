using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using System;
using System.Globalization;

namespace double_stroke.projectFolder.StaticFileMaps;

public static class AlternativeCharsets
{

    public static HashSet<string> getAllchars()
    {
        var guk = GetAllCharsFromFile(FilePaths.dotsAndSlash + FilePaths.wikigukja);
        var sek = GetAllCharsFromFile(FilePaths.dotsAndSlash + FilePaths.wikihk);
        var thi = GetAllCharsFromFile(FilePaths.dotsAndSlash + FilePaths.wikijis);
        var forth = GetAllCharsFromFile(FilePaths.dotsAndSlash + FilePaths.wikijooyo);
        HashSet<string> allchars = new HashSet<string>();
        allchars.UnionWith(guk);
        allchars.UnionWith(sek);
        allchars.UnionWith(thi);
        allchars.UnionWith(forth);
        return allchars;
    }
/*
    public void IterateString(string text)
    {
        

        while (charEnum.MoveNext())
        {
            
            int index = charEnum.ElementIndex;

            Console.WriteLine($"Character at index {index}: {textElement}");
        }
    }*/
    
    private static HashSet<string> GetAllCharsFromFile(string filePath)
    {
        HashSet<string> unused = new HashSet<string>();
        HashSet<string> distinctChars = new HashSet<string>();
        try
        {
            // Read all text from the file
            var fileContent = File.ReadAllText(filePath);
            
            TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(fileContent);
            // Enumerate the string, treating it as a sequence of Unicode code points, not a sequence of .NET Char objects. 
            // This is necessary to correctly handle Unicode characters that are outside the Basic Multilingual Plane (BMP). 
            // The C# foreach statement processes text in Unicode "surrogate pairs", where each pair forms a single Unicode code point.
            while (charEnum.MoveNext())
            {
                string textElement = charEnum.GetTextElement();
                // Get Unicode code point at the current position.
                int codePoint = char.ConvertToUtf32(textElement, 0);
                // Add all distinct characters to the list
                if (codePoint == 3050)
                {
                    string test = "";
                }
                //Point + "";
                if (textElement.Equals("ぬ"))
                {
                    string test = "";
                }
                if (acceptableCodepoints(codePoint, textElement)) //> 11903)
                {
                    distinctChars.Add(textElement);
                }
                else
                {
                    unused.Add(textElement);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return distinctChars;
    }

    
    /*
    
    private static HashSet<string> GetAllCharsFromFile(string filePath)
    {
        HashSet<string> unused = new HashSet<string>();
        HashSet<string> distinctChars = new HashSet<string>();
        try
        {
            // Read all text from the file
            var fileContent = File.ReadAllText(filePath);
            
            
            // Enumerate the string, treating it as a sequence of Unicode code points, not a sequence of .NET Char objects. 
            // This is necessary to correctly handle Unicode characters that are outside the Basic Multilingual Plane (BMP). 
            // The C# foreach statement processes text in Unicode "surrogate pairs", where each pair forms a single Unicode code point.
            for (int i = 0; i < fileContent.Length; i += char.IsSurrogatePair(fileContent, i) ? 2 : 1)
            {
                // Get Unicode code point at the current position.
                int codePoint = char.ConvertToUtf32(fileContent, i);
                // Add all distinct characters to the list
                if (codePoint == 3050)
                {
                    string test = "";
                }
                string codeToChar = (char)codePoint + "";
                if (codeToChar.Equals("ぬ"))
                {
                    string test = "";
                }
                if (acceptableCodepoints(codePoint, codeToChar)) //> 11903)
                {
                    distinctChars.Add(codeToChar);
                }
                else
                {
                    unused.Add(codeToChar);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return distinctChars;
    }
     */
    
    private static bool acceptableCodepoints(int codePoint, string codeToChar)
    {
        if (codeToChar.Equals("Č"))
        {
            string test = "";
        }

        var min = 11903;
        Range kana = 12352..12544;
        if (codePoint >= kana.Start.Value && codePoint <= kana.End.Value)
        {
            return false;
        } else if (codePoint > min)
        {
            return true;
        }

        return false;
    }
}