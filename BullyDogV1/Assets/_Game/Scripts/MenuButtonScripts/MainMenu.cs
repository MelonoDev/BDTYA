using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void QuitGame() {
		Application.Quit ();
	}

	public void Credits(){
		SceneManager.LoadScene ("CreditsScene");
	}

	public void ToMainMenu(){
		SceneManager.LoadScene ("StartScene");
	}

	public void ToLevelSelect(){
		SceneManager.LoadScene ("LevelSelectScene");
	}

	public void ToThisLevel(string LvlNum){
		SceneManager.LoadScene ("Level" + LvlNum);
	}
}
