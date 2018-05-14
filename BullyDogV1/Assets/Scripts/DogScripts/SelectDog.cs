using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDog : MonoBehaviour {

	public Shader VerticesOutlineShader; 
	public Shader VerticesOutlineShader2; 
	public Renderer rend;

	void Awake(){
		rend = GetComponent<Renderer>();
	}

	void Update (){

	}

	// Use this for initialization
	void OnMouseDown () {
		
	}
	
	// Update is called once per frame
	void OnMouseOver () {
		rend.material.shader = VerticesOutlineShader;
	}

	void OnMouseExit (){
		rend.material.shader = VerticesOutlineShader2;
	}
}
