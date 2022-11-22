using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
	[SerializeField] private UIMainMenu uiMainMenu;
	[SerializeField] private UIGameOver uiGameOver;
	[SerializeField] private UISetting uiSetting;
	[SerializeField] private TextMeshProUGUI textScore;
	public void setTextScore(int score) {
		textScore.text ="SCORE : "+ score;
	}
	public void openSettingWindow() {
		uiSetting.settingWindow.SetActive(true);
	}
	public void openGameOverWindow(int score) {
		uiGameOver.gameOverWindow.SetActive(true);
		uiGameOver.setTextGameOver(score);
	}
	public void openMainMenuWindow() {
		uiMainMenu.uiMainMenu.SetActive(true);
	}
	public void closeSettingWindow() {
		uiSetting.settingWindow.SetActive(false);
	}
	public void closeGameOverWindow() {
		uiGameOver.gameOverWindow.SetActive(false);
	}
	public void closeMainMenuWindow() {
		uiMainMenu.uiMainMenu.SetActive(false);
	}
}
