using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class GenerarPublicacion : Form
    {
        Form parent;

        public GenerarPublicacion(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.fill_components();
        }

        private void fill_components ()
        {
            var publication_types = new List<KeyValuePair<int, string>>();
            var bussines = new List<KeyValuePair<int, string>>();
            var visibilities = new List<KeyValuePair<int, string>>();

            publication_types.Add(new KeyValuePair<int, string>(1, "Compra inmediata"));
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
            /* TODO: sp para cargar la nueva pubicacion */
            DialogResult result = MessageBox.Show("Su publicacion fue creada con exito en estado 'Borrador'. Desea activar su publicacion?",
                                                  "Activar publicacion",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.ToString() == "Yes")
                ;/* TODO: Activar publicacion */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }
    }
} 