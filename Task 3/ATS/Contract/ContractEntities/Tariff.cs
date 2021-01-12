namespace Task_3.ATS.Contract.ContractEntities
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