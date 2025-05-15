using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_List
{
    struct Automobile
    {
        public string make;
        public int year;
        public double mileage;
    }

    public partial class Form1 : Form
    {
        // 建立一個 Automobile 結構的 List，作為儲存所有汽車資料的欄位。
        private List<Automobile> carList = new List<Automobile>();

        public Form1()
        {
            InitializeComponent();
        }

        // GetData 方法會從使用者介面的 TextBox 取得輸入資料，
        // 並將這些資料指派給傳入的 Automobile 結構參數 auto 的各個欄位。
        // 若輸入格式錯誤（如非數字），會顯示錯誤訊息。
        private void GetData(ref Automobile auto)
        {
            try
            {
                // 從 makeTextBox 取得汽車廠牌名稱，指派給 auto.make。
                auto.make = makeTextBox.Text;
                // 從 yearTextBox 取得年份字串，轉換為 int 型別後指派給 auto.year。
                auto.year = int.Parse(yearTextBox.Text);
                // 從 mileageTextBox 取得里程數字串，轉換為 double 型別後指派給 auto.mileage。
                auto.mileage = double.Parse(mileageTextBox.Text);
            }
            catch (Exception ex)
            {
                // 若發生例外（如轉型失敗），顯示錯誤訊息視窗，內容為例外訊息。
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // 建立一個新的 Automobile 結構實例 car，用來儲存單筆汽車資料。
            Automobile car = new Automobile();

            // 呼叫 GetData 方法，將使用者輸入的資料存入 car 結構。
            GetData(ref car);

            // 將 car 結構（包含使用者輸入的汽車資料）加入 carList 清單中。
            carList.Add(car);

            // 清空所有輸入用的 TextBox，方便使用者繼續輸入下一筆資料。
            makeTextBox.Clear();
            yearTextBox.Clear();
            mileageTextBox.Clear();

            // 將游標焦點設回 makeTextBox，提升使用者體驗。
            makeTextBox.Focus();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            // 宣告一個字串變數 output，用來暫存每一筆汽車資料的顯示內容。
            string output;

            // 清除 carListBox 目前所有項目，避免重複顯示。
            carListBox.Items.Clear();

            // 逐一讀取 carList 中的每一個 Automobile 結構 aCar。
            foreach (Automobile aCar in carList)
            {
                // 將 aCar 的年份、廠牌與里程數組合成一行字串，格式為「年份 廠牌 with 里程數 miles.」
                output = aCar.year + " " + aCar.make +
                    " with " + aCar.mileage + " miles.";

                // 將組合好的字串加入 carListBox，顯示在畫面上。
                carListBox.Items.Add(output);
            }
        }

        // carInfoGroupBox_Enter 事件處理函式，目前未實作任何功能。
        // 可用於當使用者進入 carInfoGroupBox 時執行特定動作。
        private void carInfoGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
