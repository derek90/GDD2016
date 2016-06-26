using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Paginator
    {
        NumericUpDown current_page;
        DataGridView data_grid;
        string query;
        string page_count_query;
        Label page_count_label;
        int page_size;
        List<KeyValuePair<string, object>> query_params;

        public Paginator (NumericUpDown current_page, DataGridView data_grid, string query, Button prev, Button next,
                          string page_count_query, Label page_count_label, int page_size)
        {
            this.current_page = current_page;
            this.query = query;
            this.data_grid = data_grid;
            this.page_count_query = page_count_query;
            this.page_count_label = page_count_label;
            this.page_size = page_size;
            this.query_params = new List<KeyValuePair<string, object>>();
            // Seteo que los botones pidan la siguiente y la anterior pagina
            prev.Click += (s, e) => this.current_page.Value -= 1;
            next.Click += (s, e) => this.current_page.Value += 1;
            // Para que al cambiar de valor current_page se haga el pedido a la base
            current_page.ValueChanged += (s, e) =>
            {
                //this.load_page(this.current_page.Value);
                prev.Enabled = !(this.current_page.Value == this.current_page.Minimum);
                next.Enabled = !(this.current_page.Value == this.current_page.Maximum);
            };
        }

        public Paginator (NumericUpDown current_page, DataGridView data_grid, string query, Button prev, Button next,
                          string page_count_query, Label page_count_label, int page_size, List<KeyValuePair<string, object>> query_params)
        {
            this.current_page = current_page;
            this.query = query;
            this.data_grid = data_grid;
            this.page_count_query = page_count_query;
            this.page_count_label = page_count_label;
            this.page_size = page_size;
            this.query_params = query_params;
            // Seteo que los botones pidan la siguiente y la anterior pagina
            prev.Click += (s, e) => this.current_page.Value -= 1;
            next.Click += (s, e) => this.current_page.Value += 1;
            // Para que al cambiar de valor current_page se haga el pedido a la base
            current_page.ValueChanged += (s, e) =>
            {
                //this.load_page(this.current_page.Value);
                prev.Enabled = !(this.current_page.Value == this.current_page.Minimum);
                next.Enabled = !(this.current_page.Value == this.current_page.Maximum);
            };
        }

        public void load_page(decimal page)
        {
            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand(this.query, connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@pagina", page));
                this.query_params.ForEach((pair) => query.Parameters.Add(new SqlParameter(pair.Key, pair.Value)));

                //Creo el adapter usando el select_query
                SqlDataAdapter adapter = new SqlDataAdapter(query);

                //Lleno el dataset y lo seteo como source del dataGridView
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.data_grid.DataSource = table;
                this.data_grid.ReadOnly = true;
                this.data_grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.data_grid.MultiSelect = false;
                this.data_grid.AllowUserToAddRows = false;
            }
        }

        public void set_max_page_number()
        {
            int total_pages;

            using (var connection = DBConnection.getInstance().getConnection())
            {
                // Pido la cantidad de paginas totales
                SqlCommand query = new SqlCommand(this.page_count_query, connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@tamanio_pagina", page_size));
                total_pages = Int32.Parse(query.ExecuteScalar().ToString());
            }

            this.page_count_label.Text = "/ " + total_pages.ToString();
            this.current_page.Maximum = total_pages;
        }
    }
}
