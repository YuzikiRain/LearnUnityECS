using Unity.Entities;

namespace DefaultNamespace
{
    public struct ZombieProperties : IComponentData
    {
    }

    public struct ZombieHeading : IComponentData
    {
        public float Value;
    }
}