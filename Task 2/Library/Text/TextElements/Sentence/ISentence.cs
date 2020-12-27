using System.Collections.Generic;
using Task_2.Library.Text.TextElements.Sentence.SentenceElements;
using Task_2.Library.Text.TextElements.Sentence.SentenceElements.Punctuation;

namespace Task_2.Library.Text.TextElements.Sentence
{
    public interface ISentence
    {
        void Add(SentenceItem item);
        int GetWordsCount();
        EndOfSentenceMark GetEndOfSentenceMark();
        IList<Word> GetWordsByLength(uint length);
        void Remove(SentenceItem word);
        void Replace(uint wordsLength, string str);
    }
}