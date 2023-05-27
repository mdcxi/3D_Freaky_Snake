using FreakySnake;
using System.Collections;
using UnityEngine;

public class ItemController : MonoBehaviour
{
	[Header("Item Config")]
	[SerializeField]
	private float minRotatingSpeed = 150f;

	[SerializeField]
	private float maxRotatingSpeed = 350f;

	[Header("Item References")]
	[SerializeField]
	private MeshRenderer meshRender;

	[SerializeField]
	private ItemType itemType;

	private float rotatingSpeed;

	// private bool isHitPlayer;

	public void InitValues()
	{
		// rotatingSpeed = Random.Range(minRotatingSpeed, maxRotatingSpeed);
		// isHitPlayer = false;
		// if (itemType == ItemType.COIN)
		// {
		// 	StartCoroutine(CRWaitForMagnetMode());
		// }
	}

	private void Update()
	{
		transform.eulerAngles += Vector3.up * rotatingSpeed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		// if (other.CompareTag("Player") && !isHitPlayer)
		// {
			// isHitPlayer = true;
			// Vector3 pos = base.transform.position + Vector3.up * meshRender.bounds.size.y;
			// if (itemType == ItemType.COIN)
			// {
			// 	ServicesManager.Instance.SoundManager.PlayOneSound(ServicesManager.Instance.SoundManager.collectCoin);
			// 	ServicesManager.Instance.CoinManager.AddCollectedCoins(1);
			// 	// EffectManager.Instance.CreateCoinCollectEffect(pos);
			// }
			// else if (itemType == ItemType.SHIELD)
			// {
			// 	ServicesManager.Instance.SoundManager.PlayOneSound(ServicesManager.Instance.SoundManager.enableShield);
			// 	EffectManager.Instance.CreateShieldCollectEffect(pos);
			// 	if (!SnakeController.Instance.IsImmortal)
			// 	{
			// 		SnakeController.Instance.EnableAllShields();
			// 	}
			// }
			// else if (itemType == ItemType.MAGNET)
			// {
			// 	ServicesManager.Instance.SoundManager.PlayOneSound(ServicesManager.Instance.SoundManager.enableMagnetMode);
			// 	if (!SnakeController.Instance.IsOnMagnetMode)
			// 	{
			// 		SnakeController.Instance.SetMagetMode(isActive: true);
			// 	}
			// }
		// 	base.gameObject.SetActive(value: false);
		// }
		// else if (other.CompareTag("Respawn"))
		// {
		// 	base.gameObject.SetActive(value: false);
		}
	// }

	// private IEnumerator CRWaitForMagnetMode()
	// {
		// yield return null;
		// while (!SnakeController.Instance.IsOnMagnetMode || !(base.transform.position.z > SnakeController.Instance.transform.position.z) || !(Vector3.Distance(base.transform.position, SnakeController.Instance.transform.position) <= 20f))
		// {
		// 	yield return null;
		// }
		// base.transform.SetParent(null);
		// while (true)
		// {
		// 	Vector3 normalized = (SnakeController.Instance.transform.position - base.transform.position).normalized;
		// 	base.transform.position += normalized * 50f * Time.deltaTime;
		// 	yield return null;
		// }
	// }
}
