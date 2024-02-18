namespace double_stroke.projectFolder.StaticFileMaps;

//this should end up as a dictionary with element to codepointExceptionRecord, 
//hvor element er UnicodeCodepoint, dvs. der skal bruge
//flere 
public record CodepointExceptionRecord(
    string character,
    UnicodeCharacter alphabetLetter,
    HashSet<string> rawCodepoint,
    List<string> allAcceptableElems,
    List<string> mistakenMatches
    );


////扌目趴  虫木竺
/// 金飣車糽言馬門
/// 
/*
 public record CodepointBasicRecord(
    //UnicodeCharacter[] codepointNumbers,
    string rawCodepoint
    );
*/