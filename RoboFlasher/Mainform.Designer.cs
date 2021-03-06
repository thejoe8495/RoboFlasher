﻿namespace RoboFlasher
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
            this.chkAllKnown = new System.Windows.Forms.CheckBox();
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
            this.btnWebinterfaceInstall = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnRunWerbint = new System.Windows.Forms.Button();
            this.lblStatusWI = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstwebinterface = new System.Windows.Forms.ListBox();
            this.tabFirmware = new System.Windows.Forms.TabPage();
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
            this.btnInstallVoicepack = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lstVoices = new System.Windows.Forms.ListBox();
            this.tabExpert = new System.Windows.Forms.TabPage();
            this.cboMiioCommands = new System.Windows.Forms.ComboBox();
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
            this.filewatcher = new System.IO.FileSystemWatcher();
            this.cbolisten = new System.Windows.Forms.ComboBox();
            this.metroTabControl1.SuspendLayout();
            this.tabDevice.SuspendLayout();
            this.tabWebinterface.SuspendLayout();
            this.tabFirmware.SuspendLayout();
            this.tabPackFirmware.SuspendLayout();
            this.tabVoiceinstall.SuspendLayout();
            this.tabExpert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filewatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // txtlog
            // 
            this.txtlog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlog.Location = new System.Drawing.Point(33, 526);
            this.txtlog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtlog.Multiline = true;
            this.txtlog.Name = "txtlog";
            this.txtlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtlog.Size = new System.Drawing.Size(1100, 106);
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
            this.metroTabControl1.Location = new System.Drawing.Point(29, 76);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1107, 418);
            this.metroTabControl1.TabIndex = 19;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabDevice
            // 
            this.tabDevice.Controls.Add(this.cbolisten);
            this.tabDevice.Controls.Add(this.chkAllKnown);
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
            this.tabDevice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Size = new System.Drawing.Size(1099, 376);
            this.tabDevice.TabIndex = 0;
            this.tabDevice.Text = "Device";
            // 
            // chkAllKnown
            // 
            this.chkAllKnown.AutoSize = true;
            this.chkAllKnown.Checked = true;
            this.chkAllKnown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllKnown.Location = new System.Drawing.Point(701, 233);
            this.chkAllKnown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAllKnown.Name = "chkAllKnown";
            this.chkAllKnown.Size = new System.Drawing.Size(176, 21);
            this.chkAllKnown.TabIndex = 41;
            this.chkAllKnown.Text = "show all known devices";
            this.chkAllKnown.UseVisualStyleBackColor = true;
            this.chkAllKnown.CheckedChanged += new System.EventHandler(this.chkAllKnown_CheckedChanged);
            // 
            // llbWebserver
            // 
            this.llbWebserver.AutoSize = true;
            this.llbWebserver.Location = new System.Drawing.Point(400, 178);
            this.llbWebserver.Name = "llbWebserver";
            this.llbWebserver.Size = new System.Drawing.Size(91, 17);
            this.llbWebserver.TabIndex = 40;
            this.llbWebserver.TabStop = true;
            this.llbWebserver.Text = "llbWebserver";
            this.llbWebserver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbWebserver_LinkClicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 178);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 39;
            this.label10.Text = "Local URL";
            // 
            // lblErrorToken
            // 
            this.lblErrorToken.AutoSize = true;
            this.lblErrorToken.ForeColor = System.Drawing.Color.Maroon;
            this.lblErrorToken.Location = new System.Drawing.Point(481, 78);
            this.lblErrorToken.Name = "lblErrorToken";
            this.lblErrorToken.Size = new System.Drawing.Size(0, 17);
            this.lblErrorToken.TabIndex = 38;
            // 
            // btnSearchKey
            // 
            this.btnSearchKey.Location = new System.Drawing.Point(481, 106);
            this.btnSearchKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchKey.Name = "btnSearchKey";
            this.btnSearchKey.Size = new System.Drawing.Size(36, 27);
            this.btnSearchKey.TabIndex = 37;
            this.btnSearchKey.Text = "...";
            this.btnSearchKey.UseVisualStyleBackColor = true;
            this.btnSearchKey.Click += new System.EventHandler(this.btnSearchKey_Click);
            // 
            // btnGenerateNew
            // 
            this.btnGenerateNew.Location = new System.Drawing.Point(523, 106);
            this.btnGenerateNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerateNew.Name = "btnGenerateNew";
            this.btnGenerateNew.Size = new System.Drawing.Size(164, 27);
            this.btnGenerateNew.TabIndex = 36;
            this.btnGenerateNew.Text = "Generate New";
            this.btnGenerateNew.UseVisualStyleBackColor = true;
            this.btnGenerateNew.Click += new System.EventHandler(this.btnGenerateNew_Click);
            // 
            // txtKeyPassword
            // 
            this.txtKeyPassword.Location = new System.Drawing.Point(138, 143);
            this.txtKeyPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKeyPassword.Name = "txtKeyPassword";
            this.txtKeyPassword.Size = new System.Drawing.Size(338, 22);
            this.txtKeyPassword.TabIndex = 35;
            // 
            // txtRsaKey
            // 
            this.txtRsaKey.Location = new System.Drawing.Point(138, 110);
            this.txtRsaKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRsaKey.Name = "txtRsaKey";
            this.txtRsaKey.Size = new System.Drawing.Size(338, 22);
            this.txtRsaKey.TabIndex = 34;
            this.txtRsaKey.Text = "rsaKey";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 143);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 31;
            this.label7.Text = "Keyfiles password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "SSH key";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(701, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Found devices:";
            // 
            // lstdevices
            // 
            this.lstdevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstdevices.DisplayMember = "Devicename";
            this.lstdevices.FormattingEnabled = true;
            this.lstdevices.ItemHeight = 16;
            this.lstdevices.Location = new System.Drawing.Point(701, 62);
            this.lstdevices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstdevices.Name = "lstdevices";
            this.lstdevices.Size = new System.Drawing.Size(375, 164);
            this.lstdevices.TabIndex = 24;
            this.lstdevices.SelectedIndexChanged += new System.EventHandler(this.lstdevices_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Token";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(138, 78);
            this.txtToken.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(338, 22);
            this.txtToken.TabIndex = 22;
            this.txtToken.Text = "00000000000000000000000000000000";
            this.txtToken.TextChanged += new System.EventHandler(this.txtToken_TextChanged);
            // 
            // btnDiscoverDevices
            // 
            this.btnDiscoverDevices.Location = new System.Drawing.Point(841, 27);
            this.btnDiscoverDevices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDiscoverDevices.Name = "btnDiscoverDevices";
            this.btnDiscoverDevices.Size = new System.Drawing.Size(235, 28);
            this.btnDiscoverDevices.TabIndex = 21;
            this.btnDiscoverDevices.Text = "Discover devices";
            this.btnDiscoverDevices.UseVisualStyleBackColor = true;
            this.btnDiscoverDevices.Click += new System.EventHandler(this.btndiscover_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "IP address:";
            // 
            // txtipadress
            // 
            this.txtipadress.Location = new System.Drawing.Point(138, 50);
            this.txtipadress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtipadress.Name = "txtipadress";
            this.txtipadress.Size = new System.Drawing.Size(146, 22);
            this.txtipadress.TabIndex = 19;
            // 
            // tabWebinterface
            // 
            this.tabWebinterface.Controls.Add(this.btnWebinterfaceDownload);
            this.tabWebinterface.Controls.Add(this.btnWebinterfaceInstall);
            this.tabWebinterface.Controls.Add(this.label14);
            this.tabWebinterface.Controls.Add(this.btnRunWerbint);
            this.tabWebinterface.Controls.Add(this.lblStatusWI);
            this.tabWebinterface.Controls.Add(this.label2);
            this.tabWebinterface.Controls.Add(this.lstwebinterface);
            this.tabWebinterface.Location = new System.Drawing.Point(4, 38);
            this.tabWebinterface.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabWebinterface.Name = "tabWebinterface";
            this.tabWebinterface.Size = new System.Drawing.Size(1099, 376);
            this.tabWebinterface.TabIndex = 1;
            this.tabWebinterface.Text = "Webinterface";
            // 
            // btnWebinterfaceDownload
            // 
            this.btnWebinterfaceDownload.Location = new System.Drawing.Point(824, 234);
            this.btnWebinterfaceDownload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWebinterfaceDownload.Name = "btnWebinterfaceDownload";
            this.btnWebinterfaceDownload.Size = new System.Drawing.Size(253, 46);
            this.btnWebinterfaceDownload.TabIndex = 30;
            this.btnWebinterfaceDownload.Text = "Download selected";
            this.btnWebinterfaceDownload.UseVisualStyleBackColor = true;
            // 
            // btnWebinterfaceInstall
            // 
            this.btnWebinterfaceInstall.Location = new System.Drawing.Point(368, 59);
            this.btnWebinterfaceInstall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWebinterfaceInstall.Name = "btnWebinterfaceInstall";
            this.btnWebinterfaceInstall.Size = new System.Drawing.Size(145, 45);
            this.btnWebinterfaceInstall.TabIndex = 28;
            this.btnWebinterfaceInstall.Text = "install Webinterface";
            this.btnWebinterfaceInstall.UseVisualStyleBackColor = true;
            this.btnWebinterfaceInstall.Click += new System.EventHandler(this.btnWebinterfaceInstall_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 17);
            this.label14.TabIndex = 26;
            this.label14.Text = "Webinterface state:";
            // 
            // btnRunWerbint
            // 
            this.btnRunWerbint.Location = new System.Drawing.Point(368, 234);
            this.btnRunWerbint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRunWerbint.Name = "btnRunWerbint";
            this.btnRunWerbint.Size = new System.Drawing.Size(233, 46);
            this.btnRunWerbint.TabIndex = 25;
            this.btnRunWerbint.Text = "Run Webinterface per SSH";
            this.btnRunWerbint.UseVisualStyleBackColor = true;
            this.btnRunWerbint.Click += new System.EventHandler(this.btnRunWerbint_Click);
            // 
            // lblStatusWI
            // 
            this.lblStatusWI.AutoSize = true;
            this.lblStatusWI.Location = new System.Drawing.Point(200, 248);
            this.lblStatusWI.Name = "lblStatusWI";
            this.lblStatusWI.Size = new System.Drawing.Size(59, 17);
            this.lblStatusWI.TabIndex = 24;
            this.lblStatusWI.Text = "pending";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Update webinterface";
            // 
            // lstwebinterface
            // 
            this.lstwebinterface.DisplayMember = "Linetext";
            this.lstwebinterface.FormattingEnabled = true;
            this.lstwebinterface.ItemHeight = 16;
            this.lstwebinterface.Location = new System.Drawing.Point(27, 58);
            this.lstwebinterface.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstwebinterface.Name = "lstwebinterface";
            this.lstwebinterface.Size = new System.Drawing.Size(304, 164);
            this.lstwebinterface.TabIndex = 17;
            // 
            // tabFirmware
            // 
            this.tabFirmware.Controls.Add(this.btnInstallFirmware);
            this.tabFirmware.Controls.Add(this.label5);
            this.tabFirmware.Controls.Add(this.lstfirmware);
            this.tabFirmware.Location = new System.Drawing.Point(4, 38);
            this.tabFirmware.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFirmware.Name = "tabFirmware";
            this.tabFirmware.Size = new System.Drawing.Size(1099, 376);
            this.tabFirmware.TabIndex = 2;
            this.tabFirmware.Text = "Firmware";
            // 
            // btnInstallFirmware
            // 
            this.btnInstallFirmware.Location = new System.Drawing.Point(366, 58);
            this.btnInstallFirmware.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInstallFirmware.Name = "btnInstallFirmware";
            this.btnInstallFirmware.Size = new System.Drawing.Size(146, 52);
            this.btnInstallFirmware.TabIndex = 23;
            this.btnInstallFirmware.Text = "Install firmware";
            this.btnInstallFirmware.UseVisualStyleBackColor = true;
            this.btnInstallFirmware.Click += new System.EventHandler(this.btnInstallFirmware_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Update custom firmware";
            // 
            // lstfirmware
            // 
            this.lstfirmware.DisplayMember = "Linetext";
            this.lstfirmware.FormattingEnabled = true;
            this.lstfirmware.ItemHeight = 16;
            this.lstfirmware.Location = new System.Drawing.Point(28, 58);
            this.lstfirmware.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstfirmware.Name = "lstfirmware";
            this.lstfirmware.Size = new System.Drawing.Size(304, 164);
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
            this.tabPackFirmware.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPackFirmware.Name = "tabPackFirmware";
            this.tabPackFirmware.Size = new System.Drawing.Size(1099, 376);
            this.tabPackFirmware.TabIndex = 5;
            this.tabPackFirmware.Text = "Create Firmware";
            // 
            // chkGenerateSshKey
            // 
            this.chkGenerateSshKey.AutoSize = true;
            this.chkGenerateSshKey.Checked = true;
            this.chkGenerateSshKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenerateSshKey.Location = new System.Drawing.Point(46, 187);
            this.chkGenerateSshKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkGenerateSshKey.Name = "chkGenerateSshKey";
            this.chkGenerateSshKey.Size = new System.Drawing.Size(248, 21);
            this.chkGenerateSshKey.TabIndex = 29;
            this.chkGenerateSshKey.Text = "generate new SSH key if not exists";
            this.chkGenerateSshKey.UseVisualStyleBackColor = true;
            // 
            // btnPackandFlash
            // 
            this.btnPackandFlash.Enabled = false;
            this.btnPackandFlash.Location = new System.Drawing.Point(46, 230);
            this.btnPackandFlash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPackandFlash.Name = "btnPackandFlash";
            this.btnPackandFlash.Size = new System.Drawing.Size(256, 83);
            this.btnPackandFlash.TabIndex = 28;
            this.btnPackandFlash.Text = "Pack and Flash";
            this.btnPackandFlash.UseVisualStyleBackColor = true;
            this.btnPackandFlash.Click += new System.EventHandler(this.btnPackandFlash_Click);
            // 
            // cboWebinterface
            // 
            this.cboWebinterface.FormattingEnabled = true;
            this.cboWebinterface.Location = new System.Drawing.Point(46, 149);
            this.cboWebinterface.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboWebinterface.Name = "cboWebinterface";
            this.cboWebinterface.Size = new System.Drawing.Size(256, 24);
            this.cboWebinterface.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 17);
            this.label13.TabIndex = 26;
            this.label13.Text = "Install webinterface";
            // 
            // cboVoicepacks
            // 
            this.cboVoicepacks.FormattingEnabled = true;
            this.cboVoicepacks.Location = new System.Drawing.Point(46, 98);
            this.cboVoicepacks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboVoicepacks.Name = "cboVoicepacks";
            this.cboVoicepacks.Size = new System.Drawing.Size(256, 24);
            this.cboVoicepacks.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(46, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "Install sound";
            // 
            // cboFirmware
            // 
            this.cboFirmware.FormattingEnabled = true;
            this.cboFirmware.Location = new System.Drawing.Point(46, 50);
            this.cboFirmware.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboFirmware.Name = "cboFirmware";
            this.cboFirmware.Size = new System.Drawing.Size(256, 24);
            this.cboFirmware.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 34);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Original firmware";
            // 
            // tabVoiceinstall
            // 
            this.tabVoiceinstall.Controls.Add(this.btnInstallVoicepack);
            this.tabVoiceinstall.Controls.Add(this.label8);
            this.tabVoiceinstall.Controls.Add(this.lstVoices);
            this.tabVoiceinstall.Location = new System.Drawing.Point(4, 38);
            this.tabVoiceinstall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabVoiceinstall.Name = "tabVoiceinstall";
            this.tabVoiceinstall.Size = new System.Drawing.Size(1099, 376);
            this.tabVoiceinstall.TabIndex = 3;
            this.tabVoiceinstall.Text = "Voices";
            // 
            // btnInstallVoicepack
            // 
            this.btnInstallVoicepack.Location = new System.Drawing.Point(364, 55);
            this.btnInstallVoicepack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInstallVoicepack.Name = "btnInstallVoicepack";
            this.btnInstallVoicepack.Size = new System.Drawing.Size(146, 53);
            this.btnInstallVoicepack.TabIndex = 27;
            this.btnInstallVoicepack.Text = "install voicepack";
            this.btnInstallVoicepack.UseVisualStyleBackColor = true;
            this.btnInstallVoicepack.Click += new System.EventHandler(this.btnInstallVoicepack_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 35);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Install sounds";
            // 
            // lstVoices
            // 
            this.lstVoices.DisplayMember = "Linetext";
            this.lstVoices.FormattingEnabled = true;
            this.lstVoices.ItemHeight = 16;
            this.lstVoices.Location = new System.Drawing.Point(24, 54);
            this.lstVoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstVoices.Name = "lstVoices";
            this.lstVoices.Size = new System.Drawing.Size(304, 164);
            this.lstVoices.TabIndex = 22;
            // 
            // tabExpert
            // 
            this.tabExpert.Controls.Add(this.cboMiioCommands);
            this.tabExpert.Controls.Add(this.lblsshcomman);
            this.tabExpert.Controls.Add(this.txtSshCommand);
            this.tabExpert.Controls.Add(this.btnSshCommand);
            this.tabExpert.Controls.Add(this.txtMiiOParams);
            this.tabExpert.Controls.Add(this.txtMiioParameter);
            this.tabExpert.Controls.Add(this.btnMiioCommand);
            this.tabExpert.Controls.Add(this.txtMiioCommand);
            this.tabExpert.Controls.Add(this.label9);
            this.tabExpert.Location = new System.Drawing.Point(4, 38);
            this.tabExpert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabExpert.Name = "tabExpert";
            this.tabExpert.Size = new System.Drawing.Size(1099, 376);
            this.tabExpert.TabIndex = 4;
            this.tabExpert.Text = "Expert";
            // 
            // cboMiioCommands
            // 
            this.cboMiioCommands.FormattingEnabled = true;
            this.cboMiioCommands.Items.AddRange(new object[] {
            "--",
            "miIO.config_router",
            "miIO.info",
            "miIO.get_ota_progress",
            "miIO.get_ota_state",
            "enable_log_upload",
            "disable_log_upload"});
            this.cboMiioCommands.Location = new System.Drawing.Point(188, 33);
            this.cboMiioCommands.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMiioCommands.Name = "cboMiioCommands";
            this.cboMiioCommands.Size = new System.Drawing.Size(172, 24);
            this.cboMiioCommands.TabIndex = 8;
            this.cboMiioCommands.SelectedIndexChanged += new System.EventHandler(this.cboMiioCommands_SelectedIndexChanged);
            // 
            // lblsshcomman
            // 
            this.lblsshcomman.AutoSize = true;
            this.lblsshcomman.Location = new System.Drawing.Point(35, 223);
            this.lblsshcomman.Name = "lblsshcomman";
            this.lblsshcomman.Size = new System.Drawing.Size(142, 17);
            this.lblsshcomman.TabIndex = 7;
            this.lblsshcomman.Text = "Send SSH command:";
            // 
            // txtSshCommand
            // 
            this.txtSshCommand.Location = new System.Drawing.Point(188, 220);
            this.txtSshCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSshCommand.Name = "txtSshCommand";
            this.txtSshCommand.Size = new System.Drawing.Size(249, 22);
            this.txtSshCommand.TabIndex = 6;
            // 
            // btnSshCommand
            // 
            this.btnSshCommand.Location = new System.Drawing.Point(458, 217);
            this.btnSshCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSshCommand.Name = "btnSshCommand";
            this.btnSshCommand.Size = new System.Drawing.Size(304, 28);
            this.btnSshCommand.TabIndex = 5;
            this.btnSshCommand.Text = "Send SSH Command";
            this.btnSshCommand.UseVisualStyleBackColor = true;
            this.btnSshCommand.Click += new System.EventHandler(this.btnSshCommand_Click);
            // 
            // txtMiiOParams
            // 
            this.txtMiiOParams.AutoSize = true;
            this.txtMiiOParams.Location = new System.Drawing.Point(460, 11);
            this.txtMiiOParams.Name = "txtMiiOParams";
            this.txtMiiOParams.Size = new System.Drawing.Size(118, 17);
            this.txtMiiOParams.TabIndex = 4;
            this.txtMiiOParams.Text = "Params as jquery";
            // 
            // txtMiioParameter
            // 
            this.txtMiioParameter.Location = new System.Drawing.Point(458, 35);
            this.txtMiioParameter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMiioParameter.Multiline = true;
            this.txtMiioParameter.Name = "txtMiioParameter";
            this.txtMiioParameter.Size = new System.Drawing.Size(401, 169);
            this.txtMiioParameter.TabIndex = 3;
            // 
            // btnMiioCommand
            // 
            this.btnMiioCommand.Location = new System.Drawing.Point(878, 35);
            this.btnMiioCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMiioCommand.Name = "btnMiioCommand";
            this.btnMiioCommand.Size = new System.Drawing.Size(195, 27);
            this.btnMiioCommand.TabIndex = 2;
            this.btnMiioCommand.Text = "Send MiiO";
            this.btnMiioCommand.UseVisualStyleBackColor = true;
            this.btnMiioCommand.Click += new System.EventHandler(this.btnMiioCommand_Click);
            // 
            // txtMiioCommand
            // 
            this.txtMiioCommand.Location = new System.Drawing.Point(188, 65);
            this.txtMiioCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMiioCommand.Name = "txtMiioCommand";
            this.txtMiioCommand.Size = new System.Drawing.Size(249, 22);
            this.txtMiioCommand.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 17);
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
            this.label15.Location = new System.Drawing.Point(34, 504);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 17);
            this.label15.TabIndex = 29;
            this.label15.Text = "Progress by MiiO";
            // 
            // prgMiiO
            // 
            this.prgMiiO.Location = new System.Drawing.Point(163, 499);
            this.prgMiiO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prgMiiO.Name = "prgMiiO";
            this.prgMiiO.Size = new System.Drawing.Size(403, 21);
            this.prgMiiO.TabIndex = 30;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(958, 36);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(189, 40);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Refresh files and web";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // filewatcher
            // 
            this.filewatcher.EnableRaisingEvents = true;
            this.filewatcher.IncludeSubdirectories = true;
            this.filewatcher.Path = "./";
            this.filewatcher.SynchronizingObject = this;
            this.filewatcher.Changed += new System.IO.FileSystemEventHandler(this.filewatcher_Changed);
            // 
            // cbolisten
            // 
            this.cbolisten.FormattingEnabled = true;
            this.cbolisten.Location = new System.Drawing.Point(138, 178);
            this.cbolisten.Name = "cbolisten";
            this.cbolisten.Size = new System.Drawing.Size(256, 24);
            this.cbolisten.TabIndex = 42;
            this.cbolisten.SelectedIndexChanged += new System.EventHandler(this.cbolisten_SelectedIndexChanged);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 660);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.prgMiiO);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.txtlog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Mainform";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "RoboFlasher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainform_FormClosing);
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
            ((System.ComponentModel.ISupportInitialize)(this.filewatcher)).EndInit();
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
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.LinkLabel llbWebserver;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkAllKnown;
        private System.Windows.Forms.ComboBox cboMiioCommands;
        private System.IO.FileSystemWatcher filewatcher;
        private System.Windows.Forms.ComboBox cbolisten;
    }
}

