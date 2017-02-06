using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GiftAidCalculator.TestConsole.Enums;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.POCOS;

namespace GiftAidCalculator.TestConsole.Classes
{
    public class EventRepository : IRepository<Event>
    {
        private readonly IList<Event> _events;

        public EventRepository()
        {
            _events = new List<Event>
            {
                new Event
                {
                    EventType = EventTypeEnum.Running,
                    Supplement = 5
                },
                new Event
                {
                    EventType = EventTypeEnum.Swimming,
                    Supplement = 3
                },
                new Event
                {
                    EventType = EventTypeEnum.Other,
                    Supplement = 0
                }
            };
        }

        public Event Update(Event entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var findRate = _events.FirstOrDefault(r => r.EventType == entity.EventType);

            if (findRate == null)
            {
                _events.Add(entity);
                return entity;
            }

            _events.Remove(findRate);
            _events.Add(entity);

            return entity;
        }

        public IEnumerable<Event> Select(Expression<Func<Event, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return _events.Where(predicate.Compile());
        }

        public Event Insert(Event entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _events.Add(entity);

            return entity;
        }
    }
}