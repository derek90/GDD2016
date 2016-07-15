using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class GenerarPublicacion : Form
    {
        Form parent;
        string username;
        int code;
        bool is_modification;

        public GenerarPublicacion(Form parent, string username)
        {
            this.is_modification = false;
            InitializeComponent();
            this.parent = parent;
            this.username = username;
            this.dateTimePicker1.MinDate = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.dateTimePicker1.Value = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.fill_components();
        }

        public GenerarPublicacion(Form parent, string username, int code, string description, int stock, float price,
                                  int bussiness_code, int visibility_code, int state_code, int type_code, DateTime start_time, DateTime expiration_time,
                                  bool send_enabled)
        {
            this.is_modification = true;
            InitializeComponent();
            this.label10.Text = "Modificar borrador";
            this.button1.Text = "Modificar";
            this.parent = parent;
            this.username = username;
            this.code = code;
            this.dateTimePicker1.MinDate = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.fill_components(description, stock, price, bussiness_code, visibility_code, start_time,
                                 state_code, type_code, expiration_time, send_enabled);
        }

        private void fill_components(string description, int stock, float price, int bussiness_code, int visibility_code, DateTime start_time,
                                     int state_code, int type_code, DateTime expiration_time, bool send_enabled)
        {
            this.fill_components();
            this.textBox1.Text = description;
            this.numericUpDown2.Value = (decimal) price;
            this.numericUpDown1.Value = stock;
            this.checkBox1.Checked = send_enabled;
            foreach(var pair in this.comboBox1.Items)
                if(((KeyValuePair<int, string>) pair).Key == type_code)
                {
                    this.comboBox1.SelectedItem = pair;
                    break;
                }
            foreach(var pair in this.comboBox2.Items)
                if(((KeyValuePair<int, string>) pair).Key == bussiness_code)
                {
                    this.comboBox2.SelectedItem = pair;
                    break;
                }
            foreach(var pair in this.comboBox3.Items)
                if(((KeyValuePair<int, string>) pair).Key == visibility_code)
                {
                    this.comboBox3.SelectedItem = pair;
                    break;
                }
            this.dateTimePicker1.Value = expiration_time;
            this.dateTimePicker1.MinDate = start_time;
        }

        private void fill_components ()
        {
            var publication_types = new List<KeyValuePair<int, string>>();
            var bussines = new List<KeyValuePair<int, string>>();
            var visibilities = new List<KeyValuePair<int, string>>();

            publication_types.Add(new KeyValuePair<int, string>(1, "Compra Inmediata"));
            publication_types.Add(new KeyValuePair<int, string>(2, "Subasta"));

            using (var connection = DBConnection.getInstance().getConnection())
            {
                connection.Open();
                SqlCommand query = Utils.create_sp("HARDCOR.obtener_rubros", new List<KeyValuePair<string, object>>(), connection);
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                    bussines.Add(new KeyValuePair<int, string>(Int32.Parse(reader["cod_rubro"].ToString()),
                                                               reader["rubro_desc_corta"].ToString()));
            }

            using (var connection = DBConnection.getInstance().getConnection())
            {
                connection.Open();
                SqlCommand query = Utils.create_sp("HARDCOR.obtener_visibilidades", new List<KeyValuePair<string, object>>(), connection);
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                    visibilities.Add(new KeyValuePair<int, string> (Int32.Parse(reader["cod_visi"].ToString()),
                                                                    reader["visi_desc"].ToString()));
            }

            Utils.populate(this.comboBox1, publication_types);
            Utils.populate(this.comboBox2, bussines);
            Utils.populate(this.comboBox3, visibilities);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1.Enabled = ((ComboBox)sender).SelectedIndex == 1;
            this.dateTimePicker1.Value = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            if (dateTimePicker1.Enabled)
                this.label5.Text = "Precio inicial";
            else
                this.label5.Text = "Precio";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int new_publication_code = 0;
            using(var connection = DBConnection.getInstance().getConnection())
            {
                string query_name = "HARDCOR.generar_publicacion";
                if (this.is_modification)
                    query_name = "HARDCOR.modificar_borrador";

                SqlCommand query = new SqlCommand(query_name, connection);
                query.CommandType = System.Data.CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@descripcion", this.textBox1.Text));
                query.Parameters.Add(new SqlParameter("@stock", this.numericUpDown1.Value));
                query.Parameters.Add(new SqlParameter("@precio", this.numericUpDown2.Value));
                query.Parameters.Add(new SqlParameter("@rubro", ((KeyValuePair<int, string>) this.comboBox2.SelectedItem).Value));
                query.Parameters.Add(new SqlParameter("@visi", ((KeyValuePair<int, string>) this.comboBox3.SelectedItem).Value));
                query.Parameters.Add(new SqlParameter("@tipo", ((KeyValuePair<int, string>) this.comboBox1.SelectedItem).Value));
                query.Parameters.Add(new SqlParameter("@fecha_venc", this.dateTimePicker1.Value));
                query.Parameters.Add(new SqlParameter("@envio", this.checkBox1.Checked));

                if (this.is_modification)
                {
                    query.Parameters.Add(new SqlParameter("@cod_pub", this.code));
                    connection.Open();
                    query.ExecuteScalar();
                }
                else
                {
                    query.Parameters.Add(new SqlParameter("@estado", "Borrador"));
                    query.Parameters.Add(new SqlParameter("@usuario", this.username));
                    query.Parameters.Add(new SqlParameter("@fecha", DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString())));
                    connection.Open();
                    new_publication_code = (int)query.ExecuteScalar();
                }

            }

            if (!this.is_modification)
            {
                DialogResult result = MessageBox.Show("Su publicacion fue creada con exito en estado 'Borrador'. Desea activar su publicacion?",
                                                      "Activar publicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result.ToString() == "Yes")
                {
                    using (var connection = DBConnection.getInstance().getConnection())
                    {
                        SqlCommand query = new SqlCommand("HARDCOR.cambiar_estado_publ", connection);
                        query.CommandType = System.Data.CommandType.StoredProcedure;
                        query.Parameters.Add(new SqlParameter("@usuario", this.username));
                        query.Parameters.Add(new SqlParameter("@cod_pub", new_publication_code));
                        query.Parameters.Add(new SqlParameter("@nuevo_estado", "Activada"));
                        query.Parameters.Add(new SqlParameter("@fecha", DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString())));

                        connection.Open();
                        int bill_number = (int)query.ExecuteScalar();

                        SqlCommand fetch_bill = new SqlCommand("HARDCOR.obtener_factura", connection);
                        fetch_bill.CommandType = CommandType.StoredProcedure;
                        fetch_bill.Parameters.Add(new SqlParameter("@numero", bill_number));
                        SqlDataReader reader = fetch_bill.ExecuteReader();
                        reader.Read();
                        DateTime date = DateTime.Parse(reader["fecha"].ToString());
                        float total = float.Parse(reader["total"].ToString());
                        string payment_type = reader["forma_pago"].ToString();
                        int user_code = Int32.Parse(reader["cod_us"].ToString());
                        (new Facturas.Factura(this.parent, bill_number, new_publication_code, user_code, date, payment_type, total)).Show();
                    }
                }
                MessageBox.Show("Publicacion creada con exito", "Publicacion creada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Borrador modificado con exito", "Borrador modificado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((ModificarPublicacion) this.parent).refresh();
            }

            this.Close();
            this.parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.comboBox3.GetItemText(this.comboBox3.SelectedItem) == "Gratis")
            {
                this.checkBox1.Checked = false;
                this.checkBox1.Enabled = false;
            }
            else
            {
                this.checkBox1.Enabled = true;
            }
        }
    }
} 