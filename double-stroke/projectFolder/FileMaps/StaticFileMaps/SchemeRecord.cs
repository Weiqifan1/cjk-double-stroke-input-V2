namespace double_stroke.projectFolder.StaticFileMaps;

public record SchemeRecord(
    List<string> rolledOutNoShape,
    List<string> rolledOutWithShape,
    string character,
    string rawCodepoint,
    HashSet<string> foundExceptionElems,
    string exceptionLetter,
    long? jundaNumber,
    long? tzaiNumber,
    HashSet<string> code4,
    HashSet<string> code6);

    /*
        SchemeRecord(
    string character,
    string rawCodepoint,
    HashSet<string> foundExceptionElems,
    string exceptionLetter,
    HashSet<string> code4,
    HashSet<string> code6);

//test content of 'throwing'
Assert.AreEqual(throwing.originalCodepoint.rawCodepoint, "121(35|53)");
Assert.AreEqual(throwing.codepointAfterExceptionremoval,  "(35|53)");
Assert.AreEqual(throwing.codepointExceptions.allAcceptableElems.Count, 1);
Assert.AreEqual(throwing.codepointExceptions.allAcceptableElems[0], "扌");
Assert.AreEqual(throwing.codepointExceptions.alphabetLetter.Value, "s");
Assert.AreEqual(throwing.letter.Value, "扔");
*/

