using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_13_6_1
{
    internal class Program
    {

        public static List<string> list = new List<string>();
        public static LinkedList<string> linked_list = new LinkedList<string>();
        public static ReadMyFile file = new ReadMyFile();

        static void Main(string[] args)
        {
            var downloads = @"C:\Users\amigo\Downloads\";
            var path = Path.Combine(downloads, "Text1.txt");
            var words = file.ReadingFile(path);

            //добавляем в List<string>
            var stopWatch = Stopwatch.StartNew();
            foreach ( var word in words )
            {
                list.Add(word);
            }
            // выводим 
            Console.WriteLine($"{words.Length} слов вставилось в список за {stopWatch.Elapsed.TotalSeconds} сек.");

            //добавляем в LinkedList<string>
            var stopWatch_L = Stopwatch.StartNew();
            foreach (var word in words)
            {
                linked_list.AddFirst(word);
            }
            // выводим 
            Console.WriteLine($"{words.Length} слов вставилось в связанный список за {stopWatch.Elapsed.TotalSeconds} сек.");
            Console.ReadKey();
        }
    }
}
