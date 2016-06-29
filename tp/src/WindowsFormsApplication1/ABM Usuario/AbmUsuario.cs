using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class AbmUsuario : Form
    {
        Form parent;
        public AbmUsuario(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (new AltaUsuario()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new AltaUsuario()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new ModificacionCliente()).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            (new ModificacionEmpresa()).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
