using System.Linq;
using System.Text.RegularExpressions;
using Task_2.Library.Text.TextElements.Sentence;
using Task_2.Library.Text.TextElements.Sentence.SentenceElements;
using Task_2.Library.Text.TextElements.Sentence.SentenceElements.Punctuation;

namespace Task_2.Library.Text.Parser
{
    public class TextParser : IParser
    {
        private readonly string[] _punctuation = {",", "\"", "-", "—", " "};
        private readonly string[] _endOfSentence = {".", "!", "?", "...", "!?", "?!"};
        private const string SentenceParserRegEx = @"((\w|['-])+)|([\W_-[\s]]+)|\s+";
        private const string TextParserRegEx = @"(?<=[\.!\?])\s";

        public Text Parse(string textString)
        {
            var text = new Text();
            var elements = Regex.Split(textString, TextParserRegEx);
            foreach (string sentence in elements)
            {
                text.Add(ParseSentence(sentence));
            }
            return text;
        }

        private ISentence ParseSentence(string sentenceString)
        {
            var sentence = new Sentence();
            var elements = Regex.Matches(sentenceString, SentenceParserRegEx);
            foreach (var element in elements)
            {
                var elementString = element.ToString();
                if (IsWord(elementString))
                {
                    sentence.Add(new Word(elementString));
                }
                else if (IsPunctuation(element.ToString()))
                {
                    sentence.Add(new PunctuationMark(SimplifyEmptyString(element.ToString())));
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
            return Regex.IsMatch(str, @"((\w|['-])+)");
        }

        private bool IsEndOfSentence(string str)
        {
            return _endOfSentence.Any(str.Contains);
        }

        private string SimplifyEmptyString(string str)
        {
            if (str.Length > 0 && string.IsNullOrWhiteSpace(str))
            {
                str = " ";
            }
            return str;
        }
    }
}