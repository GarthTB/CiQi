using System.Text;
using System.Text.RegularExpressions;

namespace 词器
{
    public partial class Formmain : Form
    {
        public Formmain()
        {
            InitializeComponent();
        }

        //词库和备份的绝对路径
        private string CiZuLuJing;//词组文件的绝对路径
        private string DanZiLuJing;//单字文件的绝对路径
        private string BeiFenLuJing;//备份词库的绝对路径

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
                if (MessageBox.Show("未能自动找到词库！\r\n请将此程序的文件夹放在小狼毫的用户文件夹下!\r\n且用户文件夹应包含以下两个文件：\r\nxkjd6.cizu.dict.yaml\r\nxkjd6.danzi.dict.yaml\r\n\r\n点击确定退出程序，点击取消手动选择词库目录。", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    System.Environment.Exit(0);
                }
            }
        }

        //主页的操作
        private void tabControlmain_Click(object sender, EventArgs e)
        {
            //不载入词库目录就不能离开这个tabpage
            //没有选择不要备份且没有备份就不能离开这个tabpage
            if (textBoxCiKuMuLu.Text == string.Empty && tabControlmain.SelectedTab != tabPageHome)
            {
                MessageBox.Show("请先选择词库目录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControlmain.SelectedTab = tabPageHome;
            }
            else if (!checkBoxBuYaoBeiFen.Checked && labelCheckBeiFen.ForeColor == Color.Red && tabControlmain.SelectedTab != tabPageHome)
            {
                MessageBox.Show("请先备份，再进行维护。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //  如果选到了就在textbox里显示，并载入绝对路径
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxBeiFenMuLu.Text = folderBrowserDialog.SelectedPath;
                BeiFenLuJing = textBoxBeiFenMuLu.Text + @"\xkjd6.cizu.dict(backup).yaml";
            }
        }

        private void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //弹出帮助
            MessageBox.Show("此工具可进行以下操作：\r\n\r\n添加：在词库中添加一行。\r\n删除：在词库中删除一行。\r\n改词：将词库里某行的词换成另一个词。\r\n改码：将词库里某行的码换成另一个码。\r\n调频：将长码的词移到短码上，短码的词移到最短的空码上。\r\n\r\n注意：\r\n\r\n1. 本工具支持将非3字词放在3码，但不推荐这么做。\r\n2. 仅支持由DanZi中的字组成的词组，用其他字可能出错。", "帮助", MessageBoxButtons.OK);
        }

        private void linkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //自动复制链接
            //弹出关于
            Clipboard.SetDataObject("https://github.com/GarthTB/CiQi");
            MessageBox.Show("词器v0.1\r\n一个用于维护星空键道6输入法Rime版的词库的小工具。\r\n源码链接已复制到剪贴板。", "词器", MessageBoxButtons.OK);
        }

