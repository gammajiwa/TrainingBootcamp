using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI textGameOver;
    public GameObject gameOverWindow;
    public void SetTextGameOver(int score) {
        textGameOver.text = "SCORE :" + "<br>" + score;
    }

}
