using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 5;
	public bool stop;
	private Rigidbody enemyRb;
	private SpawnManager spawnManager;
	private PlayerController player;
	
    // Start is called before the first frame update
    void Start()
    {
		enemyRb = GetComponent<Rigidbody>();
		spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
		player = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
		if(transform.position.y < -30 || spawnManager.gameOver)
		{
			Destroy(gameObject);
		}
		Vector3 lookDirection = (player.transform.position - transform.position).normalized;
		enemyRb.AddForce(lookDirection * speed * Time.deltaTime);			
        
    }
}
