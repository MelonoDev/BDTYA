using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDog : MonoBehaviour {

	public Shader VerticesOutlineShader; 
	public Shader VerticesOutlineShader2; 
	public Renderer rend;
	public AudioSource DogSoundSource;
	public AudioSource NaughtyDog;
	public DogStates dogStates;
	
	private bool SoundCheck = true;

	void Awake(){
		rend = GetComponent<Renderer>();
		DogSoundSource = GetComponentInChildren<AudioSource>();

	}


	void OnMouseDown () {
		if (dogStates.currentState == State.StopTime) {
			NaughtyDog.Play ();
			if (!dogStates.TheBullyDog) {
				dogStates.currentState = State.Bullied;
				print (dogStates.currentState);
			}
		}
	}
	
	void OnMouseOver () {
		if (dogStates.currentState == State.StopTime) {
			rend.material.shader = VerticesOutlineShader;
			if (SoundCheck) {
				SoundCheck = false;
				DogSoundSource.Play ();
			}
		}

	}

	void OnMouseExit (){
		rend.material.shader = VerticesOutlineShader2;
		SoundCheck = true;
	}
}


//Unity Development with Visual Studio Code