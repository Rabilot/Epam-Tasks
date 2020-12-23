using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2.Text.Parser;
using Task_2.Text.TextElements.Sentence;
using Task_2.Text.TextElements.Sentence.SentenceElements;

namespace Task_2.Text
{
    public class Text : IText
    {
        private IList<ISentence> _sentences;

        public Text()
        {
            _sentences = new List<ISentence>();
        }

        private Text(IList<ISentence> sentences)
        {
            _sentences = sentences;
        }

        public void Add(ISentence sentence)
        {
            _sentences.Add(sentence);
        }

        public Text GetSortedText()
        {
            var sentences = _sentences.OrderBy(item => item.GetLength()).ToList();
            var sortedText = new Text(sentences);
            return sortedText;
        }

        private IList<ISentence> GetInterrogativeSentences()
        {
            return _sentences.Where(sentence => sentence.GetEndOfSentenceMark().Value == "?").ToList();
        }

        public IList<Word> GetWordsWithoutRepeating(int length)
        {
            IList<Word> words = new List<Word>();
            foreach (var sentence in GetInterrogativeSentences())
            {
                words = sentence.GetWordsByLength(length);
            }

            return words;
        }

        public void DeleteConsonantByLength(int length)
        {
            foreach (var sentence in _sentences)
            {
                foreach (Word word in sentence.GetWordsByLength(length))
                {
                    sentence.Remove(word);
                }
            }
        }
        
        public void ReplaceWordToString(int sentenceNumber, int length, string str)
        {
            for (int i = 0; i < _sentences.Count; i++)
            {
                if (i == sentenceNumber - 1)
                {
                    _sentences[i].Replace(length, str);
                }
            }
            IParser parser = new TextParser();
            var text = parser.Parse(ToString());
            _sentences = text._sentences;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var sentence in _sentences)
            {
                stringBuilder.Append(sentence);
            }
            return stringBuilder.ToString();
        }
    }
}