using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Historial_Cliente
{
    public partial class HistorialCliente : Form
    {
        Form parent;
        Paginator paginator;
        string username;

        public HistorialCliente(Form parent, string username)
        {
            this.parent = parent;
            this.username = username;
            InitializeComponent();
            List<KeyValuePair<string, object>> param = new List<KeyValuePair<string, object>>();
            param.Add(new KeyValuePair<string, object>("@username", this.username));
            this.paginator = new Paginator(this.numericUpDown1, this.dataGridView1, "HARDCOR.publicaciones_por_usuario", this.button1,
                                           this.button2, this.label1, 10, param);
            this.paginator.load_page(0);
            this.fill_labels(username);
        }

        private void fill_labels(string username)
        {
            string stars_given_average, publication_reviewed, pending_review_publication;

            using(var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("HARDCOR.promedio_estrellas_dadas", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@username", username));

                connection.Open();
                stars_given_average = query.ExecuteScalar().ToString();
                if (stars_given_average == "")
                    stars_given_average = "0";

                query = new SqlCommand("HARDCOR.cantidad_publicaciones_calificadas", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@username", username));

                publication_reviewed = query.ExecuteScalar().ToString();

                query = new SqlCommand("HARDCOR.cantidad_publicaciones_sin_calificar", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@username", username));

                pending_review_publication = query.ExecuteScalar().ToString();
            }

            this.label3.Text = stars_given_average;
            this.label5.Text = publication_reviewed;
            this.label7.Text = pending_review_publication;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
