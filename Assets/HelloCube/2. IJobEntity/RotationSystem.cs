using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace HelloCube.JobEntity
{
    public partial struct RotationSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState systemState)
        {
            systemState.RequireForUpdate<Execute.JobEntity>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState systemState)
        {
            var job = new RotationJob() {deltaTime = SystemAPI.Time.DeltaTime};
            job.ScheduleParallel();
        }
    }

    partial struct RotationJob : IJobEntity
    {
        public float deltaTime;

        void Execute(ref LocalTransform transform, in RotationSpeed speed)
        {
            transform = transform.RotateY(speed.RadiansPerSecond * deltaTime);
        }
    }
}