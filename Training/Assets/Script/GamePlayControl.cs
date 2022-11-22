using System;
using UnityEngine;

public class GamePlayControl : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject obstacle;
	[SerializeField] private float spawnLocation;
	[SerializeField] private float timeSpawner;
	[SerializeField] private Vector2 minMax;
	[SerializeField] bool isPlaying = false;
	private float timer = 0;
	public Action stopGame;
	public void initialized() {
		player.SetActive(true);
		player.GetComponent<PlayerControl>().reset();
		isPlaying = true;
	}
	public void spawnObstacle() {
		if (isPlaying) {
			timer -= 1*Time.deltaTime;
			if (timer <= 0) {
				float randomePosision = UnityEngine.Random.Range(minMax.x, minMax.y);
				Instantiate(obstacle, new Vector2(spawnLocation, randomePosision), Quaternion.identity);
				timer = timeSpawner;
			}
		}
	}
	public void gameStop() {
		isPlaying = false;
		stopGame.Invoke();
		player.SetActive(false);
	}
}
