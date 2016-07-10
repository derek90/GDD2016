using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Facturas
{
    public partial class ListadoFacturas : Form
    {
        Form parent;
        Paginator paginator;

        public ListadoFacturas(Form parent)
        {
            this.parent = parent;
            InitializeComponent();

            this.radioButton1.Checked = true;
            this.textBox3.Enabled = false;
            this.comboBox1.DataSource = getTiposDocFromDB();

            // Seteo los minimos y maximos de algunos de los filtros

            this.dateTimePicker1.MaxDate = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.dateTimePicker1.Value = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.dateTimePicker2.MaxDate = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.dateTimePicker2.MinDate = dateTimePicker1.Value;
            this.dateTimePicker2.Value = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.numericUpDown2.Maximum = int.MaxValue;

            // Creo un paginador
            this.paginator = new Paginator(this.numericUpDown3, this.dataGridView1, "HARDCOR.consulta_factura",
                                           this.button5, this.button4, this.label7, 10);
        }

        private List<string> getTiposDocFromDB()
        {
            List<string> tiposDoc = new List<string>();
            using (var connection = DBConnection.getInstance().getConnection())
            {
                connection.Open();
                SqlCommand query = Utils.create_sp("HARDCOR.obtener_tipos_doc", connection);
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    tiposDoc.Add((reader["documento"].ToString()));
                }
                return tiposDoc;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = this.dateTimePicker1.MinDate;
            this.dateTimePicker2.Value = this.dateTimePicker2.MinDate;
            this.numericUpDown1.Value = this.numericUpDown1.Minimum;
            this.numericUpDown2.Value = this.numericUpDown2.Minimum;
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, object>> query_params = new List<KeyValuePair<string, object>>();
            query_params.Add(new KeyValuePair<string, object>("@razon_social", getRazonSocial()));
            query_params.Add(new KeyValuePair<string, object>("@tipo", getTipo()));
            query_params.Add(new KeyValuePair<string, object>("@fechai", this.dateTimePicker1.Value));
            query_params.Add(new KeyValuePair<string, object>("@fechaf", this.dateTimePicker2.Value));
            query_params.Add(new KeyValuePair<string, object>("@importei", this.numericUpDown1.Value));
            query_params.Add(new KeyValuePair<string, object>("@importef", this.numericUpDown2.Value));
            query_params.Add(new KeyValuePair<string, object>("@descripcion", this.textBox1.Text));
            query_params.Add(new KeyValuePair<string, object>("@tipo_doc", this.comboBox1.Text));

            this.paginator.set_query_params(query_params);
            this.paginator.load_page(0);
        }

        private string getRazonSocial()
        {
            string razonSocial = (radioButton1.Checked) ? textBox2.Text.Trim() : textBox3.Text.Trim();
            return razonSocial;
        }

        private int getTipo()
        {
            int tipo = (radioButton1.Checked) ? 0 : 1;
            return tipo;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.acceptOnlyNumbers(sender, e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox3.Text = "";
            this.textBox2.Enabled = true;
            this.textBox3.Enabled = false;
            this.comboBox1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = true;
            this.comboBox1.Enabled = false;
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            DateTimePicker picker = (DateTimePicker)sender;
            DateTime fecha = picker.Value;
            dateTimePicker2.MinDate = fecha;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Minimum = numericUpDown1.Value + 1;
        }
    }
}
