using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class ConfirmarCompraOferta : Form
    {
        int publication_code;
        string username;
        ComprarOfertar parent;

        public ConfirmarCompraOferta(ComprarOfertar parent, string username, int publication_code, int min, int max)
        {
            this.publication_code = publication_code;
            this.parent = parent;
            this.username = username;
            InitializeComponent();
            this.numericUpDown1.Minimum = min;
            this.numericUpDown1.Maximum = max;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = DBConnection.getInstance().getConnection())
            {
                // TODO: Hacer sp
                // Me tiene que devolver la factura para mostrar
                SqlCommand query = new SqlCommand("HARDCOR.", connection);

                //Seteo que sea un stored procedure
                query.CommandType = CommandType.StoredProcedure;

                //Agrego los parámetros
                query.Parameters.Add(new SqlParameter("@codigo_publicacion", this.publication_code));
                query.Parameters.Add(new SqlParameter("@usuario", this.username));

                SqlDataReader reader = query.ExecuteReader();

                reader.Read();
                int bill_number = Int32.Parse(reader["nro_fact"].ToString());
                DateTime date = DateTime.Parse(reader["fecha"].ToString());
                int total = Int32.Parse(reader["total"].ToString());
                string payment_type = reader["forma_pago"].ToString();

                this.Close();
                /* TODO: Abrir el form para ver las factuas
                 * pasarle el parent de esta asi puede volver
                 * pasarle todos los arguementos de arriba mas codigo de publicacion
                 * y codigo de usuario
                 */
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
