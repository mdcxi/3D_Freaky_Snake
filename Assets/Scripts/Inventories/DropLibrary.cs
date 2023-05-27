using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FreakySnake.Inventories
{
    [CreateAssetMenu(menuName = "Items/Drop Library")]
    public class DropLibrary : ScriptableObject
    {
        [SerializeField] private DropConfig[] potentialDrops; 
        
        [Serializable]
        class DropConfig
        {
            public InventoryItem item;
            public float dropChance;
        }
        
        public struct Dropped
        {
            public InventoryItem item;
        }
        
        /// <summary>
        /// Duyệt danh sách các phần "Dropped".
        /// Trả về kết quả vật phẩm có được drop hay không (GetDropResult),
        /// thông qua việc duyệt vòng lặp và check giá trị của ShouldDrop.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Dropped> GetRandomDrops()
        {
            foreach (var drop in potentialDrops)
            {
                if (ShouldDrop(drop))
                {
                    yield return GetDropResult(drop);
                }
            }
        }
        
        private bool ShouldDrop(DropConfig drop)
        {
            return Random.Range(0f, 1f) < drop.dropChance;
        }
        
        private Dropped GetDropResult(DropConfig drop)
        {
            var result = new Dropped();
            result.item = drop.item;
            return result;
        }
    }
}

