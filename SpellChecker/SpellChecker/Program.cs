using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string separator = "===";   //разделитель словаря и текста в файле input.txt
            MyReader reader = new MyReader("input.txt", separator);
            MyWriter writer = new MyWriter("output.txt");

            //чтение словаря и текста
            MyDictionary dictionary = new MyDictionary(reader.ReadToSeparator(separator));
            List<string> text = reader.ReadToSeparator(separator);
            reader.Close();

            //для каждого слова текста ищются наиболее релевантные аналоги
            foreach (string word in text) {
                List<string> relevantWords = dictionary.GetRelevantWords(word, 2);
                writer.Write(word, relevantWords);
            }

            Console.WriteLine("Программа завершена успешно. Результат записан в файл output.txt");
            Console.Read();
        }
    }
}
