using System;
using GiftAidCalculator.TestConsole.Commands;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.POCOS;
using Microsoft.Practices.Unity;

namespace GiftAidCalculator.TestConsole.Classes
{
    public sealed class DiContainer : IDisposable
    {
        private static DiContainer _instance;

        private DiContainer()
        {
            Container = new UnityContainer();
            RegisterTypes();
        }

        public static DiContainer Instance => _instance ?? (_instance = new DiContainer());

        public IUnityContainer Container { get; }


        public void Dispose()
        {
            Container.Dispose();
        }


        private void RegisterTypes()
        {
            Container.RegisterType<ICommandFactory, CommandFactory>();
            Container.RegisterType<ICommand, AdministratorCommand>("AdministratorCommand");
            Container.RegisterType<ICommand, DonorCommand>("DonorCommand");
            Container.RegisterType<ICalculator, Calculator>();
            Container.RegisterType<ITaxRateService, TaxRateService>();
            Container.RegisterType<IRepository<TaxRate>, TaxRateRepository>();
        }

        public ICommandFactory ResolveCommandFactory()
        {
            return Container.Resolve<ICommandFactory>();
        }
    }
}