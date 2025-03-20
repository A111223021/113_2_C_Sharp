using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5; //The size of array;
            int[] lotteryNumber = new int[SIZE];
            Random rand = new Random();

            for (int i = 0; i < lotteryNumber.Length; i++) 
            {
                lotteryNumber[i] = rand.Next(1, 43);
            }

          //firstLabel.Text  = lotteryNumber[0].ToString();
          //secondLabel.Text = lotteryNumber[1].ToString();
          //thirdLabel.Text  = lotteryNumber[2].ToString();
          //fourthLabel.Text = lotteryNumber[3].ToString();
          //fifthLabel.Text  = lotteryNumber[4].ToString();
          
            Label[]showLabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel };
            for (int i = 0; i < showLabels.Length; i++)
            {
                showLabels[i].Text = lotteryNumber[i].ToString();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
