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

namespace WindowsFormsApplication1.Historial_Cliente
{
    public partial class HistorialCliente : Form
    {
        Form parent;
        Paginator paginator;

        public HistorialCliente(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            /* TODO: Hacer sp */
            this.paginator = new Paginator(this.numericUpDown1, this.dataGridView1, "HARDCOR.", this.button1,
                                           this.button2, "HARDCOR.", this.label1, 10);
            //this.paginator.set_max_page_number();
            /* TODO: pasarle el codigo de usuario */
            this.fill_data_sets(1);
            this.fill_labels(1);
        }

        private void fill_data_sets(int user_code)
        {
            /*
            using(var connection = DBConnection.getInstance().getConnection())
            {
                // TODO: Hacer SP - Compras y subastas por cliente
                SqlCommand query = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@usuario", user_code));

                //Creo el adapter usando el select_query
                SqlDataAdapter adapter = new SqlDataAdapter(query);

                //Lleno el dataset y lo seteo como source del dataGridView
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.dataGridView1.DataSource = table;
                this.dataGridView1.ReadOnly = true;


                // TODO: Hacer SP - Ultimas 5 publicaciones calificadas
                SqlCommand query2 = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@usuario", user_code));

                //Creo el adapter usando el select_query
                SqlDataAdapter adapter2 = new SqlDataAdapter(query);

                //Lleno el dataset y lo seteo como source del dataGridView
                DataTable table2 = new DataTable();
                adapter.Fill(table2);
                this.dataGridView1.DataSource = table2;
                this.dataGridView1.ReadOnly = true;


                // TODO: Hacer SP - Ultimas operaciones pendientes de calificar
                SqlCommand query3 = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@usuario", user_code));

                //Creo el adapter usando el select_query
                SqlDataAdapter adapter3 = new SqlDataAdapter(query);

                //Lleno el dataset y lo seteo como source del dataGridView
                DataTable table3 = new DataTable();
                adapter.Fill(table3);
                this.dataGridView1.DataSource = table3;
                this.dataGridView1.ReadOnly = true;
            }
            */
        }

        private void fill_labels(int user_code)
        {
            /*
            string stars_given_average, publication_reviewed;

            using(var connection = DBConnection.getInstance().getConnection())
            {
                // TODO: Hacer SP - Promedio de estrellas dadas
                SqlCommand query = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@usuario", user_code));

                stars_given_average = query.ExecuteScalar().ToString();

                // TODO: Hacer SP - Cantidad de publicaciones puntuadas
                query = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@usuario", user_code));

                publication_reviewed = query.ExecuteScalar().ToString();
            }

            this.label3.Text = stars_given_average;
            this.label5.Text = publication_reviewed;
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
