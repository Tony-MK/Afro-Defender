using UnityEngine;
using System.Collections;


public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab,spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public int waveNumber = 1;

    void Update(){
    	if (countdown <= 0f){
    		SpawnWave();
    		countdown = timeBetweenWaves;
    	}
    	countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave(){

    	for (int i = 0; i < waveNumber; i++){
    		SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
    	}

    	waveNumber++;
    	Debug.Log("Wave "+waveNumber+" Incoming");
    }

    void SpawnEnemy(){
    	Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
