using System.IO;
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

        //主页的操作
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
            //仅支持由DanZi中的字组成的词组
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

        //五个用于检查的函数
        private List<string> GetQuanMa(string Ci)//获取词组的所有全码，无重复（输入参数已排除所有错误）
        {
            List<string> BianMa = new();//词组的所有可能编码
            List<string> Ma1 = new();//第一个字的所有编码（前三码）
            List<string> Ma2 = new();//第二个字的所有编码（前三码）
            List<string> Ma3 = new();//第三个字的所有编码（前三码）
            List<string> Ma4 = new();//最后一字的所有编码（前三码）
            using StreamReader DanZiStream = new(DanZiLuJing, Encoding.Default);
            string? Zi_Ma = null;//单字流中的每一行
            if (Ci.Length == 2)
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma.Length > 4 && Zi_Ma[..1] == Ci[..1] && !Ma1.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma1.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma.Length > 4 && Zi_Ma[..1] == Ci.Substring(1, 1) && !Ma2.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma2.Add(Zi_Ma.Substring(2, 3));
                    }
                }
                for (int n1 = 0; n1 < Ma1.Count; n1++)
                {
                    for (int n2 = 0; n2 < Ma2.Count; n2++)
                    {
                        if (!BianMa.Contains(Ma1[n1][..2] + Ma2[n2][..2] + Ma1[n1].Substring(2, 1) + Ma2[n2].Substring(2, 1)))
                        {
                            BianMa.Add(Ma1[n1][..2] + Ma2[n2][..2] + Ma1[n1].Substring(2, 1) + Ma2[n2].Substring(2, 1));
                        }
                    }
                }
            }
            else if (Ci.Length == 3)
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma.Length > 4 && Zi_Ma[..1] == Ci[..1] && !Ma1.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma1.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma.Length > 4 && Zi_Ma[..1] == Ci.Substring(1, 1) && !Ma2.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma2.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma.Length > 4 && Zi_Ma[..1] == Ci.Substring(2, 1) && !Ma3.Contains(Zi_Ma.Substring(2, 3)))
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
                            if (!BianMa.Contains(Ma1[n1][..1] + Ma2[n2][..1] + Ma3[n3][..1] + Ma1[n1].Substring(2, 1) + Ma2[n2].Substring(2, 1) + Ma3[n3].Substring(2, 1)))
                            {
                                BianMa.Add(Ma1[n1][..1] + Ma2[n2][..1] + Ma3[n3][..1] + Ma1[n1].Substring(2, 1) + Ma2[n2].Substring(2, 1) + Ma3[n3].Substring(2, 1));
                            }
                        }
                    }
                }
            }
            else
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma.Length > 4 && Zi_Ma[..1] == Ci[..1] && !Ma1.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma1.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma.Length > 4 && Zi_Ma[..1] == Ci.Substring(1, 1) && !Ma2.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma2.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma.Length > 4 && Zi_Ma[..1] == Ci.Substring(2, 1) && !Ma3.Contains(Zi_Ma.Substring(2, 3)))
                    {
                        Ma3.Add(Zi_Ma.Substring(2, 3));
                    }
                    if (Zi_Ma.Length > 4 && Zi_Ma[..1] == Ci[^1..] && !Ma4.Contains(Zi_Ma.Substring(2, 3)))
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
                                if (!BianMa.Contains(Ma1[n1][..1] + Ma2[n2][..1] + Ma3[n3][..1] + Ma4[n4][..1] + Ma1[n1].Substring(2, 1) + Ma2[n2].Substring(2, 1)))
                                {
                                    BianMa.Add(Ma1[n1][..1] + Ma2[n2][..1] + Ma3[n3][..1] + Ma4[n4][..1] + Ma1[n1].Substring(2, 1) + Ma2[n2].Substring(2, 1));
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

        private bool AllInDanZi(string Ci)//检查编码用字是否全在DanZi中（输入参数必须大于1码）
        {
            bool n1 = false, n2 = false, n3 = false, n4 = false;//在DanZi中就计真
            using StreamReader DanZiStream = new(DanZiLuJing, Encoding.Default);
            string? Zi_Ma = null;//单字流中的每一行
            if (Ci.Length == 2)
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma[..1] == Ci[..1]) { n1 = true; }
                    if (Zi_Ma[..1] == Ci.Substring(1, 1)) { n2 = true; }
                    if (n1 && n2) { return true; }
                }
            }
            else if (Ci.Length == 3)
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma[..1] == Ci[..1]) { n1 = true; }
                    if (Zi_Ma[..1] == Ci.Substring(1, 1)) { n2 = true; }
                    if (Zi_Ma[..1] == Ci.Substring(2, 1)) { n3 = true; }
                    if (n1 && n2 && n3) { return true; }
                }
            }
            else
            {
                while ((Zi_Ma = DanZiStream.ReadLine()) != null)
                {
                    if (Zi_Ma[..1] == Ci[..1]) { n1 = true; }
                    if (Zi_Ma[..1] == Ci.Substring(1, 1)) { n2 = true; }
                    if (Zi_Ma[..1] == Ci.Substring(2, 1)) { n3 = true; }
                    if (Zi_Ma[..1] == Ci[^1..]) { n4 = true; }
                    if (n1 && n2 && n3 && n4) { return true; }
                }
            }
            return false;
        }

        private bool YiYouTiaoMu(string Ci, string Ma)//检查该条目是否已在CiZu中
        {
            using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            string? Ci_Ma = null;//词组流中的每一行
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)
            {
                if (Ci_Ma == Ci + "\t" + Ma)
                {
                    return true;
                }
            }
            return false;
        }

        private bool YiYouCi(string Ci)//检查该词是否已在CiZu中
        {
            using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            string? Ci_Ma = null;//词组流中的每一行
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)
            {
                if (Ci_Ma.StartsWith(Ci + "\t"))
                {
                    return true;
                }
            }
            return false;
        }

        private bool YiYouMa(string Ma)//检查该码是否已在CiZu中
        {
            using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            string? Ci_Ma = null;//词组流中的每一行
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)
            {
                if (Ci_Ma.EndsWith("\t" + Ma))
                {
                    return true;
                }
            }
            return false;
        }

        private bool GengDuanKongMa(string Ma)//检查是否有更短空码
        {
            using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            string? Ci_Ma = null;//词组流中的每一行
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)
            {
                if (Ci_Ma.EndsWith("\t" + Ma[..^1]))
                {
                    return false;
                }
            }
            return true;
        }

        //加词页的操作
        private List<string> QuanMa = new();//添加词的所有全码

        private void JianChaTianJia()
        {
            //清空检查器
            //已有条目报错
            //  多码可选提示，已有词提示，码位被占提示，有更短空码提示
            //  没有提示就显示勾勾没问题
            labelCheckTianJia.Text = string.Empty;
            if (YiYouTiaoMu(textBoxTianJiaCi.Text, comboBoxTianJiaMa.Text))
            {
                labelCheckTianJia.ForeColor = Color.Red;
                labelCheckTianJia.Text = "×已有词";
            }
            else
            {
                labelCheckTianJia.ForeColor = Color.Blue;
                labelCheckTianJia.Text = "!";
                if (comboBoxTianJiaMa.Items.Count > 1)
                {
                    labelCheckTianJia.Text += " 多";
                }
                if (YiYouCi(textBoxTianJiaCi.Text))
                {
                    labelCheckTianJia.Text += " 已";
                }
                if (YiYouMa(comboBoxTianJiaMa.Text))
                {
                    labelCheckTianJia.Text += " 占";
                }
                if (comboBoxTianJiaMa.Text.Length > 3 && GengDuanKongMa(comboBoxTianJiaMa.Text))
                {
                    labelCheckTianJia.Text += " 短";
                }
                if (labelCheckTianJia.Text == "!")
                {
                    labelCheckTianJia.ForeColor = Color.Green;
                    labelCheckTianJia.Text = "√没问题";
                }
            }
        }

        private void textBoxTianJiaCi_TextChanged(object sender, EventArgs e)
        {
            //清空全码list和combobox里的码
            //  如果textbox为空就关掉检查
            //  如果输入了非中文，或码长小于2就报错
            //  如果编码用字不在DanZi中就报错
            //    获取词的编码，根据指定码长切割，放进combobox
            //    开启检查器，以便combobox执行检查
            QuanMa.Clear();
            comboBoxTianJiaMa.Text = string.Empty;
            comboBoxTianJiaMa.Items.Clear();
            if (textBoxTianJiaCi.Text == string.Empty)
            {
                labelCheckTianJia.Visible = false;
            }
            else if (Regex.IsMatch(textBoxTianJiaCi.Text, "[^\u4e00-\u9fa5]") || textBoxTianJiaCi.Text.Length < 2)
            {
                labelCheckTianJia.Visible = true;
                labelCheckTianJia.ForeColor = Color.Red;
                labelCheckTianJia.Text = "×无效词";
            }
            else if (!AllInDanZi(textBoxTianJiaCi.Text))
            {
                labelCheckTianJia.Visible = true;
                labelCheckTianJia.ForeColor = Color.Red;
                labelCheckTianJia.Text = "×无效词";
            }
            else
            {
                QuanMa = GetQuanMa(textBoxTianJiaCi.Text);
                foreach (string quanma in QuanMa)
                {
                    if (!comboBoxTianJiaMa.Items.Contains(quanma[..(int)numericUpDownTianJiaMaChang.Value]))
                    {
                        comboBoxTianJiaMa.Items.Add(quanma[..(int)numericUpDownTianJiaMaChang.Value]);
                    }
                }
                comboBoxTianJiaMa.SelectedIndex = 0;
                labelCheckTianJia.Visible = true;
            }
        }

        private void comboBoxTianJiaMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果全码list非空就执行检查
            if (QuanMa.Any()) { JianChaTianJia(); }
        }

        private void numericUpDownTianJiaMaChang_ValueChanged(object sender, EventArgs e)
        {
            //如果全码list非空
            //  清空combobox里的码
            //  重新根据指定码长切割全码，放进combobox
            if (QuanMa.Any())
            {
                comboBoxTianJiaMa.Text = string.Empty;
                comboBoxTianJiaMa.Items.Clear();
                foreach (string quanma in QuanMa)
                {
                    if (!comboBoxTianJiaMa.Items.Contains(quanma[..(int)numericUpDownTianJiaMaChang.Value]))
                    {
                        comboBoxTianJiaMa.Items.Add(quanma[..(int)numericUpDownTianJiaMaChang.Value]);
                    }
                }
                comboBoxTianJiaMa.SelectedIndex = 0;
            }
        }

        private void TianJia()
        {
            //将词组加入CiZu并写日志
            using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            using StreamWriter NewCiZuStream = new(textBoxCiKuMuLu.Text + @"\xkjd6.cizu.dict(new).yaml");
            string? Ci_Ma = null;//词组流中的每一行
            string[] TempArray = new string[2];//用来给条目排序的缓存数组
            string[] SortedTempArray = new string[2];//排序后的缓存数组
            TempArray[1] = comboBoxTianJiaMa.Text;//将要加的码作为数组的第二个元素
            for (int i = 0; i < 5; i++)//先把文件头写了
            {
                NewCiZuStream.WriteLine(CiZuStream.ReadLine());
            }
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)
            {
                TempArray[0] = Ci_Ma.Split("\t")[1];//取出这一行的码作为数组的第一个元素
                SortedTempArray = TempArray;
                Array.Sort(SortedTempArray);
                if (TempArray[0] == SortedTempArray[0])
                {
                    NewCiZuStream.WriteLine(Ci_Ma);
                }
                else
                {
                    NewCiZuStream.WriteLine(textBoxTianJiaCi.Text + "\t" + comboBoxTianJiaMa.Text);
                    NewCiZuStream.WriteLine(Ci_Ma);
                }
            }
            richTextBoxLog.Text += textBoxTianJiaCi.Text + "\t" + comboBoxTianJiaMa.Text + "\t添加\t" + labelCheckTianJia.Text + "\r\n";
        }

        private void buttonTianJia_Click(object sender, EventArgs e)
        {
            //检查没问题就添加
            //检查有提示就弹框确认
            //其他情况就不添加并弹框提示
            if (labelCheckTianJia.Visible && labelCheckTianJia.ForeColor == Color.Green)
            {
                TianJia();
            }
            else if (labelCheckTianJia.Visible && labelCheckTianJia.ForeColor == Color.Blue)
            {
                if(MessageBox.Show("确定添加吗？", "误码提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    TianJia();
                }
            }
            else
            {
                MessageBox.Show("未添加。请检查输入的词和码。", "误码提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}