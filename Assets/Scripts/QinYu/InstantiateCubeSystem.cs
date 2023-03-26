using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace QinYu
{
    public partial struct InstantiateCubeSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<InstantiateCubeComponentData>();
        }

        public void OnUpdate(ref SystemState state)
        {
            // 创建
            var generator = SystemAPI.GetSingleton<InstantiateCubeComponentData>();
            var cubes = state.EntityManager.Instantiate(generator.CubePrefab, generator.CubeCount, Allocator.Temp);
            int count = 0;
            foreach (var cube in cubes)
            {
                state.EntityManager.AddComponentData(cube, new RotateComponentData()
                {
                    RotateSpeed = count * math.radians(60.0f),
                    MoveSpeed = count,
                });

                // 另一种方式
                // var cubes = CollectionHelper.CreateNativeArray<Entity>(generator.CubeCount, Allocator.Temp);
                //state.EntityManager.Instantiate(generator.cubeEntityProtoType, cubes);

                // 设置位置
                var transform = SystemAPI.GetComponent<LocalTransform>(cube);
                transform.Position = new float3((count - generator.CubeCount * 0.5f) * 1.2f, 0, 0);
                
                count++;
            }
        }
    }
}