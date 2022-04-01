using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    class MyReader
    {
        private StreamReader streamReader;
        public MyReader(string filePath, string _separator) {
            if (!File.Exists("input.txt")) {
                using (StreamWriter streamWriter = File.CreateText("input.txt")) {
                    streamWriter.WriteLine(_separator);
                    streamWriter.WriteLine(_separator);
                }
            }
            try
            {
                streamReader = new StreamReader(filePath);
            }
            catch (Exception e) {
                Console.WriteLine("Ошибка чтения файла:");
                Console.WriteLine(e.Message);
            }
        }

        public List<string> ReadToSeparator(string _separator)
        {
            List<string> res = new List<string>();

            string currentString = "";
            List<string> separatedLines = new List<string>();
            do
            {
                currentString = streamReader.ReadLine();
                separatedLines.Add(currentString);
            } while (currentString != _separator);

            foreach (var str in separatedLines) { 
                string[] separatedWords = str.Split(' ');

                foreach (string item in separatedWords)
                    if (item != "===" && item != "")
                        res.Add(item);

                if (str != _separator)
                    res.Add("\n");
            }
            
            return res;
        }

        //public List<string> ReadToSeparator() {
        //    List<string> res = new List<string>();

        //    string currentString = "";
        //    string text = "";
        //    do {
        //        currentString = streamReader.ReadLine();
        //        text += currentString  + " ";
        //    } while (currentString != "===");

        //    string[] separatedWords = text.Split(' ');

        //    foreach (string item in separatedWords)
        //        if (item != "===" && item != "")
        //            res.Add(item);

        //    return res;
        //}

        public void Close() {
            streamReader.Close();
        }
    }
}
