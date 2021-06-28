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
    public partial class AdminManageHouse : Form
    {
        public AdminManageHouse()
        {
            InitializeComponent();
        }
        char mode;
        private void label5_Click(object sender, EventArgs e)
        {

        }
        RemaxContext remax;
        private void AdminManageHouse_Load(object sender, EventArgs e)
        {
            remax = new RemaxContext();

            var houses = from house in remax.Houses
                         select house;
            gridHouses.DataSource = houses.ToList();

            foreach (Client client in remax.Clients)
            {
                cboRefClient.Items.Add(client.ClientId);
            }

            foreach (var item in Enum.GetValues(typeof(EnumHuoseType)))
            {
                cboHouseType.Items.Add(item);
            }

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
         

                try
                {
                  House  house = (from house1 in remax.Houses
                           where house1 == newhouse
                           select house1).First();
                    if (house == null)
                    {

                        remax.Houses.Add(newhouse);
                        remax.SaveChanges();
                        MessageBox.Show("House has been Added in Database");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("House with the Same Number  already exist");
                }

                remax.Houses.Add(newhouse);
         
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


            }

            var houses = from house in remax.Houses
                            select house;
            gridHouses.DataSource = houses.ToList();
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

            var clients1 = from client in remax.Clients
                           select client;
            gridHouses.DataSource = clients1.ToList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            AdminForm  admin= new AdminForm();
            this.Hide();
            admin.ShowDialog();
            this.Close();
        }
    }
}
