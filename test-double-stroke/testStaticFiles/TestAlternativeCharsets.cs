﻿using double_stroke.projectFolder.StaticFileMaps;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace test_double_stroke.testStaticFiles;


public class TestAlternativeCharsets: testSetup
{
    //AlternativeCharsets
          
    [Test]
    public void GukjaMissing()
    {
        HashSet<string> allChars = AlternativeCharsets.getGukja();
        HashSet<string> miss = getMissing(allChars);
        Dictionary<string, List<string>> sorted = GroupByUnicodeBlock(miss);//new Dictionary<string, List<string>>()
        Assert.IsTrue(sorted.Count == 1);
        var otherLet = sorted.GetValueOrDefault("OtherLetter");
        Assert.IsTrue(otherLet.Count == 2);
    }

     
    [Test]
    public void HongkongMissing()
    {
        HashSet<string> allChars = AlternativeCharsets.getHongkong2016();
        HashSet<string> miss = getMissing(allChars);
        Dictionary<string, List<string>> sorted = GroupByUnicodeBlock(miss);//new Dictionary<string, List<string>>();
        Assert.IsTrue(sorted.Count == 9);
        var OtherSymbol = sorted.GetValueOrDefault("OtherSymbol");
        var ModifierLetter = sorted.GetValueOrDefault("ModifierLetter");
        var OtherLetter = sorted.GetValueOrDefault("OtherLetter");
        var LetterNumber = sorted.GetValueOrDefault("LetterNumber");
        var OpenPunctuation = sorted.GetValueOrDefault("OpenPunctuation");
        var ClosePunctuation = sorted.GetValueOrDefault("ClosePunctuation"); 
        var MathSymbol = sorted.GetValueOrDefault("MathSymbol");
        var OtherPunctuation = sorted.GetValueOrDefault("OtherPunctuation");
        var PrivateUse = sorted.GetValueOrDefault("PrivateUse");
        
        Assert.IsTrue(OtherSymbol.Count == 48);
        Assert.IsTrue(ModifierLetter.Count == 1);
        Assert.IsTrue(OtherLetter.Count == 1370);
        Assert.IsTrue(LetterNumber.Count == 1);
        Assert.IsTrue(OpenPunctuation.Count == 1);
        Assert.IsTrue(ClosePunctuation.Count == 1);
        Assert.IsTrue(MathSymbol.Count == 1);
        Assert.IsTrue(OtherPunctuation.Count == 2);
        Assert.IsTrue(PrivateUse.Count == 16);
        
    }

     
    [Test]
    public void JISX0208Missing()
    {
        HashSet<string> allChars = AlternativeCharsets.getJISX0208();
        HashSet<string> miss = getMissing(allChars);
        Dictionary<string, List<string>> sorted = GroupByUnicodeBlock(miss);//new Dictionary<string, List<string>>();
        Assert.IsTrue(sorted.Count == 3);
        var ModifierLetter = sorted.GetValueOrDefault("ModifierLetter");
        var OtherLetter = sorted.GetValueOrDefault("OtherLetter");
        var LetterNumber = sorted.GetValueOrDefault("LetterNumber");
        
        Assert.IsTrue(ModifierLetter.Count == 1);
        Assert.IsTrue(OtherLetter.Count == 1);
        Assert.IsTrue(LetterNumber.Count == 1);
    }
 
    [Test]
    public void JoyoMissing()
    {
        HashSet<string> allChars = AlternativeCharsets.getJoyo();
        HashSet<string> miss = getMissing(allChars);
        Dictionary<string, List<string>> sorted = GroupByUnicodeBlock(miss);//new Dictionary<string, List<string>>();
        Assert.IsTrue(sorted.Count == 6);
        var ModifierLetter = sorted.GetValueOrDefault("ModifierLetter");
        var OtherLetter = sorted.GetValueOrDefault("OtherLetter");
        var UppercaseLetter = sorted.GetValueOrDefault("UppercaseLetter");
        var OtherPunctuation = sorted.GetValueOrDefault("OtherPunctuation"); 
        var OpenPunctuation = sorted.GetValueOrDefault("OpenPunctuation");
        var ClosePunctuation = sorted.GetValueOrDefault("ClosePunctuation");
        
        Assert.IsTrue(ModifierLetter.Count == 1);
        Assert.IsTrue(OtherLetter.Count == 1);
        Assert.IsTrue(UppercaseLetter.Count == 3);
        Assert.IsTrue(OtherPunctuation.Count == 1);
        Assert.IsTrue(OpenPunctuation.Count == 1);
        Assert.IsTrue(ClosePunctuation.Count == 1);
    }

    private static HashSet<string> getMissing(HashSet<string> allChars)
    {

        HashSet<string> exceptChars = foundExceptions.Keys.ToHashSet();

        HashSet<string> missingChars = new HashSet<string>();

        foreach (var VARIABLE in allChars)
        {
            if (!exceptChars.Contains(VARIABLE))
            {
                missingChars.Add(VARIABLE);
            }
        }
        return missingChars;
    }
  
    
    public Dictionary<string, List<string>> GroupByUnicodeBlock(HashSet<string> characters)
    {
        var result = new Dictionary<string, List<string>>();

        foreach (string character in characters)
        {
            int codepoint = char.ConvertToUtf32(character, 0);
            UnicodeCategory unicodeBlock = CharUnicodeInfo.GetUnicodeCategory(codepoint);

            string blockName = unicodeBlock.ToString();

            if (!result.ContainsKey(blockName))
            {
                result[blockName] = new List<string>();
            }

            result[blockName].Add(character);
        }

        foreach (var unicodeBlock in result.Keys.ToList())
        {
            result[unicodeBlock] = result[unicodeBlock].OrderBy(c => char.ConvertToUtf32(c, 0)).ToList();
        }

        return result;
    }
}