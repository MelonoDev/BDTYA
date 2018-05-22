using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamAxisScript : MonoBehaviour {

	float camSpeed = 3f;

	public TimeControl timeControl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!timeControl.TimeHasStopped) {
			transform.Rotate (0, Input.GetAxis ("Horizontal") * camSpeed, 0);
		}
	}
}
