﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new ServiceReference1.Service1Client();
            var txt = client.GetData((int)numericUpDown1.Value);
            label1.Text = txt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new ServiceReference1.Service1Client();

            dataGridView1.DataSource = client.GetKlassen();
        }
    }
}
