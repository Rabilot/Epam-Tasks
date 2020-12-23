using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2.Text.Parser;
using Task_2.Text.TextElements.Sentence.SentenceElements;
using Task_2.Text.TextElements.Sentence.SentenceElements.Punctuation;

namespace Task_2.Text.TextElements.Sentence
{
    public class Sentence : ISentence
    {
        private readonly IList<SentenceItem> _elementsOfSentence;

        public Sentence()
        {
            _elementsOfSentence = new List<SentenceItem>();
        }

        public void Add(SentenceItem item)
        {
            _elementsOfSentence.Add(item);
        }

        public int GetLength()
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
            return _elementsOfSentence.OfType<Word>().Where(item => item.Value.Length == length).ToList();
        }

        public void Remove(SentenceItem word)
        {
            _elementsOfSentence.Remove(word);
        }

        public void Replace(int length, string str)
        {
            var words = GetWordsByLength(length);
            foreach (var word in GetWordsByLength(length))
            {
                word.Value = str;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var element in _elementsOfSentence)
            {
                stringBuilder.Append(element);
            }
            stringBuilder.Append(' ');
            
            return stringBuilder.ToString();
        }
    }
}