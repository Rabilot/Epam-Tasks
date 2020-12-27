using System.Collections.Generic;
using Task_2.Library.Text.TextElements.Sentence;
using Task_2.Library.Text.TextElements.Sentence.SentenceElements;

namespace Task_2.Library.Text
{
    public interface IText
    {
        void Add(ISentence sentence);
        Text GetSortedText();
        IList<Word> GetWords(uint length, string endMark);
        void DeleteConsonantByLength(uint length);
        void ReplaceWordToString(int sentenceNumber, uint length, string str);
    }
}