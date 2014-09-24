using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramLauncher
{

    //IconMessageBox is a custom form to be displayed as a popup that allows the user
    //to see the Icon of the executable that ProgramLauncher will be replacing.
    class IconMessageBox : Form
    {
        PictureBox pictureBox = new PictureBox();
        Icon fileIcon = null;
        Image displayImage = null;

        public IconMessageBox(Icon icon)
        {
            fileIcon = icon;
            displayImage = icon.ToBitmap();

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //Header Changes
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Icon";
            this.Icon = fileIcon;
            
            //General Window changes
            this.Size = displayImage.Size;
            this.AutoSize = true;
            this.StartPosition = FormStartPosition.CenterParent;
            //Disables the ability to resize the window
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            Label label = new Label();
            label.Location = new System.Drawing.Point(0, displayImage.Height/2 - 6);
            label.Text = "Icon to be displayed: ";
            label.AutoSize = true;

            pictureBox.Image = displayImage;
            pictureBox.Size = displayImage.Size;
            pictureBox.Location = new System.Drawing.Point(label.Width+10, 0);

            this.Controls.Add(label);
            this.Controls.Add(pictureBox);
        }

        private void okBtn_Click(Object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}
