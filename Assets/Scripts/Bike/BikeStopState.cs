using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;

public class BikeStopState : MonoBehaviour, IBikeState
{
    private BikeController _bikeController;

    public void Handle(BikeController controller)
    {
        if (!_bikeController)
        {
            _bikeController = controller;
        }

        _bikeController.CurrentSpeed = 0;
    }
}
