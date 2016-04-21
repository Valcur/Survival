using UnityEngine;
using UnityEngine.UI;
using CnControls;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	public Image joyBaseAim, joyStickAim;
	public Image joyBaseMove, joyStickMove;

	public int speedPU;

	Vector3 movement;
	Quaternion rot;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLenght = 100f;
	PlayerShooting playerShooting;
	GameObject playerWeapon;
	GameObject playerMesh;
	GameObject playerVisual;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
		playerShooting = GetComponentInChildren<PlayerShooting> ();
		playerWeapon = GameObject.FindGameObjectWithTag("PlayerWeapon");
		playerMesh = GameObject.FindGameObjectWithTag ("PlayerMesh");
		playerVisual = GameObject.FindGameObjectWithTag ("PlayerVisual");

	}

	void FixedUpdate()
	{
		float h = CnControls.CnInputManager.GetAxisRaw ("Horizontal");
		float v = CnControls.CnInputManager.GetAxisRaw ("Vertical");

	

		Move (h, v);
		//MouseTurning ();
		Turning ();
		Animating (h, v);
	}

	void Move(float h, float v)
	{
		movement.Set (h, 0, v);
		movement = movement.normalized * speed * Time.deltaTime;

		Vector3 diffMove = joyStickMove.rectTransform.position - joyBaseMove.rectTransform.position;

		diffMove.Set(diffMove.y, 0, - diffMove.x);

		diffMove /= 4;
		speed = diffMove.magnitude + speedPU;

		rot.eulerAngles = new Vector3 (diffMove.x, transform.rotation.eulerAngles.y, diffMove.z);

		playerWeapon.transform.rotation = new Quaternion (-rot.x, playerVisual.transform.rotation.y, -rot.z, playerVisual.transform.rotation.w);
		transform.rotation = Quaternion.Lerp(transform.rotation, rot, 1);
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning()
	{
		playerShooting.isShooting = false;

		Vector3 diff = joyStickAim.rectTransform.position - joyBaseAim.rectTransform.position;


		if (Mathf.Abs (diff.x) > 1 && Mathf.Abs (diff.y) > 1) {

			playerShooting.isShooting = true;

			diff.Set (diff.x, diff.z, diff.y);
			diff.y = 0f;


			Quaternion newRotation = Quaternion.LookRotation (diff);
			newRotation = new Quaternion(playerVisual.transform.rotation.x, newRotation.y, playerVisual.transform.rotation.z, newRotation.w);


			/*
			newRotation.Set(transform.rotation.x, newRotation.y, transform.rotation.z, newRotation.w);
			Debug.Log (newRotation);*/
			playerVisual.transform.rotation = newRotation;
		}
		
	}

	void MouseTurning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if(Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}

	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}
