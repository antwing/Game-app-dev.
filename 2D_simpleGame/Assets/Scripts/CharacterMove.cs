﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	//player Movement variables
	public Animator animator;

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
		animator.SetBool ("isJumping",false);
		animator.SetBool ("isRunning",false);
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

		//Input.GetKeyDown(KeyCode.Space)&& grounded || 
			if(Input.GetKey(KeyCode.W)&& grounded)
			{
				Jump();
			}

			//double jump
			if(grounded)
			{
				doubleJump = false;
				animator.SetBool ("isJumping", false);
			}

//Input.GetKeyDown(KeyCode.Space)&& !grounded && !doubleJump || 
			if(Input.GetKey(KeyCode.W)&& !grounded && !doubleJump)
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
				animator.SetBool ("isRunning", true);
			}
			else if(Input.GetKeyUp (KeyCode.D)){
				animator.SetBool ("isRunning", false);
			}

			//left
			if(Input.GetKey(KeyCode.A))
			{
				//GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
				moveVelocity = -moveSpeed;
				animator.SetBool ("isRunning", true);

			}
			else if(Input.GetKeyUp (KeyCode.A)){
				animator.SetBool ("isRunning", false);
			}
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

			//player flip
			if(GetComponent<Rigidbody2D>().velocity.x > 0)
			{
				transform.localScale = new Vector3(2f, 2f, 0.1f);
			}
			else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			{
				transform.localScale = new Vector3(-2f, 2f, 0.1f);
			}

	}
	/*
	public void OnGround()
	{
		animator.SetBool("isJumping", false);
	}
*/

	public void Jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,JumpHeight);
		animator.SetBool ("isJumping", true);
	}
}