using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace DefaultNamespace
{
    public class ZombieMono : MonoBehaviour
    {
        public float RiseRate;
    }

    
    public class ZombieBaker : Baker<ZombieMono>
    {
        public override void Bake(ZombieMono authoring)
        {
            AddComponent(new ZombieRiseRate() { Value = authoring.RiseRate });
        }
    }
    
}