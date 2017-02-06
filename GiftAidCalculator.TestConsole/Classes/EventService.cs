using System;
using System.Linq;
using GiftAidCalculator.TestConsole.Enums;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.POCOS;

namespace GiftAidCalculator.TestConsole.Classes
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _repository;

        public EventService(IRepository<Event> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            _repository = repository;
        }

        public decimal GetEventSupplement(EventTypeEnum eventType)
        {
            return _repository.Select(e => e.EventType == eventType).FirstOrDefault().Supplement;
        }
    }
}