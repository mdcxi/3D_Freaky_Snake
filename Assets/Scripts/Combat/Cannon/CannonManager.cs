using System.Collections.Generic;
using FreakySnake.Abilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FreakySnake.Combat
{
	[DefaultExecutionOrder(10)]
	public class CannonManager : MonoBehaviour
	{
		public List<CannonBehaviour> _cannons = new List<CannonBehaviour>();
		public List<CannonBehaviour> _selectedCannonsToChangeDirection = new List<CannonBehaviour>();
		public List<CannonBehaviour> _selectedCannonToUpgrade = new List<CannonBehaviour>();
		
		private int _cannonAmount;
		private CannonBehaviour _cannon;
		private CannonModificationEffect _cannonModification;
		
		private void Start()
		{
			FindCannons();
			_cannonAmount = _cannons.Count;
			ChangeDetectRadiusInEachCannon();
			SelectRandomCannonsToChangeShootingType();
		}

		private void FindCannons()
		{
			_cannons.AddRange(FindObjectsOfType<CannonBehaviour>());
		}

		/// <summary>
		/// Chọn ngẫu nhiên 3 cannons từ danh sách các cannons hiện có,
		/// và thay đổi kiểu bắn của chúng thành "curve".
		/// </summary>
		private void SelectRandomCannonsToChangeShootingType()
		{
			if (_cannonAmount < 3)
			{
				Debug.Log("Not enough cannons to change");
				return;
			}
			
			var availableCannonIndices = new List<int>(_cannonAmount);
			
			for (var i = 0; i < _cannonAmount; i++)
			{
				//Khởi tạo 1 danh sách cannons dựa trên _cannons hiện có
				//Lí do phải tạo mới danh sách availableCannonIndices
				//vì việc xoá chỉ dưới đây số sẽ ảnh hưởng đến danh sách _cannons 
				availableCannonIndices.Add(i);
			}
			
			var cannonsToSelect = Mathf.Min(3, _cannonAmount);
			for (var i = 0; i < cannonsToSelect; i++)
			{
				var randomIndex = Random.Range(0, availableCannonIndices.Count);
				var selectedIndex = availableCannonIndices[randomIndex];
				
				//Xóa chỉ số selectedIndex khỏi danh sách availableCannonIndices
				//để không chọn lại cannon đó trong các lượt chọn tiếp theo.
				availableCannonIndices.RemoveAt(randomIndex); 
				
				//Lấy cannon đã chọn thông qua chỉ số selectedIndex
				//thay đổi bullet ShootingType thành "curve"
				var selectedCannon = _cannons[selectedIndex];
				// selectedCannon.bulletManager.ChangeShootingType(ShootingType.ShootingTypes.Curve);
				selectedCannon.bulletManager.ChangeShootingType(ShootingType.ShootingTypes.Curve);
				_selectedCannonsToChangeDirection.Add(selectedCannon);
			}
		}

		public void SelectARandomCannonToUpgrade(Bullet newBullet)
		{
			if (_cannonAmount < 1)
			{
				Debug.Log("Not enough cannons to upgrade");
				return;
			}

			var randomIndex = Random.Range(0, _cannonAmount);
			var selectedCannon = _cannons[randomIndex];
			
			var newColor = selectedCannon.canon.GetComponent<Renderer>();
			var material = newColor.material;
			material.color = Color.blue; // Thay đổi thành màu mới tùy ý
			
			selectedCannon.bulletPrefab = newBullet;
			_selectedCannonToUpgrade.Add(selectedCannon); // Lưu cannon đã chọn vào danh sách các Cannons đã được nâng cấp
		}

		private void ChangeDetectRadiusInEachCannon()
		{
			for (int i = _cannonAmount - 1; i > 0; i--)
			{
				int newDetectRadius = (i - 1) + Random.Range(1,3);
				_cannons[i].UpdateDetectRadius(newDetectRadius);
			}
		}
		
		public void ChangeNewBulletInEachCannon (Bullet newBullet)
		{
			foreach (var cannon in _cannons)
			{
				cannon.bulletPrefab = newBullet;
			}
		}
	}
}

