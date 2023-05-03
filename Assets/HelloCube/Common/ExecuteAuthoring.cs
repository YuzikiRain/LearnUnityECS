using Unity.Entities;
using UnityEngine;

namespace HelloCube.Execute
{
    /// <summary>
    /// 用于控制哪些System会被执行（否则所有System都会被执行）
    /// </summary>
    public class ExecuteAuthoring : MonoBehaviour
    {
        public bool MainThread;
        public bool JobEntity;
        public bool Aspects;
        public bool Prefabs;

        class Baker : Baker<ExecuteAuthoring>
        {
            public override void Bake(ExecuteAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);

                if (authoring.MainThread) AddComponent<MainThread>(entity);
                if (authoring.JobEntity) AddComponent<JobEntity>(entity);
                if (authoring.Aspects) AddComponent<Aspects>(entity);
                if (authoring.Prefabs) AddComponent<Prefabs>(entity);
            }
        }
    }

    public struct MainThread : IComponentData
    {
    }

    public struct JobEntity : IComponentData
    {
    }
    
    public struct Aspects : IComponentData
    {
    }
    
    public struct Prefabs : IComponentData
    {
    }
}
