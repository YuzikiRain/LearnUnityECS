using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace HelloCube
{
    public class RotationSpeedAuthoring : MonoBehaviour
    {
        public float DegreesPerSecond = 360.0f;

        public class Baker : Baker<RotationSpeedAuthoring>
        {
            public override void Bake(RotationSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var component = new RotationSpeed() {RadiansPerSecond = math.radians(authoring.DegreesPerSecond)};

                // 过时了，用下一种方法
                // AddComponent(component);
                AddComponent(entity, component);
            }
        }
    }

    struct RotationSpeed : IComponentData
    {
        public float RadiansPerSecond;
    }
}