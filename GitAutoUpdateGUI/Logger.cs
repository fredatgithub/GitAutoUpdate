﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitAutoUpdateGUI
{
  public static class Logger
  {
    public static string Message { get; set; }
    public static DestinationLog Destination { get; set; }
    private const string oneSpace = " ";
    private const string dash = "-";
    private static readonly string Crlf = Environment.NewLine;

    public static void Add(TextBoxBase textBox, string message)
    {
      textBox.Text += DateTime.Now + oneSpace + dash + oneSpace + message + Crlf;
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