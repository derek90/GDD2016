using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Paginator
    {
        NumericUpDown current_page;
        DataGridView data_grid;
        string query;
        Label page_count_label;
        int page_size;
        List<KeyValuePair<string, object>> query_params;
        Button prev;
        Button next;

        public Paginator (NumericUpDown current_page, DataGridView data_grid, string query, Button prev, Button next,
                          Label page_count_label, int page_size)
        {
            this.current_page = current_page;
            this.query = query;
            this.data_grid = data_grid;
            this.page_count_label = page_count_label;
            this.page_size = page_size;
            this.prev = prev;
            this.next = next;
            this.query_params = new List<KeyValuePair<string, object>>();
            // Seteo que los botones pidan la siguiente y la anterior pagina
            prev.Click += (s, e) => this.current_page.Value -= 1;
            next.Click += (s, e) => this.current_page.Value += 1;
            // Para que al cambiar de valor current_page se haga el pedido a la base
            current_page.ValueChanged += (s, e) => this.load_page(this.current_page.Value);
        }

        public Paginator (NumericUpDown current_page, DataGridView data_grid, string query, Button prev, Button next,
                          Label page_count_label, int page_size, List<KeyValuePair<string, object>> query_params)
        {
            this.current_page = current_page;
            this.query = query;
            this.data_grid = data_grid;
            this.page_count_label = page_count_label;
            this.page_size = page_size;
            this.prev = prev;
            this.next = next;
            this.query_params = query_params;
            // Seteo que los botones pidan la siguiente y la anterior pagina
            prev.Click += (s, e) => this.current_page.Value -= 1;
            next.Click += (s, e) => this.current_page.Value += 1;
            // Para que antes de cargar alguna pagina no me deje tocar lso botones
            prev.Enabled = false;
            next.Enabled = false;
            // Para que al cambiar de valor current_page se haga el pedido a la base
            current_page.ValueChanged += (s, e) => this.load_page(this.current_page.Value);
        }

        public void load_page(decimal page)
        {
            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand(this.query, connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@pagina", page));
                query.Parameters.Add(new SqlParameter("@cantidad_resultados_por_pagina", this.page_size));
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

                // Para que oculte la columna del COUNT
                this.data_grid.Columns[0].Visible = false;

                int total_pages = 0;
                if(this.data_grid.Rows.Count > 0)
                    total_pages = (int)this.data_grid.Rows[0].Cells[0].Value;
                this.page_count_label.Text = "/ " + (total_pages / this.page_size).ToString();
                this.current_page.Maximum = total_pages;
            }
            this.prev.Enabled = !(this.current_page.Value == this.current_page.Minimum);
            this.next.Enabled = !(this.current_page.Value == this.current_page.Maximum);
        }

        public void set_query(string query)
        {
            this.query = query;
        }

        public void set_query_params(List<KeyValuePair<string, object>> query_params)
        {
            this.query_params = query_params;
        }
    }
}
