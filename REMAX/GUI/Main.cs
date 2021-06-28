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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        RemaxContext remax;
        private void Main_Load(object sender, EventArgs e)
        {
         remax  = new RemaxContext();
            var clientsid = from clientid in remax.Clients
                         select clientid.ClientId;

            cboProvince.DataSource = clientsid.ToList();


            foreach (Employee emp in remax.Employees)
            {
                cboAgentId.Items.Add(emp.VEmployeeId);
            }
        }

        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            var houses = from house in remax.Houses
                         where house.VRefClient == cboProvince.SelectedItem.ToString()
                         select house;
            gridHouses.DataSource = houses.ToList();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login1 = new Login();
            this.Hide();
            login1.ShowDialog();
            this.Close();
        }

        private void cboAgentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var employees = from emp in remax.Employees
                            where emp.VEmployeeId == cboAgentId.SelectedItem.ToString()
                            select emp;

            gridHouses.DataSource = employees.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var employees = from emp in remax.Employees
                            select emp;
            gridHouses.DataSource = employees.ToList();

        }
    }
}
