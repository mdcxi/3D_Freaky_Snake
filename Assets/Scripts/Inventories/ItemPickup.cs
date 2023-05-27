using UnityEngine;

namespace FreakySnake.Inventories
{
    public class ItemPickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Item"))
            {
                var item = other.GetComponent<Pickup>().item;
                Debug.Log(item);
                item.Use(gameObject);
                other.GetComponent<Pickup>().PickupItem();
            }
        }
    }
}

