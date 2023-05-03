using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace HelloCube.Prefabs
{
    public partial struct SpawnSystem : ISystem
    {
        EntityQuery m_SpinningCubes;
        private uint updateCounter;

        [BurstCompile]
        public void OnCreate(ref SystemState systemState)
        {
            // 等待Spawner已经bake完毕再执行，否则执行时取Spawner可能为空
            systemState.RequireForUpdate<Spawner>();
            systemState.RequireForUpdate<Execute.Prefabs>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState systemState)
        {
            // 这里假定prefab身上附加了RotationSpeedAuthoring脚本，可bake出RotationSpeed
            var rotateCubesQuery = SystemAPI.QueryBuilder().WithAll<RotationSpeed>().Build();
            // 因此查询RotationSpeed是否存在等同于查询prefab是否已经被Instantiate了，如果prefab没有该组件，则会一直复制prefab
            if (!rotateCubesQuery.IsEmpty) return;

            // Spawner全局只存在一个，可以使用GetSingleton
            var prefabEntity = SystemAPI.GetSingleton<Spawner>().PrefabEntity;
            var instances = systemState.EntityManager.Instantiate(prefabEntity, 500, Allocator.Temp);
            var random = Random.CreateFromIndex(updateCounter++);

            foreach (var entity in instances)
            {
                var transform = SystemAPI.GetComponentRW<LocalTransform>(entity, false);
                // 设置一个随机的初始位置
                transform.ValueRW.Position = (random.NextFloat3() - new float3(0.5f, 0, 0.5f)) * 20;
            }
        }
    }
}