﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class ModificacionCliente : Form
    {
        String select_query =  "HARDCOR.listar_clientes";
        SqlDataAdapter adapter;
        Dictionary<int, string> tiposDoc;

        public ModificacionCliente()
        {
            InitializeComponent();
            this.tiposDoc = getTiposDocFromDB();
            this.comboBox1.DataSource = this.tiposDoc.Values.ToList();
        }

        private Dictionary<int, string> getTiposDocFromDB()
        {
            using (var connection = DBConnection.getInstance().getConnection())
            {
                connection.Open();
                SqlCommand query = Utils.create_sp("HARDCOR.obtener_tipos_doc", connection);
                SqlDataReader reader = query.ExecuteReader();
                Dictionary<int, string> tiposDoc = new Dictionary<int, string>();
                tiposDoc.Add(0, "");
                while (reader.Read())
                {
                    tiposDoc.Add(Convert.ToInt32(reader["cod_doc"]), reader["documento"].ToString());
                }
                return tiposDoc;
            }
        }

        public void fill_data_set(string name, string lastname, string mail, int dni, int tipoDoc)
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand(this.select_query, connection);

            //Seteo que sea un stored procedure
            query.CommandType = CommandType.StoredProcedure;

            //Agrego los parámetros
            query.Parameters.Add(new SqlParameter("@nombre", name));
            query.Parameters.Add(new SqlParameter("@apellido", lastname));
            query.Parameters.Add(new SqlParameter("@dni", dni));
            query.Parameters.Add(new SqlParameter("@email", mail));
            query.Parameters.Add(new SqlParameter("@tipo_doc", tipoDoc));

            //Creo el adapter usando el select_query
            this.adapter = new SqlDataAdapter(query);

            //Lleno el dataset y lo seteo como source del dataGridView
            DataTable table = new DataTable();
            this.adapter.Fill(table);
            this.dataGridView1.DataSource = table;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AllowUserToAddRows = false;

            //Oculto la columna de pk
            this.dataGridView1.Columns[0].Visible = false;

            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.fill_data_set(this.textBox4.Text, this.textBox1.Text,
                               this.textBox3.Text, (int) this.numericUpDown1.Value, (int)tiposDoc.FirstOrDefault(x => x.Value == comboBox1.Text).Key);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox box in (new List<TextBox> { this.textBox1, this.textBox3, this.textBox4 }))
                box.Clear();

            this.numericUpDown1.Value = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            (new AltaContactoCliente(Int32.Parse(dataGridView1.SelectedRows[0].Cells["cod_us"].Value.ToString()))).Show();
        }
    }
}
