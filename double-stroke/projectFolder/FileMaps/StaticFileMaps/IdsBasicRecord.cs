namespace double_stroke.projectFolder.StaticFileMaps;

public record IdsBasicRecord(
    List<string> rawIds,
    List<string> rolledOutIds,
    List<string> rolledOutIdsWithNoShape
    );