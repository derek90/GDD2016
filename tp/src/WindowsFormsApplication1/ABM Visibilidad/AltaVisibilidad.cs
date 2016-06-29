using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Visibilidad
{
    public partial class AltaVisibilidad : Form
    {
        int visibility_code;
        AbmVisibilidad parent;

        public AltaVisibilidad(AbmVisibilidad parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.button1.Click += this.insert;
        }

        public AltaVisibilidad(DataGridViewRow row, AbmVisibilidad parent)
        {
            this.parent = parent;
            InitializeComponent();

            this.button1.Text = "Modificar";
            this.button1.Click += this.update;
            this.Text = "Modificar visibilidad";

            this.visibility_code = Int32.Parse(row.Cells["cod_visi"].Value.ToString());
            this.textBox1.Text = row.Cells["visi_desc"].Value.ToString();
            this.numericUpDown1.Value = decimal.Parse(row.Cells["comision_por_tipo"].Value.ToString());
            this.numericUpDown2.Value = decimal.Parse(row.Cells["comision_prducto_vendido"].Value.ToString());
            this.numericUpDown3.Value = decimal.Parse(row.Cells["comision_envio"].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void update(object sender, EventArgs e)
        {
            /* TODO: Hacer el SP
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand update_command = new SqlCommand("HARDCOR.", connection);
            update_command.CommandType = CommandType.StoredProcedure;
            update_command.Parameters.Add(new SqlParameter("@cod_visi", this.visibility_code));

            connection.Open();
            if(update_command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Se modificaron los campos correctamente");
                this.parent.fill_data_set();  // Para que refresque el data set
            }
            else
                MessageBox.Show("Hubo un error al modificar los datos. Intente nuevamente");
            connection.Close();
            */
            MessageBox.Show("Completar el update");
        }

        private void insert(object sender, EventArgs e)
        {

            if(this.textBox1.Text == "")
            {
                MessageBox.Show("La descripcion no puede ser vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand insert_command = new SqlCommand("HARDCOR.", connection);
                insert_command.CommandType = CommandType.StoredProcedure;
                insert_command.Parameters.Add(new SqlParameter("@nombre", this.textBox1.Text));

                connection.Open();

                /* TODO: Hacer el insert */
                MessageBox.Show("Hay que hacer el insert!");
            }
        }
    }
}
