using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;

using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace MyTenthPlugin
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class MyTenthPlugin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //Get the handle of the current document
                Document document = commandData.Application.ActiveUIDocument.Document;
                UIDocument uiDocument = commandData.Application.ActiveUIDocument;

                //Get the file details
                string fileName = "";
                string FileFilter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                FileOpenDialog fd = new FileOpenDialog(FileFilter);

                //Open the FileOpenDialog Box and check the users input
                if(fd.Show()==ItemSelectionDialogResult.Confirmed)
                {
                    using (Transaction td = new Transaction(document, "New Transaction"))
                    {
                        td.Start("FilePath");

                        //Get the filepath and convert it into readable string.
                        fileName = ModelPathUtils.ConvertModelPathToUserVisiblePath(fd.GetSelectedModelPath());

                        //Getting Data from Excel, reading it and displaying it to the user
                        //---------Excel file Open Start-------//
                        Excel.Application excelApp;
                        excelApp = new Excel.Application();

                        //Create Workbook and Worksheet variable
                        Excel.Workbook wb;
                        Excel.Worksheet ws;

                        //Open the excel file using the workbook and retrieve the first worksheet
                        wb = excelApp.Workbooks.Open(fileName);
                        ws = wb.Worksheets[1];

                        //Display the file path selected by the user.
                        TaskDialog.Show("FilePath", "The Selected file path is: \n" + Convert.ToString(ws.Cells[1,1].Value) );

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

                        //----------Excel file Close End---------//
                        td.Commit();
                    }
                }
                else
                {
                    throw new Exception("Nothing was selected.");
                }
                return Result.Succeeded;
            }
            catch(Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
        }
    }
}
