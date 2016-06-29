using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Calificar
{
    public partial class Calificar : Form
    {
        Form parent;
        string username;

        public Calificar(Form parent, string username)
        {
            this.parent = parent;
            this.username = username;
            InitializeComponent();
            this.fill_data_sets();
            this.fill_statistics();
        }

        private void fill_data_sets()
        {
            /*
            using(var connection = DBConnection.getInstance().getConnection())
            {
                connection.Open();

                // TODO: Hacer SP - Ultimas operaciones pendientes de calificar
                SqlCommand query = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@usuario", username));

                //Creo el adapter usando el select_query
                SqlDataAdapter adapter = new SqlDataAdapter(query);

                //Lleno el dataset y lo seteo como source del dataGridView
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.dataGridView1.DataSource = table;
                this.dataGridView1.ReadOnly = true;

                // TODO: Hacer SP - Ultimas 5 publicaciones calificadas
                SqlCommand query2 = new SqlCommand("HARDCOR.", connection);
                query2.CommandType = CommandType.StoredProcedure;
                query2.Parameters.Add(new SqlParameter("@usuario", this.username));

                //Creo el adapter usando el select_query
                SqlDataAdapter adapter2 = new SqlDataAdapter(query2);

                //Lleno el dataset y lo seteo como source del dataGridView
                DataTable table2 = new DataTable();
                adapter.Fill(table2);
                this.dataGridView2.DataSource = table2;
                this.dataGridView2.ReadOnly = true;
            }
            */
        }

        private void fill_statistics ()
        {
            /*
            using(var connection = DBConnection.getInstance().getConnection())
            {
                // TODO: SP - Dar cantidad de ofertas por calificacion, cantidad de subastas por calificacion, total de operaciones
                SqlCommand query = new SqlCommand("HARDCOR.", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@usuario", this.username));

                connection.Open();
                SqlDataReader reader = query.ExecuteReader();
                Label label_to_modify = this.label13;  // Tengo que darle un valor por defecto para que no chille
                while (reader.Read())
                {
                    if(reader["tipo"].ToString() == "Compra Inmediata")
                        switch (Int32.Parse(reader["calificacion"].ToString()))
                        {
                            case 1:
                                label_to_modify = this.label13;
                                break;
                            case 2:
                                label_to_modify = this.label14;
                                break;
                            case 3:
                                label_to_modify = this.label15;
                                break;
                            case 4:
                                label_to_modify = this.label16;
                                break;
                            case 5:
                                label_to_modify = this.label17;
                                break;
                        }
                    else
                        switch (Int32.Parse(reader["calificacion"].ToString()))
                        {
                            case 1:
                                label_to_modify = this.label18;
                                break;
                            case 2:
                                label_to_modify = this.label19;
                                break;
                            case 3:
                                label_to_modify = this.label20;
                                break;
                            case 4:
                                label_to_modify = this.label21;
                                break;
                            case 5:
                                label_to_modify = this.label22;
                                break;
                        }
                    label_to_modify.Text = reader["cantidad"].ToString();
                    this.label21.Text = reader["total"].ToString();
                }
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una compra o subasta");
                return;
            }
        }
    }
}
