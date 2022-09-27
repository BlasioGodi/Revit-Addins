using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace MyEighthPlugin
{
    [Transaction(TransactionMode.Manual)]
    public class MyEighthPlugin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Get the document handle/reference
                Document document = commandData.Application.ActiveUIDocument.Document;
                UIDocument uIDocument = commandData.Application.ActiveUIDocument;

                //Select items in document
                Selection selection = uIDocument.Selection;
                ICollection<ElementId> idCollection = document.Delete(uIDocument.Selection.GetElementIds());

                //Create new TaskDialog
                TaskDialog taskDialog = new TaskDialog("Revit");
                taskDialog.MainContent = ("Click Yes to return Succeeded. Selected elements will be deleted.\n" + 
                    "Click No to return Failed. Selected elements will not be deleted.\n" + 
                    "Click Cancel to return Cancelled. Selected elements will not be deleted.");

                //Create buttons for the TaskDialog
                TaskDialogCommonButtons buttons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No | TaskDialogCommonButtons.Cancel;
                taskDialog.CommonButtons = buttons;

                TaskDialogResult taskDialogResult = taskDialog.Show();

                if(taskDialogResult == TaskDialogResult.Yes)
                {
                    return Result.Succeeded;
                }
                else if (taskDialogResult == TaskDialogResult.No)
                {
                    return Result.Failed;
                }
                else
                {
                    return Result.Failed;
                }
            }
            catch
            {
                message = "Unexpected Exception thrown.";
                return Result.Failed;
            }
        }
    }
}
