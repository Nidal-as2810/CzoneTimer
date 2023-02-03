namespace CzoneHeroTimer.Froms.formScreens
{
    public partial class frm_Settings : frm_Default
    {
        public frm_Settings()
        {
            InitializeComponent();
            load();
        }

        public override void Save()
        {
            //Properties.Settings.Default.DatabaseConnection = tbDatabase.Text;
            //Properties.Settings.Default.NormalHours = double.Parse(tbNormalHours.Text);
            //Properties.Settings.Default.BreakTime = double.Parse(tbBreak.Text);

            //Properties.Settings.Default.Save();
            //MessageBox.Show("Succesfully Saved!");
        }

        public void load()
        {
            //tbDatabase.Text = Properties.Settings.Default.DatabaseConnection;
            //tbNormalHours.Text = Properties.Settings.Default.NormalHours.ToString("n2");
            //tbBreak.Text = Properties.Settings.Default.BreakTime.ToString("n2");
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                tbDatabase.Text = folder.SelectedPath;
            }
        }
    }
}
