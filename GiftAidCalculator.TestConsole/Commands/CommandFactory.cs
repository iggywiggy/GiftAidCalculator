using System;
using System.Collections.Generic;
using GiftAidCalculator.TestConsole.Classes;
using GiftAidCalculator.TestConsole.Enums;
using GiftAidCalculator.TestConsole.Interfaces;
using Microsoft.Practices.Unity;

namespace GiftAidCalculator.TestConsole.Commands
{
 
    public class CommandFactory : ICommandFactory
    {
        private IDictionary<RoleEnum, Type> _commandsDictionary;

        public CommandFactory()
        {
            RegisterCommands();
        }

        public void Resolve(RoleEnum role, object[] args)
        {
            var commandType = _commandsDictionary[role];

            var command = DiContainer.Instance.Container.Resolve<ICommand>(commandType.Name);
            command.Execute(args);
        }

        private void RegisterCommands()
        {
            _commandsDictionary = new Dictionary<RoleEnum, Type>
            {
                {RoleEnum.Administrator, typeof (AdministratorCommand)},
                {RoleEnum.Donor, typeof (DonorCommand)}
            };
        }
    }
}
