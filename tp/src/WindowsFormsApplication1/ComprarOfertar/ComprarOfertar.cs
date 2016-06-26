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

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class ComprarOfertar : Form
    {
        Form parent;

        public ComprarOfertar(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.fill_list();
        }

        private void fill_list()
        {
            List<KeyValuePair<int, string>> items = new List<KeyValuePair<int, string>>();
            using (var connection = DBConnection.getInstance().getConnection())
            {
                /* TODO: hacer sp */
                SqlCommand command = new SqlCommand("SELECT cod_rubro, rubro_desc_corta FROM HARDCOR.Rubro", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    items.Add(new KeyValuePair<int, string>(Int32.Parse(reader["cod_rubro"].ToString()),
                                                            reader["rubro_desc_corta"].ToString()));
            }

            Utils.populate(this.checkedListBox1, items);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
