using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public AudioAnalyser audioAnalyser;
    public GameObject enemyPrefab;
    public List<GameObject> enemies;
    Clock clock;
    int maxEnemies;

    // Use this for initialization
    void Start () {
        clock = GetComponent<Clock>();
        enemies = new List<GameObject>();
        maxEnemies = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (clock.elapsedTime > 180)
        {
            if (audioAnalyser.beatDetected)
            {
                clock.elapsedTime = 0;

                if (enemies.Count < maxEnemies)
                {
                    enemies.Add(GameObject.Instantiate<GameObject>(enemyPrefab, new Vector3(Random.Range(-10, 10), Random.Range(0, 5), 10), Quaternion.identity));
                }
            }
        }
    }
}
