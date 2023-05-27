using System.Collections.Generic;
using System.Linq;
using Lean.Pool;
using UnityEngine;

namespace FreakySnake.Helpers
{
	public class BodyPartsManager : SingletonMonobehaviour<BodyPartsManager>
	{
		[SerializeField] private GameObject bodyPartPrefab;
		private readonly List<BodyPartController> _listBodyPartControl = new List<BodyPartController>();
		private BodyPartController _lastShotBodyPart;

		private void Start()
		{
			var skinInfor = ServicesManager.Instance.SkinContainer.SkinInfors[ServicesManager.Instance.SkinContainer.SelectedSkinIndex];
		
			bodyPartPrefab.GetComponent<MeshFilter>().mesh = skinInfor.BodyMesh;
			bodyPartPrefab.GetComponent<MeshRenderer>().material = skinInfor.Material;
			bodyPartPrefab.transform.GetChild(0).GetComponent<MeshFilter>().mesh = skinInfor.BodyMesh;
		}

		public BodyPartController GetBodyPart()
		{
			//using LINQ to find the first element in the list listBodyPartControl that is not activated
			var bodyPartController = (from a in _listBodyPartControl
				where !a.gameObject.activeInHierarchy
				select a).FirstOrDefault();
		
			if (bodyPartController == null)
			{
				bodyPartController = LeanPool.Spawn(bodyPartPrefab, Vector3.zero, Quaternion.identity)
					.GetComponent<BodyPartController>();
				_listBodyPartControl.Add(bodyPartController);
				bodyPartController.gameObject.SetActive(false);
			}
		
			return bodyPartController;
		}
		

	}
}

