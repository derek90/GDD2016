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
            this.numericUpDown1.Value = decimal.Parse(row.Cells["comision_pub"].Value.ToString());
            this.numericUpDown2.Value = decimal.Parse(row.Cells["comision_vta"].Value.ToString());
            this.numericUpDown3.Value = decimal.Parse(row.Cells["comision_envio"].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void update(object sender, EventArgs e)
        {
            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand update_command = new SqlCommand("HARDCOR.mod_vis", connection);
                update_command.CommandType = CommandType.StoredProcedure;
                update_command.Parameters.Add(new SqlParameter("@cod_visi", this.visibility_code));
                update_command.Parameters.Add(new SqlParameter("@descripcion", this.textBox1.Text));
                update_command.Parameters.Add(new SqlParameter("@comision_pub", this.numericUpDown1.Value));
                update_command.Parameters.Add(new SqlParameter("@comision_vta", this.numericUpDown2.Value));
                update_command.Parameters.Add(new SqlParameter("@comision_envio", this.numericUpDown3.Value));
                connection.Open();
                update_command.ExecuteNonQuery();
            }
            MessageBox.Show("La visibilidad se modifico correctamente", "Modificacion exitosa",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.parent.fill_data_set();  // Para refrescar la vista anterior
        }

        private void insert(object sender, EventArgs e)
        {

            if(this.textBox1.Text == "")
            {
                MessageBox.Show("La descripcion no puede ser vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int succesful;
            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand insert_command = new SqlCommand("HARDCOR.alta_vis", connection);
                insert_command.CommandType = CommandType.StoredProcedure;
                insert_command.Parameters.Add(new SqlParameter("@descripcion", this.textBox1.Text));
                insert_command.Parameters.Add(new SqlParameter("@comision_pub", this.numericUpDown1.Value));
                insert_command.Parameters.Add(new SqlParameter("@comision_vta", this.numericUpDown2.Value));
                insert_command.Parameters.Add(new SqlParameter("@comision_envio", this.numericUpDown3.Value));

                connection.Open();

                succesful = insert_command.ExecuteNonQuery();
            }
            if (succesful == 1)
            {
                MessageBox.Show("La visibilidad se creo correctamente", "Alta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.parent.fill_data_set();  // Para refrescar la vista anterior
            }
            else
                MessageBox.Show("La descripcion de esa visibilidad ya existe, elija otra", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
