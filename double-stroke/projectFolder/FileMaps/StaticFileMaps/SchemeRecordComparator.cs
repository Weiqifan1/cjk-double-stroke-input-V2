namespace double_stroke.projectFolder.StaticFileMaps;


public class SchemeRecordComparator : IComparer<SchemeRecord>
{
    private readonly bool _simplified;

    public SchemeRecordComparator(bool  simplified)
    {
        _simplified = simplified;
    }

    public int Compare(SchemeRecord x, SchemeRecord y)
    {
        if (_simplified)
        {
            return CompareSimplifiedFirst(x, y);
        }
        else
        {
            return CompareTraditionalFirst(x, y);
        }
    }
    
    private int CompareTraditionalFirst(SchemeRecord x, SchemeRecord other)
    {
        // First compare by tzaiNumber 
        int comparison;
        
        if (other.tzaiNumber.HasValue && x.tzaiNumber.HasValue)
        {
            comparison = other.tzaiNumber.Value.CompareTo(x.tzaiNumber.Value);
        }
        else if (!x.tzaiNumber.HasValue && other.tzaiNumber.HasValue)
        {
            comparison = 1; // This object comes after if it has null tzaiNumber.
        }
        else if (x.tzaiNumber.HasValue && !other.tzaiNumber.HasValue)
        {
            comparison = -1; // This object comes before if the other object has null tzaiNumber.
        }
        else
        {
            comparison = 0; // Both are null, hence they're equal as per comparison.
        }

        if (comparison != 0) return comparison;

        // Then compare by jundaNumber
        if (other.jundaNumber.HasValue && x.jundaNumber.HasValue)
        {
            comparison = other.jundaNumber.Value.CompareTo(x.jundaNumber.Value);
        }
        else if (!x.jundaNumber.HasValue && other.jundaNumber.HasValue)
        {
            comparison = 1; // This object comes after if it has null jundaNumber.
        }
        else if (x.jundaNumber.HasValue && !other.jundaNumber.HasValue)
        {
            comparison = -1; // This object comes before if the other object has null jundaNumber.
        }
        else
        {
            comparison = 0; // Both are null, hence they're equal as per comparison.
        }

        if (comparison != 0) return comparison;
        
        // Finally by rawCodepoint
        return char.ConvertToUtf32(x.character, 0).CompareTo(char.ConvertToUtf32(other.character, 0));
        
        //return string.Compare(x.rawCodepoint, other.rawCodepoint, StringComparison.Ordinal);
    }
    
    private int CompareSimplifiedFirst(SchemeRecord x, SchemeRecord other)
    {
        // First compare by jundaNumber
        int comparison;
        if (other.jundaNumber.HasValue && x.jundaNumber.HasValue)
        {
            comparison = other.jundaNumber.Value.CompareTo(x.jundaNumber.Value);
        }
        else if (!x.jundaNumber.HasValue && other.jundaNumber.HasValue)
        {
            comparison = 1; // This object comes after if it has null jundaNumber.
        }
        else if (x.jundaNumber.HasValue && !other.jundaNumber.HasValue)
        {
            comparison = -1; // This object comes before if the other object has null jundaNumber.
        }
        else
        {
            comparison = 0; // Both are null, hence they're equal as per comparison.
        }

        if (comparison != 0) return comparison;

        // Then compare by tzaiNumber
        if (other.tzaiNumber.HasValue && x.tzaiNumber.HasValue)
        {
            comparison = other.tzaiNumber.Value.CompareTo(x.tzaiNumber.Value);
        }
        else if (!x.tzaiNumber.HasValue && other.tzaiNumber.HasValue)
        {
            comparison = 1; // This object comes after if it has null tzaiNumber.
        }
        else if (x.tzaiNumber.HasValue && !other.tzaiNumber.HasValue)
        {
            comparison = -1; // This object comes before if the other object has null tzaiNumber.
        }
        else
        {
            comparison = 0; // Both are null, hence they're equal as per comparison.
        }

        if (comparison != 0) return comparison;

        // Finally by rawCodepoint
        return char.ConvertToUtf32(x.character, 0).CompareTo(char.ConvertToUtf32(other.character, 0));
        
        //return string.Compare(x.rawCodepoint, other.rawCodepoint, StringComparison.Ordinal);
    }
}