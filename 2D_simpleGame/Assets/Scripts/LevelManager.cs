using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;

	private Rigidbody2D PC;

	public GameObject PC2;

	//particles
	public GameObject DeathParticle;

	public GameObject RespawnParticle;

	//respawn delay
	public float RespawnDelay;

	//point penalty on death

	public int PointPenaltyOnDeath;

	//store Gravity value

	private float GravityStore;

	// Use this for initialization
	void Start () {
		PC = GameObject.Find("PC").GetComponent<Rigidbody2D>();
		PC2 = GameObject.Find("PC");
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		//generate death particle
		Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);
		PC2.SetActive (false);
		//hide pc
		//PC.enbled = false;
		PC.GetComponent<Renderer>().enabled = false;
		//gravity reset
		GravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
		PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
		PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//Point Penalty
		ScoreManager.AddPoints(PointPenaltyOnDeath);
		//Debug Message
		Debug.Log("PC Respawn");
		//respawn delay
		yield return new WaitForSeconds(RespawnDelay);
		//gravity Restore
		PC.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//match PCs transform position
		PC.transform.position = CurrentCheckPoint.transform.position;
		//show Pc
		//PC.enabled = true;
		PC2.SetActive(true);
		PC.GetComponent<Renderer>().enabled = true;
		//spawn PC
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);

	}
}
