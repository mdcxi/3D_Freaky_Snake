using UnityEngine;

namespace FreakySnake.Combat
{
    [CreateAssetMenu(menuName = "Snake/Bullet", fileName = "New Bullet")]
    public class BulletData : ScriptableObject
    {
        [Header("Bullet Config")]
        public float bulletSpeed;
        public float rotationSpeed = 200f;
        public int damageAmount;
        public float bulletDestroyTime = 3;

        [Space(2)]
        [Header("Detect Config")]
        public Vector3 center;
        public float detectRadius;

        [Space(2)]
        [Header("Explosion Effect Config")]
        public GameObject explosionEffect;
        public float explosionDestroyTime = 3;
    }
}