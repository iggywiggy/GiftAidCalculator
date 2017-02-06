using System;
using GiftAidCalculator.TestConsole.Enums;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole.Classes
{
    public class Calculator : ICalculator
    {
        private readonly IEventService _eventService;
        private readonly ITaxRateService _taxRateService;


        public Calculator(ITaxRateService taxRateService, IEventService eventService)
        {
            if (taxRateService == null)
            {
                throw new ArgumentNullException(nameof(taxRateService));
            }

            if (eventService == null)
            {
                throw new ArgumentNullException(nameof(eventService));
            }

            _taxRateService = taxRateService;
            _eventService = eventService;
        }

        public decimal CalculateGiftAid(decimal donationAmount, EventTypeEnum eventType)
        {
            if (donationAmount <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(donationAmount)} cannot be zero or less");
            }

            var taxRate = _taxRateService.GetTaxRate();

            Console.WriteLine($"Tax Rate {taxRate}");

            var giftAid = CalculateRatio(taxRate, donationAmount);

            var supplement = CalculateRatio(_eventService.GetEventSupplement(eventType), giftAid);

            var totalAmount = Math.Round(donationAmount + supplement + giftAid, 2);

            Console.WriteLine(
                $"Your donation of £{donationAmount} has a gift aid of £{giftAid} and a supplement of {supplement}, {Environment.NewLine} giving a total of £{totalAmount} to the charity.");

            return Math.Round(supplement + giftAid, 2);
        }

        private decimal CalculateRatio(decimal percentage, decimal donation)
        {
            var rate = percentage/100;
            var giftAid = donation*rate;
            return Math.Round(giftAid, 2);
        }
    }
}