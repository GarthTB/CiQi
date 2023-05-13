namespace 词器
{
    partial class Formmain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formmain));
            tabControlmain = new TabControl();
            tabPageHome = new TabPage();
            labelCheckBeiFen = new Label();
            linkLabelAbout = new LinkLabel();
            linkLabelHelp = new LinkLabel();
            buttonBeiFen = new Button();
            checkBoxBuYaoBeiFen = new CheckBox();
            textBoxBeiFenMuLu = new TextBox();
            buttonBeiFenMuLu = new Button();
            labelBeiFenMuLu = new Label();
            textBoxCiKuMuLu = new TextBox();
            buttonCiKuMuLu = new Button();
            labelCiKuMuLu = new Label();
            tabPageTianJia = new TabPage();
            buttonTianJia = new Button();
            labelCheckTianJia = new Label();
            numericUpDownTianJiaMaChang = new NumericUpDown();
            comboBoxTianJiaMa = new ComboBox();
            labelTianJiaMa = new Label();
            labelTianJiaMaChang = new Label();
            textBoxTianJiaCi = new TextBox();
            labelTianJiaCi = new Label();
            tabPageShanChu = new TabPage();
            buttonShanChu = new Button();
            labelCheckShanChu = new Label();
            comboBoxShanChuMa = new ComboBox();
            labelShanChuMa = new Label();
            textBoxShanChuCi = new TextBox();
            labelShanChuCi = new Label();
            tabPageGaiCi = new TabPage();
            textBoxGaiCiMa = new TextBox();
            buttonGaiCi = new Button();
            labelCheckGaiCi = new Label();
            comboBoxYuanCi = new ComboBox();
            labelGaiCiMa = new Label();
            labelYuanCi = new Label();
            textBoxGaiCiCi = new TextBox();
            labelGaiCiCi = new Label();
            tabPageGaiMa = new TabPage();
            textBoxGaiMaMa = new TextBox();
            buttonGaiMa = new Button();
            labelCheckGaiMa = new Label();
            comboBoxYuanMa = new ComboBox();
            labelGaiMaMa = new Label();
            labelYuanMa = new Label();
            textBoxGaiMaCi = new TextBox();
            labelGaiMaCi = new Label();
            tabPageTiaoPin = new TabPage();
            labelCheckTiaoPinDuan = new Label();
            comboBoxTiaoPinChangMa = new ComboBox();
            labelTiaoPinChangMa = new Label();
            textBoxTiaoPinChangCi = new TextBox();
            labelTiaoPinChangCi = new Label();
            buttonTiaoPin = new Button();
            labelCheckTiaoPinChang = new Label();
            comboBoxTiaoPinDuanMa = new ComboBox();
            labelTiaoPinDuanMa = new Label();
            textBoxTiaoPinDuanCi = new TextBox();
            labelTiaoPinDuanCi = new Label();
            tabPageRiZhi = new TabPage();
            buttonImportLog = new Button();
            buttonExportLog = new Button();
            richTextBoxLog = new RichTextBox();
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
            toolTip = new ToolTip(components);
            tabControlmain.SuspendLayout();
            tabPageHome.SuspendLayout();
            tabPageTianJia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTianJiaMaChang).BeginInit();
            tabPageShanChu.SuspendLayout();
            tabPageGaiCi.SuspendLayout();
            tabPageGaiMa.SuspendLayout();
            tabPageTiaoPin.SuspendLayout();
            tabPageRiZhi.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlmain
            // 
            resources.ApplyResources(tabControlmain, "tabControlmain");
            tabControlmain.Controls.Add(tabPageHome);
            tabControlmain.Controls.Add(tabPageTianJia);
            tabControlmain.Controls.Add(tabPageShanChu);
            tabControlmain.Controls.Add(tabPageGaiCi);
            tabControlmain.Controls.Add(tabPageGaiMa);
            tabControlmain.Controls.Add(tabPageTiaoPin);
            tabControlmain.Controls.Add(tabPageRiZhi);
            tabControlmain.Name = "tabControlmain";
            tabControlmain.SelectedIndex = 0;
            toolTip.SetToolTip(tabControlmain, resources.GetString("tabControlmain.ToolTip"));
            tabControlmain.Click += tabControlmain_Click;
            // 
            // tabPageHome
            // 
            resources.ApplyResources(tabPageHome, "tabPageHome");
            tabPageHome.Controls.Add(labelCheckBeiFen);
            tabPageHome.Controls.Add(linkLabelAbout);
            tabPageHome.Controls.Add(linkLabelHelp);
            tabPageHome.Controls.Add(buttonBeiFen);
            tabPageHome.Controls.Add(checkBoxBuYaoBeiFen);
            tabPageHome.Controls.Add(textBoxBeiFenMuLu);
            tabPageHome.Controls.Add(buttonBeiFenMuLu);
            tabPageHome.Controls.Add(labelBeiFenMuLu);
            tabPageHome.Controls.Add(textBoxCiKuMuLu);
            tabPageHome.Controls.Add(buttonCiKuMuLu);
            tabPageHome.Controls.Add(labelCiKuMuLu);
            tabPageHome.Name = "tabPageHome";
            toolTip.SetToolTip(tabPageHome, resources.GetString("tabPageHome.ToolTip"));
            tabPageHome.UseVisualStyleBackColor = true;
            // 
            // labelCheckBeiFen
            // 
            resources.ApplyResources(labelCheckBeiFen, "labelCheckBeiFen");
            labelCheckBeiFen.ForeColor = Color.Red;
            labelCheckBeiFen.Name = "labelCheckBeiFen";
            toolTip.SetToolTip(labelCheckBeiFen, resources.GetString("labelCheckBeiFen.ToolTip"));
            // 
            // linkLabelAbout
            // 
            resources.ApplyResources(linkLabelAbout, "linkLabelAbout");
            linkLabelAbout.Name = "linkLabelAbout";
            linkLabelAbout.TabStop = true;
            toolTip.SetToolTip(linkLabelAbout, resources.GetString("linkLabelAbout.ToolTip"));
            linkLabelAbout.LinkClicked += linkLabelAbout_LinkClicked;
            // 
            // linkLabelHelp
            // 
            resources.ApplyResources(linkLabelHelp, "linkLabelHelp");
            linkLabelHelp.Name = "linkLabelHelp";
            linkLabelHelp.TabStop = true;
            toolTip.SetToolTip(linkLabelHelp, resources.GetString("linkLabelHelp.ToolTip"));
            linkLabelHelp.LinkClicked += linkLabelHelp_LinkClicked;
            // 
            // buttonBeiFen
            // 
            resources.ApplyResources(buttonBeiFen, "buttonBeiFen");
            buttonBeiFen.Name = "buttonBeiFen";
            toolTip.SetToolTip(buttonBeiFen, resources.GetString("buttonBeiFen.ToolTip"));
            buttonBeiFen.UseVisualStyleBackColor = true;
            buttonBeiFen.Click += buttonBeiFen_Click;
            // 
            // checkBoxBuYaoBeiFen
            // 
            resources.ApplyResources(checkBoxBuYaoBeiFen, "checkBoxBuYaoBeiFen");
            checkBoxBuYaoBeiFen.Name = "checkBoxBuYaoBeiFen";
            toolTip.SetToolTip(checkBoxBuYaoBeiFen, resources.GetString("checkBoxBuYaoBeiFen.ToolTip"));
            checkBoxBuYaoBeiFen.UseVisualStyleBackColor = true;
            checkBoxBuYaoBeiFen.CheckedChanged += checkBoxBuYaoBeiFen_CheckedChanged;
            // 
            // textBoxBeiFenMuLu
            // 
            resources.ApplyResources(textBoxBeiFenMuLu, "textBoxBeiFenMuLu");
            textBoxBeiFenMuLu.BackColor = SystemColors.Window;
            textBoxBeiFenMuLu.BorderStyle = BorderStyle.FixedSingle;
            textBoxBeiFenMuLu.Name = "textBoxBeiFenMuLu";
            textBoxBeiFenMuLu.ReadOnly = true;
            toolTip.SetToolTip(textBoxBeiFenMuLu, resources.GetString("textBoxBeiFenMuLu.ToolTip"));
            // 
            // buttonBeiFenMuLu
            // 
            resources.ApplyResources(buttonBeiFenMuLu, "buttonBeiFenMuLu");
            buttonBeiFenMuLu.Name = "buttonBeiFenMuLu";
            toolTip.SetToolTip(buttonBeiFenMuLu, resources.GetString("buttonBeiFenMuLu.ToolTip"));
            buttonBeiFenMuLu.UseVisualStyleBackColor = true;
            buttonBeiFenMuLu.Click += buttonBeiFenMuLu_Click;
            // 
            // labelBeiFenMuLu
            // 
            resources.ApplyResources(labelBeiFenMuLu, "labelBeiFenMuLu");
            labelBeiFenMuLu.Name = "labelBeiFenMuLu";
            toolTip.SetToolTip(labelBeiFenMuLu, resources.GetString("labelBeiFenMuLu.ToolTip"));
            // 
            // textBoxCiKuMuLu
            // 
            resources.ApplyResources(textBoxCiKuMuLu, "textBoxCiKuMuLu");
            textBoxCiKuMuLu.BackColor = SystemColors.Window;
            textBoxCiKuMuLu.BorderStyle = BorderStyle.FixedSingle;
            textBoxCiKuMuLu.Name = "textBoxCiKuMuLu";
            textBoxCiKuMuLu.ReadOnly = true;
            toolTip.SetToolTip(textBoxCiKuMuLu, resources.GetString("textBoxCiKuMuLu.ToolTip"));
            // 
            // buttonCiKuMuLu
            // 
            resources.ApplyResources(buttonCiKuMuLu, "buttonCiKuMuLu");
            buttonCiKuMuLu.Name = "buttonCiKuMuLu";
            toolTip.SetToolTip(buttonCiKuMuLu, resources.GetString("buttonCiKuMuLu.ToolTip"));
            buttonCiKuMuLu.UseVisualStyleBackColor = true;
            buttonCiKuMuLu.Click += buttonCiKuMuLu_Click;
            // 
            // labelCiKuMuLu
            // 
            resources.ApplyResources(labelCiKuMuLu, "labelCiKuMuLu");
            labelCiKuMuLu.Name = "labelCiKuMuLu";
            toolTip.SetToolTip(labelCiKuMuLu, resources.GetString("labelCiKuMuLu.ToolTip"));
            // 
            // tabPageTianJia
            // 
            resources.ApplyResources(tabPageTianJia, "tabPageTianJia");
            tabPageTianJia.Controls.Add(buttonTianJia);
            tabPageTianJia.Controls.Add(labelCheckTianJia);
            tabPageTianJia.Controls.Add(numericUpDownTianJiaMaChang);
            tabPageTianJia.Controls.Add(comboBoxTianJiaMa);
            tabPageTianJia.Controls.Add(labelTianJiaMa);
            tabPageTianJia.Controls.Add(labelTianJiaMaChang);
            tabPageTianJia.Controls.Add(textBoxTianJiaCi);
            tabPageTianJia.Controls.Add(labelTianJiaCi);
            tabPageTianJia.Name = "tabPageTianJia";
            toolTip.SetToolTip(tabPageTianJia, resources.GetString("tabPageTianJia.ToolTip"));
            tabPageTianJia.UseVisualStyleBackColor = true;
            // 
            // buttonTianJia
            // 
            resources.ApplyResources(buttonTianJia, "buttonTianJia");
            buttonTianJia.Name = "buttonTianJia";
            toolTip.SetToolTip(buttonTianJia, resources.GetString("buttonTianJia.ToolTip"));
            buttonTianJia.UseVisualStyleBackColor = true;
            buttonTianJia.Click += buttonTianJia_Click;
            // 
            // labelCheckTianJia
            // 
            resources.ApplyResources(labelCheckTianJia, "labelCheckTianJia");
            labelCheckTianJia.ForeColor = Color.Green;
            labelCheckTianJia.Name = "labelCheckTianJia";
            toolTip.SetToolTip(labelCheckTianJia, resources.GetString("labelCheckTianJia.ToolTip"));
            // 
            // numericUpDownTianJiaMaChang
            // 
            resources.ApplyResources(numericUpDownTianJiaMaChang, "numericUpDownTianJiaMaChang");
            numericUpDownTianJiaMaChang.BorderStyle = BorderStyle.FixedSingle;
            numericUpDownTianJiaMaChang.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDownTianJiaMaChang.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownTianJiaMaChang.Name = "numericUpDownTianJiaMaChang";
            toolTip.SetToolTip(numericUpDownTianJiaMaChang, resources.GetString("numericUpDownTianJiaMaChang.ToolTip"));
            numericUpDownTianJiaMaChang.Value = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownTianJiaMaChang.ValueChanged += numericUpDownTianJiaMaChang_ValueChanged;
            // 
            // comboBoxTianJiaMa
            // 
            resources.ApplyResources(comboBoxTianJiaMa, "comboBoxTianJiaMa");
            comboBoxTianJiaMa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTianJiaMa.FormattingEnabled = true;
            comboBoxTianJiaMa.Name = "comboBoxTianJiaMa";
            toolTip.SetToolTip(comboBoxTianJiaMa, resources.GetString("comboBoxTianJiaMa.ToolTip"));
            comboBoxTianJiaMa.SelectedIndexChanged += comboBoxTianJiaMa_SelectedIndexChanged;
            // 
            // labelTianJiaMa
            // 
            resources.ApplyResources(labelTianJiaMa, "labelTianJiaMa");
            labelTianJiaMa.Name = "labelTianJiaMa";
            toolTip.SetToolTip(labelTianJiaMa, resources.GetString("labelTianJiaMa.ToolTip"));
            // 
            // labelTianJiaMaChang
            // 
            resources.ApplyResources(labelTianJiaMaChang, "labelTianJiaMaChang");
            labelTianJiaMaChang.Name = "labelTianJiaMaChang";
            toolTip.SetToolTip(labelTianJiaMaChang, resources.GetString("labelTianJiaMaChang.ToolTip"));
            // 
            // textBoxTianJiaCi
            // 
            resources.ApplyResources(textBoxTianJiaCi, "textBoxTianJiaCi");
            textBoxTianJiaCi.BorderStyle = BorderStyle.FixedSingle;
            textBoxTianJiaCi.Name = "textBoxTianJiaCi";
            toolTip.SetToolTip(textBoxTianJiaCi, resources.GetString("textBoxTianJiaCi.ToolTip"));
            textBoxTianJiaCi.TextChanged += textBoxTianJiaCi_TextChanged;
            // 
            // labelTianJiaCi
            // 
            resources.ApplyResources(labelTianJiaCi, "labelTianJiaCi");
            labelTianJiaCi.Name = "labelTianJiaCi";
            toolTip.SetToolTip(labelTianJiaCi, resources.GetString("labelTianJiaCi.ToolTip"));
            // 
            // tabPageShanChu
            // 
            resources.ApplyResources(tabPageShanChu, "tabPageShanChu");
            tabPageShanChu.Controls.Add(buttonShanChu);
            tabPageShanChu.Controls.Add(labelCheckShanChu);
            tabPageShanChu.Controls.Add(comboBoxShanChuMa);
            tabPageShanChu.Controls.Add(labelShanChuMa);
            tabPageShanChu.Controls.Add(textBoxShanChuCi);
            tabPageShanChu.Controls.Add(labelShanChuCi);
            tabPageShanChu.Name = "tabPageShanChu";
            toolTip.SetToolTip(tabPageShanChu, resources.GetString("tabPageShanChu.ToolTip"));
            tabPageShanChu.UseVisualStyleBackColor = true;
            // 
            // buttonShanChu
            // 
            resources.ApplyResources(buttonShanChu, "buttonShanChu");
            buttonShanChu.Name = "buttonShanChu";
            toolTip.SetToolTip(buttonShanChu, resources.GetString("buttonShanChu.ToolTip"));
            buttonShanChu.UseVisualStyleBackColor = true;
            buttonShanChu.Click += buttonShanChu_Click;
            // 
            // labelCheckShanChu
            // 
            resources.ApplyResources(labelCheckShanChu, "labelCheckShanChu");
            labelCheckShanChu.ForeColor = Color.Green;
            labelCheckShanChu.Name = "labelCheckShanChu";
            toolTip.SetToolTip(labelCheckShanChu, resources.GetString("labelCheckShanChu.ToolTip"));
            // 
            // comboBoxShanChuMa
            // 
            resources.ApplyResources(comboBoxShanChuMa, "comboBoxShanChuMa");
            comboBoxShanChuMa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShanChuMa.FormattingEnabled = true;
            comboBoxShanChuMa.Name = "comboBoxShanChuMa";
            toolTip.SetToolTip(comboBoxShanChuMa, resources.GetString("comboBoxShanChuMa.ToolTip"));
            comboBoxShanChuMa.SelectedIndexChanged += comboBoxShanChuMa_SelectedIndexChanged;
            // 
            // labelShanChuMa
            // 
            resources.ApplyResources(labelShanChuMa, "labelShanChuMa");
            labelShanChuMa.Name = "labelShanChuMa";
            toolTip.SetToolTip(labelShanChuMa, resources.GetString("labelShanChuMa.ToolTip"));
            // 
            // textBoxShanChuCi
            // 
            resources.ApplyResources(textBoxShanChuCi, "textBoxShanChuCi");
            textBoxShanChuCi.BorderStyle = BorderStyle.FixedSingle;
            textBoxShanChuCi.Name = "textBoxShanChuCi";
            toolTip.SetToolTip(textBoxShanChuCi, resources.GetString("textBoxShanChuCi.ToolTip"));
            textBoxShanChuCi.TextChanged += textBoxShanChuCi_TextChanged;
            // 
            // labelShanChuCi
            // 
            resources.ApplyResources(labelShanChuCi, "labelShanChuCi");
            labelShanChuCi.Name = "labelShanChuCi";
            toolTip.SetToolTip(labelShanChuCi, resources.GetString("labelShanChuCi.ToolTip"));
            // 
            // tabPageGaiCi
            // 
            resources.ApplyResources(tabPageGaiCi, "tabPageGaiCi");
            tabPageGaiCi.Controls.Add(textBoxGaiCiMa);
            tabPageGaiCi.Controls.Add(buttonGaiCi);
            tabPageGaiCi.Controls.Add(labelCheckGaiCi);
            tabPageGaiCi.Controls.Add(comboBoxYuanCi);
            tabPageGaiCi.Controls.Add(labelGaiCiMa);
            tabPageGaiCi.Controls.Add(labelYuanCi);
            tabPageGaiCi.Controls.Add(textBoxGaiCiCi);
            tabPageGaiCi.Controls.Add(labelGaiCiCi);
            tabPageGaiCi.Name = "tabPageGaiCi";
            toolTip.SetToolTip(tabPageGaiCi, resources.GetString("tabPageGaiCi.ToolTip"));
            tabPageGaiCi.UseVisualStyleBackColor = true;
            // 
            // textBoxGaiCiMa
            // 
            resources.ApplyResources(textBoxGaiCiMa, "textBoxGaiCiMa");
            textBoxGaiCiMa.Name = "textBoxGaiCiMa";
            toolTip.SetToolTip(textBoxGaiCiMa, resources.GetString("textBoxGaiCiMa.ToolTip"));
            textBoxGaiCiMa.TextChanged += textBoxGaiCiMa_TextChanged;
            // 
            // buttonGaiCi
            // 
            resources.ApplyResources(buttonGaiCi, "buttonGaiCi");
            buttonGaiCi.Name = "buttonGaiCi";
            toolTip.SetToolTip(buttonGaiCi, resources.GetString("buttonGaiCi.ToolTip"));
            buttonGaiCi.UseVisualStyleBackColor = true;
            buttonGaiCi.Click += buttonGaiCi_Click;
            // 
            // labelCheckGaiCi
            // 
            resources.ApplyResources(labelCheckGaiCi, "labelCheckGaiCi");
            labelCheckGaiCi.ForeColor = Color.Green;
            labelCheckGaiCi.Name = "labelCheckGaiCi";
            toolTip.SetToolTip(labelCheckGaiCi, resources.GetString("labelCheckGaiCi.ToolTip"));
            // 
            // comboBoxYuanCi
            // 
            resources.ApplyResources(comboBoxYuanCi, "comboBoxYuanCi");
            comboBoxYuanCi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxYuanCi.FormattingEnabled = true;
            comboBoxYuanCi.Name = "comboBoxYuanCi";
            toolTip.SetToolTip(comboBoxYuanCi, resources.GetString("comboBoxYuanCi.ToolTip"));
            comboBoxYuanCi.SelectedIndexChanged += comboBoxYuanCi_SelectedIndexChanged;
            // 
            // labelGaiCiMa
            // 
            resources.ApplyResources(labelGaiCiMa, "labelGaiCiMa");
            labelGaiCiMa.Name = "labelGaiCiMa";
            toolTip.SetToolTip(labelGaiCiMa, resources.GetString("labelGaiCiMa.ToolTip"));
            // 
            // labelYuanCi
            // 
            resources.ApplyResources(labelYuanCi, "labelYuanCi");
            labelYuanCi.Name = "labelYuanCi";
            toolTip.SetToolTip(labelYuanCi, resources.GetString("labelYuanCi.ToolTip"));
            // 
            // textBoxGaiCiCi
            // 
            resources.ApplyResources(textBoxGaiCiCi, "textBoxGaiCiCi");
            textBoxGaiCiCi.BorderStyle = BorderStyle.FixedSingle;
            textBoxGaiCiCi.Name = "textBoxGaiCiCi";
            toolTip.SetToolTip(textBoxGaiCiCi, resources.GetString("textBoxGaiCiCi.ToolTip"));
            textBoxGaiCiCi.TextChanged += textBoxGaiCiCi_TextChanged;
            // 
            // labelGaiCiCi
            // 
            resources.ApplyResources(labelGaiCiCi, "labelGaiCiCi");
            labelGaiCiCi.Name = "labelGaiCiCi";
            toolTip.SetToolTip(labelGaiCiCi, resources.GetString("labelGaiCiCi.ToolTip"));
            // 
            // tabPageGaiMa
            // 
            resources.ApplyResources(tabPageGaiMa, "tabPageGaiMa");
            tabPageGaiMa.Controls.Add(textBoxGaiMaMa);
            tabPageGaiMa.Controls.Add(buttonGaiMa);
            tabPageGaiMa.Controls.Add(labelCheckGaiMa);
            tabPageGaiMa.Controls.Add(comboBoxYuanMa);
            tabPageGaiMa.Controls.Add(labelGaiMaMa);
            tabPageGaiMa.Controls.Add(labelYuanMa);
            tabPageGaiMa.Controls.Add(textBoxGaiMaCi);
            tabPageGaiMa.Controls.Add(labelGaiMaCi);
            tabPageGaiMa.Name = "tabPageGaiMa";
            toolTip.SetToolTip(tabPageGaiMa, resources.GetString("tabPageGaiMa.ToolTip"));
            tabPageGaiMa.UseVisualStyleBackColor = true;
            // 
            // textBoxGaiMaMa
            // 
            resources.ApplyResources(textBoxGaiMaMa, "textBoxGaiMaMa");
            textBoxGaiMaMa.Name = "textBoxGaiMaMa";
            toolTip.SetToolTip(textBoxGaiMaMa, resources.GetString("textBoxGaiMaMa.ToolTip"));
            textBoxGaiMaMa.TextChanged += textBoxGaiMaMa_TextChanged;
            // 
            // buttonGaiMa
            // 
            resources.ApplyResources(buttonGaiMa, "buttonGaiMa");
            buttonGaiMa.Name = "buttonGaiMa";
            toolTip.SetToolTip(buttonGaiMa, resources.GetString("buttonGaiMa.ToolTip"));
            buttonGaiMa.UseVisualStyleBackColor = true;
            buttonGaiMa.Click += buttonGaiMa_Click;
            // 
            // labelCheckGaiMa
            // 
            resources.ApplyResources(labelCheckGaiMa, "labelCheckGaiMa");
            labelCheckGaiMa.ForeColor = Color.Green;
            labelCheckGaiMa.Name = "labelCheckGaiMa";
            toolTip.SetToolTip(labelCheckGaiMa, resources.GetString("labelCheckGaiMa.ToolTip"));
            // 
            // comboBoxYuanMa
            // 
            resources.ApplyResources(comboBoxYuanMa, "comboBoxYuanMa");
            comboBoxYuanMa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxYuanMa.FormattingEnabled = true;
            comboBoxYuanMa.Name = "comboBoxYuanMa";
            toolTip.SetToolTip(comboBoxYuanMa, resources.GetString("comboBoxYuanMa.ToolTip"));
            comboBoxYuanMa.SelectedIndexChanged += comboBoxYuanMa_SelectedIndexChanged;
            // 
            // labelGaiMaMa
            // 
            resources.ApplyResources(labelGaiMaMa, "labelGaiMaMa");
            labelGaiMaMa.Name = "labelGaiMaMa";
            toolTip.SetToolTip(labelGaiMaMa, resources.GetString("labelGaiMaMa.ToolTip"));
            // 
            // labelYuanMa
            // 
            resources.ApplyResources(labelYuanMa, "labelYuanMa");
            labelYuanMa.Name = "labelYuanMa";
            toolTip.SetToolTip(labelYuanMa, resources.GetString("labelYuanMa.ToolTip"));
            // 
            // textBoxGaiMaCi
            // 
            resources.ApplyResources(textBoxGaiMaCi, "textBoxGaiMaCi");
            textBoxGaiMaCi.BorderStyle = BorderStyle.FixedSingle;
            textBoxGaiMaCi.Name = "textBoxGaiMaCi";
            toolTip.SetToolTip(textBoxGaiMaCi, resources.GetString("textBoxGaiMaCi.ToolTip"));
            textBoxGaiMaCi.TextChanged += textBoxGaiMaCi_TextChanged;
            // 
            // labelGaiMaCi
            // 
            resources.ApplyResources(labelGaiMaCi, "labelGaiMaCi");
            labelGaiMaCi.Name = "labelGaiMaCi";
            toolTip.SetToolTip(labelGaiMaCi, resources.GetString("labelGaiMaCi.ToolTip"));
            // 
            // tabPageTiaoPin
            // 
            resources.ApplyResources(tabPageTiaoPin, "tabPageTiaoPin");
            tabPageTiaoPin.Controls.Add(labelCheckTiaoPinDuan);
            tabPageTiaoPin.Controls.Add(comboBoxTiaoPinChangMa);
            tabPageTiaoPin.Controls.Add(labelTiaoPinChangMa);
            tabPageTiaoPin.Controls.Add(textBoxTiaoPinChangCi);
            tabPageTiaoPin.Controls.Add(labelTiaoPinChangCi);
            tabPageTiaoPin.Controls.Add(buttonTiaoPin);
            tabPageTiaoPin.Controls.Add(labelCheckTiaoPinChang);
            tabPageTiaoPin.Controls.Add(comboBoxTiaoPinDuanMa);
            tabPageTiaoPin.Controls.Add(labelTiaoPinDuanMa);
            tabPageTiaoPin.Controls.Add(textBoxTiaoPinDuanCi);
            tabPageTiaoPin.Controls.Add(labelTiaoPinDuanCi);
            tabPageTiaoPin.Name = "tabPageTiaoPin";
            toolTip.SetToolTip(tabPageTiaoPin, resources.GetString("tabPageTiaoPin.ToolTip"));
            tabPageTiaoPin.UseVisualStyleBackColor = true;
            // 
            // labelCheckTiaoPinDuan
            // 
            resources.ApplyResources(labelCheckTiaoPinDuan, "labelCheckTiaoPinDuan");
            labelCheckTiaoPinDuan.ForeColor = Color.Green;
            labelCheckTiaoPinDuan.Name = "labelCheckTiaoPinDuan";
            toolTip.SetToolTip(labelCheckTiaoPinDuan, resources.GetString("labelCheckTiaoPinDuan.ToolTip"));
            // 
            // comboBoxTiaoPinChangMa
            // 
            resources.ApplyResources(comboBoxTiaoPinChangMa, "comboBoxTiaoPinChangMa");
            comboBoxTiaoPinChangMa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTiaoPinChangMa.FormattingEnabled = true;
            comboBoxTiaoPinChangMa.Name = "comboBoxTiaoPinChangMa";
            toolTip.SetToolTip(comboBoxTiaoPinChangMa, resources.GetString("comboBoxTiaoPinChangMa.ToolTip"));
            comboBoxTiaoPinChangMa.SelectedIndexChanged += comboBoxTiaoPinChangMa_SelectedIndexChanged;
            // 
            // labelTiaoPinChangMa
            // 
            resources.ApplyResources(labelTiaoPinChangMa, "labelTiaoPinChangMa");
            labelTiaoPinChangMa.Name = "labelTiaoPinChangMa";
            toolTip.SetToolTip(labelTiaoPinChangMa, resources.GetString("labelTiaoPinChangMa.ToolTip"));
            // 
            // textBoxTiaoPinChangCi
            // 
            resources.ApplyResources(textBoxTiaoPinChangCi, "textBoxTiaoPinChangCi");
            textBoxTiaoPinChangCi.BorderStyle = BorderStyle.FixedSingle;
            textBoxTiaoPinChangCi.Name = "textBoxTiaoPinChangCi";
            toolTip.SetToolTip(textBoxTiaoPinChangCi, resources.GetString("textBoxTiaoPinChangCi.ToolTip"));
            textBoxTiaoPinChangCi.TextChanged += textBoxTiaoPinChangCi_TextChanged;
            // 
            // labelTiaoPinChangCi
            // 
            resources.ApplyResources(labelTiaoPinChangCi, "labelTiaoPinChangCi");
            labelTiaoPinChangCi.Name = "labelTiaoPinChangCi";
            toolTip.SetToolTip(labelTiaoPinChangCi, resources.GetString("labelTiaoPinChangCi.ToolTip"));
            // 
            // buttonTiaoPin
            // 
            resources.ApplyResources(buttonTiaoPin, "buttonTiaoPin");
            buttonTiaoPin.Name = "buttonTiaoPin";
            toolTip.SetToolTip(buttonTiaoPin, resources.GetString("buttonTiaoPin.ToolTip"));
            buttonTiaoPin.UseVisualStyleBackColor = true;
            buttonTiaoPin.Click += buttonTiaoPin_Click;
            // 
            // labelCheckTiaoPinChang
            // 
            resources.ApplyResources(labelCheckTiaoPinChang, "labelCheckTiaoPinChang");
            labelCheckTiaoPinChang.ForeColor = Color.Green;
            labelCheckTiaoPinChang.Name = "labelCheckTiaoPinChang";
            toolTip.SetToolTip(labelCheckTiaoPinChang, resources.GetString("labelCheckTiaoPinChang.ToolTip"));
            // 
            // comboBoxTiaoPinDuanMa
            // 
            resources.ApplyResources(comboBoxTiaoPinDuanMa, "comboBoxTiaoPinDuanMa");
            comboBoxTiaoPinDuanMa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTiaoPinDuanMa.FormattingEnabled = true;
            comboBoxTiaoPinDuanMa.Name = "comboBoxTiaoPinDuanMa";
            toolTip.SetToolTip(comboBoxTiaoPinDuanMa, resources.GetString("comboBoxTiaoPinDuanMa.ToolTip"));
            comboBoxTiaoPinDuanMa.SelectedIndexChanged += comboBoxTiaoPinDuanMa_SelectedIndexChanged;
            // 
            // labelTiaoPinDuanMa
            // 
            resources.ApplyResources(labelTiaoPinDuanMa, "labelTiaoPinDuanMa");
            labelTiaoPinDuanMa.Name = "labelTiaoPinDuanMa";
            toolTip.SetToolTip(labelTiaoPinDuanMa, resources.GetString("labelTiaoPinDuanMa.ToolTip"));
            // 
            // textBoxTiaoPinDuanCi
            // 
            resources.ApplyResources(textBoxTiaoPinDuanCi, "textBoxTiaoPinDuanCi");
            textBoxTiaoPinDuanCi.BorderStyle = BorderStyle.FixedSingle;
            textBoxTiaoPinDuanCi.Name = "textBoxTiaoPinDuanCi";
            toolTip.SetToolTip(textBoxTiaoPinDuanCi, resources.GetString("textBoxTiaoPinDuanCi.ToolTip"));
            textBoxTiaoPinDuanCi.TextChanged += textBoxTiaoPinDuanCi_TextChanged;
            // 
            // labelTiaoPinDuanCi
            // 
            resources.ApplyResources(labelTiaoPinDuanCi, "labelTiaoPinDuanCi");
            labelTiaoPinDuanCi.Name = "labelTiaoPinDuanCi";
            toolTip.SetToolTip(labelTiaoPinDuanCi, resources.GetString("labelTiaoPinDuanCi.ToolTip"));
            // 
            // tabPageRiZhi
            // 
            resources.ApplyResources(tabPageRiZhi, "tabPageRiZhi");
            tabPageRiZhi.Controls.Add(buttonImportLog);
            tabPageRiZhi.Controls.Add(buttonExportLog);
            tabPageRiZhi.Controls.Add(richTextBoxLog);
            tabPageRiZhi.Name = "tabPageRiZhi";
            toolTip.SetToolTip(tabPageRiZhi, resources.GetString("tabPageRiZhi.ToolTip"));
            tabPageRiZhi.UseVisualStyleBackColor = true;
            // 
            // buttonImportLog
            // 
            resources.ApplyResources(buttonImportLog, "buttonImportLog");
            buttonImportLog.Name = "buttonImportLog";
            toolTip.SetToolTip(buttonImportLog, resources.GetString("buttonImportLog.ToolTip"));
            buttonImportLog.UseVisualStyleBackColor = true;
            buttonImportLog.Click += buttonImportLog_Click;
            // 
            // buttonExportLog
            // 
            resources.ApplyResources(buttonExportLog, "buttonExportLog");
            buttonExportLog.Name = "buttonExportLog";
            toolTip.SetToolTip(buttonExportLog, resources.GetString("buttonExportLog.ToolTip"));
            buttonExportLog.UseVisualStyleBackColor = true;
            buttonExportLog.Click += buttonExportLog_Click;
            // 
            // richTextBoxLog
            // 
            resources.ApplyResources(richTextBoxLog, "richTextBoxLog");
            richTextBoxLog.BackColor = SystemColors.Window;
            richTextBoxLog.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxLog.Name = "richTextBoxLog";
            richTextBoxLog.ReadOnly = true;
            toolTip.SetToolTip(richTextBoxLog, resources.GetString("richTextBoxLog.ToolTip"));
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            resources.ApplyResources(openFileDialog, "openFileDialog");
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(folderBrowserDialog, "folderBrowserDialog");
            // 
            // Formmain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tabControlmain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Formmain";
            toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            Load += Formmain_Load;
            tabControlmain.ResumeLayout(false);
            tabPageHome.ResumeLayout(false);
            tabPageHome.PerformLayout();
            tabPageTianJia.ResumeLayout(false);
            tabPageTianJia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTianJiaMaChang).EndInit();
            tabPageShanChu.ResumeLayout(false);
            tabPageShanChu.PerformLayout();
            tabPageGaiCi.ResumeLayout(false);
            tabPageGaiCi.PerformLayout();
            tabPageGaiMa.ResumeLayout(false);
            tabPageGaiMa.PerformLayout();
            tabPageTiaoPin.ResumeLayout(false);
            tabPageTiaoPin.PerformLayout();
            tabPageRiZhi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlmain;
        private TabPage tabPageTianJia;
        private TabPage tabPageShanChu;
        private TabPage tabPageGaiCi;
        private TabPage tabPageTiaoPin;
        private TabPage tabPageRiZhi;
        private TabPage tabPageHome;
        private CheckBox checkBoxBuYaoBeiFen;
        private TextBox textBoxBeiFenMuLu;
        private Button buttonBeiFenMuLu;
        private Label labelBeiFenMuLu;
        private TextBox textBoxCiKuMuLu;
        private Button buttonCiKuMuLu;
        private TextBox textBoxTianJiaCi;
        private Label labelTianJiaCi;
        private Label labelTianJiaMa;
        private Label labelTianJiaMaChang;
        private ComboBox comboBoxTianJiaMa;
        private NumericUpDown numericUpDownTianJiaMaChang;
        private Button buttonTianJia;
        private Label labelCheckTianJia;
        private Button buttonShanChu;
        private Label labelCheckShanChu;
        private ComboBox comboBoxShanChuMa;
        private Label labelShanChuMa;
        private TextBox textBoxShanChuCi;
        private Label labelShanChuCi;
        private TextBox textBoxGaiCiMa;
        private Button buttonGaiCi;
        private Label labelCheckGaiCi;
        private ComboBox comboBoxYuanCi;
        private Label labelGaiCiMa;
        private Label labelYuanCi;
        private TextBox textBoxGaiCiCi;
        private Label labelGaiCiCi;
        private Label labelCheckTiaoPinDuan;
        private ComboBox comboBoxTiaoPinChangMa;
        private Label labelTiaoPinChangMa;
        private TextBox textBoxTiaoPinChangCi;
        private Label labelTiaoPinChangCi;
        private Button buttonTiaoPin;
        private Label labelCheckTiaoPinChang;
        private ComboBox comboBoxTiaoPinDuanMa;
        private Label labelTiaoPinDuanMa;
        private TextBox textBoxTiaoPinDuanCi;
        private Label labelTiaoPinDuanCi;
        private Button buttonImportLog;
        private Button buttonExportLog;
        private RichTextBox richTextBoxLog;
        private Label labelCiKuMuLu;
        private LinkLabel linkLabelAbout;
        private LinkLabel linkLabelHelp;
        private Button buttonBeiFen;
        private OpenFileDialog openFileDialog;
        private FolderBrowserDialog folderBrowserDialog;
        private Label labelCheckBeiFen;
        private TabPage tabPageGaiMa;
        private TextBox textBoxGaiMaMa;
        private Button buttonGaiMa;
        private Label labelCheckGaiMa;
        private ComboBox comboBoxYuanMa;
        private Label labelGaiMaMa;
        private Label labelYuanMa;
        private TextBox textBoxGaiMaCi;
        private Label labelGaiMaCi;
        private ToolTip toolTip;
    }
}