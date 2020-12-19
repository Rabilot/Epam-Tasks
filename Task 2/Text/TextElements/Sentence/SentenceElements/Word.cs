namespace Task_2.Text.TextElements.Sentence.SentenceElements
{
    public sealed class Word : SenteceItem
    {
        public Word(string str)
        {
            Value = str;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}