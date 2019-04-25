using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public AudioAnalyser audioAnalyser;
    public GameObject enemyPrefab;
    Clock clock;
    int maxEnemies, timeToSpawn;
    public int enemyCount;

    // Use this for initialization
    void Start () {
        clock = GetComponent<Clock>();
        maxEnemies = 5;
        enemyCount = 0;
        timeToSpawn = 120;
	}
	
	// Update is called once per frame
	void Update () {
        if (clock.elapsedTime > timeToSpawn)
        {
            if (audioAnalyser.beatDetected)
            {
                clock.elapsedTime = 0;

                if(enemyCount < maxEnemies)
                {
                    GameObject.Instantiate<GameObject>(enemyPrefab, new Vector3(Random.Range(-7f, 7f), Random.Range(2f, 5f), 7f), Quaternion.identity);
                    ++enemyCount;
                }
            }
        }
    }
}
