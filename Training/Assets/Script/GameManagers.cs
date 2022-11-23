using UnityEngine;

public class GameManagers : MonoBehaviour {

    [SerializeField] private UIManager uiManager;
    [SerializeField] private GamePlayControl gamePlayControl;
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private MyEnum gameCurrentState;
    [SerializeField] private int gameScore;
    private void Start() {
        playerControl.GameOverEvent += OnGameOver;
        playerControl.AddScoreEvent += OnAddScore;
    }
    private void FixedUpdate() {
        MovingPlayer();
    }
    private void Update() {
        gamePlayControl.SpawnObstacle();
    }
    public void ButtonOpenSetting() {
        gameCurrentState.currentGameState = MyEnum.GameState.Setting;
        uiManager.openSettingWindow();
    }
    public void ButtonBackMainMenu() {
        gameCurrentState.currentGameState = MyEnum.GameState.MainMenu;
        uiManager.closeSettingWindow();
        uiManager.closeGameOverWindow();
        uiManager.openMainMenuWindow();
    }
    public void ButtonPlay() {
        gameCurrentState.currentGameState = MyEnum.GameState.GamePlay;
        uiManager.closeMainMenuWindow();
        gamePlayControl.Initialize();
        uiManager.closeGameOverWindow();
        gameScore = 0;
        uiManager.SetTextScore(gameScore);
    }
    private void OnGameOver() {
        if (gameCurrentState.currentGameState != MyEnum.GameState.GameOver) {
            gameCurrentState.currentGameState = MyEnum.GameState.GameOver;
            uiManager.openGameOverWindow(gameScore);
            gamePlayControl.GameStop();
        }
    }
    private void OnAddScore() {
        if (gameCurrentState.currentGameState == MyEnum.GameState.GamePlay) {
            gameScore++;
            uiManager.SetTextScore(gameScore);
        }
    }
    private void MovingPlayer() {
        if (gameCurrentState.currentGameState == MyEnum.GameState.GamePlay) {
            if (Input.GetMouseButton(0)) {
                playerControl.PlayerMove();
            }
        }
    }
}