using GiftAidCalculator.TestConsole.Enums;

namespace GiftAidCalculator.TestConsole.Interfaces
{
    public interface ICommandFactory
    {
        void Resolve(RoleEnum role, object[] args);
    }
}