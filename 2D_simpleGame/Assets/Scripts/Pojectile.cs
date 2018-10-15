using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pojectile : MonoBehaviour {

	public float speed;

	public Rigidbody2D PC;

	public GameObject EnemyDeath;

	public GameObject ProjectileParticle;

	public int PointsForKill;

	// Use this for initialization
	void Start () {

		if (PC.transform.localScale.x < 0)
		{
			speed = -speed;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy"){
			Instantiate(EnemyDeath,other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints(PointsForKill);
		}
		
		Instantiate(ProjectileParticle, transform.position, transform.rotation);
		Destroy (gameObject);
	}

}
