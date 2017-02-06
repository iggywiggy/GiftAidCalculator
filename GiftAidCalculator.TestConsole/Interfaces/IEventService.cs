using GiftAidCalculator.TestConsole.Enums;

namespace GiftAidCalculator.TestConsole.Interfaces
{
    public interface IEventService
    {
        decimal GetEventSupplement(EventTypeEnum eventType);
    }
}