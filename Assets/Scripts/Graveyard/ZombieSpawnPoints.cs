using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace DefaultNamespace
{
    public struct ZombieSpawnPoints : IComponentData
    {
        public NativeArray<float3> Value;
        
    }
}