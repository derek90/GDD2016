using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class AMBPublicacion : Form
    {
        Form parent;
        string username;

        public AMBPublicacion(Form parent, string username)
        {
            this.parent = parent;
            this.username = username;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new GenerarPublicacion(this, this.username)).Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new ModificarPublicacion(this, this.username)).Show();
            this.Hide();
        }
    }
}
