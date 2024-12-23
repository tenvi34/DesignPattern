using UnityEngine;

namespace Bike
{
    public class HUDController : MonoBehaviour
    {
        private bool _isDisplayOn;

        private void DisplayHUD()
        {
            _isDisplayOn = true;
        }

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, DisplayHUD);
        }

        private void OnDisable()
        {
            RaceEventBus.UnSubscribe(RaceEventType.START, DisplayHUD);
        }

        private void OnGUI()
        {
            if (_isDisplayOn)
            {
                if (GUILayout.Button("Stop Race"))
                {
                    _isDisplayOn = false;
                    RaceEventBus.Publish(RaceEventType.STOP);
                }
            }
        }
    }
}
