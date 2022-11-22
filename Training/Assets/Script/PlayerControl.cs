using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rigidbodyPlayer;
	[SerializeField] private float power;
	public Action gameOver;
	public Action addScore;
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "obstacles") {
			gameOver.Invoke();
		}
		if (collision.gameObject.tag == "score") {
			addScore.Invoke();
		}
	}
	public void reset() {
		rigidbodyPlayer.velocity = new Vector2(0, 0);
		transform.position = new Vector2(0, 0);
	}
	public void playerMove() {
		rigidbodyPlayer.velocity = Vector2.up * power;
	}
}


