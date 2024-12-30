using System;
using System.Collections.Generic;
using UnityEngine;

namespace VisitorPattern
{
    public class BikeController : MonoBehaviour, IBikeElement
    {
        private List<IBikeElement> _bikeElements = new List<IBikeElement>();

        private void Start()
        {
            _bikeElements.Add(gameObject.AddComponent<BikeEngine>());
            _bikeElements.Add(gameObject.AddComponent<BikeShield>());
            _bikeElements.Add(gameObject.AddComponent<BikeWeapon>());
        }

        public void Accept(IVisitor visitor)
        {
            foreach (IBikeElement element in _bikeElements)
            {
                element.Accept(visitor);
            }
        }
    }
}