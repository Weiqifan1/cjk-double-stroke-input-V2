namespace double_stroke.projectFolder.StaticFileMaps;

public record IdsRecur(
        string elem,
        string rawConway,
        string unambigousConway,
        string regeneratedConway,
        List<IdsRecur> body);
    