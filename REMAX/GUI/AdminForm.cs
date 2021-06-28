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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
           
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void housesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminManageHouse houses = new AdminManageHouse();
            this.Hide();
            houses.ShowDialog();
            this.Close();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageEmployees employees = new ManageEmployees();
            this.Hide();
            employees.ShowDialog();
            this.Close();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClients clients = new ManageClients();
            this.Hide();
            clients.ShowDialog();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login1 = new Login();
            this.Hide();
            login1.ShowDialog();
            this.Close();
        }
    }
}
