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
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
            fill_select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fill_select()
        {
            var roles = new List<KeyValuePair<int, string>>();
            using (SqlConnection connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("HARDCOR.get_roles", connection);
                connection.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                    roles.Add(new KeyValuePair<int, string>(Int32.Parse(reader["cod_fun"].ToString()), reader["descripcion"].ToString()));
            }
            Utils.populate(this.comboBox1, roles);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "" || this.textBox2.Text == "")
            {
                MessageBox.Show("Los campos de nombre de usuario y contraseña no pueden estar vacíos",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection connection = DBConnection.getInstance().getConnection();
            SqlCommand exists_user_command = new SqlCommand("SELECT HARDCOR.existe_usuario(@username)", connection);
            exists_user_command.Parameters.Add(new SqlParameter("@username", this.textBox1.Text));
            connection.Open();
            bool already_exists_user = (bool) exists_user_command.ExecuteScalar();
            connection.Close();
            if(already_exists_user)
            {
                MessageBox.Show("El nombre de usuario ya existe. Por favor, elija otro", "Usuario ya existente",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            KeyValuePair<string, int> selectedItem = (KeyValuePair<string, int>) this.comboBox1.SelectedItem;
            switch (selectedItem.Value)
            {
                case 3:
                    (new AltaContactoEmpresa(this.textBox1.Text, this.textBox2.Text)).Show();
                    break;
                case 4:
                    (new AltaContactoCliente(this.textBox1.Text, this.textBox2.Text)).Show();
                    break;
                default:
                    SqlCommand query = new SqlCommand("HARDCOR.crear_usuario", connection);
                    query.CommandType = CommandType.StoredProcedure;
                    query.Parameters.Add(new SqlParameter("@username", this.textBox1.Text));
                    query.Parameters.Add(new SqlParameter("@password", this.textBox2.Text));
                    query.Parameters.Add(new SqlParameter("@codigo_rol", selectedItem.Value));
                    connection.Open();
                    query.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El administrador " + this.textBox1.Text + " ha sido creado con éxito");
                    break;
            }
        }
    }
}
