using Project_Files.Scripts.Player.Input;
using Project_Files.Scripts.Weapon;
using UnityEngine;

namespace Project_Files.Scripts.Player
{
    public class PlayerWeaponManager : MonoBehaviour
    {
        private IWeapon[] _weapons = new IWeapon[3];
        private int _currentWeaponIndex = 0;

        [SerializeField] private GameObject weaponContainer;
    
        private void Start()
        {
            _weapons[0] = weaponContainer.transform.GetChild(0)?.GetComponent<IWeapon>();
            _weapons[1] = weaponContainer.transform.GetChild(1)?.GetComponent<IWeapon>();
            _weapons[2] = weaponContainer.transform.GetChild(2)?.GetComponent<IWeapon>();
        }
        
        private void OnEnable()
        {
            PlayerInputEvents.OnFireInput += TryShoot;
            PlayerInputEvents.OnReloadInput += TryReload;
        }
        
        private void OnDisable()
        {
            PlayerInputEvents.OnFireInput -= TryShoot;
            PlayerInputEvents.OnReloadInput -= TryReload;
        }
        
        private void TryShoot(bool performed)
        {
            if (performed) _weapons[_currentWeaponIndex].Attack();
        }
        
        private void TryReload(bool performed)
        {
            if (performed && _weapons[_currentWeaponIndex] is RangedWeapon rangedWeapon)
            {
                rangedWeapon.Reload();
            }
        }
    }
}
