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
    public partial class AgentHouses : Form
    {
        string empid = id.emp1;
        char mode;
        RemaxContext remax;
        public AgentHouses()
        {
            InitializeComponent();
        }

        private void AgentHouses_Load(object sender, EventArgs e)
        {
            remax = new RemaxContext();
            foreach (var item in Enum.GetValues(typeof(EnumHuoseType)))
            {
                cboHouseType.Items.Add(item);
            }

            var clients = from client in remax.Clients
                           where client.VRefEmp == empid
                           select client.ClientId;

            var clients1 = from client in remax.Clients
                          where client.VRefEmp == empid
                          select new { client.ClientId, client.FirstName };

            //foreach(Employee emp in remax.Employees)
            //{
            //    if(emp.VEmployeeId==empid && emp.VType==EnumEmpType.Agent)
            //    {

            //    }
            //}
            //if(remax.Employees)

            cboRefClient.DataSource = clients.ToList();
            lisClients.DisplayMember = "FirstName";
            lisClients.ValueMember = "ClientId";
            lisClients.DataSource = clients1.ToList();


        }

        private void lisClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            var houses = from house in remax.Houses
                         where house.VRefClient == lisClients.SelectedValue.ToString()
                         select house;
            gridHouses.DataSource = houses.ToList();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gridHouses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string gridslct = gridHouses.CurrentRow.Cells["HouseNumber"].Value.ToString();

            House houses = (from house in remax.Houses
                            where house.HouseNumber == gridslct
                            select house).First();

            txtId.Text = houses.HouseNumber;
            txtAddress.Text = houses.Address;
            txtCity.Text = houses.City;
            txtPostalCode.Text = houses.PostalCode;
            txtProvince.Text = houses.Province;
            cboHouseType.Text = houses.VHouseType.ToString();
            cboRefClient.Text = houses.VRefClient.ToString();
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
            House newhouse = new House();
            if (mode == 'a')
            {
                newhouse.HouseNumber = txtId.Text.ToString();
                newhouse.Address = txtAddress.Text.ToString();
                newhouse.City = txtCity.Text.ToString();
                newhouse.Province = txtProvince.Text.ToString();
                newhouse.PostalCode = txtPostalCode.Text.ToString();
                newhouse.VHouseType = (EnumHuoseType)cboHouseType.SelectedItem;
                newhouse.VRefClient = cboRefClient.SelectedItem.ToString();

                remax.Houses.Add(newhouse);
                remax.SaveChanges();
                MessageBox.Show("House has been Added in Database");
            }
            if (mode == 'u')
            {

                newhouse.HouseNumber = txtId.Text.ToString();
                newhouse.Address = txtAddress.Text.ToString();
                newhouse.City = txtCity.Text.ToString();
                newhouse.Province = txtProvince.Text.ToString();
                newhouse.PostalCode = txtPostalCode.Text.ToString();
                newhouse.VHouseType = (EnumHuoseType)cboHouseType.SelectedItem;
                newhouse.VRefClient = cboRefClient.SelectedItem.ToString();


                remax.Entry(newhouse).State = System.Data.Entity.EntityState.Deleted;
                remax.SaveChanges();
                remax.Houses.Add(newhouse);
                remax.SaveChanges();
                MessageBox.Show("House has been Updated");

            }

            
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
            txtId.Text = txtAddress.Text = txtCity.Text = txtProvince.Text = txtPostalCode.Text = cboHouseType.Text = cboRefClient.Text = "";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = btnCancel.Enabled = false;
            txtId.Text = txtAddress.Text = txtCity.Text = txtProvince.Text = txtPostalCode.Text = cboHouseType.Text = cboRefClient.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            House houses = (from house in remax.Houses
                            where house.HouseNumber == txtId.Text
                            select house).FirstOrDefault();

            remax.Entry(houses).State = System.Data.Entity.EntityState.Deleted;
            remax.SaveChanges();

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            AgentForm agent = new AgentForm();
            this.Hide();
            agent.ShowDialog();
            this.Close();
        }
    }
}
