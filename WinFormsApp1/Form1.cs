using WinFormsApp1.LotteryReader;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LotteryReader6.Read("C:\\Users\\iesas\\Documents\\宝くじ\\ロト6\\ロト6当せん番号(第1回〜第20回) _ みずほ銀行.html");
        }
    }
}
