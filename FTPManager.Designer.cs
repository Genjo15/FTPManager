using ComponentFactory.Krypton.Toolkit;
namespace FTPManager
{
    partial class FTPManager
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTPManager));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.FakeLabelForFillingSpace = new System.Windows.Forms.ToolStripStatusLabel();
            this.DirFileCounterLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.SplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.FTPsHeaderGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.ConnectButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.EditButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.AddButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.DeleteButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.SplitContainer2 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.FTPListGroupBox = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.FTPListDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.GeneralControlsGroupBox = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.SplitContainer3 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.ServerInfoGroupBox = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.BackButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.RecoveryDayComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.RecoveryFrequencyComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.FileMaskLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.RecoveryDayLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.RecoveryFrequencyLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.PasswordLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LoginLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ProviderLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.RegionNameLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ServerAddressLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.OkPictureBox = new System.Windows.Forms.PictureBox();
            this.FileMaskTextBox = new System.Windows.Forms.TextBox();
            this.RecoveryDayLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.RecoveryFrequencyLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.FileMaskLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TargetDirectoryButton = new System.Windows.Forms.Button();
            this.TargetDirectoryLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.ProviderTextBox = new System.Windows.Forms.TextBox();
            this.RegionNameTextBox = new System.Windows.Forms.TextBox();
            this.ServerAddressTextBox = new System.Windows.Forms.TextBox();
            this.ServerAddressLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.PasswordLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.LoginLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ProviderLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.RegionNameLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SplitContainer4 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.FTPBrowserHeaderGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.DownloadButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.StopButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.FileExplorerListView = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModificationDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownloadDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileExplorerImageList = new System.Windows.Forms.ImageList(this.components);
            this.Navigator = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.Logcat = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.LogcatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1.Panel1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1.Panel2)).BeginInit();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FTPsHeaderGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTPsHeaderGroup.Panel)).BeginInit();
            this.FTPsHeaderGroup.Panel.SuspendLayout();
            this.FTPsHeaderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2.Panel1)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2.Panel2)).BeginInit();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FTPListGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTPListGroupBox.Panel)).BeginInit();
            this.FTPListGroupBox.Panel.SuspendLayout();
            this.FTPListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FTPListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralControlsGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralControlsGroupBox.Panel)).BeginInit();
            this.GeneralControlsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3.Panel1)).BeginInit();
            this.SplitContainer3.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3.Panel2)).BeginInit();
            this.SplitContainer3.Panel2.SuspendLayout();
            this.SplitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerInfoGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerInfoGroupBox.Panel)).BeginInit();
            this.ServerInfoGroupBox.Panel.SuspendLayout();
            this.ServerInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecoveryDayComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecoveryFrequencyComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4.Panel1)).BeginInit();
            this.SplitContainer4.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4.Panel2)).BeginInit();
            this.SplitContainer4.Panel2.SuspendLayout();
            this.SplitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FTPBrowserHeaderGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTPBrowserHeaderGroup.Panel)).BeginInit();
            this.FTPBrowserHeaderGroup.Panel.SuspendLayout();
            this.FTPBrowserHeaderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Navigator)).BeginInit();
            this.Navigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logcat)).BeginInit();
            this.Logcat.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(900, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            // 
            // KryptonManager
            // 
            this.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = System.Drawing.Color.Transparent;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FakeLabelForFillingSpace,
            this.DirFileCounterLabel,
            this.ProgressLabel,
            this.ProgressBar});
            this.StatusStrip.Location = new System.Drawing.Point(0, 578);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(900, 22);
            this.StatusStrip.TabIndex = 2;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // FakeLabelForFillingSpace
            // 
            this.FakeLabelForFillingSpace.Name = "FakeLabelForFillingSpace";
            this.FakeLabelForFillingSpace.Size = new System.Drawing.Size(666, 17);
            this.FakeLabelForFillingSpace.Spring = true;
            // 
            // DirFileCounterLabel
            // 
            this.DirFileCounterLabel.Name = "DirFileCounterLabel";
            this.DirFileCounterLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(17, 17);
            this.ProgressLabel.Text = " - ";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 24);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.FTPsHeaderGroup);
            this.SplitContainer1.Panel1MinSize = 300;
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.SplitContainer3);
            this.SplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.SplitContainer1.Size = new System.Drawing.Size(900, 554);
            this.SplitContainer1.SplitterDistance = 300;
            this.SplitContainer1.TabIndex = 3;
            // 
            // FTPsHeaderGroup
            // 
            this.FTPsHeaderGroup.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.ConnectButton,
            this.EditButton,
            this.AddButton,
            this.DeleteButton});
            this.FTPsHeaderGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FTPsHeaderGroup.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.TabLowProfile;
            this.FTPsHeaderGroup.HeaderVisibleSecondary = false;
            this.FTPsHeaderGroup.Location = new System.Drawing.Point(0, 0);
            this.FTPsHeaderGroup.Name = "FTPsHeaderGroup";
            this.FTPsHeaderGroup.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            // 
            // FTPsHeaderGroup.Panel
            // 
            this.FTPsHeaderGroup.Panel.Controls.Add(this.SplitContainer2);
            this.FTPsHeaderGroup.Size = new System.Drawing.Size(300, 554);
            this.FTPsHeaderGroup.TabIndex = 0;
            this.FTPsHeaderGroup.ValuesPrimary.Heading = "FTP Manager";
            this.FTPsHeaderGroup.ValuesPrimary.Image = global::FTPManager.Properties.Resources.FTP;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            this.ConnectButton.Image = global::FTPManager.Properties.Resources.Connect;
            this.ConnectButton.UniqueName = "9549667780BF4F3247BE24896229EE83";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            this.EditButton.Image = global::FTPManager.Properties.Resources.Edit;
            this.EditButton.UniqueName = "4AE12EA925EE4A9082B4B10E07546A02";
            // 
            // AddButton
            // 
            this.AddButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
            this.AddButton.Image = global::FTPManager.Properties.Resources.Add;
            this.AddButton.UniqueName = "36BC8132EE134F57CEA2D3C685EB840B";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            this.DeleteButton.Image = global::FTPManager.Properties.Resources.Delete;
            this.DeleteButton.UniqueName = "4266B508A7CA47CD7FB2E3D706AA7252";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.FTPListGroupBox);
            this.SplitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 2);
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.Controls.Add(this.GeneralControlsGroupBox);
            this.SplitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(5, 2, 5, 5);
            this.SplitContainer2.Size = new System.Drawing.Size(298, 517);
            this.SplitContainer2.SplitterDistance = 395;
            this.SplitContainer2.TabIndex = 0;
            // 
            // FTPListGroupBox
            // 
            this.FTPListGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FTPListGroupBox.Location = new System.Drawing.Point(5, 5);
            this.FTPListGroupBox.Name = "FTPListGroupBox";
            this.FTPListGroupBox.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            // 
            // FTPListGroupBox.Panel
            // 
            this.FTPListGroupBox.Panel.Controls.Add(this.FTPListDataGridView);
            this.FTPListGroupBox.Panel.Padding = new System.Windows.Forms.Padding(7);
            this.FTPListGroupBox.Size = new System.Drawing.Size(288, 388);
            this.FTPListGroupBox.TabIndex = 0;
            this.FTPListGroupBox.Values.Heading = "FTP List :";
            // 
            // FTPListDataGridView
            // 
            this.FTPListDataGridView.AllowUserToAddRows = false;
            this.FTPListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FTPListDataGridView.Location = new System.Drawing.Point(7, 7);
            this.FTPListDataGridView.Name = "FTPListDataGridView";
            this.FTPListDataGridView.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.FTPListDataGridView.ReadOnly = true;
            this.FTPListDataGridView.RowHeadersVisible = false;
            this.FTPListDataGridView.Size = new System.Drawing.Size(270, 350);
            this.FTPListDataGridView.TabIndex = 0;
            this.FTPListDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FTPListDataGridView_CellClick);
            this.FTPListDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.FTPListDataGridView_DataBindingComplete);
            // 
            // GeneralControlsGroupBox
            // 
            this.GeneralControlsGroupBox.CaptionOrientation = ComponentFactory.Krypton.Toolkit.ButtonOrientation.FixedTop;
            this.GeneralControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralControlsGroupBox.Location = new System.Drawing.Point(5, 2);
            this.GeneralControlsGroupBox.Name = "GeneralControlsGroupBox";
            this.GeneralControlsGroupBox.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.GeneralControlsGroupBox.Size = new System.Drawing.Size(288, 110);
            this.GeneralControlsGroupBox.TabIndex = 0;
            this.GeneralControlsGroupBox.Values.Heading = "General Controls : ";
            // 
            // SplitContainer3
            // 
            this.SplitContainer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer3.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer3.Name = "SplitContainer3";
            this.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer3.Panel1
            // 
            this.SplitContainer3.Panel1.Controls.Add(this.ServerInfoGroupBox);
            this.SplitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // SplitContainer3.Panel2
            // 
            this.SplitContainer3.Panel2.Controls.Add(this.SplitContainer4);
            this.SplitContainer3.Size = new System.Drawing.Size(595, 554);
            this.SplitContainer3.SplitterDistance = 170;
            this.SplitContainer3.SplitterWidth = 0;
            this.SplitContainer3.TabIndex = 0;
            // 
            // ServerInfoGroupBox
            // 
            this.ServerInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerInfoGroupBox.Location = new System.Drawing.Point(5, 5);
            this.ServerInfoGroupBox.Name = "ServerInfoGroupBox";
            // 
            // ServerInfoGroupBox.Panel
            // 
            this.ServerInfoGroupBox.Panel.Controls.Add(this.BackButton);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.RecoveryDayComboBox);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.RecoveryFrequencyComboBox);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.FileMaskLabel2);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.RecoveryDayLabel2);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.RecoveryFrequencyLabel2);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.PasswordLabel2);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.LoginLabel2);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.ProviderLabel2);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.RegionNameLabel2);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.ServerAddressLabel2);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.OkPictureBox);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.FileMaskTextBox);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.RecoveryDayLabel);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.RecoveryFrequencyLabel);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.FileMaskLabel);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.TargetDirectoryButton);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.TargetDirectoryLabel);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.PasswordTextBox);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.LoginTextBox);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.ProviderTextBox);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.RegionNameTextBox);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.ServerAddressTextBox);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.ServerAddressLabel);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.PasswordLabel);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.LoginLabel);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.ProviderLabel);
            this.ServerInfoGroupBox.Panel.Controls.Add(this.RegionNameLabel);
            this.ServerInfoGroupBox.Size = new System.Drawing.Size(585, 160);
            this.ServerInfoGroupBox.TabIndex = 0;
            this.ServerInfoGroupBox.Values.Heading = "Server Info :";
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.BackButton.Location = new System.Drawing.Point(10, 107);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(38, 24);
            this.BackButton.TabIndex = 29;
            this.BackButton.Values.Image = global::FTPManager.Properties.Resources.Back;
            this.BackButton.Values.Text = "";
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // RecoveryDayComboBox
            // 
            this.RecoveryDayComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RecoveryDayComboBox.DropDownWidth = 184;
            this.RecoveryDayComboBox.Items.AddRange(new object[] {
            "None",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.RecoveryDayComboBox.Location = new System.Drawing.Point(395, 86);
            this.RecoveryDayComboBox.Name = "RecoveryDayComboBox";
            this.RecoveryDayComboBox.Size = new System.Drawing.Size(184, 21);
            this.RecoveryDayComboBox.TabIndex = 28;
            this.RecoveryDayComboBox.Visible = false;
            // 
            // RecoveryFrequencyComboBox
            // 
            this.RecoveryFrequencyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RecoveryFrequencyComboBox.DropDownWidth = 184;
            this.RecoveryFrequencyComboBox.Items.AddRange(new object[] {
            "None",
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly"});
            this.RecoveryFrequencyComboBox.Location = new System.Drawing.Point(395, 64);
            this.RecoveryFrequencyComboBox.Name = "RecoveryFrequencyComboBox";
            this.RecoveryFrequencyComboBox.Size = new System.Drawing.Size(184, 21);
            this.RecoveryFrequencyComboBox.TabIndex = 0;
            this.RecoveryFrequencyComboBox.Visible = false;
            // 
            // FileMaskLabel2
            // 
            this.FileMaskLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FileMaskLabel2.Location = new System.Drawing.Point(395, 42);
            this.FileMaskLabel2.Name = "FileMaskLabel2";
            this.FileMaskLabel2.Size = new System.Drawing.Size(14, 20);
            this.FileMaskLabel2.TabIndex = 25;
            this.FileMaskLabel2.Values.Text = "f";
            // 
            // RecoveryDayLabel2
            // 
            this.RecoveryDayLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RecoveryDayLabel2.Location = new System.Drawing.Point(395, 85);
            this.RecoveryDayLabel2.Name = "RecoveryDayLabel2";
            this.RecoveryDayLabel2.Size = new System.Drawing.Size(17, 20);
            this.RecoveryDayLabel2.TabIndex = 27;
            this.RecoveryDayLabel2.Values.Text = "h";
            // 
            // RecoveryFrequencyLabel2
            // 
            this.RecoveryFrequencyLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RecoveryFrequencyLabel2.Location = new System.Drawing.Point(395, 64);
            this.RecoveryFrequencyLabel2.Name = "RecoveryFrequencyLabel2";
            this.RecoveryFrequencyLabel2.Size = new System.Drawing.Size(18, 20);
            this.RecoveryFrequencyLabel2.TabIndex = 26;
            this.RecoveryFrequencyLabel2.Values.Text = "g";
            // 
            // PasswordLabel2
            // 
            this.PasswordLabel2.Location = new System.Drawing.Point(104, 86);
            this.PasswordLabel2.Name = "PasswordLabel2";
            this.PasswordLabel2.Size = new System.Drawing.Size(17, 20);
            this.PasswordLabel2.TabIndex = 24;
            this.PasswordLabel2.Values.Text = "e";
            // 
            // LoginLabel2
            // 
            this.LoginLabel2.Location = new System.Drawing.Point(104, 64);
            this.LoginLabel2.Name = "LoginLabel2";
            this.LoginLabel2.Size = new System.Drawing.Size(18, 20);
            this.LoginLabel2.TabIndex = 23;
            this.LoginLabel2.Values.Text = "d";
            // 
            // ProviderLabel2
            // 
            this.ProviderLabel2.Location = new System.Drawing.Point(104, 42);
            this.ProviderLabel2.Name = "ProviderLabel2";
            this.ProviderLabel2.Size = new System.Drawing.Size(16, 20);
            this.ProviderLabel2.TabIndex = 22;
            this.ProviderLabel2.Values.Text = "c";
            // 
            // RegionNameLabel2
            // 
            this.RegionNameLabel2.Location = new System.Drawing.Point(104, 21);
            this.RegionNameLabel2.Name = "RegionNameLabel2";
            this.RegionNameLabel2.Size = new System.Drawing.Size(18, 20);
            this.RegionNameLabel2.TabIndex = 21;
            this.RegionNameLabel2.Values.Text = "b";
            // 
            // ServerAddressLabel2
            // 
            this.ServerAddressLabel2.Location = new System.Drawing.Point(104, 0);
            this.ServerAddressLabel2.Name = "ServerAddressLabel2";
            this.ServerAddressLabel2.Size = new System.Drawing.Size(17, 20);
            this.ServerAddressLabel2.TabIndex = 20;
            this.ServerAddressLabel2.Values.Text = "a";
            // 
            // OkPictureBox
            // 
            this.OkPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OkPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.OkPictureBox.Image = global::FTPManager.Properties.Resources.OK;
            this.OkPictureBox.Location = new System.Drawing.Point(233, 111);
            this.OkPictureBox.Name = "OkPictureBox";
            this.OkPictureBox.Size = new System.Drawing.Size(109, 20);
            this.OkPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.OkPictureBox.TabIndex = 19;
            this.OkPictureBox.TabStop = false;
            this.OkPictureBox.Visible = false;
            this.OkPictureBox.Click += new System.EventHandler(this.OkPictureBox_Click);
            // 
            // FileMaskTextBox
            // 
            this.FileMaskTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FileMaskTextBox.Location = new System.Drawing.Point(395, 42);
            this.FileMaskTextBox.Name = "FileMaskTextBox";
            this.FileMaskTextBox.Size = new System.Drawing.Size(184, 20);
            this.FileMaskTextBox.TabIndex = 16;
            this.FileMaskTextBox.Visible = false;
            // 
            // RecoveryDayLabel
            // 
            this.RecoveryDayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RecoveryDayLabel.Location = new System.Drawing.Point(320, 85);
            this.RecoveryDayLabel.Name = "RecoveryDayLabel";
            this.RecoveryDayLabel.Size = new System.Drawing.Size(76, 20);
            this.RecoveryDayLabel.TabIndex = 15;
            this.RecoveryDayLabel.Values.Text = "Recov. Day : ";
            // 
            // RecoveryFrequencyLabel
            // 
            this.RecoveryFrequencyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RecoveryFrequencyLabel.Location = new System.Drawing.Point(285, 64);
            this.RecoveryFrequencyLabel.Name = "RecoveryFrequencyLabel";
            this.RecoveryFrequencyLabel.Size = new System.Drawing.Size(112, 20);
            this.RecoveryFrequencyLabel.TabIndex = 14;
            this.RecoveryFrequencyLabel.Values.Text = "Recov. Frequency : ";
            // 
            // FileMaskLabel
            // 
            this.FileMaskLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FileMaskLabel.Location = new System.Drawing.Point(330, 42);
            this.FileMaskLabel.Name = "FileMaskLabel";
            this.FileMaskLabel.Size = new System.Drawing.Size(67, 20);
            this.FileMaskLabel.TabIndex = 13;
            this.FileMaskLabel.Values.Text = "File mask : ";
            // 
            // TargetDirectoryButton
            // 
            this.TargetDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetDirectoryButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetDirectoryButton.Location = new System.Drawing.Point(460, 20);
            this.TargetDirectoryButton.Name = "TargetDirectoryButton";
            this.TargetDirectoryButton.Size = new System.Drawing.Size(75, 21);
            this.TargetDirectoryButton.TabIndex = 12;
            this.TargetDirectoryButton.Text = "Path";
            this.TargetDirectoryButton.UseVisualStyleBackColor = true;
            this.TargetDirectoryButton.Click += new System.EventHandler(this.TargetDirectoryButton_Click);
            // 
            // TargetDirectoryLabel
            // 
            this.TargetDirectoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetDirectoryLabel.Location = new System.Drawing.Point(294, 21);
            this.TargetDirectoryLabel.Name = "TargetDirectoryLabel";
            this.TargetDirectoryLabel.Size = new System.Drawing.Size(105, 20);
            this.TargetDirectoryLabel.TabIndex = 10;
            this.TargetDirectoryLabel.Values.Text = "Target Directory : ";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PasswordTextBox.Location = new System.Drawing.Point(104, 86);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(184, 20);
            this.PasswordTextBox.TabIndex = 9;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.Visible = false;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LoginTextBox.Location = new System.Drawing.Point(104, 64);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(184, 20);
            this.LoginTextBox.TabIndex = 8;
            this.LoginTextBox.Visible = false;
            // 
            // ProviderTextBox
            // 
            this.ProviderTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProviderTextBox.Location = new System.Drawing.Point(104, 42);
            this.ProviderTextBox.Name = "ProviderTextBox";
            this.ProviderTextBox.Size = new System.Drawing.Size(184, 20);
            this.ProviderTextBox.TabIndex = 7;
            this.ProviderTextBox.Visible = false;
            // 
            // RegionNameTextBox
            // 
            this.RegionNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RegionNameTextBox.Location = new System.Drawing.Point(104, 21);
            this.RegionNameTextBox.Name = "RegionNameTextBox";
            this.RegionNameTextBox.Size = new System.Drawing.Size(184, 20);
            this.RegionNameTextBox.TabIndex = 6;
            this.RegionNameTextBox.Visible = false;
            // 
            // ServerAddressTextBox
            // 
            this.ServerAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerAddressTextBox.Location = new System.Drawing.Point(104, 0);
            this.ServerAddressTextBox.Name = "ServerAddressTextBox";
            this.ServerAddressTextBox.Size = new System.Drawing.Size(474, 20);
            this.ServerAddressTextBox.TabIndex = 5;
            this.ServerAddressTextBox.Visible = false;
            // 
            // ServerAddressLabel
            // 
            this.ServerAddressLabel.Location = new System.Drawing.Point(10, 0);
            this.ServerAddressLabel.Name = "ServerAddressLabel";
            this.ServerAddressLabel.Size = new System.Drawing.Size(98, 20);
            this.ServerAddressLabel.TabIndex = 4;
            this.ServerAddressLabel.Values.Text = "Server Address :";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(37, 86);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(68, 20);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Values.Text = "Password :";
            // 
            // LoginLabel
            // 
            this.LoginLabel.Location = new System.Drawing.Point(57, 64);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(47, 20);
            this.LoginLabel.TabIndex = 2;
            this.LoginLabel.Values.Text = "Login :";
            // 
            // ProviderLabel
            // 
            this.ProviderLabel.Location = new System.Drawing.Point(43, 42);
            this.ProviderLabel.Name = "ProviderLabel";
            this.ProviderLabel.Size = new System.Drawing.Size(62, 20);
            this.ProviderLabel.TabIndex = 1;
            this.ProviderLabel.Values.Text = "Provider :";
            // 
            // RegionNameLabel
            // 
            this.RegionNameLabel.Location = new System.Drawing.Point(16, 21);
            this.RegionNameLabel.Name = "RegionNameLabel";
            this.RegionNameLabel.Size = new System.Drawing.Size(91, 20);
            this.RegionNameLabel.TabIndex = 0;
            this.RegionNameLabel.Values.Text = "Region Name :";
            // 
            // SplitContainer4
            // 
            this.SplitContainer4.Cursor = System.Windows.Forms.Cursors.Default;
            this.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer4.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer4.Name = "SplitContainer4";
            this.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer4.Panel1
            // 
            this.SplitContainer4.Panel1.Controls.Add(this.FTPBrowserHeaderGroup);
            this.SplitContainer4.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // SplitContainer4.Panel2
            // 
            this.SplitContainer4.Panel2.Controls.Add(this.Navigator);
            this.SplitContainer4.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.SplitContainer4.Size = new System.Drawing.Size(595, 384);
            this.SplitContainer4.SplitterDistance = 257;
            this.SplitContainer4.TabIndex = 0;
            // 
            // FTPBrowserHeaderGroup
            // 
            this.FTPBrowserHeaderGroup.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.DownloadButton,
            this.StopButton});
            this.FTPBrowserHeaderGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FTPBrowserHeaderGroup.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.FTPBrowserHeaderGroup.HeaderVisibleSecondary = false;
            this.FTPBrowserHeaderGroup.Location = new System.Drawing.Point(5, 5);
            this.FTPBrowserHeaderGroup.Name = "FTPBrowserHeaderGroup";
            // 
            // FTPBrowserHeaderGroup.Panel
            // 
            this.FTPBrowserHeaderGroup.Panel.Controls.Add(this.FileExplorerListView);
            this.FTPBrowserHeaderGroup.Size = new System.Drawing.Size(585, 247);
            this.FTPBrowserHeaderGroup.TabIndex = 0;
            this.FTPBrowserHeaderGroup.ValuesPrimary.Heading = "FTP Browser :";
            this.FTPBrowserHeaderGroup.ValuesPrimary.Image = null;
            // 
            // DownloadButton
            // 
            this.DownloadButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            this.DownloadButton.Image = global::FTPManager.Properties.Resources.Download;
            this.DownloadButton.UniqueName = "DCE2BEABD68040F447866B52B29228B7";
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
            this.StopButton.Image = global::FTPManager.Properties.Resources.Stop;
            this.StopButton.UniqueName = "93076AB0D33749296E9D9454E999571A";
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // FileExplorerListView
            // 
            this.FileExplorerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.SizeColumn,
            this.ModificationDateColumn,
            this.DownloadDateColumn});
            this.FileExplorerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileExplorerListView.Location = new System.Drawing.Point(0, 0);
            this.FileExplorerListView.MultiSelect = false;
            this.FileExplorerListView.Name = "FileExplorerListView";
            this.FileExplorerListView.Size = new System.Drawing.Size(583, 220);
            this.FileExplorerListView.SmallImageList = this.FileExplorerImageList;
            this.FileExplorerListView.TabIndex = 0;
            this.FileExplorerListView.UseCompatibleStateImageBehavior = false;
            this.FileExplorerListView.View = System.Windows.Forms.View.Details;
            this.FileExplorerListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FileExplorerListView_ColumnClick);
            this.FileExplorerListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.FileExplorerListView_ItemSelectionChanged);
            this.FileExplorerListView.DoubleClick += new System.EventHandler(this.FileExplorerListView_DoubleClick);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 400;
            // 
            // SizeColumn
            // 
            this.SizeColumn.Text = "Size";
            this.SizeColumn.Width = 87;
            // 
            // ModificationDateColumn
            // 
            this.ModificationDateColumn.Text = "Modification Date";
            this.ModificationDateColumn.Width = 150;
            // 
            // DownloadDateColumn
            // 
            this.DownloadDateColumn.Text = "Last Download Date";
            this.DownloadDateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DownloadDateColumn.Width = 320;
            // 
            // FileExplorerImageList
            // 
            this.FileExplorerImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FileExplorerImageList.ImageStream")));
            this.FileExplorerImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FileExplorerImageList.Images.SetKeyName(0, "File.ico");
            this.FileExplorerImageList.Images.SetKeyName(1, "Folder.ico");
            this.FileExplorerImageList.Images.SetKeyName(2, "ParentFolder.ico");
            this.FileExplorerImageList.Images.SetKeyName(3, "Previous.ico");
            this.FileExplorerImageList.Images.SetKeyName(4, "Excel.ico");
            this.FileExplorerImageList.Images.SetKeyName(5, "Zip.ico");
            this.FileExplorerImageList.Images.SetKeyName(6, "rar.ico");
            // 
            // Navigator
            // 
            this.Navigator.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.Navigator.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.Navigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Navigator.Location = new System.Drawing.Point(5, 5);
            this.Navigator.Name = "Navigator";
            this.Navigator.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.Logcat});
            this.Navigator.SelectedIndex = 0;
            this.Navigator.Size = new System.Drawing.Size(585, 112);
            this.Navigator.TabIndex = 0;
            this.Navigator.Text = "kryptonNavigator1";
            // 
            // Logcat
            // 
            this.Logcat.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.Logcat.Controls.Add(this.LogcatRichTextBox);
            this.Logcat.Flags = 65534;
            this.Logcat.LastVisibleSet = true;
            this.Logcat.MinimumSize = new System.Drawing.Size(50, 50);
            this.Logcat.Name = "Logcat";
            this.Logcat.Size = new System.Drawing.Size(583, 85);
            this.Logcat.Text = "Logcat";
            this.Logcat.ToolTipTitle = "Page ToolTip";
            this.Logcat.UniqueName = "E46FA679F6BD4581E09E06E3DA0825C2";
            // 
            // LogcatRichTextBox
            // 
            this.LogcatRichTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.LogcatRichTextBox.DetectUrls = false;
            this.LogcatRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogcatRichTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogcatRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogcatRichTextBox.Name = "LogcatRichTextBox";
            this.LogcatRichTextBox.ReadOnly = true;
            this.LogcatRichTextBox.Size = new System.Drawing.Size(583, 85);
            this.LogcatRichTextBox.TabIndex = 0;
            this.LogcatRichTextBox.Text = "";
            // 
            // FTPManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FTPManager";
            this.Size = new System.Drawing.Size(900, 600);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1.Panel1)).EndInit();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1.Panel2)).EndInit();
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FTPsHeaderGroup.Panel)).EndInit();
            this.FTPsHeaderGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FTPsHeaderGroup)).EndInit();
            this.FTPsHeaderGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2.Panel1)).EndInit();
            this.SplitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2.Panel2)).EndInit();
            this.SplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FTPListGroupBox.Panel)).EndInit();
            this.FTPListGroupBox.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FTPListGroupBox)).EndInit();
            this.FTPListGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FTPListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralControlsGroupBox.Panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralControlsGroupBox)).EndInit();
            this.GeneralControlsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3.Panel1)).EndInit();
            this.SplitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3.Panel2)).EndInit();
            this.SplitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).EndInit();
            this.SplitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServerInfoGroupBox.Panel)).EndInit();
            this.ServerInfoGroupBox.Panel.ResumeLayout(false);
            this.ServerInfoGroupBox.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerInfoGroupBox)).EndInit();
            this.ServerInfoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RecoveryDayComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecoveryFrequencyComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4.Panel1)).EndInit();
            this.SplitContainer4.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4.Panel2)).EndInit();
            this.SplitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4)).EndInit();
            this.SplitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FTPBrowserHeaderGroup.Panel)).EndInit();
            this.FTPBrowserHeaderGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FTPBrowserHeaderGroup)).EndInit();
            this.FTPBrowserHeaderGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Navigator)).EndInit();
            this.Navigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logcat)).EndInit();
            this.Logcat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private ComponentFactory.Krypton.Toolkit.KryptonManager KryptonManager;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer SplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup FTPsHeaderGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer SplitContainer2;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox FTPListGroupBox;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox GeneralControlsGroupBox;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer SplitContainer3;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer SplitContainer4;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator Navigator;
        private ComponentFactory.Krypton.Navigator.KryptonPage Logcat;
        private System.Windows.Forms.RichTextBox LogcatRichTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox ServerInfoGroupBox;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup FTPBrowserHeaderGroup;
        private System.Windows.Forms.ToolStripStatusLabel FakeLabelForFillingSpace;
        private System.Windows.Forms.ToolStripStatusLabel ProgressLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private KryptonDataGridView FTPListDataGridView;
        private KryptonLabel RegionNameLabel;
        private KryptonLabel LoginLabel;
        private KryptonLabel ProviderLabel;
        private KryptonLabel PasswordLabel;
        private KryptonLabel ServerAddressLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox ProviderTextBox;
        private System.Windows.Forms.TextBox RegionNameTextBox;
        private System.Windows.Forms.TextBox ServerAddressTextBox;
        private KryptonLabel TargetDirectoryLabel;
        private System.Windows.Forms.Button TargetDirectoryButton;
        private KryptonLabel RecoveryDayLabel;
        private KryptonLabel RecoveryFrequencyLabel;
        private KryptonLabel FileMaskLabel;
        private System.Windows.Forms.TextBox FileMaskTextBox;
        private System.Windows.Forms.PictureBox OkPictureBox;
        private KryptonLabel ServerAddressLabel2;
        private KryptonLabel FileMaskLabel2;
        private KryptonLabel PasswordLabel2;
        private KryptonLabel LoginLabel2;
        private KryptonLabel ProviderLabel2;
        private KryptonLabel RegionNameLabel2;
        private KryptonLabel RecoveryDayLabel2;
        private KryptonLabel RecoveryFrequencyLabel2;
        private KryptonComboBox RecoveryDayComboBox;
        private KryptonComboBox RecoveryFrequencyComboBox;
        internal ButtonSpecHeaderGroup AddButton;
        internal ButtonSpecHeaderGroup DeleteButton;
        private KryptonButton BackButton;
        private ButtonSpecHeaderGroup EditButton;
        private ButtonSpecHeaderGroup ConnectButton;
        private System.Windows.Forms.ListView FileExplorerListView;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader SizeColumn;
        private System.Windows.Forms.ColumnHeader ModificationDateColumn;
        private System.Windows.Forms.ImageList FileExplorerImageList;
        private System.Windows.Forms.ToolStripStatusLabel DirFileCounterLabel;
        private ButtonSpecHeaderGroup DownloadButton;
        internal ButtonSpecHeaderGroup StopButton;
        private System.Windows.Forms.ColumnHeader DownloadDateColumn;

    }
}
