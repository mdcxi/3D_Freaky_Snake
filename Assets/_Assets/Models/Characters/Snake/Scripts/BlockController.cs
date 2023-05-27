using FreakySnake;
using UnityEngine;

public class BlockController : MonoBehaviour
{
	// [Header("References")]
	// [SerializeField]
	// private MeshRenderer meshRender;

	// [SerializeField]
	// private TextMesh textMesh;

	[SerializeField]
	private BlockType blockType;

	private int _currentBrokenNumber;

	// public void InitValues(int blockNumber)
	// {
	// 	_currentBrokenNumber = blockNumber;
	// 	textMesh.text = _currentBrokenNumber.ToString();
	// }

	public BlockType GetBlockType()
	{
		return blockType;
	}

	// public void CountDownBrokenNumber()
	// {
	// 	_currentBrokenNumber--;
	// 	ServicesManager.Instance.ScoreManager.AddCurrentScore(1);
	// 	textMesh.text = _currentBrokenNumber.ToString();
	// 	if (_currentBrokenNumber <= 0)
	// 	{
	// 		Explode();
	// 	}
	// }
	//
	// private void OnTriggerEnter(Collider other)
	// {
	// 	if (other.CompareTag("Respawn"))
	// 	{
	// 		base.gameObject.SetActive(value: false);
	// 	}
	// }

	// public void Explode()
	// {
	// 	ServicesManager.Instance.SoundManager.PlayOneSound(ServicesManager.Instance.SoundManager.destroyBlock);
	// 	gameObject.SetActive(value: false);
	// 	// EffectManager.Instance.CreateBlockExplode(blockType, base.transform.position);
	// 	Vector3 pos = base.transform.position + Vector3.up * (meshRender.bounds.size.y + 0.1f);
	// 	IngameManager.Instance.CreateFadingText(pos, blockType);
	// }
}
