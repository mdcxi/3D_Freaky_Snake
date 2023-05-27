using FreakySnake.Helpers;
using UnityEngine;

public class IngameViewController : MonoBehaviour
{
	[SerializeField]
	private PlayingViewController playingViewControl;

	[SerializeField]
	private ReviveViewController reviveViewControl;

	[SerializeField]
	private GameOverViewController gameOverViewControl;

	// public PlayingViewController PlayingViewController => playingViewControl;

	public void OnShow()
	{
		IngameManager.GameStateChanged += GameManager_GameStateChanged;
	}

	private void OnDisable()
	{
		IngameManager.GameStateChanged -= GameManager_GameStateChanged;
	}

	private void GameManager_GameStateChanged(IngameState obj)
	{
		switch (obj)
		{
		case IngameState.Ingame_Revive:
			reviveViewControl.gameObject.SetActive(true);
			reviveViewControl.OnShow();
			playingViewControl.gameObject.SetActive(false);
			gameOverViewControl.gameObject.SetActive(false);
			break;
		case IngameState.Ingame_GameOver:
			gameOverViewControl.gameObject.SetActive(true);
			gameOverViewControl.OnShow();
			reviveViewControl.gameObject.SetActive(false);
			playingViewControl.gameObject.SetActive(false);
			break;
		case IngameState.Ingame_Playing:
			playingViewControl.gameObject.SetActive(true);
			playingViewControl.OnShow();
			reviveViewControl.gameObject.SetActive(false);
			gameOverViewControl.gameObject.SetActive(false);
			break;
		}
	}
}
