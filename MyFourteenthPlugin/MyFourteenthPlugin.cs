using System;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Reflection;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;

namespace MyFourteenthPlugin
{
    public class MyFourteenthPlugin : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            ///<summary>Creation of a number of functionalities for a custom ribbon tab</summary>
            ///<RibbonTab>Ribbon Tab 1</RibbonTab>
            String ribbonTab1 = "RevitToExcel";
            application.CreateRibbonTab(ribbonTab1);

            ///<RibbonPanel>Ribbon Panel 1</RibbonPanel>
            String panel1 = "Excel1";
            RibbonPanel ribbonPanel1 = application.CreateRibbonPanel(ribbonTab1, panel1);

            PushButtonData pushButton1 = new PushButtonData("First","First", @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyNinthPlugin\obj\x64\Debug\MyNinthPlugin.dll",
                "MyNinthPlugin.MyNinthPlugin");
            pushButton1.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\AutoCAD.png"));

            PushButtonData pushButton2 = new PushButtonData("Second","Second", @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyNinthPlugin\obj\x64\Debug\MyNinthPlugin.dll",
                "MyNinthPlugin.MyNinthPlugin");
            pushButton2.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\AutoCAD.png"));

            PushButton button1 = ribbonPanel1.AddItem(pushButton1) as PushButton;

            ribbonPanel1.AddSeparator();
            PushButton button2 = ribbonPanel1.AddItem(pushButton2) as PushButton;

            ///<RibbonPanel>Ribbon Panel 2</RibbonPanel>
            String panel2 = "Excel2";
            RibbonPanel ribbonPanel2 = application.CreateRibbonPanel(ribbonTab1, panel2);

            PushButtonData pushButton3 = new PushButtonData("Third", "Third", @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyNinthPlugin\obj\x64\Debug\MyNinthPlugin.dll",
                "MyNinthPlugin.MyNinthPlugin");
            pushButton3.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\ACAD2.png"));

            PushButtonData pushButton4 = new PushButtonData("Fourth", "Fourth", @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyNinthPlugin\obj\x64\Debug\MyNinthPlugin.dll",
                "MyNinthPlugin.MyNinthPlugin");
            pushButton4.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\ACAD2.png"));

            SplitButtonData split1 = new SplitButtonData("Split1", "Split1");
            split1.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\ACAD2.png"));

            SplitButton splitButton1 = ribbonPanel2.AddItem(split1) as SplitButton;
            splitButton1.AddPushButton(pushButton3);
            splitButton1.AddPushButton(pushButton4);

            ribbonPanel2.AddSeparator();

            RadioButtonGroupData radioButton = new RadioButtonGroupData("Radio1");
            RadioButtonGroup radioButtonGroup1 = ribbonPanel2.AddItem(radioButton) as RadioButtonGroup;

            ToggleButtonData toggle1 = new ToggleButtonData("First","First");
            toggle1.ToolTip = "First Bit of Information";
            toggle1.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\AutoCAD.png"));
            radioButtonGroup1.AddItem(toggle1);

            ToggleButtonData toggle2 = new ToggleButtonData("Second", "Second");
            toggle2.ToolTip = "Second Bit of Information";
            toggle2.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\ACAD2.png"));
            radioButtonGroup1.AddItem(toggle2);

            ///<RibbonPanel>Ribbon Panel 3</RibbonPanel>
            String panel3 = "Excel3";
            RibbonPanel ribbonPanel3 = application.CreateRibbonPanel(ribbonTab1, panel3);

            ribbonPanel3.AddSlideOut();

            PulldownButtonData pulldown1 = new PulldownButtonData("Pull1", "Pull1");
            PulldownButton pulldownButton1 = ribbonPanel3.AddItem(pulldown1) as PulldownButton;
            pulldownButton1.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\RedBuilding.png"));

            PulldownButtonData pulldown2 = new PulldownButtonData("Pull2", "Pull2");
            PulldownButton pulldownButton2 = ribbonPanel3.AddItem(pulldown2) as PulldownButton;
            pulldownButton2.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\RedBuilding.png"));
            
            PulldownButtonData pulldown3 = new PulldownButtonData("Pull3", "Pull3");
            PulldownButton pulldownButton3 = ribbonPanel3.AddItem(pulldown3) as PulldownButton;
            pulldownButton3.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\RedBuilding.png"));
            
            //PushButton Data for Pulldownbutton
            PushButtonData pushButton5 = new PushButtonData("Third", "Third", @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyNinthPlugin\obj\x64\Debug\MyNinthPlugin.dll",
                "MyNinthPlugin.MyNinthPlugin");
            pushButton5.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\AutoCAD.png"));

            PushButtonData pushButton6 = new PushButtonData("Fourth", "Fourth", @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyNinthPlugin\obj\x64\Debug\MyNinthPlugin.dll",
                "MyNinthPlugin.MyNinthPlugin");
            pushButton6.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\ACAD2.png"));

            PushButtonData pushButton7 = new PushButtonData("Fourth", "Fourth", @"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyNinthPlugin\obj\x64\Debug\MyNinthPlugin.dll",
                "MyNinthPlugin.MyNinthPlugin");
            pushButton7.LargeImage = new BitmapImage(new Uri(@"C:\Users\user\Desktop\Computer Science\2. Projects\Projects2-RevitAddin\MyFourteenthPlugin\AutoCAD.png"));

            pulldownButton1.AddPushButton(pushButton5);
            pulldownButton1.AddSeparator();

            pulldownButton2.AddPushButton(pushButton6);
            pulldownButton2.AddSeparator();

            pulldownButton3.AddPushButton(pushButton7);

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}