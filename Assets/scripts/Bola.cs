using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		//Faz com que a bola pare quando estiver a uma velocidade baixa
		if(rb.velocity.magnitude < 0.1 && rb.velocity.magnitude > 0){
			rb.velocity = new Vector3(0,0,0);
		}

		//Evita que a bola pule na mesa
		if(transform.position.y > 0.19f){
			transform.position = new Vector3(transform.position.x,0.19f,transform.position.z);
		}
	}
}
