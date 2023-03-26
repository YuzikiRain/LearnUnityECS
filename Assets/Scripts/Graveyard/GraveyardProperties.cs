using Unity.Entities;
using Unity.Mathematics;

namespace DefaultNamespace
{
    public struct GraveyardProperties : IComponentData
    {
        public float2 FIeldDimensions;
        public int NumberTombstonesToSpawn;
        public Entity TombstonePrefab;
        public Entity ZombiePrefab;
        public float ZombieSpawnRate;
    }

    public struct ZombieSpawnTimer : IComponentData
    {
        public float Value;
    }
}