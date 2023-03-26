using Unity.Entities;
using UnityEngine;

namespace QinYu
{
    public struct InstantiateCubeComponentData : IComponentData
    {
        public Entity CubePrefab;
        public int CubeCount;
    }
}