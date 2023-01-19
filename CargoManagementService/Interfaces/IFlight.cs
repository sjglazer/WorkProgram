namespace CargoManagementService.Interfaces
{
    internal interface IFlight
    {
        bool IsAtMaxCapacity();
        void AddBox();
    }
}
