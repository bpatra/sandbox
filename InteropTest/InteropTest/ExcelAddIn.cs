using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Interop;
using ExcelDna.Integration;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using DialogResult = System.Windows.Forms.DialogResult;
using System.Runtime.CompilerServices;
using FrontExcelAddIn.VersionManagement;
using System.Text;
///////////////////////////////////////////
//ADDIN LOADING PROBLEMS SOLUTION ROADMAP//
///////////////////////////////////////////
//a) Delete the User.Config file (can be located using the method in System.Configuration DLL: "ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);")
//b) Check the Excel Options>AddIn>Disabled AddIns
//c) Make sure that the "[ComVisible(true)]" is present for the Ribbon method, and the Forms Panes Methods
//d) Check if [DebuggerNonUserCode] are not misplaced

namespace PowerMerger
{

    public class ExcelAddIn
    {
        public static Application Excel;
        public static Workbook ActiveWorkbook;
        public static Worksheet ActiveSheet;

        public static string GetAppDataDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"InteropTest");
        }

    
        [ExcelCommand]
        public static void SelectEvenLines()
        {
           Console.WriteLine("Hello");
        }


        public class MyDnaAddIn : IExcelAddIn
        {

            public void AutoOpen()
            {

                try
                {
                    Excel = (Application)ExcelDnaUtil.Application;
                    var configFileName = Assembly.GetAssembly(typeof(ExcelAddIn)).Location + @".config";
                    var settingsFileName = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                    var filePath = Path.GetFullPath(Path.Combine(GetAppDataDirectory(), @".\Logs\InteropTest.log"));
                    Log.InitLog(filePath, false);
                    Log.Trace("AutoOpen", "Log started (Config='{0}' Default Properties Settings='{1}')", configFileName, settingsFileName);

                }
                catch (Exception ex)
                {
                    Log.Exception(ex);
                }

                try
                {

                    Log.Trace("AutoOpen", "Active .NET Version: " + RuntimeEnvironment.GetSystemVersion());
                    Log.Trace("AutoOpen", "Executing assembly:" + Assembly.GetExecutingAssembly().FullName);
                    Log.Trace("AutoOpen", "Addin executing directory: " + Path.GetDirectoryName((string)XlCall.Excel(XlCall.xlGetName)));

                    //TODO: used to simplify logic but it is not recommended see Eric Carter and Lipper book section;: Programming Excel
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); //Mandatory if Windows in English but regional settings are not

                    ExcelAsyncUtil.Initialize();

                    ActiveWorkbook = Excel.ActiveWorkbook;
                    ActiveSheet = (Worksheet)Excel.ActiveSheet;

                    Excel.WorkbookOpen += WorkbookOpen;
                    Excel.WorkbookActivate += WorkbookActivated;
                    Excel.WorkbookDeactivate += WorkbookDeactivated;
                    Excel.WorkbookBeforeSave += WorkBookBeforeSave;
                    Excel.WorkbookBeforeClose += WorkbookBeforeClose;
                }
                catch (Exception ex)
                {
                    Log.Exception(ex);
                }
            }

            public void AutoClose()
            {
            }

            //As AutoClose is not systematically called we use the workbook closing...
            private void WorkbookBeforeClose(Workbook workbook, ref bool cancel)
            {
                Log.Trace("WorkbookBeforeClose", "toto");
            }

            //No AfterSave event in Excel 2007...
            private void WorkBookBeforeSave(Workbook workbook, bool saveasui, ref bool cancel)
            {
                Log.Trace("WorkbookBeforeSave", "toto");
            }

            private void WorkbookOpen(Workbook workbook)
            {
                Log.Trace("WorkbookOpen", "toto");
            }

            private void WorkbookActivated(Workbook workbook)
            {
                ActiveWorkbook = Excel.ActiveWorkbook;
                ActiveSheet = (Worksheet)Excel.ActiveSheet;
                workbook.SheetActivate += SheetActivated;
                workbook.SheetDeactivate += SheetDeactivated;
                ActiveSheet.SelectionChange += SheetSelectionChange;
                
                Log.Trace("WorkbookActivated", "toto");
            }

            private void WorkbookDeactivated(Workbook workbook)
            {
                Log.Trace("WorkbookDeactivated", "toto");
            }

            private void SheetActivated(object sheet)
            {
                Log.Trace("SheetActivated", "toto");
                ActiveSheet = (Worksheet)sheet;

                ActiveSheet.SelectionChange += SheetSelectionChange;
            }

            private void SheetDeactivated(object sheet)
            {
                Log.Trace("SheetDeactivated", "toto");
                ((Worksheet)sheet).SelectionChange -= SheetSelectionChange;
            }

            private void SheetSelectionChange(Range range)
            {
                Log.Trace("SheetSelectionChange", "toto");
            }
        }
    }
}
