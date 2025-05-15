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
            平均成績單.Items.Clear();

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "CSV 檔案(*.csv)|*.csv*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader inputFile = File.OpenText(openFile.FileName);
                    string line;

                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine();

                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        line = line.Trim();

                        // 先把名字和成績分開
                        // 假設格式為：姓名後面直接接第一個成績
                        int nameEndIndex = line.IndexOfAny("0123456789".ToCharArray());
                        if (nameEndIndex == -1)
                        {
                            平均成績單.Items.Add("格式錯誤，找不到姓名與分數的分界。");
                            continue;
                        }

                        string name = line.Substring(0, nameEndIndex);
                        string scoresPart = line.Substring(nameEndIndex);

                        string[] tokens = scoresPart.Split(',');

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
                            平均成績單.Items.Add($"{name} 的平均分數: {average:F2}");
                        }
                        else
                        {
                            平均成績單.Items.Add($"{name} 的資料格式錯誤，無法計算");
                        }
                    }

                    inputFile.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取檔案時發生錯誤: " + ex.Message);
                }
            }
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
