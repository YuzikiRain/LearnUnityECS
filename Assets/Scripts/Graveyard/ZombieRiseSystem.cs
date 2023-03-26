using Unity.Burst;
using Unity.Entities;

namespace DefaultNamespace
{
    [BurstCompile]
    [UpdateAfter(typeof(SpawnZombieSystem))]
    public partial struct ZombieRiseSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();

            new ZombieRiseJob()
            {
                DeltaTime = deltaTime,
                ECB = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter(),
            }.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct ZombieRiseJob : IJobEntity
    {
        public float DeltaTime;
        public EntityCommandBuffer.ParallelWriter ECB;

        [BurstCompile]
        private void Execute(ZombieRiseAspect zombieRiseAspect, [EntityIndexInQuery]int sortKey)
        {
            zombieRiseAspect.Rise(DeltaTime);
            if (!zombieRiseAspect.IsAboveGround) return;

            zombieRiseAspect.SetAtGroundLevel();
            ECB.RemoveComponent<ZombieRiseRate>(sortKey, zombieRiseAspect.Entity);
        }
    }
}