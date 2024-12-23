using System;
using UnityEngine;

namespace ObserverPattern
{
    public class BikeController : Subject
    {
        public bool IsTurboOn
        {
            get;
            private set;
        }

        public float CurrentHealth
        {
            get { return health; }
        }

        private bool _isEngineOn;
        private HUDController _hudController;
        private CameraController _cameraController;
        
        [SerializeField] private float health = 100.0f;

        private void Awake()
        {
            _hudController = gameObject.AddComponent<HUDController>();
            _cameraController = gameObject.AddComponent<CameraController>();
        }

        private void Start()
        {
            StartEngine();
        }

        private void OnEnable()
        {
            if (_hudController)
                Attach(_hudController);
            
            if (_cameraController)
                Attach(_cameraController);
        }

        private void OnDisable()
        {
            if (_hudController)
                Detach(_hudController);
            
            if (_cameraController)
                Detach(_cameraController);
        }

        // 엔진 시동
        private void StartEngine()
        {
            _isEngineOn = true;
            NotifyObservers();
        }

        // 터보 상태 전환
        public void ToggleTurbo()
        {
            if (_isEngineOn)
                IsTurboOn = !IsTurboOn;
            NotifyObservers();
        }
        
        // 데미지 입음
        public void TakeDamage(float damage)
        {
            health -= damage;
            IsTurboOn = false;
            
            NotifyObservers();
            
            if (health < 0)
                Destroy(gameObject);
        }
    }
}