using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public int LevelToload;

	public void LoadLevel(){
		SceneManager.LoadScene(LevelToload);
	}

	public void LevelExit(){
		Application.Quit();
	}
}