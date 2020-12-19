namespace Task_2.Text.TextElements.Sentence.SentenceElements
{
    public abstract class SenteceItem
    {
        public virtual string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}