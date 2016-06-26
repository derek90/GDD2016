﻿using System;
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
            this.textBox9.Text = reader["nro_calle"].ToString();
            this.textBox10.Text = reader["nro_piso"].ToString();
            this.textBox11.Text = reader["nro_dpto"].ToString();
            this.textBox12.Text = reader["localidad"].ToString();
            this.textBox13.Text = reader["cod_postal"].ToString();
        }

        public bool there_are_empty_inputs()
        {
            List<TextBox> inputs = new List<TextBox> { this.textBox1, this.textBox2, this.textBox3, this.textBox4, this.textBox5,
                                                       this.textBox6, this.textBox7, this.textBox8, this.textBox9, this.textBox10,
                                                       this.textBox11, this.textBox12, this.textBox13};
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
            update.Parameters.Add(new SqlParameter("@cuit", this.textBox2.Text));
            update.Parameters.Add(new SqlParameter("@telefono", this.textBox5.Text));
            update.Parameters.Add(new SqlParameter("@mail", this.textBox6.Text));
            update.Parameters.Add(new SqlParameter("@ciudad", this.textBox7.Text));
            update.Parameters.Add(new SqlParameter("@direccion_calle", this.textBox8.Text));
            update.Parameters.Add(new SqlParameter("@direccion_numero", this.textBox9.Text));
            update.Parameters.Add(new SqlParameter("@direccion_piso", this.textBox10.Text));
            update.Parameters.Add(new SqlParameter("@numero_departamento", this.textBox11.Text));
            update.Parameters.Add(new SqlParameter("@localidad", this.textBox12.Text));
            update.Parameters.Add(new SqlParameter("@codigo_postal", this.textBox13.Text));

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
            create.Parameters.Add(new SqlParameter("@cuit", this.textBox2.Text));
            create.Parameters.Add(new SqlParameter("@telefono", this.textBox5.Text));
            create.Parameters.Add(new SqlParameter("@mail", this.textBox6.Text));
            create.Parameters.Add(new SqlParameter("@ciudad", this.textBox7.Text));
            create.Parameters.Add(new SqlParameter("@direccion_calle", this.textBox8.Text));
            create.Parameters.Add(new SqlParameter("@direccion_numero", this.textBox9.Text));
            create.Parameters.Add(new SqlParameter("@direccion_piso", this.textBox10.Text));
            create.Parameters.Add(new SqlParameter("@numero_departamento", this.textBox11.Text));
            create.Parameters.Add(new SqlParameter("@localidad", this.textBox12.Text));
            create.Parameters.Add(new SqlParameter("@codigo_postal", this.textBox13.Text));

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

        private void textBox10_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(this.textBox10.Text);
                this.errorProvider1.SetError(this.textBox10, "");
                this.button1.Enabled = true;
            }
            catch
            {
                this.errorProvider1.SetError(this.textBox10, "El piso no es un número");
                this.button1.Enabled = false;
            }
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(this.textBox9.Text);
                this.errorProvider1.SetError(this.textBox9, "");
                this.button1.Enabled = true;
            }
            catch
            {
                this.errorProvider1.SetError(this.textBox9, "El numero de la direccion no es un número");
                this.button1.Enabled = false;
            }

        }
    }
}
