using double_stroke.projectFolder.StaticFileMaps;

namespace double_stroke.projectFolder;

public class CreateDeckFileController
{
    public void myFunction()
    {
        Console.WriteLine("Hello, this is my function.");
        GenerateFileMaps genJunda = new GenerateFileMaps();
        genJunda.Run();
    }
    
}
