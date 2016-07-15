using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Rol
{

    public partial class AbmRol : Form
    {
        Form parent;
        string username;

        public AbmRol(Form parent, string username)
        {
            this.parent = parent;
            this.username = username;
            InitializeComponent();
            this.fill_data_set();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        public void fill_data_set()
        {
            using(var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("HARDCOR.obtener_roles_para_modificar", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@username", this.username));

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
            }
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
