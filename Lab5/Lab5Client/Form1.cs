using Lab5Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5Client
{
    public partial class Form1 : Form
    {
        BASICPAA.Service1Client client1;
        BASICPAA.Service1Client client2;

        public Form1()
        {
            InitializeComponent();
            client1 = new BASICPAA.Service1Client("BasicHttpBinding_IService1");
            //client2 = new BASICPAA.Service1Client("NetTcpBinding_IService1");
            client1.Open();
            //client2.Open();
        }

        private void add_Click(object sender, EventArgs e)
        {
            z1.ForeColor = Color.Black;
            int val1, val2;
            if (int.TryParse(x1.Text.ToString(), out val1) && int.TryParse(y1.Text.ToString(), out val2))
            {
                z1.Text = client1.Add(val1, val2).ToString();
            }
            else
            {
                z1.ForeColor = Color.Red;
                z1.Text = "Error!";
            }
        }

        private void concat_Click(object sender, EventArgs e)
        {
            z2.ForeColor = Color.Black;
            int val1;
            string val2 = y2.Text;
            if (int.TryParse(x2.Text, out val1))
            {
                z2.Text = client1.Concat(val2, val1);
            }
            else
            {
                z2.ForeColor = Color.Red;
                z2.Text = "Error!";
            }
        }

        private void sum_Click(object sender, EventArgs e)
        {
            A A1 = new A();
            A1.s = s1.Text;
            A1.k = int.Parse(i1.Text);
            A1.f = float.Parse(d1.Text);

            A A2 = new A();
            A2.s = s2.Text;
            A2.k = int.Parse(i2.Text);
            A2.f = float.Parse(d2.Text);

            A result = client1.Sum(A1, A2);

            s3.Text = result.s;
            i3.Text = result.k.ToString();
            d3.Text = result.f.ToString();
        }
    }
}
