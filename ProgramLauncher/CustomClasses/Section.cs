using ProgramLauncher.CustomClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramLauncher
{
    class Section : System.Windows.Forms.Panel
    {
        Label addNewAppLabel = new Label();
        Label addNewParamLabel = new Label();

        public TextBox addNewAppTbx = new TextBox();
        public TextBox addNewParamTbx = new TextBox();

        Button browseNewAppBtn = new Button();
        Button removeSectionBtn = new Button();


        public Section()
        {
            initSection();
        }

        private void initSection(){
            this.Size = new Size(583, 64);
            this.SendToBack();

            addNewAppLabel.Text = "Application to launch:";
            addNewAppLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            addNewAppLabel.Size = new System.Drawing.Size(120, 13);
            addNewAppLabel.Location = new System.Drawing.Point(19, 0);

            addNewAppTbx.ReadOnly = true;
            addNewAppTbx.BackColor = Color.White;
            addNewAppTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            addNewAppTbx.Size = new System.Drawing.Size(276, 20);
            addNewAppTbx.Location = new System.Drawing.Point(19, 25);

            addNewParamLabel.Text = "Parameters:";
            addNewParamLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            addNewParamLabel.Size = new System.Drawing.Size(63, 13);
            addNewParamLabel.Location = new System.Drawing.Point(304, 0);

            addNewParamTbx.BackColor = Color.White;
            addNewParamTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            addNewParamTbx.Size = new System.Drawing.Size(185, 20);
            addNewParamTbx.Location = new System.Drawing.Point(306, 25);
            addNewParamTbx.TextChanged += new System.EventHandler(addNewParamTbx_OnTextChange);


            browseNewAppBtn.Text = "Browse";
            browseNewAppBtn.Click += new System.EventHandler(browseNewAppBtn_Click);
            browseNewAppBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Right));
            browseNewAppBtn.Size = new System.Drawing.Size(75, 23);
            browseNewAppBtn.Location = new System.Drawing.Point(503, 23);

            removeSectionBtn.Text = "X";
            removeSectionBtn.Click += new System.EventHandler(removeSectionBtn_Click);
            removeSectionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            removeSectionBtn.Size = new System.Drawing.Size(20, 20);
            removeSectionBtn.Location = new System.Drawing.Point(558, 0);


            this.Controls.Add(addNewAppLabel);
            this.Controls.Add(addNewAppTbx);
            this.Controls.Add(addNewParamLabel);
            this.Controls.Add(addNewParamTbx);
            this.Controls.Add(browseNewAppBtn);
            this.Controls.Add(removeSectionBtn);
        }

        private void removeSectionBtn_Click(Object sender, System.EventArgs e)
        {
            
            try
            {
                //-6,-6 is the magic number that allows the sections to not slowly move down when deleted..
                this.Size = new System.Drawing.Size(-6, -6);

                ProgramLauncher.CustomClasses.OtherExeContainer oEC = new ProgramLauncher.CustomClasses.OtherExeContainer();
                oEC.setExe(addNewParamTbx.Text);

                ConfigForm.deleteExeFromArray(oEC);

                this.Controls.Remove(addNewAppLabel);
                this.Controls.Remove(addNewAppTbx);

                this.Controls.Remove(addNewParamLabel);
                this.Controls.Remove(addNewParamTbx);

                this.Controls.Remove(browseNewAppBtn);
                this.Controls.Remove(removeSectionBtn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong when deleting this program... \n\n" + ex.ToString());
            }
        }

        private void browseNewAppBtn_Click(Object sender, System.EventArgs e)
        {
            OpenFileDialog newAppDialog = new OpenFileDialog();
            newAppDialog.Filter = "Exe files (*.exe)|*.exe|All files (*.*)|*.*";

            DialogResult result = newAppDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ProgramLauncher.CustomClasses.OtherExeContainer oEC = new CustomClasses.OtherExeContainer();
                oEC.setExe(addNewAppTbx.Text);

                ConfigForm.deleteExeFromArray(oEC);
                string file = newAppDialog.FileName;
                try
                {
                    if (!file.ToLower().Equals(ConfigForm.EXE_PATH.ToLower()))
                    {
                        oEC.setExe(file);
                        oEC.setParam(addNewAppTbx.Text);
                        if (ConfigForm.setOtherExesArray(oEC)) addNewAppTbx.Text = file;
                    }
                    else
                    {
                        MessageBox.Show(ConfigForm.EXE_PATH + " is not a valid executable, please choose a different application.");
                    }
                }
                catch (IOException)
                {
                }
            }
        }

        private void addNewParamTbx_OnTextChange(Object sender, System.EventArgs e)
        {
            string exeText = addNewAppTbx.Text;
            foreach (OtherExeContainer oEC in ConfigForm.getOtherExesArray()){
                if(oEC.getExe().ToLower().Equals(exeText.ToLower())){
                    oEC.setParam(addNewParamTbx.Text);
                }
            }
        }
    }
}
