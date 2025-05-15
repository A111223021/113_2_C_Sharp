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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "CSV讀取器";
            getScoresButton.Text = "取得分數";
            exitButton.Text = "離開";

        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            averagesListBox.Items.Clear();

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "CSV 檔案(*.csv)|*.csv*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader inputFile = File.OpenText(openFile.FileName);
                    string line;
                    int count = 0;

                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine();

                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }

                        line = line.Trim();
                        string[] tokens = line.Split(',');

                        double total = 0;
                        int validCount = 0;

                        foreach (string token in tokens)
                        {
                            if (int.TryParse(token.Trim(), out int score))
                            {
                                total += score;
                                validCount++;
                            }
                        }

                        if (validCount > 0)
                        {
                            double average = total / validCount;
                            averagesListBox.Items.Add($"第 {count + 1} 位同學的平均分數: {average}");
                        }
                        else
                        {
                            averagesListBox.Items.Add($"第 {count + 1} 位資料格式錯誤，無法計算");
                        }
                        count++;
                    }
                    inputFile.Close();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("讀取檔案時發生錯誤:" + ex.Message);
                }

            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
