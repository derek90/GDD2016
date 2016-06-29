using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Rubro
{
    public partial class AbmRubro : Form
    {
        Form parent;

        public AbmRubro(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
