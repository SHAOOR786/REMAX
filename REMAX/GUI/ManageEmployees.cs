using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REMAX.GUI
{
    public partial class ManageEmployees : Form
    {
        public ManageEmployees()
        {
            InitializeComponent();
        }
        RemaxContext remax;
        char mode;
        private void ManageEmployees_Load(object sender, EventArgs e)
        {

            btnSave.Enabled = btnCancel.Enabled = false;



            remax = new RemaxContext();

            var employees1 = from employee in remax.Employees
                             select employee;

            dataGridView1.DataSource = employees1.ToList();


           

            foreach (EnumEmpType row in Enum.GetValues(typeof(EnumEmpType)))
            {
                CboEmpType.Items.Add(row);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string gridslct = dataGridView1.CurrentRow.Cells["VEmployeeId"].Value.ToString();

            Employee anemployee = (from admin in remax.Employees
                                   where admin.VEmployeeId == gridslct
                                   select admin).First();

            txtId.Text = anemployee.VEmployeeId;
            txtFname.Text = anemployee.VFName;
            txtLname.Text = anemployee.VLName;
            txtFname.Text = anemployee.VFName;
            txtPhone.Text = anemployee.VPhone;
            txtEmail.Text = anemployee.VEmail;
            txtPassword.Text = anemployee.VPassword;
            CboEmpType.Text = anemployee.VType.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = 'a';
            btnUpdate.Enabled = btnDelete.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            mode = 'u';
            btnAdd.Enabled = btnDelete.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = true;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            remax = new RemaxContext();
            Employee newemployee = new Employee();
            if (mode == 'a')
            {
                newemployee.VEmployeeId = txtId.Text.ToString();
                newemployee.VFName = txtFname.Text.ToString();
                newemployee.VLName = txtLname.Text.ToString();
                newemployee.VEmail = txtEmail.Text.ToString();
                newemployee.VPhone = txtPhone.Text.ToString();
                newemployee.VPassword = txtPassword.Text.ToString();
                newemployee.VType = (EnumEmpType)CboEmpType.SelectedItem;




                        remax.Employees.Add(newemployee);
                        remax.SaveChanges();
                        MessageBox.Show("Employee has been Added in Database");
        
              


            }
            if (mode == 'u')
            {

                Employee anEmployee = new Employee();


                anEmployee.VEmployeeId = txtId.Text;
                anEmployee.VFName = txtFname.Text;
                anEmployee.VLName = txtLname.Text;
                anEmployee.VPhone = txtPhone.Text;
                anEmployee.VEmail = txtEmail.Text;
                anEmployee.VType = (EnumEmpType)CboEmpType.SelectedItem;
                anEmployee.VPassword = txtPassword.Text;

                remax.Entry(anEmployee).State = System.Data.Entity.EntityState.Deleted;
                remax.SaveChanges();
                remax.Employees.Add(anEmployee);
                remax.SaveChanges();

               
            }

            var employees = from employee in remax.Employees
                            select employee;
            dataGridView1.DataSource = employees.ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled= true;
            btnSave.Enabled = btnCancel.Enabled = true;
            txtId.Text = txtFname.Text = txtLname.Text = txtPassword.Text = txtPhone.Text = txtEmail.Text = CboEmpType.Text = "";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Employee anEmployee = (from employee in remax.Employees
                             where employee.VEmployeeId == txtId.Text
                             select employee).FirstOrDefault();

            remax.Entry(anEmployee).State = System.Data.Entity.EntityState.Deleted;
            remax.SaveChanges();

            var employees = from employee in remax.Employees
                         select employee;
            dataGridView1.DataSource = employees.ToList();


        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            this.Hide();
            admin.ShowDialog();
            this.Close();
        }
    }
}

