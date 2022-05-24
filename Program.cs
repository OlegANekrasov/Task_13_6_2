using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Task_13_6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // читаем весь файл в строку текста
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Text1.txt");
            string text = File.ReadAllText(path);
            
            // убрираем из текста знаки пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            var dictionary = new Dictionary<string, long>();

            // Добавляем все слова
            foreach (var word in words)
            {
                if(dictionary.ContainsKey(word))
                {
                    ++dictionary[word];
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }

            // сортируем по убыванию
            var dictionarySort = dictionary.OrderByDescending(o => o.Value);

            // Выведем результат
            Console.WriteLine("10 слов чаще всего встречающихся:\n");
            var i = 0;
            foreach(var keyValuePair in dictionarySort)
            {
                ++i;
                
                Console.WriteLine($"Слово: \"{keyValuePair.Key}\" встречается: {keyValuePair.Value}");
                
                if(i == 10)
                {
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
