using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Spectrum
{
    enum Spectrum 
    { 
        紅, 橙, 黃, 綠,
        藍, 靛, 紫 
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void DisplayColor(Spectrum color)
        {
            colorLabel.Text = color.ToString();
        }


        private void redLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.紅);
        }

        private void orangeLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.橙);
        }

        private void yellowLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.黃);
        }

        private void greenLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.綠);
        }

        private void blueLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.藍);
        }

        private void indigoLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.靛);
        }

        private void violetLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.紫);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            redLabel.Text = string.Empty;
            orangeLabel.Text = string.Empty;
            yellowLabel.Text = string.Empty;
            greenLabel.Text = string.Empty;
            blueLabel.Text = string.Empty;
            indigoLabel.Text = string.Empty;
            violetLabel.Text = string.Empty;

            colorLabel.Text = "";
        }
    }
}
