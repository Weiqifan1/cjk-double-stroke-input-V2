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
  version: ""1.0""
  author:
    - 發明人 郑易里教授
  description: |
    郑码
    碼表源自 极点超集郑码20151108
    敲 ` 鍵進入拼音反查
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
      string comment,
      string schemaId,
      string name,
      string dictionary,
      string reverseLookup
      )
    {
      string result = 
        part1.Trim() +
        " " +
        comment +
        "\n" +
        part2.Trim() +
        " " +
        schemaId + 
        "\n  " +
        part3.Trim() +
        "" +
        name + 
        "" +
        part4.Trim() +
        " " +
        dictionary + 
        "\n  " +
        part5.Trim() +
        reverseLookup +
        "" +
        part6.Trim()  
          ;
      return result;
    }
    

}
