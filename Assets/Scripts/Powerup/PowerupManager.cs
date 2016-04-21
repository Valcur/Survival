using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour {
	
	public GameObject[] powerup;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;
	
	
	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		int powerupIndex = Random.Range (0, powerup.Length);

		if(spawnPoints[spawnPointIndex].GetComponent<PowerupSpawnPoint>().isEmpty == false)
		{
			return;
		}
		
		var powerupGo = Instantiate (powerup[powerupIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
		powerupGo.transform.parent = spawnPoints [spawnPointIndex].transform;
		spawnPoints [spawnPointIndex].GetComponent<PowerupSpawnPoint> ().isEmpty = false;
	}
}
