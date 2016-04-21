using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddClothing : MonoBehaviour {
	
	#region Fields
	public GameObject[] body;
	public List<GameObject> clothing;
	public GameObject avatar;
	private GameObject wornClothing;
	private Stitcher stitcher;
	GameObject player;
	#endregion

	#region Monobehaviour
	void Awake () {

		avatar = GameObject.FindGameObjectWithTag ("PlayerArmature");
		stitcher = new Stitcher ();

	
		foreach (var cloth in clothing) {
			//RemoveWorn ();
			Wear (cloth);
		}


	}
	#endregion
	
	private void RemoveWorn ()
	{
		if (wornClothing == null)
			return;
		GameObject.Destroy (wornClothing);
	}
	
	private void Wear (GameObject clothing)
	{
		if (clothing == null)
			return;
		clothing = (GameObject)GameObject.Instantiate (clothing);
		wornClothing = stitcher.Stitch (clothing, avatar);
		GameObject.Destroy (clothing);
	}

}
