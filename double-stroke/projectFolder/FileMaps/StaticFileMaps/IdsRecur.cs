namespace double_stroke.projectFolder.StaticFileMaps;

public record IdsRecur(
        string elem,
        string rawConway,
        string unambigousConway,
        List<IdsRecur> body);
    