using System.Linq;
using System.Text.RegularExpressions;
using Task_2.Text.TextElements.Sentence;
using Task_2.Text.TextElements.Sentence.SentenceElements;
using Task_2.Text.TextElements.Sentence.SentenceElements.Punctuation;

namespace Task_2.Text.Parser
{
    public class TextParser : IParser
    {
        private readonly string[] _punctuation = {",", "\"", "-", "—", " "};
        private readonly string[] _endOfSentence = {".", "!", "?", "...", "!?", "?!"};

        public Text Parse(string textString)
        {
            var text = new Text();
            var elements = Regex.Split(textString, @"(?<=[\.!\?])\s");
            foreach (string sentence in elements)
            {
                text.Add(ParseSentence(sentence));
            }
            return text;
        }

        private ISentence ParseSentence(string sentenceString)
        {
            var sentence = new Sentence();
            var elements = Regex.Matches(sentenceString, @"((\w|['-])+)|([\W_-[\s]]+)|\s+");
            foreach (var element in elements)
            {
                if (IsWord(element.ToString()))
                {
                    sentence.Add(new Word(element.ToString()));
                }else if (IsPunctuation(element.ToString()))
                {
                    sentence.Add(new PunctuationMark(DeleteTabs(element.ToString())));
                }
                else if (IsEndOfSentence(element.ToString()))
                {
                    sentence.Add(new EndOfSentenceMark(element.ToString()));
                }
            }
            return sentence;
        }
        
        private bool IsPunctuation(string str)
        {
            return _punctuation.Any(str.Contains);
        }

        private bool IsWord(string str)
        {
            return Regex.IsMatch(str, @"((\w|['])+)");
        }

        private bool IsEndOfSentence(string str)
        {
            return _endOfSentence.Any(str.Contains);
        }

        private string DeleteTabs(string str)
        {
            if (str.Length > 0 && str[0] == ' ') str = " ";
            return str;
        }
    }
}