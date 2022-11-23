using UnityEngine;
using System;
public class ObstaclesGameObject : MonoBehaviour {
    [SerializeField] private float speed;
    public Action<ObstaclesGameObject> DestroyEvent;
    private GamePlayControl gamePlayControl;
    private void Start() {
        // gamePlayControl = GameObject.FindObjectOfType<GamePlayControl>();
        // gamePlayControl.StopGameEvent += OnGameOver;
    }
    private void Update() {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (transform.position.x <= -6f) {
            // Destroy(gameObject);
            DestroyEvent.Invoke(this);
        }
    }
    // private void OnGameOver() {
    //     Destroy(gameObject);
    // }
    // private void OnDestroy() {
    //     gamePlayControl.StopGameEvent -= OnGameOver;
    // }
}
