using UnityEngine;

namespace Bike
{
    public class CilentEventBus : MonoBehaviour
    {
        private bool _isButtonEnabled;
    
        void Start()
        {
            gameObject.AddComponent<HUDController>();
            gameObject.AddComponent<CountdownTimer>();
            gameObject.AddComponent<BikeController>();
        }

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.STOP, Restart);
        }

        private void OnDisable()
        {
            RaceEventBus.UnSubscribe(RaceEventType.STOP, Restart);
        }

        private void Restart()
        {
            _isButtonEnabled = true;
        }

        private void OnGUI()
        {
            if (_isButtonEnabled)
            {
                if (GUILayout.Button("Start Countdown"))
                {
                    _isButtonEnabled = false;
                    RaceEventBus.Publish(RaceEventType.COUNTDOWN);
                }
            }
        }
    }
}