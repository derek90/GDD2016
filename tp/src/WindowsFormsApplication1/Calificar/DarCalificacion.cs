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

namespace WindowsFormsApplication1.Calificar
{
    public partial class DarCalificacion : Form
    {

        Calificar parent;
        int buy_code;

        public DarCalificacion(Calificar parent, int buy_code)
        {
            this.parent = parent;
            this.buy_code = buy_code;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            using(var connection = DBConnection.getInstance().getConnection())
            {
                // TODO: SP - Calificar a un vendedor
                SqlCommand query = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@compra", this.buy_code));
                query.Parameters.Add(new SqlParameter("@calificacion", this.numericUpDown1.Value));
                query.Parameters.Add(new SqlParameter("@descripcion", this.richTextBox1.Text));

                connection.Open();
                query.ExecuteNonQuery();
                MessageBox.Show("Se ha calificado la compra correctamente", "Calificacion exitosa", MessageBoxButtons.OK);
            }
            */
            MessageBox.Show("SP no implementado");
            this.Close();
        }
    }
}
