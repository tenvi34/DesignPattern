﻿using UnityEngine;

namespace ObserverPattern
{
    public abstract class Observer : MonoBehaviour
    {
        public abstract void Notify(Subject subject);
    }
}