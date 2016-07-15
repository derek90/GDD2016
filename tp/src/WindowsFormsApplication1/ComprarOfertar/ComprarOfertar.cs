using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class ComprarOfertar : Form
    {
        Form parent;
        Paginator paginator;
        string username;

        public ComprarOfertar(Form parent, string username)
        {
            InitializeComponent();
            this.parent = parent;
            this.username = username;

            this.fill_list();
            List<KeyValuePair<string, object>> param = new List<KeyValuePair<string, object>>();
            param.Add(new KeyValuePair<string, object>("@rubros", ""));
            param.Add(new KeyValuePair<string, object>("@descripcion", ""));
            param.Add(new KeyValuePair<string, object>("@username", this.username));
            this.paginator = new Paginator(this.numericUpDown1, this.dataGridView1, "HARDCOR.listar_publicaciones", this.button3,
                                            this.button4, this.label3, 10, param);

        }

        public void refresh()
        {
            this.paginator.load_page(0);
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

        private bool has_too_much_pending_reviews(string username)
        {
            using(var connection = DBConnection.getInstance().getConnection())
            {
                // TODO: Hacer SP - Decir si un usuario tiene mas de tres operaciones sin calificar
                SqlCommand query = new SqlCommand("HARDCOR.usuario_con_calif_pendientes", connection);
                query.CommandType = CommandType.StoredProcedure;
                connection.Open();
                query.Parameters.Add(new SqlParameter("@usuario", username));

                return Int32.Parse(query.ExecuteScalar().ToString()) == 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, object>> param = new List<KeyValuePair<string, object>>();
            List<int> pks = new List<int>();
            foreach (var item in this.checkedListBox1.CheckedItems)
                pks.Add(((KeyValuePair<int, string>)item).Key);
            param.Add(new KeyValuePair<string, object>("@rubros", String.Join(",", pks)));
            param.Add(new KeyValuePair<string, object>("@descripcion", this.textBox1.Text));
            param.Add(new KeyValuePair<string, object>("@username", this.username));
            this.paginator.set_query_params(param);
            this.paginator.load_page(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (this.checkedListBox1.CheckedIndices.Count > 0)
                this.checkedListBox1.SetItemChecked(this.checkedListBox1.CheckedIndices[0], false);
            this.textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una publicacion");
                return;
            }

            if (this.has_too_much_pending_reviews(username))
            {
                MessageBox.Show("Tiene mas de tres compras o subastas sin calificar. Califiquelas para poder hacer una nueva operacion",
                                "Limite de operaciones pnedientes de calificar excedido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                var cells = this.dataGridView1.SelectedRows[0].Cells;
                int publication_code = Int32.Parse(cells["cod_pub"].Value.ToString());
                decimal min, max;
                bool is_auction = Int32.Parse(cells["cod_tipo"].Value.ToString()) == 2;
                if (is_auction) // Es una subasta
                {
                    min = decimal.Parse(cells["precio"].Value.ToString());
                    max = Int32.MaxValue;
                }
                else
                {
                    min = 1;
                    max = Int32.Parse(cells["stock"].Value.ToString());
                }

                this.Hide();
                (new ConfirmarCompraOferta(this, this.username, publication_code, is_auction, min, max)).Show();
            }
        }
    }
}
