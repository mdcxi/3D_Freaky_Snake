using FreakySnake.DamageSystem;
using Lean.Pool;
using UnityEngine;

namespace FreakySnake.Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletData bulletData; 
        
        private Transform _target;
        private float _startTime, _passingTime;
        private Rigidbody _rigidbody;
        private BulletManager _bulletManager;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _startTime = Time.time;
        }

        public void AssignTarget (Transform target)
        {
            _target = target;
        }

        private void Update()
        {
            _passingTime = Time.time - _startTime;
            
            if (_target == null)
            {
                LeanPool.Despawn(gameObject);
                return;
            }
          
            var direction = _target.position - transform.position;
            
            //the distance bullet moves in one frame.
            //this calculation ensures that the movement speed of the bullet remains consistent in all situations.
            var distanceInEachFrame = bulletData.bulletSpeed * Time.deltaTime; 
            
           //if the length of the direction vector is less than or equal to the distance the bullet has reached the target
            if (direction.magnitude <= distanceInEachFrame) 
            {
                HitTarget();
                return;
            }

            if (BulletManager.Instance.GetCurrentShootingType() == ShootingType.ShootingTypes.Straight)
            {
                transform.Translate(direction.normalized * distanceInEachFrame, Space.World);
                transform.LookAt(_target);
            }
            else
            {
                ApplyCurveTrajectory();
            }
        }

        private void ApplyCurveTrajectory()
        {
            var direction = _target.position - transform.position;
            direction.Normalize();
            var rotateAmount = Vector3.Cross(direction, transform.forward);
            _rigidbody.angularVelocity = -rotateAmount * bulletData.rotationSpeed;
            _rigidbody.velocity = transform.forward * bulletData.bulletSpeed;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer != LayerMask.NameToLayer("Environment")) return;
            if (!(_passingTime > bulletData.bulletDestroyTime)) return;
            Explosion();
            LeanPool.Despawn(gameObject); //if collide with environment
        }

        private void HitTarget()
        {
            Explosion();
            
            ApplyDamage();
            
            LeanPool.Despawn(gameObject); //if collide with enemy
        }

        private void Explosion()
        {
            if (bulletData.explosionEffect == null) return;
            
            var explosionInstance = LeanPool.Spawn(bulletData.explosionEffect, transform.position, transform.rotation);
            LeanPool.Despawn(explosionInstance, bulletData.explosionDestroyTime); //Despawn VFX
        }

        private void ApplyDamage()
        {
            var colliders = Physics.OverlapSphere(transform.position, bulletData.detectRadius);

            if (colliders.Length <= 0) return;
            
            foreach (var c in colliders)
            {
                if (c.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    Damageable.DamageMessage message = new Damageable.DamageMessage()
                    {
                        amount = bulletData.damageAmount
                    };
                        
                    c.GetComponent<Damageable>().ApplyDamage(message);
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + bulletData.center, bulletData.detectRadius);
        }
#endif
    }
}

