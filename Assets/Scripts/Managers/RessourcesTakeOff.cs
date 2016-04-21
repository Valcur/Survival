using UnityEngine;
using System.Collections;

public class RessourcesTakeOff : MonoBehaviour {

	public int collectScore = 200;


	GameObject player;
	PlayerBackpack backpack;
	
	void Awake () {

		player = GameObject.FindGameObjectWithTag ("Player");
		backpack = player.GetComponent<PlayerBackpack> ();
	
	}

	void OnTriggerEnter (Collider coll) {

		if (coll.name == "Player" && backpack.transportingRessources) {
		
			TakeOff();
		
		}
	
	}

	void TakeOff(){

		backpack.transportingRessources = false;
		Destroy(GameObject.FindGameObjectWithTag("Container"));
		Debug.Log ("succeed");
		ScoreManager.score += collectScore;

	}


}