using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGameObject : MonoBehaviour
{
	[SerializeField] private float speed;
	private GamePlayControl gamePlayControl;
	private void Start() {
		gamePlayControl = GameObject.FindObjectOfType<GamePlayControl>();
		gamePlayControl.stopGame += onGameOver;
	}
	private void Update() {
		transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
		if(transform.position.x <= -6f ) {
			Destroy(gameObject);
		}
	}
	private void onGameOver() {
		Destroy(gameObject);
	}
	private void OnDestroy() {
		gamePlayControl.stopGame -= onGameOver;
	}
}
