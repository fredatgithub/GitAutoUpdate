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
  }
}