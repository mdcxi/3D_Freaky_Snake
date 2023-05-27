using UnityEngine;

namespace FreakySnake.Inventories
{
    [CreateAssetMenu(menuName = "Action Item")]
    public class ActionItem : InventoryItem
    {
        public virtual bool Use(GameObject user)
        {
            return false;
        }
    }
}

