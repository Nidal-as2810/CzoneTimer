using CzoneHeroTimer.Data;
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
    public partial class frm_Default : Form 
     {
        
        public frm_Default()
        {
            InitializeComponent();
        }

        
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void New() { }
        public virtual void Save() { Reload(); }
        public virtual void Delete() { Reload(); }
        public virtual void Reload() { New(); }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Reload();
        }
    }
}
