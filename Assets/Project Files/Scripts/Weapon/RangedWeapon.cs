using System;
using UnityEngine;

namespace Project_Files.Scripts.Weapon
{
    public class RangedWeapon : MonoBehaviour, IWeapon
    {
        public WeaponInfo currentWeapon;

        private int _currentAmmo;
        private int _currentReloadState;
        private int _currentReloadStateTimeStamp;

        private float _timeSinceLastShot = -1;

        [SerializeField] private Transform firingPoint;

        private void Start()
        {
            
        }

        public void Attack()
        {
            Debug.Log("Trying to shoot with weapon: " + currentWeapon.weaponName);
            if (Time.time - _timeSinceLastShot < RpmToTime() && _timeSinceLastShot > 0) return;
            _timeSinceLastShot = Time.time;
            Debug.Log("Weapon Shot");
            
            var cameraRay = ResourceFinder.PlayerCamera().ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
            Vector3 targetPoint;

            if(Physics.Raycast(cameraRay, out var hit))
            {
                targetPoint = hit.point;
                Debug.Log("Bullet destination: " + hit.collider.name + " at " + targetPoint);
            }
            else
            {
                targetPoint = cameraRay.origin + cameraRay.direction * currentWeapon.maxRange;
                Debug.Log("No hit, bullet destination at max range: " + targetPoint);
            }

            var weaponRay = new Ray(firingPoint.position, targetPoint - firingPoint.position);
            if (Physics.Raycast(weaponRay, out var weaponHit, currentWeapon.maxRange))
            {
                Debug.Log("Bullet hit: " + weaponHit.collider.name + " at " + weaponHit.point);
            }
            
            Debug.DrawRay(firingPoint.position, targetPoint - firingPoint.position, Color.red, 3f);
        }

        public void Reload()
        {

        }

        private int RpmToTime()
        {
            return (int)(60 / currentWeapon.fireRate * 1000);
        }
    }
}