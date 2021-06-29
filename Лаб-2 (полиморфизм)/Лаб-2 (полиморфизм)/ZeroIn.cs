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
    public partial class ZeroIn : Form
    {
        public ZeroIn()
        {
            InitializeComponent();
        }

        private void ZeroIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
