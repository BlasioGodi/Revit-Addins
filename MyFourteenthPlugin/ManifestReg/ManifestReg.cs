using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

using Autodesk.RevitAddIns;

namespace ManifestReg
{
    class ManifestReg
    {
        static void Main()
        {
            ///<summary>Create a new Manifest file for the executable</summary>
            RevitAddInManifest revitAddIn = new RevitAddInManifest();

            RevitAddInApplication inApplication = new RevitAddInApplication("Fourteenth", @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\obj\x64\Debug\MyFourteenthPlugin.dll", Guid.NewGuid(), "MyFourteenthPlugin.MyFourteenthPlugin", "Autodesk");

            revitAddIn.AddInApplications.Add(inApplication);

            RevitProduct revitProduct = RevitProductUtility.GetAllInstalledRevitProducts()[0];
            revitAddIn.SaveAs(revitProduct.CurrentUserAddInFolder + "\\MyFourteenthPlugin.addin");
        }
    }
}
