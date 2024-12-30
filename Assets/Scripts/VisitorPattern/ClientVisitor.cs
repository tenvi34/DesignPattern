using System;
using UnityEngine;

namespace VisitorPattern
{
    public class ClientVisitor : MonoBehaviour
    {
        public PowerUp enginePowerUp;
        public PowerUp shieldPowerUp;
        public PowerUp weaponPowerUp;
        
        private BikeController _bikeController;

        private void Start()
        {
            _bikeController = gameObject.AddComponent<BikeController>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Engine Power Up"))
            {
                _bikeController.Accept(enginePowerUp);
            }
            
            if (GUILayout.Button("Shield Power Up"))
            {
                _bikeController.Accept(shieldPowerUp);
            }
            
            if (GUILayout.Button("Weapon Power Up"))
            {
                _bikeController.Accept(weaponPowerUp);
            }
        }
    }
}