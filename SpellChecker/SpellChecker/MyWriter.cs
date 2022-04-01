using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    class MyWriter
    {
        private StreamWriter streamWriter;
        public MyWriter(string filePath)
        {
            try
            {
                streamWriter = new StreamWriter(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка записи в файл:");
                Console.WriteLine(e.Message);
            }
        }

        //запись в выходной файл
        public void Write(string _word, List<string> _relevantWords) {
            if (_word == "\n")
                streamWriter.Write(_word);
            else if (_relevantWords == null)
                streamWriter.Write("{" + _word + "?} ");
            else if (_relevantWords.Count == 1)
                streamWriter.Write(_relevantWords[0] + " ");
            else {
                streamWriter.Write("{");
                for (int i = 0; i < _relevantWords.Count; i++) {
                    streamWriter.Write(_relevantWords[i]);
                    if (i != _relevantWords.Count-1)
                        streamWriter.Write(" ");
                }
                streamWriter.Write("} ");
            }

            streamWriter.Flush();
        }
    }
}
