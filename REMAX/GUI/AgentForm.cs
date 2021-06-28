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
    public partial class AgentForm : Form
    {
        public AgentForm()
        {
            InitializeComponent();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgentClients client = new AgentClients();
            this.Hide();
            client.ShowDialog();
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

        private void housesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgentHouses house = new AgentHouses();
            this.Hide();
            house.ShowDialog();
            this.Close();
        }
    }
}
