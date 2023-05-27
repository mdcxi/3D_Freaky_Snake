using UnityEngine;

public class PlayingViewController : MonoBehaviour
{
	[SerializeField]
	private GameObject btnUnPauseView;
	[SerializeField]
	private GameObject btnPauseView;

	public void OnShow()
	{
		btnUnPauseView.SetActive(false);
	}

	public void PauseBtn()
	{
		btnUnPauseView.SetActive(true);
		btnPauseView.SetActive(false);
		IngameManager.Instance.PauseGame();
	}

	public void UnPauseBtn()
	{
		btnUnPauseView.SetActive(false);
		btnPauseView.SetActive(true);
		IngameManager.Instance.UnPauseGame();
	}
}
