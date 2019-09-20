using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab,spawnPoint;
    public Text waveCountDownText;
    public int waveIndex = 0;
    private float waveInterval = 5.5f;
    private float spawnInterval = 0.5f;
    private float countDown = 2f;



    void Update(){
    	if (countDown <= 0f){
    		StartCoroutine(SpawnWave());
    		countDown = waveInterval;
    	}
    	countDown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Round(countDown).ToString();


    }

    IEnumerator SpawnWave(){
        waveIndex++;
    	for (int i = 0; i < waveIndex; i++){
    		SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
    	}
    	Debug.Log("Wave "+waveIndex+" Incoming.");
    }


    void SpawnEnemy(){
    	Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
