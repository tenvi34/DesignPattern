using UnityEngine;

namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        private Invoker _invoker;
        private bool _isRecording;
        private bool _isReplaying;
        private BikeController _bikeController;
        private Command _buttonA, _buttonD, _buttonW;
    
        private void Start()
        {
            _invoker = gameObject.AddComponent<Invoker>();
            _bikeController = FindObjectOfType<BikeController>();
    
            _buttonA = new TurnLeft(_bikeController);
            _buttonD = new TurnRight(_bikeController);
            _buttonW = new ToggleTurbo(_bikeController);
        }
    
        private void Update()
        {
            // 녹화중이면
            if (!_isReplaying && _isRecording)
            {
                // 입력한 키에 따라 명령을 실행한다.
                if (Input.GetKeyUp(KeyCode.A)) _invoker.ExecuteCommand(_buttonA);
                if (Input.GetKeyUp(KeyCode.D)) _invoker.ExecuteCommand(_buttonD);
                if (Input.GetKeyUp(KeyCode.W)) _invoker.ExecuteCommand(_buttonW);
            }
        }
        
        void OnGUI()
        {
            if (GUILayout.Button("Start Recording"))
            {
                Debug.Log("Start Recording");
                _bikeController.ResetPosition();
                _isReplaying = false;
                _isRecording = true;
                _invoker.Record();
            }
        
            if (GUILayout.Button("Stop Recording"))
            {
                Debug.Log("Stop Recording");
                _bikeController.ResetPosition();
                _isRecording = false;
            }
    
            if (!_isRecording)
            {
                if (GUILayout.Button("Start Replay"))
                {
                    Debug.Log("Start Replay");
                    _bikeController.ResetPosition();
                    _isRecording = false;
                    _isReplaying = true;
                    _invoker.Replay();
                }
            }
        }
    }
}