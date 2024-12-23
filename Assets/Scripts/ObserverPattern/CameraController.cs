using UnityEngine;

namespace ObserverPattern
{
    public class CameraController : Observer
    {
        private bool _isTurboOn;
        private Vector3 _initialPosition;
        private float _shakeMagnitude = 0.1f;
        private BikeController _bikeController;

        void OnEnable()
        {
            _initialPosition = gameObject.transform.localPosition;
        }

        void Update()
        {
            // 터보 보드가 활성화 될때만
            if (_isTurboOn)
                gameObject.transform.localPosition = _initialPosition + (Random.insideUnitSphere * _shakeMagnitude);
            else
                gameObject.transform.localPosition = _initialPosition;
        }

        // Subject의 상태가 변경되었을 때 호출되는 메서드
        public override void Notify(Subject subject)
        {
            if (!_bikeController)
                _bikeController = subject.GetComponent<BikeController>();

            if (_bikeController)
                _isTurboOn = _bikeController.IsTurboOn;
        }
    }
}