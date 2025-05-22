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

namespace Phonebook
{
    // 定義一個結構來表示電話簿中的一個條目。
    // 每個條目包含兩個欄位：名稱 (name) 和電話號碼 (phone)。
    struct PhoneBookEntry
    {
        public string name;  // 儲存聯絡人的名稱。
        public string phone; // 儲存聯絡人的電話號碼。
    }

    public partial class Form1 : Form
    {
        // 用於儲存 PhoneBookEntry 物件的清單。
        // 這個清單會包含從檔案中讀取的所有聯絡人資訊。
        private List<PhoneBookEntry> phoneList = new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();

            // 設定表單的標題為繁體中文。
            this.Text = "電話簿";

            // 假設有一個按鈕元件 exitButton，將其文字改為繁體中文。
            exitButton.Text = "退出";

            // 假設有一個 ListBox 元件 nameListBox，將其標題改為繁體中文。
            // 如果需要其他元件的 Text 屬性修改，請在此處新增。
        }

        // ReadFile 方法會讀取 PhoneList.txt 檔案的內容。
        // 每一行應包含一個聯絡人的名稱和電話號碼，
        // 並以某種分隔符號（例如逗號）分隔。
        // 方法會將每一行的資料解析為 PhoneBookEntry 物件，
        // 並將這些物件加入到 phoneList 清單中。
        private void ReadFile()
        {
            try
            {
                string[] lines = File.ReadAllLines("PhoneList.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        PhoneBookEntry entry = new PhoneBookEntry
                        {
                            name = parts[0].Trim(),
                            phone = parts[1].Trim()
                        };
                        phoneList.Add(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取檔案時發生錯誤: " + ex.Message);
            }
        }

        // DisplayNames 方法會將 phoneList 清單中的所有聯絡人名稱
        // 顯示在 namesListBox 控制項中。
        // 此方法主要用於更新 UI，讓使用者可以看到所有聯絡人的名稱。
        private void DisplayNames()
        {
            nameListBox.Items.Clear();
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        // Form1_Load 是表單載入時觸發的事件處理方法。
        // 在此方法中，可以初始化表單的狀態，例如讀取檔案並顯示聯絡人名稱。
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile(); //  讀取電話簿資料

            DisplayNames(); // 顯示聯絡人名稱
        }

        // nameListBox_SelectedIndexChanged 是當使用者在 namesListBox 中
        // 選擇不同的項目時觸發的事件處理方法。
        // 可以在此方法中顯示選定聯絡人的詳細資訊，例如電話號碼。
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if (index >= 0 && index < phoneList.Count)
            {
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                phoneLabel.Text = "無資料";
            }
        }


        // exitButton_Click 是當使用者按下 "Exit" 按鈕時觸發的事件處理方法。
        // 此方法會關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束應用程式。
            this.Close();
        }
    }
}
