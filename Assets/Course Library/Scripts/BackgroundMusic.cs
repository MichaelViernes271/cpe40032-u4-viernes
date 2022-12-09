using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
	private AudioSource gameMusic;
	private PlayerController player;
	private SpawnManager spawnManager;
	
	public Text text;
	
    // Start is called before the first frame update
    void Start()
    {
		spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
		gameMusic = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
		if(spawnManager.gameOver) // if player falls; end game
		{
			gameMusic.Stop();
			text.gameObject.SetActive(true);					
		}
        
    }
}
