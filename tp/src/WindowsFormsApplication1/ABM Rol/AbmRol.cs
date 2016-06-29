using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Rol
{

    public partial class AbmRol : Form
    {
        Form parent;

        public AbmRol(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.fill_data_set();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        public void fill_data_set()
        {
            var connection = DBConnection.getInstance().getConnection();

            //Creo el adapter usando el select_query
            // TODO: Hacer este string un SP
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM HARDCOR.Rol", connection);

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
            if(this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un rol");
                return;
            }
            (new ModificacionRol(this.dataGridView1.SelectedRows[0], this)).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new ModificacionRol(this)).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
