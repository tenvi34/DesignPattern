using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommandPattern;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _replayTime;
    private float _recordingTime;
    private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

    public void ExecuteCommand(Command command)
    {
        command.Execute();

        if (_isRecording)
        {
            _recordedCommands.Add(_recordingTime, command);
        }

        Debug.Log("Recorded Time: " + _recordingTime);
        Debug.Log("Recorded Command: " + command);
    }

    public void Record()
    {
        _recordingTime = 0.0f;
        _isRecording = true;
    }

    public void Replay()
    {
        _replayTime = 0.0f;
        _isReplaying = true;
        
        if (_recordedCommands.Count <= 0)
        {
            Debug.Log("No commands to replay!");
        }
    }

    private void FixedUpdate()
    {
        // 녹화가 시작되면
        if (_isRecording)
        {
            // FixedUpdate() 함수가 호출될 때마다 녹화 시간을 증가시킨다.
            _recordingTime += Time.fixedDeltaTime;
        }

        // 리플레이 영상이 재생중이면
        if (_isReplaying)
        {
            // 재생 시간이 매 프레임마다 증가한다.
            _replayTime += Time.deltaTime;

            if (_recordedCommands.Any())
            {
                // _replayTime이 Keys[0](첫번째로 녹화된 시간)과 거의 같은지 확인 후
                if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                {
                    Debug.Log("Replay Time: " + _replayTime);
                    Debug.Log("Replay Command: " + _recordedCommands.Values[0]);
                    
                    // Execute() 함수를 호출하고, 실행된 Command를 삭제한다.
                    // TurnLeft 객체가 전달되면 TurnLeft 클래스의 Execute() 메서드가 호출되고,
                    // TurnRight 객체가 전달되면 TurnRight 클래스의 Execute() 메서드가 호출된다.
                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }
            }
        }
        else
        {
            _isReplaying = false;
        }
    }
}
