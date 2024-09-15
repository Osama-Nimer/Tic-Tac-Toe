using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White,10);
            pen.StartCap=System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap=System.Drawing.Drawing2D.LineCap.Round;

            //||
            e.Graphics.DrawLine(pen,700, 40, 700, 390);
            e.Graphics.DrawLine(pen,500, 40, 500, 390);

            //---
            e.Graphics.DrawLine(pen, 360, 280, 840, 280);
            e.Graphics.DrawLine(pen, 360, 150, 840, 150);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
