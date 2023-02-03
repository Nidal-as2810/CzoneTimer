using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CzoneHeroTimer.Froms.screens
{
    public partial class controlLogin : UserControl
    {
        public controlLogin()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Panel pnlContainer = this.Parent as Panel;
            if (tbUsername.Text == "Admin" && tbPassword.Text == "admin")
            {
                controlMain control = new controlMain();

                pnlContainer.Controls.Clear();
                control.Location = new Point(((pnlContainer.Width - control.Width) / 2), ((pnlContainer.Height - control.Height) / 2));
                pnlContainer.Controls.Add(control);
            }
        }
    }
}
