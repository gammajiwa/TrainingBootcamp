using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public Action GameOverEvent;
    public Action AddScoreEvent;
    [SerializeField] private Rigidbody2D rigidbodyPlayer;
    [SerializeField] private float power;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "obstacles") {
            GameOverEvent.Invoke();
        }
        if (collision.gameObject.tag == "score") {
            AddScoreEvent.Invoke();
        }
    }
    public void Reset() {
        rigidbodyPlayer.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }
    public void PlayerMove() {
        rigidbodyPlayer.velocity = Vector2.up * power;
    }
}


