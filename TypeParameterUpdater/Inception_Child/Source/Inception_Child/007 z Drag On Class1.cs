using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Xceed.Wpf.Toolkit.PropertyGrid; 
using System.Windows;

namespace Inception_Child
{
    public class MostCommonParameters
    {
        //public Window1 myWindow1 { get; set; }
        public string Comments { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string TypeComments { get; set; }
        public string Description { get; set; }
    }

    public class Class1_withEvent : IExternalEventHandler
    {

        public Element myElement { get; set; }
        public ElementType myElementType { get; set; }
        public MostCommonParameters myMostCommonParameters { get; set; }

        public void Execute(UIApplication uiapp)
        {
            Document doc = uiapp.ActiveUIDocument.Document;

            try
            {
                using (Transaction t = new Transaction(doc, "Fields with carriage returns"))
                {
                    t.Start();

                    if (myElement.LookupParameter("Comments") != null) myElement.GetParameters("Comments")[0].Set(myMostCommonParameters.Comments);
                    if (myElementType.LookupParameter("Model") != null) myElementType.GetParameters("Model")[0].Set(myMostCommonParameters.Model);
                    if (myElementType.LookupParameter("Manufacturer") != null) myElementType.GetParameters("Manufacturer")[0].Set(myMostCommonParameters.Manufacturer);
                    if (myElementType.LookupParameter("Type Comments") != null) myElementType.GetParameters("Type Comments")[0].Set(myMostCommonParameters.TypeComments);
                    if (myElementType.LookupParameter("Description") != null) myElementType.GetParameters("Description")[0].Set(myMostCommonParameters.Description);

                    t.Commit();
                }
            }

            #region catch and finally
            catch (Exception ex)
            {
                TaskDialog.Show("Catch", "Failed due to:" + Environment.NewLine + ex.Message);
            }
            finally
            {

            }
            #endregion
        }
        public string GetName()
        {
            return "External Event Example";
        }


#pragma warning disable CS0618 // Type or member is obsolete
        public static EditorDefinition EditorDefinition01(List<string> ListAllStringsFields, WindowDia myWindow1)
        {
            EditorDefinition ed = new EditorDefinition();  //if this stops working in the future then use an earlier version of xceed extended toolkit

            PropertyDefinition pd = new PropertyDefinition();
            pd.TargetProperties = ListAllStringsFields;  // new List<string>() { "Description","Make" };
            ed.PropertiesDefinitions.Add(pd);

            FrameworkElementFactory fac = new FrameworkElementFactory(typeof(System.Windows.Controls.TextBox));
            fac.SetBinding(System.Windows.Controls.TextBox.TextProperty, new System.Windows.Data.Binding("Value"));
            fac.SetValue(System.Windows.Controls.TextBox.TextWrappingProperty, TextWrapping.Wrap);
            fac.SetValue(System.Windows.Controls.TextBox.AcceptsReturnProperty, true);
            fac.SetValue(System.Windows.Controls.TextBox.BorderThicknessProperty, new Thickness(1));
            DataTemplate dt = new DataTemplate { VisualTree = fac };
            dt.Seal();
            ed.EditorTemplate = dt;

            return ed;
        }
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
