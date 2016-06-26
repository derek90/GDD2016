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

namespace WindowsFormsApplication1.Menu_principal
{
    public partial class MainMenu : Form
    {
        Dictionary<int, Func<Form>> form_mapping;
        Form login_form;

        public MainMenu(Form login_form, int role_code)
        {
            InitializeComponent();
            this.login_form = login_form;
            this.initialize_form_mapping();
            this.fill_list(role_code);
        }

        private void fill_list(int role_code)
        {
            var sp_params = new List<KeyValuePair<string, object>>();
            sp_params.Add(new KeyValuePair<string, object>("@cod_rol", role_code));
            var roles = new List<KeyValuePair<int, string>>();

            using (SqlConnection connection = DBConnection.getInstance().getConnection())
            { 
                SqlCommand query = Utils.create_sp("HARDCOR.funcionalidades_del_rol", sp_params, connection);
                connection.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                    roles.Add(new KeyValuePair<int, string>(Int32.Parse(reader["cod_fun"].ToString()), reader["descripcion"].ToString()));
            }
            Utils.populate(this.listBox1, roles);
        }

        private void initialize_form_mapping()
        {
            this.form_mapping = new Dictionary<int, Func<Form>>();
            this.form_mapping.Add(1, () => new ABM_Rol.AbmRol());
            this.form_mapping.Add(2, () => new ABM_Usuario.AbmUsuario());
            this.form_mapping.Add(3, () => new ABM_Rubro.AbmRubro());
            this.form_mapping.Add(4, () => new ABM_Visibilidad.AbmVisibilidad(this));
            this.form_mapping.Add(5, () => new Generar_Publicación.GenerarPublicacion(this));
            this.form_mapping.Add(6, () => new ComprarOfertar.ComprarOfertar(this));
            this.form_mapping.Add(7, () => new Historial_Cliente.Form1());
            this.form_mapping.Add(8, () => new Calificar.Form1());
            this.form_mapping.Add(9, () => new Facturas.Form1());
            this.form_mapping.Add(10, () => new Listado_Estadistico.Form1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.login_form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selected_functionality_code = ((KeyValuePair<int, string>) this.listBox1.SelectedItem).Key;
            if (!this.form_mapping.ContainsKey(selected_functionality_code))
                return;

            this.Hide();
            (this.form_mapping[selected_functionality_code])().Show();
        }
    }
}
