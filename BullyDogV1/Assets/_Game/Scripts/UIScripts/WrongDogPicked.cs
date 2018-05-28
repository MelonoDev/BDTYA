using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongDogPicked : MonoBehaviour {

	public int WrongAnswers = 0;
	public GameObject[] WrongImage;

	void Start () {
		for (int i = 0; i < WrongImage.Length; i++) {
			WrongImage [i].SetActive (false);
		}
	}


	public void ChosenWrong() {
		WrongImage [WrongAnswers].SetActive (true);
		WrongAnswers += 1;
	}
}
