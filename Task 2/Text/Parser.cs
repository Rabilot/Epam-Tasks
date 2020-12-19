using System.Linq;
using System.Text.RegularExpressions;
using Task_2.Text.TextElements.Sentence;
using Task_2.Text.TextElements.Sentence.SentenceElements;

namespace Task_2.Text
{
    public class Parser
    {
        private static readonly string[] Punctuation = {",", ".", "!", "?", "\"", "-", "—", "...", "!?", "?!", " "};

        public static Task_2.Text.Text Parse(string textString)
        {
            var text = new Task_2.Text.Text();
            var elements = Regex.Split(textString, @"(?<=[\.!\?]\s)");
            foreach (string sentence in elements)
            {
                text.Add(ParseSentence(sentence));
            }
            return text;
        }

        private static ISentence ParseSentence(string sentenceString)
        {
            var sentence = new Sentence();
            var elements = Regex.Matches(sentenceString, @"((\w|['])+)|([\W_-[\s]]+)|\s+");
            foreach (var element in elements)
            {
                if (IsPunctuation(element.ToString()))
                {
                    sentence.Add(new Punctuation(DeleteTabs(element.ToString())));
                }

                if (IsWord(element.ToString()))
                {
                    sentence.Add(new Word(element.ToString()));
                }
            }
            return sentence;
        }
        
        private static bool IsPunctuation(string str)
        {
            return Punctuation.Any(str.Contains);
        }

        private static bool IsWord(string str)
        {
            return Regex.IsMatch(str, @"((\w|['])+)");
        }

        private static string DeleteTabs(string str)
        {
            if (str.Length > 0 && str[0] == ' ') str = " ";
            return str;
        }
    }
}