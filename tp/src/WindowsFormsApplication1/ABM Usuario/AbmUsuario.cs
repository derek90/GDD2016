﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class AbmUsuario : Form
    {
        public AbmUsuario()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (new AltaUsuario()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new AltaUsuario()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new ModificacionCliente()).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            (new ModificacionEmpresa()).Show();
        }
    }
}
