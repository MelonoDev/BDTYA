using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControlButtonScript : MonoBehaviour {

	public void ToNextLevel(){
		SceneManager.LoadScene ("Level" + SceneManager.GetActiveScene ().buildIndex.ToString());
	}

	public void ToMainMenu(){
		SceneManager.LoadScene ("StartScene");
	}

	public void ToRetry(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
