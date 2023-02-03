using CzoneHeroTimer.Data.Repository;
using CzoneHeroTimer.Modules;

namespace CzoneHeroTimer.Froms.formScreens
{
    public partial class frm_Users : frm_Default
    {
        public frm_Users()
        {
            InitializeComponent();
            getDapartments();
            Reload();
        }
        User user;
        public override void New()
        {
            user = new User();
            textBox1.Text = user.Username;
            textBox2.Text=user.Password;
            
            base.New();
        }
        public override void Save()
        {
            UserRepository db= new UserRepository();

            user.Username = textBox1.Text;
            user.Password = textBox2.Text;
            user.UserRole = comboBox1.Text;
            user.DepartmentId =(int) comboBox2.SelectedValue;

            if (user.Id == 0)
                db.Add(user);
            else
                db.Update(user);

            base.Save();
        }
        public override void Delete()
        {
            UserRepository db = new UserRepository();

            if ( user.Id>0)
                db.Delete(user);
            base.Delete();
        }
        public override void Reload()
        {
            UserRepository db = new UserRepository();
            List<User> users= db.getAll();
            
            //List<Department> departments=departmentRepository.getAll();

            foreach (User user in users)
            {
                user.Department = departments.FirstOrDefault(d => d.Id == user.DepartmentId);
            }

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = users;

            base.Reload();
        }
        List<Department> departments;
        private void getDapartments() { 
            DepartmentRepository db = new DepartmentRepository();
            departments = db.getAll();

            comboBox2.DataSource = departments;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            UserRepository db = new UserRepository();
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            user = db.getAll().FirstOrDefault(x => x.Id == id);

            textBox1.Text = user.Username;
            textBox2.Text = user.Password;
            comboBox1.Text = user.UserRole;
            comboBox2.SelectedValue = user.DepartmentId;
        }
    }
}
