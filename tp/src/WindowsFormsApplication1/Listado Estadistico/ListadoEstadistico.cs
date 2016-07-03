using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        Form parent;

        public ListadoEstadistico(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.numericUpDown1.Maximum = int.MaxValue;
            this.numericUpDown1.Value = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString()).Year;
            this.comboBox2.Enabled = false;
            this.comboBox2.DataSource = getRubrosFromDB();

        }

        private List<string> getRubrosFromDB()
        {
            using (var connection = DBConnection.getInstance().getConnection())
            {
                connection.Open();
                SqlCommand query = Utils.create_sp("HARDCOR.obtener_rubros", connection);
                SqlDataReader reader = query.ExecuteReader();
                List<string> rubros = new List<string>();
                while (reader.Read())
                    rubros.Add(reader["rubro_desc_corta"].ToString());
                return rubros;
            }
        }

        private void toggleRubrosComboBox(object sender, EventArgs e)
        {
            comboBox2.Enabled = (comboBox1.SelectedIndex == 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("HARDCOR.listados", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@anio", numericUpDown1.Value));
                query.Parameters.Add(new SqlParameter("@nro_trim", numericUpDown2.Value));
                query.Parameters.Add(new SqlParameter("@tipoListado", comboBox1.SelectedIndex));
                query.Parameters.Add(new SqlParameter("@cod_visi", DBNull.Value));
                query.Parameters.Add(new SqlParameter("@mes", DBNull.Value));
                query.Parameters.Add(new SqlParameter("@desc", comboBox2.Text));

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query);
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.dataGridView1.DataSource = table;
                this.dataGridView1.ReadOnly = true;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView1.MultiSelect = false;
                this.dataGridView1.AllowUserToAddRows = false;
            }
        }
    }
}
