using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_13_6_2
{
    internal class ReadMyFile
    {
        public string[] ReadingFile(string path)
        {
            // читаем весь файл в строку текста
            string text = File.ReadAllText(path);

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }
    }
}
