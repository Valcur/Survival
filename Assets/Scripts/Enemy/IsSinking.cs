using UnityEngine;
using System.Collections;

public class IsSinking : MonoBehaviour {
	
	void Sink () {

		transform.parent.GetComponent<EnemyHealth> ().StartSinking ();
	
	}

}
