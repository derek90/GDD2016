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

namespace WindowsFormsApplication1.ABM_Rol
{
    public partial class ModificacionRol : Form
    {
        int role_code;
        AbmRol parent;

        public ModificacionRol(DataGridViewRow row, AbmRol parent)
        {
            this.role_code = Int32.Parse(row.Cells["cod_rol"].Value.ToString());
            this.parent = parent;
            InitializeComponent();
            this.textBox1.Text = row.Cells["nombre"].Value.ToString();
            this.checkBox1.Checked = (bool) row.Cells["habilitado"].Value;
            this.button1.Click += this.update;
        }

        public ModificacionRol(AbmRol parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.label1.Text = "Cree un nuevo rol";
            this.button1.Text = "Crear";
            this.button1.Click += this.insert;
        }

        private void update(object sender, EventArgs e)
        {
            var connection = (new DBConnection()).openConnection();
            SqlCommand update_command = new SqlCommand("HARDCOR.updateRole", connection);
            update_command.CommandType = CommandType.StoredProcedure;
            update_command.Parameters.Add(new SqlParameter("@cod_rol", this.role_code));
            update_command.Parameters.Add(new SqlParameter("@nombre", this.textBox1.Text));
            update_command.Parameters.Add(new SqlParameter("@habilitado", this.checkBox1.Checked));

            connection.Open();
            if(update_command.ExecuteNonQuery() == 1)
            {
                this.Hide();
                MessageBox.Show("Se modificaron los campos correctamente");
                this.parent.fill_data_set();  // Para que refresque el data set
            }
            else
                MessageBox.Show("Hubo un error al modificar los datos. Intente nuevamente");
            connection.Close();
        }

        private void insert(object sender, EventArgs e)
        {
            var connection = (new DBConnection()).openConnection();
            SqlCommand insert_command = new SqlCommand("HARDCOR.newRole", connection);
            insert_command.CommandType = CommandType.StoredProcedure;
            insert_command.Parameters.Add(new SqlParameter("@nombre", this.textBox1.Text));
            insert_command.Parameters.Add(new SqlParameter("@habilitado", this.checkBox1.Checked));

            connection.Open();
            if(insert_command.ExecuteNonQuery() == 1)
            {
                this.Hide();
                MessageBox.Show("Se agregó correctamente el rol " + this.textBox1.Text);
                this.parent.fill_data_set();  // Para que refresque el data set
            }
            else
                MessageBox.Show("Hubo un error al agregar el nuevo rol. Intente nuevamente");
            connection.Close();
        }
    }
}
