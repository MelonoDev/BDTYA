using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongDogPicked : MonoBehaviour {

	public int WrongAnswers = 0;
	public GameObject[] WrongImage;
	public GameObject LoseObject;

	void Start () {
		for (int i = 0; i < WrongImage.Length; i++) {
			WrongImage [i].SetActive (false);
		}
		LoseObject.SetActive (false);
	}


	public void ChosenWrong() {
		WrongImage [WrongAnswers].SetActive (true);
		WrongAnswers += 1;
		if (WrongAnswers >= 3) {
			LoseObject.SetActive (true);
		}
	}
}
