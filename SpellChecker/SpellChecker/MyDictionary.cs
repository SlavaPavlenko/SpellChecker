using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    class MyDictionary
    {
        private List<string> wordList;
        public MyDictionary(List<string> _wordList) {
            wordList = _wordList;
        }

        //формирование списка подходящих замен
        public List<string> GetRelevantWords(string _word, int _editsAmount) {
            //листы для релевантных слов с 1 и 2 ошибками
            List<string> oneMistakeWords = new List<string>();
            List<string> twoMistakeWords = new List<string>();

            foreach (string word in wordList) {
                int mistakeCounter = 0;
                int i = 0;  //счетчик текущей буквы в _word (_wordSpelling)
                int j = 0;  //счетчик текущей буквы в word (wordSpelling)
                List<char> _wordSpelling = word.ToList();
                List<char> wordSpelling = _word.ToList();
                //if (word == "fall" && _word == "fells") {
                //    int dasd = 2;
                //}

                if (wordList.Contains(_word)) {
                    DefineList(_word, mistakeCounter, oneMistakeWords, twoMistakeWords);
                    List<string> res = new List<string>();
                    res.Add(_word);
                    return res;
                }

                //посимвольное сравнение слов
                while (mistakeCounter <= _editsAmount && i < _wordSpelling.Count && j < wordSpelling.Count)
                {
                    if (_wordSpelling[i] != wordSpelling[j])
                    {
                        if (_wordSpelling.Count >= wordSpelling.Count)
                        {
                            _wordSpelling.RemoveAt(i);
                            mistakeCounter++;
                        }
                        else if (_wordSpelling.Count < wordSpelling.Count)
                        {
                            _wordSpelling.Insert(i, wordSpelling[j]);
                            mistakeCounter++;
                        }
                    }
                    else
                    {
                        i++;
                        j++;
                    }
                }
                mistakeCounter += Math.Abs(_wordSpelling.Count - wordSpelling.Count);
                DefineList(word, mistakeCounter, oneMistakeWords, twoMistakeWords);
                

                //...слова одинаковой длины. "Заменяем" букву
                //ОШИБКА! Некорректно работает условие при равных длинах слов
                //сделать удиный алгоритм
                /*
                if (_word.Length == word.Length)
                {
                    while (mistakeCounter <= 2 && i < wordSpelling.Length)
                    {
                        if (_wordSpelling[i] != wordSpelling[j])
                            mistakeCounter += 2;
                        i++;
                        j++;
                    }

                    //запись в соответствующий лист
                    DefineList(word, mistakeCounter, oneMistakeWords, twoMistakeWords);
                }
                //...сравниваемое слово длиннее. "Удаляем" букву из _word
                else if (_word.Length > word.Length) {
                    while (mistakeCounter <= 2 && i < _wordSpelling.Length)
                    {
                        if (j < wordSpelling.Length && _wordSpelling[i] != wordSpelling[j])
                        {
                            mistakeCounter += 1;
                        }
                        else
                            j++;
                        i++;
                    }
                    DefineList(word, mistakeCounter, oneMistakeWords, twoMistakeWords);
                }
                //...сравниваемое слово короче. "Вставляем" букву в _word
                else if (_word.Length < word.Length)
                {
                    while (mistakeCounter <= 2 && i < _wordSpelling.Length)
                    {
                        if (j >= wordSpelling.Length || _wordSpelling[i] != wordSpelling[j])
                        {
                            mistakeCounter += 1;
                        } else
                            i++;
                        j++;
                    }
                    DefineList(word, mistakeCounter, oneMistakeWords, twoMistakeWords);
                }
                */
            }

            if (oneMistakeWords.Count > 0)
                return oneMistakeWords;
            else if (twoMistakeWords.Count > 0)
                return twoMistakeWords;
            else
                return null;
        }

        //записывает слово из словаря в соответствующий список
        //нужно для избежания дублирования кода в GetRelevantWords()
        private void DefineList(string _word, int _mistakeCounter, List<string> _oneMistakeWords, List<string> _twoMistakeWords) {
            switch (_mistakeCounter)
            {
                case 1:
                    _oneMistakeWords.Add(_word);
                    break;
                case 2:
                    _twoMistakeWords.Add(_word);
                    break;
            }
        }
    }
}
