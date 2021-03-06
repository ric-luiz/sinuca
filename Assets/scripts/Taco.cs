﻿using UnityEngine;
using System.Collections;

public class Taco : MonoBehaviour {
	public GameObject bolaJogador;
	public GameObject colissor;
	//public AudioClip impacto;
	//private AudioSource audio; 
	private int forca;
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
		//audio = colissor.GetComponent<AudioSource>();
		//Cria os ignores dos collision
		foreach (GameObject i in GameObject.FindGameObjectsWithTag ("barra")) {
			Physics.IgnoreCollision (
				i.GetComponent<Collider>(),
				transform.Find("colisor").gameObject.GetComponent<Collider>());
		}
		foreach (GameObject i in GameObject.FindGameObjectsWithTag ("bola")) {
			Physics.IgnoreCollision (
				i.GetComponent<Collider>(),
				transform.Find("colisor").gameObject.GetComponent<Collider>());
		}
	}

	void FixedUpdate(){
		//Faz o impulso da tacada
		if(Input.GetMouseButtonUp(2)){
			rb.AddForce(transform.forward*-forca,ForceMode.Impulse);
		}

		//Rotaciona o taco em volta da bola;
		if(Input.GetMouseButton(1)){
			transform.RotateAround (bolaJogador.transform.position,Vector3.up,-0.5f);
		} else if(Input.GetMouseButton(0)){
			transform.RotateAround (bolaJogador.transform.position,Vector3.up,0.5f);
		}
		
		//Faz a funçao do taco puxar para tras e soltar
		if (Input.GetMouseButton (2) && forca < 300) {
			forca+=5;
			transform.Translate (0, 0, 0.01f);
		}
	}

	void OnCollisionStay(Collision col){

		if(col.gameObject.name == "BolaPrincipal"){
			//Desabilita as forças aplicadas ao taco
			rb.isKinematic = true;
			//Esconde o taco
			gameObject.SetActive(false);
			//Faz com que as colisoes nao sejam detectadas
			colissor.GetComponent<Collider>().isTrigger = true;
			//Seta a puxada para tras do taco para zero
			forca = 0;
			//Faz o som Do taco
			//audio.Play();
		}
	}
}
