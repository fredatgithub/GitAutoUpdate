﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitMethods = GitAutoUpdateGUI.FormMain;

namespace UnitTestGitAutoUpdate
{
  [TestClass]
  public class UnitTestMethods
  {
    [TestMethod]
    public void TestMethod_GetLatestFilePrivate()
    {
      PrivateType privateTypeObject = new PrivateType(typeof(GitMethods));
      const string methodName = "GetLatestFile";
      var source1 = $@"C:\Users\{GetProfileUserName()}\Documents\Visual Studio 2012\Projects";
      if (!Directory.Exists(source1))
      {
        Assert.IsTrue(true);
        return;
      }

      const string source2 = "update*.bat";
      const string expected = "update7.bat";
      object result = privateTypeObject.InvokeStatic(methodName, source1, source2);
      Assert.AreEqual(expected, result.ToString());
    }

    [TestMethod]
    public void TestMethod_GetLatestFilePublic()
    {
      string source1 = $@"C:\Users\{GetProfileUserName()}\Documents\Visual Studio 2012\Projects";
      if (!Directory.Exists(source1))
      {
        Assert.IsTrue(true);
        return;
      }

      const string source2 = "update*.bat";
      const string expected = "update7.bat";
      string result = GitMethods.GetLatestFile(source1, source2);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_FileNumber_no_digit()
    {
      const string source = "update.bat";
      const int expected = 0;
      int result = GitMethods.GetDigitFromFileName(source);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_FileNumber_one_digit_zero()
    {
      const string source = "update0.bat";
      const int expected = 0;
      int result = GitMethods.GetDigitFromFileName(source);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_FileNumber_one_digit_one()
    {
      const string source = "update1.bat";
      const int expected = 1;
      int result = GitMethods.GetDigitFromFileName(source);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_FileNumber_two_digits()
    {
      const string source = "update66.bat";
      const int expected = 66;
      int result = GitMethods.GetDigitFromFileName(source);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_FileNumber_no_digit_and_long_name()
    {
      const string source = "update-good-one-to-keep.bat";
      const int expected = 0;
      int result = GitMethods.GetDigitFromFileName(source);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_System_variables()
    {
      string source = $"{Path.GetPathRoot(Environment.SystemDirectory)}Program Files\\Git\\bin";
      const string expected = "C:\\Program Files\\Git\\bin";
      Assert.AreEqual(source, expected);
    }

    [TestMethod]
    public void TestMethod_Program_files_variables()
    {
      string source = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Git\\cmd";
      const string expected = "C:\\Program Files (x86)\\Git\\cmd";
      Assert.AreEqual(source, expected);
    }

    [TestMethod]
    public void TestMethod_AppData_Roaming_variables()
    {
      string source = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}";
      string expected = $@"C:\Users\{GetProfileUserName()}\AppData\Roaming";
      Assert.AreEqual(source, expected);
    }


    [TestMethod]
    public void TestMethod_AppData_Local_variables()
    {
      string source = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Substring(0, 22)}\\Local";
      string expected = $"C:\\Users\\{GetProfileUserName()}\\AppData\\Local";
      Assert.AreEqual(source, expected);
    }

    [TestMethod]
    public void TestMethod_Get_username_and_pc_name_variables()
    {
      string source = $"{System.Security.Principal.WindowsIdentity.GetCurrent().Name}";
      string expected = $@"{GetHostname()}\{GetProfileUserName()}";
      Assert.AreEqual(source, expected);
    }

    [TestMethod]
    public void TestMethod_Get_username_variables()
    {
      string source = $"{Environment.UserName}";
      string expected = GetProfileUserName();
      Assert.AreEqual(source, expected);
    }

    [TestMethod]
    public void TestMethod_GetNumbers()
    {
      PrivateType privateTypeObject = new PrivateType(typeof(GitMethods));
      const string methodName = "GetNumbers";
      string source = $@"C:\Users\Documents\Visual Studio 2012\Projects";
      const string expected = "2012";
      object result = privateTypeObject.InvokeStatic(methodName, source);
      Assert.AreEqual(expected, result.ToString());
    }

    [TestMethod]
    public void TestMethod_AddSlash_with_a_slash()
    {
      PrivateType privateTypeObject = new PrivateType(typeof(GitMethods));
      const string methodName = "AddSlash";
      string source = $@"C:\Users\{GetProfileUserName()}\Documents\Visual Studio 2012\Projects\";
      string expected = $@"C:\Users\{GetProfileUserName()}\Documents\Visual Studio 2012\Projects\";
      object obj = privateTypeObject.InvokeStatic(methodName, source);
      Assert.AreEqual(expected, (string)obj);
    }

    [TestMethod]
    public void TestMethod_AddSlash_without_a_slash()
    {
      PrivateType privateTypeObject = new PrivateType(typeof(GitMethods));
      const string methodName = "AddSlash";
      string source = $@"C:\Users\{GetProfileUserName()}\Documents\Visual Studio 2012\Projects";
      string expected = $@"C:\Users\{GetProfileUserName()}\Documents\Visual Studio 2012\Projects\";
      object obj = privateTypeObject.InvokeStatic(methodName, source);
      Assert.AreEqual(expected, (string)obj);
    }

    public string GetProfileUserName()
    {
      return Environment.UserName;
    }

    public string GetHostname()
    {
      return Environment.MachineName;
    }
  }
}