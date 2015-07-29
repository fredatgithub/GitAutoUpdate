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
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(1361, 28);
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
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
      this.fileToolStripMenuItem.Text = "&Fichier";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
      this.newToolStripMenuItem.Text = "&Nouveau";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
      this.openToolStripMenuItem.Text = "&Ouvrir";
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size(244, 6);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
      this.saveToolStripMenuItem.Text = "&Enregistrer";
      // 
      // saveasToolStripMenuItem
      // 
      this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
      this.saveasToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
      this.saveasToolStripMenuItem.Text = "Enregistrer &sous";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(244, 6);
      // 
      // printToolStripMenuItem
      // 
      this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printToolStripMenuItem.Name = "printToolStripMenuItem";
      this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.printToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
      this.printToolStripMenuItem.Text = "&Imprimer";
      // 
      // printPreviewToolStripMenuItem
      // 
      this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
      this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
      this.printPreviewToolStripMenuItem.Text = "Aperçu a&vant impression";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(244, 6);
      // 
      // quitToolStripMenuItem
      // 
      this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
      this.quitToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
      this.quitToolStripMenuItem.Text = "&Quitter";
      this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
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
      this.editToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
      this.editToolStripMenuItem.Text = "&Edition";
      // 
      // cancelToolStripMenuItem
      // 
      this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
      this.cancelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.cancelToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
      this.cancelToolStripMenuItem.Text = "&Annuler";
      // 
      // redoToolStripMenuItem
      // 
      this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
      this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
      this.redoToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
      this.redoToolStripMenuItem.Text = "&Rétablir";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(194, 6);
      // 
      // cutToolStripMenuItem
      // 
      this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
      this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.cutToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
      this.cutToolStripMenuItem.Text = "&Couper";
      this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
      // 
      // copyToolStripMenuItem
      // 
      this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.copyToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
      this.copyToolStripMenuItem.Text = "Co&pier";
      this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
      // 
      // pasteToolStripMenuItem
      // 
      this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
      this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.pasteToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
      this.pasteToolStripMenuItem.Text = "Co&ller";
      this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(194, 6);
      // 
      // selectAllToolStripMenuItem
      // 
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
      this.selectAllToolStripMenuItem.Text = "Sélectio&nner tout";
      this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
      this.toolsToolStripMenuItem.Text = "&Outils";
      // 
      // personalizeToolStripMenuItem
      // 
      this.personalizeToolStripMenuItem.Name = "personalizeToolStripMenuItem";
      this.personalizeToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
      this.personalizeToolStripMenuItem.Text = "&Personnaliser";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
      this.optionsToolStripMenuItem.Text = "&Options";
      // 
      // languagetoolStripMenuItem
      // 
      this.languagetoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frenchToolStripMenuItem,
            this.englishToolStripMenuItem});
      this.languagetoolStripMenuItem.Name = "languagetoolStripMenuItem";
      this.languagetoolStripMenuItem.Size = new System.Drawing.Size(86, 24);
      this.languagetoolStripMenuItem.Text = "Language";
      // 
      // frenchToolStripMenuItem
      // 
      this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
      this.frenchToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
      this.frenchToolStripMenuItem.Text = "Français";
      this.frenchToolStripMenuItem.Click += new System.EventHandler(this.frenchToolStripMenuItem_Click);
      // 
      // englishToolStripMenuItem
      // 
      this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
      this.englishToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
      this.englishToolStripMenuItem.Text = "Anglais";
      this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
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
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
      this.helpToolStripMenuItem.Text = "&Aide";
      // 
      // summaryToolStripMenuItem
      // 
      this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
      this.summaryToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
      this.summaryToolStripMenuItem.Text = "&Sommaire";
      // 
      // indexToolStripMenuItem
      // 
      this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
      this.indexToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
      this.indexToolStripMenuItem.Text = "&Index";
      // 
      // searchToolStripMenuItem
      // 
      this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
      this.searchToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
      this.searchToolStripMenuItem.Text = "&Rechercher";
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(172, 6);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
      this.aboutToolStripMenuItem.Text = "À &propos de...";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
      // 
      // labelChooseVSVersion
      // 
      this.labelChooseVSVersion.AutoSize = true;
      this.labelChooseVSVersion.Location = new System.Drawing.Point(30, 79);
      this.labelChooseVSVersion.Name = "labelChooseVSVersion";
      this.labelChooseVSVersion.Size = new System.Drawing.Size(220, 17);
      this.labelChooseVSVersion.TabIndex = 2;
      this.labelChooseVSVersion.Text = "Choose the Visual Studio version:";
      // 
      // textBoxVSProjectPath
      // 
      this.textBoxVSProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxVSProjectPath.Location = new System.Drawing.Point(715, 77);
      this.textBoxVSProjectPath.Name = "textBoxVSProjectPath";
      this.textBoxVSProjectPath.Size = new System.Drawing.Size(622, 22);
      this.textBoxVSProjectPath.TabIndex = 3;
      this.textBoxVSProjectPath.Text = "C:\\";
      // 
      // comboBoxVSVersion
      // 
      this.comboBoxVSVersion.FormattingEnabled = true;
      this.comboBoxVSVersion.Location = new System.Drawing.Point(287, 76);
      this.comboBoxVSVersion.Name = "comboBoxVSVersion";
      this.comboBoxVSVersion.Size = new System.Drawing.Size(171, 24);
      this.comboBoxVSVersion.TabIndex = 4;
      this.comboBoxVSVersion.Text = "Visual Studio Version";
      // 
      // buttonVSVersionGetPath
      // 
      this.buttonVSVersionGetPath.Location = new System.Drawing.Point(663, 77);
      this.buttonVSVersionGetPath.Name = "buttonVSVersionGetPath";
      this.buttonVSVersionGetPath.Size = new System.Drawing.Size(37, 23);
      this.buttonVSVersionGetPath.TabIndex = 5;
      this.buttonVSVersionGetPath.Text = "...";
      this.buttonVSVersionGetPath.UseVisualStyleBackColor = true;
      this.buttonVSVersionGetPath.Click += new System.EventHandler(this.buttonVSVersionGetPath_Click);
      // 
      // checkBoxGitBashInstalled
      // 
      this.checkBoxGitBashInstalled.AutoSize = true;
      this.checkBoxGitBashInstalled.Location = new System.Drawing.Point(33, 124);
      this.checkBoxGitBashInstalled.Name = "checkBoxGitBashInstalled";
      this.checkBoxGitBashInstalled.Size = new System.Drawing.Size(136, 21);
      this.checkBoxGitBashInstalled.TabIndex = 6;
      this.checkBoxGitBashInstalled.Text = "GitBash installed";
      this.checkBoxGitBashInstalled.UseVisualStyleBackColor = true;
      // 
      // labelSelectVSProjects
      // 
      this.labelSelectVSProjects.AutoSize = true;
      this.labelSelectVSProjects.Location = new System.Drawing.Point(30, 168);
      this.labelSelectVSProjects.Name = "labelSelectVSProjects";
      this.labelSelectVSProjects.Size = new System.Drawing.Size(335, 17);
      this.labelSelectVSProjects.TabIndex = 7;
      this.labelSelectVSProjects.Text = "Select the Visual Studio projects you want to update";
      // 
      // listViewVSProjects
      // 
      this.listViewVSProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listViewVSProjects.Location = new System.Drawing.Point(33, 356);
      this.listViewVSProjects.Name = "listViewVSProjects";
      this.listViewVSProjects.Size = new System.Drawing.Size(1304, 166);
      this.listViewVSProjects.TabIndex = 8;
      this.listViewVSProjects.UseCompatibleStateImageBehavior = false;
      // 
      // labelPickDirectory
      // 
      this.labelPickDirectory.AutoSize = true;
      this.labelPickDirectory.Location = new System.Drawing.Point(481, 79);
      this.labelPickDirectory.Name = "labelPickDirectory";
      this.labelPickDirectory.Size = new System.Drawing.Size(109, 17);
      this.labelPickDirectory.TabIndex = 9;
      this.labelPickDirectory.Text = "or pick directory";
      // 
      // buttonUpdateVSProjects
      // 
      this.buttonUpdateVSProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonUpdateVSProjects.Location = new System.Drawing.Point(665, 159);
      this.buttonUpdateVSProjects.Name = "buttonUpdateVSProjects";
      this.buttonUpdateVSProjects.Size = new System.Drawing.Size(313, 32);
      this.buttonUpdateVSProjects.TabIndex = 10;
      this.buttonUpdateVSProjects.Text = "Update selected Visual Studio Projects";
      this.buttonUpdateVSProjects.UseVisualStyleBackColor = true;
      this.buttonUpdateVSProjects.Click += new System.EventHandler(this.buttonUpdateVSProjects_Click);
      // 
      // textBoxGitBashBinariesPath
      // 
      this.textBoxGitBashBinariesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxGitBashBinariesPath.Location = new System.Drawing.Point(273, 122);
      this.textBoxGitBashBinariesPath.Name = "textBoxGitBashBinariesPath";
      this.textBoxGitBashBinariesPath.Size = new System.Drawing.Size(1064, 22);
      this.textBoxGitBashBinariesPath.TabIndex = 11;
      this.textBoxGitBashBinariesPath.Text = "C:\\";
      // 
      // buttonGitBashBinPath
      // 
      this.buttonGitBashBinPath.Location = new System.Drawing.Point(225, 121);
      this.buttonGitBashBinPath.Name = "buttonGitBashBinPath";
      this.buttonGitBashBinPath.Size = new System.Drawing.Size(37, 23);
      this.buttonGitBashBinPath.TabIndex = 12;
      this.buttonGitBashBinPath.Text = "...";
      this.buttonGitBashBinPath.UseVisualStyleBackColor = true;
      this.buttonGitBashBinPath.Click += new System.EventHandler(this.buttonGitBashBinPath_Click);
      // 
      // buttonScannWholePC
      // 
      this.buttonScannWholePC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonScannWholePC.Location = new System.Drawing.Point(389, 159);
      this.buttonScannWholePC.Name = "buttonScannWholePC";
      this.buttonScannWholePC.Size = new System.Drawing.Size(211, 32);
      this.buttonScannWholePC.TabIndex = 13;
      this.buttonScannWholePC.Text = "Scan whole Pc";
      this.buttonScannWholePC.UseVisualStyleBackColor = true;
      // 
      // textBoxLog
      // 
      this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxLog.Location = new System.Drawing.Point(33, 212);
      this.textBoxLog.Multiline = true;
      this.textBoxLog.Name = "textBoxLog";
      this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBoxLog.Size = new System.Drawing.Size(1304, 122);
      this.textBoxLog.TabIndex = 14;
      this.textBoxLog.Text = "Log";
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1361, 534);
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
      this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.Name = "FormMain";
      this.ShowIcon = false;
      this.Text = "Git Auto update GUI";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainFormClosing);
      this.Load += new System.EventHandler(this.FormMain_Load);
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
  }
}