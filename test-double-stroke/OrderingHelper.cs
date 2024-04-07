namespace test_double_stroke;

public static class OrderingHelper
{
    
    public static HashSet<string> AllAboveThe9ThFilter(
        List<Tuple<string, HashSet<string>>> dictList,
        HashSet<int> codelengthToInclude)
    {
        HashSet<string> tempDict = new HashSet<string>();
        foreach (var VARIABLE in dictList)
        {
            if (codelengthToInclude.Contains(VARIABLE.Item1.Length))
            {
                tempDict.UnionWith(VARIABLE.Item2);
            }
        }
        return tempDict;
    }
    
    
}