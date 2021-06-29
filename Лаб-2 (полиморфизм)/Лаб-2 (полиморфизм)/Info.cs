using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб_2__полиморфизм_
{
     partial class Info : Form
    {
        public Info(Form1 form1)
        {
            InitializeComponent();
            f1 = form1;
        }
        Form1 f1;
        private void listBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Figure f = null;
            if (listBox1.Items.Count != 0 && listBox1.SelectedItem != null)
            {
                for (int i = 0; i < f1.figure.Length; i++)
                {
                    if (/*f1.figure[i].ToString() == listBox1.SelectedItem.ToString()*/i == listBox1.SelectedIndex)
                    {
                        f = f1.figure[i];
                    }
                }
                if (f is Point)
                {
                    f1.numericUpDown1.Value = ((Point)f).X;
                    f1.numericUpDown2.Value = ((Point)f).Y;
                    f1.textBox2.Text = 0.ToString();
                    f1.textBox3.Visible = false;
                    f1.label4.Visible = false;
                }
                if (f is Circle)
                {
                    f1.numericUpDown1.Value = ((Circle)f).X;
                    f1.numericUpDown2.Value = ((Circle)f).Y;
                    f1.textBox2.Text = ((Circle)f).S.ToString();
                    f1.textBox3.Text = Math.Round(((Circle)f).R, 3).ToString();
                    f1.textBox3.Visible = true;
                    f1.label4.Visible = true;
                    f1.label4.Text = "Радиус";
                }
                if (f is Square)
                {
                    f1.numericUpDown1.Value = ((Square)f).X;
                    f1.numericUpDown2.Value = ((Square)f).Y;
                    f1.textBox2.Text = ((Square)f).S.ToString();
                    f1.textBox3.Text = Math.Round(((Square)f).Side, 3).ToString();
                    f1.textBox3.Visible = true;
                    f1.label4.Text = "Сторона";
                    f1.label4.Visible = true;
                }
                f1.Draw();
            }
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Info_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
