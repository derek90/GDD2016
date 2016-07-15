using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class ConfirmarCompraOferta : Form
    {
        int publication_code;
        string username;
        ComprarOfertar parent;
        bool is_auction;

        public ConfirmarCompraOferta(ComprarOfertar parent, string username, int publication_code, bool is_auction, decimal min, decimal max)
        {
            this.publication_code = publication_code;
            this.parent = parent;
            this.username = username;
            this.is_auction = is_auction;
            InitializeComponent();
            if (is_auction)
            {
                this.label1.Text = "Monto a ofertar";
                this.button1.Text = "Ofertar";
            }
            this.numericUpDown1.Minimum = min;
            this.numericUpDown1.Maximum = max;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("HARDCOR.comprar_ofertar", connection);

                //Seteo que sea un stored procedure
                query.CommandType = CommandType.StoredProcedure;

                //Agrego los parámetros
                query.Parameters.Add(new SqlParameter("@cod_pub", this.publication_code));
                query.Parameters.Add(new SqlParameter("@usuario", this.username));
                query.Parameters.Add(new SqlParameter("@fecha",  DateTime.Parse(ConfigurationManager.AppSettings["current_date"].ToString())));
                if (is_auction)
                {
                    query.Parameters.Add(new SqlParameter("@cantidad", 1));
                    query.Parameters.Add(new SqlParameter("@mont_of", this.numericUpDown1.Value));
                }
                else
                {
                    query.Parameters.Add(new SqlParameter("@cantidad", this.numericUpDown1.Value));
                    query.Parameters.Add(new SqlParameter("@mont_of", this.numericUpDown1.Value));
                }

                connection.Open();

                if (!is_auction)
                {
                    int bill_number = Int32.Parse(query.ExecuteScalar().ToString());
                    SqlCommand fetch_bill = new SqlCommand("HARDCOR.obtener_factura", connection);
                    fetch_bill.CommandType = CommandType.StoredProcedure;
                    fetch_bill.Parameters.Add(new SqlParameter("@numero", bill_number));
                    SqlDataReader reader = fetch_bill.ExecuteReader();
                    reader.Read();
                    DateTime date = DateTime.Parse(reader["fecha"].ToString());
                    float total = float.Parse(reader["total"].ToString());
                    string payment_type = reader["forma_pago"].ToString();
                    int user_code = Int32.Parse(reader["cod_us"].ToString());
                    MessageBox.Show("La compra se ha efectuado correctamente", "Compra exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.parent.refresh();
                    (new Facturas.Factura(this.parent, bill_number, this.publication_code, user_code, date, payment_type, total)).Show();
                }
                else
                {
                    query.ExecuteNonQuery();
                    MessageBox.Show("Se ha ofertado correctamente", "Oferta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.parent.refresh();
                    this.parent.Show();
                }

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
