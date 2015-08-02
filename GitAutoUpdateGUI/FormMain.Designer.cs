namespace GitAutoUpdateGUI
{
  partial class FormMain
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

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
      System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.personalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.languagetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.labelChooseVSVersion = new System.Windows.Forms.Label();
      this.textBoxVSProjectPath = new System.Windows.Forms.TextBox();
      this.comboBoxVSVersion = new System.Windows.Forms.ComboBox();
      this.buttonVSVersionGetPath = new System.Windows.Forms.Button();
      this.checkBoxGitBashInstalled = new System.Windows.Forms.CheckBox();
      this.labelSelectVSProjects = new System.Windows.Forms.Label();
      this.listViewVSProjects = new System.Windows.Forms.ListView();
      this.labelPickDirectory = new System.Windows.Forms.Label();
      this.buttonUpdateVSProjects = new System.Windows.Forms.Button();
      this.textBoxGitBashBinariesPath = new System.Windows.Forms.TextBox();
      this.buttonGitBashBinPath = new System.Windows.Forms.Button();
      this.buttonScannWholePC = new System.Windows.Forms.Button();
      this.textBoxLog = new System.Windows.Forms.TextBox();
      this.buttonLoadVSProjects = new System.Windows.Forms.Button();
      this.checkBoxCreateUpdateFile = new System.Windows.Forms.CheckBox();
      this.buttonCheckUncheckAll = new System.Windows.Forms.Button();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.languagetoolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(1021, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
      this.fileToolStripMenuItem.Text = "&Fichier";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.newToolStripMenuItem.Text = "&Nouveau";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.openToolStripMenuItem.Text = "&Ouvrir";
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size(202, 6);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.saveToolStripMenuItem.Text = "&Enregistrer";
      // 
      // saveasToolStripMenuItem
      // 
      this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
      this.saveasToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.saveasToolStripMenuItem.Text = "Enregistrer &sous";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
      // 
      // printToolStripMenuItem
      // 
      this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printToolStripMenuItem.Name = "printToolStripMenuItem";
      this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.printToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.printToolStripMenuItem.Text = "&Imprimer";
      // 
      // printPreviewToolStripMenuItem
      // 
      this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
      this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.printPreviewToolStripMenuItem.Text = "Aperçu a&vant impression";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
      // 
      // quitToolStripMenuItem
      // 
      this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
      this.quitToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
      this.quitToolStripMenuItem.Text = "&Quitter";
      this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItemClick);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
      this.editToolStripMenuItem.Text = "&Edition";
      // 
      // cancelToolStripMenuItem
      // 
      this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
      this.cancelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.cancelToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.cancelToolStripMenuItem.Text = "&Annuler";
      // 
      // redoToolStripMenuItem
      // 
      this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
      this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
      this.redoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.redoToolStripMenuItem.Text = "&Rétablir";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
      // 
      // cutToolStripMenuItem
      // 
      this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
      this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.cutToolStripMenuItem.Text = "&Couper";
      this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItemClick);
      // 
      // copyToolStripMenuItem
      // 
      this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.copyToolStripMenuItem.Text = "Co&pier";
      this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
      // 
      // pasteToolStripMenuItem
      // 
      this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
      this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.pasteToolStripMenuItem.Text = "Co&ller";
      this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItemClick);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
      // 
      // selectAllToolStripMenuItem
      // 
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.selectAllToolStripMenuItem.Text = "Sélectio&nner tout";
      this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItemClick);
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
      this.toolsToolStripMenuItem.Text = "&Outils";
      // 
      // personalizeToolStripMenuItem
      // 
      this.personalizeToolStripMenuItem.Name = "personalizeToolStripMenuItem";
      this.personalizeToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.personalizeToolStripMenuItem.Text = "&Personnaliser";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.optionsToolStripMenuItem.Text = "&Options";
      // 
      // languagetoolStripMenuItem
      // 
      this.languagetoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frenchToolStripMenuItem,
            this.englishToolStripMenuItem});
      this.languagetoolStripMenuItem.Name = "languagetoolStripMenuItem";
      this.languagetoolStripMenuItem.Size = new System.Drawing.Size(71, 20);
      this.languagetoolStripMenuItem.Text = "Language";
      // 
      // frenchToolStripMenuItem
      // 
      this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
      this.frenchToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.frenchToolStripMenuItem.Text = "Français";
      this.frenchToolStripMenuItem.Click += new System.EventHandler(this.FrenchToolStripMenuItemClick);
      // 
      // englishToolStripMenuItem
      // 
      this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
      this.englishToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
      this.englishToolStripMenuItem.Text = "Anglais";
      this.englishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItemClick);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summaryToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
      this.helpToolStripMenuItem.Text = "&Aide";
      // 
      // summaryToolStripMenuItem
      // 
      this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
      this.summaryToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
      this.summaryToolStripMenuItem.Text = "&Sommaire";
      // 
      // indexToolStripMenuItem
      // 
      this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
      this.indexToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
      this.indexToolStripMenuItem.Text = "&Index";
      // 
      // searchToolStripMenuItem
      // 
      this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
      this.searchToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
      this.searchToolStripMenuItem.Text = "&Rechercher";
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(144, 6);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
      this.aboutToolStripMenuItem.Text = "À &propos de...";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
      // 
      // labelChooseVSVersion
      // 
      this.labelChooseVSVersion.AutoSize = true;
      this.labelChooseVSVersion.Location = new System.Drawing.Point(22, 64);
      this.labelChooseVSVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelChooseVSVersion.Name = "labelChooseVSVersion";
      this.labelChooseVSVersion.Size = new System.Drawing.Size(165, 13);
      this.labelChooseVSVersion.TabIndex = 2;
      this.labelChooseVSVersion.Text = "Choose the Visual Studio version:";
      // 
      // textBoxVSProjectPath
      // 
      this.textBoxVSProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxVSProjectPath.Location = new System.Drawing.Point(536, 63);
      this.textBoxVSProjectPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.textBoxVSProjectPath.Name = "textBoxVSProjectPath";
      this.textBoxVSProjectPath.Size = new System.Drawing.Size(468, 20);
      this.textBoxVSProjectPath.TabIndex = 3;
      this.textBoxVSProjectPath.Text = "C:\\";
      this.textBoxVSProjectPath.TextChanged += new System.EventHandler(this.TextBoxVsProjectPathTextChanged);
      // 
      // comboBoxVSVersion
      // 
      this.comboBoxVSVersion.FormattingEnabled = true;
      this.comboBoxVSVersion.Location = new System.Drawing.Point(215, 62);
      this.comboBoxVSVersion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.comboBoxVSVersion.Name = "comboBoxVSVersion";
      this.comboBoxVSVersion.Size = new System.Drawing.Size(129, 21);
      this.comboBoxVSVersion.TabIndex = 4;
      this.comboBoxVSVersion.Text = "Visual Studio Version";
      this.comboBoxVSVersion.SelectedIndexChanged += new System.EventHandler(this.comboBoxVSVersion_SelectedIndexChanged);
      // 
      // buttonVSVersionGetPath
      // 
      this.buttonVSVersionGetPath.Location = new System.Drawing.Point(497, 63);
      this.buttonVSVersionGetPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.buttonVSVersionGetPath.Name = "buttonVSVersionGetPath";
      this.buttonVSVersionGetPath.Size = new System.Drawing.Size(28, 19);
      this.buttonVSVersionGetPath.TabIndex = 5;
      this.buttonVSVersionGetPath.Text = "...";
      this.buttonVSVersionGetPath.UseVisualStyleBackColor = true;
      this.buttonVSVersionGetPath.Click += new System.EventHandler(this.ButtonVsVersionGetPathClick);
      // 
      // checkBoxGitBashInstalled
      // 
      this.checkBoxGitBashInstalled.AutoSize = true;
      this.checkBoxGitBashInstalled.Enabled = false;
      this.checkBoxGitBashInstalled.Location = new System.Drawing.Point(25, 101);
      this.checkBoxGitBashInstalled.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.checkBoxGitBashInstalled.Name = "checkBoxGitBashInstalled";
      this.checkBoxGitBashInstalled.Size = new System.Drawing.Size(104, 17);
      this.checkBoxGitBashInstalled.TabIndex = 6;
      this.checkBoxGitBashInstalled.Text = "GitBash installed";
      this.checkBoxGitBashInstalled.UseVisualStyleBackColor = true;
      // 
      // labelSelectVSProjects
      // 
      this.labelSelectVSProjects.AutoSize = true;
      this.labelSelectVSProjects.Location = new System.Drawing.Point(22, 136);
      this.labelSelectVSProjects.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelSelectVSProjects.Name = "labelSelectVSProjects";
      this.labelSelectVSProjects.Size = new System.Drawing.Size(253, 13);
      this.labelSelectVSProjects.TabIndex = 7;
      this.labelSelectVSProjects.Text = "Select the Visual Studio projects you want to update";
      // 
      // listViewVSProjects
      // 
      this.listViewVSProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listViewVSProjects.GridLines = true;
      listViewGroup1.Header = "ListViewGroup";
      listViewGroup1.Name = "listViewGroup1";
      listViewGroup2.Header = "ListViewGroup";
      listViewGroup2.Name = "listViewGroup2";
      this.listViewVSProjects.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
      this.listViewVSProjects.Location = new System.Drawing.Point(25, 311);
      this.listViewVSProjects.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.listViewVSProjects.Name = "listViewVSProjects";
      this.listViewVSProjects.Size = new System.Drawing.Size(979, 114);
      this.listViewVSProjects.TabIndex = 8;
      this.listViewVSProjects.UseCompatibleStateImageBehavior = false;
      // 
      // labelPickDirectory
      // 
      this.labelPickDirectory.AutoSize = true;
      this.labelPickDirectory.Location = new System.Drawing.Point(361, 64);
      this.labelPickDirectory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelPickDirectory.Name = "labelPickDirectory";
      this.labelPickDirectory.Size = new System.Drawing.Size(82, 13);
      this.labelPickDirectory.TabIndex = 9;
      this.labelPickDirectory.Text = "or pick directory";
      // 
      // buttonUpdateVSProjects
      // 
      this.buttonUpdateVSProjects.Enabled = false;
      this.buttonUpdateVSProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonUpdateVSProjects.Location = new System.Drawing.Point(647, 129);
      this.buttonUpdateVSProjects.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.buttonUpdateVSProjects.Name = "buttonUpdateVSProjects";
      this.buttonUpdateVSProjects.Size = new System.Drawing.Size(235, 26);
      this.buttonUpdateVSProjects.TabIndex = 10;
      this.buttonUpdateVSProjects.Text = "Update selected Visual Studio Projects";
      this.buttonUpdateVSProjects.UseVisualStyleBackColor = true;
      this.buttonUpdateVSProjects.Click += new System.EventHandler(this.ButtonUpdateVsProjectsClick);
      // 
      // textBoxGitBashBinariesPath
      // 
      this.textBoxGitBashBinariesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxGitBashBinariesPath.Location = new System.Drawing.Point(205, 99);
      this.textBoxGitBashBinariesPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.textBoxGitBashBinariesPath.Name = "textBoxGitBashBinariesPath";
      this.textBoxGitBashBinariesPath.Size = new System.Drawing.Size(799, 20);
      this.textBoxGitBashBinariesPath.TabIndex = 11;
      this.textBoxGitBashBinariesPath.Text = "C:\\";
      this.textBoxGitBashBinariesPath.TextChanged += new System.EventHandler(this.TextBoxGitBashBinariesPathTextChanged);
      // 
      // buttonGitBashBinPath
      // 
      this.buttonGitBashBinPath.Location = new System.Drawing.Point(169, 98);
      this.buttonGitBashBinPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.buttonGitBashBinPath.Name = "buttonGitBashBinPath";
      this.buttonGitBashBinPath.Size = new System.Drawing.Size(28, 19);
      this.buttonGitBashBinPath.TabIndex = 12;
      this.buttonGitBashBinPath.Text = "...";
      this.buttonGitBashBinPath.UseVisualStyleBackColor = true;
      this.buttonGitBashBinPath.Click += new System.EventHandler(this.ButtonGitBashBinPathClick);
      // 
      // buttonScannWholePC
      // 
      this.buttonScannWholePC.Enabled = false;
      this.buttonScannWholePC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonScannWholePC.Location = new System.Drawing.Point(292, 129);
      this.buttonScannWholePC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.buttonScannWholePC.Name = "buttonScannWholePC";
      this.buttonScannWholePC.Size = new System.Drawing.Size(135, 26);
      this.buttonScannWholePC.TabIndex = 13;
      this.buttonScannWholePC.Text = "Scan whole Pc";
      this.buttonScannWholePC.UseVisualStyleBackColor = true;
      // 
      // textBoxLog
      // 
      this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxLog.Location = new System.Drawing.Point(25, 172);
      this.textBoxLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.textBoxLog.Multiline = true;
      this.textBoxLog.Name = "textBoxLog";
      this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBoxLog.Size = new System.Drawing.Size(979, 100);
      this.textBoxLog.TabIndex = 14;
      this.textBoxLog.Text = "Log";
      // 
      // buttonLoadVSProjects
      // 
      this.buttonLoadVSProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonLoadVSProjects.Location = new System.Drawing.Point(433, 129);
      this.buttonLoadVSProjects.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.buttonLoadVSProjects.Name = "buttonLoadVSProjects";
      this.buttonLoadVSProjects.Size = new System.Drawing.Size(208, 26);
      this.buttonLoadVSProjects.TabIndex = 15;
      this.buttonLoadVSProjects.Text = "Search for Visual Studio Projects";
      this.buttonLoadVSProjects.UseVisualStyleBackColor = true;
      this.buttonLoadVSProjects.Click += new System.EventHandler(this.ButtonLoadVsProjectsClick);
      // 
      // checkBoxCreateUpdateFile
      // 
      this.checkBoxCreateUpdateFile.AutoSize = true;
      this.checkBoxCreateUpdateFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.checkBoxCreateUpdateFile.Location = new System.Drawing.Point(886, 133);
      this.checkBoxCreateUpdateFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.checkBoxCreateUpdateFile.Name = "checkBoxCreateUpdateFile";
      this.checkBoxCreateUpdateFile.Size = new System.Drawing.Size(129, 21);
      this.checkBoxCreateUpdateFile.TabIndex = 16;
      this.checkBoxCreateUpdateFile.Text = "Create script file";
      this.checkBoxCreateUpdateFile.UseVisualStyleBackColor = true;
      // 
      // buttonCheckUncheckAll
      // 
      this.buttonCheckUncheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonCheckUncheckAll.Location = new System.Drawing.Point(25, 276);
      this.buttonCheckUncheckAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.buttonCheckUncheckAll.Name = "buttonCheckUncheckAll";
      this.buttonCheckUncheckAll.Size = new System.Drawing.Size(163, 26);
      this.buttonCheckUncheckAll.TabIndex = 17;
      this.buttonCheckUncheckAll.Text = "Check/Uncheck All";
      this.buttonCheckUncheckAll.UseVisualStyleBackColor = true;
      this.buttonCheckUncheckAll.Click += new System.EventHandler(this.ButtonCheckUncheckAllClick);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1021, 434);
      this.Controls.Add(this.buttonCheckUncheckAll);
      this.Controls.Add(this.checkBoxCreateUpdateFile);
      this.Controls.Add(this.buttonLoadVSProjects);
      this.Controls.Add(this.textBoxLog);
      this.Controls.Add(this.buttonScannWholePC);
      this.Controls.Add(this.buttonGitBashBinPath);
      this.Controls.Add(this.textBoxGitBashBinariesPath);
      this.Controls.Add(this.buttonUpdateVSProjects);
      this.Controls.Add(this.labelPickDirectory);
      this.Controls.Add(this.listViewVSProjects);
      this.Controls.Add(this.labelSelectVSProjects);
      this.Controls.Add(this.checkBoxGitBashInstalled);
      this.Controls.Add(this.buttonVSVersionGetPath);
      this.Controls.Add(this.comboBoxVSVersion);
      this.Controls.Add(this.textBoxVSProjectPath);
      this.Controls.Add(this.labelChooseVSVersion);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.Name = "FormMain";
      this.ShowIcon = false;
      this.Text = "Git Auto update GUI";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainFormClosing);
      this.Load += new System.EventHandler(this.FormMainLoad);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem personalizeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem summaryToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem languagetoolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
    private System.Windows.Forms.Label labelChooseVSVersion;
    private System.Windows.Forms.TextBox textBoxVSProjectPath;
    private System.Windows.Forms.ComboBox comboBoxVSVersion;
    private System.Windows.Forms.Button buttonVSVersionGetPath;
    private System.Windows.Forms.CheckBox checkBoxGitBashInstalled;
    private System.Windows.Forms.Label labelSelectVSProjects;
    private System.Windows.Forms.ListView listViewVSProjects;
    private System.Windows.Forms.Label labelPickDirectory;
    private System.Windows.Forms.Button buttonUpdateVSProjects;
    private System.Windows.Forms.TextBox textBoxGitBashBinariesPath;
    private System.Windows.Forms.Button buttonGitBashBinPath;
    private System.Windows.Forms.Button buttonScannWholePC;
    private System.Windows.Forms.TextBox textBoxLog;
    private System.Windows.Forms.Button buttonLoadVSProjects;
    private System.Windows.Forms.CheckBox checkBoxCreateUpdateFile;
    private System.Windows.Forms.Button buttonCheckUncheckAll;
  }
}