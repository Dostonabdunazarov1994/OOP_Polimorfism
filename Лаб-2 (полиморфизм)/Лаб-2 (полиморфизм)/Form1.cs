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
     partial class Form1 : Form
    {
        Crossing cros = new Crossing();
        ZeroIn zero = new ZeroIn();
        Info info;
        Equal equal = new Equal();
        public Figure[] figure;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            info = new Info(this);
        }
        int k;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(textBox1.Text != "")
                {
                    k = 0;
                    info.listBox1.Items.Clear();
                    figure = new Figure[int.Parse(textBox1.Text)];
                    for (int i = 0; i < int.Parse(textBox1.Text); i++)
                    {
                        k++;
                        switch (rnd.Next(3))
                        {
                            case 0:
                                {
                                    figure[i] = new Point(rnd.Next(-8, 9), rnd.Next(-8, 9));
                                    info.listBox1.Items.Add(k + ". " + figure[i].ToString());
                                    break;
                                }
                            case 1:
                                {
                                    figure[i] = new Circle(rnd.Next(-8, 9), rnd.Next(-8, 9), rnd.Next(1, 100));
                                    info.listBox1.Items.Add(k + ". " + figure[i].ToString());
                                    break;
                                }
                            case 2:
                                {
                                    figure[i] = new Square(rnd.Next(-8, 9), rnd.Next(-8, 9), rnd.Next(1, 100));
                                    info.listBox1.Items.Add(k + ". " + figure[i].ToString());
                                    break;
                                }
                        }
                    }
                    Draw();
                }
                textBox1.Text = "";
            }
            
        }
        int k1;
        public void Draw()
        {
            k1 = 0;
            int Xlines = pictureBox1.Width / 20;
            int Ylines = pictureBox1.Height / 20;
            int x0 = pictureBox1.Width / 2;
            int y0 = pictureBox1.Height / 2;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.AntiqueWhite);
            Pen black = new Pen(Color.Black, 1);
            Pen blue = new Pen(Color.Blue);
            Pen red = new Pen(Color.Red,2);
            Pen green = new Pen(Color.Green);
            g.DrawLine(black, 0, y0, pictureBox1.Width, y0);
            g.DrawLine(black, x0, 0, x0, pictureBox1.Height);
            Font f = new Font(DefaultFont, FontStyle.Bold);
            SolidBrush solid = new SolidBrush(Color.Black);
            for(int i = Xlines; i < pictureBox1.Height; i+=Xlines)
            {
                g.DrawLine(black, x0 - 3, i, x0 + 3, i);
            }
            for (int i = Xlines; i < pictureBox1.Height; i += Xlines)
            {
                g.DrawLine(black, i, y0+3,i, y0 - 3);
            }
            for (int i = 0; i < figure.Length; i++)
            {
                k1++;
                if (figure[i] is Point)
                {                   
                    g.DrawEllipse(red, x0 + figure[i].X * Xlines, y0-figure[i].Y * Ylines, 2f, 2f);
                    g.DrawString(k1.ToString(), f, solid, (x0 + figure[i].X * Xlines)-6, (y0 - figure[i].Y * Ylines) - 15);
                }
                else if(figure[i] is Square)
                {
                    //g.DrawRectangle(blue, (float)(x0 + Xlines * figure[i].X - Xlines * ((Square)figure[i]).Side / Xlines), (float)(y0 - Xlines * figure[i].Y - Xlines * ((Square)figure[i]).Side / 2), Xlines * (float)(((Square)figure[i]).Side), Xlines * (float)(((Square)figure[i]).Side));
                    g.DrawRectangle(blue, (x0 + figure[i].X * Xlines) - (float)((Square)figure[i]).Side * Xlines / 2, (y0 - figure[i].Y * Ylines) - (float)((Square)figure[i]).Side * Xlines / 2, (float)((Square)figure[i]).Side * Xlines, (float)((Square)figure[i]).Side * Ylines);
                    g.DrawString(k1.ToString(), f, solid, (x0 + figure[i].X * Xlines) - (float)((Square)figure[i]).Side * Xlines / 2, ((y0 - figure[i].Y * Ylines) - (float)((Square)figure[i]).Side * Xlines / 2) - 15);
                }
                else if(figure[i] is Circle)
                {
                    g.DrawEllipse(green, (x0 + figure[i].X * Xlines) - (float)((Circle)figure[i]).R * Xlines, (y0 - figure[i].Y * Ylines) - (float)((Circle)figure[i]).R * Ylines, ((float)((Circle)figure[i]).R * Ylines) * 2, ((float)((Circle)figure[i]).R * Ylines)* 2);
                    g.DrawString(k1.ToString(), f, solid, ((x0 + figure[i].X * Xlines) - (float)((Circle)figure[i]).R * Xlines) + ((float)((Circle)figure[i]).R * Xlines) - 10, ((y0 - figure[i].Y * Ylines) - (float)((Circle)figure[i]).R * Ylines) - 15);
                }
            }
            pictureBox1.Image = bmp;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox1.Text) <= 0 && int.Parse(textBox1.Text) >= 20)
                    textBox1.Text = "";
            }
            catch { textBox1.Text = ""; }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            info.Show();
        }
        Figure f = null;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int k = 0;
            for(int i = 0; i < figure.Length; i++)
            {
                if (i == info.listBox1.SelectedIndex)
                {
                    f = figure[i];
                    k = i;
                }
            }
            if(f is Point)
               ((Point)f).X = (int)numericUpDown1.Value;
            if (f is Circle)
                ((Circle)f).X = (int)numericUpDown1.Value;
            if (f is Square)
                ((Square)f).X = (int)numericUpDown1.Value;
            figure[k].X = (int)numericUpDown1.Value;
            info.listBox1.Items[k] = k+1 + ". " +figure[k].ToString();
            zeroin();
            equals();
            cross();
            Draw();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int k = 0;
            for (int i = 0; i < figure.Length; i++)
            {
                if (i == info.listBox1.SelectedIndex)
                {
                    f = figure[i];
                    k = i;
                }
            }
            if (f is Point)
                ((Point)f).Y = (int)numericUpDown2.Value;
            if (f is Circle)
                ((Circle)f).Y = (int)numericUpDown2.Value;
            if (f is Square)
                ((Square)f).Y = (int)numericUpDown2.Value;
            figure[k].Y = (int)numericUpDown2.Value;
            info.listBox1.Items[k] = k+1 + ". "+figure[k].ToString();
            zeroin();
            equals();
            cross();
            Draw();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            int k = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (double.Parse(textBox2.Text) > 0 && double.Parse(textBox2.Text) <= 100)
                {
                    if (label4.Text == "Радиус")
                    {
                        textBox3.Text = Math.Round((Math.Sqrt(double.Parse(textBox2.Text) / Math.PI)), 3).ToString();
                    }
                    else
                    {
                        textBox3.Text = Math.Round((Math.Sqrt(double.Parse(textBox2.Text))), 3).ToString();
                    }
                }
                for (int i = 0; i < figure.Length; i++)
                {
                    if (i == info.listBox1.SelectedIndex)
                    {
                        f = figure[i];
                        k = i;
                    }
                }
                if (f is Point)
                    ((Point)f).S = 0;
                if (f is Circle)
                    ((Circle)f).S = Math.Round(double.Parse(textBox2.Text),3);
                if (f is Square)
                    ((Square)f).S = Math.Round(double.Parse(textBox2.Text),3);
                figure[k].S = Math.Round(double.Parse(textBox2.Text),3);
                info.listBox1.Items[k] = k+1 + ". "+figure[k].ToString();
                zeroin();
                equals();
                cross();
                Draw();
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            int k = 0;
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < figure.Length; i++)
                {
                    if (i == info.listBox1.SelectedIndex)
                    {
                        f = figure[i];
                        k = i;
                    }
                }
                if (label4.Text == "Радиус" && double.Parse(textBox3.Text) > 0 && double.Parse(textBox3.Text) <= 5.642)
                {
                    textBox2.Text = Math.Round((Math.PI * double.Parse(textBox3.Text) * double.Parse(textBox3.Text)), 3).ToString();
                    if (f is Circle)
                        ((Circle)f).R = Math.Round(double.Parse(textBox3.Text), 3);
                    ((Circle)figure[k]).R = Math.Round(double.Parse(textBox3.Text), 3);
                
                }
                if (label4.Text == "Сторона" && double.Parse(textBox3.Text) > 0 && double.Parse(textBox3.Text) <= 10)
                {
                    textBox2.Text = Math.Round((double.Parse(textBox3.Text) * double.Parse(textBox3.Text)), 3).ToString();
                    if (f is Square)
                        ((Square)f).Side = Math.Round(double.Parse(textBox3.Text), 3);
                    ((Square)figure[k]).Side = Math.Round(double.Parse(textBox3.Text), 3);
                }
                info.listBox1.Items[k] = k+1 + ". " +figure[k].ToString();
                zeroin();
                equals();
                cross();
                Draw();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    double.Parse(textBox2.Text);
            //    if (int.Parse(textBox2.Text) <= 0 && int.Parse(textBox2.Text) > 100)
            //        textBox2.Text = "0";
            //}
            //catch { textBox2.Text = "0"; }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    double.Parse(textBox3.Text);
            //    if (double.Parse(textBox3.Text) <= 0 && double.Parse(textBox3.Text) > 5.642)
            //        textBox2.Text = "0";
            //}
            //catch { textBox2.Text = "0"; }
        }
        void cross()
        {
            cros.Text = "Crossing";
            cros.textBox1.Text = "";
            cros.label1.Text = "";
            cros.label2.Text = "";
            for (int i = 0; i < figure.Length; i++)
            {
                if (figure[i] is Point)
                    cros.label1.Text += i + 1 + ".Точка  ";
                if (figure[i] is Circle)
                    cros.label1.Text += i + 1 + ".Круг   ";
                if (figure[i] is Square)
                    cros.label1.Text += i + 1 + ".Квадр  ";
            }
            for (int i = 0; i < figure.Length; i++)
            {
                if (figure[i] is Point)
                    cros.label2.Text += i + 1 + ".Точка\n\n";
                if (figure[i] is Circle)
                    cros.label2.Text += i + 1 + ".Круг\n\n";
                if (figure[i] is Square)
                    cros.label2.Text += i + 1 + ".Квадрат\n\n";
            }
            for (int i = 0; i < figure.Length; i++)
            {
                for (int j = 0; j < figure.Length; j++)
                {
                    if (figure[i] is Point)
                        cros.textBox1.Text += figure[i].Crossing(figure[j]) + "       ";
                    if (figure[i] is Circle)
                        cros.textBox1.Text += figure[i].Crossing(figure[j]) + "       ";
                    if (figure[i] is Square)
                        cros.textBox1.Text += figure[i].Crossing(figure[j]) + "       ";
                }
                cros.textBox1.Text += "\r\n\r\n";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cross();
            cros.Show();
        }
        void equals()
        {
            equal.Text = "Equal";
            equal.textBox1.Text = "";
            equal.label1.Text = "";
            equal.label2.Text = "";
            for (int i = 0; i < figure.Length; i++)
            {
                if (figure[i] is Point)
                    equal.label1.Text += i + 1 + ".Точка  ";
                if (figure[i] is Circle)
                    equal.label1.Text += i + 1 + ".Круг   ";
                if (figure[i] is Square)
                    equal.label1.Text += i + 1 + ".Квадр  ";
            }
            for (int i = 0; i < figure.Length; i++)
            {
                if (figure[i] is Point)
                    equal.label2.Text += i + 1 + ".Точка\n\n";
                if (figure[i] is Circle)
                    equal.label2.Text += i + 1 + ".Круг\n\n";
                if (figure[i] is Square)
                    equal.label2.Text += i + 1 + ".Квадрат\n\n";
            }
            for (int i = 0; i < figure.Length; i++)
            {
                for (int j = 0; j < figure.Length; j++)
                {
                    if (figure[i] is Point)
                        equal.textBox1.Text += figure[i].Equal(figure[j]) + "       ";
                    if (figure[i] is Circle)
                        equal.textBox1.Text += figure[i].Equal(figure[j]) + "       ";
                    if (figure[i] is Square)
                        equal.textBox1.Text += figure[i].Equal(figure[j]) + "       ";
                }
                equal.textBox1.Text += "\r\n\r\n";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            equals();
            equal.Show();
        }
        public void zeroin()
        {
            zero.Text = "ZeroIn";
            zero.label1.Text = "(0,0)";
            zero.textBox1.Text = "";
            zero.label2.Text = "";
            for (int i = 0; i < figure.Length; i++)
            {
                if (figure[i] is Point)
                    zero.label2.Text += i + 1 + ".Точка\n\n";
                if (figure[i] is Circle)
                    zero.label2.Text += i + 1 + ".Круг\n\n";
                if (figure[i] is Square)
                    zero.label2.Text += i + 1 + ".Квадрат\n\n";
            }
            for (int i = 0; i < figure.Length; i++)
            {
                if (figure[i] is Point)
                    zero.textBox1.Text += figure[i].ZeroIn() + "      ";
                if (figure[i] is Circle)
                    zero.textBox1.Text += figure[i].ZeroIn() + "      ";
                if (figure[i] is Square)
                    zero.textBox1.Text += figure[i].ZeroIn() + "      ";

                zero.textBox1.Text += "\r\n\r\n";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            zeroin();
            zero.Show();
        }
    }
}
