using System;
using GiftAidCalculator.TestConsole.Classes;
using GiftAidCalculator.TestConsole.Enums;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.POCOS;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    public class EventRepositoryTests
    {
        private IRepository<Event> _repository;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _repository = new EventRepository();
        }

        [Test]
        public void Update_ParamEntity_Null_ThrowsArgumentNullException()
        {
            Assert.Throws(typeof (ArgumentNullException), () => _repository.Update(null));
        }

        [Test]
        public void Update_ParamEntity_TaxRateUpdated()
        {
            var entity = new Event
            {
                EventType = EventTypeEnum.Other,
                Supplement = 0
            };

            var result = _repository.Update(entity);

            Assert.AreSame(entity, result);
        }

        [Test]
        public void Update_ParamEntity_EntityDoesntExist_Inserted()
        {
            var entity = new Event
            {
                EventType = EventTypeEnum.Running,
                Supplement = 5
            };

            var result = _repository.Update(entity);

            CollectionAssert.Contains(_repository.Select(rate => rate.EventType == entity.EventType), result);
        }

        [Test]
        public void Insert_ParamEntity_Null_ThrowsArgumentNullException()
        {
            Assert.Throws(typeof (ArgumentNullException), () => _repository.Insert(null));
        }

        [Test]
        public void Insert_ParamEntity_EntityIsInserted()
        {
            var entity = new Event
            {
                EventType = EventTypeEnum.Swimming,
                Supplement = 3
            };

            var result = _repository.Insert(entity);

            CollectionAssert.Contains(_repository.Select(rate => true), result);
        }

        [Test]
        public void Select_ParamPredicate_Null_ThrowsArgumentNullException()
        {
            Assert.Throws(typeof (ArgumentNullException), () => _repository.Select(null));
        }
    }
}