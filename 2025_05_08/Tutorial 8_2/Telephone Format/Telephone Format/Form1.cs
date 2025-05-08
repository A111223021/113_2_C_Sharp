using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法用於檢查輸入的字串是否為有效的電話號碼。
        // 它會檢查字串是否包含 10 個數字，並返回布林值：
        // 如果是有效的電話號碼，則
        private bool IsValidNumber(string str)
        {
            
        }

        // TelephoneFormat 方法用於將傳入的字串格式化為電話號碼格式。
        // 它會將字串轉換為以下格式：(XXX) XXX-XXXX。
        // 此方法使用了字串的 Insert 方法來插入
        private void TelephoneFormat(ref string str)
        {
            //if (str.Length == 10) 
            //{
            //  str = $"{str.Substring(0, 2)}-{str.Substring(2, 4)}-{str.Substring(6, 4)}";
            //}
            str = str.Insert(0, "(");
            str = str.Insert(3, ")");
            str = str.Insert(9, "-");
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text; //取得使用者輸入字串

            if (IsValidNumber(input)) //檢查是否為有效的10位數字
            {
                MessageBox.Show("請輸入有效的電話號碼", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
              TelephoneFormat(ref input);
                MessageBox.Show(input, "格式化結果", MessageBoxButtons.OK, MessageBoxInformation);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉視窗
            this.Close();
        }

        private bool IsValidNumber(string str) 
        {
            const int VALID_LENGTH = 10;

            if (str.Length == VALID_LENGTH) 
            {
                for (int i = 0; i < str.Length; i++) 
                {
                    if (!char.IsDigit(ToolStripPanel[i])) 
                    {
                      return false;
                    }
                }
                return true;
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
