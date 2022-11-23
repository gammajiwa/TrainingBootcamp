using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayControl : MonoBehaviour {
    // public Action StopGameEvent;
    [SerializeField] private PlayerControl player;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnLocation;
    [SerializeField] private float timeSpawner;
    [SerializeField] private Vector2 minMax;
    [SerializeField] bool isPlaying = false;
    private List<ObstaclesGameObject> obstacles = new List<ObstaclesGameObject>();
    private float timer = 0;
    public void Initialize() {
        player.gameObject.SetActive(true);
        player.Reset();
        isPlaying = true;
    }
    public void SpawnObstacle() {
        if (isPlaying) {
            timer -= 1 * Time.deltaTime;
            if (timer <= 0) {
                float randomPosition = UnityEngine.Random.Range(minMax.x, minMax.y);
                ObstaclesGameObject obj = Instantiate(obstaclePrefab, new Vector2(spawnLocation, randomPosition), Quaternion.identity).GetComponent<ObstaclesGameObject>();
                obstacles.Add(obj);
                obj.DestroyEvent += OnDestroyObstacle;
                timer = timeSpawner;
            }
        }
    }
    public void GameStop() {
        isPlaying = false;
        // StopGameEvent.Invoke();
        player.gameObject.SetActive(false);
    }

    private void OnDestroyObstacle(ObstaclesGameObject obstaclesGameObject) {
        if (obstacles.Contains(obstaclesGameObject)) {
            obstacles.Remove(obstaclesGameObject);
            obstaclesGameObject.DestroyEvent -= OnDestroyObstacle;
            Destroy(obstaclesGameObject.gameObject);
        }
    }
}
