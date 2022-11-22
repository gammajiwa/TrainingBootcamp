using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textGameOver;
    public GameObject gameOverWindow;
    public void setTextGameOver(int score){
        textGameOver.text ="SCORE :"+"<br>"+ score;
    }

}
