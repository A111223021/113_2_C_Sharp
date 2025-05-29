using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 用來儲存 CellPhone 物件的清單
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法會接收一個 CellPhone 物件作為參數，
        // 並將使用者於表單輸入的資料指派給該物件的屬性。
        // 包含品牌、型號與價格，若價格格式錯誤則顯示錯誤訊息。
        private void GetPhoneData(CellPhone phone)
        {
            // 暫存手機價格的變數
            decimal price;

            // 取得手機品牌，並指派給 CellPhone 物件的 Brand 屬性
            phone.Brand = brandTextBox.Text;

            // 取得手機型號，並指派給 CellPhone 物件的 Model 屬性
            phone.Model = modelTextBox.Text;

            // 取得手機價格，若輸入格式正確則指派給 CellPhone 物件的 Price 屬性
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // 若價格輸入無效，顯示錯誤訊息提示使用者
                MessageBox.Show("價格格式無效，請重新輸入正確的數值。");
            }
        }

        // 當使用者點擊「新增手機」按鈕時觸發此事件
        // 會建立新的 CellPhone 物件，取得表單資料後加入清單與 ListBox
        // 並清空輸入欄位，將焦點移回品牌輸入框
        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone();

            GetPhoneData(myPhone);

            phoneList.Add(myPhone);

            // 將手機品牌與型號組合後加入 ListBox 顯示
            phoneListBox.Items.Add(myPhone.Brand + "" + myPhone.Model);

            // 清空品牌、型號與價格的輸入欄位
            brandTextBox.Text = "";
            modelTextBox.Text = "";
            priceTextBox.Text = "";

            // 將游標焦點移回品牌輸入欄位，方便繼續輸入
            brandTextBox.Focus();
        }

        // 當使用者於 ListBox 選取不同手機時觸發此事件
        // 會根據選取的索引，顯示該手機的價格（以貨幣格式呈現）
        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex;

            MessageBox.Show(phoneList[index].Price.ToString("C"));
        }

        // 當使用者點擊「離開」按鈕時觸發此事件
        // 會關閉目前的表單，結束應用程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
