using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.CambiarPassword
{
    public partial class CambiarPassword : Form
    {
        Form parent;
        string username;

        public CambiarPassword(Form parent, string username)
        {
            InitializeComponent();
            this.username = username;
            this.parent = parent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Su nueva contrasena no puede ser nulo", "Contrasena vacia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("HARDCOR.cambiar_password_usuario", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@username", this.username));
                query.Parameters.Add(new SqlParameter("@nueva_password", this.textBox1.Text));

                connection.Open();
                query.ExecuteNonQuery();
            }
            MessageBox.Show("Se ha actualizado correctamente la contrasena de " + username, "Cambio exitoso",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
