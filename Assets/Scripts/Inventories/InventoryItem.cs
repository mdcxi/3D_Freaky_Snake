using Lean.Pool;
using UnityEngine;

namespace FreakySnake.Inventories
{
    public abstract class InventoryItem : ScriptableObject
    {
        [SerializeField] private Pickup pickup;
        
        public Pickup SpawnPickup(Vector3 position, int number)
        {
            var pickup = LeanPool.Spawn(this.pickup);
            pickup.transform.position = position;
            return pickup;
        }
    }
}

