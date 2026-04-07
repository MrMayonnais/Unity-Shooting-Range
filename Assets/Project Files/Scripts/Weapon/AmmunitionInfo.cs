using UnityEngine;

namespace Project_Files.Scripts.Weapon
{
    [CreateAssetMenu(fileName = "AmmunitionInfo", menuName = "Scriptable Objects/AmmunitionInfo")]
    public class AmmunitionInfo : ScriptableObject
    {
        public string ammunitionName;

        public int projectileAmount;
        
        public float muzzleVelocity;
        public float penetration;
    }
}
