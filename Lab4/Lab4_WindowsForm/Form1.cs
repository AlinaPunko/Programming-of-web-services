using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_WindowsForm
{
    public partial class Form1 : Form
    {
        public ServiceReference1.SimlexSoapClient client;
        public Form1()
        {
            InitializeComponent();
            client = new ServiceReference1.SimlexSoapClient();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (int.TryParse(x.Text, out int intX) && int.TryParse(y.Text, out int intY))
             z.Text = client.Add(intX, intY).ToString();
        }

        private void Concat_Click(object sender, EventArgs e)
        {
            if (int.TryParse(x.Text, out int intX))
                result.Text = client.Concat(s.Text, intX);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(int.TryParse(k1.Text, out int intk1) 
                && int.TryParse(k2.Text, out int intk2)
                && float.TryParse(f1.Text, out float floatf1)
                && float.TryParse(f2.Text, out float floatf2))
            {
                ServiceReference1.A result = client.Sum(new ServiceReference1.A { s = s1.Text, k = intk1, f = floatf1 },
    new ServiceReference1.A { s = s2.Text, k = intk2, f = floatf2 });

                s3.Text = result.s;
                k3.Text = result.k.ToString();
                f3.Text = result.f.ToString();
            }
        }
    }
}
