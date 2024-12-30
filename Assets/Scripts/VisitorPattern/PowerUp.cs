using UnityEngine;

namespace VisitorPattern
{
    [CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
    public class PowerUp : ScriptableObject, IVisitor
    {
        public string powerUpName;
        public GameObject powerUpPrefab;
        public string powerUpDescription;
        
        [Tooltip("Fully heal Shield")]
        public bool healShield;
        
        [Range(0.0f, 50f)]
        [Tooltip("Boost turbo settings up to increments of 50/mph")]
        public float turboBoost;

        [Range(0.0f, 25f)] 
        [Tooltip("Boost weapon range in increments of up to 25 units")]
        public float weaponRange;
        
        [Range(0.0f, 50f)]
        [Tooltip("Boost weapon strength in increments of up to 50%")]
        public float weaponStrength;
        
        public void Visit(BikeShield bikeShield)
        {
            if (healShield) bikeShield.health = 100.0f;
        }

        public void Visit(BikeEngine bikeEngine)
        {
            
        }

        public void Visit(BikeWeapon bikeWeapon)
        {
            
        }
    }
}