/*
 * ${res:XML.StandardHeader.CreatedByBlasio}
 * User: ${BlasioGodi}
 * Date: 10/19/2022
 * Time: 23:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Linq;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace Inception_Child
{
	/// <summary>
	/// Interaction logic for WindowDia.xaml
	/// </summary>
	public partial class WindowDia : Window
	{
        UIDocument uidoc = null;
        Document doc = null;

        Class1_withEvent myClass1_withEvent;
        ExternalEvent myExternalEvent;

        MostCommonParameters myMostCommonParameters = null;
        public WindowDia(UIDocument uid)
		{
			InitializeComponent();

            // add 'UIDocument uid' as a parameter above, because this is the way it is called form the external event, please see youve 5 Secrets of Revit API Coding for an explaination on this

            this.Top = Properties.Settings.Default.Top;
            this.Left = Properties.Settings.Default.Left;
            this.Height = Properties.Settings.Default.Height;
            this.Width = Properties.Settings.Default.Width;

            uidoc = uid;
            doc = uidoc.Document;

            PropertyGrid myPG = new PropertyGrid();

            Element myElement = doc.GetElement(uidoc.Selection.GetElementIds().First());

            myClass1_withEvent = new Class1_withEvent();
            myExternalEvent = ExternalEvent.Create(myClass1_withEvent);

            myMostCommonParameters = new MostCommonParameters();
            //myMostCommonParameters.myWindow1 = this;
            myMostCommonParameters.Comments = (myElement.LookupParameter("Comments") != null) ? myElement.GetParameters("Comments")[0].AsString() : "";

            ElementType myElementType = doc.GetElement(myElement.GetTypeId()) as ElementType;

            this.Title = myElementType.FamilyName + " - " + myElementType.Name;

            myClass1_withEvent.myElementType = myElementType;
            myClass1_withEvent.myElement = myElement;

            myMostCommonParameters.Model = (myElementType.LookupParameter("Model") != null) ? myElementType.GetParameters("Model")[0].AsString() : "";
            myMostCommonParameters.Manufacturer = (myElementType.LookupParameter("Manufacturer") != null) ? myElementType.GetParameters("Manufacturer")[0].AsString() : "";
            myMostCommonParameters.TypeComments = (myElementType.LookupParameter("Type Comments") != null) ? myElementType.GetParameters("Type Comments")[0].AsString() : "";
            myMostCommonParameters.Description = (myElementType.LookupParameter("Description") != null) ? myElementType.GetParameters("Description")[0].AsString() : "";

            myPG.EditorDefinitions.Add(Class1_withEvent.EditorDefinition01(myMostCommonParameters.GetType().GetProperties().Select(xxx => xxx.Name).ToList(), this));
            myPG.PropertyDefinitions.Add(new PropertyDefinition() { Category = "Instance", DisplayName = "Comments", TargetProperties = new string[] { "Comments" } });

            myPG.SelectedObject = myMostCommonParameters;
        }

        public void UpdateRevit()
        {
            try
            {
                //TaskDialog.Show("Me", myTempComments.Description);
                myClass1_withEvent.myMostCommonParameters = myMostCommonParameters;
                myExternalEvent.Raise();
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
        }

        private void Upgrade_Click(object sender, RoutedEventArgs e)
        {
            UpdateRevit();
        }

        private void UpgradeAndClose_Click(object sender, RoutedEventArgs e)
        {
            UpdateRevit();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Save();
        }
    }
}