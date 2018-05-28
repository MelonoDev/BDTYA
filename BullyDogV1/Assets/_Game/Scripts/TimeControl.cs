using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour {

	public GameObject[] Doggies;
	public bool TimeHasStopped = false;
	public AudioSource TimeStopSound;
	public AudioSource TimeResumeSound;
	public AudioSource SceneMusic;

	// Use this for initialization
	void Start () {
		Doggies = GameObject.FindGameObjectsWithTag("Doggy");
	}
	
	void Update () {
		if (Input.GetButtonDown("Jump")) {
			print ("ZA WARUDO");



			foreach (GameObject Dog in Doggies)
			{
				if ((Dog.GetComponent<DogStates>().currentState != State.StopTime) && ((Dog.GetComponent<DogStates>().currentState != State.Bullied))){
					Dog.GetComponent<DogStates>().currentState = State.StopTime; 
					TimeHasStopped = true; 
					TimeStopSound.Play ();
					SceneMusic.Pause ();

				} else if ((Dog.GetComponent<DogStates>().currentState == State.StopTime)){
					Dog.GetComponent<DogStates>().currentState = State.Idle;
					TimeHasStopped = false;
					TimeResumeSound.Play ();
					SceneMusic.UnPause ();

				}
			}
		}
	}
}
