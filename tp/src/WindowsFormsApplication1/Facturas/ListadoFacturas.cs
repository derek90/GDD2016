using System;
using System.Collections.Generic;
using System.Configuration;
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

            // Seteo los minimos y maximos de algunos de los filtros
            this.dateTimePicker1.MinDate = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.dateTimePicker1.Value = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.dateTimePicker2.MinDate = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.dateTimePicker2.Value = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.numericUpDown2.Maximum = int.MaxValue;

            // Creo un paginador
            List<KeyValuePair<string, object>> query_params = new List<KeyValuePair<string, object>>();
            query_params.Add(new KeyValuePair<string, object>("@razon_social", this.textBox2.Text));
            query_params.Add(new KeyValuePair<string, object>("@fecha_desde", this.dateTimePicker1.Value));
            query_params.Add(new KeyValuePair<string, object>("@fecha_hasta", this.dateTimePicker2.Value));
            query_params.Add(new KeyValuePair<string, object>("@importe_desde", this.numericUpDown1.Value));
            query_params.Add(new KeyValuePair<string, object>("@importe_hasta", this.numericUpDown2.Value));
            query_params.Add(new KeyValuePair<string, object>("@descripcion", this.textBox1.Text));

            this.paginator = new Paginator(this.numericUpDown3, this.dataGridView1, "HARDCOR.",
                                           this.button5, this.button4, "HARDCOR.", this.label7, 10, query_params);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.textBox2.Text == "")
            {
                MessageBox.Show("El campo 'Razon social' no puede estar vacio para hacer una busqueda");
                return;
            }

            /*
            using(var connection = DBConnection.getInstance().getConnection())
            {
                // TODO: sp - Buscar facturas por vendedor, con filtro entre fechas, entre importes y contiene descripcion
                SqlCommand query = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@razon_social", this.textBox2.Text));
                query.Parameters.Add(new SqlParameter("@fecha_desde", this.dateTimePicker1.Value));
                query.Parameters.Add(new SqlParameter("@fecha_hasta", this.dateTimePicker2.Value));
                query.Parameters.Add(new SqlParameter("@importe_desde", this.numericUpDown1.Value));
                query.Parameters.Add(new SqlParameter("@importe_hasta", this.numericUpDown2.Value));
                query.Parameters.Add(new SqlParameter("@descripcion", this.textBox1.Text));

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
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = true;
        }
    }
}
