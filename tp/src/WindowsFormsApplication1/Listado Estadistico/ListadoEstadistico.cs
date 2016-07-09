using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace WindowsFormsApplication1.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        Form parent;
        Dictionary<int, string> visibilidades;
        Dictionary<int, string> rubros;

        public ListadoEstadistico(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.numericUpDown1.Maximum = int.MaxValue;
            this.numericUpDown1.Value = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString()).Year;
            this.comboBox2.Enabled = false;
            this.rubros = getRubrosFromDB();
            this.comboBox2.DataSource = this.rubros.Values.ToList();
            this.visibilidades = getVisibilidadesFromDB();
            this.comboBox3.DataSource = this.visibilidades.Values.ToList();

        }

        private Dictionary<int, string> getRubrosFromDB()
        {
            using (var connection = DBConnection.getInstance().getConnection())
            {
                connection.Open();
                SqlCommand query = Utils.create_sp("HARDCOR.obtener_rubros", connection);
                SqlDataReader reader = query.ExecuteReader();
                Dictionary<int, string> rubros = new Dictionary<int, string>();
                while (reader.Read())
                {
                    if (reader["cod_rubro"] != null && reader["rubro_desc_corta"] != null)
                    {
                        rubros.Add(Convert.ToInt32(reader["cod_rubro"]), reader["rubro_desc_corta"].ToString());
                    }
                }
                return rubros;
            }
        }

        private Dictionary<int, string> getVisibilidadesFromDB()
        {
            using (var connection = DBConnection.getInstance().getConnection())
            {
                connection.Open();
                SqlCommand query = Utils.create_sp("HARDCOR.obtener_visibilidades", connection);
                SqlDataReader reader = query.ExecuteReader();
                Dictionary<int, string> visibilidades = new Dictionary<int, string>();
                while (reader.Read())
                {
                    if (reader["cod_visi"] != null && reader["visi_desc"] != null)
                    {
                        visibilidades.Add(Convert.ToInt32(reader["cod_visi"]), reader["visi_desc"].ToString());
                    }
                }
                return visibilidades;
            }
        }

        private void toggleComboBoxes(object sender, EventArgs e)
        {
            comboBox2.Enabled = (comboBox1.SelectedIndex == 1);
            if (!comboBox2.Enabled)
            {
                comboBox2.Hide();
                label4.Hide();
            }
            else
            {
                comboBox2.Show();
                label4.Show();
            }
            comboBox3.Enabled = (comboBox1.SelectedIndex == 0);
            if (!comboBox3.Enabled)
            {
                comboBox3.Hide();
                label5.Hide();
            }
            else
            {
                comboBox3.Show();
                label5.Show();
            }
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
                var visibilidadeleccionada = visibilidades.FirstOrDefault(x => x.Value == comboBox3.Text).Key;
                var rubroSeleccionado = rubros.FirstOrDefault(x => x.Value == comboBox2.Text).Key;
                SqlCommand query = new SqlCommand("HARDCOR.listados", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@anio", numericUpDown1.Value));
                query.Parameters.Add(new SqlParameter("@nro_trim", numericUpDown2.Value));
                query.Parameters.Add(new SqlParameter("@tipoListado", comboBox1.SelectedIndex));
                query.Parameters.Add(new SqlParameter("@cod_visi", visibilidadeleccionada));
                query.Parameters.Add(new SqlParameter("@mes", DBNull.Value));
                query.Parameters.Add(new SqlParameter("@cod_rubro", rubroSeleccionado));

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
