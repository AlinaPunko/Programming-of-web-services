using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4_WebForm
{
    public partial class _Default : Page
    {
        private Simlex proxyClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            proxyClient = new Simlex();
        }

        public void Add_Click(object sender, EventArgs e)
        {
            if (int.TryParse(x.Text, out int intX) && int.TryParse(y.Text, out int intY))
                result1.Text = proxyClient.Add(intX, intY).ToString();
        }

        public void Concat_Click(object sender, EventArgs e)
        {
            if (int.TryParse(x.Text, out int intX))
                result2.Text = proxyClient.Concat(s.Text, intX);
        }

        public void Sum_Click(object sender, EventArgs e)
        {
            if (int.TryParse(k1.Text, out int intk1)
                && int.TryParse(k2.Text, out int intk2)
                && float.TryParse(f1.Text, out float floatf1)
                && float.TryParse(f2.Text, out float floatf2))
            {
                A result = proxyClient.Sum(new A { s = s1.Text, k = intk1, f = floatf1 },
                    new A { s = s2.Text, k = intk2, f = floatf2 });

                s3.Text = result.s;
                k3.Text = result.k.ToString();
                f3.Text = result.f.ToString();
            }
        }
    }
}