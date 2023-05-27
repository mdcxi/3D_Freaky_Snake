using FreakySnake.Enemies;
using Lean.Pool;
using UnityEngine;

namespace FreakySnake.Combat
{
    public class CannonBehaviour : MonoBehaviour
    {
        public Bullet bulletPrefab;
        public Transform canon;
        [SerializeField] private Transform pivotToShoot; 
        [SerializeField] private int bulletShootPerSeconds = 1;

        [Space(2)]
        [Header("Detect Config")]
        public Vector3 center;
        public float detectRadius;
        
        private Transform _target;
        private float _shootingTimeCountdown = 0f; //Count down the time until the cannon can be shot again.
        [HideInInspector] public BulletManager bulletManager;

        private void Awake()
        {
            bulletManager = BulletManager.Instance;
        }
        
        private void Update()
        {
            FindClosetTarget();
            Aim();
        }

        private void FindClosetTarget()
        {
            Transform closestTarget = null;
            var maxDistance = Mathf.Infinity;
            
            var slimes = FindObjectsOfType<SlimeBehaviour>();
         
            foreach (var slime in slimes)
            {
                var targetDistance = Vector3.Distance(transform.position, slime.transform.position);
        
                if (targetDistance < maxDistance)
                {
                    closestTarget = slime.transform;
                    maxDistance = targetDistance;
                }
            }
        
            _target = closestTarget;
        }
    
  
        private void Aim()
        {
            var colliders = Physics.OverlapSphere(transform.position, detectRadius);
            var hasDetectedEnemy = false;
            
            foreach (var col in colliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    DirectToTarget();

                    if (!hasDetectedEnemy && _shootingTimeCountdown <= 0f)
                    {
                        Shoot();
                        _shootingTimeCountdown = 1 / bulletShootPerSeconds;
                        hasDetectedEnemy = true;
                    }
                }
            }

            _shootingTimeCountdown -= Time.deltaTime;
        }
        
        private void DirectToTarget()
        {
            if (_target == null) return;
            
            var direction = _target.position - canon.position;
            direction.y = 0;
            var targetRotation = Quaternion.LookRotation(direction, direction);
            canon.rotation = targetRotation;
        }
        
        private void Shoot()
        {
            var instance = LeanPool.Spawn(bulletPrefab, pivotToShoot.position, pivotToShoot.rotation);
            var bullet = instance.GetComponent<Bullet>();

            if (bullet != null)
            {
                bullet.AssignTarget(_target);
            }
        }
        
        public void UpdateDetectRadius(float newDetectRadius)
        {
            detectRadius = newDetectRadius;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + center, detectRadius);
        }
#endif
    }
}

