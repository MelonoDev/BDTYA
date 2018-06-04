using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopTimeVisual : MonoBehaviour {

	public GameObject StopTimeImage;
	public GameObject Controller;
	public TimeControl timeControl;

	void Start () {
		Controller = GameObject.Find ("ControllerObject");
		timeControl = Controller.GetComponent<TimeControl> ();
		StopTimeImage.SetActive (false);
	}

	void Update (){
		if (timeControl.TimeHasStopped) {
			StopTimeImage.SetActive (true);
		} else {
			StopTimeImage.SetActive (false);
		}
	}

}
