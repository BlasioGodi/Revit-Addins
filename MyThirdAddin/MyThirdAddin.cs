using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

//Revit Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;

//Microsoft Power BI: To install the Power BI API type the below in the Package Manager
//-----Install - Package Microsoft.PowerBI.Api-----//
using Microsoft.PowerBI.Api;

namespace MyThirdAddin
{
    public class MyThirdAddin : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            //Create Ribbon Panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Peter Kasasi");

            //Create Pushbutton for Ribbon Panel
            string panelAssembly = @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MySecondAddin\bin\x64\Debug\MySecondAddin.dll";
            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("Peter Kasasi", "Peter Kasasi", panelAssembly, "MySecondAddin.MySecondPlugin")) as PushButton;

            //Create Image for Pushbutton
            Uri uriImage = new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyThirdAddin\img\badCat.png");
            BitmapImage bitmapImage = new BitmapImage(uriImage);
            pushButton.LargeImage = bitmapImage;

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
