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

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class ModificacionEmpresa : Form
    {
        String select_query =  "HARDCOR.listar_empresas";
        SqlDataAdapter adapter;

        public ModificacionEmpresa()
        {
            InitializeComponent();
        }

        public void fill_data_set(string corporate_name, string cuit, string mail)
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand(this.select_query, connection);

            //Seteo que sea un stored procedure
            query.CommandType = CommandType.StoredProcedure;

            //Agrego los parámetros
            query.Parameters.Add(new SqlParameter("@razon_social", corporate_name));
            query.Parameters.Add(new SqlParameter("@cuit", cuit));
            query.Parameters.Add(new SqlParameter("@mail", mail));

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.fill_data_set(this.textBox3.Text, this.textBox2.Text, this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox box in (new List<TextBox> { this.textBox1, this.textBox2, this.textBox3 }))
                box.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una empresa");
                return;
            }
            (new AltaContactoEmpresa(Int32.Parse(dataGridView1.SelectedRows[0].Cells["cod_us"].Value.ToString()))).Show();
        }
    }
}
