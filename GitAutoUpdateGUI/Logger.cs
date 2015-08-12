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
using System.Windows.Forms;

namespace GitAutoUpdateGUI
{
  public static class Logger
  {
    public static string Message { get; set; }
    public static DestinationLog Destination { get; set; }
    private const string OneSpace = " ";
    private const string Dash = "-";
    private static readonly string Crlf = Environment.NewLine;

    public static void Add(TextBoxBase textBox, string message)
    {
      textBox.Text += DateTime.Now + OneSpace + Dash + OneSpace + message + Crlf;
    }

    public static void Clear(TextBoxBase textBox)
    {
      textBox.Text = string.Empty;
    }
  }

  public enum DestinationLog
  {
    LogFile,
    LogTextBox
  }
}