using System.Collections;
using System.Collections.Generic;
using Bike;
using UnityEngine;

// 오토바이의 현재 상태를 가리키는 public 속성을 노출시켜 모든 상태 변경 인식
public class BikeStateContext : MonoBehaviour
{
    public IBikeState CurrentState
    {
        get;
        set;
    }
    
    private readonly BikeController _bikeController;

    public BikeStateContext(BikeController bikeController)
    {
        _bikeController = bikeController;
    }

    public void Transition()
    {
        CurrentState.Handle(_bikeController);
    }

    public void Transition(IBikeState state)
    {
        CurrentState = state;
        CurrentState.Handle(_bikeController);
    }
}
