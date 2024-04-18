using double_stroke.projectFolder.InputMethodFiles;

namespace double_stroke.GenerateInputMethodClass;

using double_stroke.projectFolder.StaticFileMaps;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text.Json;
using double_stroke.projectFolder.FileMaps;
using double_stroke.projectFolder.FileMaps.GenerateFilesController;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using test_double_stroke.testSchemdictValuesBeforePrint;

[Explicit]
public class GenerateOtherShapeSystemHelpers
{
    //FilePaths.dotsAndSlash + FilePaths.windowsArraySimpOutputFile

    [Test]
    public void GenerateCangjie()
    {
        var gen = new GenerateFileMaps();
        string cangjiePath = FilePaths.dotsAndSlash + FilePaths.cangjie5DictStaticFile; 
        List<List<string>> foreign = gen.generateForeignInputSystemDict(cangjiePath);
        
        //generateCangjie5Dict(foreign);

        string test = "";
    }

}