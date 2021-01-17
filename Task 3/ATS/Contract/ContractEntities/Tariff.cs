namespace Task_3.ATS.Contract.ContractEntities
{
    public class Tariff
    {
        public double CostPerMinute { get; }
        private const double DefaultCostPerMinute = 0.1;

        public Tariff(double costPerMinute = DefaultCostPerMinute)
        {
            CostPerMinute = costPerMinute;
        }
    }
}