using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public Transform FirePoint;

	public GameObject Projectile;

	public GameObject FirePoint;

	// Use this for initialization
	void Start () {
		Projectile = GameObject.Find("Projectile");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightControl))
		{
			Instantiate(Projectile.FirePoint.position, Projectile.FirePoint.rotation);
		}
		
	}
}
