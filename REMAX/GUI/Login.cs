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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        RemaxContext remax;
        private void btnAdmin_Click(object sender, EventArgs e)
        {


            remax = new RemaxContext();
            Employee emp = null;
          
                emp = (from emp1 in remax.Employees
                       where emp1.VEmployeeId == txtUserId.Text && emp1.VPassword == txtPassword.Text && emp1.VType == EnumEmpType.Admin
                       select emp1).First();

                if (emp != null)
                {
                    MessageBox.Show("Loged in");
                    AdminForm admin = new AdminForm();
                    this.Hide();
                    admin.ShowDialog();
                    this.Close();

                }
            
            else
            
            {
                MessageBox.Show("Admin doesnt found");
                txtUserId.Text = "";
                txtPassword.Text = "";
                txtUserId.Focus();
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnAgent_Click(object sender, EventArgs e)
        {
            remax = new RemaxContext();

            Employee emp = null;
            emp = (from emp1 in remax.Employees
                   where emp1.VEmployeeId == txtUserId.Text && emp1.VPassword == txtPassword.Text && emp1.VType == EnumEmpType.Agent
                   select emp1).First();
            if (emp != null)
            {
                id.emp1 = txtUserId.Text;

                MessageBox.Show("Loged in");

                AgentForm agent = new AgentForm();
                this.Hide();
                agent.ShowDialog();
                this.Close();

            }

            else
                MessageBox.Show("Agent Does");
            txtUserId.Text = "";
            txtPassword.Text = "";
            txtUserId.Focus();



        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            remax = new RemaxContext();
            try
            {
                Client clients = null;
                clients = (from client in remax.Clients
                           where client.ClientId == txtUserId.Text && client.VPassword == txtPassword.Text
                           select client).First();
                if (clients != null)
                {
                    id.clid = txtUserId.Text;

                    MessageBox.Show("Loged in");

                    ClientHouses house = new ClientHouses();
                    this.Hide();
                    house.ShowDialog();
                    this.Close();

                }
            }
            catch
            {


                MessageBox.Show("Agent Does");
                txtUserId.Text = "";
                txtPassword.Text = "";
                txtUserId.Focus();
            }
        }
    }
}
