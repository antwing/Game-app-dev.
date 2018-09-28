﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	//player Movement variables

	public int moveSpeed = 5;
	public float JumpHeight;
	private bool doubleJump;

	//player grounded varables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	//Non-Slide Player
	private float moveVelocity;

	// Use this for initialization
	void Start () 
	{
		
	}

	void FixedUpdate()
	{
		//checks the ground
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//makes character jump
		
			if(Input.GetKeyDown(KeyCode.Space)&& grounded || Input.GetKey(KeyCode.W)&& grounded)
			{
				Jump();
			}

			//double jump
			if(grounded)
			{
				doubleJump = false;
			}

			if(Input.GetKeyDown(KeyCode.Space)&& !grounded && !doubleJump || Input.GetKey(KeyCode.W)&& !grounded && !doubleJump)
			{
				Jump();
				doubleJump = true;
			}

		//non-slide player
		moveVelocity = 0f;

		//character movement

			//right
			if(Input.GetKey(KeyCode.D))
			{
				//GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
				moveVelocity = moveSpeed;
			}

			//left
			if(Input.GetKey(KeyCode.A))
			{
				//GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
				moveVelocity = -moveSpeed;

			}
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

	}


	public void Jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,JumpHeight);
	}
}