namespace Task_3.ATS_entities
{
    public class Tariff
    {
        public double CostPerMinute { get; }

        public Tariff(double costPerMinute)
        {
            CostPerMinute = costPerMinute;
        }
    }
}