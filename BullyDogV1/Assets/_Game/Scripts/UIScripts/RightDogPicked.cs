using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightDogPicked : MonoBehaviour {

	public GameObject WinMessage;

	// Use this for initialization
	void Start () {
		WinMessage.SetActive (false);
	}
	
	// Update is called once per frame
	public void DisplayWinMessage () {
		WinMessage.SetActive (true);
	}
}
