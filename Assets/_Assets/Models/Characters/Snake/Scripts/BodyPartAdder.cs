using FreakySnake;
using System.Collections;
using FreakySnake.Control;
using UnityEngine;

public class BodyPartAdder : MonoBehaviour
{
	// [SerializeField] private int textMesh;

	[SerializeField]
	private MeshCollider meshCollider;

	private int bodyPartNumber;

	private bool isHitPlayer;

	public void InitValues(int number)
	{
		bodyPartNumber = number;
		isHitPlayer = false;
	}

	public int GetAddedBodyPart()
	{
		return bodyPartNumber;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// isHitPlayer = true;
			meshCollider.enabled = false;
			
			// textMesh.gameObject.SetActive(value: false);
			for (int i = 0; i < bodyPartNumber; i++)
			{
				SnakeController.Instance.AddBodyPart();
			}
			// StartCoroutine(CRScaleDown());
			// SnakeController.Instance.ScaleAllBodies();
			// ServicesManager.Instance.SoundManager.PlayOneSound(ServicesManager.Instance.SoundManager.collectBody);
		}
		// else if (other.CompareTag("Respawn"))
		// {
		// 	gameObject.SetActive(value: false);
		// }
	}

	private IEnumerator CRScaleDown()
	{
		float t = 0f;
		Vector3 startScale = base.transform.localScale;
		Vector3 endScale = Vector3.zero;
		while (t < 0.15f)
		{
			t += Time.deltaTime;
			float t2 = t / 0.15f;
			base.transform.localScale = Vector3.Lerp(startScale, endScale, t2);
			yield return null;
		}
		// textMesh.gameObject.SetActive(value: true);
		meshCollider.enabled = true;
		transform.localScale = Vector3.one;
		gameObject.SetActive(value: false);
	}
}
