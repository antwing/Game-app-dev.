﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) {
		if(other.name == "PC")
		{
			Debug.Log("Player Enters Death Zone");
			Destroy(other);
		}
	}
}
