using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Task_13_6_2
{
    internal class Program
    {

        public static ReadMyFile file = new ReadMyFile();

        static void Main(string[] args)
        {
            var downloads = @"C:\Users\amigo\Downloads\";
            var path = Path.Combine(downloads, "Text1.txt");
            var text = File.ReadAllText(path);

            // Удаляем знаки препинания из текста
            string cleanText = Regex.Replace(text, @"[^\w\s]", "");

            // Разделение текста на отдельные слова
            string[] words = cleanText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Создание словаря для подсчета количества встреч каждого слова
            Dictionary<string, int> most_common_words = new Dictionary<string, int>();

            // Подсчет встречаемости каждого слова длиной больше 3 символов потому что очень много попадает частиц, предлогов и т.д.
            foreach (string word in words)
            {
                string lowercase_word = word.ToLower();
                if (lowercase_word.Length > 3)
                {
                    if (most_common_words.ContainsKey(lowercase_word))
                    {
                        most_common_words[lowercase_word]++;
                    }
                    else
                    {
                        most_common_words[lowercase_word] = 1;
                    }
                }
            }

            // Получение топ-10 часто встречающихся слов
            var topWords = most_common_words.OrderByDescending(pair => pair.Value).Take(10);

            // Вывод топ-10 слов
            Console.WriteLine("Топ-10 наиболее часто встречающихся слов:");
            foreach (var pair in topWords)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value} раз");
            }

            Console.ReadKey();
        }
    }
}
