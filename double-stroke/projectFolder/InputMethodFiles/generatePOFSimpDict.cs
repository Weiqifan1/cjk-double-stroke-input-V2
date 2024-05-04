namespace double_stroke.projectFolder.InputMethodFiles;

public static class generatePOFSimpDict
{
    private static string part1 = @"
    # Rime dictionary: 
    ";

    private static string part2 = @"
    # encoding: utf-8

---
name: 
    ";

    private static string part2_5 = 
      "version:";
    
    private static string part3 = @"
sort: original
columns:
  - text
  - code
encoder:
  rules:
    - length_equal: 2
      formula: ""AaAbBaBb""
    - length_equal: 3
      formula: ""AaBaBbCa""
    - length_equal: 4
      formula: ""AaBaCaDa""
    - length_in_range: [5, 10]
      formula: ""AaBaCaDa""
  tail_anchor: ""'""
... ";

    public static string generate(
      string comment,
      string name,
      string version
      )
    {
      string result = 
        part1.Trim() +
        " " +
        comment +
        "\r\n" +
        part2.Trim() +
        " " +
        name + 
        "\r\n" +
        part2_5 + 
        " \"" +
        version +
        "\"" + 
        
        "\r\n" +
        part3.Trim() +
        "\r\n";
      return result;
    }
    

}