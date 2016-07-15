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

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class ModificarPassword : Form
    {
        Form parent;

        public ModificarPassword(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            Paginator paginator = new Paginator(this.numericUpDown1, this.dataGridView1, "HARDCOR.listar_usuarios",
                                                this.button3, this.button4, this.label3, 10);
            paginator.load_page(0);
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
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe elegir una usuario", "Usuario no elegido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string username;
            using(var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("HARDCOR.cambiar_password_usuario", connection);
                query.CommandType = CommandType.StoredProcedure;
                username = this.dataGridView1.SelectedRows[0].Cells["username"].Value.ToString();
                query.Parameters.Add(new SqlParameter("@username", username));
                query.Parameters.Add(new SqlParameter("@nueva_password", this.textBox1.Text));

                connection.Open();
                query.ExecuteNonQuery();
            }
            MessageBox.Show("Se ha actualizado correctamente la contrasena de " + username, "Cambio exitoso",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
