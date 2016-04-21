using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoManager : MonoBehaviour {

	public static int ammo;

	Text text;

	void Awake () {

		text = GetComponent<Text> ();
	
	}

	void Update () {

		text.text = "x " + ammo;
		Debug.Log (ammo);
	
	}
}
