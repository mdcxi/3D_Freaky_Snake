using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using FreakySnake;
using FreakySnake.Abilities;
using FreakySnake.Helpers;
using UnityEngine;

public class BodyPartController : MonoBehaviour
{
	// [SerializeField] private GameObject bodyPartAdder; 	
	// public List<BodyPartAdder> _listBodyPartAdder = new List<BodyPartAdder>();

	// private void Start()
	// {
	// 	var skinInfor = ServicesManager.Instance.SkinContainer.SkinInfors[ServicesManager.Instance.SkinContainer.SelectedSkinIndex];
	// 	bodyPartAdderPrefab.GetComponent<MeshFilter>().mesh = skinInfor.BodyMesh;
	// 	bodyPartAdderPrefab.GetComponent<MeshRenderer>().material = skinInfor.Material;
	// 	bodyPartAdderPrefab.GetComponent<MeshCollider>().sharedMesh = skinInfor.BodyMesh;
	// }

	// public void Scale(float upFactor, float scalingTime)
	// {
	// 	AnimateScale(upFactor, scalingTime).Forget();
	// }
	//

	/// <summary>
	/// Change the scale of the Snake's body parts over time
	/// </summary>
	/// <param name="upFactor"> The scaling ratio </param>
	/// <param name="scalingTime"> The duration of the scaling process </param>
	/// <returns> </returns>
	// private async UniTask AnimateScale(float upFactor, float scalingTime)
	// {
	// 	var passedTime = 0f;
	// 	
	// 	var originalScale = transform.localScale;
	// 	var endScale = originalScale * upFactor;
	// 	
	// 	while (passedTime < scalingTime)
	// 	{
	// 		passedTime += Time.deltaTime;
	// 		var percentage = passedTime / scalingTime;
	// 		transform.localScale = Vector3.Lerp(originalScale, endScale, percentage);
	// 		await UniTask.Yield();
	// 	}
	// 	
	// 	passedTime = 0f;
	// 	while (passedTime < scalingTime)
	// 	{
	// 		passedTime += Time.deltaTime;
	// 		var percentage = passedTime / scalingTime;
	// 		transform.localScale = Vector3.Lerp(endScale, originalScale, percentage);
	// 		await UniTask.Yield();
	// 	}
	// }

	// public BodyPartAdder GetBodyPartAdder()
	// {
	// 	var bodyPartAdder = (from a in _listBodyPartAdder
	// 		where !a.gameObject.activeInHierarchy
	// 		select a).FirstOrDefault();
	// 		
	// 	if (bodyPartAdder == null)
	// 	{
	// 		bodyPartAdder = Instantiate(, Vector3.zero, Quaternion.identity).GetComponent<BodyPartAdder>();
	// 		bodyPartAdder.gameObject.SetActive(false);
	// 		_listBodyPartAdder.Add(bodyPartAdder);
	// 	}
	// 	return bodyPartAdder;
	// }
}
