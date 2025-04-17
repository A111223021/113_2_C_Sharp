using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            //定義座位數
            const int ROWS = 6; //6行
            const int COLS = 4; //4列

            int row; //儲存使用者輸入的行號
            int col; //儲存使用者輸入的列號

            //定義座位價格的二維陣列
            decimal[,] seatPrices =
            {
                { 450m, 450m, 450m, 450m },
                { 425m, 425m, 425m, 425m },
                { 400m, 400m, 400m, 400m },
                { 375m, 375m, 375m, 375m },
                { 375m, 375m, 375m, 375m },
                { 350m, 350m, 350m, 350m },
            };

            if (int.TryParse(rowTextBox.Text, out row))
            {
                if (int.TryParse(rowTextBox.Text, out col))
                {
                    if (row >= 0 && row < ROWS)
                    {
                        if (col >= 0 && col < COLS)
                        {
                            priceLabel.Text = seatPrices[row, col].ToString("C");
                        }
                        else 
                        {
                            MessageBox.Show("列編號0~3!");
                            rowTextBox.Focus();
                            return;
                        }
                    }
                    else 
                    {
                        MessageBox.Show("列編號0~5!");
                        rowTextBox.Focus();
                        return;
                    }
                }
                else 
                {
                    MessageBox.Show("請輸入有效行號");
                    colTextBox.Focus();
                    return;
                }
            }
            else 
            {
                MessageBox.Show("請輸入有效行號");
                rowTextBox.Focus();
                return;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void colPromptLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
