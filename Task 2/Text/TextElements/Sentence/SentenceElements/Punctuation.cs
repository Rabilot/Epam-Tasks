namespace Task_2.Text.TextElements.Sentence.SentenceElements
{
    public sealed class Punctuation : SenteceItem
    {
        public Punctuation(string value)
        {
            Value = value;
        }
        
        public override string ToString()
        {
            return Value;
        }
    }
}