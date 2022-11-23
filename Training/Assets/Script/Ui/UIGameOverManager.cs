using UnityEngine;
using TMPro;

public class UIGameOverManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI textGameOver;
    public GameObject gameOverWindow;

    public void SetTextGameOver(int score) {
        textGameOver.text = score.ToString();
    }
}
