using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

	void StartMoving(){

	}
	void StopMoving(){
		GetComponent<Animator> ().SetTrigger ("StopMoving");
	}
	void IsMoving(){
		
	}
}
