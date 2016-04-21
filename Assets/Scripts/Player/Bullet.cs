using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 5;
	public float lifeTime = 5;


	
	void Awake () {
	
		Destroy (gameObject, lifeTime);

	}

	void Update () {

		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	
	}
}
