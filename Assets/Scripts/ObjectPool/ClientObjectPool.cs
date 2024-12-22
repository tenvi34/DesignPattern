using System;
using UnityEngine;

namespace ObjectPool
{
    public class ClientObjectPool : MonoBehaviour
    {
        private DroneObjectPool _pool;

        private void Start()
        {
            _pool = gameObject.AddComponent<DroneObjectPool>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Spawn Drone"))
            {
                _pool.Spawn();
            }
        }
    }
}
