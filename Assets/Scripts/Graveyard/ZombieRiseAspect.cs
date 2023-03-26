using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DefaultNamespace
{
    public readonly partial struct ZombieRiseAspect : IAspect
    {
        public readonly Entity Entity;

        private readonly RefRW<LocalTransform> _transformAspect;
        private readonly RefRO<ZombieRiseRate> _zombieRiseRate;

        public void Rise(float deltaTime)
        {
            _transformAspect.ValueRW.Position += math.up() * _zombieRiseRate.ValueRO.Value * deltaTime;
        }

        public bool IsAboveGround => _transformAspect.ValueRO.Position.y >= 0f;

        public void SetAtGroundLevel()
        {
            var position = _transformAspect.ValueRO.Position;
            position.y = 0f;
            _transformAspect.ValueRW.Position = position;
        }
    }
}