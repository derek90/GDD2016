using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Login
{
    public partial class EleccionRoles : Form
    {
        Dictionary<int, String> roles;

        public EleccionRoles(Dictionary<int, string> roles)
        {
            InitializeComponent();
            this.roles = roles;
            this.fill_select();

        }

        private void fill_select()
        {
            this.comboBox1.DisplayMember = "Value";
            this.comboBox1.ValueMember = "Key";

            foreach (var pair in this.roles)
                this.comboBox1.Items.Add(pair);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).Show();
        }
    }
}
