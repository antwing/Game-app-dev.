﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public transform FirePoint;

	public GameObject Projectile;

	// Use this for initialization
	void Start () {
		Projectile = gameObject.Find("Projectile");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightControl))
		{
			Instantiate(Projectile.FirePoint.position, FirePoint.rotation);
		}
		
	}
}