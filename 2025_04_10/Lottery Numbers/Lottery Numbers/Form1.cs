using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lottery_Numbers
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

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5;
            int[] lotteryNumber = new int[SIZE];
            Random rand = new Random();

            for (int i = 0; i < lotteryNumber.Length; i++) 
            {
                int number; 
                do
                {
                    number = rand.Next(1, 43);
                }
                while (lotteryNumber.Contains(number));
                lotteryNumber[i] = number;
            }
            Label[] showLabel = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel };

            for (int i = 0; i < showLabel.Length; i++) 
            {
                showLabel[i].Text = lotteryNumber[i].ToString();
            }

        }
    }
}
