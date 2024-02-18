namespace double_stroke.projectFolder.StaticFileMaps;
//using Newtonsoft.Json;
using System.ComponentModel;

public class UnicodeCharacter
{
    
    private string value;
    
    
    public string Value
    {
        get { return this.value; }
        private set { this.value = value; }  // Added this set accessor
    }
    
    public UnicodeCharacter()
    {
    }
    
    public UnicodeCharacter(string value)
    {
        if (value.Length < 1 || value.Length > 2)
        {
            throw new ArgumentException("Invalid length for Unicode character");
        }
        if (value.Length.Equals(2) && !IsSurrogatePair(value))
        {
            throw new ArgumentException("Invalid length for Unicode character");
        }
        this.value = value;
    }
    
    private bool IsSurrogatePair(string input)  
    {  
        if (string.IsNullOrEmpty(input))  
        {  
            throw new ArgumentNullException(nameof(input));  
        }  
  
        if (input.Length != 2)  
        {  
            return false;  
        }  
  
        return char.IsHighSurrogate(input[0]) && char.IsLowSurrogate(input[1]);  
    }
    
    
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is UnicodeCharacter))
            return false;
        var unicodeordinalOfValue = GetUnicodeOrdinalLocal(this);
        var otherItem = GetUnicodeOrdinalLocal(((UnicodeCharacter) obj));
        return unicodeordinalOfValue.Equals(otherItem);
    }

    private object GetUnicodeOrdinalLocal(UnicodeCharacter uni)
    {
        if (char.IsHighSurrogate(uni.Value[0]) && uni.Value.Length > 1)
        {
            int unicodeOrdinal = char.ConvertToUtf32(uni.Value[0], uni.Value[1]);
            string unicodeString = unicodeOrdinal.ToString();
            return unicodeString;
        }
        else
        {
            int unicodeOrdinal = uni.Value[0];
            string unicodeString = unicodeOrdinal.ToString();
            return unicodeString;
        }
    }

    public override int GetHashCode()
    {
        return value != null ? value.GetHashCode() : 0;
    }
}