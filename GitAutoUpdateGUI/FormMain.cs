/*
The MIT License(MIT)
Copyright(c) 2015 Freddy Juhel
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using GitAutoUpdateGUI.Properties;

namespace GitAutoUpdateGUI
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    readonly Dictionary<string, string> _languageDicoEn = new Dictionary<string, string>();
    readonly Dictionary<string, string> _languageDicoFr = new Dictionary<string, string>();
    private const string OneSpace = " ";
    private const string Comma = ",";
    private const string Dash = "-";
    private const string Period = ".";
    private static readonly string Crlf = Environment.NewLine;
    private string _currentLanguage = "english";

    private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveWindowValue();
      Application.Exit();
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutBoxApplication aboutBoxApplication = new AboutBoxApplication();
      aboutBoxApplication.ShowDialog();
    }

    private void DisplayTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      Text += string.Format(" V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      LoadSettingsAtStartup();
    }

    private void LoadSettingsAtStartup()
    {
      DisplayTitle();
      LoadComboBoxVsVersions(comboBoxVSVersion);
      GetWindowValue();
      LoadLanguages();
      SetLanguage(Settings.Default.LastLanguageUsed);
      CheckGitBashBinary();
    }

    private static void ClearComboBox(ComboBox cb)
    {
      cb.Items.Clear();
    }
    
    private void LoadComboBoxVsVersions(ComboBox cb)
    {
      ClearComboBox(cb);
      // read XML file
      if (!File.Exists(Settings.Default.VisualStudioVersionsFileName))
      {
        CreateVsVersionFile();
      }

      XDocument xmlDoc = XDocument.Load(Settings.Default.VisualStudioVersionsFileName);
      var result = from node in xmlDoc.Descendants("VSVersion")
                   where node.HasElements
                   let xElement = node.Element("name")
                   where xElement != null
                   select new
                   {
                     vsNameValue = xElement.Value,
                   };

      foreach (var q in result)
      {
        comboBoxVSVersion.Items.Add(q.vsNameValue);
      }

      comboBoxVSVersion.SelectedIndex = comboBoxVSVersion.Items.Count - 1;// select latest version
    }

    private static void CreateVsVersionFile()
    {
      // TODO 
    }

    private void LoadLanguages()
    {
      if (!File.Exists(Settings.Default.LanguageFileName))
      {
        CreateLanguageFile();
      }

      // read the translation file and feed the language
      XDocument xDoc = XDocument.Load(Settings.Default.LanguageFileName);
      var result = from node in xDoc.Descendants("term")
                   where node.HasElements
                   let xElementName = node.Element("name")
                   where xElementName != null
                   let xElementEnglish = node.Element("englishValue")
                   where xElementEnglish != null
                   let xElementFrench = node.Element("frenchValue")
                   where xElementFrench != null
                   select new
                   {
                     name = xElementName.Value,
                     englishValue = xElementEnglish.Value,
                     frenchValue = xElementFrench.Value
                   };
      foreach (var i in result)
      {
        _languageDicoEn.Add(i.name, i.englishValue);
        _languageDicoFr.Add(i.name, i.frenchValue);
      }
    }

    private static void CreateLanguageFile()
    {
      List<string> minimumVersion = new List<string>
      {
        "<?xml version=\"1.0\" encoding=\"utf - 8\" ?>",
        "<Document>",
        "<DocumentVersion>",
        "<version> 1.0 </version>",
        "</DocumentVersion>",
        "<terms>",
         "<term>",
        "<name>MenuFile</name>",
        "<englishValue>File</englishValue>",
        "<frenchValue>Fichier</frenchValue>",
        "</term>",
        "<term>",
        "<name>MenuFileNew</name>",
        "<englishValue>New</englishValue>",
        "<frenchValue>Nouveau</frenchValue>",
        "</term>",
        "<term>",
        "<name>MenuFileOpen</name>",
        "<englishValue>Open</englishValue>",
        "<frenchValue>Ouvrir</frenchValue>",
        "</term>",
        "<term>",
        "<name>MenuFileSave</name>",
        "<englishValue>Save</englishValue>",
        "<frenchValue>Enregistrer</frenchValue>",
        "</term>",
        "<term>",
        "<name>MenuFileSaveAs</name>",
        "<englishValue>Save as ...</englishValue>",
        "<frenchValue>Enregistrer sous ...</frenchValue>",
        "</term>",
        "<term>",
        "<name>MenuFilePrint</name>",
        "<englishValue>Print ...</englishValue>",
        "<frenchValue>Imprimer ...</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenufilePageSetup</name>",
          "<englishValue>Page setup</englishValue>",
          "<frenchValue>Aperçu avant impression</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenufileQuit</name>",
          "<englishValue>Quit</englishValue>",
          "<frenchValue>Quitter</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEdit</name>",
          "<englishValue>Edit</englishValue>",
          "<frenchValue>Edition</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditCancel</name>",
          "<englishValue>Cancel</englishValue>",
          "<frenchValue>Annuler</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditRedo</name>",
          "<englishValue>Redo</englishValue>",
          "<frenchValue>Rétablir</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditCut</name>",
          "<englishValue>Cut</englishValue>",
          "<frenchValue>Couper</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditCopy</name>",
          "<englishValue>Copy</englishValue>",
          "<frenchValue>Copier</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditPaste</name>",
          "<englishValue>Paste</englishValue>",
          "<frenchValue>Coller</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuEditSelectAll</name>",
          "<englishValue>Select All</englishValue>",
          "<frenchValue>Sélectionner tout</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuTools</name>",
          "<englishValue>Tools</englishValue>",
          "<frenchValue>Outils</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuToolsCustomize</name>",
          "<englishValue>Customize ...</englishValue>",
          "<frenchValue>Personaliser ...</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuToolsOptions</name>",
          "<englishValue>Options</englishValue>",
          "<frenchValue>Options</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuLanguage</name>",
          "<englishValue>Language</englishValue>",
          "<frenchValue>Langage</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuLanguageEnglish</name>",
          "<englishValue>English</englishValue>",
          "<frenchValue>Anglais</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuLanguageFrench</name>",
          "<englishValue>French</englishValue>",
          "<frenchValue>Français</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuHelp</name>",
          "<englishValue>Help</englishValue>",
          "<frenchValue>Aide</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuHelpSummary</name>",
          "<englishValue>Summary</englishValue>",
          "<frenchValue>Sommaire</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuHelpIndex</name>",
          "<englishValue>Index</englishValue>",
          "<frenchValue>Index</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuHelpSearch</name>",
          "<englishValue>Search</englishValue>",
          "<frenchValue>Rechercher</frenchValue>",
        "</term>",
        "<term>",
          "<name>MenuHelpAbout</name>",
          "<englishValue>About</englishValue>",
          "<frenchValue>A propos de ...</frenchValue>",
        "</term>",
        "</terms>",
        "</Document>"
      };
      StreamWriter sw = new StreamWriter(Settings.Default.LanguageFileName);
      foreach (string item in minimumVersion)
      {
        sw.WriteLine(item);
      }

      sw.Close();
    }

    private void GetWindowValue()
    {
      Width = Settings.Default.WindowWidth;
      Height = Settings.Default.WindowHeight;
      Top = Settings.Default.WindowTop < 0 ? 0 : Settings.Default.WindowTop;
      Left = Settings.Default.WindowLeft < 0 ? 0 : Settings.Default.WindowLeft;
      comboBoxVSVersion.SelectedIndex = Settings.Default.comboBoxVSVersion;
      textBoxVSProjectPath.Text = Settings.Default.textBoxVSProjectPath;
      checkBoxGitBashInstalled.Checked = Settings.Default.checkBoxGitBashInstalled;
      textBoxGitBashBinariesPath.Text = Settings.Default.textBoxGitBashBinariesPath;
      checkBoxCreateUpdateFile.Checked = Settings.Default.checkBoxCreateUpdateFile;
    }

    private void SaveWindowValue()
    {
      Settings.Default.WindowHeight = Height;
      Settings.Default.WindowWidth = Width;
      Settings.Default.WindowLeft = Left;
      Settings.Default.WindowTop = Top;
      Settings.Default.LastLanguageUsed = frenchToolStripMenuItem.Checked ? "French" : "English";
      Settings.Default.comboBoxVSVersion = comboBoxVSVersion.SelectedIndex;
      Settings.Default.textBoxVSProjectPath = textBoxVSProjectPath.Text;
      Settings.Default.checkBoxGitBashInstalled = checkBoxGitBashInstalled.Checked;
      Settings.Default.textBoxGitBashBinariesPath = textBoxGitBashBinariesPath.Text;
      Settings.Default.checkBoxCreateUpdateFile = checkBoxCreateUpdateFile.Checked;
      Settings.Default.Save();
    }

    private void FormMainFormClosing(object sender, FormClosingEventArgs e)
    {
      SaveWindowValue();
    }

    private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _currentLanguage = Language.French.ToString();
      SetLanguage(Language.French.ToString());
    }

    private void englishToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _currentLanguage = Language.English.ToString();
      SetLanguage(Language.English.ToString());
    }

    private void SetLanguage(string myLanguage)
    {
      switch (myLanguage)
      {
        case "English":
          frenchToolStripMenuItem.Checked = false;
          englishToolStripMenuItem.Checked = true;
          fileToolStripMenuItem.Text = _languageDicoEn["MenuFile"];
          newToolStripMenuItem.Text = _languageDicoEn["MenuFileNew"];
          openToolStripMenuItem.Text = _languageDicoEn["MenuFileOpen"];
          saveToolStripMenuItem.Text = _languageDicoEn["MenuFileSave"];
          saveasToolStripMenuItem.Text = _languageDicoEn["MenuFileSaveAs"];
          printPreviewToolStripMenuItem.Text = _languageDicoEn["MenuFilePrint"];
          printPreviewToolStripMenuItem.Text = _languageDicoEn["MenufilePageSetup"];
          quitToolStripMenuItem.Text = _languageDicoEn["MenufileQuit"];
          editToolStripMenuItem.Text = _languageDicoEn["MenuEdit"];
          cancelToolStripMenuItem.Text = _languageDicoEn["MenuEditCancel"];
          redoToolStripMenuItem.Text = _languageDicoEn["MenuEditRedo"];
          cutToolStripMenuItem.Text = _languageDicoEn["MenuEditCut"];
          copyToolStripMenuItem.Text = _languageDicoEn["MenuEditCopy"];
          pasteToolStripMenuItem.Text = _languageDicoEn["MenuEditPaste"];
          selectAllToolStripMenuItem.Text = _languageDicoEn["MenuEditSelectAll"];
          toolsToolStripMenuItem.Text = _languageDicoEn["MenuTools"];
          personalizeToolStripMenuItem.Text = _languageDicoEn["MenuToolsCustomize"];
          optionsToolStripMenuItem.Text = _languageDicoEn["MenuToolsOptions"];
          languagetoolStripMenuItem.Text = _languageDicoEn["MenuLanguage"];
          englishToolStripMenuItem.Text = _languageDicoEn["MenuLanguageEnglish"];
          frenchToolStripMenuItem.Text = _languageDicoEn["MenuLanguageFrench"];
          helpToolStripMenuItem.Text = _languageDicoEn["MenuHelp"];
          summaryToolStripMenuItem.Text = _languageDicoEn["MenuHelpSummary"];
          indexToolStripMenuItem.Text = _languageDicoEn["MenuHelpIndex"];
          searchToolStripMenuItem.Text = _languageDicoEn["MenuHelpSearch"];
          aboutToolStripMenuItem.Text = _languageDicoEn["MenuHelpAbout"];
          labelSelectVSProjects.Text = _languageDicoEn["Select the Visual Studio projects you want to update"];
          labelChooseVSVersion.Text = _languageDicoEn["Choose the Visual Studio version:"];
          labelPickDirectory.Text = _languageDicoEn["or pick directory:"];
          checkBoxGitBashInstalled.Text = _languageDicoEn["GitBash installed"];
          buttonUpdateVSProjects.Text = _languageDicoEn["Update selected Visual Studio Projects"];
          buttonScannWholePC.Text = _languageDicoEn["Scan whole Pc"];
          buttonLoadVSProjects.Text = _languageDicoEn["Search for Visual Studio Projects"];
          checkBoxCreateUpdateFile.Text = _languageDicoEn["Create script file"];
          buttonCheckUncheckAll.Text = _languageDicoEn["Check/Uncheck All"];
          _currentLanguage = "English";
          break;
        case "French":
          frenchToolStripMenuItem.Checked = true;
          englishToolStripMenuItem.Checked = false;
          fileToolStripMenuItem.Text = _languageDicoFr["MenuFile"];
          newToolStripMenuItem.Text = _languageDicoFr["MenuFileNew"];
          openToolStripMenuItem.Text = _languageDicoFr["MenuFileOpen"];
          saveToolStripMenuItem.Text = _languageDicoFr["MenuFileSave"];
          saveasToolStripMenuItem.Text = _languageDicoFr["MenuFileSaveAs"];
          printPreviewToolStripMenuItem.Text = _languageDicoFr["MenuFilePrint"];
          printPreviewToolStripMenuItem.Text = _languageDicoFr["MenufilePageSetup"];
          quitToolStripMenuItem.Text = _languageDicoFr["MenufileQuit"];
          editToolStripMenuItem.Text = _languageDicoFr["MenuEdit"];
          cancelToolStripMenuItem.Text = _languageDicoFr["MenuEditCancel"];
          redoToolStripMenuItem.Text = _languageDicoFr["MenuEditRedo"];
          cutToolStripMenuItem.Text = _languageDicoFr["MenuEditCut"];
          copyToolStripMenuItem.Text = _languageDicoFr["MenuEditCopy"];
          pasteToolStripMenuItem.Text = _languageDicoFr["MenuEditPaste"];
          selectAllToolStripMenuItem.Text = _languageDicoFr["MenuEditSelectAll"];
          toolsToolStripMenuItem.Text = _languageDicoFr["MenuTools"];
          personalizeToolStripMenuItem.Text = _languageDicoFr["MenuToolsCustomize"];
          optionsToolStripMenuItem.Text = _languageDicoFr["MenuToolsOptions"];
          languagetoolStripMenuItem.Text = _languageDicoFr["MenuLanguage"];
          englishToolStripMenuItem.Text = _languageDicoFr["MenuLanguageEnglish"];
          frenchToolStripMenuItem.Text = _languageDicoFr["MenuLanguageFrench"];
          helpToolStripMenuItem.Text = _languageDicoFr["MenuHelp"];
          summaryToolStripMenuItem.Text = _languageDicoFr["MenuHelpSummary"];
          indexToolStripMenuItem.Text = _languageDicoFr["MenuHelpIndex"];
          searchToolStripMenuItem.Text = _languageDicoFr["MenuHelpSearch"];
          aboutToolStripMenuItem.Text = _languageDicoFr["MenuHelpAbout"];
          labelChooseVSVersion.Text = _languageDicoFr["Choose the Visual Studio version:"];
          labelPickDirectory.Text = _languageDicoFr["or pick directory:"];
          checkBoxGitBashInstalled.Text = _languageDicoFr["GitBash installed"];
          buttonUpdateVSProjects.Text = _languageDicoFr["Update selected Visual Studio Projects"];
          labelSelectVSProjects.Text = _languageDicoFr["Select the Visual Studio projects you want to update"];
          buttonScannWholePC.Text = _languageDicoFr["Scan whole Pc"];
          buttonLoadVSProjects.Text = _languageDicoFr["Search for Visual Studio Projects"];
          checkBoxCreateUpdateFile.Text = _languageDicoFr["Create script file"];
          buttonCheckUncheckAll.Text = _languageDicoFr["Check/Uncheck All"];
          _currentLanguage = "French";
          break;
      }
    }

    private void cutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      List<Control> listOfCtrl = new List<Control> { textBoxVSProjectPath, textBoxGitBashBinariesPath };
      Control focusedControl = FindFocusedControl(listOfCtrl);
      var tb = focusedControl as TextBox;
      if (tb != null)
      {
        CutToClipboard(tb);
      }
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control focusedControl = FindFocusedControl(new List<Control> { textBoxVSProjectPath, textBoxGitBashBinariesPath });
      var tb = focusedControl as TextBox;
      if (tb != null)
      {
        CopyToClipboard(tb);
      }
    }

    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control focusedControl = FindFocusedControl(new List<Control> { textBoxVSProjectPath, textBoxGitBashBinariesPath });
      var tb = focusedControl as TextBox;
      if (tb != null)
      {
        PasteFromClipboard(tb);
      }
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control focusedControl = FindFocusedControl(new List<Control> { textBoxVSProjectPath, textBoxGitBashBinariesPath });
      if (focusedControl is TextBox)
      {
        ((TextBox)focusedControl).SelectAll();
      }
    }

    private void CutToClipboard(TextBoxBase tb, string errorMessage = "nothing")
    {
      if (tb != ActiveControl) return;
      if (tb.Text == string.Empty)
      {
        DisplayMessageOk(GetTranslatedString("ThereIs") + OneSpace +
          GetTranslatedString(errorMessage) + OneSpace +
          GetTranslatedString("ToCut") + OneSpace, GetTranslatedString(errorMessage),
          MessageBoxButtons.OK);
        return;
      }

      if (tb.SelectedText == string.Empty)
      {
        DisplayMessageOk(GetTranslatedString("NoTextHasBeenSelected"),
          GetTranslatedString(errorMessage), MessageBoxButtons.OK);
        return;
      }

      Clipboard.SetText(tb.SelectedText);
      tb.SelectedText = string.Empty;
    }

    private void CopyToClipboard(TextBoxBase tb, string message = "nothing")
    {
      if (tb != ActiveControl) return;
      if (tb.Text == string.Empty)
      {
        DisplayMessageOk(GetTranslatedString("ThereIsNothingToCopy") + OneSpace,
          GetTranslatedString(message), MessageBoxButtons.OK);
        return;
      }

      if (tb.SelectedText == string.Empty)
      {
        DisplayMessageOk(GetTranslatedString("NoTextHasBeenSelected"),
          GetTranslatedString(message), MessageBoxButtons.OK);
        return;
      }

      Clipboard.SetText(tb.SelectedText);
    }

    private void PasteFromClipboard(TextBoxBase tb)
    {
      if (tb != ActiveControl) return;
      var selectionIndex = tb.SelectionStart;
      tb.Text = tb.Text.Insert(selectionIndex, Clipboard.GetText());
      tb.SelectionStart = selectionIndex + Clipboard.GetText().Length;
    }

    private void DisplayMessageOk(string message, string title, MessageBoxButtons buttons)
    {
      MessageBox.Show(this, message, title, buttons);
    }

    private string GetTranslatedString(string index)
    {
      string result = string.Empty;
      switch (_currentLanguage.ToLower())
      {
        case "english":
          result = _languageDicoEn.ContainsKey(index) ? _languageDicoEn[index] :
           "the term: \"" + index + "\" has not been translated yet.\nPlease tell the developer to translate this term";
          break;
        case "french":
          result = _languageDicoFr.ContainsKey(index) ? _languageDicoFr[index] :
            "the term: \"" + index + "\" has not been translated yet.\nPlease tell the developer to translate this term";
          break;
      }

      return result;
    }

    private static Control FindFocusedControl0(Control container)
    {
      foreach (Control childControl in container.Controls.Cast<Control>().Where(childControl => childControl.Focused))
      {
        return childControl;
      }

      return (from Control childControl in container.Controls
              select FindFocusedControl0(childControl)).FirstOrDefault(maybeFocusedControl => maybeFocusedControl != null);
    }

    private static Control FindFocusedControl(IEnumerable<Control> container)
    {
      return container.FirstOrDefault(control => control.Focused);
    }

    private static Control FindFocusedControl(List<Control> container)
    {
      return container.FirstOrDefault(control => control.Focused);
    }

    private void buttonVSVersionGetPath_Click(object sender, EventArgs e)
    {
      textBoxVSProjectPath.Text = ChooseDirectory();
    }

    private static string ChooseDirectory()
    {
      string result = string.Empty;
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        result = fbd.SelectedPath;
      }

      return result;
    }

    private static string ChooseOneFile(string filter = "All files (*.*)|*.*")
    {
      string result = string.Empty;
      FileDialog fd = new OpenFileDialog();
      fd.Filter = filter;
      if (fd.ShowDialog() == DialogResult.OK)
      {
        result = fd.FileName;
      }

      return result;
    }

    private void buttonGitBashBinPath_Click(object sender, EventArgs e)
    {
      textBoxGitBashBinariesPath.Text = ChooseOneFile("git executable (git.exe)|git.exe");
    }

    private void buttonUpdateVSProjects_Click(object sender, EventArgs e)
    {
      if (listViewVSProjects.Items.Count == 0)
      {
        DisplayMessageOk(GetTranslatedString("The list doesn't have any Visual Studio project to update") +
          Period + Crlf + GetTranslatedString("Enter a correct path and search project again"),
          GetTranslatedString("List empty"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, GetTranslatedString("The list doesn't have any Visual Studio project to update"));
        return;
      }

      var selectedProjects = listViewVSProjects.CheckedItems;
      if (selectedProjects.Count == 0)
      {
        DisplayMessageOk(GetTranslatedString("No project has been selected") +
          Period + Crlf + GetTranslatedString("Select at least one project"),
          GetTranslatedString("No selection"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, GetTranslatedString("No project has been selected"));
        return;
      }

      var gitBinaryPath = "\\GIT\\bin\\git.exe"; // valid for x86 and x64 pc because of (x86) directory
      string pathVariable = Environment.GetEnvironmentVariable("Path");
      if (pathVariable != null && !pathVariable.Contains(gitBinaryPath))
      {
        DisplayMessageOk(GetTranslatedString("The Path variable does not have the path to the GitBash binaries"),
          GetTranslatedString("Path variable no GitBash binaries"), MessageBoxButtons.OK);
        return;
      }

      Logger.Add(textBoxLog, GetTranslatedString("Updating selected projects"));
      if (checkBoxCreateUpdateFile.Checked)
      {
        Logger.Add(textBoxLog, GetTranslatedString("Creating the update.bat script"));
        Logger.Add(textBoxLog, GetTranslatedString("in"));
        Logger.Add(textBoxLog, textBoxVSProjectPath.Text);
      }

      string updateScript = Path.Combine(textBoxVSProjectPath.Text, "update.bat");
      // check if updateScript doesn't already exist, if so, increment the name
      updateScript = GenerateUniqueFileName(updateScript);
      CreateNewFile(updateScript);
      AddBeginningOfScript(updateScript);

      foreach (ListViewItem selectedProj in selectedProjects)
      {
        var projectName = selectedProj.Text;
        AddGitPullToScript(updateScript, projectName);
        Logger.Add(textBoxLog, GetTranslatedString("Adding the selected project") + OneSpace + projectName);
      }

      AddPauseToFile(updateScript);
      Process task = new Process
      {
        StartInfo =
        {
          UseShellExecute = true,
          FileName = updateScript,
          CreateNoWindow = false
        }
      };

      task.Start();
    }

    private void AddPauseToFile(string fileName)
    {
      const bool append = true;
      StreamWriter sw = new StreamWriter(fileName, append);
      sw.WriteLine("REM " + GetTranslatedString("Press a key to exit"));
      sw.WriteLine("pause");
      sw.Close();
    }

    private static void AddGitPullToScript(string fileName, string directoryName)
    {
      const bool append = true;
      StreamWriter sw = new StreamWriter(fileName, append);
      sw.WriteLine("cd \"" + directoryName + "\"");
      sw.WriteLine("git pull origin master");
      sw.WriteLine("cd ..");
      sw.Close();
    }

    private void AddBeginningOfScript(string fileName)
    {
      const bool append = true;
      StreamWriter sw = new StreamWriter(fileName, append);
      sw.WriteLine("REM Batch script generated automatically by GitAutoUpdateGui");
      sw.WriteLine("REM Source and executable can be found at");
      sw.WriteLine("REM https://github.com/fredatgithub/GitAutoUpdate");
      sw.WriteLine("REM created by Freddy Juhel on the 31st of July 2015");
      sw.WriteLine("REM If you have any error, check that GitBash is installed");
      sw.WriteLine("REM then add C:\\Program Files\\Git\\bin to the environment PATH variable and reboot you PC");
      sw.WriteLine("cd \\");
      sw.WriteLine("cd " + textBoxVSProjectPath.Text);
      sw.Close();
    }

    private static void CreateNewFile(string fileName)
    {
      const bool doNotAppend = false;
      StreamWriter sw = new StreamWriter(fileName, doNotAppend, Encoding.UTF8);
      sw.Close();
    }

    private static string GenerateUniqueFileName(string fileName)
    {
      string result = string.Empty;
      if (!File.Exists(fileName))
      {
        return fileName;
      }

      int fileNumber = 1;
      result = AddAtTheEndOfFileName(fileName, fileNumber.ToString(CultureInfo.InvariantCulture));
      while (File.Exists(result))
      {
        fileNumber++;
        result = AddAtTheEndOfFileName(fileName, fileNumber.ToString(CultureInfo.InvariantCulture));
      }

      return result;
    }

    private static string AddAtTheEndOfFileName(string fileName, string textToBeAdded)
    {
      const string backslash = "\\";
      string result = GetDirectoryFileNameAndExtension(fileName)[0] + backslash
                                 + GetDirectoryFileNameAndExtension(fileName)[1]
                                 + textToBeAdded
                                 + GetDirectoryFileNameAndExtension(fileName)[2];
      return result;
    }

    private void buttonLoadVSProjects_Click(object sender, EventArgs e)
    {
      Logger.Clear(textBoxLog);
      Logger.Add(textBoxLog, GetTranslatedString("Clearing past results"));
      if (textBoxVSProjectPath.Text == string.Empty)
      {
        DisplayMessageOk(GetTranslatedString("The Visual Studio project directory path is empty") +
          Period + Crlf + GetTranslatedString("Enter a correct path"),
          GetTranslatedString("Directory empty"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, GetTranslatedString("The Visual Studio project directory path is empty"));
        return;
      }

      if (!Directory.Exists(textBoxVSProjectPath.Text))
      {
        DisplayMessageOk(GetTranslatedString("The Visual Studio project directory path doesn't exist") +
          Period + Crlf + GetTranslatedString("Enter a correct path"),
          GetTranslatedString("Wrong Directory"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, GetTranslatedString("The Visual Studio project directory path doesn't exist"));
        return;
      }

      if (!Directory.EnumerateDirectories(textBoxVSProjectPath.Text).Any())
      {
        DisplayMessageOk(GetTranslatedString("The Visual Studio project directory is empty") +
          Period + Crlf + GetTranslatedString("Enter a correct path"),
          GetTranslatedString("Directory empty"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, GetTranslatedString("The Visual Studio project directory is empty"));
        return;
      }

      // verification of GitBash in textBoxGitBashBinariesPath
      if (textBoxGitBashBinariesPath.Text == string.Empty)
      {
        DisplayMessageOk(GetTranslatedString("The GitBash directory path is empty") +
          Period + Crlf + GetTranslatedString("Enter a correct path"),
          GetTranslatedString("Directory empty"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, GetTranslatedString("The GitBash directory path is empty"));
        return;
      }

      if (!File.Exists(textBoxGitBashBinariesPath.Text))
      {
        DisplayMessageOk(GetTranslatedString("The executable GitBash directory path doesn't exist") +
          Period + Crlf + GetTranslatedString("Enter a correct path"),
          GetTranslatedString("Wrong Directory"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, GetTranslatedString("The executable GitBash directory path doesn't exist"));
        return;
      }

      Logger.Add(textBoxLog, GetTranslatedString("Searching for Visual Studio projects"));

      listViewVSProjects.Items.Clear();

      listViewVSProjects.Columns.Add("To be updated", 240, HorizontalAlignment.Left);
      listViewVSProjects.Columns.Add("Solution Name", 240, HorizontalAlignment.Left);
      listViewVSProjects.Columns.Add("Solution Path", 640, HorizontalAlignment.Left);

      listViewVSProjects.View = View.Details;
      listViewVSProjects.LabelEdit = false;
      listViewVSProjects.AllowColumnReorder = true;
      listViewVSProjects.CheckBoxes = true;
      listViewVSProjects.FullRowSelect = true;
      listViewVSProjects.GridLines = true;
      listViewVSProjects.Sorting = SortOrder.None;
      int projectCount = 0;
      foreach (var directory in Directory.EnumerateDirectories(textBoxVSProjectPath.Text))
      {
        //Logger.Add(textBoxLog, directories); // for debug
        var filteredFiles = Directory.GetFiles(directory, "*.sln").ToList();
        foreach (var solutionName in filteredFiles)
        {
          var tmpSolPath = GetDirectoryFileNameAndExtension(solutionName)[0];
          var tmpSolNameOnly0 = GetDirectoryFileNameAndExtension(solutionName)[0];
          var tmpSolNameOnly = tmpSolNameOnly0.Substring(tmpSolNameOnly0.LastIndexOf('\\') + 1);

          var subfilteredDirs = Directory.EnumerateDirectories(tmpSolPath, "*.git").ToList();
          if (subfilteredDirs.Count != 0)
          {
            //Logger.Add(textBoxLog, solutionName); // for debug
            ListViewItem item1 = new ListViewItem(tmpSolNameOnly) { Checked = false };
            item1.SubItems.Add(tmpSolNameOnly);
            item1.SubItems.Add(tmpSolPath);
            listViewVSProjects.Items.Add(item1);
            projectCount++;
          }
        }
      }

      Logger.Add(textBoxLog, projectCount + OneSpace + GetTranslatedString("project") + Plural(projectCount) +
        OneSpace + GetTranslatedString(Plural(projectCount, "has")) + OneSpace +
        GetTranslatedString("been found") + FrenchPlural(projectCount));
      buttonUpdateVSProjects.Enabled = true;
    }

    private string FrenchPlural(int number)
    {
      return (number > 1 && _currentLanguage.ToLower() == "french") ? "s" : string.Empty;
    }

    private static string Plural(int number, string irregularNoun = "")
    {
      switch (irregularNoun)
      {
        case "":
          return number > 1 ? "s" : string.Empty;
        case "al":
          return number > 1 ? "aux" : "al";
        case "au":
          return number > 1 ? "aux" : "au";
        case "eau":
          return number > 1 ? "eaux" : "eau";
        case "eu":
          return number > 1 ? "eux" : "eu";
        case "landau":
          return number > 1 ? "landaus" : "landau";
        case "sarrau":
          return number > 1 ? "sarraus" : "sarrau";
        case "bleu":
          return number > 1 ? "bleus" : "bleu";
        case "émeu":
          return number > 1 ? "émeus" : "émeu";
        case "lieu":
          return number > 1 ? "lieux" : "lieu";
        case "pneu":
          return number > 1 ? "pneus" : "pneu";
        case "aval":
          return number > 1 ? "avals" : "aval";
        case "bal":
          return number > 1 ? "bals" : "bal";
        case "chacal":
          return number > 1 ? "chacals" : "chacal";
        case "carnaval":
          return number > 1 ? "carnavals" : "carnaval";
        case "festival":
          return number > 1 ? "festivals" : "festival";
        case "récital":
          return number > 1 ? "récitals" : "récital";
        case "régal":
          return number > 1 ? "régals" : "régal";
        case "cal":
          return number > 1 ? "cals" : "cal";
        case "serval":
          return number > 1 ? "servals" : "serval";
        case "choral":
          return number > 1 ? "chorals" : "choral";
        case "narval":
          return number > 1 ? "narvals" : "narval";
        case "bail":
          return number > 1 ? "baux" : "bail";
        case "corail":
          return number > 1 ? "coraux" : "corail";
        case "émail":
          return number > 1 ? "émaux" : "émail";
        case "soupirail":
          return number > 1 ? "soupiraux" : "soupirail";
        case "travail":
          return number > 1 ? "travaux" : "travail";
        case "vantail":
          return number > 1 ? "vantaux" : "vantail";
        case "vitrail":
          return number > 1 ? "vitraux" : "vitrail";
        case "bijou":
          return number > 1 ? "bijoux" : "bijou";
        case "caillou":
          return number > 1 ? "cailloux" : "caillou";
        case "chou":
          return number > 1 ? "choux" : "chou";
        case "genou":
          return number > 1 ? "genoux" : "genou";
        case "hibou":
          return number > 1 ? "hiboux" : "hibou";
        case "joujou":
          return number > 1 ? "joujoux" : "joujou";
        case "pou":
          return number > 1 ? "poux" : "pou";
        case "est":
          return number > 1 ? "sont" : "est";

        // English
        case " is":
          return number > 1 ? "s are" : " is"; // with a space before
        case "is":
          return number > 1 ? "are" : "is"; // without a space before
        case "The":
          return "The"; // CAPITAL useful when used with GetTranslatedString method
        case "the":
          return "the"; // lower case useful when used with GetTranslatedString method
        case "has":
          return number > 1 ? "have" : "has";
        default:
          return number > 1 ? "s" : string.Empty;
      }
    }

    private static string[] GetDirectoryFileNameAndExtension(string filePath)
    {
      string directory = Path.GetDirectoryName(filePath);
      string fileName = Path.GetFileNameWithoutExtension(filePath);
      string extension = Path.GetExtension(filePath);

      return new[] { directory, fileName, extension };
    }

    private void textBoxGitBashBinariesPath_TextChanged(object sender, EventArgs e)
    {
      CheckGitBashBinary();
      buttonUpdateVSProjects.Enabled = false;
    }

    private void CheckGitBashBinary()
    {
      checkBoxGitBashInstalled.Enabled = true;
      if (File.Exists(textBoxGitBashBinariesPath.Text))
      {
        checkBoxGitBashInstalled.Checked = true;
        checkBoxGitBashInstalled.Text = GetTranslatedString("GitBash installed");
        checkBoxGitBashInstalled.BackColor = Color.Green;
      }
      else
      {
        checkBoxGitBashInstalled.Checked = false;
        checkBoxGitBashInstalled.Text = GetTranslatedString("GitBash not installed");
        checkBoxGitBashInstalled.BackColor = Color.Red;
      }
      
      checkBoxGitBashInstalled.Enabled = false;
    }

    private void textBoxVSProjectPath_TextChanged(object sender, EventArgs e)
    {
      buttonUpdateVSProjects.Enabled = false;
    }

    private void buttonCheckUncheckAll_Click(object sender, EventArgs e)
    {
      if (listViewVSProjects.Items.Count != 0)
      {
        ToggleAllItems(listViewVSProjects);
      }
    }

    private static void CheckAllItems(ListView lvw, bool check)
    {
      lvw.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = check);
    }

    private static void ToggleAllItems(ListView lvw)
    {
      lvw.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = !item.Checked);
    }

    private void comboBoxVSVersion_SelectedIndexChanged(object sender, EventArgs e)
    {
      const string backSlash = "\\";
      string userProfile = Environment.GetEnvironmentVariable("USERPROFILE"); // C:\Users\userName
      if (userProfile == string.Empty)
      {
        DisplayMessageOk(GetTranslatedString("The USERPROFILE variable cannot be empty"),
          GetTranslatedString("USERPROFILE variable empty"), MessageBoxButtons.OK);
        return;
      }

      string vsVersion = GetNumbers(comboBoxVSVersion.SelectedItem.ToString());
      string documentsPath = Environment.SpecialFolder.MyDocuments.ToString();
      if (userProfile != null && !Directory.Exists(Path.Combine(userProfile, documentsPath)))
      {
        documentsPath = Environment.SpecialFolder.MyDocuments.ToString().Substring(2);
      }

      //string programFiles = Environment.GetEnvironmentVariable("ProgramFiles"); // C:\Program Files
      textBoxVSProjectPath.Text = userProfile + backSlash + documentsPath + @"\Visual Studio " + vsVersion + @"\Projects";
    }

    private static string GetNumbers(string myString)
    {
      return myString.Where(Char.IsNumber).Aggregate(string.Empty, (current, c) => current + c);
    }
  }
}