using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace MySeventhPlugin
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class MySeventhPlugin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Get the handle of the current document
                Document document = commandData.Application.ActiveUIDocument.Document;
                UIDocument uIDocument = commandData.Application.ActiveUIDocument;

                //Open a new transaction (Crucial to allowing modifications within the revit environment. 
                //You MUST TRANSACT before modifications to the Revit database is allowed. 
                using (Transaction tr = new Transaction(document))
                {
                    tr.Start("DeleteItems");

                    //Select items in document
                    Selection selection = uIDocument.Selection;
                    ICollection<ElementId> elementId = selection.GetElementIds();

                    if (0 == elementId.Count)
                    {
                        throw new Exception("No item has been selected.");
                    }
                    else
                    {
                        //Taskdialog to show that the user has selected the items
                        TaskDialog.Show("Revit", "You have selected the required items");

                        //Delete Selected items
                        ICollection<ElementId> deletedId = document.Delete(elementId);
                    }
                    tr.Commit();

                    return Result.Succeeded;
                }
            }
            catch(Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
        }
    }
}
