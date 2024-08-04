using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;

public class BikeTurnState : MonoBehaviour, IBikeState
{
    private BikeController _bikeController;
    private Vector3 _turnDirection;

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
