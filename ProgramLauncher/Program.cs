using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramLauncher
{
    static class Program
    {
        private static Process p = new Process();
        private static Process[] processArray = null;

        public static bool isStarting = true;
        [STAThread]

        static void Main(string[] args)
        {
            try
            {
                if(!File.Exists(ConfigForm.getXmlLocation())) File.Create(ConfigForm.getXmlLocation()).Close();

                bool isHasInvalidExe = false;
                if (ConfigForm.getInitAppString().ToLower().Equals(ConfigForm.EXE_PATH.ToLower()) || ConfigForm.exeArrayContains(ConfigForm.getOtherExesArray(), ConfigForm.EXE_PATH))
                {
                    isHasInvalidExe = true;
                    MessageBox.Show(ConfigForm.EXE_PATH+" is not a valid executable, please choose a different application.");
                }

                //Checks: 
                //If user is holding CTRL on startup, 
                //if the XML is empty
                //If the initExe is empty
                //If any of the other exes are empty

                if ((Control.ModifierKeys & Keys.Control) != 0 || (System.IO.File.ReadAllText(ConfigForm.getXmlLocation()).ToString() == "" 
                    || (ConfigForm.getInitAppString().Equals("") || ConfigForm.exeArrayContains(ConfigForm.getOtherExesArray(), "")) || isHasInvalidExe))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ConfigForm());
                }
                else
                {
                    //If any arguments are passed to the exe
                    if (args.Any() && !args[0].Equals(""))
                    {
                        //Executes the behind the scenes code, pass argument through to InitExe
                        goToExecute(args[0]);

                        //Keeps checking every 5 seconds if the main application has exited,
                        while (p != null && !p.HasExited)
                        {
                            p.Refresh();
                            Thread.Sleep(500);
                        }
                        //If main application has exited, kill all opened programs
                        foreach (Process proc in processArray)
                        {
                            proc.Refresh();
                            if (!proc.HasExited)
                            {
                                proc.Kill();
                            }
                        }
                    }
                    else //If no arguments are passed to the exe
                    {
                        //No arguments, just open the programs
                        goToExecute();

                        //While the main process has not exited,
                        while (p != null && !p.HasExited)
                        {
                            p.Refresh();
                            Thread.Sleep(500);
                        }
                        //If main process has exited, kill all opened programs
                        foreach (Process proc in processArray)
                        {
                            proc.Refresh();
                            if (!proc.HasExited)
                            {
                                proc.Kill();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //If arguments ARE passed to executable
        private static void goToExecute(string arg)
        {
            string initExe = ConfigForm.getInitAppString();
            List<CustomClasses.OtherExeContainer> exes = ConfigForm.getOtherExesArray();

            try
            {
                if (File.Exists(initExe))
                {
                    //Open the initial executable, also pass the arguments through to the exe
                    p.StartInfo.UseShellExecute = true;
                    p.StartInfo.FileName = initExe;
                    if (File.Exists(arg)) arg = (new Uri(arg).LocalPath).ToString();
                    //Pass in app args and outside app args - Add ""'s around arg for programs that don't handle spaces
                    p.StartInfo.Arguments = ConfigForm.getInitAppParams() + " " + "\"" + arg + "\"";
                    //MessageBox.Show(p.StartInfo.FileName + " " + p.StartInfo.Arguments);
                    p.StartInfo.WorkingDirectory = Path.GetFullPath(initExe);
                    p.Start();

                }
                else
                {
                    MessageBox.Show("File " + initExe + " does not exist. \nPlease either open the settings by holding CTRL while running the application or delete the XML file and try again.");
                }
                processArray = new Process[exes.Count];
                for (int i = 0; i < exes.Count; i++)
                {
                    if (File.Exists(exes[i].getExe()))
                    {
                        //Open every other executable in the XML file.
                        Process p2 = new Process();
                        p2.StartInfo.UseShellExecute = true;
                        p2.StartInfo.FileName = exes[i].getExe();
                        p2.StartInfo.Arguments = exes[i].getParam();
                        p2.Start();
                        processArray[i] = p2;
                    }
                    else
                    {
                        MessageBox.Show("File " + exes[i] + " does not exist. \nPlease either open the settings by holding CTRL while running the application or delete the XML file and try again.");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred when starting an application. \n\n"+e.ToString());
            }
        }
        
        //If arguments are not passed to executable
        private static void goToExecute()
        {
            string initExe = ConfigForm.getInitAppString();
            List<CustomClasses.OtherExeContainer> exes = ConfigForm.getOtherExesArray();
            try
            {
                if (File.Exists(initExe))
                {
                    //Open the initial executable
                    p.StartInfo.UseShellExecute = true;
                    p.StartInfo.FileName = initExe;
                    //Although there are arguments given here, these are in app arguments, not outside app args
                    p.StartInfo.Arguments = ConfigForm.getInitAppParams();
                    //MessageBox.Show(p.StartInfo.FileName + " " + ConfigForm.getInitAppParams());
                    p.StartInfo.WorkingDirectory = Path.GetFullPath(initExe);
                    p.Start();
                }
                else
                {
                    MessageBox.Show("File " + initExe + " does not exist. \nPlease either open the settings by holding CTRL while running the application or delete the XML file and try again.");
                }
                processArray = new Process[exes.Count];
                for(int i = 0; i < exes.Count; i++)
                {
                    if (File.Exists(exes[i].getExe()))
                    {
                        //Open every other executable in the XML file.
                        Process p2 = new Process();
                        p2.StartInfo.UseShellExecute = true;
                        p2.StartInfo.FileName = exes[i].getExe();
                        p2.StartInfo.Arguments = exes[i].getParam();
                        p2.Start();
                        processArray[i] = p2;
                    }
                    else
                    {
                        MessageBox.Show("File " + exes[i] + " does not exist. \nPlease either open the settings by holding CTRL while running the application or delete the XML file and try again.");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred when starting an application. \n\n" + e.ToString());
            }
        }
    }
}
