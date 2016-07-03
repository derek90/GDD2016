using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class GenerarPublicacion : Form
    {
        Form parent;
        string username;

        public GenerarPublicacion(Form parent, string username)
        {
            InitializeComponent();
            this.parent = parent;
            this.username = username;
            this.fill_components();
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

            this.dateTimePicker1.MinDate = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            this.dateTimePicker1.Value = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.numericUpDown3.Enabled = ((ComboBox)sender).SelectedIndex == 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int new_publication_code;
            using(var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("HARDCOR.generar_publicacion", connection);
                query.CommandType = System.Data.CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@descripcion", this.textBox1.Text));
                query.Parameters.Add(new SqlParameter("@stock", this.numericUpDown1.Value));
                query.Parameters.Add(new SqlParameter("@precio", this.numericUpDown3.Value));
                query.Parameters.Add(new SqlParameter("@rubro", ((KeyValuePair<int, string>) this.comboBox2.SelectedItem).Value));
                query.Parameters.Add(new SqlParameter("@usuario", this.username));
                query.Parameters.Add(new SqlParameter("@visi", ((KeyValuePair<int, string>) this.comboBox3.SelectedItem).Value));
                query.Parameters.Add(new SqlParameter("@estado", "activa"));
                query.Parameters.Add(new SqlParameter("@tipo", ((KeyValuePair<int, string>) this.comboBox1.SelectedItem).Value));
                query.Parameters.Add(new SqlParameter("@fecha_venc", this.dateTimePicker1.Value));
                query.Parameters.Add(new SqlParameter("@envio", this.checkBox1.Checked));
                query.Parameters.Add(new SqlParameter("@fecha", DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString())));

                connection.Open();
                new_publication_code = (int) query.ExecuteScalar();
            }

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
                    query.Parameters.Add(new SqlParameter("@nuevo_estado", "activo"));
                }
            }
            MessageBox.Show("Publicacion creada con exito", "Publicacion creada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
            this.parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
} 