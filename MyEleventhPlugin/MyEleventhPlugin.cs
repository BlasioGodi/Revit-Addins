//Autodesk
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
//Microsoft
using Microsoft.Office.Core;
//System
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
//Microsoft Excel
using Excel = Microsoft.Office.Interop.Excel;

namespace MyEleventhPlugin
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class MyEleventhPlugin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Get the handle of the current document
                Document document = commandData.Application.ActiveUIDocument.Document;
                UIDocument uIDocument = commandData.Application.ActiveUIDocument;

                //Taskdialog initialization
                TaskDialog td = new TaskDialog("New Instance");

                //File Open Dialog initialization
                string fileName = "";
                string fileFilter = "Excel files (*.xlsx*)|*.*| All Files (*.*)|*.*";
                FileOpenDialog fd = new FileOpenDialog(fileFilter);

                using (Transaction transact = new Transaction(document,"FilePathMods"))
                {
                    if (fd.Show() == ItemSelectionDialogResult.Confirmed)
                    {
                        transact.Start("BlasioMods");

                        fileName = ModelPathUtils.ConvertModelPathToUserVisiblePath(fd.GetSelectedModelPath());
                        TaskDialog.Show("Revit", fileName);

                        //-------Excel Process Start----------//

                        //Excel COM Objects Declaration
                        Excel.Application excelApp;
                        excelApp = new Excel.Application();

                        //Open new Excel Workbook and Worksheet
                        Excel.Workbook wb;
                        Excel.Worksheet ws;

                        wb = excelApp.Workbooks.Open(fileName);
                        ws = wb.Worksheets[1];

                        TaskDialog.Show("Revit", "The file name for the excel is: " + fileName);

                        //Excel cleanup after task execution
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        //Rule of thumb for releasing COM Objects
                        //Never use two dots, all COM Objects must be referenced and released individually
                        //ex: [something].[something].[something] is bad

                        //Release COM Objects to fully kill excel process from running in the background.
                        //Start with Ranges and Worksheets before proceeding to close the Workbooks.
                        Marshal.ReleaseComObject(ws);

                        //Close and Release Workbook
                        wb.Close();
                        Marshal.ReleaseComObject(wb);

                        //Quit and release excel
                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);

                        //-------Excel Process End----------//

                        transact.Commit();

                        return Result.Succeeded;
                    }
                    else
                    {
                        throw new Exception("Nothing to show here because no selection has been made.");
                    }
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
