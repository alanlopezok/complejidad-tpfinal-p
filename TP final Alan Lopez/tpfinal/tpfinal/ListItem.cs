﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpfinal
{
    public partial class ListItem : UserControl
    {

        private DatoDistancia _dato;
        public DatoDistancia Dato {
            get
            {
                return _dato;    
            }

            set
            {
                _dato = value;
                label1.Text = value.texto;
                label3.Text = "Distancia: "+value.distancia;
                label2.Text = value.descripcion;
            }

        }
        public ListItem()
        {
            InitializeComponent();
            label2.Width = this.Width - 3;
            label3.Left = this.Width - 6;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
