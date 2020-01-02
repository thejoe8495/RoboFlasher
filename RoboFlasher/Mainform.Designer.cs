namespace RoboFlasher
{
    partial class Mainform
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.txtlog = new System.Windows.Forms.TextBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabDevice = new System.Windows.Forms.TabPage();
            this.llbWebserver = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblErrorToken = new System.Windows.Forms.Label();
            this.btnSearchKey = new System.Windows.Forms.Button();
            this.btnGenerateNew = new System.Windows.Forms.Button();
            this.txtKeyPassword = new System.Windows.Forms.TextBox();
            this.txtRsaKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstdevices = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnDiscoverDevices = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtipadress = new System.Windows.Forms.TextBox();
            this.tabWebinterface = new System.Windows.Forms.TabPage();
            this.btnWebinterfaceDownload = new System.Windows.Forms.Button();
            this.chkWebinterface = new System.Windows.Forms.CheckedListBox();
            this.btnWebinterfaceInstall = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnRunWerbint = new System.Windows.Forms.Button();
            this.lblStatusWI = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstwebinterface = new System.Windows.Forms.ListBox();
            this.tabFirmware = new System.Windows.Forms.TabPage();
            this.chkFirmware = new System.Windows.Forms.CheckedListBox();
            this.btnFirmwareDownload = new System.Windows.Forms.Button();
            this.btnInstallFirmware = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lstfirmware = new System.Windows.Forms.ListBox();
            this.tabPackFirmware = new System.Windows.Forms.TabPage();
            this.chkGenerateSshKey = new System.Windows.Forms.CheckBox();
            this.btnPackandFlash = new System.Windows.Forms.Button();
            this.cboWebinterface = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboVoicepacks = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboFirmware = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabVoiceinstall = new System.Windows.Forms.TabPage();
            this.chkVoices = new System.Windows.Forms.CheckedListBox();
            this.btnVoiceDownload = new System.Windows.Forms.Button();
            this.btnInstallVoicepack = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lstVoices = new System.Windows.Forms.ListBox();
            this.tabExpert = new System.Windows.Forms.TabPage();
            this.lblsshcomman = new System.Windows.Forms.Label();
            this.txtSshCommand = new System.Windows.Forms.TextBox();
            this.btnSshCommand = new System.Windows.Forms.Button();
            this.txtMiiOParams = new System.Windows.Forms.Label();
            this.txtMiioParameter = new System.Windows.Forms.TextBox();
            this.btnMiioCommand = new System.Windows.Forms.Button();
            this.txtMiioCommand = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.timWebinterface = new System.Windows.Forms.Timer(this.components);
            this.timProgress = new System.Windows.Forms.Timer(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.prgMiiO = new MetroFramework.Controls.MetroProgressBar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.metroTabControl1.SuspendLayout();
            this.tabDevice.SuspendLayout();
            this.tabWebinterface.SuspendLayout();
            this.tabFirmware.SuspendLayout();
            this.tabPackFirmware.SuspendLayout();
            this.tabVoiceinstall.SuspendLayout();
            this.tabExpert.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtlog
            // 
            this.txtlog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlog.Location = new System.Drawing.Point(37, 658);
            this.txtlog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtlog.Multiline = true;
            this.txtlog.Name = "txtlog";
            this.txtlog.Size = new System.Drawing.Size(1237, 131);
            this.txtlog.TabIndex = 10;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.tabDevice);
            this.metroTabControl1.Controls.Add(this.tabWebinterface);
            this.metroTabControl1.Controls.Add(this.tabFirmware);
            this.metroTabControl1.Controls.Add(this.tabPackFirmware);
            this.metroTabControl1.Controls.Add(this.tabVoiceinstall);
            this.metroTabControl1.Controls.Add(this.tabExpert);
            this.metroTabControl1.Location = new System.Drawing.Point(33, 95);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 3;
            this.metroTabControl1.Size = new System.Drawing.Size(1245, 523);
            this.metroTabControl1.TabIndex = 19;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabDevice
            // 
            this.tabDevice.Controls.Add(this.llbWebserver);
            this.tabDevice.Controls.Add(this.label10);
            this.tabDevice.Controls.Add(this.lblErrorToken);
            this.tabDevice.Controls.Add(this.btnSearchKey);
            this.tabDevice.Controls.Add(this.btnGenerateNew);
            this.tabDevice.Controls.Add(this.txtKeyPassword);
            this.tabDevice.Controls.Add(this.txtRsaKey);
            this.tabDevice.Controls.Add(this.label7);
            this.tabDevice.Controls.Add(this.label6);
            this.tabDevice.Controls.Add(this.label4);
            this.tabDevice.Controls.Add(this.lstdevices);
            this.tabDevice.Controls.Add(this.label3);
            this.tabDevice.Controls.Add(this.txtToken);
            this.tabDevice.Controls.Add(this.btnDiscoverDevices);
            this.tabDevice.Controls.Add(this.label1);
            this.tabDevice.Controls.Add(this.txtipadress);
            this.tabDevice.Location = new System.Drawing.Point(4, 38);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Size = new System.Drawing.Size(1237, 481);
            this.tabDevice.TabIndex = 0;
            this.tabDevice.Text = "Device";
            // 
            // llbWebserver
            // 
            this.llbWebserver.AutoSize = true;
            this.llbWebserver.Location = new System.Drawing.Point(155, 222);
            this.llbWebserver.Name = "llbWebserver";
            this.llbWebserver.Size = new System.Drawing.Size(100, 20);
            this.llbWebserver.TabIndex = 40;
            this.llbWebserver.TabStop = true;
            this.llbWebserver.Text = "llbWebserver";
            this.llbWebserver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbWebserver_LinkClicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 222);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 39;
            this.label10.Text = "Local URL";
            // 
            // lblErrorToken
            // 
            this.lblErrorToken.AutoSize = true;
            this.lblErrorToken.ForeColor = System.Drawing.Color.Maroon;
            this.lblErrorToken.Location = new System.Drawing.Point(541, 98);
            this.lblErrorToken.Name = "lblErrorToken";
            this.lblErrorToken.Size = new System.Drawing.Size(0, 20);
            this.lblErrorToken.TabIndex = 38;
            // 
            // btnSearchKey
            // 
            this.btnSearchKey.Location = new System.Drawing.Point(541, 133);
            this.btnSearchKey.Name = "btnSearchKey";
            this.btnSearchKey.Size = new System.Drawing.Size(41, 34);
            this.btnSearchKey.TabIndex = 37;
            this.btnSearchKey.Text = "...";
            this.btnSearchKey.UseVisualStyleBackColor = true;
            this.btnSearchKey.Click += new System.EventHandler(this.btnSearchKey_Click);
            // 
            // btnGenerateNew
            // 
            this.btnGenerateNew.Location = new System.Drawing.Point(588, 133);
            this.btnGenerateNew.Name = "btnGenerateNew";
            this.btnGenerateNew.Size = new System.Drawing.Size(185, 34);
            this.btnGenerateNew.TabIndex = 36;
            this.btnGenerateNew.Text = "Generate New";
            this.btnGenerateNew.UseVisualStyleBackColor = true;
            this.btnGenerateNew.Click += new System.EventHandler(this.btnGenerateNew_Click);
            // 
            // txtKeyPassword
            // 
            this.txtKeyPassword.Location = new System.Drawing.Point(155, 179);
            this.txtKeyPassword.Name = "txtKeyPassword";
            this.txtKeyPassword.Size = new System.Drawing.Size(380, 26);
            this.txtKeyPassword.TabIndex = 35;
            // 
            // txtRsaKey
            // 
            this.txtRsaKey.Location = new System.Drawing.Point(155, 137);
            this.txtRsaKey.Name = "txtRsaKey";
            this.txtRsaKey.Size = new System.Drawing.Size(380, 26);
            this.txtRsaKey.TabIndex = 34;
            this.txtRsaKey.Text = "rsaKey";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 179);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Keyfiles password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "SSH key";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(789, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Found devices:";
            // 
            // lstdevices
            // 
            this.lstdevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstdevices.DisplayMember = "Linetext";
            this.lstdevices.FormattingEnabled = true;
            this.lstdevices.ItemHeight = 20;
            this.lstdevices.Location = new System.Drawing.Point(789, 77);
            this.lstdevices.Name = "lstdevices";
            this.lstdevices.Size = new System.Drawing.Size(421, 204);
            this.lstdevices.TabIndex = 24;
            this.lstdevices.SelectedIndexChanged += new System.EventHandler(this.lstdevices_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Token";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(155, 98);
            this.txtToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(380, 26);
            this.txtToken.TabIndex = 22;
            this.txtToken.TextChanged += new System.EventHandler(this.txtToken_TextChanged);
            // 
            // btnDiscoverDevices
            // 
            this.btnDiscoverDevices.Location = new System.Drawing.Point(946, 34);
            this.btnDiscoverDevices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDiscoverDevices.Name = "btnDiscoverDevices";
            this.btnDiscoverDevices.Size = new System.Drawing.Size(264, 35);
            this.btnDiscoverDevices.TabIndex = 21;
            this.btnDiscoverDevices.Text = "Discover devices";
            this.btnDiscoverDevices.UseVisualStyleBackColor = true;
            this.btnDiscoverDevices.Click += new System.EventHandler(this.btndiscover_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "IP address:";
            // 
            // txtipadress
            // 
            this.txtipadress.Location = new System.Drawing.Point(155, 62);
            this.txtipadress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtipadress.Name = "txtipadress";
            this.txtipadress.Size = new System.Drawing.Size(164, 26);
            this.txtipadress.TabIndex = 19;
            // 
            // tabWebinterface
            // 
            this.tabWebinterface.Controls.Add(this.btnWebinterfaceDownload);
            this.tabWebinterface.Controls.Add(this.chkWebinterface);
            this.tabWebinterface.Controls.Add(this.btnWebinterfaceInstall);
            this.tabWebinterface.Controls.Add(this.label14);
            this.tabWebinterface.Controls.Add(this.btnRunWerbint);
            this.tabWebinterface.Controls.Add(this.lblStatusWI);
            this.tabWebinterface.Controls.Add(this.label2);
            this.tabWebinterface.Controls.Add(this.lstwebinterface);
            this.tabWebinterface.Location = new System.Drawing.Point(4, 38);
            this.tabWebinterface.Name = "tabWebinterface";
            this.tabWebinterface.Size = new System.Drawing.Size(1237, 481);
            this.tabWebinterface.TabIndex = 1;
            this.tabWebinterface.Text = "Webinterface";
            // 
            // btnWebinterfaceDownload
            // 
            this.btnWebinterfaceDownload.Location = new System.Drawing.Point(927, 292);
            this.btnWebinterfaceDownload.Name = "btnWebinterfaceDownload";
            this.btnWebinterfaceDownload.Size = new System.Drawing.Size(285, 58);
            this.btnWebinterfaceDownload.TabIndex = 30;
            this.btnWebinterfaceDownload.Text = "Download selected";
            this.btnWebinterfaceDownload.UseVisualStyleBackColor = true;
            // 
            // chkWebinterface
            // 
            this.chkWebinterface.FormattingEnabled = true;
            this.chkWebinterface.Location = new System.Drawing.Point(782, 72);
            this.chkWebinterface.Name = "chkWebinterface";
            this.chkWebinterface.Size = new System.Drawing.Size(431, 211);
            this.chkWebinterface.TabIndex = 29;
            // 
            // btnWebinterfaceInstall
            // 
            this.btnWebinterfaceInstall.Location = new System.Drawing.Point(414, 74);
            this.btnWebinterfaceInstall.Name = "btnWebinterfaceInstall";
            this.btnWebinterfaceInstall.Size = new System.Drawing.Size(163, 56);
            this.btnWebinterfaceInstall.TabIndex = 28;
            this.btnWebinterfaceInstall.Text = "install Webinterface";
            this.btnWebinterfaceInstall.UseVisualStyleBackColor = true;
            this.btnWebinterfaceInstall.Click += new System.EventHandler(this.btnWebinterfaceInstall_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 313);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = "Webinterface state:";
            // 
            // btnRunWerbint
            // 
            this.btnRunWerbint.Location = new System.Drawing.Point(414, 292);
            this.btnRunWerbint.Name = "btnRunWerbint";
            this.btnRunWerbint.Size = new System.Drawing.Size(262, 58);
            this.btnRunWerbint.TabIndex = 25;
            this.btnRunWerbint.Text = "Run Webinterface per SSH";
            this.btnRunWerbint.UseVisualStyleBackColor = true;
            this.btnRunWerbint.Click += new System.EventHandler(this.btnRunWerbint_Click);
            // 
            // lblStatusWI
            // 
            this.lblStatusWI.AutoSize = true;
            this.lblStatusWI.Location = new System.Drawing.Point(225, 310);
            this.lblStatusWI.Name = "lblStatusWI";
            this.lblStatusWI.Size = new System.Drawing.Size(66, 20);
            this.lblStatusWI.TabIndex = 24;
            this.lblStatusWI.Text = "pending";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Update webinterface";
            // 
            // lstwebinterface
            // 
            this.lstwebinterface.DisplayMember = "Linetext";
            this.lstwebinterface.FormattingEnabled = true;
            this.lstwebinterface.ItemHeight = 20;
            this.lstwebinterface.Location = new System.Drawing.Point(30, 72);
            this.lstwebinterface.Name = "lstwebinterface";
            this.lstwebinterface.Size = new System.Drawing.Size(342, 204);
            this.lstwebinterface.TabIndex = 17;
            // 
            // tabFirmware
            // 
            this.tabFirmware.Controls.Add(this.chkFirmware);
            this.tabFirmware.Controls.Add(this.btnFirmwareDownload);
            this.tabFirmware.Controls.Add(this.btnInstallFirmware);
            this.tabFirmware.Controls.Add(this.label5);
            this.tabFirmware.Controls.Add(this.lstfirmware);
            this.tabFirmware.Location = new System.Drawing.Point(4, 38);
            this.tabFirmware.Name = "tabFirmware";
            this.tabFirmware.Size = new System.Drawing.Size(1237, 481);
            this.tabFirmware.TabIndex = 2;
            this.tabFirmware.Text = "Firmware";
            // 
            // chkFirmware
            // 
            this.chkFirmware.FormattingEnabled = true;
            this.chkFirmware.Location = new System.Drawing.Point(782, 72);
            this.chkFirmware.Name = "chkFirmware";
            this.chkFirmware.Size = new System.Drawing.Size(431, 211);
            this.chkFirmware.TabIndex = 32;
            // 
            // btnFirmwareDownload
            // 
            this.btnFirmwareDownload.Location = new System.Drawing.Point(927, 292);
            this.btnFirmwareDownload.Name = "btnFirmwareDownload";
            this.btnFirmwareDownload.Size = new System.Drawing.Size(285, 58);
            this.btnFirmwareDownload.TabIndex = 31;
            this.btnFirmwareDownload.Text = "Download selected";
            this.btnFirmwareDownload.UseVisualStyleBackColor = true;
            // 
            // btnInstallFirmware
            // 
            this.btnInstallFirmware.Location = new System.Drawing.Point(412, 72);
            this.btnInstallFirmware.Name = "btnInstallFirmware";
            this.btnInstallFirmware.Size = new System.Drawing.Size(164, 65);
            this.btnInstallFirmware.TabIndex = 23;
            this.btnInstallFirmware.Text = "Install firmware";
            this.btnInstallFirmware.UseVisualStyleBackColor = true;
            this.btnInstallFirmware.Click += new System.EventHandler(this.btnInstallFirmware_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 51);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Update custom firmware";
            // 
            // lstfirmware
            // 
            this.lstfirmware.DisplayMember = "Linetext";
            this.lstfirmware.FormattingEnabled = true;
            this.lstfirmware.ItemHeight = 20;
            this.lstfirmware.Location = new System.Drawing.Point(31, 72);
            this.lstfirmware.Name = "lstfirmware";
            this.lstfirmware.Size = new System.Drawing.Size(342, 204);
            this.lstfirmware.TabIndex = 19;
            // 
            // tabPackFirmware
            // 
            this.tabPackFirmware.Controls.Add(this.chkGenerateSshKey);
            this.tabPackFirmware.Controls.Add(this.btnPackandFlash);
            this.tabPackFirmware.Controls.Add(this.cboWebinterface);
            this.tabPackFirmware.Controls.Add(this.label13);
            this.tabPackFirmware.Controls.Add(this.cboVoicepacks);
            this.tabPackFirmware.Controls.Add(this.label12);
            this.tabPackFirmware.Controls.Add(this.cboFirmware);
            this.tabPackFirmware.Controls.Add(this.label11);
            this.tabPackFirmware.Location = new System.Drawing.Point(4, 38);
            this.tabPackFirmware.Name = "tabPackFirmware";
            this.tabPackFirmware.Size = new System.Drawing.Size(1237, 481);
            this.tabPackFirmware.TabIndex = 5;
            this.tabPackFirmware.Text = "Create Firmware";
            // 
            // chkGenerateSshKey
            // 
            this.chkGenerateSshKey.AutoSize = true;
            this.chkGenerateSshKey.Checked = true;
            this.chkGenerateSshKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenerateSshKey.Location = new System.Drawing.Point(52, 234);
            this.chkGenerateSshKey.Name = "chkGenerateSshKey";
            this.chkGenerateSshKey.Size = new System.Drawing.Size(281, 24);
            this.chkGenerateSshKey.TabIndex = 29;
            this.chkGenerateSshKey.Text = "generate new SSH key if not exists";
            this.chkGenerateSshKey.UseVisualStyleBackColor = true;
            // 
            // btnPackandFlash
            // 
            this.btnPackandFlash.Enabled = false;
            this.btnPackandFlash.Location = new System.Drawing.Point(52, 287);
            this.btnPackandFlash.Name = "btnPackandFlash";
            this.btnPackandFlash.Size = new System.Drawing.Size(288, 104);
            this.btnPackandFlash.TabIndex = 28;
            this.btnPackandFlash.Text = "Pack and Flash";
            this.btnPackandFlash.UseVisualStyleBackColor = true;
            this.btnPackandFlash.Click += new System.EventHandler(this.btnPackandFlash_Click);
            // 
            // cboWebinterface
            // 
            this.cboWebinterface.FormattingEnabled = true;
            this.cboWebinterface.Location = new System.Drawing.Point(52, 186);
            this.cboWebinterface.Name = "cboWebinterface";
            this.cboWebinterface.Size = new System.Drawing.Size(288, 28);
            this.cboWebinterface.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "Install webinterface";
            // 
            // cboVoicepacks
            // 
            this.cboVoicepacks.FormattingEnabled = true;
            this.cboVoicepacks.Location = new System.Drawing.Point(52, 122);
            this.cboVoicepacks.Name = "cboVoicepacks";
            this.cboVoicepacks.Size = new System.Drawing.Size(288, 28);
            this.cboVoicepacks.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Install sound";
            // 
            // cboFirmware
            // 
            this.cboFirmware.FormattingEnabled = true;
            this.cboFirmware.Location = new System.Drawing.Point(52, 62);
            this.cboFirmware.Name = "cboFirmware";
            this.cboFirmware.Size = new System.Drawing.Size(288, 28);
            this.cboFirmware.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 43);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Original firmware";
            // 
            // tabVoiceinstall
            // 
            this.tabVoiceinstall.Controls.Add(this.chkVoices);
            this.tabVoiceinstall.Controls.Add(this.btnVoiceDownload);
            this.tabVoiceinstall.Controls.Add(this.btnInstallVoicepack);
            this.tabVoiceinstall.Controls.Add(this.label8);
            this.tabVoiceinstall.Controls.Add(this.lstVoices);
            this.tabVoiceinstall.Location = new System.Drawing.Point(4, 38);
            this.tabVoiceinstall.Name = "tabVoiceinstall";
            this.tabVoiceinstall.Size = new System.Drawing.Size(1237, 481);
            this.tabVoiceinstall.TabIndex = 3;
            this.tabVoiceinstall.Text = "Voices";
            // 
            // chkVoices
            // 
            this.chkVoices.FormattingEnabled = true;
            this.chkVoices.Location = new System.Drawing.Point(782, 72);
            this.chkVoices.Name = "chkVoices";
            this.chkVoices.Size = new System.Drawing.Size(431, 211);
            this.chkVoices.TabIndex = 34;
            // 
            // btnVoiceDownload
            // 
            this.btnVoiceDownload.Location = new System.Drawing.Point(927, 292);
            this.btnVoiceDownload.Name = "btnVoiceDownload";
            this.btnVoiceDownload.Size = new System.Drawing.Size(285, 58);
            this.btnVoiceDownload.TabIndex = 33;
            this.btnVoiceDownload.Text = "Download selected";
            this.btnVoiceDownload.UseVisualStyleBackColor = true;
            // 
            // btnInstallVoicepack
            // 
            this.btnInstallVoicepack.Location = new System.Drawing.Point(410, 69);
            this.btnInstallVoicepack.Name = "btnInstallVoicepack";
            this.btnInstallVoicepack.Size = new System.Drawing.Size(164, 66);
            this.btnInstallVoicepack.TabIndex = 27;
            this.btnInstallVoicepack.Text = "install voicepack";
            this.btnInstallVoicepack.UseVisualStyleBackColor = true;
            this.btnInstallVoicepack.Click += new System.EventHandler(this.btnInstallVoicepack_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Install sounds";
            // 
            // lstVoices
            // 
            this.lstVoices.DisplayMember = "Linetext";
            this.lstVoices.FormattingEnabled = true;
            this.lstVoices.ItemHeight = 20;
            this.lstVoices.Location = new System.Drawing.Point(27, 67);
            this.lstVoices.Name = "lstVoices";
            this.lstVoices.Size = new System.Drawing.Size(342, 204);
            this.lstVoices.TabIndex = 22;
            // 
            // tabExpert
            // 
            this.tabExpert.Controls.Add(this.lblsshcomman);
            this.tabExpert.Controls.Add(this.txtSshCommand);
            this.tabExpert.Controls.Add(this.btnSshCommand);
            this.tabExpert.Controls.Add(this.txtMiiOParams);
            this.tabExpert.Controls.Add(this.txtMiioParameter);
            this.tabExpert.Controls.Add(this.btnMiioCommand);
            this.tabExpert.Controls.Add(this.txtMiioCommand);
            this.tabExpert.Controls.Add(this.label9);
            this.tabExpert.Location = new System.Drawing.Point(4, 38);
            this.tabExpert.Name = "tabExpert";
            this.tabExpert.Size = new System.Drawing.Size(1237, 481);
            this.tabExpert.TabIndex = 4;
            this.tabExpert.Text = "Expert";
            // 
            // lblsshcomman
            // 
            this.lblsshcomman.AutoSize = true;
            this.lblsshcomman.Location = new System.Drawing.Point(39, 279);
            this.lblsshcomman.Name = "lblsshcomman";
            this.lblsshcomman.Size = new System.Drawing.Size(163, 20);
            this.lblsshcomman.TabIndex = 7;
            this.lblsshcomman.Text = "Send SSH command:";
            // 
            // txtSshCommand
            // 
            this.txtSshCommand.Location = new System.Drawing.Point(212, 275);
            this.txtSshCommand.Name = "txtSshCommand";
            this.txtSshCommand.Size = new System.Drawing.Size(280, 26);
            this.txtSshCommand.TabIndex = 6;
            // 
            // btnSshCommand
            // 
            this.btnSshCommand.Location = new System.Drawing.Point(515, 271);
            this.btnSshCommand.Name = "btnSshCommand";
            this.btnSshCommand.Size = new System.Drawing.Size(342, 35);
            this.btnSshCommand.TabIndex = 5;
            this.btnSshCommand.Text = "Send SSH Command";
            this.btnSshCommand.UseVisualStyleBackColor = true;
            this.btnSshCommand.Click += new System.EventHandler(this.btnSshCommand_Click);
            // 
            // txtMiiOParams
            // 
            this.txtMiiOParams.AutoSize = true;
            this.txtMiiOParams.Location = new System.Drawing.Point(517, 14);
            this.txtMiiOParams.Name = "txtMiiOParams";
            this.txtMiiOParams.Size = new System.Drawing.Size(130, 20);
            this.txtMiiOParams.TabIndex = 4;
            this.txtMiiOParams.Text = "Params as jquery";
            // 
            // txtMiioParameter
            // 
            this.txtMiioParameter.Location = new System.Drawing.Point(515, 44);
            this.txtMiioParameter.Multiline = true;
            this.txtMiioParameter.Name = "txtMiioParameter";
            this.txtMiioParameter.Size = new System.Drawing.Size(451, 210);
            this.txtMiioParameter.TabIndex = 3;
            // 
            // btnMiioCommand
            // 
            this.btnMiioCommand.Location = new System.Drawing.Point(988, 44);
            this.btnMiioCommand.Name = "btnMiioCommand";
            this.btnMiioCommand.Size = new System.Drawing.Size(219, 34);
            this.btnMiioCommand.TabIndex = 2;
            this.btnMiioCommand.Text = "Send MiiO";
            this.btnMiioCommand.UseVisualStyleBackColor = true;
            this.btnMiioCommand.Click += new System.EventHandler(this.btnMiioCommand_Click);
            // 
            // txtMiioCommand
            // 
            this.txtMiioCommand.Location = new System.Drawing.Point(212, 44);
            this.txtMiioCommand.Name = "txtMiioCommand";
            this.txtMiioCommand.Size = new System.Drawing.Size(280, 26);
            this.txtMiioCommand.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Send MiiO command:";
            // 
            // timWebinterface
            // 
            this.timWebinterface.Enabled = true;
            this.timWebinterface.Interval = 8000;
            this.timWebinterface.Tick += new System.EventHandler(this.timWebinterface_Tick);
            // 
            // timProgress
            // 
            this.timProgress.Interval = 2000;
            this.timProgress.Tick += new System.EventHandler(this.timProgress_Tick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 630);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "Progress by MiiO";
            // 
            // prgMiiO
            // 
            this.prgMiiO.Location = new System.Drawing.Point(183, 624);
            this.prgMiiO.Name = "prgMiiO";
            this.prgMiiO.Size = new System.Drawing.Size(453, 26);
            this.prgMiiO.TabIndex = 30;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1078, 45);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(213, 50);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Refresh files and web";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 825);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.prgMiiO);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.txtlog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Mainform";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Text = "RoboFlasher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.metroTabControl1.ResumeLayout(false);
            this.tabDevice.ResumeLayout(false);
            this.tabDevice.PerformLayout();
            this.tabWebinterface.ResumeLayout(false);
            this.tabWebinterface.PerformLayout();
            this.tabFirmware.ResumeLayout(false);
            this.tabFirmware.PerformLayout();
            this.tabPackFirmware.ResumeLayout(false);
            this.tabPackFirmware.PerformLayout();
            this.tabVoiceinstall.ResumeLayout(false);
            this.tabVoiceinstall.PerformLayout();
            this.tabExpert.ResumeLayout(false);
            this.tabExpert.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtlog;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tabDevice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstdevices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Button btnDiscoverDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtipadress;
        private System.Windows.Forms.TabPage tabWebinterface;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstwebinterface;
        private System.Windows.Forms.TabPage tabFirmware;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstfirmware;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabVoiceinstall;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstVoices;
        private System.Windows.Forms.Timer timWebinterface;
        private System.Windows.Forms.Label lblStatusWI;
        private System.Windows.Forms.TabPage tabExpert;
        private System.Windows.Forms.Label lblsshcomman;
        private System.Windows.Forms.TextBox txtSshCommand;
        private System.Windows.Forms.Button btnSshCommand;
        private System.Windows.Forms.Label txtMiiOParams;
        private System.Windows.Forms.TextBox txtMiioParameter;
        private System.Windows.Forms.Button btnMiioCommand;
        private System.Windows.Forms.TextBox txtMiioCommand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timProgress;
        private System.Windows.Forms.TabPage tabPackFirmware;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtKeyPassword;
        private System.Windows.Forms.TextBox txtRsaKey;
        private System.Windows.Forms.ComboBox cboWebinterface;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboVoicepacks;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboFirmware;
        private System.Windows.Forms.Button btnSearchKey;
        private System.Windows.Forms.Button btnGenerateNew;
        private System.Windows.Forms.Label lblErrorToken;
        private System.Windows.Forms.Button btnPackandFlash;
        private System.Windows.Forms.CheckBox chkGenerateSshKey;
        private System.Windows.Forms.Button btnInstallFirmware;
        private System.Windows.Forms.Label label15;
        private MetroFramework.Controls.MetroProgressBar prgMiiO;
        private System.Windows.Forms.Button btnRunWerbint;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnWebinterfaceInstall;
        private System.Windows.Forms.Button btnInstallVoicepack;
        private System.Windows.Forms.Button btnWebinterfaceDownload;
        private System.Windows.Forms.CheckedListBox chkWebinterface;
        private System.Windows.Forms.CheckedListBox chkFirmware;
        private System.Windows.Forms.Button btnFirmwareDownload;
        private System.Windows.Forms.CheckedListBox chkVoices;
        private System.Windows.Forms.Button btnVoiceDownload;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.LinkLabel llbWebserver;
        private System.Windows.Forms.Label label10;
    }
}

