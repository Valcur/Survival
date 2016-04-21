using UnityEngine;
using System.Collections;

public class CopterMovement : MonoBehaviour
{
	public float distMin = 15;
	public float turnSpeed = 5;
	public GameObject barrelEnd;

    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
	Animator anim;
	float speed;
	EnemyShoot shoot;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
		anim = GetComponentInChildren<Animator>();
		speed = nav.speed;
		shoot = barrelEnd.GetComponent<EnemyShoot> ();
    }


    void Update ()
    {
		float playerDist = (transform.position - player.position).magnitude;
		Quaternion desiredRot = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Lerp (transform.rotation, desiredRot, turnSpeed * Time.deltaTime);

        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && playerDist >= distMin)
        {
			nav.speed = speed;
			nav.SetDestination (player.position);
			anim.SetBool("IsStanding", false);
			shoot.isShooting = false;
        }
		else if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && playerDist < distMin)
		{
			nav.speed = 0;
			anim.SetBool("IsStanding", true);
			shoot.isShooting = true;
		}
        else
        {
       	    nav.enabled = false;
        }
    }
}
