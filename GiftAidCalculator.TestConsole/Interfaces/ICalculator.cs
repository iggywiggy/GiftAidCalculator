using GiftAidCalculator.TestConsole.Enums;

namespace GiftAidCalculator.TestConsole.Interfaces
{
    public interface ICalculator
    {
        decimal CalculateGiftAid(decimal donationAmount, EventTypeEnum eventType);
    }
}