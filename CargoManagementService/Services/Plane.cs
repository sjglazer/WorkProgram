using CargoManagementService.Interfaces;

namespace CargoManagementService.Services
{
    internal class Plane : IPlane
    {
        private readonly int _id;
        
        public Plane(int id)
        {
            _id = id;
        }
    }
}
