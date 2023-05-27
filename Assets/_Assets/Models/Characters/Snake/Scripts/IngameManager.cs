using FreakySnake;
using System;
using Collections.Pooled.Generic;
using Cysharp.Threading.Tasks;
using FreakySnake.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameManager : SingletonMonobehaviour<IngameManager>
{
	[Header("In Game Config")]
	[SerializeField]
	private float reviveWaitTime = 5f;

	// [SerializeField]
	// private int firstEmptyGround = 5;
	//
	// [SerializeField]
	// private int nextNormalGround = 5;

	[SerializeField]
	private float firstGroundZPos = -5f;

	[SerializeField]
	[Range(0f, 3f)]
	private int minBodyPartAdder = 2;

	// [SerializeField]
	// [Range(0f, 8f)]
	// private int maxBodyPartAdder = 8;
	//
	// [SerializeField]
	// private int scoreToIncreaseBodyPartAdder = 30;
	//
	// [SerializeField]
	// private int bodyPartAdderIncreaseAmount = 1;

	[SerializeField]
	[Range(0f, 5f)]
	private int minBlock = 5;

	// [SerializeField]
	// [Range(0f, 13f)]
	// private int maxBlock = 13;
	//
	// [SerializeField]
	// private int scoreToIncreaseBlock = 30;
	//
	// [SerializeField]
	// private int blockIncreaseAmount = 1;

	[SerializeField]
	[Range(0f, 3f)]
	private int minObstacle = 3;

	// [SerializeField]
	// [Range(0f, 13f)]
	// private int maxObstacle = 13;
	//
	// [SerializeField]
	// private int scoreToIncreaseObstacle = 30;
	//
	// [SerializeField]
	// private int obstacleIncreaseAmount = 1;
	//
	// [SerializeField]
	// [Range(0f, 3f)]
	// private int minCoin;
	//
	// [SerializeField]
	// [Range(0f, 5f)]
	// private int maxCoin = 5;
	//
	// [SerializeField]
	// [Range(0f, 1f)]
	// private float shieldFrequency = 0.15f;
	//
	// [SerializeField]
	// [Range(0f, 1f)]
	// private float magnetFrequency = 0.01f;
	//
	// [SerializeField]
	// private float textMovingUpSpeed = 10f;

	[SerializeField] private Canvas screenCanvas; 
	[SerializeField] private GameObject gameOverScreenPrefab; 

	[SerializeField]
	private List<BlockConfig> listBlockConfig = new List<BlockConfig>();
	
	[SerializeField]
	private List<BodyPartAdderConfig> listBodyPartAdderConfig = new List<BodyPartAdderConfig>();
	
	[SerializeField]
	private List<FadingTextConfig> listFadingTextConfig = new List<FadingTextConfig>();

	private IngameState gameState = IngameState.Ingame_GameOver;

	private Vector3 groundSize = Vector3.zero;
	
	private Vector3 nextGroundPos = Vector3.zero;
	
	private int currentBodyPartAdderNumber;
	
	private int currentBlockNumber;
	
	private int currentObstacleNumber;
	private GameManager _gameOver;
	
	public static int EnvironmentIndex
	{
		get;
		private set;
	}

	public IngameState IngameState
	{
		get
		{
			return gameState;
		}
		private set
		{
			if (value != gameState)
			{
				gameState = value;
				GameStateChanged(gameState);
			}
		}
	}

	public float ReviveWaitTime
	{
		get;
		private set;
	}

	public bool IsRevived
	{
		get;
		private set;
	}

	public static event Action<IngameState> GameStateChanged;

	private void Start()
	{
		Application.targetFrameRate = 60;
		ViewManager.Instance.OnLoadingSceneDone(SceneManager.GetActiveScene().name);
		ServicesManager.Instance.ScoreManager.ResetCurrentScore();
		ServicesManager.Instance.CoinManager.ResetCollectedCoins();
		ReviveWaitTime = reviveWaitTime;
		IsRevived = false;
		currentBodyPartAdderNumber = minBodyPartAdder;
		currentBlockNumber = minBlock;
		currentObstacleNumber = minObstacle;
		// groundSize = PoolManager.Instance.GetGroundSize();
		nextGroundPos = new Vector3(0f, 0f, firstGroundZPos);
		// for (int i = 0; i < firstEmptyGround; i++)
		// {
		// 	CreateGround(isCreateObjects: false);
		// }
		// for (int j = 0; j < nextNormalGround; j++)
		// {
		// 	CreateGround(isCreateObjects: true);
		// }
		PlayingGame();
	}

	public void PlayingGame()
	{
		IngameState = IngameState.Ingame_Playing;
		gameState = IngameState.Ingame_Playing;
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void UnPauseGame()
	{
		Time.timeScale = 1;
	}

	public void GameOver()
	{
		DisplayGameOverNotification();
		Time.timeScale = 0;
	}

	private void DisplayGameOverNotification()
	{
		var canvas = screenCanvas.GetComponent<Canvas>();
		Instantiate(gameOverScreenPrefab, canvas.transform);
	}

	public void LoadScene(string sceneName, float delay)
	{
		LoadingScene(sceneName, delay).Forget();
	}

	private async UniTask LoadingScene(string sceneName, float delay)
	{
		await UniTask.Delay(TimeSpan.FromSeconds(delay));
		SceneManager.LoadScene(sceneName);
	}

	static IngameManager()
	{
		GameStateChanged = delegate
		{
		};
	}
	
	// public void CreateBodyPartAdder(Vector3 pos)
	// {
	// 	BodyPartAdder bodyPartAdder = BodyPartsManager.Instance.GetBodyPartAdder();
	// 	bodyPartAdder.transform.position = pos;
	// 	bodyPartAdder.gameObject.SetActive(value: true);
	// 	// bodyPartAdder.InitValues(GetRandomBodyPartNumber());
	// }
}
