using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeTurnState : MonoBehaviour, IBikeState
{
    private Vector3 _turnDirection;
    private BikeController _bikeController;
    
    public void Handle(BikeController controller)
    {
        if (!_bikeController)
        {
            _bikeController = controller;
        }

        _turnDirection.x = (float)_bikeController.CurrentTurnDirection;

        if (_bikeController.CurrentSpeed > 0)
        {
            transform.Translate(_turnDirection * _bikeController.turnDistance);
        }
    }
}
