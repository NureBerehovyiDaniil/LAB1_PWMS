using System;
using System.Linq;

namespace StringChangeLibrary
{
    public class StringClass
    {
        // Метод для пошуку найдовшого слова у рядку
        public string FindLongestWord(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            var words = value
                .Split(new char[] { ' ', '\t', ',', '.', ';', ':', '!', '?', '-', '(', ')', '[', ']', '{', '}', '"' },
                       StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
                return string.Empty;

            string longestWord = words[0];

            foreach (var word in words)
            {
                if (word.Length > longestWord.Length)
                    longestWord = word;
            }

            return longestWord;
        }
    }
}