using System.Collections.Generic;
using UnityEngine;

namespace Project_Files.Scripts.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
    public class WeaponInfo : ScriptableObject
    {
        public string weaponName;
        
        public int damage;
        public int fireRate;
        public int magazineSize;
        public int maxAmmo;
        public int startingAmmo;
        
        public float maxRange;
        
        public float reloadTime;
        public float adsTime;
        
        public float xRecoilMultiplier;
        public float yRecoilMultiplier;

        public float xRecoilRecovery;
        public float yRecoilRecovery;
        
        public float bulletSpread;
        
        public List<ReloadState> reloadStates;
        public List<ReloadState> emptyReloadStates;

        public AudioClip shotSound;

        public AmmunitionInfo ammo;

    }
}
