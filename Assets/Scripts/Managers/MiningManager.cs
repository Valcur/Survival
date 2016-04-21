using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiningManager : MonoBehaviour {


	public float activationSpeed = 0.1f;
	public float miningSpeed = 0.01f;
	public Image activationProgress;
	public Image miningProgress;
	public GameObject container;


	GameObject player, playerVisual;
	PlayerBackpack backPack;
	bool isActivate = false;
	bool miningComplete = false;
	Animator anim;

	

	void Awake () {
	
		player = GameObject.FindGameObjectWithTag ("Player");
		playerVisual = GameObject.FindGameObjectWithTag ("PlayerVisual");
		backPack = player.GetComponent<PlayerBackpack> ();
		anim = GetComponent<Animator> ();
	
	}

	void OnTriggerStay (Collider coll) {

		if (isActivate == false && coll.name == "Player") {
		
			activationProgress.fillAmount += activationSpeed;
		
		}

		if (activationProgress.fillAmount == 1) {
		
			isActivate = true;
			anim.SetTrigger("StartMining");
		
		}


		if (miningComplete && coll.name == "Player" && backPack.transportingRessources == false) {
		
			Collect();
		
		}
	
	}

	void Update() {

		if (isActivate) {
		
			miningProgress.fillAmount += miningSpeed;
		
		}

		if (miningProgress.fillAmount == 1) {
		
			miningComplete = true;
		
		}

	}

	void Collect(){

		miningComplete = false;
		miningProgress.fillAmount = 0;
		backPack.transportingRessources = true;
		var spawnCont = Instantiate (container, playerVisual.transform.position,
		                             new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w)
		            ) as GameObject;
		spawnCont.transform.parent = playerVisual.transform;
		spawnCont.transform.localPosition = new Vector3 (0, 1.5f, - 0.36f);
		Debug.Log ("You collect");

	}
}
