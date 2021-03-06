﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public Transform FirePoint;

	public GameObject Projectile;
	public Animator animator;



	// Use this for initialization
	void Start () {
		Projectile = Resources.Load("Prefabs/projectile") as GameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.RightControl))
		{
			Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
			animator.SetBool("isShoot", true);
		}
		
		else if(Input.GetKeyUp (KeyCode.Space)){
				animator.SetBool ("isShoot", false);
			}
			
		
	}
}
