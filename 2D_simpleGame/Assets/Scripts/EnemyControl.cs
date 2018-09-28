using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
	//movement Var

	public float MoveSpeed;

	public bool MoveRight;

	//wall check

	public Transform WallCheck;

	public float WallCheckRadius;

	public LayerMask WhatIsWall;

	private bool HittingWall;


	//edge check

	private bool NotAtEdge;

	public Transform EdgeCheck;

	// Update is called once per frame
	void Update () 
	{
		NotAtEdge = Physics2D.OverLapCircle(EdgeCheck.postion, WallCheckRadius, WhatIsWall);

		HittingWall = Physics2D.OverLapCircle(WallCheck.postion, WallCheckRadius, WhatIsWall);
		
		if (HittingWall || !NotAtEdge)
		{
			MoveRight = !MoveRight;
		}

		if (MoveRight)
		{
			Transform.localScale = new vector3(-0.2f,0.2f,1f)
			GetComponent<RigidBody2D>().velocity = new vector2(MoveSpeed, GetComponent<RigidBody2D>().velocity.y);
		}
		else
		{
			Transform.localScale = new vector3(-0.2f,0.2f,1f)
			GetComponent<RigidBody2D>().velocity = new vector2(-MoveSpeed, GetComponent<RigidBody2D>().velocity.y);

		}
	}
}
