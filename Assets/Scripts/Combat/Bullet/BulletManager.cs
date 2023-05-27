using UnityEngine;

namespace FreakySnake.Combat
{
    public class BulletManager : SingletonMonobehaviour<BulletManager>
    {
        private CannonBehaviour _cannonBehaviour;
        private ShootingType.ShootingTypes CurrentShootingType { get; set; }

        private void Start()
        {
            CurrentShootingType = ShootingType.ShootingTypes.Straight;
        }

        public void ChangeShootingType(ShootingType.ShootingTypes newShootingType)
        {
            CurrentShootingType = newShootingType;
        }
        
        public ShootingType.ShootingTypes GetCurrentShootingType()
        {
            return CurrentShootingType;
        }
    }
}

