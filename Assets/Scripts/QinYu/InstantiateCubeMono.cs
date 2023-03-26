using UnityEngine;

namespace QinYu
{
    class InstantiateCubeMono : MonoBehaviour
    {
        public GameObject CubePrefab;
        public int CubeCount;
        
             public   class Baker : Baker<InstantiateCubeMono>
                {
                    public override void Bake(InstantiateCubeMono authoring)
                    {
                        AddComponent(new InstantiateCubeComponentData()
                        {
                            CubePrefab = GetEntity(authoring.CubePrefab),
                            CubeCount = authoring.CubeCount,
                        });
                    }
                }
    }
}