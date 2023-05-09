namespace 词器
{
    public partial class Formmain : Form
    {
        public Formmain()
        {
            InitializeComponent();
        }

        private void Formmain_Load(object sender, EventArgs e)
        {
            //自动检查并找到词库文件
            if (!File.Exists(@"..\xkjd6.chaojizici.dict.yaml") || !File.Exists(@"..\xkjd6.cizu.dict.yaml") || !File.Exists(@"..\xkjd6.danzi.dict.yaml"))
            {
                if (MessageBox.Show("未能自动找到词库！\n请将此程序的文件夹放在小狼毫的用户文件夹下!\n且用户文件夹应包含以下三个文件：\nxkjd6.cizu.dict.yaml\nxkjd6.danzi.dict.yaml\nxkjd6.chaojizici.dict.yaml\n\n点击确定退出程序，点击取消手动选择词库目录。", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    System.Environment.Exit(0);
                }
            }
            else
            {
                textBoxCiKuMuLu.Text = Directory.GetParent(Environment.CurrentDirectory).FullName;
            }
        }

        private void tabControlmain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //还没选择词库路径就想离开这个tabpage，想得美
            if (textBoxCiKuMuLu.Text == string.Empty)
            {
                MessageBox.Show("请先选择词库目录", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControlmain.SelectedTab = tabPageHome;
            }
        }
    }
}