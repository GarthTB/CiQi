using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace 词器
{
    public partial class Formmain : Form
    {
        public Formmain()
        {
            InitializeComponent();
        }

        //两个词库的绝对路径
        private string CiZuLuJing;//词组的绝对路径
        private string DanZiLuJing;//单字的绝对路径

        private void Formmain_Load(object sender, EventArgs e)
        {
            //自动查找词库文件
            //  如果有就在textbox里显示目录，并载入绝对路径
            //  如果没有就报错
            if (File.Exists(@"..\xkjd6.cizu.dict.yaml") && File.Exists(@"..\xkjd6.danzi.dict.yaml"))
            {
                textBoxCiKuMuLu.Text = Directory.GetParent(Environment.CurrentDirectory).FullName;
                CiZuLuJing = textBoxCiKuMuLu.Text + @"\xkjd6.cizu.dict.yaml";
                DanZiLuJing = textBoxCiKuMuLu.Text + @"\xkjd6.danzi.dict.yaml";
            }
            else
            {
                if (MessageBox.Show("未能自动找到词库！\n请将此程序的文件夹放在小狼毫的用户文件夹下!\n且用户文件夹应包含以下两个文件：\nxkjd6.cizu.dict.yaml\nxkjd6.danzi.dict.yaml\n\n点击确定退出程序，点击取消手动选择词库目录。", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    System.Environment.Exit(0);
                }
            }
        }

        private void tabControlmain_Click(object sender, EventArgs e)
        {
            //不载入词库目录就不能离开这个tabpage
            if (textBoxCiKuMuLu.Text == string.Empty && tabControlmain.SelectedTab != tabPageHome)
            {
                MessageBox.Show("请先选择词库目录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControlmain.SelectedTab = tabPageHome;
            }
        }

        private void buttonCiKuMuLu_Click(object sender, EventArgs e)
        {
            //手动选择小狼毫的用户文件夹
            //  如果选对了就在textbox里显示目录，并载入绝对路径
            //  如果选错了就报错
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string CiKuMuLu = folderBrowserDialog.SelectedPath;
                if (File.Exists(CiKuMuLu + @"\xkjd6.cizu.dict.yaml") && File.Exists(CiKuMuLu + @"\xkjd6.danzi.dict.yaml"))
                {
                    textBoxCiKuMuLu.Text = CiKuMuLu;
                    CiZuLuJing = CiKuMuLu + @"\xkjd6.cizu.dict.yaml";
                    DanZiLuJing = CiKuMuLu + @"\xkjd6.danzi.dict.yaml";
                }
                else
                {
                    MessageBox.Show("目录下找不到需要的词库文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBeiFenMuLu_Click(object sender, EventArgs e)
        {
            //选择备份目录
            //  如果选到了就在textbox里显示
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxBeiFenMuLu.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //弹出帮助
        }

        private void linkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //弹出关于
        }

        private void checkBoxBuYaoBeiFen_CheckedChanged(object sender, EventArgs e)
        {
            //如果被勾选上就禁用两个按钮、备份框和检查器
            //如果取消勾选就恢复两个按钮、备份框和检查器
            if (checkBoxBuYaoBeiFen.Checked)
            {
                buttonBeiFenMuLu.Enabled = false;
                buttonBeiFen.Enabled = false;
                textBoxBeiFenMuLu.Enabled = false;
                textBoxBeiFenMuLu.BackColor = SystemColors.Control;
                labelCheckBeiFen.Enabled = false;
            }
            else
            {
                buttonBeiFenMuLu.Enabled = true;
                buttonBeiFen.Enabled = true;
                textBoxBeiFenMuLu.Enabled = true;
                textBoxBeiFenMuLu.BackColor = SystemColors.Window;
                labelCheckBeiFen.Enabled = true;
            }
        }

        private void buttonBeiFen_Click(object sender, EventArgs e)
        {
            //执行备份
        }

        private void buttonGengXin_Click(object sender, EventArgs e)
        {
            //如果勾选了不要备份，就直接更新
            //如果需要备份，已经备份，就直接更新
            //如果需要备份，没有备份，就弹框确认
        }

        //三个用于检查的函数
        private List<string> GetQuanMa(string Ci)//获取词组的所有全码，无重复（输入参数已排除所有错误）
        {
            List<string> BianMa = new();//词组的所有可能编码
            List<string> Ma1 = new();//第一个字的所有编码（前三码）
            List<string> Ma2 = new();//第二个字的所有编码（前三码）
            List<string> Ma3 = new();//第三个字的所有编码（前三码）
            List<string> Ma4 = new();//最后一字的所有编码（前三码）
            StreamReader DanZiStream = new(DanZiLuJing, Encoding.Default);
            string? Zi_Ma;//ReadLine中的每一行
            if (Ci.Length == 2)
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma[..1] == Ci[..1] && !Ma1.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma1.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma[..1] == Ci.Substring(1, 1) && !Ma2.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma2.Add(Zi_Ma.Substring(2, 3));
                    }
                }
                for(int n1 = 0; n1 < Ma1.Count; n1++)
                {
                    for (int n2 = 0; n2 < Ma2.Count; n2++)
                    {
                        if (!BianMa.Contains(Ma1[n1][..2] + Ma2[n2][..2]+ Ma1[n1][1..] + Ma2[n2][1..]))
                        {
                            BianMa.Add(Ma1[n1][..2] + Ma2[n2][..2] + Ma1[n1][1..] + Ma2[n2][1..]);
                        }
                    }
                }
            }
            else if (Ci.Length == 3)
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma[..1] == Ci[..1] && !Ma1.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma1.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma[..1] == Ci.Substring(1, 1) && !Ma2.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma2.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma[..1] == Ci.Substring(2, 1) && !Ma3.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma3.Add(Zi_Ma.Substring(2, 3));
                    }
                }
                for (int n1 = 0; n1 < Ma1.Count; n1++)
                {
                    for (int n2 = 0; n2 < Ma2.Count; n2++)
                    {
                        for (int n3 = 0; n3 < Ma3.Count; n3++)
                        {
                            if (!BianMa.Contains(Ma1[n1][..1] + Ma2[n2][..1] + Ma3[n1][..1] + Ma1[n1][1..] + Ma2[n2][1..] + Ma3[n1][1..]))
                            {
                                BianMa.Add(Ma1[n1][..1] + Ma2[n2][..1] + Ma3[n1][..1] + Ma1[n1][1..] + Ma2[n2][1..] + Ma3[n1][1..]);
                            }
                        }
                    }
                }
            }
            else
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma[..1] == Ci[..1] && !Ma1.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma1.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma[..1] == Ci.Substring(1, 1) && !Ma2.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma2.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma[..1] == Ci.Substring(2, 1) && !Ma3.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma3.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma[..1] == Ci[1..] && !Ma4.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma4.Add(Zi_Ma.Substring(2, 3));
                    }
                }
                for (int n1 = 0; n1 < Ma1.Count; n1++)
                {
                    for (int n2 = 0; n2 < Ma2.Count; n2++)
                    {
                        for (int n3 = 0; n3 < Ma3.Count; n3++)
                        {
                            for (int n4 = 0; n4 < Ma4.Count; n4++)
                            {
                                if (!BianMa.Contains(Ma1[n1][..1] + Ma2[n2][..1] + Ma3[n1][..1] + Ma4[n1][..1] + Ma1[n2][1..] + Ma2[n1][1..]))
                                {
                                    BianMa.Add(Ma1[n1][..1] + Ma2[n2][..1] + Ma3[n1][..1] + Ma4[n1][..1] + Ma1[n2][1..] + Ma2[n1][1..]);
                                }
                            }
                        }
                    }
                }
            }
            return BianMa;
        }

        private bool CiMaMatch(string Ci, string Ma)//检查词和码是否匹配
        {
            foreach (string BianMa in GetQuanMa(Ci))
            {
                if (BianMa.StartsWith(Ma))
                {
                    return true;
                }
            }
            return false;
        }

        private bool AllInDanZi(string Ci)//检查用于编码的字是否全在单字中（输入参数必须大于1码）
        {
            int n = 0;//符合条件的字数
            StreamReader DanZiStream = new(DanZiLuJing, Encoding.Default);
            string? Zi_Ma;//ReadLine中的每一行
            if (Ci.Length == 2)
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma[..1] == Ci[..1]) { n++; }
                    if (Zi_Ma[..1] == Ci.Substring(1,1)) { n++; }
                    if (n == 2) return true;
                }
            }
            else if(Ci.Length == 3)
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma[..1] == Ci[..1]) { n++; }
                    if (Zi_Ma[..1] == Ci.Substring(1, 1)) { n++; }
                    if (Zi_Ma[..1] == Ci.Substring(2, 1)) { n++; }
                    if (n == 3) return true;
                }
            }
            else
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma[..1] == Ci[..1]) { n++; }
                    if (Zi_Ma[..1] == Ci.Substring(1, 1)) { n++; }
                    if (Zi_Ma[..1] == Ci.Substring(2, 1)) { n++; }
                    if (Zi_Ma[..1] == Ci[1..]) { n++; }
                    if (n == 4) return true;
                }
            }
            return false;
        }
    }
}