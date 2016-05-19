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

namespace WindowsFormsApplication1.ABM
{
    public partial class Baja : Form
    {
        string name;
        string select_query;
        string update_sp;
        DataTable table;
        SqlDataAdapter adapter;

        public Baja(string name, string select_query, string update_sp)
        {
            this.name = name;
            this.select_query = select_query;
            this.update_sp = update_sp;
            this.table = new DataTable();

            InitializeComponent();
            this.fill_data_set();
            this.Text = "Baja o modificación - " + this.name;
        }

        private void fill_data_set ()
        {
            var connection = (new DBConnection()).openConnection();

            //Creo el adapter usando el select_query
            this.adapter = new SqlDataAdapter(this.select_query, connection);

            //Lleno el dataset y lo seteo como source del dataGridView
            this.adapter.Fill(this.table);
            this.dataGridView1.DataSource = this.table;

            //Deshabilito la columna de pks (siempre debe ser la primera)
            this.dataGridView1.Columns[0].ReadOnly = true;

            //Creo el comando de update
            this.adapter.UpdateCommand = this.get_update_command(connection, this.table);

            connection.Close();
        }

        private SqlCommand get_update_command(SqlConnection connection, DataTable table)
        {
            SqlCommand update_command = new SqlCommand(this.update_sp, connection);
            update_command.CommandType = CommandType.StoredProcedure;
            foreach (DataColumn column in table.Columns)
            {
                SqlParameter param = new SqlParameter("@" + column.ColumnName, column.DataType);
                param.SourceColumn = column.ColumnName;
                update_command.Parameters.Add(param);
            }
            return update_command;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxIcon icon;
            string message;
            string title;

            try
            {
                this.adapter.Update(this.table);
                icon = MessageBoxIcon.None;
                message = "Registros actualizados correctamente";
                title = "Operación realizada con éxito";
            }
            catch
            {
                icon = MessageBoxIcon.Error;
                message = "Debido a un error, los cambios no pudieron efectuarse";
                title = "Error";
            }
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }
    }
}
