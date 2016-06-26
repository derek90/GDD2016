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

namespace WindowsFormsApplication1.ABM_Visibilidad
{
    public partial class AbmVisibilidad : Form
    {
        Form parent;

        public AbmVisibilidad(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.fill_data_set();
        }

        private void fill_data_set ()
        {
            var connection = DBConnection.getInstance().getConnection();
            /* TODO: Hacer SP */
            SqlCommand query = new SqlCommand("SELECT * FROM HARDCOR.Visibilidad", connection);

            //Seteo que sea un stored procedure
            // query.CommandType = CommandType.StoredProcedure;

            //Creo el adapter usando el select_query
            SqlDataAdapter adapter = new SqlDataAdapter(query);

            //Lleno el dataset y lo seteo como source del dataGridView
            DataTable table = new DataTable();
            adapter.Fill(table);
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
            this.Close();
            this.parent.Show();
        }
    }
}
