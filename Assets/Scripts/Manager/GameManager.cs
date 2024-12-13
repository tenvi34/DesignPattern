using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    void Start()
    {
        _sessionStartTime = DateTime.Now;
        Debug.Log("Game Session Start : " + DateTime.Now);
    }

    private void OnApplicationQuit()
    {
        _sessionEndTime = DateTime.Now;
        
        TimeSpan timeDiff = _sessionEndTime.Subtract(_sessionStartTime);
        
        Debug.Log("Game Session End : " + DateTime.Now);
        Debug.Log("Game Session Time Lasted: " + timeDiff);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Next Scene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
