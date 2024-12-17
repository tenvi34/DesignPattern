using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left = -1,
    Right = 1
}

public class BikeController : MonoBehaviour
{
    public float maxSpeed = 2.0f;
    public float turnDistance = 2.0f;

    private string _status;

    public float CurrentSpeed { get; set; }

    public Direction CurrentTurnDirection { get; private set; }

    private IBikeState _startState, _stopState, _turnState;

    private BikeStateContext _bikeStateContext;

    private void Start()
    {
        _bikeStateContext = gameObject.AddComponent<BikeStateContext>();

        _startState = gameObject.AddComponent<BikeStartState>();
        _stopState = gameObject.AddComponent<BikeStopState>();
        _turnState = gameObject.AddComponent<BikeTurnState>();

        _bikeStateContext.Transition(_stopState);
    }

    public void StartBike()
    {
        _bikeStateContext.Transition(_startState);
        _status = "Started";
    }

    public void StopBike()
    {
        _bikeStateContext.Transition(_stopState);
        _status = "Stopped";
    }

    public void Turn(Direction direction)
    {
        CurrentTurnDirection = direction;
        _bikeStateContext.Transition(_turnState);
    }

    private void OnEnable()
    {
        RaceEventBus.Subscribe(RaceEventType.START, StartBike);
        RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
    }

    private void OnDisable()
    {
        RaceEventBus.UnSubscribe(RaceEventType.START, StartBike);
        RaceEventBus.UnSubscribe(RaceEventType.STOP, StopBike);
    }

    private void OnGUI()
    {
        GUI.color = Color.green;
    }
}