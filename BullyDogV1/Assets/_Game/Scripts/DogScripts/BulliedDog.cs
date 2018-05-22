using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulliedDog : MonoBehaviour {

	public DogStates dogStates;
	public CharacterController charaCon;
	public Collider vertexMeshCollider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dogStates.currentState == State.Bullied) {
			Destroy (charaCon);
			vertexMeshCollider.enabled = false;
		}
	}
}
