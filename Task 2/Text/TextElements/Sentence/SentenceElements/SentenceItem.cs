namespace Task_2.Text.TextElements.Sentence.SentenceElements
{
    public abstract class SentenceItem
    {
        public string Value { get; set; }

        public SentenceItem(string value)
        {
            Value = value;
        }
        
        public override string ToString()
        {
            return Value;
        }
    }
}