using Unity.Entities;
using UnityEngine;

namespace HelloCube.Prefabs
{
    public class SpawnerAuthoring : MonoBehaviour
    {
        public GameObject Prefab;

        class Baker : Baker<SpawnerAuthoring>
        {
            public override void Bake(SpawnerAuthoring authoring)
            {
                // 这个entity对应SpawnerAuthoring脚本所在物体，用于添加Spawner
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent<Spawner>(entity, new Spawner()
                {
                    // 这个PrefabEntity用于复制
                    PrefabEntity = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                });
            }
        }
    }
    
    struct Spawner : IComponentData
    {
        public Entity PrefabEntity;
    }
}