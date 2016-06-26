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

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class ComprarOfertar : Form
    {
        Form parent;
        Paginator paginator;

        public ComprarOfertar(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.fill_list();
            /* TODO: Hacer SP */
            this.paginator = new Paginator(this.numericUpDown1, this.dataGridView1, "HARDCOR.", this.button3,
                                                this.button4, "HARDCOR.", this.label3, 10);
            // this.paginator.set_max_page_number();
        }

        private void fill_list()
        {
            List<KeyValuePair<int, string>> items = new List<KeyValuePair<int, string>>();
            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand command = new SqlCommand("HARDCOR.obtener_rubros", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    items.Add(new KeyValuePair<int, string>(Int32.Parse(reader["cod_rubro"].ToString()),
                                                            reader["rubro_desc_corta"].ToString()));
            }

            Utils.populate(this.checkedListBox1, items);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            using (var connection = DBConnection.getInstance().getConnection())
            {
                // TODO: Hacer sp
                SqlCommand query = new SqlCommand("HARDCOR.", connection);

                //Seteo que sea un stored procedure
                query.CommandType = CommandType.StoredProcedure;

                //Agrego los parámetros
                List<int> pks = new List<int>();
                foreach (var item in this.checkedListBox1.SelectedItems)
                    pks.Add(((KeyValuePair<int, string>)item).Key);
                // TODO: averiguar como se le pasa una lista a un sp
                query.Parameters.Add(new SqlParameter("@rubros", pks));
                query.Parameters.Add(new SqlParameter("@descripcion", this.textBox1.Text));

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
            */

            MessageBox.Show("SP de filtrado todavia no implementado");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.checkedListBox1.ClearSelected();
            this.textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una publicacion");
                return;
            }

            var cells = this.dataGridView1.SelectedRows[0].Cells;
            int publication_code = Int32.Parse(cells["cod_pub"].ToString());
            int min, max;
            if(cells["tipo"].ToString() == "subasta")
            {
                /* TODO: preguntar bien cual es la columna que tiene esta informacion */
                min = Int32.Parse(cells["precio"].ToString());
                max = Int32.MaxValue;
            }
            else
            {
                min = 1;
                max = Int32.Parse(cells["stock"].ToString());
            }

            this.Hide();
            (new ConfirmarCompraOferta(this, publication_code, min, max)).Show();
        }
    }
}
