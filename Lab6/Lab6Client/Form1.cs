using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSSPAAModel;

namespace Lab6Client
{
    public partial class Form1 : Form
    {
        WSSPAAEntities1 WSSPAAEntities1;
        public Form1()
        {
            InitializeComponent();
            WSSPAAEntities1 = new WSSPAAEntities1(new Uri("http://localhost:61801/WcfDataService1.svc/"));
        }

        private void button1_Click(object sender, EventArgs e)
        {               
            listBox1.Items.Clear();
            foreach(var mark in WSSPAAEntities1.Marks)
            {
                listBox1.Items.Add(mark.id+ " " + mark.subject + " " + mark.mark1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {               
            listBox1.Items.Clear();
            foreach (var mark in WSSPAAEntities1.Marks.Select((mark) => new { mark.subject }))
            {
                listBox1.Items.Add(mark.subject);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {    
            listBox1.Items.Clear();
            foreach (var mark in WSSPAAEntities1.Marks.OrderByDescending((mark) => mark.mark1))
            {
                listBox1.Items.Add(mark.id + " " + mark.subject + " " + mark.mark1);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mark mark = new Mark { id = int.Parse(textBox1.Text), subject = textBox2.Text, mark1 = int.Parse(textBox3.Text) };
            WSSPAAEntities1.AddToMarks(mark);
            WSSPAAEntities1.SaveChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mark markToUpdate = WSSPAAEntities1.Marks.Where(mark => mark.id == int.Parse(textBox1.Text) && mark.subject == textBox2.Text).FirstOrDefault();
            markToUpdate.mark1 = int.Parse(textBox3.Text);
            WSSPAAEntities1.UpdateObject(markToUpdate);
            WSSPAAEntities1.SaveChanges();
        }
    }
}
