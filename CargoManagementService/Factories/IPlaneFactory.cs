using CargoManagementService.Interfaces;


namespace CargoManagementService.Factories
{
    internal interface IPlaneFactory
    {
        public IPlane GetPlane(int id);
    }
}
