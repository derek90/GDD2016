using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Utils
    /* Me hubiese gustado que fueran funciones sueltas
     * Thanks C#!
     */
    {
        static public void populate(ComboBox combo, List<KeyValuePair<int,string>> items)
        {
            /* Funcion que llena los items de un comboBox con los items dados */
            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";

            items.ForEach(pair => combo.Items.Add(pair));

            /* Para que seleccione el primer elemento de la lista */
            combo.SelectedItem = combo.Items[0];
        }

        static public void populate(ListBox combo, List<KeyValuePair<int,string>> items)
        {
            /* Funcion que llena los items de un comboBox con los items dados */
            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";

            items.ForEach(pair => combo.Items.Add(pair));

            /* Para que seleccione el primer elemento de la lista */
            combo.SelectedItem = combo.Items[0];
        }

        static public SqlCommand create_sp(string sp_name, List<KeyValuePair<string, object>> parameters, SqlConnection conn)
        {
            /* Funcion que crea un comando de sql para el sp determinado, con los parametros especificados */
            SqlCommand query = new SqlCommand(sp_name, conn);
            query.CommandType = CommandType.StoredProcedure;
            parameters.ForEach(pair => query.Parameters.Add(new SqlParameter(pair.Key, pair.Value)));
            return query;
        }

        static public SqlCommand create_sp(string sp_name, SqlConnection conn)
        {
            /* Funcion que crea un comando de sql para el sp determinado, con los parametros especificados */
            SqlCommand query = new SqlCommand(sp_name, conn);
            query.CommandType = CommandType.StoredProcedure;
            return query;
        }
    }
}
