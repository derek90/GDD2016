using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class ModificarPublicacion : Form
    {
        Form parent;
        string username;
        Paginator paginator;
        List<string> states;

        public ModificarPublicacion(Form parent, string username)
        {
            this.parent = parent;
            this.username = username;
            InitializeComponent();
            List<KeyValuePair<string, object>> param = new List<KeyValuePair<string, object>>();
            param.Add(new KeyValuePair<string, object>("@username", this.username));
            this.paginator = new Paginator(this.numericUpDown1, this.dataGridView1, "HARDCOR.publicaciones_vigentes_por_usuario", this.button5,
                                           this.button4, this.label1, 10, param);
            this.states = get_states();
            this.refresh();
        }

        public void refresh()
        {
            this.paginator.load_page(0);
        }

        private List<string> get_states()
        {
            List<string> states = new List<string>();
            states.Add("Activada");
            states.Add("Pausada");
            states.Add("Borrador");
            states.Add("Finalizada");
            // Este estado no se para que esta. Toda publicacion que no es 'Borrador' esta publicada
            //states.Add("Publicada");

            return states;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            if((int) this.dataGridView1.SelectedRows[0].Cells["estado"].Value != 3)
            {
                MessageBox.Show("No pude modificar una publicacion que no sea borrador");
                return;
            }
            int code = Int32.Parse(this.dataGridView1.SelectedRows[0].Cells["cod_pub"].Value.ToString());
            string description = this.dataGridView1.SelectedRows[0].Cells["descripcion"].Value.ToString();
            int stock = Int32.Parse(this.dataGridView1.SelectedRows[0].Cells["stock"].Value.ToString());
            int bussiness_code = Int32.Parse(this.dataGridView1.SelectedRows[0].Cells["cod_rubro"].Value.ToString());
            int visibility_code = Int32.Parse(this.dataGridView1.SelectedRows[0].Cells["cod_visi"].Value.ToString());
            int state_code = Int32.Parse(this.dataGridView1.SelectedRows[0].Cells["estado"].Value.ToString());
            int type_code = Int32.Parse(this.dataGridView1.SelectedRows[0].Cells["cod_tipo"].Value.ToString());
            DateTime expiration_time = DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString());
            if(state_code == 2)
                expiration_time = DateTime.Parse(this.dataGridView1.SelectedRows[0].Cells["fecha_fin"].Value.ToString());
            DateTime start_time = DateTime.Parse(this.dataGridView1.SelectedRows[0].Cells["fecha_ini"].Value.ToString());
            bool send_enabled = (bool)this.dataGridView1.SelectedRows[0].Cells["envio"].Value;
            float price = float.Parse(this.dataGridView1.SelectedRows[0].Cells["precio"].Value.ToString());

            (new GenerarPublicacion(this, this.username, code, description, stock, price, bussiness_code, visibility_code,
                                    state_code, type_code, start_time, expiration_time, send_enabled)).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            using(var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("HARDCOR.cambiar_estado_publ", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@usuario", this.username));
                query.Parameters.Add(new SqlParameter("@cod_pub", this.dataGridView1.SelectedRows[0].Cells["cod_pub"].Value));
                query.Parameters.Add(new SqlParameter("@nuevo_estado", this.comboBox1.SelectedItem));
                query.Parameters.Add(new SqlParameter("@fecha", DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString())));

                connection.Open();
                query.ExecuteNonQuery();
            }
            MessageBox.Show("Se cambio el estado de la publicacion a " + this.comboBox1.SelectedItem.ToString());
            this.paginator.load_page(0);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count > 0)
            {
                this.comboBox1.Items.Clear();
                this.comboBox1.Enabled = true;

                if ((int)this.dataGridView1.SelectedRows[0].Cells["estado"].Value == 1)
                    this.comboBox1.Items.AddRange(this.states.Where(s => (s != "Activada") && (s != "Borrador")).ToArray());
                else
                {
                    if ((int)this.dataGridView1.SelectedRows[0].Cells["estado"].Value == 2)
                        this.comboBox1.Items.AddRange(this.states.Where(s => (s != "Pausada") && (s != "Borrador")).ToArray());
                    else
                        this.comboBox1.Items.AddRange(this.states.Where(s => (s != "Borrador")).ToArray());
                }
                this.comboBox1.SelectedIndex = 0;
            }
            else
            {
                this.comboBox1.Enabled = false;
            }
        }
    }
}
