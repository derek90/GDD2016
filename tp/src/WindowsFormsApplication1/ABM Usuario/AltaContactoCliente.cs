using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class AltaContactoCliente : Form
    {
        int client_code = -1;
        string username;
        string password;

        public AltaContactoCliente(string username, string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.comboBox1.DataSource = getTiposDocFromDB();
        }

        public AltaContactoCliente(int client_code)
        {
            this.client_code = client_code;
            InitializeComponent();
            this.set_client(client_code);
            this.Text = "Modifique al cliente";
            this.button1.Text = "Modificar";
        }

        private List<string> getTiposDocFromDB()
        {
            List<string> tiposDoc = new List<string>();
            using (var connection = DBConnection.getInstance().getConnection())
            {
                connection.Open();
                SqlCommand query = Utils.create_sp("HARDCOR.obtener_tipos_doc", connection);
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    tiposDoc.Add((reader["documento"].ToString()));
                }
                return tiposDoc;
            }
        }

        private void set_client(int client_code)
        {
            SqlConnection connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("HARDCOR.obtener_cliente", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@codigo", client_code));

            connection.Open();
            this.set_textboxes(command.ExecuteReader());
            connection.Close();
        }

        public void set_textboxes (SqlDataReader reader)
        {
            reader.Read();
            this.textBox1.Text = reader["cli_nombre"].ToString();
            this.textBox2.Text = reader["cli_apellido"].ToString();
            this.numericUpDown1.Value = Int32.Parse(reader["cli_num_doc"].ToString());
            this.textBox5.Text = reader["nro_tel"].ToString();
            this.textBox6.Text = reader["mail"].ToString();
            this.dateTimePicker1.Text = reader["cli_fecha_Nac"].ToString();
            this.textBox8.Text = reader["dom_calle"].ToString();
            this.numericUpDown2.Value = Int32.Parse(reader["nro_calle"].ToString());
            this.numericUpDown3.Value = Int32.Parse(reader["nro_piso"].ToString());
            this.textBox11.Text = reader["nro_dpto"].ToString();
            this.textBox12.Text = reader["localidad"].ToString();
            this.textBox13.Text = reader["cod_postal"].ToString();
            this.checkBox1.Checked = (bool) reader["habilitado"];
        }

        public bool there_are_empty_inputs()
        {
            List<TextBox> inputs = new List<TextBox> { this.textBox1, this.textBox2, this.textBox5, this.textBox6,
                                                       this.textBox8, this.textBox11, this.textBox12, this.textBox13 };
            return inputs.Any((t) => t.Text == "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.there_are_empty_inputs())
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            SqlConnection connection = DBConnection.getInstance().getConnection();
            bool transaction_was_successful;

            if (this.client_code != -1)
                transaction_was_successful = this.update_client(connection);
            else
                transaction_was_successful = this.create_client(connection);

            if(transaction_was_successful)
                this.Close();
        }

        private bool update_client(SqlConnection connection) {
            SqlCommand update = new SqlCommand("HARDCOR.modificar_cliente", connection);
            update.CommandType = CommandType.StoredProcedure;

            update.Parameters.Add(new SqlParameter("@codigo", this.client_code));
            update.Parameters.Add(new SqlParameter("@nombre", this.textBox1.Text));
            update.Parameters.Add(new SqlParameter("@apellido", this.textBox2.Text));
            update.Parameters.Add(new SqlParameter("@dni", this.numericUpDown1.Value));
            update.Parameters.Add(new SqlParameter("@telefono", this.textBox5.Text));
            update.Parameters.Add(new SqlParameter("@mail", this.textBox6.Text));
            update.Parameters.Add(new SqlParameter("@fecha_nacimiento", this.dateTimePicker1.Value));
            update.Parameters.Add(new SqlParameter("@direccion_calle", this.textBox8.Text));
            update.Parameters.Add(new SqlParameter("@direccion_numero",this.numericUpDown2.Value));
            update.Parameters.Add(new SqlParameter("@direccion_piso", this.numericUpDown3.Value));
            update.Parameters.Add(new SqlParameter("@numero_departamento", this.textBox11.Text));
            update.Parameters.Add(new SqlParameter("@ciudad", this.textBox12.Text));
            update.Parameters.Add(new SqlParameter("@codigo_postal", this.textBox13.Text));
            update.Parameters.Add(new SqlParameter("@habilitado", this.checkBox1.Checked));

            connection.Open();
            bool update_was_ok = update.ExecuteNonQuery() > 0;
            if (update_was_ok)
                MessageBox.Show("La modificación de " + this.textBox1.Text + " ha sido exitosa!", "Modificación exitosa");
            else
                MessageBox.Show("El tipo y número de documento pertenecen a otra persona", "Error en la modificación",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection.Close();

            return update_was_ok;
        }

        private bool create_client(SqlConnection connection)
        {
            SqlCommand create = new SqlCommand("HARDCOR.crear_cliente", connection);
            create.CommandType = CommandType.StoredProcedure;

            create.Parameters.Add(new SqlParameter("@username", this.username));
            create.Parameters.Add(new SqlParameter("@password", this.password));
            create.Parameters.Add(new SqlParameter("@codigo_rol", 4));
            create.Parameters.Add(new SqlParameter("@nombre", this.textBox1.Text));
            create.Parameters.Add(new SqlParameter("@apellido", this.textBox2.Text));
            create.Parameters.Add(new SqlParameter("@dni", this.numericUpDown1.Value));
            create.Parameters.Add(new SqlParameter("@telefono", this.textBox5.Text));
            create.Parameters.Add(new SqlParameter("@mail", this.textBox6.Text));
            create.Parameters.Add(new SqlParameter("@fecha_nacimiento", this.dateTimePicker1.Value));
            create.Parameters.Add(new SqlParameter("@fecha_creacion", DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString())));
            create.Parameters.Add(new SqlParameter("@direccion_calle", this.textBox8.Text));
            create.Parameters.Add(new SqlParameter("@direccion_numero", this.numericUpDown2.Value));
            create.Parameters.Add(new SqlParameter("@direccion_piso", this.numericUpDown3.Value));
            create.Parameters.Add(new SqlParameter("@numero_departamento", this.textBox11.Text));
            create.Parameters.Add(new SqlParameter("@localidad", this.textBox12.Text));
            create.Parameters.Add(new SqlParameter("@codigo_postal", this.textBox13.Text));
            create.Parameters.Add(new SqlParameter("@habilitado", this.checkBox1.Checked));
            create.Parameters.Add(new SqlParameter("@tipo_doc", this.comboBox1.SelectedItem));

            connection.Open();
            bool creation_was_ok = create.ExecuteNonQuery() > 0;
            if (creation_was_ok)
                MessageBox.Show("La creación de " + this.textBox1.Text + " ha sido exitosa!", "Creación exitosa");
            else
                MessageBox.Show("El tipo y número de documento pertenecen a otra persona", "Error en la creación",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection.Close();

            return creation_was_ok;
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if(this.dateTimePicker1.Value >= DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString()))
            {
                this.errorProvider1.SetError(this.dateTimePicker1, "La fecha de nacimiento no puede ser mayor a la fecha actual");
                this.button1.Enabled = false;
            }
            else
            {
                this.errorProvider1.SetError(this.dateTimePicker1, "");
                this.button1.Enabled = true;
            }
        }
    }
}
