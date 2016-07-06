using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Calificar
{
    public partial class DarCalificacion : Form
    {

        Calificar parent;
        int buy_code;
        string username;

        public DarCalificacion(Calificar parent, int buy_code, string username)
        {
            this.parent = parent;
            this.buy_code = buy_code;
            this.username = username;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("HARDCOR.calificar_vta", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@cod_compra", this.buy_code));
                query.Parameters.Add(new SqlParameter("@estrellas", this.numericUpDown1.Value));
                query.Parameters.Add(new SqlParameter("@detalle", this.richTextBox1.Text));
                query.Parameters.Add(new SqlParameter("@username", this.username));

                connection.Open();
                query.ExecuteNonQuery();
                MessageBox.Show("Se ha calificado la compra correctamente", "Calificacion exitosa", MessageBoxButtons.OK);
            }
            this.parent.refresh();
            this.Close();
        }
    }
}
