/*
 * Created by SharpDevelop.
 * User: user
 * Date: 10/19/2022
 * Time: 23:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace Inception_Child
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("E15E29C9-878C-4B07-8FC8-4B9CAB6B0CCA")]
	public partial class ThisDocument
	{
		private void Module_Startup(object sender, EventArgs e)
		{

		}

		private void Module_Shutdown(object sender, EventArgs e)
		{

		}

        //this is is the method that invoked from outside
        public Result OpenWindowForm(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            if (uidoc.Selection.GetElementIds().Count != 1)
            {
                TaskDialog.Show("Me", "Please only select one entity");
                return Result.Succeeded;
            }

            try
            {
                WindowDia myWindow1 = new WindowDia(uidoc);

                myWindow1.Show();
            }

            #region catch and finally
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
            }
            #endregion

            return Result.Succeeded;
        }

        #region Revit Macros generated code
        private void InternalStartup()
		{
			this.Startup += new System.EventHandler(Module_Startup);
			this.Shutdown += new System.EventHandler(Module_Shutdown);
		}
		#endregion
	}
}