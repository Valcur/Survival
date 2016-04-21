using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {

	public string powerupEffect;

	bool isActivate = false;
	GameObject player;
	float duration;
	float timer;

	void Awake(){
	
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	void Update(){
	
		if (isActivate == true) {
		
			timer += Time.deltaTime;

			if(timer >= duration){

				PowerupEffectUnactivation();

				Destroy(gameObject);

			}
		
		}
	
	
	
	}


	void OnTriggerEnter (Collider coll) {

		if (coll.name == "Player") {
		
			PowerupActivation();
			Debug.Log("activating powerup");
		
		}
	
	}

	void PowerupActivation () {

		PowerupEffectActivation ();

		transform.parent.GetComponent<PowerupSpawnPoint> ().isEmpty = true;

		transform.GetComponent<MeshRenderer> ().enabled = false;

		isActivate = true;


		
	}

	void PowerupEffectActivation () {

		switch (powerupEffect) 
		{
		case "speed":
			player.GetComponent<PlayerMovement>().speedPU += 10;
			duration = 6;
			break;
		case "life":
			player.GetComponent<PlayerHealth>().currentHealth += 25;
			duration = 0;
			break;
						
		}

	}

	void PowerupEffectUnactivation () {
		
		switch (powerupEffect) 
		{
		case "speed":
			Debug.Log("speed end");
			player.GetComponent<PlayerMovement>().speedPU -= 10;
			break;

			
		}
		
	}
}
