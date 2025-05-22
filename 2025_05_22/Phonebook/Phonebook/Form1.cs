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
        // 這個清單會包含從檔案中讀取的所有聯絡人資訊，
        // 並在程式執行期間作為資料來源。
        private List<PhoneBookEntry> phoneList = new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();

            // 設定表單的標題為繁體中文，讓使用者一目了然本程式的用途。
            this.Text = "電話簿";

            // 設定退出按鈕的顯示文字為繁體中文，提升本地化體驗。
            exitButton.Text = "退出";

            // 如有其他元件需設定 Text 屬性，請於此處補充。
        }

        // ReadFile 方法會讀取 PhoneList.txt 檔案的內容。
        // 每一行應包含一個聯絡人的名稱和電話號碼，並以逗號分隔。
        // 方法會將每一行的資料解析為 PhoneBookEntry 物件，並加入 phoneList 清單。
        // 若檔案不存在或格式錯誤，會顯示錯誤訊息。
        private void ReadFile()
        {
            try
            {
                // 讀取所有行到字串陣列，每一行代表一筆聯絡人資料
                string[] lines = File.ReadAllLines("PhoneList.txt");
                foreach (string line in lines)
                {
                    // 以逗號分割每一行，取得姓名與電話號碼
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        // 建立一個新的 PhoneBookEntry 並加入清單
                        PhoneBookEntry entry = new PhoneBookEntry
                        {
                            name = parts[0].Trim(),  // 去除前後空白
                            phone = parts[1].Trim()
                        };
                        phoneList.Add(entry);
                    }
                    // 若格式不正確則略過該行
                }
            }
            catch (Exception ex)
            {
                // 若讀取檔案時發生錯誤（如檔案不存在或權限不足），顯示錯誤訊息
                MessageBox.Show("讀取檔案時發生錯誤: " + ex.Message);
            }
        }

        // DisplayNames 方法會將 phoneList 清單中的所有聯絡人名稱
        // 顯示在 namesListBox 控制項中。
        // 此方法主要用於更新 UI，讓使用者可以看到所有聯絡人的名稱。
        private void DisplayNames()
        {
            // 先清空 ListBox，避免重複顯示
            nameListBox.Items.Clear();
            // 將每個聯絡人的名稱加入 ListBox
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        // Form1_Load 是表單載入時觸發的事件處理方法。
        // 在此方法中，會先讀取檔案資料，再顯示聯絡人名稱。
        // 這樣使用者一打開程式就能看到現有的聯絡人清單。
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile(); //  讀取電話簿資料
            DisplayNames(); // 顯示聯絡人名稱
        }

        // nameListBox_SelectedIndexChanged 是當使用者在 namesListBox 中
        // 選擇不同的項目時觸發的事件處理方法。
        // 會根據選取的索引顯示對應聯絡人的電話號碼於 phoneLabel。
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            // 檢查索引是否有效，避免陣列越界
            if (index >= 0 && index < phoneList.Count)
            {
                // 顯示選定聯絡人的電話號碼
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                // 若無有效資料則顯示"無資料"
                phoneLabel.Text = "無資料";
            }
        }

        // exitButton_Click 是當使用者按下 "退出" 按鈕時觸發的事件處理方法。
        // 此方法會先儲存資料再關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            SaveFile();  // 離開前儲存所有聯絡人資料到檔案
            this.Close(); // 關閉表單
        }

        // button1_Click 是當使用者按下新增聯絡人按鈕時觸發的事件處理方法。
        // 會將使用者輸入的姓名與電話號碼新增到電話簿清單與畫面上。
        // 並進行輸入驗證與重複檢查。
        private void button1_Click(object sender, EventArgs e)
        {
            PhoneBookEntry entry;
            // 取得使用者輸入的姓名與電話號碼，並去除前後空白
            entry.name = textBox1.Text.Trim();
            entry.phone = textBox2.Text.Trim();

            // 檢查姓名或電話號碼是否為空，若為空則提示錯誤並中止新增
            if (string.IsNullOrEmpty(entry.name) || string.IsNullOrEmpty(entry.phone))
            {
                MessageBox.Show("姓名或電話號碼不能為空!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 檢查是否已有相同姓名，避免重複新增
            if (phoneList.Any(x => x.name == entry.name))
            {
                MessageBox.Show("此姓名已存在，請使用其他姓名!", "重複", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 將新聯絡人加入清單與畫面
            phoneList.Add(entry);                // 加入到資料清單
            nameListBox.Items.Add(entry.name);   // 加入到 ListBox 顯示
            textBox1.Clear(); // 清空姓名輸入框，方便繼續輸入
            textBox2.Clear(); // 清空電話輸入框

            // 新增成功後給予使用者提示
            MessageBox.Show("新增成功!", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // SaveFile 方法會將目前 phoneList 清單中的所有聯絡人資料
        // 以逗號分隔的格式寫入 PhoneList.txt 檔案中。
        // 若儲存過程發生錯誤，會顯示錯誤訊息。
        private void SaveFile()
        {
            try
            {
                // 使用 StreamWriter 逐筆寫入每個聯絡人的資料
                StreamWriter writer = null;
                try
                {
                    writer = File.CreateText("PhoneList.txt");
                    foreach (PhoneBookEntry entry in phoneList)
                    {
                        writer.WriteLine($"{entry.name},{entry.phone}");
                    }
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // 若儲存檔案時發生錯誤，顯示錯誤訊息
                MessageBox.Show("儲存檔案時發生錯誤: " + ex.Message);
            }
        }

        // button2_Click_1 是當使用者按下刪除聯絡人按鈕時觸發的事件處理方法。
        // 會先確認使用者是否真的要刪除，若確認則從清單與畫面移除該聯絡人，
        // 並儲存變更到檔案。
        private void button2_Click_1(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;

            // 檢查是否有選擇聯絡人
            if (index >= 0 && index < phoneList.Count)
            {
                // 顯示確認刪除對話框，避免誤刪
                var result = MessageBox.Show(
                    $"確定要刪除「{phoneList[index].name}」嗎？",
                    "確認刪除",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // 從 List 中刪除資料
                    phoneList.RemoveAt(index);
                    // 從畫面刪除
                    nameListBox.Items.RemoveAt(index);
                    phoneLabel.Text = ""; // 清空右側顯示
                    SaveFile(); // 儲存變更

                    // 刪除成功提示
                    MessageBox.Show("刪除成功!", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // 若未選擇聯絡人，提示使用者先選擇
                MessageBox.Show("請先選擇要刪除的聯絡人!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
