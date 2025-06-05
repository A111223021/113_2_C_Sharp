using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Program7_5
{
    public struct TeamData
    {
        public string Name;
        public int WinCount;
        public List<int> WinYears;

        public TeamData(string name)
        {
            Name = name;
            WinCount = 0;
            WinYears = new List<int>();
        }
    }

    public partial class Form1 : Form
    {
        List<string> teams = new List<string>();
        List<string> winners = new List<string>();
        List<int> years = new List<int>();
        List<string> originalTeams = new List<string>();
        List<TeamData> teamDataList = new List<TeamData>();

        string originalWinnersPath = "";
        string teamListPath = "";
        string newTeamOutputPath = "MLB_Teams_Translated.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("請先選擇球隊資料檔案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!ReadTeams()) return;

            MessageBox.Show("再選擇世界大賽冠軍資料檔案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!ReadWinners()) return;

            UpdateTeamList();
            BuildTeamDataList();
        }

        private bool ReadTeams()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "請選擇 Teams.txt 檔案";
                dialog.Filter = "文字檔案 (*.txt)|*.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    teamListPath = dialog.FileName;
                    teams.Clear();
                    listBox1.Items.Clear();

                    StreamReader sr = null;
                    try
                    {
                        sr = new StreamReader(dialog.FileName);
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!teams.Contains(line))
                                teams.Add(line);
                        }
                    }
                    finally
                    {
                        if (sr != null)
                            sr.Close();
                    }

                    originalTeams = new List<string>(teams);
                    return true;
                }
                else
                {
                    MessageBox.Show("未選擇檔案，程式即將結束。");
                    this.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取球隊檔案時發生錯誤：" + ex.Message);
                return false;
            }
        }

        private bool ReadWinners()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "請選擇 WorldSeries.txt 檔案";
                dialog.Filter = "文字檔案 (*.txt)|*.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    originalWinnersPath = dialog.FileName;
                    winners.Clear();
                    years.Clear();

                    StreamReader sr = null;
                    try
                    {
                        sr = new StreamReader(dialog.FileName);
                        int year = 1903;
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (year == 1904 || year == 1994) year++;
                            winners.Add(line);
                            years.Add(year);
                            year++;
                        }
                    }
                    finally
                    {
                        if (sr != null)
                            sr.Close();
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("未選擇檔案，程式結束。");
                    this.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取冠軍檔案時發生錯誤：" + ex.Message);
                return false;
            }
        }

        private void BuildTeamDataList()
        {
            teamDataList.Clear();
            foreach (string team in teams)
            {
                TeamData data = new TeamData(team);
                for (int i = 0; i < winners.Count; i++)
                {
                    if (winners[i] == team)
                    {
                        data.WinCount++;
                        data.WinYears.Add(years[i]);
                    }
                }
                teamDataList.Add(data);
            }
        }

        private void UpdateTeamList()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < teams.Count; i++)
            {
                listBox1.Items.Add($"{i + 1}.{teams[i]}隊");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;

            string fullText = listBox1.SelectedItem.ToString();
            int dotIndex = fullText.IndexOf('.');
            string teamName = fullText.Substring(dotIndex + 1).Replace("隊", "");

            TeamData data = teamDataList.FirstOrDefault(t => t.Name == teamName);

            if (data.WinCount > 0)
            {
                data.WinYears.Sort();
                string yearList = string.Join(", ", data.WinYears);

                if (data.WinCount == 1)
                    label1.Text = $"{data.Name}隊於 {data.WinYears[0]} 年獲得 1 次世界冠軍。\n年份：{yearList}";
                else
                    label1.Text = $"{data.Name}隊 從 {data.WinYears.First()} 年至 {data.WinYears.Last()} 年，共贏得 {data.WinCount} 次世界冠軍。\n年份：{yearList}";
            }
            else
            {
                label1.Text = $"{data.Name}隊 尚未贏得世界冠軍。";
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "請選擇 2010 年以後的世界大賽資料";
                dialog.Filter = "文字檔案 (*.txt)|*.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    List<string> newWinners = new List<string>();
                    List<string> newTeams = new List<string>();

                    StreamReader sr = null;
                    try
                    {
                        sr = new StreamReader(dialog.FileName);
                        int startYear = 2010;
                        int maxYear = years.Count > 0 ? years.Max() : 0;
                        if (maxYear >= 2010)
                            startYear = maxYear + 1;

                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            winners.Add(line);
                            years.Add(startYear);
                            newWinners.Add(line);

                            if (!teams.Contains(line))
                                teams.Add(line);

                            if (!originalTeams.Contains(line) && !newTeams.Contains(line))
                                newTeams.Add(line);

                            startYear++;
                        }
                    }
                    finally
                    {
                        if (sr != null)
                            sr.Close();
                    }

                    UpdateTeamList();
                    BuildTeamDataList();

                    if (newTeams.Count > 0)
                    {
                        StreamWriter sw = null;
                        try
                        {
                            sw = new StreamWriter(newTeamOutputPath, true);
                            foreach (string team in newTeams)
                            {
                                sw.WriteLine(team);
                            }
                        }
                        finally
                        {
                            if (sw != null)
                                sw.Close();
                        }

                        originalTeams.AddRange(newTeams);
                    }

                    if (!string.IsNullOrEmpty(originalWinnersPath))
                    {
                        StreamWriter sw = null;
                        try
                        {
                            sw = new StreamWriter(originalWinnersPath, true);
                            foreach (string team in newWinners)
                            {
                                sw.WriteLine(team);
                            }
                        }
                        finally
                        {
                            if (sw != null)
                                sw.Close();
                        }
                    }

                    MessageBox.Show($"新增完成！\n新隊伍數：{newTeams.Count}\n新增冠軍數：{newWinners.Count}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增資料時發生錯誤：" + ex.Message);
            }
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}






