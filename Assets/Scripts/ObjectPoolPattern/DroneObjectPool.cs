using UnityEngine;
using UnityEngine.Pool;

namespace ObjectPool
{
    public class DroneObjectPool : MonoBehaviour
    {
        public int maxPoolSize = 10;
        public int stackDefaultCapacity = 10;

        public IObjectPool<Drone> Pool
        {
            get
            {
                if (_pool == null)
                {
                    _pool = new ObjectPool<Drone>(
                        CreatePooledItem, 
                        OnTakeFromPool, 
                        OnReturnedToPool,
                        OnDestroyToPool, 
                        true, 
                        stackDefaultCapacity, 
                        maxPoolSize);
                }

                return _pool;
            }
        }
        
        private IObjectPool<Drone> _pool;
        
        // 드론 인스턴스 초기화, Pool에 드론 추가, 실제 사용할 때는 프리팹을 로드하는 방향으로 작성
        private Drone CreatePooledItem()
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Drone drone = go.AddComponent<Drone>();

            go.name = "Drone";
            drone.Pool = Pool;

            return drone;
        }
        
        // 클라이언트가 Pool에서 드론을 가져갈 때 호출, 실제로 반환되는 것이 아닌 게임 오브젝트가 활성화되는 방식
        private void OnTakeFromPool(Drone drone)
        {
            drone.gameObject.SetActive(true);
        }

        // 실제로 반환되는 것이 아닌 게임 오브젝트가 비활성화되는 방식
        private void OnReturnedToPool(Drone drone)
        {
            drone.gameObject.SetActive(false);
        }
        
        // Pool에 더이상 공간이 없을 때 호출, 반환되는 드론은 메모리 확보를 위해 파괴된다.
        private void OnDestroyToPool(Drone drone)
        {
            Destroy(drone.gameObject);
        }

        public void Spawn()
        {
            var amount = Random.Range(1, 10);

            for (int i = 0; i < amount; i++)
            {
                var drone = Pool.Get();
                drone.transform.position = Random.insideUnitSphere * 10;
            }
        }
    }
}