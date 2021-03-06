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
    public partial class ManageClients : Form
    {
        char mode;
        public ManageClients()
        {
            InitializeComponent();
        }
        RemaxContext remax;
        private void ManageClients_Load(object sender, EventArgs e)
        {
            remax = new RemaxContext();
            var clients = from client in remax.Clients
                          select client;

            gridclients.DataSource = clients.ToList();
            btnSave.Enabled = btnCancel.Enabled = false;


            foreach (Employee emp in remax.Employees)
            {
                cboEmpRef.Items.Add(emp.VEmployeeId);
            }
        }

        private void gridclients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string gridslct = gridclients.CurrentRow.Cells["ClientId"].Value.ToString();

            Client clients = (from client in remax.Clients
                                   where client.ClientId == gridslct
                                   select client).First();

            txtId.Text = clients.ClientId ;
            txtFname.Text = clients.FirstName;
            txtLname.Text = clients.LastName;
            txtPhone.Text = clients.PhoneNumber;
            txtEmail.Text = clients.Email;
            txtPassword.Text = clients.VPassword;
            cboEmpRef.Text = clients.VRefEmp;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = 'a';
            btnUpdate.Enabled = btnDelete.Enabled = btnAdd.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            mode = 'u';
            btnUpdate.Enabled = btnDelete.Enabled = btnAdd.Enabled = false;
            btnSave.Enabled = btnCancel.Enabled = true;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            remax = new RemaxContext();
            Client newclient = new Client();
            if (mode == 'a')
            {
                newclient.ClientId = txtId.Text.ToString();
                newclient.FirstName = txtFname.Text.ToString();
                newclient.LastName = txtLname.Text.ToString();
                newclient.Email = txtEmail.Text.ToString();
                newclient.PhoneNumber = txtPhone.Text.ToString();
                newclient.VPassword = txtPassword.Text.ToString();
                newclient.VRefEmp = cboEmpRef.Text.ToString();

                

                

                        remax.Clients.Add(newclient);
                        remax.SaveChanges();
                        MessageBox.Show("Client has been Added in Database");
                 
                    MessageBox.Show("Client already exist");
            

              
            }
            if (mode == 'u')
            {

                


                newclient.ClientId = txtId.Text.ToString();
                newclient.FirstName = txtFname.Text.ToString();
                newclient.LastName = txtLname.Text.ToString();
                newclient.Email = txtEmail.Text.ToString();
                newclient.PhoneNumber = txtPhone.Text.ToString();
                newclient.VPassword = txtPassword.Text.ToString();
                newclient.VRefEmp = cboEmpRef.Text.ToString();

                remax.Entry(newclient).State = System.Data.Entity.EntityState.Deleted;
                remax.SaveChanges();
                remax.Clients.Add(newclient);
                remax.SaveChanges();
                MessageBox.Show("Client has been Updated in Database");



            }

            var clients = from client in remax.Clients
                            select client;
            gridclients.DataSource = clients.ToList();
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
            txtId.Text = txtFname.Text = txtLname.Text = txtPassword.Text = txtPhone.Text = txtEmail.Text = cboEmpRef.Text = "";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
            txtId.Text = txtFname.Text = txtLname.Text = txtPassword.Text = txtPhone.Text = txtEmail.Text = cboEmpRef.Text = "";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Client clients = (from client in remax.Clients
                                   where client.ClientId == txtId.Text
                                   select client).FirstOrDefault();

            remax.Entry(clients).State = System.Data.Entity.EntityState.Deleted;
            remax.SaveChanges();

            var clients1 = from client in remax.Clients
                          select client;
            gridclients.DataSource = clients1.ToList();
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