        private void checkBoxBuYaoBeiFen_CheckedChanged(object sender, EventArgs e)
        {
            //如果被勾选上就提示风险
            //  无视风险就禁用两个按钮、备份框和检查器
            //如果取消勾选就恢复两个按钮、备份框和检查器
            if (checkBoxBuYaoBeiFen.Checked)
            {
                if (MessageBox.Show("词库的维护操作会直接编辑原词库文件。确定不备份吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    buttonBeiFenMuLu.Enabled = false;
                    buttonBeiFen.Enabled = false;
                    textBoxBeiFenMuLu.Enabled = false;
                    textBoxBeiFenMuLu.BackColor = SystemColors.Control;
                    labelCheckBeiFen.Enabled = false;
                }
                else { checkBoxBuYaoBeiFen.Checked = false; }
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
            //如果路径不为空就执行备份并更新检查器，且禁用备份按钮以防止重复备份
            //否则提示选择路径
            if (BeiFenLuJing != null)
            {
                using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
                using StreamWriter BeiFenStream = new(BeiFenLuJing);
                string? Ci_Ma = null;//词组流中的每一行
                while ((Ci_Ma = CiZuStream.ReadLine()) != null)
                {
                    BeiFenStream.WriteLine(Ci_Ma);
                }
                labelCheckBeiFen.ForeColor = Color.Green;
                labelCheckBeiFen.Text = "√已备份";
                buttonBeiFen.Enabled = false;
            }
            else
            {
                MessageBox.Show("请先选择备份目录。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //九个用于检查的函数
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
            for (int n = 0; n < 5; n++)//跳过文件头
            {
                CiZuStream.ReadLine();
            }
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
            for (int n = 0; n < 5; n++)//跳过文件头
            {
                CiZuStream.ReadLine();
            }
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
            for (int n = 0; n < 5; n++)//跳过文件头
            {
                CiZuStream.ReadLine();
            }
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
            for (int n = 0; n < 5; n++)//跳过文件头
            {
                CiZuStream.ReadLine();
            }
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

        private bool XuYaoBuWei(string Ma)//判断删除该码后是否需要补位
        {
            using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            for (int n = 0; n < 5; n++)//跳过文件头
            {
                CiZuStream.ReadLine();
            }
            string? Ci_Ma = null;//词组流中的每一行
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)
            {
                if (Ma.Length < Ci_Ma.Split("\t")[1].Length && Ci_Ma.Split("\t")[1].StartsWith(Ma))
                {
                    return true;
                }
            }
            return false;
        }

        private bool XinMaZaiQian(string XinMa, string JiuMa)//输入新码和旧码，判断新码是否应该排在前
        {
            //如果新码与旧码相同，旧码在前
            //如果新码比旧码长且以旧码开头，旧码在前
            //如果旧码比新码长且以新码开头，新码在前
            //其他情况逐个比较字符的ascii码
            if (XinMa == JiuMa) { return false; }
            else if (XinMa.Length > JiuMa.Length && XinMa.StartsWith(JiuMa)) { return false; }
            else if (JiuMa.Length > XinMa.Length && JiuMa.StartsWith(XinMa)) { return true; }
            else
            {
                for (int n = 0; n < XinMa.Length && n < JiuMa.Length; n++)
                {
                    if (XinMa[n] < JiuMa[n]) { return true; }
                    else if (XinMa[n] > JiuMa[n]) { return false; }
                }
                return true;//实际用不到的，只是用来让IDE不要再报错了的语句。
            }
        }

        //添加页的操作
        private List<string> QuanMa = new();//添加词的所有全码

        private void textBoxTianJiaCi_TextChanged(object sender, EventArgs e)
        {
            //清空全码list和combobox里的码
            //  如果少于2个字就关掉检查
            //  如果输入了非中文就报错
            //  如果编码用字不在DanZi中就报错
            //    获取词的所有编码，根据指定码长切割，放进combobox
            //    开启检查器，以便combobox执行检查
            QuanMa.Clear();
            comboBoxTianJiaMa.Text = string.Empty;
            comboBoxTianJiaMa.Items.Clear();
            if (textBoxTianJiaCi.Text.Length < 2)
            {
                labelCheckTianJia.Visible = false;
            }
            else if (Regex.IsMatch(textBoxTianJiaCi.Text, "[^\u4e00-\u9fa5]"))
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
            //  已有条目报错
            //    多码可选提示，已有词提示，码位被占提示，有更短空码提示
            //    没有提示就显示勾勾没问题
            if (QuanMa.Any())
            {
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
            List<string> Ci_Malist = new();//用于分装词库的每一行
            StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            string? Ci_Ma = null;//词组流中的每一行
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)//将词库装进list
            {
                Ci_Malist.Add(Ci_Ma);
            }
            CiZuStream.Dispose();//载入完成
            for (int n = 5; n < Ci_Malist.Count; n++)//从第六行开始比较
            {
                if (XinMaZaiQian(comboBoxTianJiaMa.Text, Ci_Malist[n].Split("\t")[1]))
                {
                    Ci_Malist.Insert(n, textBoxTianJiaCi.Text + "\t" + comboBoxTianJiaMa.Text);
                    break;
                }
            }
            File.Delete(CiZuLuJing);
            StreamWriter NewCiZuStream = new(CiZuLuJing);
            for (int n = 0; n < Ci_Malist.Count; n++)//将list写入新词库文件
            {
                NewCiZuStream.WriteLine(Ci_Malist[n]);
            }
            NewCiZuStream.Dispose();//写入完成
            richTextBoxLog.Text += textBoxTianJiaCi.Text + "\t" + comboBoxTianJiaMa.Text + "\t添加\t" + labelCheckTianJia.Text + "\r\n";
            labelCheckTianJia.ForeColor = Color.Red;//防止再次加入同一词
            labelCheckTianJia.Text = "×已有词";
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
                if (MessageBox.Show("确定添加吗？", "误码提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    TianJia();
                }
            }
            else
            {
                MessageBox.Show("未添加。请检查输入的词和码。", "误码提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //删除页的操作
        private void textBoxShanChuCi_TextChanged(object sender, EventArgs e)
        {
            //清空combobox里的码
            //  如果少于2个字就关掉检查
            //  如果词库无该词就报错
            //    获取词的所有编码，放进combobox
            //    开启检查器，以便combobox执行检查
            comboBoxShanChuMa.Text = string.Empty;
            comboBoxShanChuMa.Items.Clear();
            if (textBoxShanChuCi.Text.Length < 2)
            {
                labelCheckShanChu.Visible = false;
            }
            else if (!YiYouCi(textBoxShanChuCi.Text))
            {
                labelCheckShanChu.Visible = true;
                labelCheckShanChu.ForeColor = Color.Red;
                labelCheckShanChu.Text = "×无该词";
            }
            else
            {
                using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
                for (int n = 0; n < 5; n++)//跳过文件头
                {
                    CiZuStream.ReadLine();
                }
                string? Ci_Ma = null;//词组流中的每一行
                while ((Ci_Ma = CiZuStream.ReadLine()) != null)//将词的所有编码装进combobox
                {
                    if (Ci_Ma.StartsWith(textBoxShanChuCi.Text + "\t"))
                    {
                        comboBoxShanChuMa.Items.Add(Ci_Ma.Split("\t")[1]);
                    }
                }
                comboBoxShanChuMa.SelectedIndex = 0;
                labelCheckShanChu.Visible = true;
            }
        }

        private void comboBoxShanChuMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果此combobox非空就执行检查
            //  已删除该码报错
            //  需要补位提示
            //  没有提示就显示勾勾没问题
            if (comboBoxShanChuMa.Items.Count != 0)
            {
                if (!YiYouTiaoMu(textBoxShanChuCi.Text, comboBoxShanChuMa.Text))
                {
                    labelCheckShanChu.ForeColor = Color.Red;
                    labelCheckShanChu.Text = "×已删除";
                }
                else if (XuYaoBuWei(comboBoxShanChuMa.Text))
                {
                    labelCheckShanChu.ForeColor = Color.Blue;
                    labelCheckShanChu.Text = "!需补位";
                }
                else
                {
                    labelCheckShanChu.ForeColor = Color.Green;
                    labelCheckShanChu.Text = "√没问题";
                }
            }
        }

        private void ShanChu()
        {
            //将词组移出CiZu并写日志
            List<string> Ci_Malist = new();//用于分装词库的每一行
            StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            string? Ci_Ma = null;//词组流中的每一行
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)//将词库装进list
            {
                Ci_Malist.Add(Ci_Ma);
            }
            CiZuStream.Dispose();//载入完成
            for (int n = 5; n < Ci_Malist.Count; n++)//从第六行开始比较
            {
                if (Ci_Malist[n] == textBoxShanChuCi.Text + "\t" + comboBoxShanChuMa.Text)
                {
                    Ci_Malist.RemoveAt(n);
                    break;
                }
            }
            File.Delete(CiZuLuJing);
            StreamWriter NewCiZuStream = new(CiZuLuJing);
            for (int n = 0; n < Ci_Malist.Count; n++)//将list写入新词库文件
            {
                NewCiZuStream.WriteLine(Ci_Malist[n]);
            }
            NewCiZuStream.Dispose();//写入完成
            richTextBoxLog.Text += textBoxShanChuCi.Text + "\t" + comboBoxShanChuMa.Text + "\t删除\t" + labelCheckShanChu.Text + "\r\n";
            labelCheckShanChu.ForeColor = Color.Red;//防止再次删除同一词
            labelCheckShanChu.Text = "×已删除";
        }

        private void buttonShanChu_Click(object sender, EventArgs e)
        {
            //检查没问题就删除
            //检查有提示就弹框确认
            //其他情况就不删除并弹框提示
            if (labelCheckShanChu.Visible && labelCheckShanChu.ForeColor == Color.Green)
            {
                ShanChu();
            }
            else if (labelCheckShanChu.Visible && labelCheckShanChu.ForeColor == Color.Blue)
            {
                MessageBox.Show("该码删除后会有空位，请到改码页面进行补位。", "补位提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ShanChu();
            }
            else
            {
                MessageBox.Show("未删除。请检查输入的词和码。", "误码提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //改词页的操作
        private void textBoxGaiCiCi_TextChanged(object sender, EventArgs e)
        {
            //如果未选择原词就提醒
            //如果少于2个字就关掉检查
            //如果输入了非中文就报错
            //如果编码用字不在DanZi中就报错
            //如果码不配就报错
            //如果已有词就提示
            //没有提示就显示勾勾没问题
            if (comboBoxYuanCi.Text == string.Empty)
            {
                MessageBox.Show("请先选择输入编码并选择原词，再输入要改成的词。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxGaiCiCi.Text = string.Empty;
            }
            else if (textBoxGaiCiCi.Text.Length < 2)
            {
                labelCheckGaiCi.Visible = false;
            }
            else
            {
                labelCheckGaiCi.Visible = true;
                if (Regex.IsMatch(textBoxGaiCiCi.Text, "[^\u4e00-\u9fa5]"))
                {
                    labelCheckGaiCi.ForeColor = Color.Red;
                    labelCheckGaiCi.Text = "×无效词";
                }
                else if (!AllInDanZi(textBoxGaiCiCi.Text))
                {
                    labelCheckGaiCi.ForeColor = Color.Red;
                    labelCheckGaiCi.Text = "×无效词";
                }
                else if (!CiMaMatch(textBoxGaiCiCi.Text, textBoxGaiCiMa.Text))
                {
                    labelCheckGaiCi.ForeColor = Color.Red;
                    labelCheckGaiCi.Text = "×码不配";
                }
                else if (YiYouCi(textBoxGaiCiCi.Text))
                {
                    labelCheckGaiCi.ForeColor = Color.Blue;
                    labelCheckGaiCi.Text = "!已有词";
                }
                else
                {
                    labelCheckGaiCi.ForeColor = Color.Green;
                    labelCheckGaiCi.Text = "√没问题";
                }
            }
        }

        private void textBoxGaiCiMa_TextChanged(object sender, EventArgs e)
        {
            //清空combobox里的词和textbox里的词
            //  如果码长小于3就关掉检查
            //  如果词库无该码就报错
            //    获取编码的所有词，放进combobox
            //    开启检查器，以便combobox执行检查
            comboBoxYuanCi.Text = string.Empty;
            comboBoxYuanCi.Items.Clear();
            textBoxGaiCiCi.Text = string.Empty;
            if (textBoxGaiCiMa.Text.Length < 3)
            {
                labelCheckGaiCi.Visible = false;
            }
            else if (!YiYouMa(textBoxGaiCiMa.Text))
            {
                labelCheckGaiCi.Visible = true;
                labelCheckGaiCi.ForeColor = Color.Red;
                labelCheckGaiCi.Text = "×无该码";
            }
            else
            {
                using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
                for (int n = 0; n < 5; n++)//跳过文件头
                {
                    CiZuStream.ReadLine();
                }
                string? Ci_Ma = null;//词组流中的每一行
                while ((Ci_Ma = CiZuStream.ReadLine()) != null)//将编码的所有词装进combobox
                {
                    if (Ci_Ma.EndsWith("\t" + textBoxGaiCiMa.Text))
                    {
                        comboBoxYuanCi.Items.Add(Ci_Ma.Split("\t")[0]);
                    }
                }
                comboBoxYuanCi.SelectedIndex = 0;
                labelCheckGaiCi.Visible = true;
            }
        }

        private void comboBoxYuanCi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果此combobox非空就检查
            //  已修改该码报错
            //    多选提示
            //    没有提示就显示勾勾没问题
            if (comboBoxYuanCi.Items.Count != 0)
            {
                if (!YiYouTiaoMu(comboBoxYuanCi.Text, textBoxGaiCiMa.Text))
                {
                    labelCheckGaiCi.ForeColor = Color.Red;
                    labelCheckGaiCi.Text = "×已修改";
                }
                else if (comboBoxYuanCi.Items.Count > 1)
                {
                    labelCheckGaiCi.ForeColor = Color.Blue;
                    labelCheckGaiCi.Text = "!有多项";
                }
                else
                {
                    labelCheckGaiCi.ForeColor = Color.Green;
                    labelCheckGaiCi.Text = "√没问题";
                }
            }
        }

        private void GaiCi()
        {
            //将CiZu指定码的指定词换成另一个词并写日志
            List<string> Ci_Malist = new();//用于分装词库的每一行
            StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            string? Ci_Ma = null;//词组流中的每一行
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)//将词库装进list
            {
                Ci_Malist.Add(Ci_Ma);
            }
            CiZuStream.Dispose();//载入完成
            for (int n = 5; n < Ci_Malist.Count; n++)//从第六行开始比较
            {
                if (Ci_Malist[n] == comboBoxYuanCi.Text + "\t" + textBoxGaiCiMa.Text)
                {
                    Ci_Malist[n] = textBoxGaiCiCi.Text + "\t" + textBoxGaiCiMa.Text;
                    break;
                }
            }
            File.Delete(CiZuLuJing);
            StreamWriter NewCiZuStream = new(CiZuLuJing);
            for (int n = 0; n < Ci_Malist.Count; n++)//将list写入新词库文件
            {
                NewCiZuStream.WriteLine(Ci_Malist[n]);
            }
            NewCiZuStream.Dispose();//写入完成
            richTextBoxLog.Text += textBoxGaiCiCi.Text + "\t" + textBoxGaiCiMa.Text + "\t改词\t" + labelCheckGaiCi.Text + "\t原词：\t" + comboBoxYuanCi.Text + "\r\n";
            labelCheckGaiCi.ForeColor = Color.Red;//防止再次修改同一词
            labelCheckGaiCi.Text = "×已修改";
        }

        private void buttonGaiCi_Click(object sender, EventArgs e)
        {
            //检查没问题就修改
            //检查有提示就弹框确认
            //其他情况就不修改并弹框提示
            if (textBoxGaiCiCi.Text.Length >= 2 && labelCheckGaiCi.Visible && labelCheckGaiCi.ForeColor == Color.Green)
            {
                GaiCi();
            }
            else if (textBoxGaiCiCi.Text.Length >= 2 && labelCheckGaiCi.Visible && labelCheckGaiCi.ForeColor == Color.Blue)
            {
                if (MessageBox.Show("确定改词吗？", "误码提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    GaiCi();
                }
            }
            else
            {
                MessageBox.Show("未修改。请检查输入的词和码。", "误码提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //改码页的操作
        private void textBoxGaiMaCi_TextChanged(object sender, EventArgs e)
        {
            //清空combobox里的码和textbox里的码
            //  如果少于2个字就关掉检查
            //  如果词库无该词就报错
            //    获取词的所有编码，放进combobox
            //    开启检查器，以便combobox执行检查
            comboBoxYuanMa.Text = string.Empty;
            comboBoxYuanMa.Items.Clear();
            textBoxGaiMaMa.Text = string.Empty;
            if (textBoxGaiMaCi.Text.Length < 2)
            {
                labelCheckGaiMa.Visible = false;
            }
            else if (!YiYouCi(textBoxGaiMaCi.Text))
            {
                labelCheckGaiMa.Visible = true;
                labelCheckGaiMa.ForeColor = Color.Red;
                labelCheckGaiMa.Text = "×无该词";
            }
            else
            {
                using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
                for (int n = 0; n < 5; n++)//跳过文件头
                {
                    CiZuStream.ReadLine();
                }
                string? Ci_Ma = null;//词组流中的每一行
                while ((Ci_Ma = CiZuStream.ReadLine()) != null)//将词的所有编码装进combobox
                {
                    if (Ci_Ma.StartsWith(textBoxGaiMaCi.Text + "\t"))
                    {
                        comboBoxYuanMa.Items.Add(Ci_Ma.Split("\t")[1]);
                    }
                }
                comboBoxYuanMa.SelectedIndex = 0;
                labelCheckGaiMa.Visible = true;
            }
        }

        private void textBoxGaiMaMa_TextChanged(object sender, EventArgs e)
        {
            //如果未选择原码就提醒
            //如果码长小于3就关掉检查
            //如果输入了非小写英文就报错
            //如果码不配就报错
            //如果已有码就提示
            //如果有更短空码就提示
            //没有提示就显示勾勾没问题
            if (comboBoxYuanMa.Text == string.Empty)
            {
                MessageBox.Show("请先选择输入词组并选择原码，再输入要改成的词。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxGaiMaMa.Text = string.Empty;
            }
            else if (textBoxGaiMaMa.Text.Length < 3)
            {
                labelCheckGaiMa.Visible = false;
            }
            else
            {
                labelCheckGaiMa.Visible = true;
                if (Regex.IsMatch(textBoxGaiMaMa.Text, "[^a-z]"))
                {
                    labelCheckGaiMa.ForeColor = Color.Red;
                    labelCheckGaiMa.Text = "×无效码";
                }
                else if (!CiMaMatch(textBoxGaiMaCi.Text, textBoxGaiMaMa.Text))
                {
                    labelCheckGaiMa.ForeColor = Color.Red;
                    labelCheckGaiMa.Text = "×码不配";
                }
                else if (YiYouMa(textBoxGaiMaMa.Text))
                {
                    labelCheckGaiMa.ForeColor = Color.Blue;
                    labelCheckGaiMa.Text = "!已有码";
                }
                else if (GengDuanKongMa(textBoxGaiMaMa.Text))
                {
                    labelCheckGaiMa.ForeColor = Color.Blue;
                    labelCheckGaiMa.Text = "!更短空";
                }
                else
                {
                    labelCheckGaiMa.ForeColor = Color.Green;
                    labelCheckGaiMa.Text = "√没问题";
                }
            }
        }

        private void comboBoxYuanMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果此combobox非空就检查
            //  已修改该码报错
            //    多选提示
            //    没有提示就显示勾勾没问题
            if (comboBoxYuanMa.Items.Count != 0)
            {
                if (!YiYouTiaoMu(textBoxGaiMaCi.Text, comboBoxYuanMa.Text))
                {
                    labelCheckGaiMa.ForeColor = Color.Red;
                    labelCheckGaiMa.Text = "×已修改";
                }
                else if (comboBoxYuanMa.Items.Count > 1)
                {
                    labelCheckGaiMa.ForeColor = Color.Blue;
                    labelCheckGaiMa.Text = "!有多项";
                }
                else
                {
                    labelCheckGaiMa.ForeColor = Color.Green;
                    labelCheckGaiMa.Text = "√没问题";
                }
            }
        }

        private void GaiMa()
        {
            //将CiZu指定词的指定码换成另一个码并写日志
            List<string> Ci_Malist = new();//用于分装词库的每一行
            StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            string? Ci_Ma = null;//词组流中的每一行
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)//将词库装进list
            {
                Ci_Malist.Add(Ci_Ma);
            }
            CiZuStream.Dispose();//载入完成
            int count = 0;//用来决定什么时候跳出循环
            for (int n = 5; n < Ci_Malist.Count; n++)//从第六行开始比较
            {
                if (Ci_Malist[n] == textBoxGaiMaCi.Text + "\t" + comboBoxYuanMa.Text)
                {
                    Ci_Malist.RemoveAt(n);
                    count++;
                }
                if (XinMaZaiQian(textBoxGaiMaMa.Text, Ci_Malist[n].Split("\t")[1]))
                {
                    Ci_Malist.Insert(n, textBoxGaiMaCi.Text + "\t" + textBoxGaiMaMa.Text);
                    count++;
                }
                if (count == 2) break;
            }
            File.Delete(CiZuLuJing);
            StreamWriter NewCiZuStream = new(CiZuLuJing);
            for (int n = 0; n < Ci_Malist.Count; n++)//将list写入新词库文件
            {
                NewCiZuStream.WriteLine(Ci_Malist[n]);
            }
            NewCiZuStream.Dispose();//写入完成
            richTextBoxLog.Text += textBoxGaiMaCi.Text + "\t" + textBoxGaiMaMa.Text + "\t改码\t" + labelCheckGaiMa.Text + "\t原码：\t" + comboBoxYuanMa.Text + "\r\n";
            labelCheckGaiMa.ForeColor = Color.Red;//防止再次修改同一词
            labelCheckGaiMa.Text = "×已修改";
        }

        private void buttonGaiMa_Click(object sender, EventArgs e)
        {
            //检查没问题就修改
            //检查有提示就弹框确认
            //其他情况就不修改并弹框提示
            if (textBoxGaiMaMa.Text.Length >= 3 && labelCheckGaiMa.Visible && labelCheckGaiMa.ForeColor == Color.Green)
            {
                GaiMa();
            }
            else if (textBoxGaiMaMa.Text.Length >= 3 && labelCheckGaiMa.Visible && labelCheckGaiMa.ForeColor == Color.Blue)
            {
                if (MessageBox.Show("确定改码吗？", "误码提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    GaiMa();
                }
            }
            else
            {
                MessageBox.Show("未修改。请检查输入的词和码。", "误码提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //调频页的操作
        private void textBoxTiaoPinDuanCi_TextChanged(object sender, EventArgs e)
        {
            //清空combobox里的码
            //  如果少于2个字就关掉检查
            //  如果词库无该词就报错
            //    获取词的所有编码，放进combobox
            //    开启检查器，以便combobox执行检查
            comboBoxTiaoPinDuanMa.Text = string.Empty;
            comboBoxTiaoPinDuanMa.Items.Clear();
            if (textBoxTiaoPinDuanCi.Text.Length < 2)
            {
                labelCheckTiaoPinDuan.Visible = false;
            }
            else if (!YiYouCi(textBoxTiaoPinDuanCi.Text))
            {
                labelCheckTiaoPinDuan.Visible = true;
                labelCheckTiaoPinDuan.ForeColor = Color.Red;
                labelCheckTiaoPinDuan.Text = "×无该词";
            }
            else
            {
                using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
                for (int n = 0; n < 5; n++)//跳过文件头
                {
                    CiZuStream.ReadLine();
                }
                string? Ci_Ma = null;//词组流中的每一行
                while ((Ci_Ma = CiZuStream.ReadLine()) != null)//将词的所有编码装进combobox
                {
                    if (Ci_Ma.StartsWith(textBoxTiaoPinDuanCi.Text + "\t"))
                    {
                        comboBoxTiaoPinDuanMa.Items.Add(Ci_Ma.Split("\t")[1]);
                    }
                }
                comboBoxTiaoPinDuanMa.SelectedIndex = 0;
                labelCheckTiaoPinDuan.Visible = true;
            }
        }

        private void comboBoxTiaoPinCheckDuan()
        {
            //已调频就报错
            //如果短码词和长码词相同，或者长码不以短码开头，就报错
            //获取长码，如果对应多个长码就弹窗报错
            //  如果有多选，或没有空的码位就提示
            //  没有提示就显示勾勾没问题
            if (!YiYouTiaoMu(textBoxTiaoPinDuanCi.Text, comboBoxTiaoPinDuanMa.Text))
            {
                labelCheckTiaoPinDuan.ForeColor = Color.Red;
                labelCheckTiaoPinDuan.Text = "×已调频";
            }
            else if (textBoxTiaoPinDuanCi.Text == textBoxTiaoPinChangCi.Text || !comboBoxTiaoPinChangMa.Text.StartsWith(comboBoxTiaoPinDuanMa.Text))
            {
                labelCheckTiaoPinDuan.ForeColor = Color.Red;
                labelCheckTiaoPinDuan.Text = "×调不了";
            }
            else
            {
                List<string> XinMa = new();//调频后的长码全码
                List<string> QuanMa = GetQuanMa(textBoxTiaoPinDuanCi.Text);//获取调频后的长码全码
                foreach (string quanma in QuanMa)
                {
                    if (quanma.StartsWith(comboBoxTiaoPinDuanMa.Text))
                    {
                        XinMa.Add(quanma);
                    }
                }
                if (XinMa.Count > 1)
                {
                    MessageBox.Show("此短码对应多个长码，无法进行调频。\r\n若到手动调频，请到改码页面操作。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxTiaoPinDuanCi.Text = string.Empty;
                }
                else
                {
                    labelCheckTiaoPinDuan.ForeColor = Color.Blue;
                    labelCheckTiaoPinDuan.Text = "!";
                    if (comboBoxTiaoPinDuanMa.Items.Count > 1)
                    {
                        labelCheckTiaoPinDuan.Text += " 多";
                    }
                    if (YiYouMa(XinMa[0]) && !XinMa[0].StartsWith(comboBoxTiaoPinChangMa.Text))
                    {
                        labelCheckTiaoPinDuan.Text += " 占";
                    }
                    if (labelCheckTiaoPinDuan.Text == "!")
                    {
                        labelCheckTiaoPinDuan.ForeColor = Color.Green;
                        labelCheckTiaoPinDuan.Text = "√没问题";
                    }
                }
            }
        }

        private void comboBoxTiaoPinDuanMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果两个combobox都非空就执行检查
            if (comboBoxTiaoPinDuanMa.Items.Count != 0 && comboBoxTiaoPinChangMa.Items.Count != 0)
            {
                comboBoxTiaoPinCheckDuan();
                comboBoxTiaoPinCheckChang();
            }
        }

        private void textBoxTiaoPinChangCi_TextChanged(object sender, EventArgs e)
        {
            //清空combobox里的码
            //  如果少于2个字就关掉检查
            //  如果词库无该词就报错
            //    获取词的所有编码，放进combobox
            //    开启检查器，以便combobox执行检查
            comboBoxTiaoPinChangMa.Text = string.Empty;
            comboBoxTiaoPinChangMa.Items.Clear();
            if (textBoxTiaoPinChangCi.Text.Length < 2)
            {
                labelCheckTiaoPinChang.Visible = false;
            }
            else if (!YiYouCi(textBoxTiaoPinChangCi.Text))
            {
                labelCheckTiaoPinChang.Visible = true;
                labelCheckTiaoPinChang.ForeColor = Color.Red;
                labelCheckTiaoPinChang.Text = "×无该词";
            }
            else
            {
                using StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
                for (int n = 0; n < 5; n++)//跳过文件头
                {
                    CiZuStream.ReadLine();
                }
                string? Ci_Ma = null;//词组流中的每一行
                while ((Ci_Ma = CiZuStream.ReadLine()) != null)//将词的所有编码装进combobox
                {
                    if (Ci_Ma.StartsWith(textBoxTiaoPinChangCi.Text + "\t"))
                    {
                        comboBoxTiaoPinChangMa.Items.Add(Ci_Ma.Split("\t")[1]);
                    }
                }
                comboBoxTiaoPinChangMa.SelectedIndex = 0;
                labelCheckTiaoPinChang.Visible = true;
            }
        }

        private void comboBoxTiaoPinCheckChang()
        {
            //已调频就报错
            //如果短码词和长码词相同，或者长码不以短码开头，就报错
            //  如果有多选就提示
            //  没有提示就显示勾勾没问题
            if (!YiYouTiaoMu(textBoxTiaoPinChangCi.Text, comboBoxTiaoPinChangMa.Text))
            {
                labelCheckTiaoPinChang.ForeColor = Color.Red;
                labelCheckTiaoPinChang.Text = "×已调频";
            }
            else if (textBoxTiaoPinDuanCi.Text == textBoxTiaoPinChangCi.Text || !comboBoxTiaoPinChangMa.Text.StartsWith(comboBoxTiaoPinDuanMa.Text))
            {
                labelCheckTiaoPinChang.ForeColor = Color.Red;
                labelCheckTiaoPinChang.Text = "×调不了";
            }
            else if (comboBoxTiaoPinChangMa.Items.Count > 1)
            {
                labelCheckTiaoPinChang.ForeColor = Color.Blue;
                labelCheckTiaoPinChang.Text = "!有多项";
            }
            else
            {
                labelCheckTiaoPinChang.ForeColor = Color.Green;
                labelCheckTiaoPinChang.Text = "√没问题";
            }
        }

        private void comboBoxTiaoPinChangMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果两个combobox都非空就执行检查
            if (comboBoxTiaoPinDuanMa.Items.Count != 0 && comboBoxTiaoPinChangMa.Items.Count != 0)
            {
                comboBoxTiaoPinCheckDuan();
                comboBoxTiaoPinCheckChang();
            }
        }

        private void TiaoPin()
        {
            //将CiZu中的指定长码词放在指定短码词的码位，将短码词放在更长的码位，并写日志
            List<string> Ci_Malist = new();//用于分装词库的每一行
            StreamReader CiZuStream = new(CiZuLuJing, Encoding.Default);
            string? Ci_Ma = null;//词组流中的每一行
            while ((Ci_Ma = CiZuStream.ReadLine()) != null)//将词库装进list
            {
                Ci_Malist.Add(Ci_Ma);
            }
            CiZuStream.Dispose();//载入完成
            string XinMa = string.Empty;//短词调频后的长码全码
            List<string> QuanMa = GetQuanMa(textBoxTiaoPinDuanCi.Text);//获取调频后的长码全码
            foreach (string quanma in QuanMa)
            {
                if (quanma.StartsWith(comboBoxTiaoPinDuanMa.Text))
                {
                    XinMa = quanma;
                    break;
                }
            }
            if (!labelCheckTiaoPinDuan.Text.Contains("占"))
            {
                for (int n = 3; n <= 6; n++)//找到最短的空码
                {
                    if (!YiYouMa(XinMa[..n]))
                    {
                        XinMa = XinMa[..n];
                        break;
                    }
                }
            }
            int count = 0;//用来决定什么时候跳出循环
            if (XinMa == comboBoxTiaoPinChangMa.Text)//如果短码词的长码恰好是长码词的长码
            {
                for (int n = 5; n < Ci_Malist.Count; n++)//从第六行开始比较
                {
                    if (Ci_Malist[n] == textBoxTiaoPinDuanCi.Text + "\t" + comboBoxTiaoPinDuanMa.Text)
                    {
                        Ci_Malist[n] = textBoxTiaoPinChangCi.Text + "\t" + comboBoxTiaoPinDuanMa.Text;
                        count++;
                    }
                    if (Ci_Malist[n] == textBoxTiaoPinChangCi.Text + "\t" + comboBoxTiaoPinChangMa.Text)
                    {
                        Ci_Malist[n] = textBoxTiaoPinDuanCi.Text + "\t" + comboBoxTiaoPinChangMa.Text;
                        count++;
                    }
                    if (count == 2) break;
                }
            }
            else//如果短码词的长码不是长码词的长码
            {
                for (int n = 5; n < Ci_Malist.Count; n++)//从第六行开始比较
                {
                    if (Ci_Malist[n] == textBoxTiaoPinDuanCi.Text + "\t" + comboBoxTiaoPinDuanMa.Text)
                    {
                        Ci_Malist[n] = textBoxTiaoPinChangCi.Text + "\t" + comboBoxTiaoPinDuanMa.Text;
                        count++;
                    }
                    if (Ci_Malist[n] == textBoxTiaoPinChangCi.Text + "\t" + comboBoxTiaoPinChangMa.Text)
                    {
                        Ci_Malist.RemoveAt(n);
                        count++;
                    }
                    if (count == 2) break;
                }
                for (int n = 5; n < Ci_Malist.Count; n++)//从第六行开始比较
                {
                    if (XinMaZaiQian(XinMa, Ci_Malist[n].Split("\t")[1]))
                    {
                        Ci_Malist.Insert(n, textBoxTiaoPinDuanCi.Text + "\t" + XinMa);
                        break;
                    }
                }
            }
            File.Delete(CiZuLuJing);
            StreamWriter NewCiZuStream = new(CiZuLuJing);
            for (int n = 0; n < Ci_Malist.Count; n++)//将list写入新词库文件
            {
                NewCiZuStream.WriteLine(Ci_Malist[n]);
            }
            NewCiZuStream.Dispose();//写入完成
            richTextBoxLog.Text += textBoxTiaoPinDuanCi.Text + "\t" + XinMa + "\t调频\t" + labelCheckTiaoPinDuan.Text + "\t原码：\t" + comboBoxTiaoPinDuanMa.Text + "\r\n";
            richTextBoxLog.Text += textBoxTiaoPinChangCi.Text + "\t" + comboBoxTiaoPinDuanMa.Text + "\t调频\t" + labelCheckTiaoPinChang.Text + "\t原码：\t" + comboBoxTiaoPinChangMa.Text + "\r\n";
            labelCheckTiaoPinDuan.ForeColor = labelCheckTiaoPinChang.ForeColor = Color.Red;//防止再次进行调频操作
            labelCheckTiaoPinDuan.Text = labelCheckTiaoPinChang.Text = "×已修改";
        }

        private void buttonTiaoPin_Click(object sender, EventArgs e)
        {
            //如果两个检查都没问题就调频
            //如果检查有提示就弹框确认
            //其他情况就不调频并弹框提示
            if (labelCheckTiaoPinDuan.Visible && labelCheckTiaoPinDuan.ForeColor == Color.Green && labelCheckTiaoPinChang.Visible && labelCheckTiaoPinChang.ForeColor == Color.Green)
            {
                TiaoPin();
            }
            else if (labelCheckTiaoPinDuan.Visible && labelCheckTiaoPinDuan.ForeColor == Color.Blue && labelCheckTiaoPinChang.Visible && labelCheckTiaoPinChang.ForeColor == Color.Blue)
            {
                if (MessageBox.Show("确定调频吗？", "误码提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    TiaoPin();
                }
            }
            else
            {
                MessageBox.Show("未调频。请检查输入的词和码。", "误码提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //日志页的操作
        private void ImportLog()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBoxLog.Text = string.Empty;
                using StreamReader LogStream = new(Path.GetFullPath(openFileDialog.FileName), Encoding.Default);
                string? LogLine = null;//日志流中的每一行
                while ((LogLine = LogStream.ReadLine()) != null)
                {
                    richTextBoxLog.Text += LogLine + "\r\n";
                }
            }
        }

        private void buttonImportLog_Click(object sender, EventArgs e)
        {
            //如果非空则提示覆盖
            //如果空则直接导入
            if (richTextBoxLog.Text != string.Empty)
            {
                if (MessageBox.Show("导入日志将覆盖现有日志，确定导入吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    ImportLog();
                }
            }
            else
            {
                ImportLog();
            }
        }

        private void buttonExportLog_Click(object sender, EventArgs e)
        {
            if (richTextBoxLog.Text == string.Empty)
            {
                MessageBox.Show("日志为空，不可导出。", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string LogLuJing = folderBrowserDialog.SelectedPath + @"\xkjd6.cizu.dict.log.yaml";
                    using StreamWriter LogStream = new(LogLuJing);
                    LogStream.Write(richTextBoxLog.Text);
                    MessageBox.Show("导出成功", "提示", MessageBoxButtons.OK);
                }
            }
        }
    }
}