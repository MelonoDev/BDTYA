using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDog : MonoBehaviour {

	public Shader VerticesOutlineShader; 
	public Shader VerticesOutlineShader2; 
	public Renderer rend;
	public AudioSource DogSoundSource;
	
	private bool SoundCheck = true;

	void Awake(){
		rend = GetComponent<Renderer>();
		DogSoundSource = GetComponentInChildren<AudioSource>();

	}

	void Update (){

	}

	// Use this for initialization
	void OnMouseDown () {
		
	}
	
	// Update is called once per frame
	void OnMouseOver () {
		rend.material.shader = VerticesOutlineShader;
		if (SoundCheck){
			SoundCheck = false;
			DogSoundSource.Play();

		}

	}

	void OnMouseExit (){
		rend.material.shader = VerticesOutlineShader2;
		SoundCheck = true;
	}
}


//Unity Development with Visual Studio Code