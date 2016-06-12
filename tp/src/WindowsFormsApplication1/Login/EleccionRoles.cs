using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Login
{
    public partial class EleccionRoles : Form
    {
        public EleccionRoles(List<KeyValuePair<int, string>> roles)
        {
            InitializeComponent();
            this.fill_select(roles);
        }

        private void fill_select(List<KeyValuePair<int, string>> roles)
        {
            this.comboBox1.DisplayMember = "Value";
            this.comboBox1.ValueMember = "Key";

            foreach (var pair in roles)
                this.comboBox1.Items.Add(pair);

            // Para que seleccione el primer elemento de la lista
            this.comboBox1.SelectedItem = this.comboBox1.Items[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new Login()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selected_value = ((KeyValuePair<int, string>)this.comboBox1.SelectedItem).Key;
            (new Menu_principal.MainMenu(selected_value)).Show();
            this.Close();
        }
    }
}
