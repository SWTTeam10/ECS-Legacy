namespace ECS.Legacy
{
    public interface IHeater
    {
        bool RunSelfTest();
        void TurnOff();
        void TurnOn();
    }
}