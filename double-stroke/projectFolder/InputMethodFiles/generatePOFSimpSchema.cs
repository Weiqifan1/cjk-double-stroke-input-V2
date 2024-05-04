namespace double_stroke.projectFolder.InputMethodFiles;

public static class generatePOFSimpSchema
{
    private static string part1 = @"
    # Rime schema settings:
    ";

    private static string part2 = @"
    # encoding: utf-8

schema:
  schema_id: 
    ";
    
    private static string part3 = @"
    name: ""
    ";

    private static string part4 = @"
     ""
  version: """;
    private static string part4_3 = @"  
  author:
    -";
    private static string part4_5 = @"   
  description: |";
    
    // 郑码
    // 碼表源自 极点超集郑码20151108
    // 敲 ` 鍵進入拼音反查
    private static string part4_7 = @"
  dependencies:
    - pinyin123

switches:
  - name: ascii_mode
    reset: 0
    states: [ 中文, 西文 ]
  - name: full_shape
    states: [ 半角, 全角 ]

engine:
  processors:
    - ascii_composer
    - recognizer
    - key_binder
    - speller
    - punctuator
    - selector
    - navigator
    - express_editor
  segmentors:
    - ascii_segmentor
    - matcher
    - abc_segmentor
    - punct_segmentor
    - fallback_segmentor
  translators:
    - punct_translator
    - table_translator
    - reverse_lookup_translator

speller:
  delimiter: "" '""
  max_code_length: 6

translator:
  dictionary:    
";

    private static string part5 = @"
  enable_charset_filter: true
  enable_completion: true
  enable_sentence: false
  enable_encoder: false
  encode_commit_history: false
  enable_user_dict: false

reverse_lookup:
  dictionary: pinyin123
  prefix: ""`""
  suffix: ""'""
  tips: 〔拼音〕
  preedit_format:
    - xform/([nl])v/$1ü/
    - xform/([nl])ue/$1üe/
    - xform/([jqxy])v/$1u/

punctuator:
  import_preset: symbols

key_binder:
  import_preset: default

recognizer:
  import_preset: default
  patterns:
    reverse_lookup: ""   
    ";

    private static string part6 = @"
     ""

menu:
  page_size: 9

style:
  horizontal: true
";
    
    public static string generate(
      string schemaId,
      string author,
      string version,
      string extradescription,
      string dictionary,
      string reverseLookup
      )
    {
      string result = 
        part1.Trim() +
        " " +
        schemaId +
        "\r\n" +
        part2.Trim() +
        " " +
        schemaId + 
        "\r\n  " +
        part3.Trim() +
        "" +
        schemaId + 
        "" +
        part4.Trim() +
        version + "\"" +
        "\r\n" + "  " +
        part4_3.Trim() +
        " " +
        author +
        "\r\n" +
        "  " +
        part4_5.Trim() +
        extradescription +
        "\r\n    " +
        basicDescription +
        "\r\n\r\n  " +
        part4_7.Trim() +
        " " + 
        dictionary +
        "\r\n  " +
        part5.Trim() +
        reverseLookup +
        "" +
        part6.Trim()  
          ;
      return result;
    }

    private static string basicDescription = 
      @"First published 2024-04-21
    Repository: 
    https://github.com/Weiqifan1/rime-pof-input-method 
    
    stoke data source:
    Compiled manually by Conway (@yawnoc).
    Part of 'Conway Stroke Data',
    see <https://github.com/stroke-input/stroke-input-data>.
    Licensed under Creative Commons Attribution 4.0 International (CC-BY-4.0)
    
    IDS data source:
    # Copyright (c) 2014-2017 CJKVI Database
    # Based on CHISE IDS Database
    https://github.com/cjkvi/cjkvi-ids/blob/master/ids.txt

    frequency data source:
    simplified:
    https://lingua.mtsu.edu/chinese-computing/statistics/char/list.php?Which=MO
    traditional:
    http://technology.chtsai.org/charfreq/sorted.html";

}
