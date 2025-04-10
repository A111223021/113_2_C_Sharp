using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The Average method accepts an int array argument
        // and returns the Average of the values in the array.
        private int Average(   )
        {
            
        }

        // The Highest method accepts an int array argument
        // and returns the highest value in that array.
        private int Highest(int[] scores )
        {
            int highest = scores[0];
            for (int i = 0; i < scores.Length; i++) 
            {
            
            }
        }

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        private int Lowest(   )
        {
           
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48;
            int[] TestScore = new int[SIZE];
            int inde = 0;
            int highestScore = 0;
            int lowestScore = 0;
            int averageScore = 0;
            StreamReader inputFile;

            try
            {
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Open the file.
                    inputFile = File.OpenText(openFileDialog1.FileName);
                    // Read the values from the file into the array.
                    while (inde < SIZE && !inputFile.EndOfStream)
                    {
                        TestScore[inde] = Convert.ToInt32(inputFile.ReadLine());
                        inde++;
                    }
                    // Close the file.
                    inputFile.Close();
                    // Call the Average method and display the result.
                    averageScore = Average(TestScore);
                    highestScore = Highest(TestScore);
                    lowestScore = Lowest(TestScore);

                    highScoreLabel.Text = highestScore.ToString();
                    averageScoreLabel.Text = averageScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();
                }
            }
            catch 
            {
                
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
