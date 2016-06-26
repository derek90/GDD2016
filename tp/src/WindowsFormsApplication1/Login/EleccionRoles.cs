using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Login
{
    public partial class EleccionRoles : Form
    {
        Form login_form;

        public EleccionRoles(Form login_form, List<KeyValuePair<int, string>> roles)
        {
            InitializeComponent();
            this.login_form = login_form;
            Utils.populate(this.comboBox1, roles);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new Login()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selected_value = ((KeyValuePair<int, string>)this.comboBox1.SelectedItem).Key;
            (new Menu_principal.MainMenu(this.login_form, selected_value)).Show();
            this.Close();
        }
    }
}
