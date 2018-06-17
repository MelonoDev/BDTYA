using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeeLevel : MonoBehaviour {

	public Slider peeBar;
	public float PeeAmount = 0;
	public float PeeMaximum = 5;
	public GameObject LoseObjectPee;

	// Use this for initialization
	void Start () {
		peeBar.value = PeeAmount;
		LoseObjectPee.SetActive (false);
	}

	void Update(){
		if (PeeAmount >= PeeMaximum) {
			LoseObjectPee.SetActive (true);
		}
	}

	public void GainPee() {
		PeeAmount += 1;
		peeBar.value = CalculatePeeAmount();
	}

	float CalculatePeeAmount(){
		return PeeAmount / PeeMaximum;
	}

}
