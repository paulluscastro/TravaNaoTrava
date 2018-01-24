using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravaNaoTrava
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Loop10()
        {
            progressBar1.BeginInvoke((Action)delegate {
                progressBar1.Value = 0;
                progressBar1.Maximum = 100;
                progressBar1.Style = ProgressBarStyle.Marquee;
            });
            DateTime inicio = DateTime.Now;
            int segundos = 0;
            while (segundos < 10)
            {
                segundos = (int)(DateTime.Now - inicio).TotalSeconds;
            }
            progressBar1.BeginInvoke((Action)delegate {
                progressBar1.Style = ProgressBarStyle.Blocks;
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loop10();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(Loop10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings = dlg.PrinterSettings;
                pd.PrintPage += PrintPage;
                pd.Print();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(DisplayRectangle.Width, DisplayRectangle.Height);
            DrawToBitmap(bitmap, DisplayRectangle);
            e.Graphics.DrawImage(bitmap, new Point() { X = 10, Y = 10 });
        }
    }
}
