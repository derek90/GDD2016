using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connection = DBConnection.getInstance().getConnection();

            SqlCommand command = new SqlCommand("HARDCOR.login", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@username", this.textBox1.Text));
            command.Parameters.Add(new SqlParameter("@password", this.textBox2.Text));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<KeyValuePair<int, string>> role_codes = new List<KeyValuePair<int, string>>();
            if (!reader.HasRows)  // El usuario no existe
                MessageBox.Show("El usuario " + this.textBox1.Text + " no está registrado en el sistema",
                    "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                while (reader.Read())
                {
                    if (!(bool)reader["login_valido"])
                    {
                        string message;
                        if ((bool)reader["habilitado"])
                            message = "La contraseña es incorrecta. Tiene " + (3 - (Int32.Parse(reader["intentos"].ToString()))) + " intentos disponibles";
                        else
                            message = "Su usuario ha sido bloqueado";

                        MessageBox.Show(message, "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                        role_codes.Add(new KeyValuePair<int, string> (Int32.Parse(reader["cod_rol"].ToString()),
                                                                      reader["nombre"].ToString()));
                }
            reader.Close();
            connection.Close();

            if (role_codes.Count > 0)
                this.Hide();
            if (role_codes.Count == 1)
                (new Menu_principal.MainMenu(this, Int32.Parse(role_codes[0].Key.ToString()), this.textBox1.Text)).Show();
            if (role_codes.Count > 1) 
                (new EleccionRoles(this, this.textBox1.Text, role_codes)).Show();

            this.textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
