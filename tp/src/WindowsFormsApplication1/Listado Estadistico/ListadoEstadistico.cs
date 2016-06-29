using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

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
        }

        private Dictionary<int, string> get_query_mappings()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            // TODO: estos son los sp que se detallan en el punto 11
            ret.Add(0, "HARDCOR.");
            ret.Add(1, "HARDCOR.");
            ret.Add(2, "HARDCOR.");
            ret.Add(3, "HARDCOR.");

            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand(this.get_query_mappings()[this.comboBox1.SelectedIndex], connection);
                query.CommandType = CommandType.StoredProcedure;

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
            */
            MessageBox.Show("SPs no implementados");
        }
    }
}
