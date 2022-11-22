using UnityEngine;

public class GameManager : MonoBehaviour
{
	private enum gameState
	{
		mainMenu,
		gamePlay,
		setting,
		gameOver
	}
	[SerializeField] private gameState gameCurrentState;
	[SerializeField] private UIManager uiManager;
	[SerializeField] private GamePlayControl gamePlayControl;
	[SerializeField] private PlayerControl playerControl;
	[SerializeField] private int GameScore;
	private void Start() {
		playerControl.gameOver += onGameOver;
		playerControl.addScore += onAddScore;
	}
	private void FixedUpdate() {
		movingPlayer();
	}
	private void Update() {
		gamePlayControl.spawnObstacle();
	}
	public void buttonOpenSetting() {
		gameCurrentState = gameState.setting;
		uiManager.openSettingWindow();
	}
	public void buttonBackMainMenu() {
		gameCurrentState = gameState.mainMenu;
		uiManager.closeSettingWindow();
		uiManager.closeGameOverWindow();
		uiManager.openMainMenuWindow();
	}
	public void buttonPlay() {
		gameCurrentState = gameState.gamePlay;
		uiManager.closeMainMenuWindow();
		gamePlayControl.initialized();
		uiManager.closeGameOverWindow();
	}
	private void onGameOver() {
		if (gameCurrentState != gameState.gameOver) {
			gameCurrentState = gameState.gameOver;
			uiManager.openGameOverWindow(GameScore);
			GameScore = 0;
			uiManager.setTextScore(GameScore);
			gamePlayControl.gameStop();
		}
	}
	private void onAddScore() {
		if (gameCurrentState == gameState.gamePlay) {
			GameScore++;
			uiManager.setTextScore(GameScore);
		}
	}
	private void movingPlayer() {
		if (gameCurrentState == gameState.gamePlay) {
			if (Input.GetMouseButton(0)) {
				playerControl.playerMove();
			}
		}
	}
}