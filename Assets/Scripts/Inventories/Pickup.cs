using FreakySnake.Abilities;
using Lean.Pool;
using UnityEngine;

namespace FreakySnake.Inventories
{
    public class Pickup : MonoBehaviour
    {
        public Ability item;
        
        public void PickupItem()
        {
            LeanPool.Despawn(gameObject);
            // Destroy(gameObject);
        }
    }
}

