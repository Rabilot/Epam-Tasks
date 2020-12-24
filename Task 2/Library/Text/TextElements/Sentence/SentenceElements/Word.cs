namespace Task_2.Library.Text.TextElements.Sentence.SentenceElements
{
    public class Word : SentenceItem
    {
        private const string ConsonantSymbols = "qwrtypsdfghjklzxcvbnmйцкнгшщзхфвпрлджчсмтб";

        public Word(string str) : base(str)
        {
        }

        public bool IsFirstConsonant()
        {
            return ConsonantSymbols.Contains(Value[0].ToString());
        }
    }
}