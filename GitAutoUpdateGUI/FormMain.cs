#define Debug
using GitAutoUpdateGUI.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using Tools;

namespace GitAutoUpdateGUI
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private readonly Dictionary<string, string> _languageDicoEn = new Dictionary<string, string>();
    private readonly Dictionary<string, string> _languageDicoFr = new Dictionary<string, string>();
    private string _currentLanguage = "english";
    private float _fontSize;
    private bool settingsHaveChanged;
    private List<string> _previousUpdateFileList = new List<string>();

    private void QuitToolStripMenuItemClick(object sender, EventArgs e)
    {
      SaveWindowValue();
      Application.Exit();
    }

    private void AboutToolStripMenuItemClick(object sender, EventArgs e)
    {
      AboutBoxApplication aboutBoxApplication = new AboutBoxApplication();
      aboutBoxApplication.ShowDialog();
    }

    /// <summary>Add the version to the title of the main form</summary>
    private void DisplayTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      Text += $" V{fvi.FileMajorPart}.{fvi.FileMinorPart}.{fvi.FileBuildPart}.{fvi.FilePrivatePart}";
    }

    private void FormMainLoad(object sender, EventArgs e)
    {
      LoadSettingsAtStartup();
    }

    private void LoadSettingsAtStartup()
    {
      DisplayTitle();
      LoadComboBoxVsVersions(comboBoxVSVersion);
      LoadCheckedListBoxVsVersion();
      LoadLanguages();
      SetLanguage(Settings.Default.LastLanguageUsed);
      GetWindowValue();
      AdjustAllControls();
      CheckGitBashBinary();
      CheckGitBashPathInWinPath();
      EnableDisableButtons(listViewVSProjects, buttonCheckAll, buttonClearAll, buttonCheckUncheckAll, buttonUpdateVSProjects);
      VerifyCheckedVersion();
      buttonUpdateCheckedVersion.Enabled = checkedListBoxVSVersion.CheckedItems.Count != 0;
    }

    private void VerifyCheckedVersion()
    {
      // disable all versions that don't have an update cmd script
      List<string> checkedVersion = GetCheckedItemFromCheckedListBox(checkedListBoxVSVersion);
      settingsHaveChanged = true;
      string userProfile = Environment.GetEnvironmentVariable("USERPROFILE"); // C:\Users\userName
      if (userProfile == string.Empty)
      {
        DisplayMessageOk(Translate("The USERPROFILE variable cannot be empty"),
          Translate("USERPROFILE variable empty"), MessageBoxButtons.OK);
        return;
      }

      string vsVersion = GetNumbers(comboBoxVSVersion.SelectedItem.ToString());
      string documentsPath = Environment.SpecialFolder.MyDocuments.ToString();
      if (userProfile != null && !Directory.Exists(Path.Combine(userProfile, documentsPath)))
      {
        documentsPath = Environment.SpecialFolder.MyDocuments.ToString().Substring(2);
      }

      foreach (var item in checkedVersion)
      {
        string vsPath = Path.Combine(userProfile, documentsPath, item, "Projects");

        if (File.Exists(Path.Combine(vsPath, GetLatestFile(vsPath, "update*.bat"))))
        {
          // enable item
        }
        else
        {
          // disable item
        }
      }
    }

    public static string GetLatestFile(string directoryPath, string patternFileName)
    {
      var directory = new DirectoryInfo(directoryPath);
      //string[] allFiles = Directory.GetFiles(directoryPath, searchPattern: patternFileName);
      if (Directory.Exists(directoryPath))
      {
        var result = (from f in directory.GetFiles(patternFileName, SearchOption.TopDirectoryOnly)
                      orderby f.LastWriteTime descending
                      select f).FirstOrDefault();
        if (result != null)
        {
          return result.Name;
        }
      }

      return string.Empty;
    }

    private static List<string> GetCheckedItemFromCheckedListBox(CheckedListBox checkedListBoxVsVersion)
    {
      List<string> result = new List<string>();
      foreach (var item in checkedListBoxVsVersion.CheckedItems)
      {
        result.Add(item.ToString());
      }

      return result;
    }

    /// <summary>Enable or Disable all passed-in controls</summary>
    /// <param name="conditionalListView">The list view</param>
    /// <param name="listOfControls">The list of controls</param>
    private static void EnableDisableButtons(ListView conditionalListView, params Control[] listOfControls)
    {
      if (conditionalListView.Items.Count == 0)
      {
        foreach (var control in listOfControls)
        {
          control.Enabled = false;
        }
      }
      else
      {
        foreach (var control in listOfControls)
        {
          control.Enabled = true;
        }
      }
    }

    private void CheckGitBashPathInWinPath()
    {
      checkBoxGitInPath.Enabled = true;
      if (IsInWinPath("\\Git\\bin") || GitIsInstalled())
      {
        checkBoxGitInPath.Checked = true;
        checkBoxGitInPath.Text = Translate("GitBash binary path in Windows Path variable");
        checkBoxGitInPath.BackColor = Color.LightGreen;
#if Debug
        // buttonAddGitBinaryToWinPath.Enabled = true;
#else
        buttonAddGitBinaryToWinPath.Enabled = false;
#endif
      }
      else
      {
        checkBoxGitInPath.Checked = false;
        checkBoxGitInPath.Text = Translate("GitBash binary path not in Windows Path variable");
        checkBoxGitInPath.BackColor = Color.Red;
        buttonAddGitBinaryToWinPath.Enabled = true;
      }

      checkBoxGitInPath.Enabled = false;
    }

    private static bool GitIsInstalled()
    {
      bool result = false;
      List<string> listOfGitInstallation = new List<string>
      {
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Git\\bin",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Git\\cmd",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Git\\mingw32\\bin",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Git\\mingw32\\libexec\\git-core",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Microsoft Visual Studio\\2017\\Professional\\Common7\\IDE\\CommonExtensions\\Microsoft\\TeamFoundation\\Team Explorer\\Git\\cmd",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Microsoft Visual Studio\\2017\\Professional\\Common7\\IDE\\CommonExtensions\\Microsoft\\TeamFoundation\\Team Explorer\\Git\\mingw32\\bin",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Microsoft Visual Studio 14.0\\Web\\External\\git",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Substring(0,21)}\\Local\\Atlassian\\SourceTree\\git_local\\bin",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Substring(0,21)}\\Local\\Atlassian\\SourceTree\\git_local\\cmd",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Substring(0,21)}\\Local\\Atlassian\\SourceTree\\git_local\\libexec\\git-core",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Substring(0,21)}\\Local\\atom\\app-1.20.1\\resources\\app\\node_modules\\dugite\\git\\mingw64\\bin"
      };

      foreach (string file in listOfGitInstallation)
      {
        if (!File.Exists($"{file}\\git.exe")) continue;
        result = true;
        break;
      }

      return result;
    }

    private static string GetGitPath()
    {
      string result = string.Empty;
      List<string> listOfGitInstallation = new List<string>
      {
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Git\\bin",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Git\\cmd",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Git\\mingw32\\bin",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Git\\mingw32\\libexec\\git-core",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Microsoft Visual Studio\\2017\\Professional\\Common7\\IDE\\CommonExtensions\\Microsoft\\TeamFoundation\\Team Explorer\\Git\\cmd",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Microsoft Visual Studio\\2017\\Professional\\Common7\\IDE\\CommonExtensions\\Microsoft\\TeamFoundation\\Team Explorer\\Git\\mingw32\\bin",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Microsoft Visual Studio 14.0\\Web\\External\\git",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Substring(0,21)}\\Local\\Atlassian\\SourceTree\\git_local\\bin",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Substring(0,21)}\\Local\\Atlassian\\SourceTree\\git_local\\cmd",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Substring(0,21)}\\Local\\Atlassian\\SourceTree\\git_local\\libexec\\git-core",
        $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Substring(0,21)}\\Local\\atom\\app-1.20.1\\resources\\app\\node_modules\\dugite\\git\\mingw64\\bin"
      };

      foreach (string file in listOfGitInstallation)
      {
        if (!File.Exists($"{file}\\git.exe")) continue;
        result = $"{file}\\";
        break;
      }

      return result;
    }

    /// <summary>Check if parameter is in Windows Path</summary>
    /// <param name="substring">The string to check</param>
    /// <returns>A boolean stating if the string is in Windows path</returns>
    private static bool IsInWinPath(string substring)
    {
      bool result = false;
      string winPath = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
      if (winPath != null) result = winPath.Contains(substring);
      return result;
    }

    private static void ClearComboBox(ComboBox comboBox)
    {
      comboBox.Items.Clear();
    }

    private void LoadCheckedListBoxVsVersion()
    {
      checkedListBoxVSVersion.Items.Clear();
      if (!File.Exists(Settings.Default.VisualStudioVersionsFileName))
      {
        CreateVsVersionFile();
      }

      XDocument xmlDoc;
      try
      {
        xmlDoc = XDocument.Load(Settings.Default.VisualStudioVersionsFileName);
      }
      catch (Exception exception)
      {
        MessageBox.Show("Error while loading the " + Settings.Default.VisualStudioVersionsFileName +
                        " xml file: " + exception.Message);
        CreateVsVersionFile();
        return;
      }

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
        if (!checkedListBoxVSVersion.Items.Contains(q.vsNameValue))
        {
          checkedListBoxVSVersion.Items.Add(q.vsNameValue, false);
        }
      }
    }

    private void LoadComboBoxVsVersions(ComboBox comboBox)
    {
      ClearComboBox(comboBox);
      if (!File.Exists(Settings.Default.VisualStudioVersionsFileName))
      {
        CreateVsVersionFile();
      }

      XDocument xmlDoc;
      try
      {
        xmlDoc = XDocument.Load(Settings.Default.VisualStudioVersionsFileName);
      }
      catch (Exception exception)
      {
        MessageBox.Show("Error while loading the " + Settings.Default.VisualStudioVersionsFileName + " xml file: " + exception.Message);
        CreateVsVersionFile();
        return;
      }

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
        if (!comboBoxVSVersion.Items.Contains(q.vsNameValue))
        {
          comboBoxVSVersion.Items.Add(q.vsNameValue);
        }
      }

      comboBoxVSVersion.SelectedIndex = comboBoxVSVersion.Items.Count - 1; // select last item which is the latest version of VS
    }

    /// <summary>Create a default file if none exist</summary>
    private static void CreateVsVersionFile()
    {
      var minimumVersion = new List<string>
      {
        "<?xml version=\"1.0\" encoding=\"utf-8\" ?>",
        "<VSVersions>",
        "<VSVersion>",
        "<name>Visual Studio 2003</name>",
        "</VSVersion>",
        "<VSVersion>",
        "<name>Visual Studio 2005</name>",
        "</VSVersion>",
        "<VSVersion>",
        "<name>Visual Studio 2008</name>",
        "</VSVersion>",
        "<VSVersion>",
        "<name>Visual Studio 2010</name>",
        "</VSVersion>",
        "<VSVersion>",
        "<name>Visual Studio 2012</name>",
        "</VSVersion>",
        "<VSVersion>",
        "<name>Visual Studio 2013</name>",
        "</VSVersion>",
        "<VSVersion>",
        "<name>Visual Studio 2015</name>",
        "</VSVersion>",
        "<VSVersion>",
        "<name>Visual Studio 2017</name>",
        "</VSVersion>",
        "</VSVersions>"
      };

      StreamWriter sw = new StreamWriter(Settings.Default.VisualStudioVersionsFileName);
      foreach (string item in minimumVersion)
      {
        sw.WriteLine(item);
      }

      sw.Close();
    }

    /// <summary>Load all languages</summary>
    private void LoadLanguages()
    {
      if (!File.Exists(Settings.Default.LanguageFileName))
      {
        CreateLanguageFile();
      }

      // read the translation file and feed the language
      XDocument xDoc;
      try
      {
        xDoc = XDocument.Load(Settings.Default.LanguageFileName);
      }
      catch (Exception exception)
      {
        MessageBox.Show("Error while loading " + Settings.Default.LanguageFileName +
          "xml file " + exception.Message);
        CreateLanguageFile();
        return;
      }
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
        if (!_languageDicoEn.ContainsKey(i.name))
        {
          _languageDicoEn.Add(i.name, i.englishValue);
        }
        else
        {
          MessageBox.Show("Your xml file has duplicate like: " + i.name);
        }

        if (!_languageDicoFr.ContainsKey(i.name))
        {
          _languageDicoFr.Add(i.name, i.frenchValue);
        }
        else
        {
          MessageBox.Show("Your xml file has duplicate like: " + i.name);
        }
      }
    }

    /// <summary>Create a new language file if none exist</summary>
    private static void CreateLanguageFile()
    {
      var minimumVersion = new List<string>
      {
        "<?xml version=\"1.0\" encoding=\"utf-8\" ?>",
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
        "</terms>"
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
      checkBoxOnlyGenerateScriptFile.Checked = Settings.Default.checkBoxCreateUpdateFile;
      checkBoxUnlistVSSolution.Checked = Settings.Default.checkBoxUnlistVSSolution;
      textBoxUnlistOldSolution.Text = Settings.Default.textBoxUnlistOldSolution;
      checkBoxCaseSensitive.Checked = Settings.Default.checkBoxCaseSensitive;
      checkBoxGitInPath.Checked = Settings.Default.checkBoxGitInPath;
      _fontSize = Settings.Default._fontSize;

      for (int i = 0; i < checkedListBoxVSVersion.Items.Count; i++)
      {
        switch (i)
        {
          case 0:
            checkedListBoxVSVersion.SetItemChecked(i, Settings.Default.Visual_Studio_2003);
            break;
          case 1:
            checkedListBoxVSVersion.SetItemChecked(i, Settings.Default.Visual_Studio_2005);
            break;
          case 2:
            checkedListBoxVSVersion.SetItemChecked(i, Settings.Default.Visual_Studio_2008);
            break;
          case 3:
            checkedListBoxVSVersion.SetItemChecked(i, Settings.Default.Visual_Studio_2010);
            break;
          case 4:
            checkedListBoxVSVersion.SetItemChecked(i, Settings.Default.Visual_Studio_2012);
            break;
          case 5:
            checkedListBoxVSVersion.SetItemChecked(i, Settings.Default.Visual_Studio_2013);
            break;
          case 6:
            checkedListBoxVSVersion.SetItemChecked(i, Settings.Default.Visual_Studio_2015);
            break;
          case 7:
            checkedListBoxVSVersion.SetItemChecked(i, Settings.Default.Visual_Studio_2017);
            break;
        }
      }
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
      Settings.Default.checkBoxCreateUpdateFile = checkBoxOnlyGenerateScriptFile.Checked;
      Settings.Default.checkBoxUnlistVSSolution = checkBoxUnlistVSSolution.Checked;
      Settings.Default.textBoxUnlistOldSolution = textBoxUnlistOldSolution.Text;
      Settings.Default.checkBoxCaseSensitive = checkBoxCaseSensitive.Checked;
      Settings.Default.checkBoxGitInPath = checkBoxGitInPath.Checked;
      Settings.Default._fontSize = _fontSize;

      Settings.Default.Visual_Studio_2003 = false;
      Settings.Default.Visual_Studio_2005 = false;
      Settings.Default.Visual_Studio_2008 = false;
      Settings.Default.Visual_Studio_2010 = false;
      Settings.Default.Visual_Studio_2012 = false;
      Settings.Default.Visual_Studio_2013 = false;
      Settings.Default.Visual_Studio_2015 = false;
      Settings.Default.Visual_Studio_2017 = false;

      foreach (string vsVersion in ChangeCharacterInList(GetCheckedVsVersion(checkedListBoxVSVersion)))
      {
        if (vsVersion == "Visual_Studio_2003")
        {
          Settings.Default.Visual_Studio_2003 = true;
        }
        else if (vsVersion == "Visual_Studio_2005")
        {
          Settings.Default.Visual_Studio_2005 = true;
        }
        else if (vsVersion == "Visual_Studio_2008")
        {
          Settings.Default.Visual_Studio_2008 = true;
        }
        else if (vsVersion == "Visual_Studio_2010")
        {
          Settings.Default.Visual_Studio_2010 = true;
        }
        else if (vsVersion == "Visual_Studio_2012")
        {
          Settings.Default.Visual_Studio_2012 = true;
        }
        else if (vsVersion == "Visual_Studio_2013")
        {
          Settings.Default.Visual_Studio_2013 = true;
        }
        else if (vsVersion == "Visual_Studio_2015")
        {
          Settings.Default.Visual_Studio_2015 = true;
        }
        else if (vsVersion == "Visual_Studio_2017")
        {
          Settings.Default.Visual_Studio_2017 = true;
        }
      }

      Settings.Default.Save();
    }

    /// <summary>Save all window values before exiting</summary>
    /// <param name="sender">Sender is the main form</param>
    /// <param name="e">Form closing event arguments</param>
    private void FormMainFormClosing(object sender, FormClosingEventArgs e)
    {
      SaveWindowValue();
    }

    private void frenchToolStripMenuItemClick(object sender, EventArgs e)
    {
      _currentLanguage = Language.French.ToString();
      SetLanguage(Language.French.ToString());
      AdjustAllControls();
    }

    private void englishToolStripMenuItemClick(object sender, EventArgs e)
    {
      _currentLanguage = Language.English.ToString();
      SetLanguage(Language.English.ToString());
      AdjustAllControls();
    }

    /// <summary>Adjust all controls length when translating controls label</summary>
    private void AdjustAllControls()
    {
      AdjustControls(labelChooseVSVersion, comboBoxVSVersion, labelPickDirectory, buttonVSVersionGetPath,
        textBoxVSProjectPath);
      AdjustControls(checkBoxGitInPath, buttonAddGitBinaryToWinPath, buttonCreateBackupScript);
      AdjustControls(checkBoxGitBashInstalled, buttonGitBashBinPath, textBoxGitBashBinariesPath);
      AdjustControls(buttonClearLogTextBox, buttonScannWholePC, buttonLoadVSProjects, buttonUpdateVSProjects,
        checkBoxOnlyGenerateScriptFile);
      AdjustControls(checkBoxUnlistVSSolution, textBoxUnlistOldSolution, checkBoxCaseSensitive);
      AdjustControls(buttonClearAll, buttonCheckAll, buttonCheckUncheckAll, labelSelectVSProjects);
    }

    private void AdjustControls(params Control[] listOfControls)
    {
      if (listOfControls.Length == 0)
      {
        return;
      }

      int position = listOfControls[0].Width + 33; // 33 is the initial padding
      bool isFirstControl = true;
      if (_fontSize == 0.0f)
      {
        _fontSize = 10.0f;
      }

      foreach (Control control in listOfControls)
      {
        if (isFirstControl)
        {
          control.Font = new Font(new FontFamily("Verdana"), _fontSize);
          isFirstControl = false;
        }
        else
        {
          control.Left = position + 25;
          position += control.Width + 10;
          control.Font = new Font(new FontFamily("Verdana"), _fontSize);
        }
      }
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
          buttonUpdateVSProjects.Text = _languageDicoEn["Update selected Visual Studio Projects"];
          buttonScannWholePC.Text = _languageDicoEn["Scan whole Pc"];
          buttonLoadVSProjects.Text = _languageDicoEn["Search for Visual Studio Projects"];
          checkBoxOnlyGenerateScriptFile.Text = _languageDicoEn["Generate only the script file"];
          buttonClearLogTextBox.Text = _languageDicoEn["Clear log"];
          checkBoxUnlistVSSolution.Text =
            _languageDicoEn["Unlist Visual Studio Solution having the following terms separated with a comma"];
          checkBoxCaseSensitive.Text = _languageDicoEn["Case sensitive"];
          buttonClearAll.Text = _languageDicoEn["Uncheck all"];
          buttonCheckAll.Text = _languageDicoEn["Check all"];
          buttonCheckUncheckAll.Text = _languageDicoEn["Toggle items"];

          buttonListBoxVSVersionUncheck.Text = _languageDicoEn["Uncheck all"];
          buttonListBoxVSVersionCheck.Text = _languageDicoEn["Check all"];
          buttonListBoxVSVersionToggle.Text = _languageDicoEn["Toggle items"];
          buttonUpdateCheckedVersion.Text = _languageDicoEn["Update"];
          checkBoxGitBashInstalled.Text = _languageDicoEn[CheckOrUncheck(checkBoxGitBashInstalled, "GitBash installed")];
          checkBoxGitInPath.Text =
            _languageDicoEn[CheckOrUncheck(checkBoxGitInPath, "GitBash binary path in Windows Path variable")];
          buttonCreateBackupScript.Text =
            _languageDicoEn["Create git clone backup script for gitted Visual Studio Solutions"];
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
          buttonUpdateVSProjects.Text = _languageDicoFr["Update selected Visual Studio Projects"];
          labelSelectVSProjects.Text = _languageDicoFr["Select the Visual Studio projects you want to update"];
          buttonScannWholePC.Text = _languageDicoFr["Scan whole Pc"];
          buttonLoadVSProjects.Text = _languageDicoFr["Search for Visual Studio Projects"];
          checkBoxOnlyGenerateScriptFile.Text = _languageDicoFr["Generate only the script file"];
          buttonCheckUncheckAll.Text = _languageDicoFr["Toggle items"];
          buttonClearLogTextBox.Text = _languageDicoFr["Clear log"];
          buttonListBoxVSVersionUncheck.Text = _languageDicoFr["Uncheck all"];
          buttonListBoxVSVersionCheck.Text = _languageDicoFr["Check all"];
          buttonListBoxVSVersionToggle.Text = _languageDicoFr["Toggle items"];
          checkBoxUnlistVSSolution.Text =
            _languageDicoFr["Unlist Visual Studio Solution having the following terms separated with a comma"];
          checkBoxCaseSensitive.Text = _languageDicoFr["Case sensitive"];
          buttonClearAll.Text = _languageDicoFr["Uncheck all"];
          buttonCheckAll.Text = _languageDicoFr["Check all"];
          buttonUpdateCheckedVersion.Text = _languageDicoFr["Update"];
          checkBoxGitBashInstalled.Text = _languageDicoFr[CheckOrUncheck(checkBoxGitBashInstalled, "GitBash installed")];
          checkBoxGitInPath.Text =
            _languageDicoFr[CheckOrUncheck(checkBoxGitInPath, "GitBash binary path in Windows Path variable")];
          buttonCreateBackupScript.Text =
            _languageDicoFr["Create git clone backup script for gitted Visual Studio Solutions"];
          _currentLanguage = "French";
          break;
      }
    }

    private static string CheckOrUncheck(CheckBox checkbox, string positiveString)
    {
      switch (positiveString)
      {
        case "GitBash installed":
          return checkbox.Checked ? "GitBash installed" : "GitBash not installed";
        case "GitBash binary path in Windows Path variable":
          return checkbox.Checked
            ? "GitBash binary path in Windows Path variable"
            : "GitBash binary path not in Windows Path variable";
        default:
          return "error";
      }
    }

    private void cutToolStripMenuItemClick(object sender, EventArgs e)
    {
      var listOfCtrl = new List<Control> { textBoxVSProjectPath, textBoxGitBashBinariesPath };
      Control focusedControl = FindFocusedControl(listOfCtrl);
      var tb = focusedControl as TextBox;
      if (tb != null)
      {
        CutToClipboard(tb);
      }
    }

    private void copyToolStripMenuItemClick(object sender, EventArgs e)
    {
      Control focusedControl = FindFocusedControl(new List<Control> { textBoxVSProjectPath, textBoxGitBashBinariesPath });
      var tb = focusedControl as TextBox;
      if (tb != null)
      {
        CopyToClipboard(tb);
      }
    }

    private void pasteToolStripMenuItemClick(object sender, EventArgs e)
    {
      Control focusedControl = FindFocusedControl(new List<Control> { textBoxVSProjectPath, textBoxGitBashBinariesPath });
      var tb = focusedControl as TextBox;
      if (tb != null)
      {
        PasteFromClipboard(tb);
      }
    }

    private void selectAllToolStripMenuItemClick(object sender, EventArgs e)
    {
      Control focusedControl = FindFocusedControl(new List<Control> { textBoxVSProjectPath, textBoxGitBashBinariesPath });
      TextBox control = focusedControl as TextBox;
      control?.SelectAll();
    }

    private void CutToClipboard(TextBoxBase textBox, string errorMessage = "nothing")
    {
      if (textBox != ActiveControl) return;
      if (textBox.Text == string.Empty)
      {
        DisplayMessageOk(Translate("ThereIs") + Punctuation.OneSpace +
                         Translate(errorMessage) + Punctuation.OneSpace +
                         Translate("ToCut") + Punctuation.OneSpace, Translate(errorMessage),
          MessageBoxButtons.OK);
        return;
      }

      if (textBox.SelectedText == string.Empty)
      {
        DisplayMessageOk(Translate("NoTextHasBeenSelected"),
          Translate(errorMessage), MessageBoxButtons.OK);
        return;
      }

      Clipboard.SetText(textBox.SelectedText);
      textBox.SelectedText = string.Empty;
    }

    private void CopyToClipboard(TextBoxBase textBox, string message = "nothing")
    {
      if (textBox != ActiveControl) return;
      if (textBox.Text == string.Empty)
      {
        DisplayMessageOk(Translate("ThereIsNothingToCopy") + Punctuation.OneSpace,
          Translate(message), MessageBoxButtons.OK);
        return;
      }

      if (textBox.SelectedText == string.Empty)
      {
        DisplayMessageOk(Translate("NoTextHasBeenSelected"),
          Translate(message), MessageBoxButtons.OK);
        return;
      }

      Clipboard.SetText(textBox.SelectedText);
    }

    private void PasteFromClipboard(TextBoxBase tb)
    {
      if (tb != ActiveControl) return;
      var selectionIndex = tb.SelectionStart;
      tb.SelectedText = Clipboard.GetText();
      tb.SelectionStart = selectionIndex + Clipboard.GetText().Length;
    }

    private string Translate(string index) // could add (string index, string _currentLanguage = "english")
    {
      string result = string.Empty;
      switch (_currentLanguage.ToLower())
      {
        case "english":
          result = _languageDicoEn.ContainsKey(index)
            ? _languageDicoEn[index]
            : "the term: \"" + index + "\" has not been translated yet.\nPlease add an entry in the Translations.xml file";
          break;
        case "french":
          result = _languageDicoFr.ContainsKey(index)
            ? _languageDicoFr[index]
            : "the term: \"" + index + "\" has not been translated yet.\nPlease add an entry in the Translations.xml file";
          break;
      }

      return result;
    }

    private static Control FindFocusedControl(List<Control> container)
    {
      return container.FirstOrDefault(control => control.Focused);
    }

    private void ButtonVSVersionGetPath_Click(object sender, EventArgs e)
    {
      textBoxVSProjectPath.Text = ChooseDirectory();
    }

    private static string ChooseDirectory()
    {
      string result = string.Empty;
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        result = folderBrowserDialog.SelectedPath;
      }

      return result;
    }

    private static string ChooseOneFile(string filter = "All files (*.*)|*.*", string initialDirectory = "", bool checkIfFileExists = false)
    {
      string result = string.Empty;
      FileDialog fd = new OpenFileDialog();
      fd.Filter = filter;
      fd.CheckFileExists = checkIfFileExists;
      if (initialDirectory == string.Empty)
      {
        initialDirectory = $"{Environment.GetEnvironmentVariable("systemdrive")}\\";
      }

      fd.InitialDirectory = initialDirectory;
      if (fd.ShowDialog() == DialogResult.OK)
      {
        result = fd.FileName;
      }

      return result;
    }

    private void ButtonGitBashBinPath_Click(object sender, EventArgs e)
    {
      string startPath = GetGitPath();
      if (startPath == string.Empty)
      {
        startPath = Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") ??
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
      }

      textBoxGitBashBinariesPath.Text = ChooseOneFile("git executable (git.exe)|git.exe", startPath);
    }

    private static bool ContainIgnoreCase(string source, string toCheck)
    {
      return source.IndexOf(toCheck, StringComparison.InvariantCultureIgnoreCase) >= 0;
    }

    private void ButtonUpdateVSProjects_Click(object sender, EventArgs e)
    {
      if (listViewVSProjects.Items.Count == 0)
      {
        DisplayMessageOk(Translate("The list doesn't have any Visual Studio project to update") + Punctuation.Period + Punctuation.CrLf + Translate("Enter a correct path and search project again"),
          Translate("List empty"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("The list doesn't have any Visual Studio project to update"));
        return;
      }

      var selectedProjects = listViewVSProjects.CheckedItems;
      if (selectedProjects.Count == 0)
      {
        DisplayMessageOk(Translate("No project has been selected") + Punctuation.Period + Punctuation.CrLf + Translate("Select at least one project"), Translate("No selection"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("No project has been selected"));
        return;
      }

      const string gitBinaryPath = "\\Git\\bin"; // valid for x86 and x64 pc because of (x86) directory
      string pathVariable = Environment.GetEnvironmentVariable("Path");
      if (pathVariable != null && !ContainIgnoreCase(pathVariable, gitBinaryPath) &&
          !checkBoxOnlyGenerateScriptFile.Checked && !textBoxGitBashBinariesPath.Text.ToLower().EndsWith("git.exe"))
      {
        DisplayMessageOk(Translate("The Path variable does not have the path to the GitBash binaries"),
          Translate("No GitBash binary found in PATH variable"), MessageBoxButtons.OK);
        return;
      }

      Logger.Add(textBoxLog, Translate("Updating selected projects"));
      if (checkBoxOnlyGenerateScriptFile.Checked)
      {
        Logger.Add(textBoxLog, Translate($"Creating the {Settings.Default.UpdatefileName} script"));
        Logger.Add(textBoxLog, Translate("in"));
        Logger.Add(textBoxLog, textBoxVSProjectPath.Text);
      }

      if (_previousUpdateFileList.Count == 1)
      {
        // delete previous version
        try
        {
          // check if a cmd.exe process is still running
          File.Delete(_previousUpdateFileList[0]);
          _previousUpdateFileList.RemoveAt(0);
        }
        catch (Exception exception)
        {
          Logger.Add(textBoxLog, $"Error while deleting previous update script named {_previousUpdateFileList[0]}");
          Logger.Add(textBoxLog, $"The exception is {exception.Message}");
        }
      }

      string updateScript = Path.Combine(textBoxVSProjectPath.Text, Settings.Default.UpdatefileName);
      updateScript = GenerateUniqueFileName(updateScript);
      _previousUpdateFileList.Add(updateScript);
      CreateNewFile(updateScript);
      AddStartOfScript(updateScript);

      foreach (ListViewItem selectedProj in selectedProjects)
      {
        var projectName = selectedProj.Text;
        AddGitPullToScript(updateScript, projectName);
        Logger.Add(textBoxLog, Translate("Adding the selected project") + Punctuation.OneSpace + projectName);
      }

      AddPauseToFile(updateScript);
      if (!checkBoxOnlyGenerateScriptFile.Checked)
      {
        StartProcess(updateScript);
      }
      else
      {
        if (DisplayMessage(Translate("Would you like to view the update script file"),
          Translate("View update script file"), MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          StartApplication("Notepad.exe", updateScript);
        }
      }
    }

    /// <summary>Display a standard message box</summary>
    /// <param name="message">The message to display</param>
    /// <param name="title">the title of the window</param>
    /// <param name="buttons">The type of message box buttons</param>
    private void DisplayMessageOk(string message, string title, MessageBoxButtons buttons)
    {
      MessageBox.Show(this, message, title, buttons);
    }

    /// <summary>Display a message box and send a dialog result</summary>
    /// <param name="message">The message to be displayed</param>
    /// <param name="title">The title of the window</param>
    /// <param name="buttons">The type of message box buttons</param>
    /// <returns>A dialog result after displaying a message box</returns>
    private DialogResult DisplayMessage(string message, string title, MessageBoxButtons buttons)
    {
      return MessageBox.Show(this, message, title, buttons);
    }

    private void AddPauseToFile(string fileName)
    {
      const bool append = true;
      var sw = new StreamWriter(fileName, append);
      sw.WriteLine(string.Empty);
      sw.WriteLine("REM " + Translate("Press a key to exit"));
      sw.WriteLine("pause");
      sw.Close();
    }

    private static void AddGitPullToScript(string fileName, string directoryName)
    {
      try
      {
        const bool append = true;
        var sw = new StreamWriter(fileName, append);
        sw.WriteLine("cd \"" + directoryName + "\"");
        sw.WriteLine("git pull origin master");
        sw.WriteLine("cd ..");
        sw.Close();
      }
      catch (Exception exception)
      {
        MessageBox.Show($"Cannot access to the file {fileName} error: {exception}");
      }
    }

    private static void AddGitCloneToScript(string fileName, string gitAddress)
    {
      const bool append = true;
      var sw = new StreamWriter(fileName, append);
      sw.WriteLine("git clone " + gitAddress);
      sw.Close();
    }

    private void AddStartOfScript(string fileName)
    {
      const bool append = true;
      var sw = new StreamWriter(fileName, append);
      sw.WriteLine("REM Batch script generated automatically by GitAutoUpdateGui");
      sw.WriteLine("REM Source and executable can be found at");
      sw.WriteLine("REM https://github.com/fredatgithub/GitAutoUpdate");
      sw.WriteLine("REM created by Freddy Juhel on the 31st of July 2015");
      sw.WriteLine("REM If you have any error, check that GitBash is installed");
      sw.WriteLine("REM then add C:\\Program Files\\Git\\bin to the environment PATH variable and reboot you PC");
      sw.WriteLine("cd \\");
      sw.WriteLine($"cd {textBoxVSProjectPath.Text}");
      sw.Close();
    }

    private void AddBeginningOfBackupScript(string fileName)
    {
      const bool append = true;
      /*
      set VisualStudioVersion=2012
      set VisualStudioName=Visual Studio %VisualStudioVersion%
      cd \
      cd %userprofile%
      cd "Documents"
      cd %VisualStudioName%
      cd "Projects"
      */
      string visualStudioName = "Visual Studio " + comboBoxVSVersion.SelectedItem;
      string userprofile = Environment.GetEnvironmentVariable("userprofile");
      var sw = new StreamWriter(fileName, append);
      sw.WriteLine("REM Batch script generated automatically by GitAutoUpdateGui");
      sw.WriteLine("REM Source and executable can be found at");
      sw.WriteLine("REM https://github.com/fredatgithub/GitAutoUpdate");
      sw.WriteLine("REM created by Freddy Juhel on the 18th of September 2015");
      sw.WriteLine("REM If you have any error, check that GitBash is installed");
      sw.WriteLine("REM then add C:\\Program Files\\Git\\bin to the environment PATH variable and reboot you PC");
      sw.WriteLine("cd \\");
      sw.WriteLine($"Cd {userprofile}");
      sw.WriteLine("Cd Documents");
      sw.WriteLine($"Cd {visualStudioName}");
      sw.WriteLine("Cd Projects");
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
      if (!File.Exists(fileName))
      {
        return fileName;
      }

      int fileNumber = 1;
      string result = AddAtTheEndOfFileName(fileName, fileNumber.ToString(CultureInfo.InvariantCulture));
      while (File.Exists(result))
      {
        fileNumber++;
        result = AddAtTheEndOfFileName(fileName, fileNumber.ToString(CultureInfo.InvariantCulture));
      }

      return result;
    }

    private static string AddAtTheEndOfFileName(string fileName, string textToBeAdded)
    {
      string result = GetDirectoryFileNameAndExtension(fileName)[0] + Punctuation.Backslash
                      + GetDirectoryFileNameAndExtension(fileName)[1]
                      + textToBeAdded
                      + GetDirectoryFileNameAndExtension(fileName)[2];
      return result;
    }

    private void ButtonLoadVSProjects_Click(object sender, EventArgs e)
    {
      Logger.Clear(textBoxLog);
      Logger.Add(textBoxLog, Translate("Clearing past results"));
      if (textBoxVSProjectPath.Text == string.Empty)
      {
        DisplayMessageOk(Translate("The Visual Studio project directory path is empty") +
                         Punctuation.Period + Punctuation.CrLf +
                         Translate("Enter a correct path"),
                         Translate("Directory empty"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("The Visual Studio project directory path is empty"));
        return;
      }

      if (!Directory.Exists(textBoxVSProjectPath.Text))
      {
        DisplayMessageOk(Translate("The Visual Studio project directory path doesn't exist") +
                         Punctuation.Period + Punctuation.CrLf + Translate("Enter a correct path"),
          Translate("Wrong Directory"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("The Visual Studio project directory path doesn't exist"));
        return;
      }

      if (!Directory.EnumerateDirectories(textBoxVSProjectPath.Text).Any())
      {
        DisplayMessageOk(Translate("The Visual Studio project directory is empty") +
                         Punctuation.Period + Punctuation.CrLf + Translate("Enter a correct path"),
          Translate("Directory empty"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("The Visual Studio project directory is empty"));
        return;
      }

      // verification of GitBash in textBoxGitBashBinariesPath
      if (textBoxGitBashBinariesPath.Text == string.Empty)
      {
        DisplayMessageOk(Translate("The GitBash directory path is empty") +
                         Punctuation.Period + Punctuation.CrLf + Translate("Enter a correct path"),
          Translate("Directory empty"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("The GitBash directory path is empty"));
        return;
      }

      if (!File.Exists(textBoxGitBashBinariesPath.Text))
      {
        DisplayMessageOk(Translate("The executable GitBash directory path doesn't exist") +
                         Punctuation.Period + Punctuation.CrLf + Translate("Enter a correct path"),
          Translate("Wrong Directory"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("The executable GitBash directory path doesn't exist"));
        return;
      }

      Logger.Add(textBoxLog, Translate("Searching for Visual Studio projects"));

      if (checkBoxUnlistVSSolution.Checked && textBoxUnlistOldSolution.Text == string.Empty)
      {
        checkBoxUnlistVSSolution.Checked = false;
      }

      if (checkBoxUnlistVSSolution.Checked && textBoxUnlistOldSolution.Text != string.Empty)
      {
        int numberOfBadWords = textBoxUnlistOldSolution.Text.Split(',').Length;
        Logger.Add(textBoxLog, Translate("Removing Visual Studio Solution having") +
                               Punctuation.OneSpace + Translate("the") +
                               FrenchPlural(numberOfBadWords, _currentLanguage) +
                               Punctuation.OneSpace + Translate("word") +
                               Pluralize(numberOfBadWords) + Punctuation.OneSpace +
                               textBoxUnlistOldSolution.Text.Replace(",", Punctuation.OneSpace + Translate("and")));
      }

      listViewVSProjects.Items.Clear();
      listViewVSProjects.Columns.Clear();
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
        var filteredFiles = Directory.GetFiles(directory, "*.sln").ToList();
        foreach (var solutionName in filteredFiles)
        {
          var tmpSolPath = GetDirectoryFileNameAndExtension(solutionName)[0];
          var tmpSolNameOnly0 = GetDirectoryFileNameAndExtension(solutionName)[0];
          var tmpSolNameOnly = tmpSolNameOnly0.Substring(tmpSolNameOnly0.LastIndexOf('\\') + 1);

          var subfilteredDirs = Directory.EnumerateDirectories(tmpSolPath, "*.git").ToList();
          if (subfilteredDirs.Count != 0)
          {
            //removing unwanted solution (having words such as old or bad)
            if (!checkBoxUnlistVSSolution.Checked ||
                textBoxUnlistOldSolution.Text == string.Empty ||
                (checkBoxUnlistVSSolution.Checked &&
                 NotHavingWords(tmpSolNameOnly, textBoxUnlistOldSolution.Text.Split(','),
                   checkBoxCaseSensitive.Checked)))
            {
              ListViewItem item1 = new ListViewItem(tmpSolNameOnly) { Checked = false };
              item1.SubItems.Add(tmpSolNameOnly);
              item1.SubItems.Add(tmpSolPath);
              if (!IsInlistView(listViewVSProjects, item1, 2))
              {
                listViewVSProjects.Items.Add(item1);
                projectCount++;
                Application.DoEvents();
              }
            }
          }
        }
      }

      Logger.Add(textBoxLog, projectCount + Punctuation.OneSpace + Translate("project") + Pluralize(projectCount) +
                             Punctuation.OneSpace + Translate(Pluralize(projectCount, "has")) + Punctuation.OneSpace +
                             Translate("been found") + FrenchPlural(projectCount, _currentLanguage));
      EnableDisableButtons(listViewVSProjects, buttonCheckAll, buttonClearAll, buttonCheckUncheckAll, buttonUpdateVSProjects);
      if (listViewVSProjects.Items.Count != 0)
      {
        listViewVSProjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
      }

      buttonUpdateVSProjects.Enabled = GetItemCheckedNumbers(listViewVSProjects) > 0;
    }

    private static ColumnHeaderAutoResizeStyle GetLongestString(string headerText, ListView lv)
    {
      return headerText.Length > MaxString(lv.Items).Length ? ColumnHeaderAutoResizeStyle.HeaderSize : ColumnHeaderAutoResizeStyle.ColumnContent;
    }

    private static string MaxString(ListView.ListViewItemCollection items)
    {
      string longest = string.Empty;
      foreach (var item in items)
      {
        if (item.ToString().Length > longest.Length)
        {
          longest = item.ToString();
        }
      }

      return longest;
    }

    private static bool IsInlistView(ListView listView, ListViewItem lviItem, int columnNumber)
    {
      bool result = false;
      foreach (ListViewItem item in listView.Items)
      {
        if (item.SubItems[columnNumber].Text == lviItem.SubItems[columnNumber].Text)
        {
          result = true;
          break;
        }
      }

      return result;
    }

    private static bool NotHavingWords(string source, IEnumerable<string> badWords, bool caseSensitive = false)
    {
      bool result = true;
      if (caseSensitive)
      {
        // Linq version
        // if (badWords.Any(badWord => string.Compare(badWord.Trim(), source.Trim(), StringComparison.CurrentCulture) == 0))
        foreach (string badWord in badWords)
        {
          if (string.Compare(badWord.Trim(), source.Trim(), StringComparison.CurrentCulture) == 0)
          {
            result = false;
            break;
          }
        }

        return result;
      }

      // Linq version
      // if (badWords.Any(badWord => string.Compare(badWord.Trim(), source.Trim(), StringComparison.CurrentCultureIgnoreCase) == 0))
      foreach (string badWord in badWords)
      {
        string tmpbadWord = badWord.Trim().ToLower();
        string tmpSource = source.Trim().ToLower();
        if (tmpSource.Contains(tmpbadWord))
        {
          result = false;
          break;
        }
      }

      return result;
    }

    private static string FrenchPlural(int number, string currentLanguage = "english")
    {
      return (number > 1 && currentLanguage.ToLower() == "french") ? "s" : string.Empty;
    }

    private static string Pluralize(int number, string irregularNoun = "")
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
          return "The"; // CAPITAL useful when used with Translate method because of French plural
        case "the":
          return "the"; // lower case useful when used with Translate method because of French plural
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

    private void textBoxGitBashBinariesPathTextChanged(object sender, EventArgs e)
    {
      settingsHaveChanged = true;
      CheckGitBashBinary();
      buttonUpdateVSProjects.Enabled = false;
    }

    private void CheckGitBashBinary()
    {
      checkBoxGitBashInstalled.Enabled = true;
      if (File.Exists(textBoxGitBashBinariesPath.Text))
      {
        checkBoxGitBashInstalled.Checked = true;
        checkBoxGitBashInstalled.Text = Translate("GitBash installed");
        checkBoxGitBashInstalled.BackColor = Color.LightGreen;
      }
      else
      {
        checkBoxGitBashInstalled.Checked = false;
        checkBoxGitBashInstalled.Text = Translate("GitBash not installed");
        checkBoxGitBashInstalled.BackColor = Color.Red;
      }

      checkBoxGitBashInstalled.Enabled = false;
    }

    private void TextBoxVsProjectPathTextChanged(object sender, EventArgs e)
    {
      settingsHaveChanged = true;
      TurnGreenOrRed(textBoxVSProjectPath.Text, ObjectType.Directory, labelChooseVSVersion, labelPickDirectory);
      buttonUpdateVSProjects.Enabled = false;
    }

    public enum ObjectType
    {
      File = 0,
      Directory = 1
    }

    private static void TurnGreenOrRed(string fileName, ObjectType objectType = ObjectType.Directory,
      params Control[] listOfControls)
    {
      if (objectType == ObjectType.Directory)
      {
        if (Directory.Exists(fileName))
        {
          foreach (var control in listOfControls)
          {
            control.BackColor = Color.LightGreen;
          }
        }
        else
        {
          foreach (var control in listOfControls)
          {
            control.BackColor = Color.Red;
          }
        }

        return;
      }

      if (objectType == ObjectType.File)
      {
        if (File.Exists(fileName))
        {
          foreach (var control in listOfControls)
          {
            control.BackColor = Color.LightGreen;
          }
        }
        else
        {
          foreach (var control in listOfControls)
          {
            control.BackColor = Color.Red;
          }
        }

        return; // necessary if any other object
      }
      // any other object type
    }

    private void ButtonCheckUncheckAll_Click(object sender, EventArgs e)
    {
      if (listViewVSProjects.Items.Count != 0)
      {
        ToggleAllItems(listViewVSProjects);
      }
    }

    private static void CheckAllItems(ListView listView)
    {
      listView.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = true);
    }

    private static void CheckUncheckAllItemsIncheckedListbox(CheckedListBox clb, bool checkedOrUnchecked)
    {
      Enumerable.Range(0, clb.Items.Count).ToList().ForEach(x => clb.SetItemChecked(x, checkedOrUnchecked));
    }

    private static void UnCheckAllItems(ListView listView)
    {
      listView.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = false);
    }

    private static void ToggleAllItems(ListView listView)
    {
      listView.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = !item.Checked);
    }

    private static void ToggleAllItemsInCheckedListBox(CheckedListBox clb, bool checkItem)
    {
      for (int i = 0; i <= (clb.Items.Count - 1); i++)
      {
        clb.SetItemCheckState(i, clb.GetItemCheckState(i) == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
      }
    }

    private void ComboBoxVSVersion_SelectedIndexChanged(object sender, EventArgs e)
    {
      settingsHaveChanged = true;
      string userProfile = Environment.GetEnvironmentVariable("USERPROFILE"); // C:\Users\userName
      if (userProfile == string.Empty)
      {
        DisplayMessageOk(Translate("The USERPROFILE variable cannot be empty"),
          Translate("USERPROFILE variable empty"), MessageBoxButtons.OK);
        return;
      }

      string vsVersion = GetNumbers(comboBoxVSVersion.SelectedItem.ToString());
      string documentsPath = Environment.SpecialFolder.MyDocuments.ToString();
      if (userProfile != null && !Directory.Exists(Path.Combine(userProfile, documentsPath)))
      {
        documentsPath = Environment.SpecialFolder.MyDocuments.ToString().Substring(2);
      }

      textBoxVSProjectPath.Text = Path.Combine(userProfile, documentsPath, $"Visual Studio {vsVersion}", "Projects");

      buttonLoadVSProjects.Enabled = Directory.Exists(textBoxVSProjectPath.Text);
    }

    /// <summary>Get numbers from a string</summary>
    /// <param name="myString">The string to search numbers in</param>
    /// <returns>A string with only numbers</returns>
    private static string GetNumbers(string myString)
    {
      return myString.Where(char.IsNumber).Aggregate(string.Empty, (current, c) => current + c);
    }

    private void ButtonClearLogTextBox_Click(object sender, EventArgs e)
    {
      textBoxLog.Text = string.Empty;
    }

    private void ButtonScannWholePC_Click(object sender, EventArgs e)
    {
      Logger.Clear(textBoxLog);
      Logger.Add(textBoxLog, Translate("Clearing list result"));
      Logger.Add(textBoxLog, Translate("Scanning whole PC started"));
      Logger.Add(textBoxLog, Translate("Searching for Visual Studio projects"));
      Stopwatch chrono = new Stopwatch();
      chrono.Start();
      listViewVSProjects.Items.Clear();
      Application.DoEvents();

      DisplayMessageOk(
        Translate(
          "The process may take several minutes or several hours depending on the number of folder inside my document directory") +
        Punctuation.CrLf + Translate("A window will pop up at the end of the process"),
        Translate("Lenghty process"), MessageBoxButtons.OK);
      string mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      IEnumerable<string> listOfDir = GetAllDirectories(mydoc, ".git", SearchOption.AllDirectories);

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
      // Algo
      /*
      1. for each drive in all drives excluding CDROM, removable
      2. for each directory starting in the rootDirectory in all directories in drive
      3. if directory has an *.sln file
      4. if directory has .git subdirectory
      5. add this directory to result variable
        */

      foreach (var solutionName in listOfDir)
      {
        var tmpSolPath = GetDirectoryFileNameAndExtension(solutionName.Substring(0, solutionName.Length - 5))[0];
        var tmpSolNameOnly0 = GetDirectoryFileNameAndExtension(solutionName.Substring(0, solutionName.Length - 5))[0];
        var tmpSolNameOnly = tmpSolNameOnly0.Substring(tmpSolNameOnly0.LastIndexOf('\\') + 1);

        ListViewItem item1 = new ListViewItem(tmpSolNameOnly) { Checked = false };
        item1.SubItems.Add(tmpSolNameOnly);
        item1.SubItems.Add(tmpSolPath);
        listViewVSProjects.Items.Add(item1);
        projectCount++;
      }

      Logger.Add(textBoxLog, projectCount + Punctuation.OneSpace + Translate("project") + Pluralize(projectCount) +
                             Punctuation.OneSpace + Translate(Pluralize(projectCount, "has")) + Punctuation.OneSpace +
                             Translate("been found") + FrenchPlural(projectCount, _currentLanguage));
      EnableDisableButtons(listViewVSProjects, buttonCheckAll, buttonClearAll, buttonCheckUncheckAll, buttonUpdateVSProjects);
      chrono.Stop();
      TimeSpan ts = chrono.Elapsed;
      DisplayMessageOk(Translate("The process is over") + Punctuation.CrLf +
                       Translate("It took") + Punctuation.OneSpace + DisplayElapseTime(ts),
        Translate("Process over"), MessageBoxButtons.OK);
    }

    private static string DisplayElapseTime(TimeSpan ts)
    {
      return $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
    }

    public static IEnumerable<string> GetAllDirectories(string path, string pattern = "*",
      SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
      List<string> result = new List<string>();
      if (!Directory.Exists(path))
      {
        return result;
      }

      bool complete;
      do
      {
        try
        {
          foreach (var directory in Directory.EnumerateDirectories(path, pattern, searchOption))
          {
            result.Add(directory);
            Application.DoEvents();
          }

          complete = true;
        }
        catch (UnauthorizedAccessException)
        {
          complete = false;
        }
        catch (Exception)
        {
          complete = false;
        }
      } while (!complete);

      return result;
    }

    private static List<DriveInfo> GetAllDrives(DriveType[] excludeDriveTypeList)
    {
      var result = new List<DriveInfo>();
      try
      {
        foreach (DriveInfo drive in DriveInfo.GetDrives())
        {
          bool addingDrive = true;
          foreach (var excludeDriveType in excludeDriveTypeList)
          {
            if (excludeDriveType == drive.DriveType)
            {
              addingDrive = false;
              break;
            }
          }

          if (addingDrive)
          {
            result.Add(drive);
          }
        }
      }
      catch (Exception)
      {
        // ignored
      }
      return result;
    }

    private List<FileInfo> SearchVsGitDirectories()
    {
      List<FileInfo> files = new List<FileInfo>();

      foreach (DriveInfo drive in DriveInfo.GetDrives().Where(drive => drive.DriveType != DriveType.CDRom))
      {
        var allDirectories = from dir in drive.RootDirectory.EnumerateDirectories()
                             select new { ProgDir = dir };
        foreach (var directory in allDirectories)
        {
          try
          {
            foreach (var fileInfo in directory.ProgDir.EnumerateFiles("*.sln", SearchOption.AllDirectories))
            {
              try
              {
                files.Add(fileInfo);
              }
              catch (Exception)
              {
                // ignored
              }
            }
          }
          catch (Exception)
          {
            // ignored
          }
        }
      }

      return files;
    }

    private List<FileInfo> SearchFiles(List<string> pattern)
    {
      var files = new List<FileInfo>();

      foreach (DriveInfo drive in DriveInfo.GetDrives().Where(drive => drive.DriveType != DriveType.CDRom))
      {
        var dirs = from dir in drive.RootDirectory.EnumerateDirectories() select new { ProgDir = dir };
        foreach (var di in dirs)
        {
          try
          {
            foreach (string muster in pattern)
            {
              foreach (var fi in di.ProgDir.EnumerateFiles(muster, SearchOption.AllDirectories))
              {
                try
                {
                  files.Add(fi);
                }
                catch (UnauthorizedAccessException)
                {
                }
              }
            }
          }
          catch (UnauthorizedAccessException)
          {
          }
        }
      }

      return files;
    }

    private void TextBoxUnlistOldSolution_TextChanged(object sender, EventArgs e)
    {
      settingsHaveChanged = true;
      if (textBoxUnlistOldSolution.Text == string.Empty)
      {
        checkBoxUnlistVSSolution.Checked = false;
      }
    }

    private void ButtonClearAll_Click(object sender, EventArgs e)
    {
      if (listViewVSProjects.Items.Count != 0)
      {
        UnCheckAllItems(listViewVSProjects);
      }
    }

    private void ButtonCheckAll_Click(object sender, EventArgs e)
    {
      if (listViewVSProjects.Items.Count != 0)
      {
        CheckAllItems(listViewVSProjects);
      }
    }

    private void ButtonAddGitBinaryToWinPath_Click(object sender, EventArgs e)
    {
      // Path = %path% + textBoxGitBashBinariesPath.text minus "git.exe"
      var winPath = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
#if Debug
      MessageBox.Show("Here is your current Windows Path variable: " + winPath);
#endif
      // verification of GitBash in textBoxGitBashBinariesPath
      if (textBoxGitBashBinariesPath.Text == string.Empty)
      {
        DisplayMessageOk(Translate("The GitBash directory path is empty") +
                         Punctuation.Period + Punctuation.CrLf + Translate("Enter a correct path"),
          Translate("Directory empty"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("The GitBash directory path is empty"));
        return;
      }

      if (!File.Exists(textBoxGitBashBinariesPath.Text))
      {
        DisplayMessageOk(Translate("The executable GitBash directory path doesn't exist") +
                         Punctuation.Period + Punctuation.CrLf + Translate("Enter a correct path"),
          Translate("Wrong Directory"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("The executable GitBash directory path doesn't exist"));
        return;
      }

      winPath += Punctuation.SemiColon + Punctuation.Backslash +
                 textBoxGitBashBinariesPath.Text.Substring(0, textBoxGitBashBinariesPath.Text.Length - 8);
#if Debug
      MessageBox.Show("Here is your modifed Windows Path variable: " + winPath);
#endif
      bool additionSuccessful;
      try
      {
        Environment.SetEnvironmentVariable("Path", winPath, EnvironmentVariableTarget.Machine);
        additionSuccessful = true;
      }
      catch (SecurityException securityException)
      {
        additionSuccessful = false;
        Logger.Add(textBoxLog, Punctuation.CreateSentence(Translate("There was a security error"),
          Punctuation.Comma, Punctuation.OneSpace, Translate("probably lack of rights"),
          Punctuation.Colon, Punctuation.OneSpace) +
                               securityException.Message);
      }
      catch (Exception exception)
      {
        additionSuccessful = false;
        Logger.Add(textBoxLog, Translate("There was an error") + Punctuation.Colon +
                               Punctuation.CrLf + exception.Message);
      }

      if (additionSuccessful)
      {
        string message = Translate("The following path") + Punctuation.Colon + Punctuation.CrLf +
                         textBoxGitBashBinariesPath.Text.Substring(0, textBoxGitBashBinariesPath.Text.Length - 8) +
                         Punctuation.CrLf + Translate("has been added to the Windows Path variable") +
                         Punctuation.CrLf +
                         Translate("YOU HAVE TO REBOOT YOUR PC FOR THE VARIABLE TO BE TAKEN INTO EFFECT");
        Logger.Add(textBoxLog, message);
        DisplayMessageOk(message, Translate("Path added"), MessageBoxButtons.OK);
      }
      else
      {
        string message = Translate("The following path") + Punctuation.Colon + Punctuation.CrLf +
                         textBoxGitBashBinariesPath.Text.Substring(0, textBoxGitBashBinariesPath.Text.Length - 8) +
                         Punctuation.CrLf + Translate("has not been added to the Windows Path variable") +
                         Punctuation.CrLf + Translate("Check with the developer");
        Logger.Add(textBoxLog, message);
        DisplayMessageOk(message, Translate("Error"), MessageBoxButtons.OK);
      }
    }

    private void CheckBoxGitInPath_CheckedChanged(object sender, EventArgs e)
    {
      buttonAddGitBinaryToWinPath.Enabled = !checkBoxGitInPath.Checked;
      settingsHaveChanged = true;
    }

    private void ButtonCreateBackupScript_Click(object sender, EventArgs e)
    {
      if (textBoxVSProjectPath.Text == string.Empty)
      {
        DisplayMessageOk(Translate("The Visual Studio project directory path is empty") +
                         Punctuation.Period + Punctuation.CrLf + Translate("Enter a correct path"),
          Translate("Directory empty"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("The Visual Studio project directory path is empty"));
        return;
      }

      Logger.Clear(textBoxLog);
      Logger.Add(textBoxLog, Translate("Creating the GitCloneBackup.bat script"));
      Logger.Add(textBoxLog, Translate("Listing Visual Studio solutions with Git"));
      listViewVSProjects.Items.Clear();
      string backupScript = Path.Combine(textBoxVSProjectPath.Text, "GitCloneBackup.bat");
      backupScript = GenerateUniqueFileName(backupScript);
      CreateNewFile(backupScript);
      AddBeginningOfBackupScript(backupScript);
      listViewVSProjects.Items.Clear();

      listViewVSProjects.Columns.Add("To be updated", 240, HorizontalAlignment.Left);
      listViewVSProjects.Columns.Add("Solution Name", 240, HorizontalAlignment.Left);
      listViewVSProjects.Columns.Add("Solution Path", 640, HorizontalAlignment.Left);
      listViewVSProjects.Columns.Add("Git URL", 640, HorizontalAlignment.Left);

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
        var filteredFiles = Directory.GetFiles(directory, "*.sln").ToList();
        foreach (var solutionName in filteredFiles)
        {
          var tmpSolPath = GetDirectoryFileNameAndExtension(solutionName)[0];
          var tmpSolNameOnly0 = GetDirectoryFileNameAndExtension(solutionName)[0];
          var tmpSolNameOnly = tmpSolNameOnly0.Substring(tmpSolNameOnly0.LastIndexOf('\\') + 1);

          var subfilteredDirs = Directory.EnumerateDirectories(tmpSolPath, "*.git").ToList();
          if (subfilteredDirs.Count != 0)
          {
            // get git url
            string gitUrl = GetGitUrl(subfilteredDirs.ToArray()[0]);
            //removing unwanted solution (having words such as old or bad)
            if (!checkBoxUnlistVSSolution.Checked ||
                textBoxUnlistOldSolution.Text == string.Empty ||
                (checkBoxUnlistVSSolution.Checked &&
                 NotHavingWords(tmpSolNameOnly, textBoxUnlistOldSolution.Text.Split(','),
                   checkBoxCaseSensitive.Checked)))
            {
              // add each solution to script file
              ListViewItem item1 = new ListViewItem(tmpSolNameOnly) { Checked = true };
              item1.SubItems.Add(tmpSolNameOnly);
              item1.SubItems.Add(tmpSolPath);
              item1.SubItems.Add(gitUrl);
              if (!IsInlistView(listViewVSProjects, item1, 2) && gitUrl != string.Empty)
              {
                listViewVSProjects.Items.Add(item1);
                projectCount++;
                Application.DoEvents();
              }
            }
          }
        }
      }

      Logger.Add(textBoxLog, projectCount + Punctuation.OneSpace + Translate("project") + Pluralize(projectCount) +
                               Punctuation.OneSpace + Translate(Pluralize(projectCount, "has")) + Punctuation.OneSpace +
                               Translate("been found") + FrenchPlural(projectCount, _currentLanguage));

      // if no selected project has been checked, display message
      var selectedProjects = listViewVSProjects.CheckedItems;
      if (selectedProjects.Count == 0)
      {
        DisplayMessageOk(Translate("No project has been selected") +
                         Punctuation.Period + Punctuation.CrLf + Translate("Select at least one project"),
          Translate("No selection"), MessageBoxButtons.OK);
        Logger.Add(textBoxLog, Translate("No project has been selected"));
        return;
      }

      foreach (ListViewItem selectedProj in selectedProjects)
      {
        var gitUrl = selectedProj.SubItems[3].Text;
        if (gitUrl == string.Empty) continue;
        AddGitCloneToScript(backupScript, gitUrl);
        Logger.Add(textBoxLog, Translate("Adding the gitted project") + Punctuation.OneSpace + gitUrl);
      }

      EnableDisableButtons(listViewVSProjects, buttonCheckAll, buttonClearAll, buttonCheckUncheckAll, buttonUpdateVSProjects);
      AddPauseToFile(backupScript);

      if (DisplayMessage(Translate("Would you like to view the backup script file"),
        Translate("View backup script file"), MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        Process task = new Process
        {
          StartInfo =
          {
            UseShellExecute = true,
            FileName = "Notepad.exe",
            Arguments = backupScript,
            CreateNoWindow = false
          }
        };

        task.Start();
      }
    }

    private string GetGitUrl(string fileName)
    {
      string result = string.Empty;
      if (!File.Exists(Path.Combine(fileName, "config")))
      {
        Logger.Add(textBoxLog, Translate("The config file doesn't exist in") + Punctuation.OneSpace + fileName);
      }
      else
      {
        var sr = new StreamReader(Path.Combine(fileName, "config"));
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          if (line.Contains("url = https://github.com/"))
          {
            result = line.Split('=')[1].Trim();
          }
        }
      }
      return result;
    }

    private void ListViewVSProjects_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
      buttonUpdateVSProjects.Enabled = GetItemCheckedNumbers(listViewVSProjects) > 0;
    }

    private static int GetItemCheckedNumbers(ListView lv)
    {
      return lv.CheckedItems.Count;
    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (settingsHaveChanged)
      {
        SaveWindowValue();
      }
    }

    private void CheckBoxUnlistVSSolution_CheckedChanged(object sender, EventArgs e)
    {
      settingsHaveChanged = true;
    }

    private void CheckBoxGitBashInstalled_CheckedChanged(object sender, EventArgs e)
    {
      settingsHaveChanged = true;
    }

    private void CheckBoxOnlyGenerateScriptFile_CheckedChanged(object sender, EventArgs e)
    {
      settingsHaveChanged = true;
    }

    private void CheckBoxCaseSensitive_CheckedChanged(object sender, EventArgs e)
    {
      settingsHaveChanged = true;
    }

    private void CheckedListBoxVSVersion_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (checkedListBoxVSVersion.CheckedItems.Count == 0)
      {
        buttonListBoxVSVersionCheck.Enabled = false;
        buttonListBoxVSVersionUncheck.Enabled = false;
        buttonListBoxVSVersionToggle.Enabled = false;
        buttonUpdateCheckedVersion.Enabled = false;
      }
      else
      {
        buttonListBoxVSVersionCheck.Enabled = true;
        buttonListBoxVSVersionUncheck.Enabled = true;
        buttonListBoxVSVersionToggle.Enabled = true;
        buttonUpdateCheckedVersion.Enabled = true;
      }
    }

    private void ButtonUpdateCheckedVersionClick(object sender, EventArgs e)
    {
      //List<string> itemList = (from object item in checkedListBoxVSVersion.CheckedItems select item.ToString()).ToList();
      List<string> itemList = new List<string>();
      foreach (var item in checkedListBoxVSVersion.CheckedItems)
      {
        itemList.Add(item.ToString());
      }

      string pattern = Settings.Default.UpdateFilePattern; // "update*.bat";
      bool textBoxVsProjectPathIsIncluded = false;
      foreach (string item in itemList)
      {
        // check if scripts update.cmd do exist and if so, then start them
        // if not then create one
        // get all update*.cmd

        //C:\Users\username\Documents\Visual Studio 2015\Projects
        string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), item,
          "Projects\\");
        if (Path.Combine(directoryPath) == Path.Combine(textBoxVSProjectPath.Text))
        {
          textBoxVsProjectPathIsIncluded = true;
        }

        var directoryInfo = new DirectoryInfo(directoryPath);
        FileInfo[] files = directoryInfo.GetFiles(pattern, SearchOption.TopDirectoryOnly);
        if (files.Length == 1)
        {
          // start the only file
          StartProcess(files[0].FullName);
        }
        else if (files.Length > 1)
        {
          // get the latest file or greatest numbered file name
          string geatestFileName = GetGreatestFile(files);
          StartProcess(geatestFileName);
        }
        else
        {
          // no files so create one cmd script by using already created method in this code
          // TODO

        }
      }

      // if textBoxVSProjectPath.text is not in the list, add it
      if (textBoxVsProjectPathIsIncluded) return;

      var directoryInfo2 = new DirectoryInfo(Path.Combine(textBoxVSProjectPath.Text));
      FileInfo[] files2 = directoryInfo2.GetFiles(pattern, SearchOption.TopDirectoryOnly);
      if (files2.Length == 1)
      {
        // start the only file
        StartProcess(files2[0].FullName);
      }
      else if (files2.Length > 1)
      {
        // get the latest file or greatest numbered file name
        string geatestFileName = GetGreatestFile(files2);
        StartProcess(geatestFileName);
      }

    }

    public static string GetGreatestFile(FileInfo[] files)
    {
      string result = files[0].FullName;
      foreach (FileInfo fileInfo in files)
      {
        if (GetDigitFromFileName(fileInfo.Name) > GetDigitFromFileName(Path.GetFileName(result)))
        {
          result = fileInfo.FullName;
        }
      }

      return result;
    }

    public static int GetDigitFromFileName(string fileName)
    {
      int result = 0;
      Regex regex = new Regex(@"\d+");
      Match match = regex.Match(fileName);
      if (match.Success)
      {
        int.TryParse(match.Value, out result);
      }

      return result;
    }

    private static List<string> GetCheckedVsVersion(CheckedListBox ckListBox)
    {
      List<string> itemList = new List<string>();
      foreach (var item in ckListBox.CheckedItems)
      {
        itemList.Add(item.ToString());
      }

      return itemList;
    }

    private static string ChangeCharacter(char oldChar, char newChar, string theString)
    {
      return theString.Replace(oldChar, newChar);
    }

    private static List<string> ChangeCharacterInList(List<string> theList)
    {
      List<string> result = new List<string>();
      foreach (var item in theList)
      {
        result.Add(ChangeCharacter(' ', '_', item));
      }

      return result;
    }

    private static void StartProcess(string dosScript, bool useShellExecute = true, bool createNoWindow = false)
    {
      Process task = new Process
      {
        StartInfo =
        {
          UseShellExecute = useShellExecute,
          FileName = dosScript,
          CreateNoWindow = createNoWindow
        }
      };

      task.Start();
    }

    private static void StartApplication(string applicationName, string argument, bool useShellExecute = true, bool createNoWindow = false)
    {
      Process task = new Process
      {
        StartInfo =
        {
          UseShellExecute = useShellExecute,
          FileName = applicationName,
          Arguments = argument,
          CreateNoWindow = createNoWindow
        }
      };

      task.Start();
    }

    private void ButtonListBoxVSVersionCheck_Click(object sender, EventArgs e)
    {
      if (checkedListBoxVSVersion.Items.Count != 0)
      {
        CheckUncheckAllItemsIncheckedListbox(checkedListBoxVSVersion, true);
      }

      buttonUpdateCheckedVersion.Enabled = checkedListBoxVSVersion.CheckedItems.Count != 0;
    }

    private void ButtonListBoxVSVersionUncheck_Click(object sender, EventArgs e)
    {
      if (checkedListBoxVSVersion.Items.Count != 0)
      {
        CheckUncheckAllItemsIncheckedListbox(checkedListBoxVSVersion, false);
      }

      buttonUpdateCheckedVersion.Enabled = checkedListBoxVSVersion.CheckedItems.Count != 0;
    }

    private void ButtonListBoxVSVersionToggle_Click(object sender, EventArgs e)
    {
      if (checkedListBoxVSVersion.Items.Count != 0)
      {
        ToggleAllItemsInCheckedListBox(checkedListBoxVSVersion, false);
      }

      buttonUpdateCheckedVersion.Enabled = checkedListBoxVSVersion.CheckedItems.Count != 0;
    }
  }
}
