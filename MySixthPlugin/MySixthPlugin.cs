using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;

namespace MySixthPlugin
{
    [Transaction(TransactionMode.ReadOnly)]
    public class MySixthPlugin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Get the handle of the current document
                UIDocument uIDocument = commandData.Application.ActiveUIDocument;

                //Select elements within the active document
                Selection selection = uIDocument.Selection;
                ICollection<ElementId> selectElementIds = selection.GetElementIds();

                if (0 == selectElementIds.Count)
                {
                    //If no element is selected in the project
                    TaskDialog.Show("Revit", "No element selected. Please try again");
                }
                else
                {
                    String info = "The amount of details are as below";
                    foreach (ElementId Id in selectElementIds)
                    {
                        info += "\n\t" + Id.IntegerValue;
                    }
                    TaskDialog.Show("Revit", info);
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
            return Result.Succeeded;
        }
    }
}
