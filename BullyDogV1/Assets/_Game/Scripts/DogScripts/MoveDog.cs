using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDog : MonoBehaviour {

	public DogStates dogStates;
	private float speed;

	// Use this for initialization
	void Start () {
		speed = Random.Range (.5F, 1.5F);
		CharacterController controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
		if (dogStates.currentState == State.Move) {
			CharacterController controller = GetComponent<CharacterController>();
			Vector3 forward = transform.TransformDirection(Vector3.up);
			controller.SimpleMove(forward * speed);
		}
	}
}
