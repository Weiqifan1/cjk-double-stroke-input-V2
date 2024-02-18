namespace double_stroke.projectFolder.StaticFileMaps;

public static class generateTestSchemeDict
{
    private static AlphabetGenerator alphabetGen = new AlphabetGenerator(CodeAlphabet.generateStandardOneAlphabet());
    
    public static List<SchemeRecord> schemeFromDictionary(
        Dictionary<string, CodepointWithExceptionRecord> foundExceptions,
        Dictionary<string, FrequencyRecord> junda,
        Dictionary<string, FrequencyRecord> tzai)
    {
        AlphabetGenerator alphaGen = new AlphabetGenerator(CodeAlphabet.generateStandardOneAlphabet());
        List<string> testStr = new List<string> { "是" };//{"飼"};  //{"签", "扔", "丠", "甑"};

        List<SchemeRecord> result = new List<SchemeRecord>();
        foreach (var VARIABLE in foundExceptions)
        {
            //CodepointWithExceptionRecord excep = VARIABLE.Value.codepointExceptions;
                //string nunNullException = VARIABLE.Value.codepointExceptions;
                //rollout 
                //HashSet<string> rolledOut = RolloutStrokes.rolloutString(VARIABLE.Value.codepointAfterExceptionremoval);
                //扔甑丠
                if (testStr.Contains(VARIABLE.Key))
                {
                    string test1 = "";
                }

                List<string> rolledOutNoShape = generateRolledOutNoShape(VARIABLE);
                List<string> rolledOutWithShape = generateRolledOutWithShape(VARIABLE);
                string characterForScheme = generateCharacterForAcheme(VARIABLE, alphaGen);
                string rawCodepointForScheme = generateRawCodepointForScheme(VARIABLE, alphaGen);
                HashSet<string> foundExceptionElemsForScheme = generateFoundExceptionsForScheme(VARIABLE, alphaGen);
                string exceptionLetterForScheme = generateExceptionLetterForScheme(VARIABLE, alphaGen);
                long? jundaForScheme = generateJundaForScheme(VARIABLE, alphaGen, junda, tzai);
                long? tzaiForScheme = generateTzaiForScheme(VARIABLE, alphaGen, junda, tzai);
                HashSet<string> code4ForScheme = generateCode4ForScheme(VARIABLE, alphaGen);
                HashSet<string> code6ForScheme = generateCode6ForScheme(VARIABLE, alphaGen);
                
                //VARIABLE.Value.codepointExceptions ?? throw new InvalidOperationException("Object cannot be null.");
                result.Add(new SchemeRecord(
                    rolledOutNoShape,
                    rolledOutWithShape,
                    characterForScheme,
                    rawCodepointForScheme,
                    foundExceptionElemsForScheme,
                    exceptionLetterForScheme,
                    jundaForScheme,
                    tzaiForScheme,
                    code4ForScheme,
                    code6ForScheme
                ));
        }
        return result;
    }

    private static List<string> generateRolledOutNoShape(KeyValuePair<string, CodepointWithExceptionRecord> variable)
    {
        List<string> result = new List<string>();
        if (variable.Value != null 
            && variable.Value.idsLookup != null 
            && variable.Value.idsLookup.rolledOutIdsWithNoShape != null)
        {
            return variable.Value.idsLookup.rolledOutIdsWithNoShape;
        }

        return result;
    }

    private static List<string> generateRolledOutWithShape(KeyValuePair<string, CodepointWithExceptionRecord> variable)
    {
        List<string> result = new List<string>();
        if (variable.Value != null 
            && variable.Value.idsLookup != null 
            && variable.Value.idsLookup.rolledOutIds != null)
        {
            return variable.Value.idsLookup.rolledOutIds;
        }

        return result;
    }

    private static HashSet<string> generateCode6ForScheme(
        KeyValuePair<string, CodepointWithExceptionRecord> variable, 
        AlphabetGenerator alphaGen)
    {
        //string firstLetter = variable.Value.codepointExceptions.alphabetLetter.Value;
        HashSet<string> tailRollout =
            RolloutStrokes.rolloutString(variable.Value.originalCodepoint.rawCodepoint);
        HashSet<string> tailAlphabetStrings = tailRollout.Select(x => 
            alphaGen.gen51(x)).ToHashSet();
        //HashSet<string> tailMergedString = tailAlphabetStrings.Select(x => 
        //    firstLetter + x).ToHashSet();
        return tailAlphabetStrings;
    }

