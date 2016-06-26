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

namespace WindowsFormsApplication1.Facturas
{
    public partial class Factura : Form
    {
        Form parent;

        public Factura(Form parent, int bill_number, int publication_code,
                       int user_code, DateTime date, string payment_type, int total)
        {
            this.parent = parent;
            InitializeComponent();
            this.label7.Text = bill_number.ToString();
            this.label8.Text = publication_code.ToString();
            this.label9.Text = get_full_name(user_code);
            this.label10.Text = date.ToString();
            this.label11.Text = payment_type;
            this.label12.Text = total.ToString();

            this.fill_data_set(user_code);
        }

        private string get_full_name(int user_code)
        {
            string name;
            using(var connection = DBConnection.getInstance().getConnection())
            {
                /* TODO:  sp */
                SqlCommand query = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@codigo_usuario", user_code));

                SqlDataReader reader = query.ExecuteReader();
                reader.Read();
                name = reader["nombre"].ToString();
            }
            return "";
        }

        private void fill_data_set (int user_code)
        {
            /*
            using(var connection = DBConnection.getInstance().getConnection())
            {
                // TODO:  sp
                SqlCommand query = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@codigo_usuario", user_code));

                //Creo el adapter usando el select_query
                SqlDataAdapter adapter = new SqlDataAdapter(query);

                //Lleno el dataset y lo seteo como source del dataGridView
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.dataGridView1.DataSource = table;
                this.dataGridView1.ReadOnly = true;
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
