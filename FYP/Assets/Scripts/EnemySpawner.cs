using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public AudioAnalyser audioAnalyser;
    public GameObject enemyPrefab;
    public List<GameObject> enemies;
    Clock clock;
    int maxEnemies, timeToSpawn;

    // Use this for initialization
    void Start () {
        clock = GetComponent<Clock>();
        enemies = new List<GameObject>();
        maxEnemies = 10;
        timeToSpawn = 180;
	}
	
	// Update is called once per frame
	void Update () {
        if (clock.elapsedTime > timeToSpawn)
        {
            if (audioAnalyser.beatDetected)
            {
                clock.elapsedTime = 0;

                if (enemies.Count < maxEnemies)
                {
                    enemies.Add(GameObject.Instantiate<GameObject>(enemyPrefab, new Vector3(Random.Range(-7f, 7f), Random.Range(2f, 5f), 7f), Quaternion.identity));
                }
            }
        }
    }
}
