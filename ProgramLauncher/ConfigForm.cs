using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using ProgramLauncher.CustomClasses;

namespace ProgramLauncher
{
    public partial class ConfigForm : Form
    {
        private static string initAppString = "";
        private static string initAppParams = "";
        private static List<OtherExeContainer> otherExesList = new List<OtherExeContainer>();

        private static string XML_FILENAME = "ProgLaunch_Config.xml";
        public static string EXE_PATH = new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;

        public ConfigForm()
        {
            InitializeComponent();

            getExeDirectory();

            //Set the inital Exe string. [0] For ExeLoc, [1] for parameters
            if (setInitAppString(XMLHandler.readStringFromXML()[0]) && setInitAppParams(XMLHandler.readStringFromXML()[1]))
            {
                this.initAppTextBox.Text = getInitAppString();
                this.initParamsTbx.Text = getInitAppParams();
            }
            //Create new sections for each app
            otherExesList = XMLHandler.readArrayFromXML();
            if (otherExesList != null)
            {
                foreach (OtherExeContainer exe in otherExesList)
                {
                    Section newExeSection = new Section();

                    newExeSection.addNewAppTbx.Text = exe.getExe();
                    newExeSection.addNewParamTbx.Text = exe.getParam();
                    this.flowLayoutPanel.Controls.Add(newExeSection);
                }
            }
            else
            {
                otherExesList = new List<OtherExeContainer>();
            }

            Program.isStarting = false;
        }

        public static string getExeDirectory()
        {
            //Not using Application.ExecutablePath as if the app is launched by Steam, would return wrong location.
            string directory = "";
            directory = System.IO.Path.GetDirectoryName(EXE_PATH);
            
            return directory;
        }

        public static string getXmlLocation()
        {
            string xmlLoc = Path.GetDirectoryName(EXE_PATH) + "\\" +XML_FILENAME;
            if (!File.Exists(xmlLoc))
            {
                File.Create(xmlLoc).Close();
                
            }
            
            return xmlLoc;
        }

        private void initAppBrowseBtn_Click(object sender, EventArgs e)
        {
            //When the browse button is clicked and a exe is selected, the application will save 
            //the fileLoc into the Array and save the icon to use for ProgramLauncher
            
            DialogResult result = initAppDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = initAppDialog.FileName;
                try
                {
                    if (!file.ToLower().Equals(EXE_PATH.ToLower()))
                    {
                        if (setInitAppString(file))
                        {
                            initAppTextBox.Text = getInitAppString();
                            Icon fileIcon = Icon.ExtractAssociatedIcon(file);

                            IconMessageBox iconMessageBox = new IconMessageBox(fileIcon);
                            iconMessageBox.Show();
                            this.Icon = fileIcon;
                        }
                    }
                    else
                    {
                        MessageBox.Show(EXE_PATH + " is not a valid executable, please choose a different application.");
                    }
                }
                catch (IOException)
                {
                }                
            }
        }

        private void addNewSectionBtn_Click(object sender, EventArgs e)
        {
            Section newSection = new Section();

            this.flowLayoutPanel.Controls.Add(newSection);

            if (this.splitContainer.Panel2Collapsed)
            {
                expandPanelBtn.Text = "Hide All";
                this.splitContainer.Panel2Collapsed = false;
                this.Size = this.splitContainer.Size;
            }
        }

        private void expandPanelBtn_Click(object sender, EventArgs e)
        {
            if (this.splitContainer.Panel2Collapsed)
            {
                expandPanelBtn.Text = "Hide All";
                this.splitContainer.Panel2Collapsed = false;
                this.Size = this.splitContainer.Size;
            }
            else
            {
                expandPanelBtn.Text = "Show All";
                this.splitContainer.Panel2Collapsed = true;
                this.Size -= this.splitContainer.Size;
            }
        }

        private void onFormClosing_Click(object sender, FormClosingEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("Do you want to save changes?");
            messageBoxCS.AppendLine();
            DialogResult dlg = MessageBox.Show(messageBoxCS.ToString(), "Program Launcher Settings", MessageBoxButtons.YesNoCancel);

            if(dlg == DialogResult.Yes){
                //Do Save and Close
                setInitAppParams(initParamsTbx.Text);
                XMLHandler.writeListAndStringToXML(otherExesList, initAppString, initAppParams, getXmlLocation());
            }
            else if (dlg == DialogResult.No)
            {
                //Do not save, then Close
            }
            else
            {
                //Abort Close
                e.Cancel = true;
            }

        }

        public static bool deleteExeFromArray(OtherExeContainer deleteExe)
        {
            foreach (OtherExeContainer oEC in otherExesList)
            {
                if(deleteExe.getExe().Equals(oEC.getExe())){
                    otherExesList.Remove(oEC);
                    return true;
                }
            }
            return false;
        }

        public static bool exeArrayContains(List<OtherExeContainer> oECList, string exePath)
        {
            foreach (OtherExeContainer oEC in oECList)
            {
                if (oEC.getExe().ToLower().Equals(exePath.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        //--------------------------------Setters and Getters-------------------------------

        public static bool setInitAppString(string appString)
        {
            //Check if the selected file exists and is an executable
            if (appString != null && File.Exists(appString) && (Path.GetExtension(appString) == ".exe"))
            {
                initAppString = appString;
                return true;
            }
            else
            {
                if (!Program.isStarting) MessageBox.Show("Please specify a Windows Executable.");
                return false;
            }
        }

        public static string getInitAppString()
        {
            if (initAppString.Equals(""))
            {
                setInitAppString(XMLHandler.readStringFromXML()[0]);
            }

            return initAppString;
        }

        public static bool setInitAppParams(string param)
        {
            if (param != null)
            {
                initAppParams = param;
                return true;
            }
            return false;
        }

        public static string getInitAppParams()
        {
            if (initAppParams.Equals(""))
            {
                setInitAppParams(XMLHandler.readStringFromXML()[1]);
            }
            return initAppParams;
        }

        public static bool setOtherExesArray(OtherExeContainer newExe)
        {
            //Check if the selected file exists and is an executable
            if (File.Exists(newExe.getExe()) && (Path.GetExtension(newExe.getExe()) == ".exe"))
            {
                otherExesList.Add(newExe);
                return true;
            }
            else
            {
                if (!Program.isStarting) MessageBox.Show("Please specify a Windows Executable.");
                
                return false;
            }
        }

        public static List<OtherExeContainer> getOtherExesArray()
        {
            //If no elements in the array
            if (!otherExesList.Any())
            {
                otherExesList = XMLHandler.readArrayFromXML();
            }

            return otherExesList;
        }
    }
}
