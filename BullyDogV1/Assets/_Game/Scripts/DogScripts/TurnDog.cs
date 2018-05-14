using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDog : MonoBehaviour {

	public DogStates dogStates;
	private float rotateSpeed;
	private float maxTurn = 1.2f;
	private float minTurn = .3f;

	// Use this for initialization
	void Start () {
		rotateSpeed = Random.Range (-maxTurn, maxTurn);
		if ((rotateSpeed < minTurn) && (rotateSpeed >= 0 )) {
			rotateSpeed = Random.Range (minTurn, maxTurn);
		}
		if ((rotateSpeed > -minTurn) && (rotateSpeed <= 0 )) {
			rotateSpeed = Random.Range (-maxTurn, -minTurn);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (dogStates.currentState == State.Turn) {
			transform.Rotate (0, 0, rotateSpeed);
		}
	}
}
