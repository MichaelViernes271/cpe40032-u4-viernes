using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public bool gameOver = false;
	public GameObject enemyPrefab;
	public GameObject powerupPrefab;
	
	public int enemyCount;
	public int waveNumber;
	
	private float spawnRange = 9;
	
    // Start is called before the first frame update
    void Start()
    {
		// Spawn enmeies in proportion to wave level
		Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
		
		// Spawns powerup every wave
		Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
		if(enemyCount == 0 && !gameOver)
		{
			waveNumber++;
			SpawnEnemyWave(waveNumber);
			
		}
    }
	
	// spawns enemies
	void SpawnEnemyWave(int enemiesToSpawn)
	{
		for (int i = 0; i < enemiesToSpawn; i++)
		{
			Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
			
		}
		Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
	}
	public Vector3 GenerateRandomPosition()
	{
		float spawnPosX = Random.Range(-spawnRange, spawnRange);
		float spawnPosZ = Random.Range(-spawnRange, spawnRange);
		Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
		return randomPos;
	}
}
