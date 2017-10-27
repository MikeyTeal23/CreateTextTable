using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Exercise1_ConsoleApp
{
    class Program
    {
        const int PubDateChars = 11;
        const int TitleChars = 27;
        const int AuthorChars = 31;

        public static void Main(string[] args)
        {
            Console.WriteLine(CreateTable());
        }

        public static string CreateTable()
        {

            string[] allLines = File.ReadAllLines(@"C:\Work\Training\Training-Oct-17\StringsAndEncodings\Exercise1_ConsoleApp\Exercise1_ConsoleApp\Exercise1CSV.csv");
            List<string[]> lineTextList = new List<string[]>();
            foreach (var line in allLines)
            {
                lineTextList.Add(line.Split(','));
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(WriteFormattedLine(lineTextList[0], false));
            sb.AppendLine(WriteLongLine());
            for (int i = 1; i < 4; i++)
            {
                sb.AppendLine(WriteFormattedLine(lineTextList[i], true));
            }
            return sb.ToString();
        }

        static string WriteFormattedLine(string[] lineText, bool containsDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("| ");
            if (containsDate)
            {
                DateTime date = DateTime.Parse(lineText[0]);
                string dateString = String.Format("{0:dd MMM yyyy}", date);
                sb.Append(FormattedText(dateString, PubDateChars, PaddingDir.Right));
            }
            else
            {
                sb.Append(FormattedText(lineText[0], PubDateChars, PaddingDir.Right));

            }
            sb.Append(" | ");
            sb.Append(FormattedText(lineText[1], TitleChars, PaddingDir.Left));
            sb.Append(" | ");
            sb.Append(FormattedText(lineText[2], AuthorChars, PaddingDir.Right));
            sb.Append(" |");
            return sb.ToString();
        }

        static string WriteLongLine()
        {
            int loopLimit = 8 + PubDateChars + TitleChars + AuthorChars;

            StringBuilder sb = new StringBuilder();
            sb.Append("|");
            for (int i = 0; i < loopLimit; i++)
            {
                sb.Append("=");
            }
            sb.Append("|");
            return sb.ToString();
        }

        static string FormattedText(string str, int cellLength, PaddingDir dir)
        {
            if (str.Length > cellLength)
            {
                str = str.Substring(0, cellLength - 3);
                str += "...";
                return str;
            }

            if (dir == PaddingDir.Right)
            {
                return str.PadRight(cellLength);
            }

            return str.PadLeft(cellLength);
        }

        public enum PaddingDir
        {
            Left,
            Right
        }
    }
}
