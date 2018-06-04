using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightDogPicked : MonoBehaviour {

	public GameObject WinMessage;

	void Start () {
		WinMessage.SetActive (false);
	}
	
	public void DisplayWinMessage () {
		WinMessage.SetActive (true);
	}
}
