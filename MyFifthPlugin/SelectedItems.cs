using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

namespace MyFifthPlugin
{
    [Transaction(TransactionMode.ReadOnly)]
    public class SelectedItems : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Select some elements in Revit before invoking this command

                //Get the handle of the current document.
                UIDocument uiDocument = commandData.Application.ActiveUIDocument;

                //Get the element selection of current document.
                ICollection<ElementId> selectedIds = uiDocument.Selection.GetElementIds();

                if(0 == selectedIds.Count)
                {
                    //If no elements selected
                    TaskDialog.Show("Revit", "You havent selected any elements.");
                }
                else
                {
                    String info = "Ids of selected elements in the document are: ";
                    foreach(ElementId id in selectedIds)
                    {
                        info += "\n\t" + id.IntegerValue;
                    }
                    TaskDialog.Show("Revit", info);
                }
            }
            catch(Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }

            return Result.Succeeded;
        }
    }
}
