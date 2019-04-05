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
      this.menuStripMain = new System.Windows.Forms.MenuStrip();
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
      this.checkBoxOnlyGenerateScriptFile = new System.Windows.Forms.CheckBox();
      this.buttonCheckUncheckAll = new System.Windows.Forms.Button();
      this.buttonClearLogTextBox = new System.Windows.Forms.Button();
      this.checkBoxUnlistVSSolution = new System.Windows.Forms.CheckBox();
      this.textBoxUnlistOldSolution = new System.Windows.Forms.TextBox();
      this.checkBoxCaseSensitive = new System.Windows.Forms.CheckBox();
      this.buttonClearAll = new System.Windows.Forms.Button();
      this.buttonCheckAll = new System.Windows.Forms.Button();
      this.checkBoxGitInPath = new System.Windows.Forms.CheckBox();
      this.buttonAddGitBinaryToWinPath = new System.Windows.Forms.Button();
      this.buttonCreateBackupScript = new System.Windows.Forms.Button();
      this.checkedListBoxVSVersion = new System.Windows.Forms.CheckedListBox();
      this.buttonUpdateCheckedVersion = new System.Windows.Forms.Button();
      this.buttonListBoxVSVersionCheck = new System.Windows.Forms.Button();
      this.buttonListBoxVSVersionUncheck = new System.Windows.Forms.Button();
      this.buttonListBoxVSVersionToggle = new System.Windows.Forms.Button();
      this.menuStripMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStripMain
      // 
      this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.languagetoolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStripMain.Location = new System.Drawing.Point(0, 0);
      this.menuStripMain.Name = "menuStripMain";
      this.menuStripMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
      this.menuStripMain.Size = new System.Drawing.Size(1259, 24);
      this.menuStripMain.TabIndex = 1;
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
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
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
      this.personalizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.personalizeToolStripMenuItem.Text = "&Personnaliser";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
      this.labelChooseVSVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelChooseVSVersion.Location = new System.Drawing.Point(22, 64);
      this.labelChooseVSVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelChooseVSVersion.Name = "labelChooseVSVersion";
      this.labelChooseVSVersion.Size = new System.Drawing.Size(220, 17);
      this.labelChooseVSVersion.TabIndex = 2;
      this.labelChooseVSVersion.Text = "Choose the Visual Studio version:";
      // 
      // textBoxVSProjectPath
      // 
      this.textBoxVSProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxVSProjectPath.Location = new System.Drawing.Point(653, 63);
      this.textBoxVSProjectPath.Margin = new System.Windows.Forms.Padding(2);
      this.textBoxVSProjectPath.Name = "textBoxVSProjectPath";
      this.textBoxVSProjectPath.Size = new System.Drawing.Size(587, 20);
      this.textBoxVSProjectPath.TabIndex = 3;
      this.textBoxVSProjectPath.Text = "C:\\";
      this.textBoxVSProjectPath.TextChanged += new System.EventHandler(this.TextBoxVsProjectPathTextChanged);
      // 
      // comboBoxVSVersion
      // 
      this.comboBoxVSVersion.FormattingEnabled = true;
      this.comboBoxVSVersion.Location = new System.Drawing.Point(283, 62);
      this.comboBoxVSVersion.Margin = new System.Windows.Forms.Padding(2);
      this.comboBoxVSVersion.Name = "comboBoxVSVersion";
      this.comboBoxVSVersion.Size = new System.Drawing.Size(148, 21);
      this.comboBoxVSVersion.TabIndex = 4;
      this.comboBoxVSVersion.Text = "Visual Studio Version";
      this.comboBoxVSVersion.SelectedIndexChanged += new System.EventHandler(this.ComboBoxVSVersion_SelectedIndexChanged);
      // 
      // buttonVSVersionGetPath
      // 
      this.buttonVSVersionGetPath.Location = new System.Drawing.Point(617, 63);
      this.buttonVSVersionGetPath.Margin = new System.Windows.Forms.Padding(2);
      this.buttonVSVersionGetPath.Name = "buttonVSVersionGetPath";
      this.buttonVSVersionGetPath.Size = new System.Drawing.Size(28, 20);
      this.buttonVSVersionGetPath.TabIndex = 5;
      this.buttonVSVersionGetPath.Text = "...";
      this.buttonVSVersionGetPath.UseVisualStyleBackColor = true;
      this.buttonVSVersionGetPath.Click += new System.EventHandler(this.ButtonVSVersionGetPath_Click);
      // 
      // checkBoxGitBashInstalled
      // 
      this.checkBoxGitBashInstalled.AutoSize = true;
      this.checkBoxGitBashInstalled.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.checkBoxGitBashInstalled.ForeColor = System.Drawing.SystemColors.ControlText;
      this.checkBoxGitBashInstalled.Location = new System.Drawing.Point(25, 278);
      this.checkBoxGitBashInstalled.Margin = new System.Windows.Forms.Padding(2);
      this.checkBoxGitBashInstalled.Name = "checkBoxGitBashInstalled";
      this.checkBoxGitBashInstalled.Size = new System.Drawing.Size(150, 21);
      this.checkBoxGitBashInstalled.TabIndex = 6;
      this.checkBoxGitBashInstalled.Text = "GitBash installed";
      this.checkBoxGitBashInstalled.UseVisualStyleBackColor = true;
      this.checkBoxGitBashInstalled.CheckedChanged += new System.EventHandler(this.CheckBoxGitBashInstalled_CheckedChanged);
      // 
      // labelSelectVSProjects
      // 
      this.labelSelectVSProjects.AutoSize = true;
      this.labelSelectVSProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelSelectVSProjects.Location = new System.Drawing.Point(458, 459);
      this.labelSelectVSProjects.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelSelectVSProjects.Name = "labelSelectVSProjects";
      this.labelSelectVSProjects.Size = new System.Drawing.Size(377, 20);
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
      this.listViewVSProjects.Location = new System.Drawing.Point(25, 492);
      this.listViewVSProjects.Margin = new System.Windows.Forms.Padding(2);
      this.listViewVSProjects.Name = "listViewVSProjects";
      this.listViewVSProjects.Size = new System.Drawing.Size(1217, 207);
      this.listViewVSProjects.TabIndex = 8;
      this.listViewVSProjects.UseCompatibleStateImageBehavior = false;
      this.listViewVSProjects.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewVSProjects_ItemChecked);
      // 
      // labelPickDirectory
      // 
      this.labelPickDirectory.AutoSize = true;
      this.labelPickDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelPickDirectory.Location = new System.Drawing.Point(439, 64);
      this.labelPickDirectory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelPickDirectory.Name = "labelPickDirectory";
      this.labelPickDirectory.Size = new System.Drawing.Size(109, 17);
      this.labelPickDirectory.TabIndex = 9;
      this.labelPickDirectory.Text = "or pick directory";
      // 
      // buttonUpdateVSProjects
      // 
      this.buttonUpdateVSProjects.Enabled = false;
      this.buttonUpdateVSProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonUpdateVSProjects.Location = new System.Drawing.Point(462, 308);
      this.buttonUpdateVSProjects.Margin = new System.Windows.Forms.Padding(2);
      this.buttonUpdateVSProjects.Name = "buttonUpdateVSProjects";
      this.buttonUpdateVSProjects.Size = new System.Drawing.Size(235, 26);
      this.buttonUpdateVSProjects.TabIndex = 10;
      this.buttonUpdateVSProjects.Text = "Update selected Visual Studio Projects";
      this.buttonUpdateVSProjects.UseVisualStyleBackColor = true;
      this.buttonUpdateVSProjects.Click += new System.EventHandler(this.ButtonUpdateVSProjects_Click);
      // 
      // textBoxGitBashBinariesPath
      // 
      this.textBoxGitBashBinariesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxGitBashBinariesPath.Location = new System.Drawing.Point(242, 277);
      this.textBoxGitBashBinariesPath.Margin = new System.Windows.Forms.Padding(2);
      this.textBoxGitBashBinariesPath.Name = "textBoxGitBashBinariesPath";
      this.textBoxGitBashBinariesPath.Size = new System.Drawing.Size(1000, 20);
      this.textBoxGitBashBinariesPath.TabIndex = 11;
      this.textBoxGitBashBinariesPath.Text = "C:\\";
      this.textBoxGitBashBinariesPath.TextChanged += new System.EventHandler(this.TextBoxGitBashBinariesPathTextChanged);
      // 
      // buttonGitBashBinPath
      // 
      this.buttonGitBashBinPath.Location = new System.Drawing.Point(207, 277);
      this.buttonGitBashBinPath.Margin = new System.Windows.Forms.Padding(2);
      this.buttonGitBashBinPath.Name = "buttonGitBashBinPath";
      this.buttonGitBashBinPath.Size = new System.Drawing.Size(28, 19);
      this.buttonGitBashBinPath.TabIndex = 12;
      this.buttonGitBashBinPath.Text = "...";
      this.buttonGitBashBinPath.UseVisualStyleBackColor = true;
      this.buttonGitBashBinPath.Click += new System.EventHandler(this.ButtonGitBashBinPath_Click);
      // 
      // buttonScannWholePC
      // 
      this.buttonScannWholePC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonScannWholePC.Location = new System.Drawing.Point(130, 308);
      this.buttonScannWholePC.Margin = new System.Windows.Forms.Padding(2);
      this.buttonScannWholePC.Name = "buttonScannWholePC";
      this.buttonScannWholePC.Size = new System.Drawing.Size(115, 26);
      this.buttonScannWholePC.TabIndex = 13;
      this.buttonScannWholePC.Text = "Scan whole Pc";
      this.buttonScannWholePC.UseVisualStyleBackColor = true;
      this.buttonScannWholePC.Click += new System.EventHandler(this.ButtonScannWholePC_Click);
      // 
      // textBoxLog
      // 
      this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxLog.Location = new System.Drawing.Point(25, 368);
      this.textBoxLog.Margin = new System.Windows.Forms.Padding(2);
      this.textBoxLog.Multiline = true;
      this.textBoxLog.Name = "textBoxLog";
      this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBoxLog.Size = new System.Drawing.Size(1217, 83);
      this.textBoxLog.TabIndex = 14;
      this.textBoxLog.Text = "Log";
      // 
      // buttonLoadVSProjects
      // 
      this.buttonLoadVSProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonLoadVSProjects.Location = new System.Drawing.Point(249, 308);
      this.buttonLoadVSProjects.Margin = new System.Windows.Forms.Padding(2);
      this.buttonLoadVSProjects.Name = "buttonLoadVSProjects";
      this.buttonLoadVSProjects.Size = new System.Drawing.Size(208, 26);
      this.buttonLoadVSProjects.TabIndex = 15;
      this.buttonLoadVSProjects.Text = "Search for Visual Studio Projects";
      this.buttonLoadVSProjects.UseVisualStyleBackColor = true;
      this.buttonLoadVSProjects.Click += new System.EventHandler(this.ButtonLoadVSProjects_Click);
      // 
      // checkBoxOnlyGenerateScriptFile
      // 
      this.checkBoxOnlyGenerateScriptFile.AutoSize = true;
      this.checkBoxOnlyGenerateScriptFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.checkBoxOnlyGenerateScriptFile.Location = new System.Drawing.Point(701, 312);
      this.checkBoxOnlyGenerateScriptFile.Margin = new System.Windows.Forms.Padding(2);
      this.checkBoxOnlyGenerateScriptFile.Name = "checkBoxOnlyGenerateScriptFile";
      this.checkBoxOnlyGenerateScriptFile.Size = new System.Drawing.Size(177, 21);
      this.checkBoxOnlyGenerateScriptFile.TabIndex = 16;
      this.checkBoxOnlyGenerateScriptFile.Text = "Only generate script file";
      this.checkBoxOnlyGenerateScriptFile.UseVisualStyleBackColor = true;
      this.checkBoxOnlyGenerateScriptFile.CheckedChanged += new System.EventHandler(this.CheckBoxOnlyGenerateScriptFile_CheckedChanged);
      // 
      // buttonCheckUncheckAll
      // 
      this.buttonCheckUncheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonCheckUncheckAll.Location = new System.Drawing.Point(318, 455);
      this.buttonCheckUncheckAll.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCheckUncheckAll.Name = "buttonCheckUncheckAll";
      this.buttonCheckUncheckAll.Size = new System.Drawing.Size(136, 26);
      this.buttonCheckUncheckAll.TabIndex = 17;
      this.buttonCheckUncheckAll.Text = "Check/Uncheck All";
      this.buttonCheckUncheckAll.UseVisualStyleBackColor = true;
      this.buttonCheckUncheckAll.Click += new System.EventHandler(this.ButtonCheckUncheckAll_Click);
      // 
      // buttonClearLogTextBox
      // 
      this.buttonClearLogTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonClearLogTextBox.Location = new System.Drawing.Point(26, 308);
      this.buttonClearLogTextBox.Margin = new System.Windows.Forms.Padding(2);
      this.buttonClearLogTextBox.Name = "buttonClearLogTextBox";
      this.buttonClearLogTextBox.Size = new System.Drawing.Size(99, 26);
      this.buttonClearLogTextBox.TabIndex = 18;
      this.buttonClearLogTextBox.Text = "Clear Log";
      this.buttonClearLogTextBox.UseVisualStyleBackColor = true;
      this.buttonClearLogTextBox.Click += new System.EventHandler(this.ButtonClearLogTextBox_Click);
      // 
      // checkBoxUnlistVSSolution
      // 
      this.checkBoxUnlistVSSolution.AutoSize = true;
      this.checkBoxUnlistVSSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.checkBoxUnlistVSSolution.Location = new System.Drawing.Point(26, 342);
      this.checkBoxUnlistVSSolution.Margin = new System.Windows.Forms.Padding(2);
      this.checkBoxUnlistVSSolution.Name = "checkBoxUnlistVSSolution";
      this.checkBoxUnlistVSSolution.Size = new System.Drawing.Size(463, 21);
      this.checkBoxUnlistVSSolution.TabIndex = 19;
      this.checkBoxUnlistVSSolution.Text = "Unlist Visual Studio Solutions having the text separated with a comma";
      this.checkBoxUnlistVSSolution.UseVisualStyleBackColor = true;
      this.checkBoxUnlistVSSolution.CheckedChanged += new System.EventHandler(this.CheckBoxUnlistVSSolution_CheckedChanged);
      // 
      // textBoxUnlistOldSolution
      // 
      this.textBoxUnlistOldSolution.AcceptsReturn = true;
      this.textBoxUnlistOldSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxUnlistOldSolution.Location = new System.Drawing.Point(692, 342);
      this.textBoxUnlistOldSolution.Margin = new System.Windows.Forms.Padding(2);
      this.textBoxUnlistOldSolution.Name = "textBoxUnlistOldSolution";
      this.textBoxUnlistOldSolution.Size = new System.Drawing.Size(350, 23);
      this.textBoxUnlistOldSolution.TabIndex = 20;
      this.textBoxUnlistOldSolution.Text = "old, bad";
      this.textBoxUnlistOldSolution.TextChanged += new System.EventHandler(this.TextBoxUnlistOldSolution_TextChanged);
      // 
      // checkBoxCaseSensitive
      // 
      this.checkBoxCaseSensitive.AutoSize = true;
      this.checkBoxCaseSensitive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.checkBoxCaseSensitive.Location = new System.Drawing.Point(1045, 342);
      this.checkBoxCaseSensitive.Margin = new System.Windows.Forms.Padding(2);
      this.checkBoxCaseSensitive.Name = "checkBoxCaseSensitive";
      this.checkBoxCaseSensitive.Size = new System.Drawing.Size(118, 21);
      this.checkBoxCaseSensitive.TabIndex = 21;
      this.checkBoxCaseSensitive.Text = "Case sensitive";
      this.checkBoxCaseSensitive.UseVisualStyleBackColor = true;
      this.checkBoxCaseSensitive.CheckedChanged += new System.EventHandler(this.CheckBoxCaseSensitive_CheckedChanged);
      // 
      // buttonClearAll
      // 
      this.buttonClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonClearAll.Location = new System.Drawing.Point(26, 455);
      this.buttonClearAll.Margin = new System.Windows.Forms.Padding(2);
      this.buttonClearAll.Name = "buttonClearAll";
      this.buttonClearAll.Size = new System.Drawing.Size(138, 26);
      this.buttonClearAll.TabIndex = 22;
      this.buttonClearAll.Text = "Uncheck all";
      this.buttonClearAll.UseVisualStyleBackColor = true;
      this.buttonClearAll.Click += new System.EventHandler(this.ButtonClearAll_Click);
      // 
      // buttonCheckAll
      // 
      this.buttonCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonCheckAll.Location = new System.Drawing.Point(168, 455);
      this.buttonCheckAll.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCheckAll.Name = "buttonCheckAll";
      this.buttonCheckAll.Size = new System.Drawing.Size(128, 26);
      this.buttonCheckAll.TabIndex = 23;
      this.buttonCheckAll.Text = "Check all";
      this.buttonCheckAll.UseVisualStyleBackColor = true;
      this.buttonCheckAll.Click += new System.EventHandler(this.ButtonCheckAll_Click);
      // 
      // checkBoxGitInPath
      // 
      this.checkBoxGitInPath.AutoSize = true;
      this.checkBoxGitInPath.Enabled = false;
      this.checkBoxGitInPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.checkBoxGitInPath.ForeColor = System.Drawing.SystemColors.ControlText;
      this.checkBoxGitInPath.Location = new System.Drawing.Point(25, 240);
      this.checkBoxGitInPath.Margin = new System.Windows.Forms.Padding(2);
      this.checkBoxGitInPath.Name = "checkBoxGitInPath";
      this.checkBoxGitInPath.Size = new System.Drawing.Size(358, 21);
      this.checkBoxGitInPath.TabIndex = 24;
      this.checkBoxGitInPath.Text = "GitBash binary path in Windows Path variable";
      this.checkBoxGitInPath.UseVisualStyleBackColor = true;
      this.checkBoxGitInPath.CheckedChanged += new System.EventHandler(this.CheckBoxGitInPath_CheckedChanged);
      // 
      // buttonAddGitBinaryToWinPath
      // 
      this.buttonAddGitBinaryToWinPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonAddGitBinaryToWinPath.Location = new System.Drawing.Point(523, 236);
      this.buttonAddGitBinaryToWinPath.Margin = new System.Windows.Forms.Padding(2);
      this.buttonAddGitBinaryToWinPath.Name = "buttonAddGitBinaryToWinPath";
      this.buttonAddGitBinaryToWinPath.Size = new System.Drawing.Size(237, 26);
      this.buttonAddGitBinaryToWinPath.TabIndex = 25;
      this.buttonAddGitBinaryToWinPath.Text = "Add GitBash binary to Windows Path";
      this.buttonAddGitBinaryToWinPath.UseVisualStyleBackColor = true;
      this.buttonAddGitBinaryToWinPath.Click += new System.EventHandler(this.ButtonAddGitBinaryToWinPath_Click);
      // 
      // buttonCreateBackupScript
      // 
      this.buttonCreateBackupScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonCreateBackupScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonCreateBackupScript.Location = new System.Drawing.Point(776, 236);
      this.buttonCreateBackupScript.Margin = new System.Windows.Forms.Padding(2);
      this.buttonCreateBackupScript.Name = "buttonCreateBackupScript";
      this.buttonCreateBackupScript.Size = new System.Drawing.Size(427, 26);
      this.buttonCreateBackupScript.TabIndex = 26;
      this.buttonCreateBackupScript.Text = "Create git clone backup script";
      this.buttonCreateBackupScript.UseVisualStyleBackColor = true;
      this.buttonCreateBackupScript.Click += new System.EventHandler(this.ButtonCreateBackupScript_Click);
      // 
      // checkedListBoxVSVersion
      // 
      this.checkedListBoxVSVersion.FormattingEnabled = true;
      this.checkedListBoxVSVersion.Location = new System.Drawing.Point(283, 98);
      this.checkedListBoxVSVersion.Name = "checkedListBoxVSVersion";
      this.checkedListBoxVSVersion.Size = new System.Drawing.Size(148, 124);
      this.checkedListBoxVSVersion.TabIndex = 27;
      this.checkedListBoxVSVersion.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxVSVersion_SelectedIndexChanged);
      // 
      // buttonUpdateCheckedVersion
      // 
      this.buttonUpdateCheckedVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonUpdateCheckedVersion.Location = new System.Drawing.Point(442, 196);
      this.buttonUpdateCheckedVersion.Margin = new System.Windows.Forms.Padding(2);
      this.buttonUpdateCheckedVersion.Name = "buttonUpdateCheckedVersion";
      this.buttonUpdateCheckedVersion.Size = new System.Drawing.Size(106, 26);
      this.buttonUpdateCheckedVersion.TabIndex = 28;
      this.buttonUpdateCheckedVersion.Text = "Update";
      this.buttonUpdateCheckedVersion.UseVisualStyleBackColor = true;
      this.buttonUpdateCheckedVersion.Click += new System.EventHandler(this.ButtonUpdateCheckedVersionClick);
      // 
      // buttonListBoxVSVersionCheck
      // 
      this.buttonListBoxVSVersionCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonListBoxVSVersionCheck.Location = new System.Drawing.Point(130, 98);
      this.buttonListBoxVSVersionCheck.Margin = new System.Windows.Forms.Padding(2);
      this.buttonListBoxVSVersionCheck.Name = "buttonListBoxVSVersionCheck";
      this.buttonListBoxVSVersionCheck.Size = new System.Drawing.Size(138, 26);
      this.buttonListBoxVSVersionCheck.TabIndex = 31;
      this.buttonListBoxVSVersionCheck.Text = "Check all";
      this.buttonListBoxVSVersionCheck.UseVisualStyleBackColor = true;
      this.buttonListBoxVSVersionCheck.Click += new System.EventHandler(this.ButtonListBoxVSVersionCheck_Click);
      // 
      // buttonListBoxVSVersionUncheck
      // 
      this.buttonListBoxVSVersionUncheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonListBoxVSVersionUncheck.Location = new System.Drawing.Point(130, 140);
      this.buttonListBoxVSVersionUncheck.Margin = new System.Windows.Forms.Padding(2);
      this.buttonListBoxVSVersionUncheck.Name = "buttonListBoxVSVersionUncheck";
      this.buttonListBoxVSVersionUncheck.Size = new System.Drawing.Size(138, 26);
      this.buttonListBoxVSVersionUncheck.TabIndex = 30;
      this.buttonListBoxVSVersionUncheck.Text = "Uncheck all";
      this.buttonListBoxVSVersionUncheck.UseVisualStyleBackColor = true;
      this.buttonListBoxVSVersionUncheck.Click += new System.EventHandler(this.ButtonListBoxVSVersionUncheck_Click);
      // 
      // buttonListBoxVSVersionToggle
      // 
      this.buttonListBoxVSVersionToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonListBoxVSVersionToggle.Location = new System.Drawing.Point(130, 187);
      this.buttonListBoxVSVersionToggle.Margin = new System.Windows.Forms.Padding(2);
      this.buttonListBoxVSVersionToggle.Name = "buttonListBoxVSVersionToggle";
      this.buttonListBoxVSVersionToggle.Size = new System.Drawing.Size(136, 26);
      this.buttonListBoxVSVersionToggle.TabIndex = 29;
      this.buttonListBoxVSVersionToggle.Text = "Check/Uncheck All";
      this.buttonListBoxVSVersionToggle.UseVisualStyleBackColor = true;
      this.buttonListBoxVSVersionToggle.Click += new System.EventHandler(this.ButtonListBoxVSVersionToggle_Click);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.ClientSize = new System.Drawing.Size(1259, 708);
      this.Controls.Add(this.buttonListBoxVSVersionCheck);
      this.Controls.Add(this.buttonListBoxVSVersionUncheck);
      this.Controls.Add(this.buttonListBoxVSVersionToggle);
      this.Controls.Add(this.buttonUpdateCheckedVersion);
      this.Controls.Add(this.checkedListBoxVSVersion);
      this.Controls.Add(this.buttonCreateBackupScript);
      this.Controls.Add(this.buttonAddGitBinaryToWinPath);
      this.Controls.Add(this.checkBoxGitInPath);
      this.Controls.Add(this.buttonCheckAll);
      this.Controls.Add(this.buttonClearAll);
      this.Controls.Add(this.checkBoxCaseSensitive);
      this.Controls.Add(this.textBoxUnlistOldSolution);
      this.Controls.Add(this.checkBoxUnlistVSSolution);
      this.Controls.Add(this.buttonClearLogTextBox);
      this.Controls.Add(this.buttonCheckUncheckAll);
      this.Controls.Add(this.checkBoxOnlyGenerateScriptFile);
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
      this.Controls.Add(this.menuStripMain);
      this.MainMenuStrip = this.menuStripMain;
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "FormMain";
      this.ShowIcon = false;
      this.Text = "Git Auto update GUI";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainFormClosing);
      this.Load += new System.EventHandler(this.FormMainLoad);
      this.menuStripMain.ResumeLayout(false);
      this.menuStripMain.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStripMain;
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
    private System.Windows.Forms.CheckBox checkBoxOnlyGenerateScriptFile;
    private System.Windows.Forms.Button buttonCheckUncheckAll;
    private System.Windows.Forms.Button buttonClearLogTextBox;
    private System.Windows.Forms.CheckBox checkBoxUnlistVSSolution;
    private System.Windows.Forms.TextBox textBoxUnlistOldSolution;
    private System.Windows.Forms.CheckBox checkBoxCaseSensitive;
    private System.Windows.Forms.Button buttonClearAll;
    private System.Windows.Forms.Button buttonCheckAll;
    private System.Windows.Forms.CheckBox checkBoxGitInPath;
    private System.Windows.Forms.Button buttonAddGitBinaryToWinPath;
    private System.Windows.Forms.Button buttonCreateBackupScript;
    private System.Windows.Forms.CheckedListBox checkedListBoxVSVersion;
    private System.Windows.Forms.Button buttonUpdateCheckedVersion;
    private System.Windows.Forms.Button buttonListBoxVSVersionCheck;
    private System.Windows.Forms.Button buttonListBoxVSVersionUncheck;
    private System.Windows.Forms.Button buttonListBoxVSVersionToggle;
  }
}