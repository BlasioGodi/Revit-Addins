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

namespace MyNinthPlugin
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class MyNinthPlugin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Get the application and document from external command data
                Document document = commandData.Application.ActiveUIDocument.Document;
                UIDocument uIDocument = commandData.Application.ActiveUIDocument;

                //Create New TaskDialog
                TaskDialog taskDialog = new TaskDialog("NewInstance");

                //Create TaskDialog content
                taskDialog.MainContent = ("Click Yes to return Succeeded. Selected items will be deleted.\n" +
                    "Click No to return Failed. Selected items will not be deleted.\n" +
                    "Click Cancel to return Cancelled. Selected items will not be deleted.");

                //Create TaskDialog Buttons
                TaskDialogCommonButtons taskDialogCommonButtons = TaskDialogCommonButtons.Yes |
                    TaskDialogCommonButtons.No | TaskDialogCommonButtons.Cancel;

                //Assign Common buttons value to taskDialog Content
                taskDialog.CommonButtons = taskDialogCommonButtons;

                //Initiate a Transaction to open the document and allow for modifications within the Revit document
                using (Transaction tr = new Transaction(document))
                {
                    //Start of the Transaction
                    tr.Start("DeletedItems");

                    //Select items in document
                    Selection selection = uIDocument.Selection;
                    ICollection<ElementId> selectedElements = selection.GetElementIds();
                    
                    if (0 == selectedElements.Count)
                    {
                        throw new Exception("No item to delete");
                    }
                    //Get the TaskDialogResult
                    TaskDialogResult taskDialogResult = taskDialog.Show();

                    //Check if user accepts YES, NO or CANCELED for selected elements
                    if (taskDialogResult == TaskDialogResult.Yes)
                    {
                        ICollection<ElementId> deletedElements = document.Delete(selectedElements);
                        TaskDialog.Show("Revit", "You have successfully deleted the items.");
                    }
                    else if (taskDialogResult == TaskDialogResult.No)
                    {
                        TaskDialog.Show("Revit", "No items deleted.");
                        return Result.Failed;
                    }
                    else
                    {
                        TaskDialog.Show("Revit", "No items deleted.");
                        return Result.Cancelled;
                    }
                    tr.Commit();

                    return Result.Succeeded;
                }
                
            }
            catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
        }
    }
}


