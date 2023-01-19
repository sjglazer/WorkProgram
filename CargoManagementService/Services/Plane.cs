using CargoManagementService.Interfaces;

namespace CargoManagementService.Services
{
    internal class Plane : IPlane
    {
        public int Id { get; }

        public Plane(int id)
        {
            Id = id;
        }
    }
}
