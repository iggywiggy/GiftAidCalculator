namespace GiftAidCalculator.TestConsole.Interfaces
{
    public interface ITaxRateService
    {
        void SetNewTaxRate(decimal newTaxRate);
        decimal GetTaxRate();
    }
}