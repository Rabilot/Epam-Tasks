using System.Collections.Generic;
using Task_2.Text.TextElements.Sentence;
using Task_2.Text.TextElements.Sentence.SentenceElements;

namespace Task_2.Text
{
    public interface IText
    {
        void Add(ISentence sentence);
        Text GetSortedText();
        IList<Word> GetWordsWithoutRepeating(int length);
        void DeleteConsonantByLength(int length);
        void ReplaceWordToString(int sentenceNumber, int length, string str);
    }
}