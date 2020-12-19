using System.Collections.Generic;
using System.Text;
using Task_2.Text.TextElements.Sentence;

namespace Task_2.Text
{
    public class Text : IText
    {
        private readonly IList<ISentence> _sentences;

        public Text()
        {
            _sentences = new List<ISentence>();
        }

        public void Add(ISentence sentence)
        {
            _sentences.Add(sentence);
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