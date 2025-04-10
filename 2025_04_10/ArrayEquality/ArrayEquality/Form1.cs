using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayEquality
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4, 5 };

            //檢查兩個陣列是否相同
            bool arrayEqual = isArrayEqual(array1, array2);

            if (arrayEqual)
            {
                MessageBox.Show("兩個陣列相同");
            }
            else 
            {
                MessageBox.Show("兩個陣列不同");
            }

        }
        private bool isArrayEqual(int[] array1, int[] array2) 
        {
            //檢查長度
            if (array1.Length != array2.Length) 
            { 
                return false; 
            }

            //檢查元素
            for (int i = 0; i < array1.Length; i++) 
            {
                if (array1[i] != array2[i]) 
                {
                    return true;
                }
            }
            return true;
        }
    }
}
