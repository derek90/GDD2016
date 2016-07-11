﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class AltaContactoEmpresa : Form
    {
        int company_code = -1;
        string username;
        string password;

        public AltaContactoEmpresa(int company_code)
        {
            this.company_code = company_code;
            InitializeComponent();
            this.set_company(company_code);
            this.Text = "Modifique la empresa";
            this.button1.Text = "Modificar";
        }

        public AltaContactoEmpresa(string username, string password)
        {
            this.username = username;
            this.password = password;
            InitializeComponent();
        }

        private void set_company(int company_code)
        {
            SqlConnection connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("HARDCOR.obtener_empresa", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@codigo", company_code));

            connection.Open();
            this.set_textboxes(command.ExecuteReader());
            connection.Close();
        }

        public void set_textboxes (SqlDataReader reader)
        {
            reader.Read();
            this.textBox1.Text = reader["emp_razon_soc"].ToString();
            // Esto ni idea donde esta
            //this.textBox2.Text = reader["nombre_contacto"].ToString();
            // Esto tampoco
            //this.textBox3.Text = reader["rubro_principal"].ToString();
            this.textBox4.Text = reader["emp_cuit"].ToString();
            this.textBox5.Text = reader["nro_tel"].ToString();
            this.textBox6.Text = reader["mail"].ToString();
            this.textBox7.Text = reader["emp_ciudad"].ToString();
            this.textBox8.Text = reader["dom_calle"].ToString();
            this.numericUpDown1.Value = Int32.Parse(reader["nro_calle"].ToString());
            this.numericUpDown2.Value = Int32.Parse(reader["nro_piso"].ToString());
            this.textBox11.Text = reader["nro_dpto"].ToString();
            this.textBox12.Text = reader["localidad"].ToString();
            this.textBox13.Text = reader["cod_postal"].ToString();
            this.checkBox1.Checked = (bool) reader["habilitado"];
        }

        public bool there_are_empty_inputs()
        {
            List<TextBox> inputs = new List<TextBox> { this.textBox1, this.textBox2, this.textBox3, this.textBox4, this.textBox5,
                                                       this.textBox6, this.textBox7, this.textBox8, this.textBox11, this.textBox12,
                this.textBox13};
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

            if (this.company_code != -1)
                transaction_was_successful = this.update_company(connection);
            else
                transaction_was_successful = this.create_company(connection);

            if(transaction_was_successful)
                this.Close();
        }

        private bool update_company(SqlConnection connection) {
            SqlCommand update = new SqlCommand("HARDCOR.modificar_empresa", connection);
            update.CommandType = CommandType.StoredProcedure;

            update.Parameters.Add(new SqlParameter("@codigo", this.company_code));
            update.Parameters.Add(new SqlParameter("@razon_social", this.textBox1.Text));
            update.Parameters.Add(new SqlParameter("@cuit", this.textBox4.Text));
            update.Parameters.Add(new SqlParameter("@telefono", this.textBox5.Text));
            update.Parameters.Add(new SqlParameter("@mail", this.textBox6.Text));
            update.Parameters.Add(new SqlParameter("@ciudad", this.textBox7.Text));
            update.Parameters.Add(new SqlParameter("@direccion_calle", this.textBox8.Text));
            update.Parameters.Add(new SqlParameter("@direccion_numero", this.numericUpDown1.Value));
            update.Parameters.Add(new SqlParameter("@direccion_piso", this.numericUpDown2.Value));
            update.Parameters.Add(new SqlParameter("@numero_departamento", this.textBox11.Text));
            update.Parameters.Add(new SqlParameter("@localidad", this.textBox12.Text));
            update.Parameters.Add(new SqlParameter("@codigo_postal", this.textBox13.Text));
            update.Parameters.Add(new SqlParameter("@habilitado", this.checkBox1.Checked));

            connection.Open();
            bool update_was_ok = update.ExecuteNonQuery() > 0;
            if (update_was_ok)
                MessageBox.Show("La modificación de " + this.textBox1.Text + " ha sido exitosa!", "Modificación exitosa");
            else
                MessageBox.Show("El CUIT y razon social ya estan registradas para otra empresa", "Error en la modificación",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection.Close();

            return update_was_ok;
        }

        private bool create_company(SqlConnection connection)
        {
            SqlCommand create = new SqlCommand("HARDCOR.crear_empresa", connection);
            create.CommandType = CommandType.StoredProcedure;

            create.Parameters.Add(new SqlParameter("@username", this.username));
            create.Parameters.Add(new SqlParameter("@password", this.password));
            create.Parameters.Add(new SqlParameter("@codigo_rol", 3));
            create.Parameters.Add(new SqlParameter("@razon_social", this.textBox1.Text));
            create.Parameters.Add(new SqlParameter("@cuit", this.textBox4.Text));
            create.Parameters.Add(new SqlParameter("@telefono", this.textBox5.Text));
            create.Parameters.Add(new SqlParameter("@mail", this.textBox6.Text));
            create.Parameters.Add(new SqlParameter("@ciudad", this.textBox7.Text));
            create.Parameters.Add(new SqlParameter("@direccion_calle", this.textBox8.Text));
            create.Parameters.Add(new SqlParameter("@direccion_numero", this.numericUpDown1.Value));
            create.Parameters.Add(new SqlParameter("@direccion_piso", this.numericUpDown2.Value));
            create.Parameters.Add(new SqlParameter("@numero_departamento", this.textBox11.Text));
            create.Parameters.Add(new SqlParameter("@localidad", this.textBox12.Text));
            create.Parameters.Add(new SqlParameter("@codigo_postal", this.textBox13.Text));
            create.Parameters.Add(new SqlParameter("@habilitado", this.checkBox1.Checked));
            create.Parameters.Add(new SqlParameter("@fecha_creacion", DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString())));

            connection.Open();
            bool creation_was_ok = create.ExecuteNonQuery() > 0;
            if (creation_was_ok)
                MessageBox.Show("La creación de " + this.textBox1.Text + " ha sido exitosa!", "Creación exitosa");
            else
                MessageBox.Show("El CUIT y razon social ya estan registradas para otra empresa", "Error en la creación",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection.Close();

            return creation_was_ok;
        }
    }
}
