using UnityEngine;
using System.Collections;

public class PlayerBackpack : MonoBehaviour {

	public bool transportingRessources = false;

	public int maxAmmo, currentAmmo;

	void Awake(){

		maxAmmo = 7;
		currentAmmo = maxAmmo;

	}

	void Update(){

		AmmoManager.ammo = currentAmmo;

	}
	

}
