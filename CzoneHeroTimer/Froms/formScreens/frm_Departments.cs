using CzoneHeroTimer.Data.Repository;
using CzoneHeroTimer.Modules;

namespace CzoneHeroTimer.Froms.formScreens
{
    public partial class frm_Departments : frm_Default
    {
        public frm_Departments()
        {
            InitializeComponent();
            
            Reload();
        }
        Department department;
        public override void New()
        {
            department = new Department();
            textBox1.Text = department.Name;
            base.New();
        }
        public override void Save()
        {
            DepartmentRepository db = new DepartmentRepository();
            department.Name = textBox1.Text;
            if (department.Id == 0)
            {
                db.Add(department);
                    MessageBox.Show("Succesfully saved! ^_^");
            }
            else
            {
                db.Update(department);
            }
            base.Save();
        }
        public override void Delete()
        {
            DepartmentRepository db = new DepartmentRepository();

            db.Delete(department);
            base.Delete();
        }
        public override void Reload()
        {
            
            DepartmentRepository db = new DepartmentRepository();
            dataGridView1.DataSource=db.getAll();
            base.Reload();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            department = new Department();
            department.Id =(int) dataGridView1.CurrentRow.Cells[0].Value;
            department.Name= dataGridView1.CurrentRow.Cells[1].Value.ToString();

            textBox1.Text = department.Name;
        }
    }
}
