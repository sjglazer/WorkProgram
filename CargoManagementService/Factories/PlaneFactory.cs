using CargoManagementService.Interfaces;
using System.Collections.Concurrent;
using CargoManagementService.Services;


namespace CargoManagementService.Factories
{
    internal class PlaneFactory : IPlaneFactory
    {
        private readonly ConcurrentDictionary<int, IPlane> _planes = new ConcurrentDictionary<int, IPlane>();
        
        public IPlane GetPlane(int id)
        {
            var plane = _planes.GetOrAdd(id, (key) => new Plane(id));
            return plane;
        }
    }
}
