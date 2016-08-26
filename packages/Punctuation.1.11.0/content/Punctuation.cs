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
using System.Text;

namespace Tools
{
  public static class Punctuation
  {
    public const string Comma = ",";
    public const string Colon = ":";
    public const string SemiColon = ";";
    public const string OneSpace = " ";
    public const string UnderScore = "_";
    public const string SignAt = "@";
    public const string Ampersand = "&";
    public const string SignSharp = "#";
    public const string Period = ".";
    public const string Dot = ".";
    public const string Backslash = "\\";
    public const string Slash = "/";
    public const string OpenParenthesis = "(";
    public const string CloseParenthesis = ")";
    public const string OpenCurlyBrace = "{";
    public const string CloseCurlyBrace = "}";
    public const string OpeningBracket = "[";
    public const string ClosingBracket = "]";
    public const string LessThan = "<";
    public const string GreaterThan = ">";
    public const string DoubleQuote = "\"";
    public const string SimpleQuote = "'";
    public const string Tilde = "~";
    public const string Pipe = "|";
    public const string Plus = "+";
    public const string Minus = "-";
    public const string Dash = "-";
    public const string Multiply = "*";
    public const string Star = "*";
    public const string Divide = "/";
    public const string Equal = "=";
    public const string Dollar = "$";
    public const string Pound = "£";
    public const string Percent = "%";
    public const string QuestionMark = "?";
    public const string ExclamationPoint = "!";
    public const string Chapter = "§";
    public const string Micro = "µ";
    public const string Copyright = "®";
    public static string CrLf = Environment.NewLine;

    public static string Tabulate(ushort numberOfTabulation = 1)
    {
      string result = string.Empty;
      for (int number = 0; number < numberOfTabulation; number++)
      {
        result += " ";
      }

      return result;
    }

    public static string CreateSentence(params string[] listOfCharacters)
    {
      StringBuilder result = new StringBuilder();
      foreach (string character in listOfCharacters)
      {
        result.Append(character);
      }

      return result.ToString();
    }

    public static string CreateSentence(params PunctuationChar[] listOfCharacters)
    {
      StringBuilder result = new StringBuilder();
      foreach (var character in listOfCharacters)
      {
        result.Append(character);
      }

      return result.ToString();
    }

    public enum PunctuationChar
    {
      // values according to ASCII table
      Comma = 44,
      Colon = 58,
      SemiColon = 59,
      OneSpace = 32,
      UnderScore = 95,
      SignAt = 64,
      Ampersand = 38,
      SignSharp = 35,
      SignNumber = Pound,
      Period = 46,
      Dot = Period,
      Backslash = 92,
      OpenParenthesis = 40,
      CloseParenthesis = 41,
      OpenCurlyBrace = 123,
      OpeningBrace = OpenCurlyBrace,
      CloseCurlyBrace = 125,
      ClosingBrace = CloseCurlyBrace,
      OpeningBracket = 91,
      ClosingBracket = 93,
      LessThan = 60,
      GreaterThan = 62,
      DoubleQuote = 34,
      SimpleQuote = 39,
      Tilde = 126,
      Caret = 94,
      Circumflex = Caret,
      Pipe = 124,
      VerticalBar = Pipe,
      Plus = 43,
      Dash = 45,
      Minus = Dash,
      Multiply = 42,
      Star = Multiply,
      SignMultiply = 215,
      Slash = 47,
      Divide = Slash,
      SignDivision = 247,
      Equal = 61,
      Dollar = 36,
      Pound = 163,
      SignYen = 165,
      Percent = 37,
      QuestionMark = 63,
      ExclamationPoint = 33,
      Chapter = 167,
      Section = Chapter,
      Copyright = 169,
      Micro = 181,
      LeftDoubleAngleQuotes = 171,
      RightDoubleAngleQuotes = 187,
      LeftSingleQuotationMark = 8216,
      RightSingleQuotationMark = 8217,
      LeftDoubleQuotationMark = 8220,
      RightdoubleQuotationMark = 8221,
      SignTradeMark = 8482,
      SignEuro = 8364,
      CrLf = 0,
      NewLine = CrLf
    }
    
    public static string SpaceIfFrench(string language = "english")
    {
      return language.ToLower() == "french" ? OneSpace : string.Empty;
    }
    
    public static string Plural(int number, string irregularNoun = "")
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
        case "has":
          return number > 1 ? "have" : "has";
        case "The":
          return "The"; // CAPITAL, useful because of French plural
        case "the":
          return "the"; // lower case, useful because of French plural
        default:
          return number > 1 ? "s" : string.Empty;
      }
    }
    
    public static string FrenchPlural(int number, string currentLanguage = "english")
    {
      return (number > 1 && currentLanguage.ToLower() == "french") ? "s" : string.Empty;
    }
  }
}