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
      const string source1 = @"C:\Users\fred\Documents\Visual Studio 2012\Projects";
      const string source2 = "update*.bat";
      const string expected = "update64.bat";
      object obj = privateTypeObject.InvokeStatic(methodName, source1, source2);
      Assert.AreEqual(expected, (string)obj);
    }

    [TestMethod]
    public void TestMethod_GetLatestFilePublic()
    {
      const string source1 = @"C:\Users\fred\Documents\Visual Studio 2012\Projects";
      const string source2 = "update*.bat";
      const string expected = "update64.bat";
      string result = GitMethods.GetLatestFile(source1, source2);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_FileNumber_no_digit()
    {
      const string source = "update.bat";
      const int expected = 0;
      int result = GitMethods.FileNumber(source);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_FileNumber_one_digit_zero()
    {
      const string source = "update0.bat";
      const int expected = 0;
      int result = GitMethods.FileNumber(source);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_FileNumber_one_digit_one()
    {
      const string source = "update1.bat";
      const int expected = 1;
      int result = GitMethods.FileNumber(source);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void TestMethod_FileNumber_two_digits()
    {
      const string source = "update66.bat";
      const int expected = 66;
      int result = GitMethods.FileNumber(source);
      Assert.AreEqual(result, expected);
    }
    
    [TestMethod]
    public void TestMethod_FileNumber_no_digit_and_long_name()
    {
      const string source = "update-good-one-to-keep.bat";
      const int expected = 0;
      int result = GitMethods.FileNumber(source);
      Assert.AreEqual(result, expected);
    }
  }
}