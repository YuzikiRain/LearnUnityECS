using Unity.Entities;
using Random = Unity.Mathematics.Random;

namespace DefaultNamespace
{
    public struct GraveyardRandom : IComponentData
    {
        public Random Value;
    }
}