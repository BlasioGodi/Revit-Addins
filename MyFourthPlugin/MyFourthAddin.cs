using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

//Revit Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace MyFourthPlugin
{
    public class RibbonDesign
    {
        public void AddPanelButton(RibbonPanel ribbonPanels, string ButtonName, string ButtonText, string panelAssembly, string ClassName,Uri imageReference, string TooltipInfo)
        {
            //Create the input parameters for the PanelButton(This information varies)
            ClassName = "MySecondAddin.MySecondPlugin";
            panelAssembly = @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MySecondAddin\bin\x64\Debug\MySecondAddin.dll";
            TooltipInfo = "YOU HAVE BEEN WARNED";

            //Create the PushButton
            PushButton pushButton = ribbonPanels.AddItem(new PushButtonData(ButtonName,ButtonText, panelAssembly, ClassName)) as PushButton;

            //Create the Pushbutton images
            imageReference = new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\Image References\ACAD2.png");
            BitmapImage bitmapImage = new BitmapImage(imageReference);
            pushButton.LargeImage = bitmapImage;

            //Create Tooltip
            pushButton.ToolTip = TooltipInfo;
            pushButton.ToolTipImage = bitmapImage;
        }
    }
    public class MyFourthAddin : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            //Define used tab and panel names
            string tabName = "ExcelToRevit";
            string panelName1 = "Excel File";
            string panelName2 = "Sheet Settings";
            string panelName3 = "Excel Output";

            //Create new object for RibbonDesign
            RibbonDesign ribbonDesign = new RibbonDesign();

            //Create Ribbon Tab
            app.CreateRibbonTab(tabName);

            //Create Ribbon Panels
            RibbonPanel ribbonPanel1 = app.CreateRibbonPanel(tabName,panelName1);
            RibbonPanel ribbonPanel2 = app.CreateRibbonPanel(tabName, panelName2);
            RibbonPanel ribbonPanel3 = app.CreateRibbonPanel(tabName, panelName3);

            //Panel Button Input Parameters
            //RibbonPanel1
            //Panel Button1
            string ButtonName1 = "Massive Tab1";
            string ButtonText1 = "Massive Tab1";
            string ClassName1 = "MySecondAddin.MySecondPlugin";
            string panelAssembly1 = @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MySecondAddin\bin\x64\Debug\MySecondAddin.dll";
            string TooltipInfo1 = "YOU HAVE BEEN WARNED";
            Uri imageReference1 = new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\Image References\ACAD2.png");

            ribbonDesign.AddPanelButton(ribbonPanel1,ButtonName1,ButtonText1,panelAssembly1,ClassName1,imageReference1,TooltipInfo1);

            //Panel Separator
            ribbonPanel1.AddSeparator();

            //Panel Button2
            string ButtonName2 = "Massive Tab2";
            string ButtonText2 = "Massive Tab2";
            string ClassName2 = "MySecondAddin.MySecondPlugin";
            string panelAssembly2 = @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MySecondAddin\bin\x64\Debug\MySecondAddin.dll";
            string TooltipInfo2 = "YOU HAVE BEEN WARNED";
            Uri imageReference2 = new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\Image References\ACAD2.png");

            ribbonDesign.AddPanelButton(ribbonPanel1, ButtonName2, ButtonText2, panelAssembly2, ClassName2, imageReference2, TooltipInfo2);

            //Panel Separator
            ribbonPanel1.AddSeparator();

            //Panel Button3
            string ButtonName3 = "Massive Tab3";
            string ButtonText3 = "Massive Tab3";
            string ClassName3 = "MySecondAddin.MySecondPlugin";
            string panelAssembly3 = @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MySecondAddin\bin\x64\Debug\MySecondAddin.dll";
            Uri imageReference3 = new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\Image References\ACAD2.png");
            string TooltipInfo3 = "YOU HAVE BEEN WARNED";

            ribbonDesign.AddPanelButton(ribbonPanel1, ButtonName3, ButtonText3, panelAssembly3, ClassName3, imageReference3, TooltipInfo3);

            //RibbonPanel2
            //Panel Button1
            string ButtonName4 = "Massive Tab4";
            string ButtonText4 = "Massive Tab4";
            string ClassName4 = "MySecondAddin.MySecondPlugin";
            string panelAssembly4 = @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MySecondAddin\bin\x64\Debug\MySecondAddin.dll";
            Uri imageReference4 = new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\Image References\ACAD2.png");
            string TooltipInfo4 = "YOU HAVE BEEN WARNED";

            ribbonDesign.AddPanelButton(ribbonPanel2, ButtonName4, ButtonText4, panelAssembly4, ClassName4, imageReference4, TooltipInfo4);

            //Panel Separator
            ribbonPanel2.AddSeparator();

            //Panel Button2
            string ButtonName5 = "Massive Tab5";
            string ButtonText5 = "Massive Tab5";
            string ClassName5 = "MySecondAddin.MySecondPlugin";
            string panelAssembly5 = @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MySecondAddin\bin\x64\Debug\MySecondAddin.dll";
            Uri imageReference5 = new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\Image References\ACAD2.png");
            string TooltipInfo5 = "YOU HAVE BEEN WARNED";

            ribbonDesign.AddPanelButton(ribbonPanel2, ButtonName5, ButtonText5, panelAssembly5, ClassName5, imageReference5, TooltipInfo5);
            
            //Panel Separator
            ribbonPanel2.AddSeparator();

            //Panel Button3
            string ButtonName6 = "Massive Tab6";
            string ButtonText6 = "Massive Tab6";
            string ClassName6 = "MySecondAddin.MySecondPlugin";
            string panelAssembly6 = @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MySecondAddin\bin\x64\Debug\MySecondAddin.dll";
            Uri imageReference6 = new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\Image References\ACAD2.png");
            string TooltipInfo6 = "YOU HAVE BEEN WARNED";

            ribbonDesign.AddPanelButton(ribbonPanel2, ButtonName6, ButtonText6, panelAssembly6, ClassName6, imageReference6, TooltipInfo6);

            //RibbonPanel3
            //Panel Button1
            string ButtonName7 = "Massive Tab7";
            string ButtonText7 = "Massive Tab7";
            string ClassName7 = "MySecondAddin.MySecondPlugin";
            string panelAssembly7 = @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MySecondAddin\bin\x64\Debug\MySecondAddin.dll";
            Uri imageReference7 = new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\Image References\ACAD2.png");
            string TooltipInfo7 = "YOU HAVE BEEN WARNED";

            ribbonDesign.AddPanelButton(ribbonPanel3, ButtonName7, ButtonText7, panelAssembly7, ClassName7, imageReference7, TooltipInfo7);

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
