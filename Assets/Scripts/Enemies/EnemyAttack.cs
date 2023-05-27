using FreakySnake.DamageSystem;
using UnityEngine;

namespace FreakySnake.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 10;
        [SerializeField] private Vector3 center = Vector3.zero;
        [SerializeField] private float detectRadius = 1f;
        
        public void AttackTarget()
        {
            var colliders = Physics.OverlapSphere(transform.position, detectRadius);

            if (colliders.Length <= 0) return;
            
            foreach (var c in colliders)
            {
                if (c.gameObject.CompareTag("Player"))
                {
                    Damageable.DamageMessage message = new Damageable.DamageMessage()
                    {
                        amount = damageAmount
                    };
                        
                    c.GetComponent<Damageable>().ApplyDamage(message);
                }
            }
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

