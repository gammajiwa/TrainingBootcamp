using UnityEngine;

public class MyEnum : MonoBehaviour {
    public enum GameState {
        MainMenu,
        GamePlay,
        Setting,
        GameOver
    }
    public GameState currentGameState;
}
