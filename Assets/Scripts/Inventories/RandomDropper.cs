using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace FreakySnake.Inventories
{
    public class RandomDropper : ItemDropper
    {
        [SerializeField] private DropLibrary dropLibrary;
        
        //số lần tối đa thử tìm vị trí để drop vật phẩm
        private const int MAX_DROP_LOCATION_ATTEMPTS = 30;
        
        /// <summary>
        /// Thực hiện việc drop vật phẩm dựa trên phương thức GetRandomDrops()
        /// </summary>
        public void RandomDrop()
        {
            var drop = GetRandomDrops();
            DropItem(drop.item);
        }

        /// <summary>
        /// Lấy danh sách các vật phẩm trong DropLibrary thông qua dropLibrary.GetRandomDrops(),
        /// và trả về 1 phần tử ngẫu nhiên "Dropped" duy nhất (tránh 1 enemy drop nhiều vật phẩm)
        /// </summary>
        /// <returns></returns>
        private DropLibrary.Dropped GetRandomDrops()
        {
            var drops = dropLibrary.GetRandomDrops();
            var count = drops.Count();
            
            if (count > 0)
            {
                var randomIndex = Random.Range(0, count);
                return drops.ElementAt(randomIndex);
            }
            
            return new DropLibrary.Dropped();
        }
        
        /// <summary>
        /// Lấy vị trí để drop vật phẩm
        /// </summary>
        /// <returns></returns>
        protected override Vector3 GetDropLocation()
        {
            for (int i = 0; i < MAX_DROP_LOCATION_ATTEMPTS; i++)
            {
                Vector3 randomPoint = transform.position + Random.insideUnitSphere;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 0.1f, NavMesh.AllAreas))
                {
                    return hit.position;
                }
            }
            return transform.position;
        }
    }
}

