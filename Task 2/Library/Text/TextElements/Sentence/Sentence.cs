using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2.Library.Text.TextElements.Sentence.SentenceElements;
using Task_2.Library.Text.TextElements.Sentence.SentenceElements.Punctuation;

namespace Task_2.Library.Text.TextElements.Sentence
{
    public class Sentence : ISentence
    {
        private readonly StringBuilder _stringBuilder;
        private readonly IList<SentenceItem> _elementsOfSentence;

        public Sentence()
        {
            _stringBuilder = new StringBuilder();
            _elementsOfSentence = new List<SentenceItem>();
        }

        public void Add(SentenceItem item)
        {
            _elementsOfSentence.Add(item);
        }

        public int GetWordsCount()
        {
            return _elementsOfSentence.Count(item => item is Word);
        }

        public EndOfSentenceMark GetEndOfSentenceMark()
        {
            foreach (var item in _elementsOfSentence)
            {
                if (item is EndOfSentenceMark mark)
                {
                    return mark;
                }
            }
            throw new Exception("End of sentence not found!");
        }

        public IList<Word> GetWordsByLength(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException();
            }
            return _elementsOfSentence.OfType<Word>().Where(item => item.Value.Length == length).ToList();
        }

        public void Remove(SentenceItem word)
        {
            if (_elementsOfSentence.IndexOf(word) != -1)
            {
                int index = _elementsOfSentence.IndexOf(word);
                _elementsOfSentence.RemoveAt(index);
                if (index > 0)
                {
                    _elementsOfSentence.RemoveAt(index - 1);
                }
            }
        }

        public void Replace(int length, string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            foreach (var word in GetWordsByLength(length))
            {
                word.Value = str;
            }
        }

        public override string ToString()
        {
            _stringBuilder.Clear();
            foreach (var element in _elementsOfSentence)
            {
                _stringBuilder.Append(element);
            }
            _stringBuilder.Append(' ');
            
            return _stringBuilder.ToString();
        }
    }
}