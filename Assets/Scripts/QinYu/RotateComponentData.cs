using Unity.Entities;
using UnityEngine;

public struct RotateComponentData : IComponentData
{
    public float RotateSpeed;
    public float MoveSpeed;
}

public class RotateCubeMono : MonoBehaviour
{
    public float RotateSpeed = 360f;

    class Baker : Baker<RotateCubeMono>
    {
        public override void Bake(RotateCubeMono authoring)
        {
            AddComponent(new RotateComponentData()
            {
                RotateSpeed = authoring.RotateSpeed,
            });
        }
    }
}