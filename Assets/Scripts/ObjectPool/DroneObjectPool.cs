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
        
        private Drone CreatePooledItem()
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Drone drone = go.AddComponent<Drone>();

            go.name = "Drone";
            drone.Pool = Pool;

            return drone;
        }
        
        private void OnTakeFromPool(Drone drone)
        {
            drone.gameObject.SetActive(true);
        }

        private void OnReturnedToPool(Drone drone)
        {
            drone.gameObject.SetActive(false);
        }
        
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