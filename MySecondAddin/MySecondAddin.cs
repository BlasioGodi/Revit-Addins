using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Revit Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace MySecondAddin
{
    [Transaction(TransactionMode.Manual)]
    public class MySecondPlugin: IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("The journey of a thousand miles", "ITS HUGE");
            return Result.Succeeded;
        }
    }
}
