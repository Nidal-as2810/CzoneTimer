using CzoneHeroTimer.Data;
using CzoneHeroTimer.Froms.screens;
using CzoneHeroTimer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CzoneHeroTimer.Froms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            if (!Directory.Exists(Application.StartupPath + "data"))
            {
                Directory.CreateDirectory(Application.StartupPath + "data");
            }
            
            DataAccess data=new DataAccess();
            
            controlLogin control = new controlLogin();
            //controlMain main=new controlMain();
            //showControls(main);
            showControls(control);
        }
        public void showControls(Control control)
        {
            pnlContainer.Controls.Clear();
            control.Location = new Point(((pnlContainer.Width - control.Width) / 2), ((pnlContainer.Height - control.Height) / 2));
            pnlContainer.Controls.Add(control);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            //pictureBox2.Image = Properties.Resources.Close;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.closewhite;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.Close;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
