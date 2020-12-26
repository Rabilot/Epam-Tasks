using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2.Library.Text.TextElements.Sentence;
using Task_2.Library.Text.TextElements.Sentence.SentenceElements;

namespace Task_2.Library.Text
{
    public class Text : IText
    {
        private readonly StringBuilder _stringBuilder;
        private readonly IList<ISentence> _sentences;

        public Text()
        {
            _sentences = new List<ISentence>();
            _stringBuilder = new StringBuilder();
        }

        public void Add(ISentence sentence)
        {
            _sentences.Add(sentence);
        }

        public Text GetSortedText()
        {
            var sentences = _sentences.OrderBy(item => item.GetWordsCount()).ToList();
            var sortedText = new Text(sentences);
            return sortedText;
        }

        public IList<Word> GetWords(int length, string endMark)
        {
            IList<Word> words = new List<Word>();
            foreach (var sentence in GetSentences(endMark))
            {
                words = sentence.GetWordsByLength(length);
            }

            return words;
        }

        public void DeleteConsonantByLength(int length)
        {
            foreach (var sentence in _sentences)
            {
                foreach (var word in sentence.GetWordsByLength(length).Where(item => item.IsFirstConsonant()))
                {
                    sentence.Remove(word);
                }
            }
        }
        
        public void ReplaceWordToString(int sentenceNumber, int length, string str)
        {
            if (sentenceNumber < 1)
            {
                throw new ArgumentException("Invalid sentence number");
            }
            try
            {
                _sentences[sentenceNumber - 1].Replace(length, str);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public override string ToString()
        {
            _stringBuilder.Clear();
            foreach (var sentence in _sentences)
            {
                _stringBuilder.Append(sentence);
            }
            return _stringBuilder.ToString();
        }
                
        private IList<ISentence> GetSentences(string str)
        {
            return _sentences.Where(sentence => sentence.GetEndOfSentenceMark().Value == str).ToList();
        }
        
        private Text(IList<ISentence> sentences)
        {
            _sentences = sentences;
            _stringBuilder = new StringBuilder();
        }
    }
}