using System.Collections;
using System.Collections.Generic;
using FreakySnake;
using UnityEngine;

namespace FreakySnake.Inventories
{
    public class ItemDropper : MonoBehaviour
    {
        protected virtual Vector3 GetDropLocation()
        {
            return transform.position;
        }

        public void SpawnPickup(InventoryItem item, Vector3 spawnLocation, int quantity)
        {
            item.SpawnPickup(spawnLocation, quantity);
        }

        public void DropItem(InventoryItem item, int quantity)
        {
            SpawnPickup(item, GetDropLocation(), quantity);
        }

        public void DropItem(InventoryItem item)
        {
            SpawnPickup(item, GetDropLocation(), 1);
        }
    }
}

