using System.Collections.Generic;
using System.Text;
using Task_2.Text.TextElements.Sentence.SentenceElements;

namespace Task_2.Text.TextElements.Sentence
{
    public class Sentence : ISentence
    {
        private readonly IList<SenteceItem> _elementsOfSentence;

        public Sentence()
        {
            _elementsOfSentence = new List<SenteceItem>();
        }

        public void Add(SenteceItem item)
        {
            _elementsOfSentence.Add(item);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var element in _elementsOfSentence)
            {
                stringBuilder.Append(element);
            }
            return stringBuilder.ToString();
        }
    }
}