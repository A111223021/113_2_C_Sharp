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
        // �Ψ��x�s CellPhone ���󪺲M��
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData ��k�|�����@�� CellPhone ����@���ѼơA
        // �ñN�ϥΪ̩����J����ƫ������Ӫ����ݩʡC
        // �]�t�~�P�B�����P����A�Y����榡���~�h��ܿ��~�T���C
        private void GetPhoneData(CellPhone phone)
        {
            // �Ȧs������檺�ܼ�
            decimal price;

            // ���o����~�P�A�ë����� CellPhone ���� Brand �ݩ�
            phone.Brand = brandTextBox.Text;

            // ���o��������A�ë����� CellPhone ���� Model �ݩ�
            phone.Model = modelTextBox.Text;

            // ���o�������A�Y��J�榡���T�h������ CellPhone ���� Price �ݩ�
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // �Y�����J�L�ġA��ܿ��~�T�����ܨϥΪ�
                MessageBox.Show("����榡�L�ġA�Э��s��J���T���ƭȡC");
            }
        }

        // ��ϥΪ��I���u�s�W����v���s��Ĳ�o���ƥ�
        // �|�إ߷s�� CellPhone ����A���o����ƫ�[�J�M��P ListBox
        // �òM�ſ�J���A�N�J�I���^�~�P��J��
        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone();

            GetPhoneData(myPhone);

            phoneList.Add(myPhone);

            // �N����~�P�P�����զX��[�J ListBox ���
            phoneListBox.Items.Add(myPhone.Brand + "" + myPhone.Model);

            // �M�ū~�P�B�����P���檺��J���
            brandTextBox.Text = "";
            modelTextBox.Text = "";
            priceTextBox.Text = "";

            // �N��еJ�I���^�~�P��J���A��K�~���J
            brandTextBox.Focus();
        }

        // ��ϥΪ̩� ListBox ������P�����Ĳ�o���ƥ�
        // �|�ھڿ�������ޡA��ܸӤ��������]�H�f���榡�e�{�^
        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex;

            MessageBox.Show(phoneList[index].Price.ToString("C"));
        }

        // ��ϥΪ��I���u���}�v���s��Ĳ�o���ƥ�
        // �|�����ثe�����A�������ε{��
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