    private static HashSet<string> generateCode4ForScheme(
        KeyValuePair<string, CodepointWithExceptionRecord> variable, 
        AlphabetGenerator alphaGen)
    {
        if (variable.Key.Equals("𧾷"))
        {
            string test = "";
        }

        if (variable.Value.codepointExceptions != null && variable.Value.idsException != null)
        {
            string firstLetter = variable.Value.codepointExceptions.alphabetLetter.Value;
            HashSet<string> tailRollout =
                RolloutStrokes.rolloutString(variable.Value.codepointAfterExceptionremoval);
            HashSet<string> tailAlphabetStrings = tailRollout.Select(x => 
                    alphaGen.gen21(x)).ToHashSet();
            HashSet<string> tailMergedString = tailAlphabetStrings.Select(x => 
                    firstLetter + x).ToHashSet();
            return tailMergedString;
        }
        else
        {
            //string firstLetter = variable.Value.codepointExceptions.alphabetLetter.Value;
            HashSet<string> tailRollout =
                RolloutStrokes.rolloutString(variable.Value.originalCodepoint.rawCodepoint);
            HashSet<string> tailAlphabetStrings = tailRollout.Select(x => 
                alphaGen.gen31(x)).ToHashSet();
            //HashSet<string> tailMergedString = tailAlphabetStrings.Select(x => 
            //    firstLetter + x).ToHashSet();
            return tailAlphabetStrings;
        }
    }

    private static long? generateTzaiForScheme(
        KeyValuePair<string, CodepointWithExceptionRecord> variable, 
        AlphabetGenerator alphaGen,
        Dictionary<string, FrequencyRecord> junda, 
        Dictionary<string, FrequencyRecord> tzai)
    {
        long? result = null;
        FrequencyRecord? tzaires = tzai.GetValueOrDefault(variable.Key);
        if (tzaires != null)
        {
            result = tzaires.frequency;
        }
        return result;
    }

    private static long? generateJundaForScheme(
        KeyValuePair<string, CodepointWithExceptionRecord> variable, 
        AlphabetGenerator alphaGen, 
        Dictionary<string, FrequencyRecord> junda, 
        Dictionary<string, FrequencyRecord> tzai)
    {
        long? result = null;
        FrequencyRecord? judares = junda.GetValueOrDefault(variable.Key);
        if (judares != null)
        {
            result = judares.frequency;
        }
        return result;
    }

    private static string generateExceptionLetterForScheme(KeyValuePair<string, CodepointWithExceptionRecord> variable, AlphabetGenerator alphaGen)
    {
        string result = "";

        if (variable.Value.codepointExceptions == null)
        {
            result = null;
        }
        else if (variable.Value.idsException == null)
        {
            result = null;
        }
        else
        {
            result = variable.Value.codepointExceptions.alphabetLetter.Value;
        }

        return result;
    }

    private static HashSet<string> generateFoundExceptionsForScheme(KeyValuePair<string, CodepointWithExceptionRecord> variable, AlphabetGenerator alphaGen)
    {
        HashSet<string> result = new HashSet<string>();
        if (variable.Value.codepointExceptions == null)
        {
            result = null;
        }
        else if (variable.Value.idsException == null)
        {
            result = null;
        }
        else
        {
            result = variable.Value.codepointExceptions.allAcceptableElems.ToHashSet();
        }

        return result;
    }

    private static string generateRawCodepointForScheme(KeyValuePair<string, CodepointWithExceptionRecord> variable, AlphabetGenerator alphaGen)
    {
        string result = variable.Value.originalCodepoint.rawCodepoint;
        return result;
    }

    private static string generateCharacterForAcheme(KeyValuePair<string, CodepointWithExceptionRecord> variable, AlphabetGenerator alphaGen)
    {
        string result = variable.Key;

        return result;
    }
}

/*
       string character,
    string rawCodepoint,
    HashSet<string> foundExceptionElems,
    string exceptionLetter,
    int? jundaNumber,
    int? tzaiNumber, 
    HashSet<string> code4,
    HashSet<string> code6);

        Dictionary<string, CodepointWithExceptionRecord> codepointWithExceptionsRec = foundExceptions;
CodepointWithExceptionRecord throwing = codepointWithExceptionsRec.GetValueOrDefault("扔");
//test content of 'throwing'
Assert.AreEqual(throwing.originalCodepoint.rawCodepoint, "121(35|53)");
Assert.AreEqual(throwing.codepointAfterExceptionremoval,  "(35|53)");
Assert.AreEqual(throwing.codepointExceptions.allAcceptableElems.Count, 1);
Assert.AreEqual(throwing.codepointExceptions.allAcceptableElems[0], "扌");
Assert.AreEqual(throwing.codepointExceptions.alphabetLetter.Value, "s");
Assert.AreEqual(throwing.letter.Value, "扔");
*/